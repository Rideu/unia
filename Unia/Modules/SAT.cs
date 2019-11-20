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
using static UniaCore.Helper;

namespace UniaCore
{
    public partial class MainWindow
    {
        public void InitSAT()
        {

            speedwatch.Start();
            stopwatch.Start();
        }

        static int
            tc = 1,
            sc = 1;

        static void nullstats()
        {
            rmc = lmc = tc = 1;
        }

        static Process gp;
        static IntPtr gpp;
        static Timer waitprocess = new Timer();
        static MouseHook ms_listener;
        static KeyboardHook kb_listener;
        static Form gameWindow;

        delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

        [DllImport("user32.dll")]
        static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);

        private const uint WINEVENT_OUTOFCONTEXT = 0;
        private const uint EVENT_SYSTEM_FOREGROUND = 3;

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        string GetActiveWindowTitle()
        {
            const int nChars = 256;
            IntPtr handle = IntPtr.Zero;
            StringBuilder Buff = new StringBuilder(nChars);
            handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }

        public void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            var x = GetActiveWindowTitle();
            if (wink != null)
            {
                wink.Lock = x != "GTA: San Andreas"; 
            }
        }

        WinEventDelegate dele = null;

        public static void MainSAT()
        {

            waitprocess.Interval = 1000;
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
                    gameWindow = (Form)Form.FromHandle(gp.MainWindowHandle);

                }
            };
            mm.labelJumps.BackColor = mm.labelDist.BackColor = Color.FromArgb(80, 30, 30);
            waitprocess.Start();

            mm.dele = new WinEventDelegate(mm.WinEventProc);
            IntPtr m_hhook = SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, mm.dele, 0, 0, WINEVENT_OUTOFCONTEXT);

#if !DEBUG
            ms_listener = new MouseHook();
            ms_listener.Install();
            ms_listener.LeftButtonDown += _listener_LeftButtonUp;
            ms_listener.LeftButtonUp += Ms_listener_LeftButtonUp;
            ms_listener.RightButtonDown += Ms_listener_RightButtonDown;
            ms_listener.RightButtonUp += Ms_listener_RightButtonUp;

            kb_listener = new KeyboardHook();
            kb_listener.Install();
            kb_listener.KeyDown += Kb_listener_KeyDown;
#endif
        }

        public static void UpdateSAT()
        {

        }

        static float
            backPeakLerp1,
            backPeakLerp2,
            newPeakLerp;


        public static void DrawSAT()
        {

            //keybuf = mm.labelRMC.Text = mm.labelLMC.Text = mm.labelKeys.Text = "";

            //for (int i = 0; i < 256; i++)
            //{
            //    var s = GetAsyncKeyState(i);
            //    if (s != 0 && i > 2)
            //    {
            //        keybuf += ((Keys)i).ToString() + " ";
            //    }
            //}
            //if (lmh)
            //    keybuf += "LButton";
            //if (rmh)
            //    keybuf += "RButton"; 
            //mm.labelKeys.Text = keybuf;

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

        #region Procs

        static private bool
            rmh, lmh;

        static int
            rmc, lmc;

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

        #endregion

        #region u32

        const int PROCESS_WM_READ = 0x0010;

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        #endregion

        #region Memread

        static int moto_travelled = 0x00B7BA14;
        static int jumps_found = 0x0165C28C;

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
        #endregion
    }
}
