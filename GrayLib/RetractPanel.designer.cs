namespace GrayLib
{
    partial class RetractPanel
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonRetract = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonRetract
            // 
            this.buttonRetract.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonRetract.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.buttonRetract.FlatAppearance.BorderSize = 0;
            this.buttonRetract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRetract.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonRetract.Location = new System.Drawing.Point(0, 123);
            this.buttonRetract.Name = "buttonRetract";
            this.buttonRetract.Size = new System.Drawing.Size(146, 23);
            this.buttonRetract.TabIndex = 9;
            this.buttonRetract.Text = "retractPanel";
            this.buttonRetract.UseVisualStyleBackColor = true;
            this.buttonRetract.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // RetractPanel
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.buttonRetract);
            this.Size = new System.Drawing.Size(148, 148);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonRetract;
    }
}
