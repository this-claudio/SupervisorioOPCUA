using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using UcMachineInfosModel;
using WinFormAnimation;


namespace Supervisorio
{
    partial class UcMachineInfos
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcMachineInfos));
            this.PanelMachineGroup = new System.Windows.Forms.Panel();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.PanelVariavelRead = new System.Windows.Forms.Panel();
            this.txtVariavelName = new System.Windows.Forms.Label();
            this.GaugePanel = new System.Windows.Forms.Panel();
            this.GaugeTitle = new System.Windows.Forms.Label();
            this.oCircularProgressBar = new CircularProgressBar.CircularProgressBar();
            this.PanelEntradaDigital = new System.Windows.Forms.Panel();
            this.txtTitleEntraDigital = new System.Windows.Forms.Label();
            this.PanelVariavelString = new System.Windows.Forms.Panel();
            this.txtValueVariavelString = new System.Windows.Forms.Label();
            this.txtTitleVariavelString = new System.Windows.Forms.Label();
            this.PanelSaidaAnalogica = new System.Windows.Forms.Panel();
            this.txtSaidaAnalogicaEnviar = new System.Windows.Forms.Button();
            this.txtTitleSaidaAnalogica = new System.Windows.Forms.Label();
            this.PanelSaidaStatus = new System.Windows.Forms.Panel();
            this.textBoxSaidaAnalogica = new System.Windows.Forms.TextBox();
            this.PanelTitleGroupSinais = new System.Windows.Forms.Panel();
            this.txtTitleGrupoSinais = new System.Windows.Forms.Label();
            this.DividerPanel = new System.Windows.Forms.Panel();
            this.TitleGroupPanel = new System.Windows.Forms.Panel();
            this.txtTitleGroup = new System.Windows.Forms.Label();
            this.PanelMachineGroup.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            this.PanelVariavelRead.SuspendLayout();
            this.GaugePanel.SuspendLayout();
            this.PanelEntradaDigital.SuspendLayout();
            this.PanelVariavelString.SuspendLayout();
            this.PanelSaidaAnalogica.SuspendLayout();
            this.PanelTitleGroupSinais.SuspendLayout();
            this.TitleGroupPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelMachineGroup
            // 
            this.PanelMachineGroup.AutoSize = true;
            this.PanelMachineGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.PanelMachineGroup.Controls.Add(this.flowLayoutPanel);
            this.PanelMachineGroup.Controls.Add(this.PanelTitleGroupSinais);
            this.PanelMachineGroup.Controls.Add(this.DividerPanel);
            this.PanelMachineGroup.Controls.Add(this.TitleGroupPanel);
            this.PanelMachineGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMachineGroup.Location = new System.Drawing.Point(10, 40);
            this.PanelMachineGroup.Name = "PanelMachineGroup";
            this.PanelMachineGroup.Size = new System.Drawing.Size(647, 503);
            this.PanelMachineGroup.TabIndex = 2;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel.Controls.Add(this.PanelVariavelRead);
            this.flowLayoutPanel.Controls.Add(this.GaugePanel);
            this.flowLayoutPanel.Controls.Add(this.PanelEntradaDigital);
            this.flowLayoutPanel.Controls.Add(this.PanelVariavelString);
            this.flowLayoutPanel.Controls.Add(this.PanelSaidaAnalogica);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 65);
            this.flowLayoutPanel.MaximumSize = new System.Drawing.Size(5000, 5000);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Padding = new System.Windows.Forms.Padding(5, 5, 5, 20);
            this.flowLayoutPanel.Size = new System.Drawing.Size(647, 300);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // PanelVariavelRead
            // 
            this.PanelVariavelRead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(199)))), ((int)(((byte)(140)))));
            this.PanelVariavelRead.Controls.Add(this.txtVariavelName);
            this.PanelVariavelRead.Location = new System.Drawing.Point(8, 8);
            this.PanelVariavelRead.Name = "PanelVariavelRead";
            this.PanelVariavelRead.Size = new System.Drawing.Size(187, 27);
            this.PanelVariavelRead.TabIndex = 0;
            this.PanelVariavelRead.Tag = "";
            // 
            // txtVariavelName
            // 
            this.txtVariavelName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtVariavelName.AutoSize = true;
            this.txtVariavelName.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtVariavelName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtVariavelName.Location = new System.Drawing.Point(67, 6);
            this.txtVariavelName.Name = "txtVariavelName";
            this.txtVariavelName.Size = new System.Drawing.Size(42, 16);
            this.txtVariavelName.TabIndex = 0;
            this.txtVariavelName.Text = "Ciclo";
            // 
            // GaugePanel
            // 
            this.GaugePanel.AutoSize = true;
            this.GaugePanel.Controls.Add(this.GaugeTitle);
            this.GaugePanel.Controls.Add(this.oCircularProgressBar);
            this.GaugePanel.Location = new System.Drawing.Point(201, 8);
            this.GaugePanel.Name = "GaugePanel";
            this.GaugePanel.Size = new System.Drawing.Size(153, 153);
            this.GaugePanel.TabIndex = 11;
            // 
            // GaugeTitle
            // 
            this.GaugeTitle.AutoSize = true;
            this.GaugeTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GaugeTitle.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GaugeTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.GaugeTitle.Location = new System.Drawing.Point(0, 135);
            this.GaugeTitle.Name = "GaugeTitle";
            this.GaugeTitle.Size = new System.Drawing.Size(58, 18);
            this.GaugeTitle.TabIndex = 0;
            this.GaugeTitle.Text = "Title";
            // 
            // oCircularProgressBar
            // 
            this.oCircularProgressBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.oCircularProgressBar.AnimationSpeed = 500;
            this.oCircularProgressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.oCircularProgressBar.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.oCircularProgressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(199)))), ((int)(((byte)(140)))));
            this.oCircularProgressBar.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(29)))), ((int)(((byte)(30)))));
            this.oCircularProgressBar.InnerMargin = -1;
            this.oCircularProgressBar.InnerWidth = -1;
            this.oCircularProgressBar.Location = new System.Drawing.Point(0, 0);
            this.oCircularProgressBar.MarqueeAnimationSpeed = 2000;
            this.oCircularProgressBar.Name = "oCircularProgressBar";
            this.oCircularProgressBar.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(29)))), ((int)(((byte)(30)))));
            this.oCircularProgressBar.OuterMargin = -15;
            this.oCircularProgressBar.OuterWidth = 8;
            this.oCircularProgressBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(199)))), ((int)(((byte)(140)))));
            this.oCircularProgressBar.ProgressWidth = 5;
            this.oCircularProgressBar.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 4.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.oCircularProgressBar.Size = new System.Drawing.Size(150, 150);
            this.oCircularProgressBar.StartAngle = 270;
            this.oCircularProgressBar.SubscriptColor = System.Drawing.Color.Gray;
            this.oCircularProgressBar.SubscriptMargin = new System.Windows.Forms.Padding(0);
            this.oCircularProgressBar.SubscriptText = "";
            this.oCircularProgressBar.SuperscriptColor = System.Drawing.Color.Gray;
            this.oCircularProgressBar.SuperscriptMargin = new System.Windows.Forms.Padding(0);
            this.oCircularProgressBar.SuperscriptText = "";
            this.oCircularProgressBar.TabIndex = 10;
            this.oCircularProgressBar.Text = "90";
            this.oCircularProgressBar.TextMargin = new System.Windows.Forms.Padding(3, 5, 0, 0);
            this.oCircularProgressBar.Value = 90;
            // 
            // PanelEntradaDigital
            // 
            this.PanelEntradaDigital.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PanelEntradaDigital.BackgroundImage")));
            this.PanelEntradaDigital.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PanelEntradaDigital.Controls.Add(this.txtTitleEntraDigital);
            this.PanelEntradaDigital.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PanelEntradaDigital.Location = new System.Drawing.Point(360, 8);
            this.PanelEntradaDigital.Name = "PanelEntradaDigital";
            this.PanelEntradaDigital.Size = new System.Drawing.Size(100, 50);
            this.PanelEntradaDigital.TabIndex = 12;
            // 
            // txtTitleEntraDigital
            // 
            this.txtTitleEntraDigital.AutoSize = true;
            this.txtTitleEntraDigital.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtTitleEntraDigital.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtTitleEntraDigital.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTitleEntraDigital.Location = new System.Drawing.Point(0, 34);
            this.txtTitleEntraDigital.Name = "txtTitleEntraDigital";
            this.txtTitleEntraDigital.Size = new System.Drawing.Size(42, 16);
            this.txtTitleEntraDigital.TabIndex = 1;
            this.txtTitleEntraDigital.Text = "Title";
            // 
            // PanelVariavelString
            // 
            this.PanelVariavelString.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(199)))), ((int)(((byte)(140)))));
            this.PanelVariavelString.Controls.Add(this.txtValueVariavelString);
            this.PanelVariavelString.Controls.Add(this.txtTitleVariavelString);
            this.PanelVariavelString.Location = new System.Drawing.Point(8, 167);
            this.PanelVariavelString.Name = "PanelVariavelString";
            this.PanelVariavelString.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.PanelVariavelString.Size = new System.Drawing.Size(187, 80);
            this.PanelVariavelString.TabIndex = 13;
            // 
            // txtValueVariavelString
            // 
            this.txtValueVariavelString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtValueVariavelString.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtValueVariavelString.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtValueVariavelString.Location = new System.Drawing.Point(5, 24);
            this.txtValueVariavelString.Name = "txtValueVariavelString";
            this.txtValueVariavelString.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.txtValueVariavelString.Size = new System.Drawing.Size(182, 56);
            this.txtValueVariavelString.TabIndex = 1;
            this.txtValueVariavelString.Text = "Algum texto que descreva alguma coisa dentro de algum contexto, o qual eu desconh" +
    "eço";
            // 
            // txtTitleVariavelString
            // 
            this.txtTitleVariavelString.AutoSize = true;
            this.txtTitleVariavelString.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTitleVariavelString.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtTitleVariavelString.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtTitleVariavelString.Location = new System.Drawing.Point(5, 5);
            this.txtTitleVariavelString.Name = "txtTitleVariavelString";
            this.txtTitleVariavelString.Size = new System.Drawing.Size(48, 19);
            this.txtTitleVariavelString.TabIndex = 1;
            this.txtTitleVariavelString.Text = "Ciclo";
            // 
            // PanelSaidaAnalogica
            // 
            this.PanelSaidaAnalogica.Controls.Add(this.txtSaidaAnalogicaEnviar);
            this.PanelSaidaAnalogica.Controls.Add(this.txtTitleSaidaAnalogica);
            this.PanelSaidaAnalogica.Controls.Add(this.PanelSaidaStatus);
            this.PanelSaidaAnalogica.Controls.Add(this.textBoxSaidaAnalogica);
            this.PanelSaidaAnalogica.Location = new System.Drawing.Point(201, 167);
            this.PanelSaidaAnalogica.Name = "PanelSaidaAnalogica";
            this.PanelSaidaAnalogica.Size = new System.Drawing.Size(276, 49);
            this.PanelSaidaAnalogica.TabIndex = 14;
            // 
            // txtSaidaAnalogicaEnviar
            // 
            this.txtSaidaAnalogicaEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(92)))), ((int)(((byte)(87)))));
            this.txtSaidaAnalogicaEnviar.FlatAppearance.BorderSize = 0;
            this.txtSaidaAnalogicaEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtSaidaAnalogicaEnviar.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtSaidaAnalogicaEnviar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSaidaAnalogicaEnviar.Location = new System.Drawing.Point(199, 0);
            this.txtSaidaAnalogicaEnviar.Name = "txtSaidaAnalogicaEnviar";
            this.txtSaidaAnalogicaEnviar.Size = new System.Drawing.Size(75, 23);
            this.txtSaidaAnalogicaEnviar.TabIndex = 0;
            this.txtSaidaAnalogicaEnviar.Text = "Enviar";
            this.txtSaidaAnalogicaEnviar.UseVisualStyleBackColor = false;
            // 
            // txtTitleSaidaAnalogica
            // 
            this.txtTitleSaidaAnalogica.AutoSize = true;
            this.txtTitleSaidaAnalogica.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtTitleSaidaAnalogica.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTitleSaidaAnalogica.Location = new System.Drawing.Point(0, 26);
            this.txtTitleSaidaAnalogica.Name = "txtTitleSaidaAnalogica";
            this.txtTitleSaidaAnalogica.Size = new System.Drawing.Size(42, 16);
            this.txtTitleSaidaAnalogica.TabIndex = 2;
            this.txtTitleSaidaAnalogica.Text = "Ciclo";
            // 
            // PanelSaidaStatus
            // 
            this.PanelSaidaStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(92)))), ((int)(((byte)(93)))));
            this.PanelSaidaStatus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PanelSaidaStatus.BackgroundImage")));
            this.PanelSaidaStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PanelSaidaStatus.Location = new System.Drawing.Point(0, 0);
            this.PanelSaidaStatus.Name = "PanelSaidaStatus";
            this.PanelSaidaStatus.Size = new System.Drawing.Size(23, 23);
            this.PanelSaidaStatus.TabIndex = 1;
            // 
            // textBoxSaidaAnalogica
            // 
            this.textBoxSaidaAnalogica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(29)))), ((int)(((byte)(30)))));
            this.textBoxSaidaAnalogica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSaidaAnalogica.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxSaidaAnalogica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(199)))), ((int)(((byte)(140)))));
            this.textBoxSaidaAnalogica.Location = new System.Drawing.Point(23, 0);
            this.textBoxSaidaAnalogica.Name = "textBoxSaidaAnalogica";
            this.textBoxSaidaAnalogica.PlaceholderText = "Digite...";
            this.textBoxSaidaAnalogica.Size = new System.Drawing.Size(170, 24);
            this.textBoxSaidaAnalogica.TabIndex = 0;
            // 
            // PanelTitleGroupSinais
            // 
            this.PanelTitleGroupSinais.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(92)))), ((int)(((byte)(87)))));
            this.PanelTitleGroupSinais.Controls.Add(this.txtTitleGrupoSinais);
            this.PanelTitleGroupSinais.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitleGroupSinais.Location = new System.Drawing.Point(0, 40);
            this.PanelTitleGroupSinais.Name = "PanelTitleGroupSinais";
            this.PanelTitleGroupSinais.Size = new System.Drawing.Size(647, 25);
            this.PanelTitleGroupSinais.TabIndex = 2;
            // 
            // txtTitleGrupoSinais
            // 
            this.txtTitleGrupoSinais.AutoSize = true;
            this.txtTitleGrupoSinais.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtTitleGrupoSinais.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(199)))), ((int)(((byte)(140)))));
            this.txtTitleGrupoSinais.Location = new System.Drawing.Point(34, 5);
            this.txtTitleGrupoSinais.Name = "txtTitleGrupoSinais";
            this.txtTitleGrupoSinais.Size = new System.Drawing.Size(152, 17);
            this.txtTitleGrupoSinais.TabIndex = 1;
            this.txtTitleGrupoSinais.Text = "TitleGrupoSinais";
            // 
            // DividerPanel
            // 
            this.DividerPanel.AutoSize = true;
            this.DividerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(29)))), ((int)(((byte)(30)))));
            this.DividerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DividerPanel.Location = new System.Drawing.Point(0, 503);
            this.DividerPanel.Name = "DividerPanel";
            this.DividerPanel.Size = new System.Drawing.Size(647, 0);
            this.DividerPanel.TabIndex = 1;
            // 
            // TitleGroupPanel
            // 
            this.TitleGroupPanel.Controls.Add(this.txtTitleGroup);
            this.TitleGroupPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleGroupPanel.Location = new System.Drawing.Point(0, 0);
            this.TitleGroupPanel.Name = "TitleGroupPanel";
            this.TitleGroupPanel.Size = new System.Drawing.Size(647, 40);
            this.TitleGroupPanel.TabIndex = 0;
            // 
            // txtTitleGroup
            // 
            this.txtTitleGroup.AutoSize = true;
            this.txtTitleGroup.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtTitleGroup.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTitleGroup.Location = new System.Drawing.Point(20, 20);
            this.txtTitleGroup.Name = "txtTitleGroup";
            this.txtTitleGroup.Size = new System.Drawing.Size(95, 16);
            this.txtTitleGroup.TabIndex = 1;
            this.txtTitleGroup.Text = "TornoBatata";
            // 
            // UcMachineInfos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(29)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.PanelMachineGroup);
            this.Name = "UcMachineInfos";
            this.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.Size = new System.Drawing.Size(667, 553);
            this.PanelMachineGroup.ResumeLayout(false);
            this.PanelMachineGroup.PerformLayout();
            this.flowLayoutPanel.ResumeLayout(false);
            this.flowLayoutPanel.PerformLayout();
            this.PanelVariavelRead.ResumeLayout(false);
            this.PanelVariavelRead.PerformLayout();
            this.GaugePanel.ResumeLayout(false);
            this.GaugePanel.PerformLayout();
            this.PanelEntradaDigital.ResumeLayout(false);
            this.PanelEntradaDigital.PerformLayout();
            this.PanelVariavelString.ResumeLayout(false);
            this.PanelVariavelString.PerformLayout();
            this.PanelSaidaAnalogica.ResumeLayout(false);
            this.PanelSaidaAnalogica.PerformLayout();
            this.PanelTitleGroupSinais.ResumeLayout(false);
            this.PanelTitleGroupSinais.PerformLayout();
            this.TitleGroupPanel.ResumeLayout(false);
            this.TitleGroupPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        
        #endregion

        private System.Windows.Forms.Panel PanelMachineGroup;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Panel PanelVariavelRead;
        private System.Windows.Forms.Label txtVariavelName;
        private CircularProgressBar.CircularProgressBar oCircularProgressBar;
        private System.Windows.Forms.Panel TitleGroupPanel;
        private System.Windows.Forms.Label txtTitleGroup;
        private System.Windows.Forms.Panel DividerPanel;
        private System.Windows.Forms.Panel GaugePanel;
        private System.Windows.Forms.Label GaugeTitle;
        private Panel PanelTitleGroupSinais;
        private Label txtTitleGrupoSinais;
        private Panel PanelEntradaDigital;
        private Label txtTitleEntraDigital;
        private Panel PanelVariavelString;
        private Label txtValueVariavelString;
        private Label txtTitleVariavelString;
        private Panel PanelSaidaAnalogica;
        private Label txtTitleEntradaAnalogica;
        private Panel PanelEntradaAnalogicaStatus;
        private TextBox textBoxEntradaAnalogica;
        private Button txtSaidaAnalogicaEnviar;
        private Label txtTitleSaidaAnalogica;
        private Panel PanelSaidaStatus;
        private TextBox textBoxSaidaAnalogica;
    }
}
