using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Diagnostics;
using System.Windows.Input;
using System.Net.NetworkInformation;
using System.Threading;
using System.Net; 
using static System.Math; 
using static System.Text.RegularExpressions.Regex;

namespace Uniview
{
    public static class Helper
    {

        #region Generics

        public static T Clamp<T>(this T v, T min, T max) where T : IComparable => v.CompareTo(max) == 1 ? max : v.CompareTo(min) == -1 ? min : v;

        #endregion

        #region Rectangle

        public static Rectangle Inflate(this Rectangle r, float w, float h)
        {
            r.Inflate((int)w, (int)h);
            return r;
        }

        #endregion

        #region Color
        public static Color AlphaAmount(Color src, float by)
        {
            return Color.FromArgb((int)(by * 255), src);
        }

        public static Color LerpCol(Color src, Color tgt, float by)
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
        #endregion

        #region Math

        //public static float Amplify(this float v, float amount, float lowpass = 1) => (v / (Abs(v) + lowpass) * amount);

        public static float Amplify(this float v) => (v / (0.04f + Abs(v))) * 2 - (float)Sqrt(v) / 3;

        public static int Lerp(int firstFloat, int secondFloat, float by)
        {
            return (int)(firstFloat + (secondFloat - firstFloat) * by);
        }

        public static int PowXIn(int firstFloat, int secondFloat, float by, float x)
        {
            return (int)(firstFloat + (secondFloat - firstFloat) * -(Pow(by - 1, x) - 1));
        }

        public static float Lerp(float firstFloat, float secondFloat, float by)
        {
            return (firstFloat * (1 - by)) + (secondFloat * by);
        }
        #endregion

        #region Filing

        public static string CropFile(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            byte[] b = new byte[fs.Length];
            fs.Read(b, 0, b.Length);
            fs.Close();
            string bb = "";
            Array.ForEach(b, n => { bb += n.ToString() + " "; });
            return bb;
        }

        public static FileStream AssembleFile(string data, string destpath)
        {
            var fb = data.Split(' ').TakeWhile(n => n.Length > 0).Select(n => byte.Parse(n)).ToArray();

            FileStream ffs = new FileStream(destpath, FileMode.Create);
            ffs.Write(fb, 0, fb.Length);
            ffs.Close();
            return ffs;
        }
        #endregion

        #region Extensions

        public static T ShowWindow<T>() where T : Form, new()
        {
            var x = new T { TopMost = true };
            x.Show();
            return x;
        }

        public static void ShowDialog<T>() where T : Form, new()
        {
            var x = new T { TopMost = true };
            x.ShowDialog(x.ParentForm);
        }
         
        public static Match Match(this string s, string pattern) => Regex.Match(s, pattern);
        public static bool IsMatch(this string s, string pattern) => Regex.IsMatch(s, pattern);
        #endregion

        #region Additional

        static Random rng = new Random(DateTime.Now.Millisecond);
        public static int Rand(int min, int max) => rng.Next(min, max);
        public static float RandFloat(int min, int max) => (float)rng.NextDouble();

        #endregion

        #region External
        public const int MAX_PATH = 260;

        // Dialog Codes
        internal const int WM_GETDLGCODE = 0x0087;
        internal const int DLGC_STATIC = 0x0100;

        [StructLayout(LayoutKind.Sequential)]
        public struct HWND
        {
            public IntPtr h;

            public static HWND Cast(IntPtr h)
            {
                HWND hTemp = new HWND();
                hTemp.h = h;
                return hTemp;
            }

            public static implicit operator IntPtr(HWND h)
            {
                return h.h;
            }

            public static HWND NULL
            {
                get
                {
                    HWND hTemp = new HWND();
                    hTemp.h = IntPtr.Zero;
                    return hTemp;
                }
            }

            public static bool operator ==(HWND hl, HWND hr)
            {
                return hl.h == hr.h;
            }

            public static bool operator !=(HWND hl, HWND hr)
            {
                return hl.h != hr.h;
            }

            override public bool Equals(object oCompare)
            {
                HWND hr = Cast((HWND)oCompare);
                return h == hr.h;
            }

            public override int GetHashCode()
            {
                return (int)h;
            }
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;

            public RECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }

            public bool IsEmpty
            {
                get
                {
                    return left >= right || top >= bottom;
                }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;

            public POINT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        // WinEvent specific consts and delegates

        public const int EVENT_MIN = 0;
        public const int EVENT_MAX = 0x7FFFFFFF;

        public const int EVENT_SYSTEM_MENUSTART = 0x0004;
        public const int EVENT_SYSTEM_MENUEND = 0x0005;
        public const int EVENT_SYSTEM_MENUPOPUPSTART = 0x0006;
        public const int EVENT_SYSTEM_MENUPOPUPEND = 0x0007;
        public const int EVENT_SYSTEM_CAPTURESTART = 0x0008;
        public const int EVENT_SYSTEM_CAPTUREEND = 0x0009;
        public const int EVENT_SYSTEM_SWITCHSTART = 0x0014;
        public const int EVENT_SYSTEM_SWITCHEND = 0x0015;

        public const int EVENT_OBJECT_CREATE = 0x8000;
        public const int EVENT_OBJECT_DESTROY = 0x8001;
        public const int EVENT_OBJECT_SHOW = 0x8002;
        public const int EVENT_OBJECT_HIDE = 0x8003;
        public const int EVENT_OBJECT_FOCUS = 0x8005;
        public const int EVENT_OBJECT_STATECHANGE = 0x800A;
        public const int EVENT_OBJECT_LOCATIONCHANGE = 0x800B;

        public const int WINEVENT_OUTOFCONTEXT = 0x0000;
        public const int WINEVENT_SKIPOWNTHREAD = 0x0001;
        public const int WINEVENT_SKIPOWNPROCESS = 0x0002;
        public const int WINEVENT_INCONTEXT = 0x0004;

        // WinEvent fired when new Avalon UI is created
        public const int EventObjectUIFragmentCreate = 0x6FFFFFFF;

        // the delegate passed to USER for receiving a WinEvent
        public delegate void WinEventProcDef(int winEventHook, int eventId, IntPtr hwnd, int idObject, int idChild, int eventThread, uint eventTime);


        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(int i);

        [DllImport("user32.dll")]
        public static extern short GetKeyState(int i);

        [DllImport("User32.dll")]
        public static extern bool ShowWindow(IntPtr handle, int nCmdShow);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessageTimeout(
             HWND hwnd, int Msg, IntPtr wParam, IntPtr lParam, int flags, int uTimeout, out IntPtr pResult);

        //[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        //public static extern IntPtr SendMessageTimeout(
        //     HWND hwnd, int Msg, IntPtr wParam, ref MINMAXINFO lParam, int flags, int uTimeout, out IntPtr pResult);


        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool RedrawWindow(IntPtr hWnd, RECT lprcUpdate, IntPtr hrgnUpdate, uint flags);

        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll")]
        public static extern int RestoreDC(IntPtr hDC, int sDC);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public static extern int SaveDC(IntPtr hDC);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

        #endregion
    }



    public class RECT

    {

        public int left;

        public int top;

        public int right;

        public int bottom;

        public RECT()

        {

        }

        public RECT(int left, int top, int right, int bottom)

        {

            this.left = left;

            this.top = top;

            this.right = right;

            this.bottom = bottom;

        }

    }
}
