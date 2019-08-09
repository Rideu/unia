using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Components
{
    public partial class GrayButton : Button
    {
        public GrayButton()
        {
            InitializeComponent();
            this.FlatAppearance.BorderSize = 1;
            this.FlatAppearance.BorderColor = Color.FromArgb(50, 50, 50);
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            this.ForeColor = Color.FromArgb(60, 60, 60);
            this.Location = new System.Drawing.Point(0, 0);
            this.TabIndex = 9;
            this.UseVisualStyleBackColor = true;
        }
    }
}
