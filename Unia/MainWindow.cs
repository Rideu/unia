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
using UniaCore.Peripherals;
using NAudio;
using NAudio.Wave;
using NAudio.Dsp;
using NAudio.Wave.SampleProviders;
using NAudio.CoreAudioApi;
using static UniaCore.Helper;
using UniaCore.Components;

namespace UniaCore
{
    public partial class MainWindow : Form
    {
        Timer t, vol = new Timer();
        Stopwatch stopwatch = new Stopwatch();
        Stopwatch speedwatch = new Stopwatch();

        public MainWindow()
        {
            t = new Timer();
            t.Interval = 16;
            t.Tick += delegate
            {
                MainWindow.AppIdle();
            };
            t.Start();

            InitializeComponent();

            foreach (Control c in Controls)
            {
                c.MouseMove += C_MouseMove;
            }

            vertScrollWavefactor.Value = .5f;
            checkBoxColoriseCanvas.Checked = Properties.Settings.Default.colback;
            fade = Properties.Settings.Default.fade;

            mm = this;

            DoubleBuffered = true;

            InitSpectrum();
            InitSAT();

            formFade.OnFinish += (s, e) =>
            {
                Opacity = e.Value;
            };
            formFade.OnUpdate += (s, e) => { Opacity = e.Value; };

            MainMenu();
        }

        LerpAnimation
            formFade = new LerpAnimation(200);
        bool fade;

        private void Application_Idle(object sender, EventArgs e)
        {
            //if (formFade.IsRunning)
            //    Opacity = formFade.Value;

            if (fade)
            {
                if (!min && Bounds.Contains(MousePosition))
                {
                    min = true;
                    formFade.Inverted = false;
                    formFade.Start();
                    //Opacity = 0;
                }
                else
                if (min && !Bounds.Inflate(100f, 100f).Contains(MousePosition))
                {
                    min = false;
                    formFade.Inverted = true;
                    formFade.Start();
                    //Opacity = 1;
                }
            }
        }

        bool min = false;

        private void C_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
        }

        static MainWindow mm;
        static Graphics mmp5g;

        static Stopwatch sw = new Stopwatch();
        static void MainMenu()
        {
            MainSpectrum();
            MainSAT();
        }

        static string keybuf = "";

        static CultureInfo ci = CultureInfo.GetCultureInfo("en-US");

        static void refresh()
        {

            UpdatePerf();
            UpdateSAT();
            UpdateSpectrum();

        }

        static void exit()
        {
            ExitSpectrum();
        }


        public static void AppIdle()
        {
            mm.Application_Idle(mm, EventArgs.Empty);
            //mm.canvas1.Refresh();
            refresh();

            DrawPerf();
            DrawSAT();

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
            panelSpectrumSets.Location = panelSpectrumSets.Location == new Point(3, -25) ? new Point(3, 23) : new Point(3, -25);

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
                    Spectrum.SpectrumLowColor = colorDialog1.Color;
                }
                break;
                case "SM":
                {
                    Spectrum.SpectrumMidColor = colorDialog1.Color;
                }
                break;
                case "SH":
                {
                    Spectrum.SpectrumHighColor = colorDialog1.Color;
                }
                break;

                default:
                    break;
            }
            Properties.Settings.Default.sahc = Spectrum.SpectrumHighColor;
            Properties.Settings.Default.samc = Spectrum.SpectrumMidColor;
            Properties.Settings.Default.salc = Spectrum.SpectrumLowColor;
            Properties.Settings.Default.canvback = canvback;
            Properties.Settings.Default.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowDialog<NetChecker>();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            ShowDialog<Measure>();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            //<button onclick="var a = document.getElementsByClassName('tw-textarea tw-textarea--no-resize ')[0]; a.focus(); a.onkeydown = function() { a.value = 3223 ;} a.dispatchEvent(new KeyboardEvent('keypress',{'key':'a'}));  document.getElementsByClassName('tw-button')[0].click();">LEL</button>
        }

        private void buttonTreegex_Click(object sender, EventArgs e)
        {
            //new Treegex().ShowDialog(this);
            ShowDialog<Treegex>();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = checkBoxTopMostSwitch.Checked;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e) => exit();

        private void button8_Click(object sender, EventArgs e)
        {
            ShowDialog<MySQLMGR>();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        public static WinKeys wink;

        private void button3_Click(object sender, EventArgs e)
        {
            wink = ShowWindow<WinKeys>();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowDialog<Ultracopy>();
        }

        private void buttonVidConv_Click(object sender, EventArgs e)
        {
            ShowDialog<YDLBridge>();
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

        private void checkBoxFadeSwitch_CheckedChanged(object sender, EventArgs e)
        {

            if (!(fade = checkBoxFadeSwitch.Checked))
            {
                Opacity = 1;
            }

            Properties.Settings.Default.fade = fade;
            Properties.Settings.Default.Save();
        }
        #endregion


        static Color canvback = Properties.Settings.Default.canvback;

        #region Utils


        #endregion

    }
}
