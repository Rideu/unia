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
    public partial class WinHeader : UserControl
    {
        Form owner;
        public WinHeader()
        {
            InitializeComponent();
            Dock = DockStyle.Top;
        }

        private void WinHeader_Load(object sender, EventArgs e)
        {
            owner = FindForm();
            labelFormName.Text = owner.Text;
        }

        Point lastLocation;

        private void WinHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                owner.Location = new Point((Location.X - lastLocation.X) + MousePosition.X, (Location.Y - lastLocation.Y) + MousePosition.Y);
            }
        }

        private void WinHeader_MouseDown(object sender, MouseEventArgs e)
        {
            lastLocation = PointToClient(MousePosition);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            owner.Close();
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            owner.WindowState = FormWindowState.Minimized;
        }

    }
}
