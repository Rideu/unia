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
using NAudio;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using NAudio.CoreAudioApi;

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

        void Extend(object sender, EventArgs e)
        {

            if (Location.Y <= InitialPosition.Y - (Height + buttonLoad.Height))
            {
                isMoving = (isRetracted = false);
                t.Stop();
                t.Tick -= Extend;
                Location = new Point(InitialPosition.X, (Location.Y - (InitialPosition.Y - Height)));
            }
            else
                fLocation = new PointF(Location.X, Location.Y - ((Location.Y - (InitialPosition.Y - Height + buttonLoad.Height)) * 0.05f));
            Location = new Point((int)fLocation.X, (int)fLocation.Y);
        }

        void Retract(object sender, EventArgs e)
        {
            if (Location.Y >= InitialPosition.Y)
            {
                isMoving = !(isRetracted = true);
                t.Stop();
                t.Tick -= Retract;
                Location = InitialPosition;
            }
            else
                fLocation = new PointF(Location.X, Location.Y + ((Location.Y + (InitialPosition.Y - Height)) * 0.05f));
            Location = new Point((int)fLocation.X, (int)fLocation.Y);
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
