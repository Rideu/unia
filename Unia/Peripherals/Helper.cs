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
using UniaCore.Peripherals;
using NAudio;
using NAudio.Wave;
using NAudio.Dsp;
using NAudio.Wave.SampleProviders;
using NAudio.CoreAudioApi;
using static System.Math;

namespace UniaCore
{
    public static class Helper
    {
        public static float Amplify(this float v, float amount, float lowpass = 1) => (v / (Abs(v) + lowpass) * amount);

        public static T Clamp<T>(this T v, T min, T max) where T : IComparable => v.CompareTo(max) == 1 ? max : v.CompareTo(min) == -1 ? min : v;


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

        public static int Lerp(int firstFloat, int secondFloat, float by)
        {
            return (int)(firstFloat * (1 - by)) + (int)(secondFloat * by);
        }

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
    }
}
