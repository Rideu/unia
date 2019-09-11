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

namespace UniaCore
{
    public partial class MainWindow
    {
        public void InitSAT()
        {

            speedwatch.Start();
            stopwatch.Start();
        }

        public static void MainSAT()
        {

            waitprocess.Interval = 100;
            waitprocess.Tick += delegate
            {
                var fetch = Process.GetProcessesByName("gta_saao");
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

        public static void UpdateSAT()
        {

        }

        #region Procs

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

        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(int i);
        [DllImport("user32.dll")]
        public static extern short GetKeyState(int i);

        const int PROCESS_WM_READ = 0x0010;

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        #endregion

        #region Memread

        static int moto_travelled = 0x00B7BA14;
        static int jumps_found = 0x00B7B6E0;

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
