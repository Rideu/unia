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
using UniaCore.Peripherals;
using NAudio;
using NAudio.Wave;
using NAudio.Dsp;
using NAudio.Wave.SampleProviders;
using NAudio.CoreAudioApi;

namespace UniaCore
{
    public partial class MainWindow : Form
    {
        System.Windows.Forms.Timer t;
        static System.Windows.Forms.Timer waitprocess = new System.Windows.Forms.Timer();
        Stopwatch stopwatch = new Stopwatch();
        Stopwatch speedwatch = new Stopwatch();



        public MainWindow()
        {
            t = new System.Windows.Forms.Timer();
            t.Interval = 17;
            t.Tick += delegate { MainWindow.AppIdle(); };
            t.Start();

            InitializeComponent();

            vertScrollWavefactor.Value = .5f;
            checkBoxColoriseCanvas.Checked = Properties.Settings.Default.colback;

            mm = this;

            DoubleBuffered = true;

            InitSpectrum();
            InitSAT();

            MainMenu();
        }



        static MainWindow mm;
        static Graphics mmp5g;

        static Process gp;
        static IntPtr gpp;

        static MouseHook ms_listener;
        static KeyboardHook kb_listener;
        static Color salc = Properties.Settings.Default.salc;
        static Color sahc = Properties.Settings.Default.sahc;
        static Color samc = Properties.Settings.Default.samc;

        static Stopwatch sw = new Stopwatch();
        static void MainMenu()
        {
            MainSpectrum();
            MainSAT();
        }

        static bool lmh, rmh;
        static int lmc, rmc;
        static float lmcps, rmcps;
        static float cc, ncv, ocv, nrv, orv;
        static int tc = 1, sc = 1, msc = 1;
        static int nbin, cbin, obin, nbout, cbout, obout;


        static void nullstats()
        {
            rmc = lmc = msc = tc = 1;
        }

        static string keybuf = "";

        static CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
        //static MMDeviceEnumerator ade = new MMDeviceEnumerator();
        //static MMDeviceCollection adcs = new MMDeviceEnumerator().EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
        //static MMDevice pad = adcs[0];
        
        static void refresh()
        {

            UpdatePerf();
            UpdateSAT();
            UpdateSpectrum();

        }

        static Pen wfp = new Pen(Color.Green);
        static Color skyblue = Color.FromArgb(51, 153, 255);
        static Color green = Color.FromArgb(0, 255, 0);
        static Color red = Color.FromArgb(255, 0, 0);
        static Color purple = Color.FromArgb(255, 0, 0);

        static float padpv;

        public static void AppIdle()
        {
            mm.canvas1.Refresh();
            refresh();

            var vc = (ncv / 100) > 0.5f ? mm.labelCPUVh : mm.labelCPUVl;
            {
                mm.labelCPUVh.Text = mm.labelCPUVl.Text = "";
                vc.Text = string.Format(ci, "{0:0.0}", ncv);

                mm.labelCPUVh.Height = (int)(138 * ((ocv + ncv) / 2 / 100));
                mm.labelCPUVl.Height = 138 - (int)(138 * ((ocv + ncv) / 2 / 100));
                mm.labelCPUVh.BackColor = LerpCol(red, green, 1 - ncv / 100);
            }

            {
                mm.labelMIDVh.Text = mm.labelMIDVl.Text = "";
                vc = ((cc / sc) / 100) > 0.5f ? mm.labelMIDVh : mm.labelMIDVl;
                vc.Text = string.Format(ci, "{0:0.0}", (cc / sc));

                mm.labelMIDVh.Height = (int)(138 * ((cc / sc) / 100));
                mm.labelMIDVl.Height = 138 - (int)(138 * ((cc / sc) / 100));
                mm.labelMIDVh.BackColor = LerpCol(red, green, 1 - (cc / sc) / 100);
            }

            {
                mm.labelRAMVh.Text = mm.labelRAMVl.Text = "";
                vc = (nrv / 8192) < 0.5f ? mm.labelRAMVh : mm.labelRAMVl;
                vc.Text = string.Format(ci, "{0:0.0}G", ((8192 - nrv) / 1000));

                mm.labelRAMVh.Height = 138 - (int)(138 * (nrv / 8192));
                mm.labelRAMVl.Height = (int)(138 * (nrv / 8192));
                mm.labelRAMVh.BackColor = LerpCol(red, skyblue, 1 - (nrv / 8192));
            }
            //return;
            if (sc > 2)
            {

                mm.labelINVh.Text = mm.labelINVl.Text = "";
                vc = (cbin / 1048576f) > 0.5f ? mm.labelINVh : mm.labelINVl;
                vc.Text = string.Format(ci, "{0:0.0}", (cbin / 1024));

                mm.labelINVh.Height = (int)(138 * (cbin / 1048576f));
                mm.labelINVl.Height = 138 - (int)(138 * (cbin / 1048576f));
                mm.labelINVh.BackColor = LerpCol(purple, skyblue, 1 - (cbin / 1048576f));

                mm.labelOUTVh.Text = mm.labelOUTVl.Text = "";
                vc = (cbout / 1048576f) > 0.5f ? mm.labelOUTVh : mm.labelOUTVl;
                vc.Text = string.Format(ci, "{0:0.0}", (cbout / 1024));

                mm.labelOUTVh.Height = (int)(138 * (cbout / 1048576f));
                mm.labelOUTVl.Height = 138 - (int)(138 * (cbout / 1048576f));
                mm.labelOUTVh.BackColor = LerpCol(purple, skyblue, 1 - (cbout / 1048576f));
            }

            {
                //mm.canvas1.Height++;
                //mm.canvas1.Height--;
                //mm.waveViewer1.WaveStream = ws;
            }

            keybuf = mm.labelRMC.Text = mm.labelLMC.Text = mm.labelKeys.Text = "";

            for (int i = 0; i < 256; i++)
            {
                var s = GetAsyncKeyState(i);
                if (s != 0 && i > 2)
                {
                    keybuf += ((Keys)i).ToString() + " ";
                }
            }
            if (lmh)
                keybuf += "LButton";
            if (rmh)
                keybuf += "RButton";
            mm.labelKeys.Text = keybuf;
            mm.labelLMC.Text = string.Format(ci, "L/SMC: {0}\nL/SMCPS: {1:0.00}", lmc, lmc / (float)tc);
            mm.labelRMC.Text = string.Format(ci, "RMC: {0}\nRMCPS: {1:0.00}", rmc, rmc / (float)tc);

            if (gpp != null)
            {
                mm.labelDist.Text = string.Format(ci, "{0:0.0}|{2:000.0}\n{1:0.0}", nmtd, totmtd, spd);
                mm.labelJumps.Text = string.Format(ci, "JMP: {0}/70", jmp);
                mm.labelSpeed.Width = (int)spd;
                if (gp != null && gp.HasExited && !waitprocess.Enabled)
                {
                    mm.labelJumps.BackColor = mm.labelDist.BackColor = Color.FromArgb(80, 30, 30);
                    waitprocess.Start();
                }
            }

            if (mm.checkBoxColoriseCanvas.Checked)
            {
                mm.canvas1.BackColor = LerpCol(hcbc, LerpCol(mcbc, lcbc, (padpv)), (padpv * 4));
            }
            else if (mm.canvas1.BackColor != canvback)
            {
                mm.canvas1.BackColor = canvback;
            }
        }

