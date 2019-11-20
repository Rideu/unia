using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrayLib
{
    public partial class GrayButton : Button
    {
        public GrayButton()
        {
            this.SuspendLayout();
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 1;
            //this.FlatAppearance.BorderColor = Color.FromArgb(50, 50, 50);

            this.BackColor = Color.FromArgb(50, 50, 50);
            this.ForeColor = SystemColors.WindowFrame;

            this.Location = new System.Drawing.Point(0, 0);
            this.Size = new System.Drawing.Size(100, 25);

            this.TabIndex = 9;
            this.UseVisualStyleBackColor = true;
            this.ResumeLayout(false);
            //InitializeComponent();
        }
    }
}
