namespace UniaCore.Peripherals
{
    partial class WinKeys
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
            this.labelKeys = new System.Windows.Forms.Label();
            this.winHeader1 = new UniaCore.WinHeader();
            this.SuspendLayout();
            // 
            // labelKeys
            // 
            this.labelKeys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelKeys.Font = new System.Drawing.Font("Corbel", 12F);
            this.labelKeys.ForeColor = System.Drawing.Color.White;
            this.labelKeys.Location = new System.Drawing.Point(0, 22);
            this.labelKeys.Name = "labelKeys";
            this.labelKeys.Size = new System.Drawing.Size(671, 331);
            this.labelKeys.TabIndex = 1;
            this.labelKeys.Text = "Wink";
            // 
            // winHeader1
            // 
            this.winHeader1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.winHeader1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.winHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.winHeader1.Location = new System.Drawing.Point(0, 0);
            this.winHeader1.Name = "winHeader1";
            this.winHeader1.Size = new System.Drawing.Size(671, 22);
            this.winHeader1.TabIndex = 0;
            // 
            // WinKeys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(671, 353);
            this.Controls.Add(this.labelKeys);
            this.Controls.Add(this.winHeader1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WinKeys";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "WinKeys";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WinKeys_FormClosing);
            this.SizeChanged += new System.EventHandler(this.WinKeys_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private WinHeader winHeader1;
        private System.Windows.Forms.Label labelKeys;
    }
}