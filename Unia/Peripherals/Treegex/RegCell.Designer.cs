namespace UniaCore.Peripherals.Treegex
{
    partial class RegCell
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
            this.expName = new System.Windows.Forms.Label();
            this.expText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // expName
            // 
            this.expName.Dock = System.Windows.Forms.DockStyle.Top;
            this.expName.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.expName.ForeColor = System.Drawing.Color.White;
            this.expName.Location = new System.Drawing.Point(0, 0);
            this.expName.Name = "expName";
            this.expName.Size = new System.Drawing.Size(120, 15);
            this.expName.TabIndex = 0;
            this.expName.Text = "expName";
            this.expName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // expText
            // 
            this.expText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expText.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.expText.ForeColor = System.Drawing.Color.White;
            this.expText.Location = new System.Drawing.Point(0, 15);
            this.expText.Name = "expText";
            this.expText.Size = new System.Drawing.Size(120, 57);
            this.expText.TabIndex = 1;
            this.expText.Text = "expText";
            this.expText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RegCell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.expText);
            this.Controls.Add(this.expName);
            this.Name = "RegCell";
            this.Size = new System.Drawing.Size(120, 72);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label expName;
        private System.Windows.Forms.Label expText;
    }
}
