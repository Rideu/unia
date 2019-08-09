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
    public partial class GrayProgressBar : UserControl
    {
        public GrayProgressBar()
        {
            InitializeComponent();
        }

        public void SetProgress(float val)
        {
            label1.Width = (int)((Width - 4) * (val));
        }

        private void GrayProgressBar_Resize(object sender, EventArgs e)
        {
            label1.Height = Height - 4;
        }
    }
}
