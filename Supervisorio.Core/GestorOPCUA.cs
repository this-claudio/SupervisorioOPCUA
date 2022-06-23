using System;
using Supervisorio.Model;
using OpcUaCommon;
using System.Timers;

namespace Supervisorio.OPC
{
    public class GestorOPCUA
    {
        public ClassOPCClient oClientOPC {get;set;}
        public Machine oDadosMaquina { get; set; }
        public string sIP { get; set; }
        public string sPorta { get; set; }
        public string sUsername { get; set; }
        public string sSenha { get; set; }
        public Timer TimerCheckDesconexao { get; set; }

        public GestorOPCUA(Machine DadosMaquinaInicial)
        {
            this.oDadosMaquina = DadosMaquinaInicial;
            this.sIP = DadosMaquinaInicial.sEnderecoIP;
            this.sPorta = DadosMaquinaInicial.sPorta;
            this.sUsername = DadosMaquinaInicial.sUser;
            this.sSenha = DadosMaquinaInicial.sPassword;
            ConectarServidor();
            StartCheckDesconexao();
        }

        public void ConectarServidor()
        {
            try
            {
                if(this.oClientOPC == null)
                this.oClientOPC = new ClassOPCClient
                    (
                        this.sIP,
                        this.sPorta,
                        this.sUsername,
                        this.sSenha
                    );
                this.oClientOPC.Conectar();
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateDadosMaquina()
        {
            try
            {
                if (!EstaConectado())
                {
                    this.oDadosMaquina.sEstadoConexao = "Desconectado";
                    throw new Exception("Não foi possivel ler os dados devido à: Client Desconectado");
                }
                else 
                {
                    this.oDadosMaquina.sEstadoConexao = "Conectado";
                }


                foreach (Grupo Grupo in this.oDadosMaquina.Grupos)
                    {
                        if (Grupo != null)
                        foreach (Sinal Sinal in Grupo.Sinais)
                        {
                            if (Sinal != null)
                            {
                                if (!string.IsNullOrEmpty(Sinal.sEndereco))
                                {
                                    var Value = this.oClientOPC.GetNodeValue(Sinal.sEndereco);
                                    if (Value == null) break;
                                    Sinal.oValue = (Value);
                                }
                            }
                        }
                    }
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possivel ler os dados devido à: " + e.Message);
            }

            
        }

        public void PublishValueUpdate(string sEndereco, object oNewValue)
        {
            try
            {
                if (!EstaConectado())
                {
                    this.oDadosMaquina.sEstadoConexao = "Desconectado";
                    throw new Exception("Não foi possivel escrever os dados devido à: Client Desconectado");
                }
                else
                {
                    this.oDadosMaquina.sEstadoConexao = "Conectado";
                }

                this.oClientOPC.SetNodeValue(sEndereco, oNewValue);
            }
            catch(Exception e) 
            {
                throw new Exception("Não foi possivel gravar o dado devido à: " + e.Message);
            }
        }

        public bool EstaConectado()
        {
            if (this.oClientOPC == null) return false;
            if (this.oClientOPC.SessioStatus == ClassOPCClient.EstadoConexao.Conectado) return true;
            else return false;
        }

        public void StartCheckDesconexao()
        {
            if (TimerCheckDesconexao == null)
            {
                TimerCheckDesconexao = new Timer();
                TimerCheckDesconexao.Enabled = true;
                TimerCheckDesconexao.Interval = 10000;
                TimerCheckDesconexao.Elapsed += TimerCheckDesconexao_Elapsed;
            }
                TimerCheckDesconexao.Start();
        }

        private void TimerCheckDesconexao_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!EstaConectado())
                this.ConectarServidor();
        }
    }
}
