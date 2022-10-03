using Supervisorio.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UcMachineInfosModel;

namespace Supervisorio
{
    public class ComponentesVisuais
    {
        public event EventHandler<MouseEventArgs> ComponenteClickedPanel;
        public event EventHandler<MouseEventArgs> ComponenteClickedButton;

        public Panel PanelGrupos { get; set; }

        public TiposComponentes TiposComponentes
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Cria o painel que contem o titulo da máquina com todos os grupos e todos os componentes
        /// </summary>
        /// <param name="sNome">Nome da máquina</param>
        /// <param name="Grupos">componentes visuais dos Grupos de sinais da máquina</param>
        /// <returns></returns>
        public Panel CriarPanelMaquina(string sNome, List<GrupoSinais> Grupos)
        {
            PanelGrupos = new Panel();
            Panel PanelGrupoTitle = new Panel();
            Label Title = new Label();
            List<Object> GruposSinais = new List<object>();
            foreach (var Grupo in Grupos)
            {
                Panel Divisao = CriarGrupoDivider(Grupo.sGrupoName);
                FlowLayoutPanel PainelSinais = CriarPainelResponsivoSinais(Grupo.sGrupoName, Grupo.oSinaisComponentesVisuais);

                GruposSinais.Add(PainelSinais);
                GruposSinais.Add(Divisao);
            }


            // 
            // PanelTitleMaquina
            // 
            PanelGrupoTitle.Controls.Add(Title);
            PanelGrupoTitle.Dock = System.Windows.Forms.DockStyle.Top;
            PanelGrupoTitle.Location = new System.Drawing.Point(0, 0);
            PanelGrupoTitle.Name = "HeadGroupPanel";
            PanelGrupoTitle.Size = new System.Drawing.Size(517, 40);
            PanelGrupoTitle.Padding = new System.Windows.Forms.Padding(5, 5, 5, 20);
            PanelGrupoTitle.TabIndex = 0;
            // 
            // txtTitleMaquina
            // 
            Title.AutoSize = true;
            Title.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            Title.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            Title.Location = new System.Drawing.Point(20, 20);
            Title.Name = "txtTitleMaquina";
            Title.Size = new System.Drawing.Size(47, 16);
            Title.TabIndex = 1;
            Title.Text = sNome;

            // 
            // PanelGrupo
            // 
            PanelGrupos.AutoSize = true;
            PanelGrupos.AutoScroll = true;
            PanelGrupos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            PanelGrupos.Location = new System.Drawing.Point(3, 3);
            PanelGrupos.Dock = System.Windows.Forms.DockStyle.Fill;
            PanelGrupos.Name = sNome;
            PanelGrupos.Size = new Size(500, 400);
            PanelGrupos.TabIndex = 2;

            foreach (var DivisoresAndGrupos in GruposSinais)
            {
                PanelGrupos.Controls.Add((Control)DivisoresAndGrupos);
            }

            PanelGrupos.Controls.Add(PanelGrupoTitle);

            return PanelGrupos;
        }

