using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using UcMachineInfosModel;
using Supervisorio.Model;

namespace Supervisorio
{
    public partial class UcMachineInfos : UserControl
    {
        public event EventHandler<MouseEventArgs> ClickSaidaDigital;
        public event EventHandler<MouseEventArgs> ClickEnviarSaidaAnalogica;
        public ComponentesVisuais CriadorComponentes { get; set; }

        public ComponentesVisuais ComponentesVisuais
        {
            get => default;
            set
            {
            }
        }

        public GrupoSinais GrupoSinais
        {
            get => default;
            set
            {
            }
        }

        public UcMachineInfos()
        {
            InitializeComponent();
            CriadorComponentes = new ComponentesVisuais();
            CriadorComponentes.ComponenteClickedButton += CriadorComponentes_ComponenteClickedButton;
            CriadorComponentes.ComponenteClickedPanel += CriadorComponentes_ComponenteClickedPanel;
        }

        /// <summary>
        /// Cria a tela da máquina com base nos parametros;
        /// </summary>
        /// <param name="sNome">Nome da máquina, será utilizado no titulo da tela</param>
        /// <param name="ParametrosMaquina">Todos os parametros da máquina</param>
        public void CreateMaquineScreen(string sNome, Machine ParametrosMaquina)
        {
            List<GrupoSinais> GruposVariaveis = new List<GrupoSinais>();
            

            foreach (var Grupo in ParametrosMaquina.Grupos)
            {
                var NovoGrupo = new GrupoSinais(Grupo.sNomeGrupo);
                foreach (var Sinal in Grupo.Sinais)
                {
                    Panel componenteVisual = new Panel();

                    switch (Sinal.sTipo)
                    {
                        case TiposComponentes.EntradaDigital:
                            {
                                componenteVisual = CriadorComponentes.CriarComponenteEntradaDigital(Sinal.sNomeSinal, Sinal.sEndereco);
                                break;
                            }
                        case TiposComponentes.SaidaDigital:
                            {
                                componenteVisual = CriadorComponentes.CriarComponenteSaidaDigital(Sinal.sNomeSinal, Sinal.sEndereco);
                                break;
                            }
                        case TiposComponentes.EntradaGauge:
                            {
                                componenteVisual = CriadorComponentes.CriarComponenteGauge(Sinal.sNomeSinal, Sinal.sEndereco, Sinal.sUnidade,Sinal.nMin, Sinal.nMax);
                                break;
                            }
                        case TiposComponentes.EntradaString:
                            {
                                componenteVisual = CriadorComponentes.CriarComponenteEntradaString(Sinal.sNomeSinal, Sinal.sEndereco);
                                break;
                            }
                        case TiposComponentes.SaidaAnalogica:
                            {
                                componenteVisual = CriadorComponentes.CriarElementoSaidaAnalogica(Sinal.sNomeSinal, Sinal.sEndereco);
                                break;
                            }
                    }
                    NovoGrupo.AddComponente(componenteVisual);
                }
                GruposVariaveis.Add(NovoGrupo);
            }


            this.Controls.Clear();
            Panel NovoGrupoPanel = CriadorComponentes.CriarPanelMaquina(sNome, GruposVariaveis);
            this.Controls.Add(NovoGrupoPanel);
        }
        /// <summary>
        /// Função que procura os componentes visuais e atualiza um por um
        /// </summary>
        /// <param name="ParametrosMaquina">Parametros usados para encontrar e atualizar os valores</param>
        public void UpdateViewData(Machine ParametrosMaquina)
        {
            Control[] TitleMaquina = this.Controls.Find("txtTitleMaquina", true);
            string EstadoMaquina = 
                string.IsNullOrEmpty(ParametrosMaquina.sEstadoConexao) ? "" : (" (" + ParametrosMaquina.sEstadoConexao + ")");

            TitleMaquina[0].Text = ParametrosMaquina.sNome + EstadoMaquina;

            foreach (var Grupo in ParametrosMaquina.Grupos)
            {
                foreach (var Sinal in Grupo.Sinais)
                {
                    Control[] GruposView = this.Controls.Find(Grupo.sNomeGrupo, true);
                    if (GruposView != null  && GruposView.Count() > 0 )
                    {
                        foreach (var GrupoView in GruposView)
                        {
                            Control[] SinaisView = GrupoView.Controls.Find(Sinal.sNomeSinal, true);
                            if (SinaisView != null && SinaisView.Count() > 0)
                            {
                                foreach (var SinalView in SinaisView)
                                {
                                    AtualizaValores(Sinal, (Panel)SinalView);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Atualiza os valores na componentes da tela
        /// </summary>
        /// <param name="Sinal">É a informação do sinal, disrespeito a posição dos itens na tela seu tipo e endereço</param>
        /// <param name="PanelView">Foi o componente Panel encontrado com base nas informações do Sinal</param>
        /// <param name="ClientMachine"></param>
        private void AtualizaValores(Sinal Sinal, Panel PanelView)
        {
            
            switch (Sinal.sTipo)
            {
                case TiposComponentes.EntradaDigital:
                    {
                        var Infos = (Sinal)PanelView.Tag;
                        if (Infos.sTipo == Sinal.sTipo)
                        {
                            if (Sinal.oValue == null) break;
                            if ((bool)Sinal.oValue)
                                PanelView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(199)))), ((int)(((byte)(140)))));
                            else
                                PanelView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(92)))), ((int)(((byte)(93)))));
                        }
                        PanelView.Tag = Sinal;
                        break;
                    }
                case TiposComponentes.SaidaDigital:
                    {
                        var Infos = (Sinal)PanelView.Tag;
                        if (Infos.sTipo == Sinal.sTipo)
                        {
                            
                            if (Sinal.oValue == null) break;
                            if ((bool)Sinal.oValue)
                                PanelView.BackgroundImage = Image.FromFile("./Imagens/turn on 30.png");
                            else
                                PanelView.BackgroundImage = Image.FromFile("./Imagens/turn off 30.png");
                        }
                        PanelView.Tag = Sinal;
                        break;
                    }
                case TiposComponentes.EntradaGauge:
                    {
                        var Infos = (Sinal)PanelView.Tag;
                        if (Infos.sTipo == Sinal.sTipo)
                        {
                            
                            if (Sinal.oValue == null) break;
                            Control[] Gauge = PanelView.Controls.Find("Gauge", true);
                            if (Gauge != null)
                            {
                                var ProgessBar = (CircularProgressBar.CircularProgressBar)Gauge[0];
                                ProgessBar.Value = Convert.ToInt32(Sinal.oValue);
                                ProgessBar.Text = Sinal.oValue.ToString() + "" + Infos.sUnidade;
                            }
                        }
                        PanelView.Tag = Sinal;
                        break;
                    }
                case TiposComponentes.EntradaString:
                    {
                        var Infos = (Sinal)PanelView.Tag;
                        if (Infos.sTipo == Sinal.sTipo)
                        {
                            if (Sinal.oValue == null) break;
                            Control[] txtValue = PanelView.Controls.Find("Value", true);
                            if (txtValue != null && txtValue.Count() > 0)
                            {
                                txtValue[0].Text = Sinal.oValue.ToString();
                            }
                        }
                        PanelView.Tag = Sinal;
                        break;
                    }
            }
        }

        #region EVENTOS
        private void CriadorComponentes_ComponenteClickedPanel(object sender, MouseEventArgs e)
        {
            ClickSaidaDigital.Invoke(sender, e);
        }

        private void CriadorComponentes_ComponenteClickedButton(object sender, MouseEventArgs e)
        {
            ClickEnviarSaidaAnalogica.Invoke(sender, e);
        }
        #endregion
    }
}




