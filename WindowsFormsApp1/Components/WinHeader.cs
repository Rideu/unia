using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniaCore.Components
{
    public partial class WinHeader : Panel
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
                Parent.Location = new Point((Location.X - lastLocation.X) + MousePosition.X, (Location.Y - lastLocation.Y) + MousePosition.Y);
            }
        }

        private void WinHeader_MouseDown(object sender, MouseEventArgs e)
        {
            lastLocation = PointToClient(MousePosition);
        }
    }
}
