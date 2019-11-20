using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
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

namespace GrayLib
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

        public static void ShowDialog<T>() where T : Form, new()
        {
            var x = new T { TopMost = true };
            x.ShowDialog(x.ParentForm);
        }

        public static void Apply(this Control c, Action<Control> logic)
        {
            logic(c);
            foreach (Control ctrl in c.Controls)
            {
                ctrl.Apply(logic);
            }
        }
        #endregion

        #region Additional

        static Random rng = new Random(DateTime.Now.Millisecond);
        public static int Rand(int min, int max) => rng.Next(min, max);
        public static float RandFloat(int min, int max) => (float)rng.NextDouble();

        #endregion

        #region External

        [DllImport("User32.dll")]
        public static extern bool ShowWindow(IntPtr handle, int nCmdShow);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

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
