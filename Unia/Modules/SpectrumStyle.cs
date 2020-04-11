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
using UniaCore.Components;

using static System.Math;
using static UniaCore.Helper;
using static UniaCore.Interlop;
using static UniaCore.Properties.Settings;

using XNA = Microsoft.Xna.Framework;
using XNAG = Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Content;

// Refs:
// — https://stackoverflow.com/questions/18813112

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

        public static int HorizontalOffset { get; set; } = 225; int Step = 1;

        public enum DrawingMode
        {
            Freq,
            Spectrum
        }

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

        SpectrumViewer monohostControl;
        public SpectrumViewer MonoHost
        {
            get => monohostControl;
            set
            {
                HorizontalOffset = (monohostControl = value).Height / 2  /*- 40*/;
                monohostControl.spectrum = this;
            }
        }

        public float Exponent { get; set; }

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

        static Stopwatch sw = new Stopwatch();
        protected Point mousepos;
        public static DrawingMode Mode { get; private set; } = DrawingMode.Spectrum;

        public void Evaluate(Complex[] frequencies, float exponent, Point mp = default)
        {
            var hostsize = (hostControl ?? monohostControl).Size;
            cent = new XNA.Vector2((hostsize.Width / 2 /*+ mp.X*/) / (float)hostsize.Width, (HorizontalOffset /* hostsize.Height / 2 + mp.Y*/) / (float)hostsize.Height);

            mousepos = mp;
            sw.Restart();
            Exponent = exponent;

            if (freqPoints == null)
                freqPoints = new FreqShape[SampleWidth = frequencies.Length];
            freqPoints[0].point = new PointF(0, HorizontalOffset);

            for (int i = aliasing.Count - 1; i > 0; i--)
            {
                aliasing[i] = aliasing[i - 1];
            }
            var threads = 2;
            var chunkLength = hostsize.Width / threads / Step;

            // TODO: move spectrum analyzer here

            if (Mode == DrawingMode.Spectrum)
                Parallel.For(0, threads, (t) =>
                {
                    for (int i = chunkLength * t; i < chunkLength * (t + 1); i++)
                    {

                        var res = frequencies[i];

                        var value = ((float)Sqrt(res.X * res.X / .65f + res.Y * res.Y / .65f) * (2000 + i * (i * .05f))) / .2f;
                        value = (float)Sqrt(value / (value + 111)) * 25;
                        var ac = 0.0f;
                        for (int sm = 1; sm < aliasing.Count; sm++)
                        {
                            ac += aliasing[sm][i];
                        }
                        var v = ((ac / 1.4f + value /*(aliasing[0][i - 1] + value*3 + aliasing[0][i + 1]) / 4*/) / (4 + 0.11f)) * 1.2f;
                        value = aliasing[0][i] = aliasing[0][i] > v ? aliasing[0][i] - 0.8f : v;
                        value = value < 1 ? 1 : value;

                        var exp = ((float)Pow(value / 4, .1f + exponent / .3f) / 4 * (.5f / (value / 250)));
                        var s = i % 2 == 0 ? 1 : -1;
                        var tx = (i) * Step /*+ i*/;
                        var ty = (exp) /** s*/;
                        ty = (i > 2 ?
                        (ty + freqPoints[i - 1].size.Y + freqPoints[i + 1].size.Y + freqPoints[i - 2].size.Y + freqPoints[i + 2].size.Y) / 5 :
                        (ty + freqPoints[i + 1].size.Y + freqPoints[i + 2].size.Y) / 3);

                        var mx = (1 - (float)Abs(tx - mp.X) * 4 / 60);
                        var my = (1 - (float)Abs(HorizontalOffset - mp.Y) * 4 / 240).Clamp(0, 1);
                        var c = LerpCol(LerpCol(SpectrumLowColor, LerpCol(SpectrumMidColor, SpectrumHighColor, (value / (10 / exponent))), (value / (15 / exponent))), Color.Red, mx * my);

                        freqPoints[i].point = new PointF(Step / 4 + tx, HorizontalOffset + 100 - ty);
                        freqPoints[i].size = new PointF(tx, ty * 1);
                        freqPoints[i].col = c;
                    }
                });
            //else
            //{
            //    for (int i = 0; i < frequencies.Length; i++)
            //    {
            //        var value = frequencies[i].Y;
            //        var exp = (value * value * value * value * value);
            //        var s = i % 2 == 0 ? 1 : -1;
            //        var tx = (i) * Step;
            //        var ty = (exp * exp * exp) * 10 * exponent/* * s*/;
            //        //ty = (i > 1 ? (ty + freqPoints[i - 1].size.Y + freqPoints[i - 2].size.Y) / 3 : ty)*1.3f;

            //        var mx = (1 - (float)Abs(tx - mp.X) * 4 / 60);
            //        var my = (1 - (float)Abs(HorizontalOffset - mp.Y) * 4 / 240).Clamp(0, 1);
            //        var c = LerpCol(LerpCol(SpectrumLowColor, LerpCol(SpectrumMidColor, SpectrumHighColor, (exp / (5 / exponent))), (exp / (10 / exponent))), Color.Red, mx * my);

            //        freqPoints[i].point = new PointF(Step / 1 + tx, HorizontalOffset + ty * (ty * 0.02f));
            //        freqPoints[i].size = new PointF(tx, HorizontalOffset + -ty * 0.5f);
            //        freqPoints[i].col = c;

            //    }
            //}

            //wfb.Color = Color.FromArgb(((int)((1 - (float)Math.Abs(Spectrum.HorizontalOffset - mp.Y) * 4 / Spectrum.HorizontalOffset) * 255)).Clamp(0, 255), 205, 205, 205);
            ////wfb.Color = Color.FromArgb(100, 255, 255, 255);
            //e.Graphics.DrawString($"{((float)mp.X / mm.canvas1.Width) * 5600:0} Hz", freqFont, wfb, mp.X - 55 * (float)mp.X / mm.canvas1.Width, Spectrum.HorizontalOffset);

            sw.Stop();
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
                for (int i = 1; i < hostControl.Width; i++)
                {

                    wfp.Color = freqPoints[i].col;
                    wfb.Color = freqPoints[i].col;
                    g.DrawLine(wfp, freqPoints[i].point.X, freqPoints[i].point.Y, freqPoints[i - 1].point.X, freqPoints[i - 1].point.Y);
                    //g.DrawLine(wfp, freqPoints[i].point.X, freqPoints[i].point.Y, freqPoints[i].point.X, HorizontalOffset + freqPoints[i].size.Y);
                    g.FillRectangle(wfb, freqPoints[i].point.X, freqPoints[i].point.Y, Step - 1, freqPoints[i].size.Y);
                    //g.DrawLine(wfp, freqPoints[i].point.X + 1, HorizontalOffset, (freqPoints[i].point.X + 1) + ((i - 150f) * 0.6f), HorizontalOffset + freqPoints[i].size.Y * 0.3f);
                    //g.DrawImage(img, freqPoints[i].point.X, freqPoints[i].point.Y, Step - 1, (int)freqPoints[i].size.Y);
                    //g.DrawImage(img, freqPoints[i].point.X, freqPoints[i].point.Y, Step - 1, (int)freqPoints[i].size.Y);
                    //wfb.Color = freqPoints[100].col;
                    //g.FillClosedCurve(wfb, freqPoints.Select(p => p.point).ToArray());
                }
            }
        }

        XNA.Vector2 cent;
        public static float texFactor { get; set; } = 0.25f;
        public static int numSamples { get; set; } = 450;
        public static float Exposure { get; set; } = 0.0110f;
        public static float Decay { get; set; } = 0.9925f;
        public static float Density { get; set; } = 1.036f;
        public static float Weight { get; set; } = 0.691f;

        public void DrawSpectrum(XNAG.SpriteBatch g, XNAG.RenderTarget2D main, XNAG.RenderTarget2D rays, XNAG.RenderTarget2D buf1, XNAG.Effect e, XNAG.Effect emitter)
        {
            //SendMessageTimeout(progman,
            //           0x052C,
            //           new IntPtr(0),
            //           IntPtr.Zero,
            //           W32.SendMessageTimeoutFlags.SMTO_NORMAL,
            //           1000,
            //           out result);
            //Point pt = Cursor.Position;
            //using (var gr = Graphics.FromHdc(hdc))
            //{
            //    gr.CompositingMode = CompositingMode.SourceOver;
            //    gr.DrawEllipse(Pens.Black, pt.X - 10, pt.Y - 10, 20, 20);
            //}

            if (freqPoints != null)
            {
                var pos = new XNA.Vector2(0, 50);

                var vp = g.GraphicsDevice.Viewport;
                g.GraphicsDevice.SetRenderTarget(main);
                g.GraphicsDevice.Clear(XNAG.ClearOptions.Target, new XNA.Vector4(0f, 0f, 0f, 0f), 1, 0);
                g.Begin(XNAG.SpriteSortMode.Immediate, XNAG.BlendState.AlphaBlend);
                for (int i = 1; i < (hostControl ?? monohostControl).Width/* * (Mode == DrawingMode.Freq ? 2 : 1)*/; i++)
                {

                    //wfp.Color = freqPoints[i].col;
                    var col = freqPoints[i].col.ToXNA();
                    g.DrawLine(new XNA.Vector2(freqPoints[i].point.X, freqPoints[i].point.Y), new XNA.Vector2(freqPoints[i - 1].point.X, freqPoints[i - 1].point.Y), col);
                    //g.DrawFill(pos + new XNA.Vector2(freqPoints[i].point.X, freqPoints[i].point.Y), new XNA.Vector2(Step, freqPoints[i].size.Y), freqPoints[i].col.ToXNA());

                }
                //g.DrawString();
                g.End();

                g.GraphicsDevice.SetRenderTarget(null);

                //var emitpos = new XNA.Vector2(mousepos.X + 20, mousepos.Y + 20);
                var emit = new XNA.Rectangle(new XNA.Vector2(0, HorizontalOffset - 70 / 2).ToPoint(), new XNA.Vector2(MonoHost.Size.Width, 70).ToPoint());
                var ec = MonoHost.EmitColor;

                g.GraphicsDevice.SetRenderTarget(buf1);
                {
                    g.GraphicsDevice.Clear(XNAG.ClearOptions.Target, new XNA.Vector4(0f, 0f, 0f, 0f), 1.0f, 0);
                    g.Begin(XNAG.SpriteSortMode.Immediate, XNAG.BlendState.AlphaBlend/*, effect: e*/);

                    g.Draw(main, new XNA.Vector2(), XNA.Color.White);
                    //g.DrawFill(emit, ec);

                    //g.Draw(main, XNA.Vector2.Zero, XNA.Color.Black);
                    g.End();
                }
                g.GraphicsDevice.SetRenderTarget(null);

                //var lloc = (emit.Location.ToVector2() + emit.Size.ToVector2() / 2) / vp.Bounds.Size.ToVector2();
                //var lloc = (cent * vp.Bounds.Size.ToVector2().X) / vp.Bounds.Size.ToVector2();

                g.GraphicsDevice.SetRenderTarget(rays);
                //g.GraphicsDevice.Clear(XNAG.ClearOptions.DepthBuffer, XNA.Vector4.Zero, 1, 0);
                emitter.Parameters["gScreenLightPos"].SetValue(cent);
                emitter.Parameters["gDensity"].SetValue(Density + (monohostControl.Peak) * 0.1f);
                emitter.Parameters["gDecay"].SetValue(Decay);
                emitter.Parameters["gWeight"].SetValue(Weight);
                emitter.Parameters["gExposure"].SetValue(Exposure * 8 * (monohostControl.Peak / 2) * .5f);
                emitter.Parameters["NUM_SAMPLES"].SetValue(numSamples);

                g.Begin(XNAG.SpriteSortMode.Deferred, XNAG.BlendState.AlphaBlend, XNAG.SamplerState.AnisotropicClamp, null, null, emitter);
                g.Draw(buf1, XNA.Vector2.Zero, XNA.Color.White);
                g.End();

                g.GraphicsDevice.SetRenderTarget(null);

                g.Begin(/*effect: e*/);
                //g.DrawFill(emit, ec);
                g.Draw(main, XNA.Vector2.Zero, XNA.Color.White);
                //g.Draw(buf1, XNA.Vector2.Zero, XNA.Color.White * .5f);
                g.End();

                g.Begin(XNAG.SpriteSortMode.Deferred, XNAG.BlendState.Additive);
                g.Draw(rays, new XNA.Vector2());
                //g.Draw(main,  new XNA.Vector2(0, HorizontalOffset / 2), null, XNA.Color.White * .5f, 0, XNA.Vector2.Zero, new XNA.Vector2(1, .5f), XNAG.SpriteEffects.FlipVertically, 1);
                g.End();

            }
        }

    }
}