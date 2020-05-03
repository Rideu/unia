namespace Uniview
{
    partial class UniviewForm
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
            this.openFileDialogImage = new System.Windows.Forms.OpenFileDialog();
            this.grayButtonOpen = new GrayLib.GrayButton();
            this.winHeader1 = new GrayLib.WinHeader();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.imageViewer1 = new Uniview.Components.ImageViewer();
            this.grayButtonBackground = new GrayLib.GrayButton();
            this.colorDialogBackground = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // openFileDialogImage
            // 
            this.openFileDialogImage.Filter = "PNG|*.png|JPG|*.jpg|All files|*.*";
            this.openFileDialogImage.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogImage_FileOk);
            // 
            // grayButtonOpen
            // 
            this.grayButtonOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.grayButtonOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grayButtonOpen.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.grayButtonOpen.Location = new System.Drawing.Point(4, 25);
            this.grayButtonOpen.Name = "grayButtonOpen";
            this.grayButtonOpen.Size = new System.Drawing.Size(62, 25);
            this.grayButtonOpen.TabIndex = 9;
            this.grayButtonOpen.Text = "File...";
            this.grayButtonOpen.UseVisualStyleBackColor = true;
            this.grayButtonOpen.Click += new System.EventHandler(this.grayButton1_Click);
            // 
            // winHeader1
            // 
            this.winHeader1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.winHeader1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.winHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.winHeader1.Location = new System.Drawing.Point(4, 4);
            this.winHeader1.Name = "winHeader1";
            this.winHeader1.Size = new System.Drawing.Size(792, 22);
            this.winHeader1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(7, 56);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(447, 96);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.Text = "";
            // 
            // imageViewer1
            // 
            this.imageViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageViewer1.BackColor = System.Drawing.Color.White;
            this.imageViewer1.Location = new System.Drawing.Point(4, 50);
            this.imageViewer1.Margin = new System.Windows.Forms.Padding(0);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.Size = new System.Drawing.Size(792, 396);
            this.imageViewer1.TabIndex = 10;
            // 
            // grayButtonBackground
            // 
            this.grayButtonBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.grayButtonBackground.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grayButtonBackground.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.grayButtonBackground.Location = new System.Drawing.Point(72, 25);
            this.grayButtonBackground.Name = "grayButtonBackground";
            this.grayButtonBackground.Size = new System.Drawing.Size(62, 25);
            this.grayButtonBackground.TabIndex = 12;
            this.grayButtonBackground.Text = "Back...";
            this.grayButtonBackground.UseVisualStyleBackColor = true;
            this.grayButtonBackground.Click += new System.EventHandler(this.grayButtonBackground_Click);
            // 
            // UniviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grayButtonBackground);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.grayButtonOpen);
            this.Controls.Add(this.winHeader1);
            this.Controls.Add(this.imageViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UniviewForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Uniview";
            this.Load += new System.EventHandler(this.UniviewForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GrayLib.WinHeader winHeader1;
        private GrayLib.GrayButton grayButtonOpen;
        private Uniview.Components.ImageViewer imageViewer1;
        private System.Windows.Forms.OpenFileDialog openFileDialogImage;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private GrayLib.GrayButton grayButtonBackground;
        private System.Windows.Forms.ColorDialog colorDialogBackground;
    }
}

