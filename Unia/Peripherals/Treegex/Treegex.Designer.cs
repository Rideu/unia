namespace UniaCore
{
    partial class Treegex
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
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Treegex));
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.Context = new UniaCore.Components.GrayRichTexBox();
            this.ErrorList = new UniaCore.Components.GrayRichTexBox();
            this.Input = new UniaCore.Components.GrayRichTexBox();
            this.RegexIn = new UniaCore.Components.GrayRichTexBox();
            this.winHeader1 = new UniaCore.WinHeader();
            this.SaveRegex = new UniaCore.Components.GrayButton();
            this.OpenRegex = new UniaCore.Components.GrayButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Location = new System.Drawing.Point(618, 362);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(170, 26);
            this.panel1.TabIndex = 5;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Maroon;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(124)))), ((int)(((byte)(164)))));
            this.linkLabel1.Location = new System.Drawing.Point(3, 5);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(29, 13);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Help";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Context
            // 
            this.Context.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Context.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Context.Header = "Context";
            this.Context.Location = new System.Drawing.Point(617, 62);
            this.Context.Name = "Context";
            this.Context.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.Context.PlaceHolder = null;
            this.Context.ReadOnly = true;
            this.Context.Size = new System.Drawing.Size(171, 293);
            this.Context.TabIndex = 4;
            // 
            // ErrorList
            // 
            this.ErrorList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ErrorList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ErrorList.Header = "Error List";
            this.ErrorList.Location = new System.Drawing.Point(12, 311);
            this.ErrorList.Name = "ErrorList";
            this.ErrorList.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.ErrorList.PlaceHolder = null;
            this.ErrorList.ReadOnly = true;
            this.ErrorList.Size = new System.Drawing.Size(599, 77);
            this.ErrorList.TabIndex = 3;
            // 
            // Input
            // 
            this.Input.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Input.Header = "Input";
            this.Input.Location = new System.Drawing.Point(12, 135);
            this.Input.Name = "Input";
            this.Input.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.Input.PlaceHolder = "Enter sample text...";
            this.Input.ReadOnly = false;
            this.Input.Size = new System.Drawing.Size(599, 170);
            this.Input.TabIndex = 2;
            this.Input.TextChanged += new System.EventHandler(this.Input_TextChanged);
            // 
            // RegexIn
            // 
            this.RegexIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RegexIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RegexIn.Header = "Pattern";
            this.RegexIn.Location = new System.Drawing.Point(12, 28);
            this.RegexIn.Name = "RegexIn";
            this.RegexIn.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.RegexIn.PlaceHolder = "Enter regex pattern...";
            this.RegexIn.ReadOnly = false;
            this.RegexIn.Size = new System.Drawing.Size(599, 101);
            this.RegexIn.TabIndex = 1;
            this.RegexIn.TextChanged += new System.EventHandler(this.RegexIn_TextChanged);
            // 
            // winHeader1
            // 
            this.winHeader1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.winHeader1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.winHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.winHeader1.Location = new System.Drawing.Point(0, 0);
            this.winHeader1.Name = "winHeader1";
            this.winHeader1.Size = new System.Drawing.Size(800, 22);
            this.winHeader1.TabIndex = 0;
            // 
            // SaveRegex
            // 
            this.SaveRegex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.SaveRegex.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SaveRegex.BackgroundImage")));
            this.SaveRegex.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.SaveRegex.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.SaveRegex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveRegex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.SaveRegex.Location = new System.Drawing.Point(646, 28);
            this.SaveRegex.Name = "SaveRegex";
            this.SaveRegex.Size = new System.Drawing.Size(25, 25);
            this.SaveRegex.TabIndex = 9;
            this.SaveRegex.UseVisualStyleBackColor = true;
            this.SaveRegex.Click += new System.EventHandler(this.SaveRegex_Click);
            // 
            // OpenRegex
            // 
            this.OpenRegex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.OpenRegex.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OpenRegex.BackgroundImage")));
            this.OpenRegex.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.OpenRegex.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.OpenRegex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenRegex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.OpenRegex.Location = new System.Drawing.Point(618, 28);
            this.OpenRegex.Name = "OpenRegex";
            this.OpenRegex.Size = new System.Drawing.Size(25, 25);
            this.OpenRegex.TabIndex = 10;
            this.OpenRegex.UseVisualStyleBackColor = true;
            this.OpenRegex.Click += new System.EventHandler(this.OpenRegex_Click);
            // 
            // Treegex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.OpenRegex);
            this.Controls.Add(this.SaveRegex);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Context);
            this.Controls.Add(this.ErrorList);
            this.Controls.Add(this.Input);
            this.Controls.Add(this.RegexIn);
            this.Controls.Add(this.winHeader1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Treegex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Treegex";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WinHeader winHeader1;
        private Components.GrayRichTexBox Input;
        private Components.GrayRichTexBox Context;
        private Components.GrayRichTexBox ErrorList;
        private Components.GrayRichTexBox RegexIn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private Components.GrayButton SaveRegex;
        private Components.GrayButton OpenRegex;
    }
}