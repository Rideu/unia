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
using static GrayLib.Helper;

namespace GrayLib
{
    public partial class RetractPanel : UserControl
    {
        Point InitialPosition;
        EventHandler dl;

        public RetractPanel()
        {
            InitializeComponent();
            InitialPosition = Location;
            finalY = InitialPosition.Y - Height - buttonRetract.Height * 2;

            dl = (s, e) =>
            {
                InitialPosition = Location;

                finalY = (dirTop) ? InitialPosition.Y - Height - buttonRetract.Height * 2 : InitialPosition.Y + Height + buttonRetract.Height * 2;
                LocationChanged -= dl;
            };
            LocationChanged += dl;
        }

        [Category("Appearance")]
        public string ButtonText { get => buttonRetract.Text; set => buttonRetract.Text = value; }

        bool bRetrAtTop = false;
        [Category("Appearance")]
        public bool ButtonAtTop
        {
            get => bRetrAtTop; set
            {
                if (bRetrAtTop = value)
                {
                    buttonRetract.Dock = DockStyle.Top;
                }
                else
                {
                    buttonRetract.Dock = DockStyle.Bottom;
                }
            }
        }


        bool dirTop = true;
        [Category("Appearance")]
        /// If true, the panel goes up (std) and down otherwise.
        public bool DirectedAtTop
        {
            get => dirTop;
            set => dirTop = value;
        }

        bool isRetracted = true;
        bool isMoving;
        PointF fLocation;
        float lerp;

        int finalY;

        void Extend(object sender, EventArgs e)
        {

            if ((lerp += 0.03f) > 1)
            {
                isMoving = (isRetracted = false);
                t.Stop();
                t.Tick -= Extend;
                Location = new Point(InitialPosition.X, finalY);
                lerp = 0;
            }
            else
            {
                var l = lerp;
                fLocation = new PointF(Location.X, PowXIn(InitialPosition.Y, finalY, l, 4));
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
                var l = lerp;
                fLocation = new PointF(Location.X, PowXIn(finalY, InitialPosition.Y, l, 4));
                Location = new Point((int)fLocation.X, (int)fLocation.Y);
            }
        }
        Timer t = new Timer();

        public void RollPanel()
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

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            RollPanel();
        }
    }
}