        #region Events


        private void buttonSIE_Click(object sender, EventArgs e)
        {
            new SubImageExtraction().ShowDialog(this);
        }

        private void checkBoxColoriseCanvas_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.colback = checkBoxColoriseCanvas.Checked;
            Properties.Settings.Default.Save();
        }

        static bool pspecRetr = true;

        private void panelSpectrumSets_Click(object sender, EventArgs e)
        {
            panelSpectrumSets.Location = panelSpectrumSets.Location == new Point(3, -45) ? new Point(3, 0) : new Point(3, -45);

        }

        private void buttonSL_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            switch ((sender as Control).Name.Substring(6, 2))
            {
                case "BC":
                {
                    canvback = colorDialog1.Color;
                }
                break;
                case "SL":
                {
                    salc = colorDialog1.Color;
                }
                break;
                case "SM":
                {
                    samc = colorDialog1.Color;
                }
                break;
                case "SH":
                {
                    sahc = colorDialog1.Color;
                }
                break;

                default:
                    break;
            }
            Properties.Settings.Default.sahc = sahc;
            Properties.Settings.Default.samc = samc;
            Properties.Settings.Default.salc = salc;
            Properties.Settings.Default.canvback = canvback;
            Properties.Settings.Default.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Measure().ShowDialog();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            //<button onclick="var a = document.getElementsByClassName('tw-textarea tw-textarea--no-resize ')[0]; a.focus(); a.onkeydown = function() { a.value = 3223 ;} a.dispatchEvent(new KeyboardEvent('keypress',{'key':'a'}));  document.getElementsByClassName('tw-button')[0].click();">LEL</button>
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = checkBox1.Checked;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new TwitchMGR().ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new MySQLMGR().ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Ultracopy().ShowDialog();
        }

        private void buttonVidConv_Click(object sender, EventArgs e)
        {
            new Viauc().ShowDialog();
        }

        Point lastLocation;

        private void panelHeader_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            lastLocation = e.Location;
        }

        private void panelHeader_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Location = new Point((Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);
            }
        }
        #endregion


        static Color hcbc = Color.FromArgb(155, 25, 255), mcbc = Color.FromArgb(255, 153, 25), lcbc = Color.FromArgb(155, 53, 225);
        static Color canvback = Properties.Settings.Default.canvback;

        #region Utils

        static Color AlphaAmount(Color src, float by)
        {
            return Color.FromArgb((int)(by * 255), src);
        }

        static Color LerpCol(Color src, Color tgt, float by)
        {
            if (by < 0) return src;
            else if (by > 1) return tgt;
            else
                try
                {
                    return Color.FromArgb(Lerp(src.A, tgt.A, by), Lerp(src.R, tgt.R, by), Lerp(src.G, tgt.G, by), Lerp(src.B, tgt.B, by));
                }
                catch
                {
                    return src;
                }
        }

        static int Lerp(int firstFloat, int secondFloat, float by)
        {
            return (int)(firstFloat * (1 - by)) + (int)(secondFloat * by);
        }

        #endregion

    }
}
