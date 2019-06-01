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
using System.Threading;
using System.Net;
using System.IO;
using WindowsFormsApp1.Peripherals;
using NAudio;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using NAudio.CoreAudioApi;

namespace WindowsFormsApp1.Components
{
    public partial class RetractPanel : Panel
    {
        public RetractPanel()
        {
            InitializeComponent();
        }

        [Category("Appearance")]
        public string ButtonText { get => buttonLoad.Text; set => buttonLoad.Text = value; }

        bool isRetracted;
        bool isMoving;

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (isMoving) return;
            var t = new System.Windows.Forms.Timer();
            if (!isRetracted)
                t.Tick += delegate
                {
                    if (Location.Y <= 60 && !isRetracted)
                    {
                        isMoving = !(isRetracted = true);
                        t.Stop();
                    }
                    else Location = new Point(Location.X, Location.Y - 4);
                };
            else
                t.Tick += delegate
                {
                    if (Location.Y >= 243 && isRetracted)
                    {
                        isMoving = isRetracted = false;
                        t.Stop();
                    }
                    else Location = new Point(Location.X, Location.Y + 4);
                };
            t.Interval = 1;
            isMoving = true;
            t.Start();

        }
    }
}
