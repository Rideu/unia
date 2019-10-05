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
using NAudio;
using NAudio.Wave;
using NAudio.Dsp;
using NAudio.Wave.SampleProviders;
using NAudio.CoreAudioApi;
using static UniaCore.Helper;

// Refs:
// — https://stackoverflow.com/questions/18813112

namespace UniaCore
{

    public partial class MainWindow
    {
        static WasapiLoopbackCapture _capture;
        static WaveInProvider wip;
        static WaveFloatTo16Provider to16p;
        static SampleAggregator sampleAggregator;


        static WaveFormat wf = new WaveFormat(44100, 2);
        static MemoryStream ams = new MemoryStream();
        static RawSourceWaveStream r;
        //static WaveIn waveIn;
        static WaveOut wout;
        static WaveBuffer wb = new WaveBuffer(0);



        public void InitSpectrum()
        {

            _capture = new WasapiLoopbackCapture();

            //wip = new WaveInProvider(_capture);
            //to16p = new WaveFloatTo16Provider(wip);

            sampleAggregator = new SampleAggregator(8192 / 4);
            sampleAggregator.FftCalculated += new EventHandler<FftEventArgs>(FftCalculated);
            sampleAggregator.PerformFFT = true;


            //waveIn = new WaveIn() { WaveFormat = new WaveFormat(44100, 2), };

            _capture.DataAvailable += OnDataAvailable;

            //_capture.DataAvailable += delegate (object sender, WaveInEventArgs e)
            //{

            //    //byte[] buffer = e.Buffer;
            //    //int bytesRecorded = e.BytesRecorded;
            //    //int bufferIncrement = waveIn.WaveFormat.BlockAlign;

            //    //for (int index = 0; index < bytesRecorded; index += bufferIncrement)
            //    //{
            //    //    float sample32 = BitConverter.ToSingle(buffer, index);
            //    //    sampleAggregator.Add(sample32);
            //    //}
            //    //byte[] b = new byte[e.BytesRecorded];
            //    //var l = to16p.Read(b, 0, e.BytesRecorded);
            //    //ams.Position = 0;
            //    //ams.Write(e.Buffer, 0, e.BytesRecorded);
            //    byteBuffer = e.Buffer;
            //};

            //r = new RawSourceWaveStream(ams, _capture.WaveFormat);
            img = new Bitmap(1, 3);
            //img.SetPixel(0, 0, Color.FromArgb(57, 18, 3));
            //img.SetPixel(0, 1, Color.OrangeRed);
            //img.SetPixel(0, 2, Color.Yellow);
            img.SetPixel(0, 0, Color.FromArgb(96, 128, 255));
            img.SetPixel(0, 1, Color.FromArgb(32, 64, 96));
            img.SetPixel(0, 2, Color.FromArgb(40, 80, 160));
            _capture.StartRecording();
            //waveIn.StartRecording();
        }
        static int step = 50;
        static int awfl = 800 / step;

        volatile static float[] nawf = new float[awfl], oawf0 = new float[awfl], oawf1 = new float[awfl];

        float median = 0;
        void FftCalculated(object sender, FftEventArgs e)
        {

            spectrum.Evaluate(e.Result, mm.vertScrollWavefactor.Value, mm.canvas1.PointToClient(MousePosition));
            //spectrum.DrawSpectrum(cg);
        }

        volatile static byte[] byteBuffer;

