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

namespace UniaCore
{
    public partial class MainWindow
    {
        WasapiLoopbackCapture _capture;
        static WaveFormat wf = new WaveFormat(44100, 2);
        static MemoryStream ams = new MemoryStream();
        static RawSourceWaveStream r = new RawSourceWaveStream(ams, wf);
        static WaveIn waveIn;
        static WaveOut wout;
        static WaveBuffer wb = new WaveBuffer(0);

        static int awfl = 100;
        volatile static float[] nawf = new float[400], oawf = new float[400];

        public void InitSpectrum()
        {

            _capture = new WasapiLoopbackCapture();


            waveIn = new WaveIn() { WaveFormat = new WaveFormat(44100, 2), };

            waveIn.DataAvailable += delegate (object sender, WaveInEventArgs e)
            {
                ams.Position = 0;
                ams.Write(e.Buffer, 0, e.Buffer.Length);
            };

            this._capture.StartRecording();
            waveIn.StartRecording();
        }

        public static void MainSpectrum()
        {

            var hofs = 150;
            mm.canvas1.Paint += delegate (object sender, PaintEventArgs e)
            {
                sw.Restart();
                var mp = mm.canvas1.PointToClient(MousePosition);
                mp.Offset(-mm.canvas1.Width / 2, -mm.canvas1.Height / 2);
                //e.Graphics.Clear(mm.canvas1.BackColor);
                PointF foline = new PointF();
                for (int i = 0; i < awfl; i++)
                {
                    var v = nawf[i];
                    var exp = (float)Math.Pow(v, 1 + mm.vertScrollWavefactor.Value * 30);
                    var c = LerpCol(salc, LerpCol(samc, sahc, (float)Math.Sin(exp)), (float)Math.Cos(exp));
                    lock (e.Graphics)
                    {
                        wfp.Color = c;
                        //e.Graphics.DrawLine(wfp, i, exp * 77, i, exp * exp * 71);
                        //e.Graphics.DrawLine(wfp, i, 200, i, 200 - exp * 20);
                        //e.Graphics.DrawLine(wfp, i, 100 - exp * 20, i, 100 + exp * 20);
                        e.Graphics.DrawLine(wfp, i, hofs, i, hofs - exp * 20);
                        ////wfp.Color = LerpCol(salc, LerpCol(samc, sahc, (float)Math.Sin(exp)), (float)Math.Cos(exp));
                        var tx = i + exp * (i - mm.Width / 2 + mp.X / 10) * 0.5f;
                        var ty = hofs - exp * 80 + mp.Y / 20;
                        wfp.Color = AlphaAmount(wfp.Color, 0.2f);
                        e.Graphics.DrawLine(wfp, i, hofs, tx, hofs + exp * 20 + mp.Y / 20);
                        e.Graphics.DrawLine(wfp, i, hofs - exp * 20, tx, ty);
                        e.Graphics.DrawLine(wfp, foline.X, foline.Y, tx, ty);
                        foline = new PointF(tx, ty);
                    }
                }
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
                    var startPosition = 8000;
                    byte[] array = new byte[samplesPerPixel * bytesPerSample];
                    r.Position = startPosition + mm.canvas1.ClientRectangle.Left * bytesPerSample * samplesPerPixel;
                    wb.BindTo(array);

                    for (float num = mm.canvas1.ClientRectangle.X; num < mm.canvas1.ClientRectangle.Right; num += 1)
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
                        float num6 = (num2 + 32768f) / 65535f;
                        float num7 = (num3 + 32768f) / 65535f;
                        nawf[(int)num] = (num6 + num7 + oawf[(int)num]) / 2f;
                    }

                }
                catch
                {
                    nawf = oawf;
                }
            }
            //);
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
