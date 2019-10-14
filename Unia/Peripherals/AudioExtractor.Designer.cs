namespace UniaCore.Peripherals
{
    partial class YDLBridge
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
            this.textBoxWID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grayRichTexBox1 = new UniaCore.Components.GrayRichTextBox();
            this.grayProgressBar1 = new UniaCore.Components.GrayProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxOut = new System.Windows.Forms.TextBox();
            this.grayButton1 = new UniaCore.Components.GrayButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.winHeader1 = new UniaCore.WinHeader();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxWID
            // 
            this.textBoxWID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.textBoxWID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxWID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.textBoxWID.Location = new System.Drawing.Point(68, 5);
            this.textBoxWID.Name = "textBoxWID";
            this.textBoxWID.Size = new System.Drawing.Size(250, 20);
            this.textBoxWID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(160)))));
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Video link:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.grayRichTexBox1);
            this.panel1.Controls.Add(this.grayProgressBar1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxOut);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.grayButton1);
            this.panel1.Controls.Add(this.textBoxWID);
            this.panel1.Location = new System.Drawing.Point(0, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(323, 279);
            this.panel1.TabIndex = 10;
            // 
            // grayRichTexBox1
            // 
            this.grayRichTexBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grayRichTexBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grayRichTexBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grayRichTexBox1.Header = "Output";
            this.grayRichTexBox1.Location = new System.Drawing.Point(9, 81);
            this.grayRichTexBox1.Name = "grayRichTexBox1";
            this.grayRichTexBox1.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.grayRichTexBox1.PlaceHolder = null;
            this.grayRichTexBox1.ReadOnly = true;
            this.grayRichTexBox1.Size = new System.Drawing.Size(309, 162);
            this.grayRichTexBox1.TabIndex = 13;
            // 
            // grayProgressBar1
            // 
            this.grayProgressBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.grayProgressBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grayProgressBar1.Location = new System.Drawing.Point(68, 62);
            this.grayProgressBar1.Name = "grayProgressBar1";
            this.grayProgressBar1.Size = new System.Drawing.Size(250, 13);
            this.grayProgressBar1.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(160)))));
            this.label2.Location = new System.Drawing.Point(8, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Output to:";
            // 
            // textBoxOut
            // 
            this.textBoxOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.textBoxOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.textBoxOut.Location = new System.Drawing.Point(68, 36);
            this.textBoxOut.Name = "textBoxOut";
            this.textBoxOut.ReadOnly = true;
            this.textBoxOut.Size = new System.Drawing.Size(250, 20);
            this.textBoxOut.TabIndex = 10;
            this.textBoxOut.Click += new System.EventHandler(this.textBox2_Click);
            // 
            // grayButton1
            // 
            this.grayButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grayButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.grayButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.grayButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grayButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.grayButton1.Location = new System.Drawing.Point(224, 249);
            this.grayButton1.Name = "grayButton1";
            this.grayButton1.Size = new System.Drawing.Size(94, 25);
            this.grayButton1.TabIndex = 9;
            this.grayButton1.Text = "Convert";
            this.grayButton1.UseVisualStyleBackColor = false;
            this.grayButton1.Click += new System.EventHandler(this.grayButton1_Click);
            // 
            // winHeader1
            // 
            this.winHeader1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.winHeader1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.winHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.winHeader1.Location = new System.Drawing.Point(0, 0);
            this.winHeader1.Name = "winHeader1";
            this.winHeader1.Size = new System.Drawing.Size(323, 22);
            this.winHeader1.TabIndex = 11;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
            this.fileSystemWatcher1.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Created);
            // 
            // YDLBridge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(323, 299);
            this.Controls.Add(this.winHeader1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "YDLBridge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Audio Extractor";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxWID;
        private System.Windows.Forms.Label label1;
        private Components.GrayButton grayButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private Components.GrayProgressBar grayProgressBar1;
        private WinHeader winHeader1;
        private Components.GrayRichTextBox grayRichTexBox1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}