        private Panel CriarGrupoDivider(string sName)
        {
            Panel PanelTitleGroupSinais = new Panel();
            Label txtTitleGrupoSinais = new Label();
            // 
            // PanelTitleGroupSinais
            // 
            PanelTitleGroupSinais.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(92)))), ((int)(((byte)(87)))));
            PanelTitleGroupSinais.Controls.Add(txtTitleGrupoSinais);
            PanelTitleGroupSinais.Dock = System.Windows.Forms.DockStyle.Top;
            PanelTitleGroupSinais.Location = new System.Drawing.Point(0, 40);
            PanelTitleGroupSinais.Name = "PanelTitleGroupSinais";
            PanelTitleGroupSinais.Size = new System.Drawing.Size(647, 25);
            PanelTitleGroupSinais.TabIndex = 2;
            // 
            // txtTitleGrupoSinais
            // 
            txtTitleGrupoSinais.AutoSize = true;
            txtTitleGrupoSinais.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            txtTitleGrupoSinais.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(199)))), ((int)(((byte)(140)))));
            txtTitleGrupoSinais.Location = new System.Drawing.Point(34, 5);
            txtTitleGrupoSinais.Name = "txtTitleGrupoSinais";
            txtTitleGrupoSinais.Size = new System.Drawing.Size(152, 17);
            txtTitleGrupoSinais.TabIndex = 1;
            txtTitleGrupoSinais.Text = sName;

            return PanelTitleGroupSinais;
        }

        private FlowLayoutPanel CriarPainelResponsivoSinais(string sTag, List<Panel> SinaisComponents)
        {
            FlowLayoutPanel oFlowLayoutPanel = new FlowLayoutPanel();
            // 
            // flowLayoutPanel
            // 
            oFlowLayoutPanel.AutoSize = true;
            oFlowLayoutPanel.AutoScroll = true;
            oFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            oFlowLayoutPanel.Location = new System.Drawing.Point(0, 40);
            oFlowLayoutPanel.Name = sTag;
            oFlowLayoutPanel.Padding = new System.Windows.Forms.Padding(5, 5, 5, 20);
            oFlowLayoutPanel.Size = new System.Drawing.Size(517, 400);
            oFlowLayoutPanel.TabIndex = 0;

            foreach (var Componente in SinaisComponents)
            {
                oFlowLayoutPanel.Controls.Add((Control)Componente);
            }

            return oFlowLayoutPanel;

        }

        public Panel CriarComponenteGauge(string sNome, string sTag, string sUnidadeMedida, int nMin = 0, int nMax = 100)
        {
            CircularProgressBar.CircularProgressBar oProgressBar = new CircularProgressBar.CircularProgressBar();
            Panel PanelGauge = new Panel();
            Label oVariavelTitle = new Label();
            //
            // circular progress bar
            //
            oProgressBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            oProgressBar.AnimationSpeed = 500;
            oProgressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            oProgressBar.Font = new System.Drawing.Font("Calibri", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            oProgressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(199)))), ((int)(((byte)(140)))));
            oProgressBar.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(29)))), ((int)(((byte)(30)))));
            oProgressBar.InnerMargin = -1;
            oProgressBar.InnerWidth = -1;
            oProgressBar.Location = new System.Drawing.Point(0, 0);
            oProgressBar.MarqueeAnimationSpeed = 2000;
            oProgressBar.Name = "Gauge";
            oProgressBar.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(29)))), ((int)(((byte)(30)))));
            oProgressBar.OuterMargin = -15;
            oProgressBar.OuterWidth = 8;
            oProgressBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(199)))), ((int)(((byte)(140)))));
            oProgressBar.ProgressWidth = 5;
            oProgressBar.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 4.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            oProgressBar.Size = new System.Drawing.Size(150, 150);
            oProgressBar.StartAngle = 270;
            oProgressBar.SubscriptColor = System.Drawing.Color.Gray;
            oProgressBar.SubscriptMargin = new System.Windows.Forms.Padding(0);
            oProgressBar.SubscriptText = "";
            oProgressBar.SuperscriptColor = System.Drawing.Color.Gray;
            oProgressBar.SuperscriptMargin = new System.Windows.Forms.Padding(0);
            oProgressBar.SuperscriptText = "";
            oProgressBar.TabIndex = 10;
            oProgressBar.Text = "...";
            oProgressBar.TextMargin = new System.Windows.Forms.Padding(3, 5, 0, 0);
            oProgressBar.Maximum = nMax;
            oProgressBar.Minimum = nMin;
            oProgressBar.Value = 0;

            // 
            // GaugePanel
            // 
            PanelGauge.AutoSize = true;
            PanelGauge.Controls.Add(oVariavelTitle);
            PanelGauge.Controls.Add(oProgressBar);
            PanelGauge.Location = new System.Drawing.Point(201, 8);
            PanelGauge.Name = sNome;
            PanelGauge.Tag = new Sinal { sEndereco = sTag, sTipo = TiposComponentes.EntradaGauge, sUnidade = sUnidadeMedida, nMax = nMax, nMin = nMin };
            PanelGauge.Size = new System.Drawing.Size(153, 153);
            PanelGauge.TabIndex = 11;
            // 
            // GaugeTitle
            // 
            oVariavelTitle.AutoSize = true;
            //LabelGauge.Dock = System.Windows.Forms.DockStyle.Bottom;
            oVariavelTitle.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.GraphicsUnit.Point);
            oVariavelTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            oVariavelTitle.Location = new System.Drawing.Point(5, 150);
            oVariavelTitle.Name = "GaugeTitle";
            oVariavelTitle.Size = new System.Drawing.Size(58, 18);
            oVariavelTitle.TabIndex = 0;
            oVariavelTitle.Text = sNome;


            return PanelGauge;
        }

        public Panel CriarComponenteEntradaDigital(string sNome, string sTag)
        {
            Panel oVariavelPanel = new Panel();
            Label oVariavelTitle = new Label();

            // 
            // PanelVariavelRead
            // 
           
            
            oVariavelPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(92)))), ((int)(((byte)(84)))));
            oVariavelPanel.Controls.Add(oVariavelTitle);
            oVariavelPanel.Location = new System.Drawing.Point(8, 8);
            oVariavelPanel.Name = sNome;
            oVariavelPanel.Size = new System.Drawing.Size(187, 27);
            oVariavelPanel.TabIndex = 0;
            oVariavelPanel.Tag = new Sinal { sEndereco = sTag, sTipo = TiposComponentes.EntradaDigital };
            // 
            // txtVariavelName
            // 
            oVariavelTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            oVariavelTitle.AutoSize = true;
            oVariavelTitle.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            oVariavelTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            oVariavelTitle.Location = new System.Drawing.Point(67, 6);
            oVariavelTitle.Name = "txtVariavelName";
            oVariavelTitle.Size = new System.Drawing.Size(42, 16);
            oVariavelTitle.TabIndex = 0;
            oVariavelTitle.Text = sNome;

            return oVariavelPanel;
        }

        public Panel CriarComponenteSaidaDigital(string sNome,string sTag)
        {
            Panel PanelSaidaDigital = new Panel();
            Label oVariavelTitle = new Label();
            // 
            // PanelEntradaDigital
            // 
            
            PanelSaidaDigital.BackgroundImage = Image.FromFile("./Imagens/indefinido 30.png");
            PanelSaidaDigital.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            PanelSaidaDigital.Controls.Add(oVariavelTitle);
            PanelSaidaDigital.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            PanelSaidaDigital.Location = new System.Drawing.Point(360, 8);
            PanelSaidaDigital.Name = sNome;
            PanelSaidaDigital.Tag = new Sinal { sEndereco = sTag, sTipo = TiposComponentes.SaidaDigital };
            PanelSaidaDigital.Size = new System.Drawing.Size(100, 50);
            PanelSaidaDigital.TabIndex = 12;
            PanelSaidaDigital.MouseClick += EventoMouseClickPanel;
            PanelSaidaDigital.MouseHover += EventoMouseRover;
            PanelSaidaDigital.MouseLeave += EventoMouseLeave;
            // 
            // txtTitleEntraDigital
            // 
            oVariavelTitle.AutoSize = true;
            oVariavelTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
            oVariavelTitle.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            oVariavelTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            oVariavelTitle.Location = new System.Drawing.Point(0, 34);
            oVariavelTitle.Name = "txtTitleEntraDigital";
            oVariavelTitle.Size = new System.Drawing.Size(42, 16);
            oVariavelTitle.TabIndex = 1;
            oVariavelTitle.Text = sNome;
            

            return PanelSaidaDigital;
        }

        public Panel CriarComponenteEntradaString(string sNome,string sTag)
        {
            Panel PainelString = new Panel();
            Label txtTitle = new Label();
            Label txtValue = new Label();
            // 
            // PanelVariavelString
            // 
            PainelString.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(199)))), ((int)(((byte)(140)))));
            PainelString.Controls.Add(txtValue);
            PainelString.Controls.Add(txtTitle);
            PainelString.Location = new System.Drawing.Point(8, 167);
            PainelString.Name = sNome;
            PainelString.Tag = new Sinal { sEndereco = sTag, sTipo = TiposComponentes.EntradaString }; 
            PainelString.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            PainelString.Size = new System.Drawing.Size(187, 80);
            PainelString.TabIndex = 13;
            // 
            // txtValueVariavelString
            // 
            txtValue.Dock = System.Windows.Forms.DockStyle.Fill;
            txtValue.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            txtValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            txtValue.Location = new System.Drawing.Point(5, 24);
            txtValue.Name = "Value";
            txtValue.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            txtValue.Size = new System.Drawing.Size(182, 56);
            txtValue.TabIndex = 1;
            txtValue.Text = "...";
            // 
            // txtTitleVariavelString
            // 
            txtTitle.AutoSize = true;
            txtTitle.Dock = System.Windows.Forms.DockStyle.Top;
            txtTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            txtTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            txtTitle.Location = new System.Drawing.Point(5, 5);
            txtTitle.Name = "txtTitleVariavelString";
            txtTitle.Size = new System.Drawing.Size(48, 19);
            txtTitle.TabIndex = 1;
            txtTitle.Text = sNome;

            return PainelString;
        }

        public Panel CriarElementoSaidaString(string sNome, string sTag)
        {
            Panel PainelSaidaString = new Panel();
            Panel PainelStatusString = new Panel();
            TextBox txtBox = new TextBox();
            Label txtTitle = new Label();
            Button ButtonEnviar = new Button();
            // 
            // PanelSaidaAnalogica
            // 
            PainelSaidaString.Controls.Add(ButtonEnviar);
            PainelSaidaString.Controls.Add(txtTitle);
            PainelSaidaString.Controls.Add(PainelStatusString);
            PainelSaidaString.Controls.Add(txtBox);
            PainelSaidaString.Location = new System.Drawing.Point(201, 167);
            PainelSaidaString.Name = sNome;
            PainelSaidaString.Tag = new Sinal { sEndereco = sTag, sTipo = TiposComponentes.SaidaString };
            PainelSaidaString.Size = new System.Drawing.Size(276, 49);
            PainelSaidaString.TabIndex = 14;
            // 
            // txtTitleSaidaAnalogica
            // 
            txtTitle.AutoSize = true;
            txtTitle.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            txtTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            txtTitle.Location = new System.Drawing.Point(0, 26);
            txtTitle.Name = "txtTitleEntradaAnalogica";
            txtTitle.Size = new System.Drawing.Size(42, 16);
            txtTitle.TabIndex = 2;
            txtTitle.Text = sNome;
            // 
            // PanelSaidaAnalogicaStatus
            // 
            PainelStatusString.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(92)))), ((int)(((byte)(87)))));
            PainelStatusString.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            PainelStatusString.Location = new System.Drawing.Point(0, 0);
            PainelStatusString.Name = "PanelEntradaAnalogicaStatus";
            PainelStatusString.Size = new System.Drawing.Size(23, 23);
            PainelStatusString.TabIndex = 1;
            // 
            // textBoxSaidaAnalogica
            // 
            txtBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(29)))), ((int)(((byte)(30)))));
            txtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtBox.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            txtBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(199)))), ((int)(((byte)(140)))));
            txtBox.Location = new System.Drawing.Point(23, 0);
            txtBox.Name = "TextBox";
            txtBox.PlaceholderText = "Digite...";
            txtBox.Size = new System.Drawing.Size(170, 24);
            txtBox.TabIndex = 0;
            // 
            // buttonSaidaAnalogica
            //
            ButtonEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(92)))), ((int)(((byte)(87)))));
            ButtonEnviar.FlatAppearance.BorderSize = 0;
            ButtonEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ButtonEnviar.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            ButtonEnviar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            ButtonEnviar.Location = new System.Drawing.Point(199, 0);
            ButtonEnviar.Name = "txtSaidaAnalogicaEnviar";
            ButtonEnviar.Size = new System.Drawing.Size(75, 23);
            ButtonEnviar.TabIndex = 0;
            ButtonEnviar.Text = "Enviar";
            ButtonEnviar.UseVisualStyleBackColor = false;
            List<object> oDados = new List<object>();
            oDados.Add(txtBox);
            oDados.Add(PainelStatusString);
            ButtonEnviar.Tag = new Sinal
            {
                sTipo = TiposComponentes.SaidaString,
                sEndereco = sTag
            };

            ButtonEnviar.MouseClick += EventoMouseClickButton;

            return PainelSaidaString;
        }

        public Panel CriarElementoSaidaNumerica(string sNome, string sTag)
        {
            Panel PainelSaidaString = new Panel();
            Panel PainelStatusString = new Panel();
            TextBox txtBox = new TextBox();
            Label txtTitle = new Label();
            Button ButtonEnviar = new Button();
            // 
            // PanelSaidaAnalogica
            // 
            PainelSaidaString.Controls.Add(ButtonEnviar);
            PainelSaidaString.Controls.Add(txtTitle);
            PainelSaidaString.Controls.Add(PainelStatusString);
            PainelSaidaString.Controls.Add(txtBox);
            PainelSaidaString.Location = new System.Drawing.Point(201, 167);
            PainelSaidaString.Name = sNome;
            PainelSaidaString.Tag = new Sinal { sEndereco = sTag, sTipo = TiposComponentes.SaidaString };
            PainelSaidaString.Size = new System.Drawing.Size(276, 49);
            PainelSaidaString.TabIndex = 14;
            // 
            // txtTitleSaidaAnalogica
            // 
            txtTitle.AutoSize = true;
            txtTitle.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            txtTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            txtTitle.Location = new System.Drawing.Point(0, 26);
            txtTitle.Name = "txtTitleEntradaAnalogica";
            txtTitle.Size = new System.Drawing.Size(42, 16);
            txtTitle.TabIndex = 2;
            txtTitle.Text = sNome;
            // 
            // PanelSaidaAnalogicaStatus
            // 
            PainelStatusString.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(92)))), ((int)(((byte)(87)))));
            PainelStatusString.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            PainelStatusString.Location = new System.Drawing.Point(0, 0);
            PainelStatusString.Name = "PanelEntradaAnalogicaStatus";
            PainelStatusString.Size = new System.Drawing.Size(23, 23);
            PainelStatusString.TabIndex = 1;
            // 
            // textBoxSaidaAnalogica
            // 
            txtBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(29)))), ((int)(((byte)(30)))));
            txtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtBox.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            txtBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(199)))), ((int)(((byte)(140)))));
            txtBox.Location = new System.Drawing.Point(23, 0);
            txtBox.Name = "TextBox";
            txtBox.PlaceholderText = "Digite um número...";
            txtBox.Size = new System.Drawing.Size(170, 24);
            txtBox.TabIndex = 0;
            txtBox.KeyPress += TxtBox_KeyPress;
            // 
            // buttonSaidaAnalogica
            //
            ButtonEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(92)))), ((int)(((byte)(87)))));
            ButtonEnviar.FlatAppearance.BorderSize = 0;
            ButtonEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ButtonEnviar.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            ButtonEnviar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            ButtonEnviar.Location = new System.Drawing.Point(199, 0);
            ButtonEnviar.Name = "txtSaidaAnalogicaEnviar";
            ButtonEnviar.Size = new System.Drawing.Size(75, 23);
            ButtonEnviar.TabIndex = 0;
            ButtonEnviar.Text = "Enviar";
            ButtonEnviar.UseVisualStyleBackColor = false;
            List<object> oDados = new List<object>();
            oDados.Add(txtBox);
            oDados.Add(PainelStatusString);
            ButtonEnviar.Tag = new Sinal
            {
                sTipo = TiposComponentes.SaidaNumerica,
                sEndereco = sTag
            };

            ButtonEnviar.MouseClick += EventoMouseClickButton;

            return PainelSaidaString;
        }

        private void TxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void EventoMouseClickPanel(object sender, MouseEventArgs e)
        {
            ComponenteClickedPanel.Invoke(sender, e);
        }

        private void EventoMouseClickButton(object sender, MouseEventArgs e)
        {
            var MeuBotao = (Button)sender;
            var MeuPanelSaidaAnalogica = MeuBotao.Parent;
            ComponenteClickedButton.Invoke(MeuPanelSaidaAnalogica, e);
        }

       

        private void EventoMouseLeave(object sender, EventArgs e)
        {
            Panel Component = (Panel)sender;
            Component.BorderStyle = BorderStyle.None;
        }

        private void EventoMouseRover(object sender, EventArgs e)
        {
            Panel Component = (Panel)sender;
            Component.BorderStyle = BorderStyle.FixedSingle;
        }

    }

    public class TiposComponentes
    {
        public const string EntradaDigital = "EntradaDigital";
        public const string SaidaDigital = "SaidaDigital";
        public const string EntradaGauge = "EntradaGauge";
        public const string EntradaString = "EntradaString";
        public const string SaidaString = "SaidaString";
        public const string SaidaNumerica = "SaidaNumerica";
    }
}
