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
using Threads = System.Threading;
using System.Net;
using System.IO;

namespace UniaCore.Components
{
    public class AnimArgs : EventArgs
    {
        public float Value { get; internal set; }

        internal AnimArgs(float v) => Value = v;

    }

    public class LerpAnimation
    {
        public int Period { get; private set; }
        public float Value { get; private set; }

        public bool IsRunning { get; private set; }
        bool inverted;
        public bool Inverted { get => inverted; set { Value = (inverted = value) ? 1 - sw.ElapsedMilliseconds / (float)Period : sw.ElapsedMilliseconds / (float)Period; } }


        public LerpAnimation(int period)
        {
            Period = period;
            Value = 0;
            sw = new Stopwatch();
            t = new Timer();
            t.Interval = 1;
            OnFinish = null;

            t.Tick += Update;
        }

        private void Update(object sender, EventArgs e)
        {
            var x = sw.ElapsedMilliseconds / (Period * 1f);
            Value = Inverted ? 1 - x : x;

            if (x > 1)
            {
                Stop();
                Value = Inverted ? 0 : 1;
                OnFinish?.Invoke(null, new AnimArgs(Value));
            }
            else
            {
                OnUpdate?.Invoke(null, new AnimArgs(Value));
            }
        }

        public event EventHandler<AnimArgs> OnFinish;
        public event EventHandler<AnimArgs> OnUpdate;

        Timer t;
        Stopwatch sw;

        public void Start()
        {
            Value = Inverted ? 1 : 0;
            t.Start();
            sw.Restart();
            IsRunning = true;
            Update(null, EventArgs.Empty);
        }


        public void Stop()
        {
            t.Stop();
            sw.Stop();
            IsRunning = false;
        }

        public void Restart()
        {
            Value = Inverted ? 1 : 0;
            t.Start();
            sw.Restart();
            IsRunning = true;
            Update(null, EventArgs.Empty);
        }


    }
}
