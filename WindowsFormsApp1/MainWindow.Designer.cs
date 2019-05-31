namespace WindowsFormsApp1
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
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.canvas1 = new WindowsFormsApp1.Components.Canvas();
            this.labelJumps = new System.Windows.Forms.Label();
            this.labelDist = new System.Windows.Forms.Label();
            this.labelRMC = new System.Windows.Forms.Label();
            this.labelLMC = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelKeys = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelOUTVh = new System.Windows.Forms.Label();
            this.labelOUTVl = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panelCPUI = new System.Windows.Forms.Panel();
            this.labelCPUVl = new System.Windows.Forms.Label();
            this.labelCPUVh = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.labelCPU = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelINVh = new System.Windows.Forms.Label();
            this.labelINVl = new System.Windows.Forms.Label();
            this.labelMem = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelRAMVh = new System.Windows.Forms.Label();
            this.labelRAMVl = new System.Windows.Forms.Label();
            this.panelMIDI = new System.Windows.Forms.Panel();
            this.labelMIDVh = new System.Windows.Forms.Label();
            this.labelMIDVl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.canvas1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panelCPUI.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelMIDI.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.panelHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHeader.Controls.Add(this.button7);
            this.panelHeader.Controls.Add(this.button6);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(769, 23);
            this.panelHeader.TabIndex = 6;
            this.panelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseDown);
            this.panelHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseMove);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.BackColor = System.Drawing.Color.SteelBlue;
            this.button7.FlatAppearance.BorderSize = 2;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(735, 3);
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
            this.button6.Location = new System.Drawing.Point(750, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(14, 15);
            this.button6.TabIndex = 0;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // canvas1
            // 
            this.canvas1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.canvas1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.canvas1.Controls.Add(this.checkBox1);
            this.canvas1.Location = new System.Drawing.Point(0, 23);
            this.canvas1.Name = "canvas1";
            this.canvas1.Size = new System.Drawing.Size(769, 159);
            this.canvas1.TabIndex = 14;
            // 
            // labelJumps
            // 
            this.labelJumps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelJumps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.labelJumps.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelJumps.ForeColor = System.Drawing.SystemColors.Window;
            this.labelJumps.Location = new System.Drawing.Point(542, 402);
            this.labelJumps.Name = "labelJumps";
            this.labelJumps.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.labelJumps.Size = new System.Drawing.Size(127, 43);
            this.labelJumps.TabIndex = 15;
            this.labelJumps.Text = "Jumps";
            this.labelJumps.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDist
            // 
            this.labelDist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.labelDist.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDist.ForeColor = System.Drawing.SystemColors.Window;
            this.labelDist.Location = new System.Drawing.Point(404, 402);
            this.labelDist.Name = "labelDist";
            this.labelDist.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.labelDist.Size = new System.Drawing.Size(132, 43);
            this.labelDist.TabIndex = 14;
            this.labelDist.Text = "Distance";
            this.labelDist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelRMC
            // 
            this.labelRMC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRMC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.labelRMC.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRMC.ForeColor = System.Drawing.SystemColors.Window;
            this.labelRMC.Location = new System.Drawing.Point(542, 348);
            this.labelRMC.Name = "labelRMC";
            this.labelRMC.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.labelRMC.Size = new System.Drawing.Size(127, 51);
            this.labelRMC.TabIndex = 13;
            this.labelRMC.Text = "Mouse";
            this.labelRMC.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // labelLMC
            // 
            this.labelLMC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLMC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.labelLMC.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLMC.ForeColor = System.Drawing.SystemColors.Window;
            this.labelLMC.Location = new System.Drawing.Point(403, 348);
            this.labelLMC.Name = "labelLMC";
            this.labelLMC.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.labelLMC.Size = new System.Drawing.Size(133, 51);
            this.labelLMC.TabIndex = 12;
            this.labelLMC.Text = "Mouse";
            this.labelLMC.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Location = new System.Drawing.Point(192, 463);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Net";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Location = new System.Drawing.Point(754, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(12, 11);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.Location = new System.Drawing.Point(215, 454);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.label7.Size = new System.Drawing.Size(30, 23);
            this.label7.TabIndex = 11;
            this.label7.Text = "OUT";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelKeys
            // 
            this.labelKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelKeys.BackColor = System.Drawing.SystemColors.WindowText;
            this.labelKeys.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelKeys.ForeColor = System.Drawing.SystemColors.Window;
            this.labelKeys.Location = new System.Drawing.Point(403, 307);
            this.labelKeys.Name = "labelKeys";
            this.labelKeys.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.labelKeys.Size = new System.Drawing.Size(266, 139);
            this.labelKeys.TabIndex = 3;
            this.labelKeys.Text = "Keys";
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(134)))), ((int)(((byte)(84)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(675, 412);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(90, 29);
            this.button5.TabIndex = 4;
            this.button5.Text = "Ultracopy";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel4.Controls.Add(this.labelOUTVh);
            this.panel4.Controls.Add(this.labelOUTVl);
            this.panel4.Location = new System.Drawing.Point(209, 307);
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
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button4.BackColor = System.Drawing.Color.BurlyWood;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button4.Location = new System.Drawing.Point(675, 447);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 29);
            this.button4.TabIndex = 3;
            this.button4.Text = "MySQLMGR";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button3.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.Location = new System.Drawing.Point(675, 377);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 29);
            this.button3.TabIndex = 2;
            this.button3.Text = "TwitchMGR";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panelCPUI
            // 
            this.panelCPUI.BackColor = System.Drawing.SystemColors.ControlText;
            this.panelCPUI.Controls.Add(this.labelCPUVl);
            this.panelCPUI.Controls.Add(this.labelCPUVh);
            this.panelCPUI.Location = new System.Drawing.Point(8, 307);
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
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(675, 342);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 29);
            this.button2.TabIndex = 1;
            this.button2.Text = "SysMeas";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Location = new System.Drawing.Point(172, 454);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.label6.Size = new System.Drawing.Size(30, 23);
            this.label6.TabIndex = 9;
            this.label6.Text = "IN";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(675, 307);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "CommNET";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelCPU
            // 
            this.labelCPU.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCPU.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelCPU.Location = new System.Drawing.Point(12, 454);
            this.labelCPU.Name = "labelCPU";
            this.labelCPU.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.labelCPU.Size = new System.Drawing.Size(36, 23);
            this.labelCPU.TabIndex = 1;
            this.labelCPU.Text = "CPU%";
            this.labelCPU.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel3.Controls.Add(this.labelINVh);
            this.panel3.Controls.Add(this.labelINVl);
            this.panel3.Location = new System.Drawing.Point(169, 307);
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
            // labelMem
            // 
            this.labelMem.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMem.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelMem.Location = new System.Drawing.Point(94, 454);
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
            this.panel2.Location = new System.Drawing.Point(88, 307);
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
            // panelMIDI
            // 
            this.panelMIDI.BackColor = System.Drawing.SystemColors.ControlText;
            this.panelMIDI.Controls.Add(this.labelMIDVh);
            this.panelMIDI.Controls.Add(this.labelMIDVl);
            this.panelMIDI.Location = new System.Drawing.Point(48, 307);
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
            this.label2.Location = new System.Drawing.Point(51, 454);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.label2.Size = new System.Drawing.Size(38, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "MID%";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(769, 485);
            this.Controls.Add(this.labelJumps);
            this.Controls.Add(this.canvas1);
            this.Controls.Add(this.labelDist);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.labelRMC);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.labelLMC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panelMIDI);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelMem);
            this.Controls.Add(this.labelKeys);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.labelCPU);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panelCPUI);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unia 0.12";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.panelHeader.ResumeLayout(false);
            this.canvas1.ResumeLayout(false);
            this.canvas1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panelCPUI.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelMIDI.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label labelKeys;
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
        private System.Windows.Forms.CheckBox checkBox1;
        private Components.Canvas canvas1;
        private System.Windows.Forms.Label labelLMC;
        private System.Windows.Forms.Label labelRMC;
        private System.Windows.Forms.Label labelDist;
        private System.Windows.Forms.Label labelJumps;
    }
}