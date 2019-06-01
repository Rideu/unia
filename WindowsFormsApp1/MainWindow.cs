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

namespace WindowsFormsApp1
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
            t.Interval = 1;
            InitializeComponent();
            t.Tick += delegate { MainWindow.AppIdle(); };
            t.Start();
            mm = this;
            WaveOut wo = new WaveOut() { };

            //BufferedWaveProvider bwp = new BufferedWaveProvider(new WaveFormat(44100, 2));
            //bwp
            var gc = Process.GetProcessesByName("chrome").Where(n => n.MainWindowHandle.ToInt32() != 0).FirstOrDefault();

            var wci = WaveCallbackInfo.ExistingWindow(gc.MainWindowHandle);

            waveIn = new WaveIn() { WaveFormat = new WaveFormat(44100, 2), };
            //wo.
            //d.WaveFormat = new WaveFormat(44100, 2);
            waveIn.DataAvailable += delegate (object sender, WaveInEventArgs e)
            {
                //ams.Position = 0;
                //ams.SetLength(0);
                //ams.Write(e.Buffer, 0, e.BytesRecorded);

                r = new RawSourceWaveStream(e.Buffer, 0, e.Buffer.Length, wf);
                //ams.Write(e.Buffer, 0, e.BytesRecorded);
                //nsbs = e.Buffer;
            };

            waveIn.StartRecording();
            //waveIn.StartRecording();
            DoubleBuffered = true;
            //SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

            speedwatch.Start();
            stopwatch.Start();
            MainMenu();
        }

        static MainWindow mm;
        static Graphics mmp5g;

        static Process gp;
        static IntPtr gpp;

        static MouseHook ms_listener;
        static KeyboardHook kb_listener;
        static Color salc = Color.FromArgb(155, 25, 255);
        static Color sahc = Color.FromArgb(255, 153, 25);
        static Color samc = Color.FromArgb(255, 253, 25);
        static void MainMenu()
        {
            mm.canvas1.Paint += delegate (object sender, PaintEventArgs e)
            {
                //e.Graphics.Clear(mm.canvas1.BackColor);
                for (int i = 0; i < awfl; i++)
                {
                    var v = nawf[i];
                    var exp = (v * v * v * v * v);
                    wfp.Color = LerpCol(salc, LerpCol(samc, sahc, (float)Math.Sin(exp)), (float)Math.Cos(exp));
                    e.Graphics.DrawLine(wfp, i, exp * 77, i, exp * exp * 71);
                    //e.Graphics.DrawLine(wfp, i, exp * 17, i, exp * -exp * 71);
                    //e.Graphics.DrawLine(wfp, i, exp * 87, i, exp * exp * 221);

                }
            };
            waitprocess.Interval = 100;
            waitprocess.Tick += delegate
            {
                var fetch = Process.GetProcessesByName("gta_sa");
                if (fetch.Count() > 0)
                {
                    nullstats();
                    gpp = OpenProcess(PROCESS_WM_READ, false, (gp = fetch.First()).Id);
                    mm.labelJumps.BackColor = mm.labelDist.BackColor = Color.FromArgb(30, 30, 30);
                    totmtd = Properties.Settings.Default.MotoDistance;
                    waitprocess.Stop();
                }
            };
            mm.labelJumps.BackColor = mm.labelDist.BackColor = Color.FromArgb(80, 30, 30);
            waitprocess.Start();
            ms_listener = new MouseHook();
            ms_listener.Install();
            ms_listener.LeftButtonDown += _listener_LeftButtonUp;
            ms_listener.LeftButtonUp += Ms_listener_LeftButtonUp;
            ms_listener.RightButtonDown += Ms_listener_RightButtonDown;
            ms_listener.RightButtonUp += Ms_listener_RightButtonUp;

            kb_listener = new KeyboardHook();
            kb_listener.Install();
            kb_listener.KeyDown += Kb_listener_KeyDown;

        }

        private static void Ms_listener_RightButtonUp(MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            rmh = false;
        }

        private static void Ms_listener_LeftButtonUp(MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            lmh = false;
        }

        private static void Ms_listener_RightButtonDown(MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            rmc++;
            rmh = true;
        }

        private static void _listener_LeftButtonUp(MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            lmc++;
            lmh = true;
        }

        private static void Kb_listener_KeyDown(KeyboardHook.VKeys key)
        {
            if (key == KeyboardHook.VKeys.LSHIFT)
                lmc++;
        }


        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(int i);
        [DllImport("user32.dll")]
        public static extern short GetKeyState(int i);

        const int PROCESS_WM_READ = 0x0010;

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        static int moto_travelled = 0x00B79394;
        static int jumps_found = 0x00B79060;

        static float nmtd, omtd, totmtd;
        static float nspd, ospd, spd, oespd;
        static int jmp = 0;
        public static float memReadFloat(int addr, IntPtr proc)
        {
            int bytesRead = 0;
            byte[] buffer = new byte[4];

            ReadProcessMemory((int)proc, addr, buffer, buffer.Length, ref bytesRead);

            return BitConverter.ToSingle(buffer, 0);
        }

        public static int memReadInt(int addr, IntPtr proc)
        {
            int bytesRead = 0;
            byte[] buffer = new byte[4];

            ReadProcessMemory((int)proc, addr, buffer, buffer.Length, ref bytesRead);

            return BitConverter.ToInt32(buffer, 0);
        }

        static bool lmh, rmh;
        static int lmc, rmc;
        static float lmcps, rmcps;
        static float cc, ncv, ocv, nrv, orv;
        static int tc = 1, sc = 1, msc = 1;
        static int nbin, cbin, obin, nbout, cbout, obout;
        static int awfl = 100;
        volatile static float[] nawf = new float[400], oawf = new float[400];

        static string keybuf = "";

        static CultureInfo ci = CultureInfo.GetCultureInfo("en-US");
        static PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        static PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes", string.Empty);
        static NetworkInterface netDevice = NetworkInterface.GetAllNetworkInterfaces().First();
        static IPv4InterfaceStatistics ndata;
        //static MMDeviceEnumerator ade = new MMDeviceEnumerator();
        static MMDeviceCollection adcs = new MMDeviceEnumerator().EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
        static WasapiLoopbackCapture d = new WasapiLoopbackCapture(adcs[0]);
        static MemoryStream ams = new MemoryStream();
        static WaveFormat wf = new WaveFormat(44100, 2);
        static RawSourceWaveStream r = new RawSourceWaveStream(ams, wf);
        static WaveIn waveIn;
        static WaveOut wout;
        volatile static byte[] nsbs = new byte[17000];

        static void nullstats()
        {
            rmc = lmc = msc = tc = 1;
        }

        async static void refresh()
        {
            await Task.Run(() =>
            {
                ocv = ncv;
                ncv = cpuCounter.NextValue();
                orv = nrv;
                nrv = ramCounter.NextValue();
                omtd = nspd = nmtd;
                //spd = nspd - ospd;
                nmtd = memReadFloat(moto_travelled, gpp);

                jmp = memReadInt(jumps_found, gpp);
                //if(nmtd <= 0)
                //{

                //}

                if (omtd > nmtd)
                {
                    Properties.Settings.Default.MotoDistance = totmtd;
                    Properties.Settings.Default.Save();
                    totmtd += omtd;
                    nullstats();
                }

                cc += ncv;
                sc++;
                //if (tc % 1000 == 0)
                if (mm.stopwatch.ElapsedMilliseconds > 1000)
                {
                    //spd = nspd - ospd;
                    //if (ospd != nspd)
                    //{

                    //}
                    //ospd = nspd;
                    tc += 1;
                    mm.stopwatch.Restart();
                }

                if (mm.speedwatch.ElapsedMilliseconds > 100)
                {
                    //oespd = ospd;
                    //var espd1 = spd;
                    spd = ((nspd - ospd) / (0.06f) + spd) / 3f;
                    ospd = nspd;
                    mm.speedwatch.Restart();
                }

                ndata = netDevice.GetIPv4Statistics();

                obin = nbin;
                nbin = (int)ndata.BytesReceived;
                obout = nbout;
                nbout = (int)ndata.BytesSent;

                cbin = nbin - obin;
                cbin = cbin < 0 ? 0 : cbin;
                cbout = nbout - obout;
                cbout = cbout < 0 ? 0 : cbout;
            }
            );

            //await Task.Run(() =>
            {
                oawf = nawf;
                nawf = new float[awfl = mm.canvas1.Width];
                oawf = nawf.Length != oawf.Length ? nawf : oawf;
                try
                {
                    //NAudio visualiser
                    //var s = new WdlResamplingSampleProvider(r.ToSampleProvider(), 44100);

                    //SampleToWaveProvider16 pcma = new SampleToWaveProvider16(r.ToSampleProvider());

                    r.Position = 0L;
                    var samplesPerPixel = 6;
                    var bytesPerSample = 4 / 4 * 2;
                    var startPosition = 0;
                    byte[] array = new byte[samplesPerPixel * bytesPerSample];
                    r.Position = startPosition + mm.canvas1.ClientRectangle.Left * bytesPerSample * samplesPerPixel;
                    for (float num = (float)mm.canvas1.ClientRectangle.X; num < (float)mm.canvas1.ClientRectangle.Right; num += 1f)
                    {
                        short num2 = 0;
                        short num3 = 0;
                        int num4 = r.Read(array, 0, samplesPerPixel * bytesPerSample);
                        for (int i = 0; i < num4; i += 2)
                        {
                            short num5 = BitConverter.ToInt16(array, i);
                            if (num5 < num2)
                            {
                                num2 = num5;
                            }
                            if (num5 > num3)
                            {
                                num3 = num5;
                            }
                        }
                        float num6 = ((float)num2 - -32768f) / 65535f;
                        float num7 = ((float)num3 - -32768f) / 65535f;
                        nawf[(int)num] = (float)(num6 + num7 + oawf[(int)num]) / 2f;
                    }
                }
                catch
                {
                    nawf = oawf;
                }
            }
            //);
        }



        static Pen wfp = new Pen(Color.Green);
        static Color skyblue = Color.FromArgb(51, 153, 255);
        static Color green = Color.FromArgb(0, 255, 0);
        static Color red = Color.FromArgb(255, 0, 0);

        //static bool pLoad, pNet, pTrack;

        static Color purple = Color.FromArgb(255, 0, 0);

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

        private void richTextBox1_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //richTextBox1.Text = "";
            //richTextBox1.ForeColor = Color.Black;
        }

        private void axWebBrowser1_Enter(object sender, EventArgs e)
        {

        }

        private void twitchOpen_Click(object sender, EventArgs e)
        {
            //axWebBrowser1.Navigate("https://www.twitch.tv/popout/vadyanga_ff/chat?popout=");
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new TwitchMGR().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new MySQLMGR().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Ultracopy().ShowDialog();
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
    }
}
