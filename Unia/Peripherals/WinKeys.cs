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

namespace UniaCore.Peripherals
{

    public partial class WinKeys : Form
    {
        static string keybuf = "";
        static Timer keyt = new Timer { Interval = 6 };
        static MouseHook ms_listener;
        static KeyboardHook kb_listener;

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

        public WinKeys()
        {
            InitializeComponent();
            var winkbounds = Properties.Settings.Default.winkeys_bounds;
            if (winkbounds != default)
            {
                this.Bounds = winkbounds;
            }
            keyt.Tick += Keyt_Tick;
            keyt.Start();


            //#if !DEBUG
            //ms_listener = new MouseHook();
            //ms_listener.Install();
            //ms_listener.LeftButtonDown += _listener_LeftButtonUp;
            //ms_listener.LeftButtonUp += Ms_listener_LeftButtonUp;
            //ms_listener.RightButtonDown += Ms_listener_RightButtonDown;
            //ms_listener.RightButtonUp += Ms_listener_RightButtonUp;

            //kb_listener = new KeyboardHook();
            //kb_listener.Install();
            //kb_listener.KeyDown += Kb_listener_KeyDown;
            //#endif
        }

        public bool Lock = false;

        private void Keyt_Tick(object sender, EventArgs e)
        {

            keybuf = labelKeys.Text = labelKeys.Text = labelKeys.Text = "";

            if (Lock) return;

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

            labelKeys.Text = keybuf;
        }

        private const int
        HTLEFT = 10,
        HTRIGHT = 11,
        HTTOP = 12,
        HTTOPLEFT = 13,
        HTTOPRIGHT = 14,
        HTBOTTOM = 15,
        HTBOTTOMLEFT = 16,
        HTBOTTOMRIGHT = 17;

        const int BorderSize = 5;


        private void WinKeys_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ms_listener.Uninstall();
            //kb_listener.Uninstall();
            keyt.Stop();
        }


        private void WinKeys_SizeChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.winkeys_bounds = Bounds;
            Properties.Settings.Default.Save();
        }

        Rectangle TopBorder { get { return new Rectangle(0, 0, this.ClientSize.Width, BorderSize); } }
        Rectangle BottomBorder { get { return new Rectangle(0, this.ClientSize.Height - BorderSize, this.ClientSize.Width, BorderSize); } }
        Rectangle RightBorder { get { return new Rectangle(this.ClientSize.Width - BorderSize, 0, BorderSize, this.ClientSize.Height); } }
        Rectangle LeftBorder { get { return new Rectangle(0, 0, BorderSize, this.ClientSize.Height); } }

        Rectangle TopLeft { get { return new Rectangle(0, 0, BorderSize, BorderSize); } }
        Rectangle TopRight { get { return new Rectangle(this.ClientSize.Width - BorderSize, 0, BorderSize, BorderSize); } }
        Rectangle BottomLeft { get { return new Rectangle(0, this.ClientSize.Height - BorderSize, BorderSize, BorderSize); } }
        Rectangle BottomRight { get { return new Rectangle(this.ClientSize.Width - BorderSize, this.ClientSize.Height - BorderSize, BorderSize, BorderSize); } }


        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == 0x84)
            {
                var cp = MousePosition;
                var cursor = this.PointToClient(cp);

                if (TopLeft.Contains(cursor)) message.Result = (IntPtr)HTTOPLEFT;
                else if (TopRight.Contains(cursor)) message.Result = (IntPtr)HTTOPRIGHT;
                else if (BottomLeft.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMLEFT;
                else if (BottomRight.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMRIGHT;

                else if (TopBorder.Contains(cursor)) message.Result = (IntPtr)HTTOP;
                else if (LeftBorder.Contains(cursor)) message.Result = (IntPtr)HTLEFT;
                else if (RightBorder.Contains(cursor)) message.Result = (IntPtr)HTRIGHT;
                else if (BottomBorder.Contains(cursor)) message.Result = (IntPtr)HTBOTTOM;
            }
        }
    }
}
