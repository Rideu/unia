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
    public partial class WinHeader : UserControl
    {
        public WinHeader()
        {

            InitializeComponent();
        }

        Point lastLocation;

        private void WinHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Parent.Location = new Point((Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);
            }
        }

        private void WinHeader_MouseDown(object sender, MouseEventArgs e)
        {
            lastLocation = e.Location;
        }
    }
}
