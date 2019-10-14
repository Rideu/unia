using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Input;
using System.Net.NetworkInformation;
using System.Net;
using System.IO;
using UniaCore.Peripherals;
using static UniaCore.Helper;

namespace UniaCore.Components
{
    public partial class RetractPanel : Panel
    {
        Point InitialPosition;
        EventHandler dl;
        public RetractPanel()
        {
            InitializeComponent();
            InitialPosition = Location;

            dl = (s, e) =>
            {
                InitialPosition = Location;
                LocationChanged -= dl;
            };
            LocationChanged += dl;
        }

        [Category("Appearance")]
        public string ButtonText { get => buttonLoad.Text; set => buttonLoad.Text = value; }

        bool isRetracted = true;
        bool isMoving;
        PointF fLocation;
        float lerp;

        void Extend(object sender, EventArgs e)
        {

            if ((lerp += 0.03f) > 1)
            {
                isMoving = (isRetracted = false);
                t.Stop();
                t.Tick -= Extend;
                Location = new Point(InitialPosition.X, InitialPosition.Y - Height + buttonLoad.Height);
                lerp = 0;
            }
            else
            {
                fLocation = new PointF(Location.X, PowXIn(InitialPosition.Y, InitialPosition.Y - Height + buttonLoad.Height, lerp, 4));
                Location = new Point((int)fLocation.X, (int)fLocation.Y);
            }
        }

        void Retract(object sender, EventArgs e)
        {
            if ((lerp += 0.03f) > 1)
            {
                isMoving = !(isRetracted = true);
                t.Stop();
                t.Tick -= Retract;
                Location = InitialPosition;
                lerp = 0;
            }
            else
            {
                fLocation = new PointF(Location.X, PowXIn(InitialPosition.Y - Height + buttonLoad.Height, InitialPosition.Y, lerp, 4));
                Location = new Point((int)fLocation.X, (int)fLocation.Y);
            }
        }
        Timer t = new Timer();

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (isMoving) return;

            if (isRetracted)
                t.Tick += Extend;
            else
                t.Tick += Retract;
            t.Interval = 1;
            isMoving = true;
            t.Start();

        }
    }
}
