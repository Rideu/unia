﻿namespace UniaCore
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            //<button onclick="document.getElementById('sendbtn').click();"> Lel </button>
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelName = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panelSpectrumSets = new System.Windows.Forms.Panel();
            this.grayButtonSettings = new GrayLib.GrayButton();
            this.vertScrollWavefactor = new GrayLib.GrayScroll();
            this.checkBoxColoriseCanvas = new System.Windows.Forms.CheckBox();
            this.buttonSH = new System.Windows.Forms.Button();
            this.buttonSM = new System.Windows.Forms.Button();
            this.buttonBC = new System.Windows.Forms.Button();
            this.buttonSL = new System.Windows.Forms.Button();
            this.checkBoxTopMostSwitch = new System.Windows.Forms.CheckBox();
            this.checkBoxFadeSwitch = new System.Windows.Forms.CheckBox();
            this.retractPanelSettings = new GrayLib.RetractPanel();
            this.retractPanel4 = new GrayLib.RetractPanel();
            this.buttonTreegex = new System.Windows.Forms.Button();
            this.buttonSIE = new System.Windows.Forms.Button();
            this.buttonVidConv = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.buttonCommNET = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.retractPanel2 = new GrayLib.RetractPanel();
            this.panelCPUI = new System.Windows.Forms.Panel();
            this.labelCPUVl = new System.Windows.Forms.Label();
            this.labelCPUVh = new System.Windows.Forms.Label();
            this.labelMem = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelRAMVh = new System.Windows.Forms.Label();
            this.labelRAMVl = new System.Windows.Forms.Label();
            this.labelCPU = new System.Windows.Forms.Label();
            this.panelMIDI = new System.Windows.Forms.Panel();
            this.labelMIDVh = new System.Windows.Forms.Label();
            this.labelMIDVl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.canvas1 = new GrayLib.Canvas();
            this.retractPanel1 = new GrayLib.RetractPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelOUTVh = new System.Windows.Forms.Label();
            this.labelOUTVl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelINVh = new System.Windows.Forms.Label();
            this.labelINVl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.spectrumViewer1 = new UniaCore.SpectrumViewer();
            this.panelHeader.SuspendLayout();
            this.panelSpectrumSets.SuspendLayout();
            this.retractPanel4.SuspendLayout();
            this.retractPanel2.SuspendLayout();
            this.panelCPUI.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelMIDI.SuspendLayout();
            this.retractPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.panelHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHeader.Controls.Add(this.labelName);
            this.panelHeader.Controls.Add(this.button7);
            this.panelHeader.Controls.Add(this.button6);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(900, 23);
            this.panelHeader.TabIndex = 0;
            this.panelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseDown);
            this.panelHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseMove);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(5, 3);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(29, 13);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Unia";
            this.labelName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseDown);
            this.labelName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseMove);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.BackColor = System.Drawing.Color.SteelBlue;
            this.button7.FlatAppearance.BorderSize = 2;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(866, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(14, 15);
            this.button7.TabIndex = 1;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.BackColor = System.Drawing.Color.Brown;
            this.button6.FlatAppearance.BorderSize = 2;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(881, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(14, 15);
            this.button6.TabIndex = 0;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // panelSpectrumSets
            // 
            this.panelSpectrumSets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panelSpectrumSets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSpectrumSets.Controls.Add(this.grayButtonSettings);
            this.panelSpectrumSets.Controls.Add(this.vertScrollWavefactor);
            this.panelSpectrumSets.Controls.Add(this.checkBoxColoriseCanvas);
            this.panelSpectrumSets.Controls.Add(this.buttonSH);
            this.panelSpectrumSets.Controls.Add(this.buttonSM);
            this.panelSpectrumSets.Controls.Add(this.buttonBC);
            this.panelSpectrumSets.Controls.Add(this.buttonSL);
            this.panelSpectrumSets.Location = new System.Drawing.Point(0, 23);
            this.panelSpectrumSets.Name = "panelSpectrumSets";
            this.panelSpectrumSets.Size = new System.Drawing.Size(177, 54);
            this.panelSpectrumSets.TabIndex = 24;
            this.panelSpectrumSets.Click += new System.EventHandler(this.panelSpectrumSets_Click);
            // 
            // grayButtonSettings
            // 
            this.grayButtonSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.grayButtonSettings.BackgroundImage = global::UniaCore.Properties.Resources.sets;
            this.grayButtonSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.grayButtonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grayButtonSettings.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.grayButtonSettings.Location = new System.Drawing.Point(136, 3);
            this.grayButtonSettings.Name = "grayButtonSettings";
            this.grayButtonSettings.Size = new System.Drawing.Size(22, 22);
            this.grayButtonSettings.TabIndex = 9;
            this.grayButtonSettings.UseVisualStyleBackColor = true;
            this.grayButtonSettings.Click += new System.EventHandler(this.grayButtonSettings_Click);
            // 
            // vertScrollWavefactor
            // 
            this.vertScrollWavefactor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.vertScrollWavefactor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vertScrollWavefactor.Location = new System.Drawing.Point(3, 27);
            this.vertScrollWavefactor.MaximumSize = new System.Drawing.Size(9999, 14);
            this.vertScrollWavefactor.MinimumSize = new System.Drawing.Size(100, 14);
            this.vertScrollWavefactor.Name = "vertScrollWavefactor";
            this.vertScrollWavefactor.Orient = GrayLib.GrayScroll.Orientype.Horizontal;
            this.vertScrollWavefactor.Size = new System.Drawing.Size(169, 14);
            this.vertScrollWavefactor.TabIndex = 5;
            this.vertScrollWavefactor.Value = -0.01481481F;
            // 
            // checkBoxColoriseCanvas
            // 
            this.checkBoxColoriseCanvas.AutoSize = true;
            this.checkBoxColoriseCanvas.Checked = true;
            this.checkBoxColoriseCanvas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxColoriseCanvas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxColoriseCanvas.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.checkBoxColoriseCanvas.Location = new System.Drawing.Point(160, 3);
            this.checkBoxColoriseCanvas.Name = "checkBoxColoriseCanvas";
            this.checkBoxColoriseCanvas.Size = new System.Drawing.Size(12, 11);
            this.checkBoxColoriseCanvas.TabIndex = 4;
            this.checkBoxColoriseCanvas.UseVisualStyleBackColor = true;
            this.checkBoxColoriseCanvas.CheckedChanged += new System.EventHandler(this.checkBoxColoriseCanvas_CheckedChanged);
            // 
            // buttonSH
            // 
            this.buttonSH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSH.Location = new System.Drawing.Point(71, 3);
            this.buttonSH.Name = "buttonSH";
            this.buttonSH.Size = new System.Drawing.Size(33, 22);
            this.buttonSH.TabIndex = 3;
            this.buttonSH.Text = "SH";
            this.buttonSH.UseVisualStyleBackColor = true;
            this.buttonSH.Click += new System.EventHandler(this.buttonSL_Click);
            // 
            // buttonSM
            // 
            this.buttonSM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSM.Location = new System.Drawing.Point(37, 3);
            this.buttonSM.Name = "buttonSM";
            this.buttonSM.Size = new System.Drawing.Size(33, 22);
            this.buttonSM.TabIndex = 2;
            this.buttonSM.Text = "SM";
            this.buttonSM.UseVisualStyleBackColor = true;
            this.buttonSM.Click += new System.EventHandler(this.buttonSL_Click);
            // 
            // buttonBC
            // 
            this.buttonBC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBC.Location = new System.Drawing.Point(105, 3);
            this.buttonBC.Name = "buttonBC";
            this.buttonBC.Size = new System.Drawing.Size(30, 22);
            this.buttonBC.TabIndex = 1;
            this.buttonBC.Text = "B";
            this.buttonBC.UseVisualStyleBackColor = true;
            this.buttonBC.Click += new System.EventHandler(this.buttonSL_Click);
            // 
            // buttonSL
            // 
            this.buttonSL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSL.Location = new System.Drawing.Point(3, 3);
            this.buttonSL.Name = "buttonSL";
            this.buttonSL.Size = new System.Drawing.Size(33, 22);
            this.buttonSL.TabIndex = 0;
            this.buttonSL.Text = "SL";
            this.buttonSL.UseVisualStyleBackColor = true;
            this.buttonSL.Click += new System.EventHandler(this.buttonSL_Click);
            // 
            // checkBoxTopMostSwitch
            // 
            this.checkBoxTopMostSwitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxTopMostSwitch.AutoSize = true;
            this.checkBoxTopMostSwitch.Checked = true;
            this.checkBoxTopMostSwitch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTopMostSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxTopMostSwitch.Location = new System.Drawing.Point(882, 30);
            this.checkBoxTopMostSwitch.Name = "checkBoxTopMostSwitch";
            this.checkBoxTopMostSwitch.Size = new System.Drawing.Size(12, 11);
            this.checkBoxTopMostSwitch.TabIndex = 2;
            this.checkBoxTopMostSwitch.UseVisualStyleBackColor = true;
            this.checkBoxTopMostSwitch.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBoxFadeSwitch
            // 
            this.checkBoxFadeSwitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxFadeSwitch.AutoSize = true;
            this.checkBoxFadeSwitch.Checked = true;
            this.checkBoxFadeSwitch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFadeSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxFadeSwitch.Location = new System.Drawing.Point(882, 47);
            this.checkBoxFadeSwitch.Name = "checkBoxFadeSwitch";
            this.checkBoxFadeSwitch.Size = new System.Drawing.Size(12, 11);
            this.checkBoxFadeSwitch.TabIndex = 26;
            this.checkBoxFadeSwitch.UseVisualStyleBackColor = true;
            this.checkBoxFadeSwitch.CheckedChanged += new System.EventHandler(this.checkBoxFadeSwitch_CheckedChanged);
            // 
            // retractPanelSettings
            // 
            this.retractPanelSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.retractPanelSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.retractPanelSettings.ButtonAtTop = false;
            this.retractPanelSettings.ButtonText = "Done";
            this.retractPanelSettings.DirectedAtTop = false;
            this.retractPanelSettings.Location = new System.Drawing.Point(179, -218);
            this.retractPanelSettings.Name = "retractPanelSettings";
            this.retractPanelSettings.Size = new System.Drawing.Size(361, 241);
            this.retractPanelSettings.TabIndex = 27;
            // 
            // retractPanel4
            // 
            this.retractPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.retractPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.retractPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.retractPanel4.ButtonAtTop = true;
            this.retractPanel4.ButtonText = "Utilities";
            this.retractPanel4.Controls.Add(this.buttonTreegex);
            this.retractPanel4.Controls.Add(this.buttonSIE);
            this.retractPanel4.Controls.Add(this.buttonVidConv);
            this.retractPanel4.Controls.Add(this.button8);
            this.retractPanel4.Controls.Add(this.buttonCommNET);
            this.retractPanel4.Controls.Add(this.button5);
            this.retractPanel4.Controls.Add(this.button4);
            this.retractPanel4.Controls.Add(this.button3);
            this.retractPanel4.Controls.Add(this.button2);
            this.retractPanel4.DirectedAtTop = true;
            this.retractPanel4.Location = new System.Drawing.Point(759, 423);
            this.retractPanel4.Name = "retractPanel4";
            this.retractPanel4.Size = new System.Drawing.Size(141, 207);
            this.retractPanel4.TabIndex = 23;
            // 
            // buttonTreegex
            // 
            this.buttonTreegex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(202)))), ((int)(((byte)(184)))));
            this.buttonTreegex.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonTreegex.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonTreegex.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonTreegex.Location = new System.Drawing.Point(95, 105);
            this.buttonTreegex.Name = "buttonTreegex";
            this.buttonTreegex.Size = new System.Drawing.Size(40, 30);
            this.buttonTreegex.TabIndex = 13;
            this.buttonTreegex.Text = "RGX";
            this.buttonTreegex.UseVisualStyleBackColor = false;
            this.buttonTreegex.Click += new System.EventHandler(this.buttonTreegex_Click);
            // 
            // buttonSIE
            // 
            this.buttonSIE.BackColor = System.Drawing.Color.BurlyWood;
            this.buttonSIE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSIE.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSIE.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonSIE.Location = new System.Drawing.Point(49, 141);
            this.buttonSIE.Name = "buttonSIE";
            this.buttonSIE.Size = new System.Drawing.Size(40, 30);
            this.buttonSIE.TabIndex = 12;
            this.buttonSIE.Text = "SIE";
            this.buttonSIE.UseVisualStyleBackColor = false;
            this.buttonSIE.Click += new System.EventHandler(this.buttonSIE_Click);
            // 
            // buttonVidConv
            // 
            this.buttonVidConv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(202)))), ((int)(((byte)(184)))));
            this.buttonVidConv.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonVidConv.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonVidConv.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonVidConv.Location = new System.Drawing.Point(49, 105);
            this.buttonVidConv.Name = "buttonVidConv";
            this.buttonVidConv.Size = new System.Drawing.Size(40, 30);
            this.buttonVidConv.TabIndex = 11;
            this.buttonVidConv.Text = "VCT";
            this.buttonVidConv.UseVisualStyleBackColor = false;
            this.buttonVidConv.Click += new System.EventHandler(this.buttonVidConv_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(0, 0);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 14;
            // 
            // buttonCommNET
            // 
            this.buttonCommNET.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(142)))), ((int)(((byte)(244)))));
            this.buttonCommNET.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCommNET.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.buttonCommNET.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonCommNET.Location = new System.Drawing.Point(3, 33);
            this.buttonCommNET.Name = "buttonCommNET";
            this.buttonCommNET.Size = new System.Drawing.Size(40, 30);
            this.buttonCommNET.TabIndex = 0;
            this.buttonCommNET.Text = "NET";
            this.buttonCommNET.UseVisualStyleBackColor = false;
            this.buttonCommNET.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(182)))), ((int)(((byte)(204)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(3, 69);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(40, 30);
            this.button5.TabIndex = 4;
            this.button5.Text = "RCP";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(182)))), ((int)(((byte)(204)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button4.Location = new System.Drawing.Point(49, 69);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(40, 30);
            this.button4.TabIndex = 3;
            this.button4.Text = "CNV";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(202)))), ((int)(((byte)(184)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.Location = new System.Drawing.Point(3, 105);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 30);
            this.button3.TabIndex = 2;
            this.button3.Text = "WK";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(142)))), ((int)(((byte)(244)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(49, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 30);
            this.button2.TabIndex = 1;
            this.button2.Text = "MR";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // retractPanel2
            // 
            this.retractPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.retractPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.retractPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.retractPanel2.ButtonAtTop = true;
            this.retractPanel2.ButtonText = "Hardware";
            this.retractPanel2.Controls.Add(this.panelCPUI);
            this.retractPanel2.Controls.Add(this.labelMem);
            this.retractPanel2.Controls.Add(this.panel2);
            this.retractPanel2.Controls.Add(this.labelCPU);
            this.retractPanel2.Controls.Add(this.panelMIDI);
            this.retractPanel2.Controls.Add(this.label2);
            this.retractPanel2.DirectedAtTop = true;
            this.retractPanel2.Location = new System.Drawing.Point(0, 424);
            this.retractPanel2.Name = "retractPanel2";
            this.retractPanel2.Size = new System.Drawing.Size(124, 207);
            this.retractPanel2.TabIndex = 21;
            // 
            // panelCPUI
            // 
            this.panelCPUI.BackColor = System.Drawing.SystemColors.ControlText;
            this.panelCPUI.Controls.Add(this.labelCPUVl);
            this.panelCPUI.Controls.Add(this.labelCPUVh);
            this.panelCPUI.Location = new System.Drawing.Point(3, 30);
            this.panelCPUI.Name = "panelCPUI";
            this.panelCPUI.Padding = new System.Windows.Forms.Padding(2);
            this.panelCPUI.Size = new System.Drawing.Size(36, 144);
            this.panelCPUI.TabIndex = 6;
            // 
            // labelCPUVl
            // 
            this.labelCPUVl.BackColor = System.Drawing.SystemColors.ControlText;
            this.labelCPUVl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelCPUVl.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.labelCPUVl.Location = new System.Drawing.Point(2, 57);
            this.labelCPUVl.Name = "labelCPUVl";
            this.labelCPUVl.Size = new System.Drawing.Size(32, 85);
            this.labelCPUVl.TabIndex = 1;
            this.labelCPUVl.Text = "2";
            this.labelCPUVl.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // labelCPUVh
            // 
            this.labelCPUVh.BackColor = System.Drawing.SystemColors.Highlight;
            this.labelCPUVh.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCPUVh.ForeColor = System.Drawing.SystemColors.Window;
            this.labelCPUVh.Location = new System.Drawing.Point(2, 2);
            this.labelCPUVh.Name = "labelCPUVh";
            this.labelCPUVh.Size = new System.Drawing.Size(32, 53);
            this.labelCPUVh.TabIndex = 0;
            this.labelCPUVh.Text = "1";
            this.labelCPUVh.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelMem
            // 
            this.labelMem.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMem.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelMem.Location = new System.Drawing.Point(89, 177);
            this.labelMem.Name = "labelMem";
            this.labelMem.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.labelMem.Size = new System.Drawing.Size(30, 23);
            this.labelMem.TabIndex = 2;
            this.labelMem.Text = "RAM";
            this.labelMem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel2.Controls.Add(this.labelRAMVh);
            this.panel2.Controls.Add(this.labelRAMVl);
            this.panel2.Location = new System.Drawing.Point(83, 30);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(2);
            this.panel2.Size = new System.Drawing.Size(36, 144);
            this.panel2.TabIndex = 6;
            // 
            // labelRAMVh
            // 
            this.labelRAMVh.BackColor = System.Drawing.SystemColors.Highlight;
            this.labelRAMVh.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelRAMVh.ForeColor = System.Drawing.SystemColors.Window;
            this.labelRAMVh.Location = new System.Drawing.Point(2, 2);
            this.labelRAMVh.Name = "labelRAMVh";
            this.labelRAMVh.Size = new System.Drawing.Size(32, 53);
            this.labelRAMVh.TabIndex = 3;
            this.labelRAMVh.Text = "1";
            this.labelRAMVh.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelRAMVl
            // 
            this.labelRAMVl.BackColor = System.Drawing.SystemColors.ControlText;
            this.labelRAMVl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelRAMVl.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.labelRAMVl.Location = new System.Drawing.Point(2, 57);
            this.labelRAMVl.Name = "labelRAMVl";
            this.labelRAMVl.Size = new System.Drawing.Size(32, 85);
            this.labelRAMVl.TabIndex = 4;
            this.labelRAMVl.Text = "2";
            this.labelRAMVl.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // labelCPU
            // 
            this.labelCPU.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCPU.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelCPU.Location = new System.Drawing.Point(7, 177);
            this.labelCPU.Name = "labelCPU";
            this.labelCPU.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.labelCPU.Size = new System.Drawing.Size(36, 23);
            this.labelCPU.TabIndex = 1;
            this.labelCPU.Text = "CPU%";
            this.labelCPU.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMIDI
            // 
            this.panelMIDI.BackColor = System.Drawing.SystemColors.ControlText;
            this.panelMIDI.Controls.Add(this.labelMIDVh);
            this.panelMIDI.Controls.Add(this.labelMIDVl);
            this.panelMIDI.Location = new System.Drawing.Point(43, 30);
            this.panelMIDI.Name = "panelMIDI";
            this.panelMIDI.Padding = new System.Windows.Forms.Padding(2);
            this.panelMIDI.Size = new System.Drawing.Size(36, 144);
            this.panelMIDI.TabIndex = 5;
            // 
            // labelMIDVh
            // 
            this.labelMIDVh.BackColor = System.Drawing.SystemColors.Highlight;
            this.labelMIDVh.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelMIDVh.ForeColor = System.Drawing.SystemColors.Window;
            this.labelMIDVh.Location = new System.Drawing.Point(2, 2);
            this.labelMIDVh.Name = "labelMIDVh";
            this.labelMIDVh.Size = new System.Drawing.Size(32, 53);
            this.labelMIDVh.TabIndex = 2;
            this.labelMIDVh.Text = "1";
            this.labelMIDVh.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelMIDVl
            // 
            this.labelMIDVl.BackColor = System.Drawing.SystemColors.ControlText;
            this.labelMIDVl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelMIDVl.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.labelMIDVl.Location = new System.Drawing.Point(2, 57);
            this.labelMIDVl.Name = "labelMIDVl";
            this.labelMIDVl.Size = new System.Drawing.Size(32, 85);
            this.labelMIDVl.TabIndex = 2;
            this.labelMIDVl.Text = "2";
            this.labelMIDVl.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(46, 177);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.label2.Size = new System.Drawing.Size(38, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "MID%";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // canvas1
            // 
            this.canvas1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.canvas1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.canvas1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas1.Location = new System.Drawing.Point(884, 67);
            this.canvas1.Name = "canvas1";
            this.canvas1.Size = new System.Drawing.Size(10, 10);
            this.canvas1.TabIndex = 14;
            this.canvas1.Visible = false;
            // 
            // retractPanel1
            // 
            this.retractPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.retractPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.retractPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.retractPanel1.ButtonAtTop = true;
            this.retractPanel1.ButtonText = "Network";
            this.retractPanel1.Controls.Add(this.panel4);
            this.retractPanel1.Controls.Add(this.label5);
            this.retractPanel1.Controls.Add(this.panel3);
            this.retractPanel1.Controls.Add(this.label7);
            this.retractPanel1.Controls.Add(this.label6);
            this.retractPanel1.DirectedAtTop = true;
            this.retractPanel1.Location = new System.Drawing.Point(125, 424);
            this.retractPanel1.Name = "retractPanel1";
            this.retractPanel1.Size = new System.Drawing.Size(84, 207);
            this.retractPanel1.TabIndex = 20;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel4.Controls.Add(this.labelOUTVh);
            this.panel4.Controls.Add(this.labelOUTVl);
            this.panel4.Location = new System.Drawing.Point(43, 30);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(2);
            this.panel4.Size = new System.Drawing.Size(36, 144);
            this.panel4.TabIndex = 10;
            // 
            // labelOUTVh
            // 
            this.labelOUTVh.BackColor = System.Drawing.SystemColors.Highlight;
            this.labelOUTVh.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelOUTVh.ForeColor = System.Drawing.SystemColors.Window;
            this.labelOUTVh.Location = new System.Drawing.Point(2, 2);
            this.labelOUTVh.Name = "labelOUTVh";
            this.labelOUTVh.Size = new System.Drawing.Size(32, 53);
            this.labelOUTVh.TabIndex = 3;
            this.labelOUTVh.Text = "1";
            this.labelOUTVh.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelOUTVl
            // 
            this.labelOUTVl.BackColor = System.Drawing.SystemColors.ControlText;
            this.labelOUTVl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelOUTVl.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.labelOUTVl.Location = new System.Drawing.Point(2, 57);
            this.labelOUTVl.Name = "labelOUTVl";
            this.labelOUTVl.Size = new System.Drawing.Size(32, 85);
            this.labelOUTVl.TabIndex = 4;
            this.labelOUTVl.Text = "2";
            this.labelOUTVl.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Location = new System.Drawing.Point(26, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Net";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel3.Controls.Add(this.labelINVh);
            this.panel3.Controls.Add(this.labelINVl);
            this.panel3.Location = new System.Drawing.Point(3, 30);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(2);
            this.panel3.Size = new System.Drawing.Size(36, 144);
            this.panel3.TabIndex = 7;
            // 
            // labelINVh
            // 
            this.labelINVh.BackColor = System.Drawing.SystemColors.Highlight;
            this.labelINVh.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelINVh.ForeColor = System.Drawing.SystemColors.Window;
            this.labelINVh.Location = new System.Drawing.Point(2, 2);
            this.labelINVh.Name = "labelINVh";
            this.labelINVh.Size = new System.Drawing.Size(32, 53);
            this.labelINVh.TabIndex = 3;
            this.labelINVh.Text = "1";
            this.labelINVh.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelINVl
            // 
            this.labelINVl.BackColor = System.Drawing.SystemColors.ControlText;
            this.labelINVl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelINVl.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.labelINVl.Location = new System.Drawing.Point(2, 57);
            this.labelINVl.Name = "labelINVl";
            this.labelINVl.Size = new System.Drawing.Size(32, 85);
            this.labelINVl.TabIndex = 4;
            this.labelINVl.Text = "2";
            this.labelINVl.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.Location = new System.Drawing.Point(49, 177);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.label7.Size = new System.Drawing.Size(30, 23);
            this.label7.TabIndex = 11;
            this.label7.Text = "OUT";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Location = new System.Drawing.Point(6, 177);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.label6.Size = new System.Drawing.Size(30, 23);
            this.label6.TabIndex = 9;
            this.label6.Text = "IN";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spectrumViewer1
            // 
            this.spectrumViewer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.spectrumViewer1.Location = new System.Drawing.Point(0, 20);
            this.spectrumViewer1.Name = "spectrumViewer1";
            this.spectrumViewer1.Size = new System.Drawing.Size(900, 433);
            this.spectrumViewer1.TabIndex = 2;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.retractPanelSettings);
            this.Controls.Add(this.checkBoxFadeSwitch);
            this.Controls.Add(this.retractPanel4);
            this.Controls.Add(this.retractPanel2);
            this.Controls.Add(this.panelSpectrumSets);
            this.Controls.Add(this.canvas1);
            this.Controls.Add(this.retractPanel1);
            this.Controls.Add(this.checkBoxTopMostSwitch);
            this.Controls.Add(this.spectrumViewer1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Unia 0.2";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelSpectrumSets.ResumeLayout(false);
            this.panelSpectrumSets.PerformLayout();
            this.retractPanel4.ResumeLayout(false);
            this.retractPanel2.ResumeLayout(false);
            this.panelCPUI.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelMIDI.ResumeLayout(false);
            this.retractPanel1.ResumeLayout(false);
            this.retractPanel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCommNET;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label labelMem;
        private System.Windows.Forms.Label labelCPU;
        private System.Windows.Forms.Panel panelCPUI;
        private System.Windows.Forms.Panel panelMIDI;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelCPUVl;
        private System.Windows.Forms.Label labelCPUVh;
        private System.Windows.Forms.Label labelMIDVl;
        private System.Windows.Forms.Label labelMIDVh;
        private System.Windows.Forms.Label labelRAMVh;
        private System.Windows.Forms.Label labelRAMVl;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelINVh;
        private System.Windows.Forms.Label labelINVl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelOUTVh;
        private System.Windows.Forms.Label labelOUTVl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBoxTopMostSwitch;
        private GrayLib.Canvas canvas1;
        private GrayLib.RetractPanel retractPanel1;
        private GrayLib.RetractPanel retractPanel2;
        private GrayLib.RetractPanel retractPanel4;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Panel panelSpectrumSets;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button buttonSH;
        private System.Windows.Forms.Button buttonSM;
        private System.Windows.Forms.Button buttonBC;
        private System.Windows.Forms.Button buttonSL;
        private System.Windows.Forms.CheckBox checkBoxColoriseCanvas;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button buttonVidConv;
        private System.Windows.Forms.Button buttonSIE;
        public GrayLib.GrayScroll vertScrollWavefactor;
        private System.Windows.Forms.Button buttonTreegex;
        private GrayLib.GrayButton grayButtonSettings;
        public SpectrumViewer spectrumViewer1;
        private System.Windows.Forms.CheckBox checkBoxFadeSwitch;
        private GrayLib.RetractPanel retractPanelSettings;
    }
}