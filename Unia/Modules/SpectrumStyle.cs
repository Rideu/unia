using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
using Microsoft.Win32;

using static System.Math;
using static UniaCore.Helper;
using static UniaCore.Properties.Settings;

namespace UniaCore
{


    public class Spectrum
    {



        struct FreqShape
        {
            public Color col;
            public PointF point;
            public PointF size;
        }

        public static Color SpectrumLowColor = Default.salc;
        public static Color SpectrumMidColor = Default.samc;
        public static Color SpectrumHighColor = Default.sahc;

        public static int HorizontalOffset { get; set; } = 225; int Step = 3;

        public enum SpectrumStyle
        {
            Blocks,
            Lines
        }

        Bitmap img;
        public Spectrum()
        {

            img = new Bitmap(1, 3);
            //img.SetPixel(0, 0, Color.FromArgb(57, 18, 3));
            //img.SetPixel(0, 1, Color.OrangeRed);
            //img.SetPixel(0, 2, Color.Yellow);
            img.SetPixel(0, 0, Color.FromArgb(40, 80, 160));
            img.SetPixel(0, 1, Color.FromArgb(96, 128, 255));
            img.SetPixel(0, 2, Color.FromArgb(255, 255, 255));
            //img.SetPixel(0, 2, Color.FromArgb(126, 188, 255));

            for (int i = 0; i < aliasteps; i++)
            {
                aliasing.Add(new float[SampleWidth]);
            }
        }

        Control hostControl;
        public Control Host
        {
            get => hostControl;
            set
            {
                HorizontalOffset = (hostControl = value).Height / 2;
            }
        }

        static Pen wfp = new Pen(Color.Green)
        {
            //Alignment = System.Drawing.Drawing2D.PenAlignment.Center,
            //LineJoin = System.Drawing.Drawing2D.LineJoin.Round,
            Width = 1f
        };

        static SolidBrush wfb = new SolidBrush(Color.Green);

        //public Func<float, float> freqFunc = new Func<float, float>((f) => { return 1; });

        FreqShape[] freqPoints;

        static Spectrum()
        {
        }

        static int SampleWidth = 2048;
        static int aliasteps = 4;
        volatile List<float[]> aliasing = new List<float[]>();

        public async void Evaluate(Complex[] frequencies, float exponent, Point mp = default)
        {
            freqPoints = new FreqShape[SampleWidth = frequencies.Length];
            freqPoints[0].point = new PointF(0, HorizontalOffset);

            for (int i = aliasing.Count - 1; i > 0; i--)
            {
                aliasing[i] = aliasing[i - 1];
            }
            var threads = 4;
            var chunkLength = hostControl.Width / threads / Step;

            Parallel.For(0, threads, (t) =>
            {
                for (int i = chunkLength * t; i < chunkLength * (t + 1); i++)
                //for (int i = fl * t / 2; i < fl - fl * t / 2; i++)
                {

                    var res = frequencies[i];
                    var value = ((float)Sqrt(res.X * res.X * 2 + res.Y * res.Y) * (2000 + i * (i * 0.01f)));
                    value = (float)Sqrt(value /*/ (value + 5)*/) * 10;
                    var ac = 0.0f;
                    for (int sm = 1; sm < aliasing.Count; sm++)
                    {
                        ac += aliasing[sm][i];
                    }
                    aliasing[0][i] = ((ac + value) / (aliasteps - 0.1f));

                    var exp = ((float)Pow(aliasing[0][i], 1.5f + exponent * 1)) / 16;
                    //var exp = nawf[i];
                    var s = i % 2 == 0 ? 1 : -1;
                    var tx = (i) * Step;
                    var ty = (exp + 0.0f);

                    var my = (1 - (float)Abs(HorizontalOffset - mp.Y) * 4 / 240).Clamp(0, 1);
                    var mx = (1 - (float)Abs(tx - mp.X) * 4 / 60);
                    var c = LerpCol(LerpCol(SpectrumLowColor, LerpCol(SpectrumMidColor, SpectrumHighColor, (exp / (40 / exponent))), (exp / (70 / exponent))), Color.Red, mx * my);


                    freqPoints[i].point = new PointF(tx, HorizontalOffset - ty);
                    freqPoints[i].size = new PointF(tx, ty);
                    freqPoints[i].col = c;
                }
            });
        }
        static bool capped;
        static IntPtr ProgMan = FindWindow("Progman", "Program Manager");

        static IntPtr Shell = FindWindowEx(ProgMan, IntPtr.Zero, "WorkerW", null);

        static IntPtr listView = FindWindowEx(Shell, IntPtr.Zero, "SysListView32", "FolderView");

        static IntPtr hdc = GetDC(listView);




        RECT rect;

        Bitmap back = new Bitmap(400, 225);

        GraphicsPath gp = new GraphicsPath() { FillMode = FillMode.Alternate };

        public void DrawSpectrum(Graphics g)
        {
            if (freqPoints != null)
            {
                //g.DrawClosedCurve(wfp, freqPoints.Select(n => n.point).ToArray(), 1, FillMode.Alternate);
                //g.DrawCurve(wfp, freqPoints.Select(n => n.point).ToArray());
                for (int i = 0; i < hostControl.Width; i++)
                {
                    //wfp.Color = freqPoints[i].col;
                    wfb.Color = freqPoints[i].col;
                    //g.DrawLine(wfp, freqPoints[i].point.X, freqPoints[i].point.Y, freqPoints[i - 1].point.X, freqPoints[i - 1].point.Y);
                    //g.DrawLine(wfp, freqPoints[i].point.X, freqPoints[i].point.Y, freqPoints[i].point.X, HorizontalOffset + freqPoints[i].size.Y);
                    g.FillRectangle(wfb, freqPoints[i].point.X, freqPoints[i].point.Y, Step - 1, freqPoints[i].size.Y);
                    //g.DrawImage(img, freqPoints[i].point.X, freqPoints[i].point.Y, Step - 1, (int)freqPoints[i].size.Y);
                    //g.DrawImage(img, freqPoints[i].point.X, freqPoints[i].point.Y, Step - 1, (int)freqPoints[i].size.Y);
                    //wfb.Color = freqPoints[100].col;
                    //g.FillClosedCurve(wfb, freqPoints.Select(p => p.point).ToArray());
                }
            }
        }


    }
}