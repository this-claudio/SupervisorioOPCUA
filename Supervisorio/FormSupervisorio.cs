
using System;
using System.Collections.Generic;
using Supervisorio.Model;
using Supervisorio.Persistencia;
using Supervisorio.OPC;
using System.Windows.Forms;
using System.Drawing;

namespace Supervisorio
{
    public partial class FormSupervisorio : Form
    {
        GrupoMaquinas ParametrosMaquinas { get; set; }
        ConfigGeralPersistence Persistence { get; set; }
        Timer TimerAtualizaDados { get; set; }
        List<ModuloMaquina> MinhasMaquinas { get; set; }

        public ModuloMaquina ModuloMaquina
        {
            get => default;
            set
            {
            }
        }

        public ConfigGeralPersistence ConfigGeralPersistence
        {
            get => default;
            set
            {
            }
        }

        public FormSupervisorio()
        {
            InitializeComponent();

            this.Persistence = new ConfigGeralPersistence();
            this.ParametrosMaquinas = Persistence.GetParametros();

            this.MinhasMaquinas = new List<ModuloMaquina>();

            foreach (var ParametroMaquina in this.ParametrosMaquinas.Machines)
            {
                ModuloMaquina oMaquina = new ModuloMaquina();
                oMaquina.MachineClientOPC = new GestorOPCUA(ParametroMaquina);
                oMaquina.oDadoMaquina = ParametroMaquina;
                oMaquina.oMaquinaView = new UcMachineInfos();
                oMaquina.oMaquinaView.ClickSaidaDigital += TratarClickPanel;
                oMaquina.oMaquinaView.ClickEnviarSaidaAnalogica += TratarClickButton;
                oMaquina.oMaquinaView.CreateMaquineScreen(ParametroMaquina.sNome, ParametroMaquina);
                oMaquina.oMaquinaView.Dock = DockStyle.Fill;
                CreateButton(ParametroMaquina.sNome, oMaquina.oMaquinaView);
                AddMachineView(oMaquina.oMaquinaView);
                MinhasMaquinas.Add(oMaquina);
            }

            this.SidePanel.Controls.Add(this.HeadPanel);

            StartTemplate();
        }

        private void AddMachineView(UcMachineInfos MachineScreen)
        {
            this.CenterPanel.Controls.Add(MachineScreen);
        }

        public void CreateButton(string sNome, UcMachineInfos MachineInfoScreen)
        {
            Button Botao = new Button();
            // 
            // MaquinaButton
            // 
            Botao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(29)))), ((int)(((byte)(30)))));
            Botao.BackgroundImage = Image.FromFile("./Imagens/machine40.png");
            Botao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            Botao.Dock = System.Windows.Forms.DockStyle.Top;
            Botao.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(29)))), ((int)(((byte)(30)))));
            Botao.FlatAppearance.BorderSize = 0;
            Botao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Botao.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            Botao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(199)))), ((int)(((byte)(140)))));
            Botao.Location = new System.Drawing.Point(0, 134);
            Botao.Name = sNome;
            Botao.Size = new System.Drawing.Size(200, 40);
            Botao.TabIndex = 1;
            Botao.Text = sNome;
            Botao.Tag = MachineInfoScreen;
            Botao.UseVisualStyleBackColor = false;
            Botao.MouseClick += BotaoMachine_MouseClick;

            this.SidePanel.Controls.Add(Botao);
        }

        private void StartTemplate()
        {
            if (TimerAtualizaDados == null)
            {
                TimerAtualizaDados = new Timer();
                TimerAtualizaDados.Enabled = true;
                TimerAtualizaDados.Interval = 800;
                TimerAtualizaDados.Tick += UpdateInterface;
                TimerAtualizaDados.Start();
            }
        }

        private void UpdateInterface(object sender, EventArgs e)
        {
            try
            {
                foreach (var Maquina in this.MinhasMaquinas)
                {
                    try
                    {
                        Maquina.MachineClientOPC.UpdateDadosMaquina();
                    }
                    catch (Exception Erro)
                    {

                    }

                    Maquina.oMaquinaView.UpdateViewData(Maquina.oDadoMaquina);
                }
            }
            catch (Exception Erro)
            {

            }
        }


        #region EVENTOS
        private void BotaoMachine_MouseClick(object sender, MouseEventArgs e)
        {
            var Botao = (Button)sender;
            var UcMachine = (UcMachineInfos)Botao.Tag;
            UcMachine.BringToFront();
        }

        private void TratarClickPanel(object sender, MouseEventArgs e)
        {
            try
            {
                var ClickedPanel = (Panel)sender;
                var Info = (Sinal)ClickedPanel.Tag;
                var MachineScreen = (Panel)ClickedPanel.Parent.Parent;
                string NomeMaquina = MachineScreen.Name;
                var DadosMachinaImMemory = (ModuloMaquina)MinhasMaquinas.Find(x => x.oDadoMaquina.sNome == NomeMaquina);
                //var Sinal = Persistence.GetSinalByEndereco( DadosMachinaImMemory.oDadoMaquina, inf)
                var bEstadoAtual = (bool)Info.oValue;
                DadosMachinaImMemory.MachineClientOPC.PublishValueUpdate(Info.sEndereco.ToString(), !bEstadoAtual);
            }
            catch (Exception Error2)
            {
                var a = Error2;
            }

        }

        private void TratarClickButton(object sender, MouseEventArgs e)
        {

            var PanelStatus = new Panel();
            try
            {
                var PanelSaidaAnalogica = (Control)sender;
                var Info = (Sinal)PanelSaidaAnalogica.Tag;
                var TextoInput = (TextBox)PanelSaidaAnalogica.Controls.Find("TextBox", true)[0];
                PanelStatus = (Panel)PanelSaidaAnalogica.Controls.Find("PanelEntradaAnalogicaStatus", true)[0];

                var MachineScreen = (Panel)PanelSaidaAnalogica.Parent.Parent;
                string NomeMaquina = MachineScreen.Name;
                var DadosMachinaImMemory = (ModuloMaquina)MinhasMaquinas.Find(x => x.oDadoMaquina.sNome == NomeMaquina);

                DadosMachinaImMemory.MachineClientOPC.PublishValueUpdate(Info.sEndereco.ToString(), TextoInput.Text.ToString());


                PanelStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(199)))), ((int)(((byte)(140)))));
                PanelStatus.BackgroundImage = Image.FromFile("./Imagens/check23.png");
            }
            catch (Exception error1)
            {

                PanelStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(92)))), ((int)(((byte)(93)))));
                PanelStatus.BackgroundImage = Image.FromFile("./Imagens/error23.png");
            }

        }

        #endregion

    }

    public class ModuloMaquina
    {
        public GestorOPCUA MachineClientOPC { get; set; }
        public Machine oDadoMaquina { get; set; }

        public UcMachineInfos oMaquinaView { get; set; }

        public UcMachineInfos UcMachineInfos
        {
            get => default;
            set
            {
            }
        }

        public GestorOPCUA GestorOPCUA
        {
            get => default;
            set
            {
            }
        }

        public GrupoMaquinas GrupoMaquinas
        {
            get => default;
            set
            {
            }
        }

        public Machine Machine
        {
            get => default;
            set
            {
            }
        }
    }
}