        void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EventHandler<WaveInEventArgs>(OnDataAvailable), sender, e);
            }
            else
            {
                byteBuffer = e.Buffer;
                int bytesRecorded = e.BytesRecorded;
                int bufferIncrement = _capture.WaveFormat.BlockAlign;

                for (int index = 0; index < bytesRecorded; index += bufferIncrement)
                {
                    float sample32 = BitConverter.ToSingle(byteBuffer, index);
                    sampleAggregator.Add(sample32);
                }
            }
        }

        static Pen wfp = new Pen(Color.Green)
        {
            Alignment = System.Drawing.Drawing2D.PenAlignment.Center,
            LineJoin = System.Drawing.Drawing2D.LineJoin.Round,
            Width = 1.6f
        };

        static SolidBrush wfb = new SolidBrush(Color.Green);
        static Color skyblue = Color.FromArgb(51, 153, 255);
        static Color green = Color.FromArgb(0, 255, 0);
        static Color red = Color.FromArgb(255, 0, 0);
        static Color purple = Color.FromArgb(255, 0, 0);


        static Font freqFont = new Font("Consolas", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);



        public static Spectrum spectrum = new Spectrum();
        //static Image img = Image.FromFile(@"C:\Users\Rideu\Desktop\render\skys1low.png");
        static Bitmap img;
        //static Graphics cg;
        public static void MainSpectrum()
        {
            //cg = Graphics.FromHwnd(mm.canvas1.Handle);
            spectrum.Host = mm.canvas1;
            mm.canvas1.Paint += delegate (object sender, PaintEventArgs e)
            {
                e.Graphics.DrawImage(img, 0, 0, mm.canvas1.Width, mm.canvas1.Height);
                e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                sw.Restart();
                var mp = mm.canvas1.PointToClient(MousePosition);
                var mpofs = mp;
                mpofs.Offset(-mm.canvas1.Width / 2, -mm.canvas1.Height / 2);
                spectrum.DrawSpectrum(e.Graphics);

                wfb.Color = Color.FromArgb(((int)((1 - (float)Math.Abs(Spectrum.HorizontalOffset - mp.Y) * 4 / Spectrum.HorizontalOffset) * 255)).Clamp(0, 255), 205, 205, 205);
                //wfb.Color = Color.FromArgb(100, 255, 255, 255);
                e.Graphics.DrawString($"{((float)mp.X / mm.canvas1.Width) * 5600:0} Hz", freqFont, wfb, mp.X - 55 * (float)mp.X / mm.canvas1.Width, Spectrum.HorizontalOffset);

                //);
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
            };
        }

        public static void UpdateSpectrum()
        {
            //await Task.Run(() =>
            {

                //padpv = pad.AudioMeterInformation.PeakValues[0];

                //oawf = nawf;
                //nawf = new float[awfl = (mm.canvas1.Width)];
                //oawf = nawf.Length != oawf.Length ? nawf : oawf;
                try
                {
                    //if (byteBuffer == null) return;
                    //byte[] buffer = byteBuffer;
                    //int bytesRecorded = buffer.Length;
                    //int bufferIncrement = _capture.WaveFormat.BlockAlign;

                    //for (int index = 0; index < bytesRecorded; index += bufferIncrement)
                    //{
                    //    float sample32 = BitConverter.ToSingle(buffer, index);
                    //    sampleAggregator.Add(sample32);
                    //}
                    //byteBuffer = null;
                    //NAudio visualiser
                    //var s = new WdlResamplingSampleProvider(r.ToSampleProvider(), 44100);

                    //SampleToWaveProvider16 pcma = new SampleToWaveProvider16(r.ToSampleProvider());

                    //r.Position = 0L;
                    //var samplesPerPixel = 2;
                    //var bytesPerSample = 4 / 4 * 2;
                    //var startPosition = 0;
                    //byte[] array = new byte[samplesPerPixel * bytesPerSample];
                    //r.Position = startPosition + mm.canvas1.ClientRectangle.Left * bytesPerSample * samplesPerPixel;
                    //wb.BindTo(array);

                    //for (float num = 0; num < awfl; num += 1)
                    //{
                    //    short num2 = 0;
                    //    int num4 = r.Read(array, 0, samplesPerPixel * bytesPerSample);
                    //    //for (int i = 0; i < num4; i += 2)
                    //    var hw = 1;// (float)FastFourierTransform.HannWindow((int)num, num4);
                    //    float num5 = (BitConverter.ToInt16(array, 0) + 32768f) / 65535f;

                    //    nawf[(int)num] = (num5 * 2.0f * (hw) + oawf[(int)num]) / 2f;
                    //}

                }
                catch
                {
                    //nawf = oawf0;
                }
            }
            //);
        }

        public static void ExitSpectrum()
        {
            _capture.Dispose();
        }

        #region Utils

        private float[] ConvertByteToFloat(byte[] array, int length)
        {
            int samplesNeeded = length / 4;
            float[] floatArr = new float[samplesNeeded];

            for (int i = 0; i < samplesNeeded; i++)
            {
                floatArr[i] = BitConverter.ToSingle(array, i * 4);
            }

            return floatArr;
        }
        #endregion
    }
}
