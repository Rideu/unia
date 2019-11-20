namespace GrayLib
{
    partial class GrayScroll
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
            this.slider = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // slider
            // 
            this.slider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.slider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.slider.Location = new System.Drawing.Point(1, 1);
            this.slider.Name = "slider";
            this.slider.Size = new System.Drawing.Size(10, 30);
            this.slider.TabIndex = 0;
            this.slider.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.slider.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.slider.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            this.slider.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.slider.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // VertScroll
            // 
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.slider);
            this.MaximumSize = new System.Drawing.Size(14, 9999);
            this.MinimumSize = new System.Drawing.Size(14, 100);
            this.Name = "VertScroll";
            this.Size = new System.Drawing.Size(12, 374);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel slider;
    }
}
