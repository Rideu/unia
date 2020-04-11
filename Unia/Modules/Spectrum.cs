using NAudio.CoreAudioApi;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using NAudio;
using NAudio.Dsp;

using System;
using System.Diagnostics;
using System.Drawing;

using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using static UniaCore.Helper;


namespace UniaCore
{

    public partial class MainWindow
    {
        static IWaveIn _capture;
        static WaveInProvider wip;
        static IWaveProvider to16p;
        static SampleAggregator sampleAggregator;
        static MMDevice pad;


        static WaveFormat wf = new WaveFormat(44100, 2);
        static MemoryStream ams = new MemoryStream();
        static RawSourceWaveStream r;
        static WaveOut wout;
        static WaveBuffer wb = new WaveBuffer(0);



        public void InitSpectrum()
        {
            pad = new MMDeviceEnumerator().GetDefaultAudioEndpoint(DataFlow.Render, Role.Communications);
            _capture = new WasapiLoopbackCapture();

            //wip = new WaveInProvider(_capture);
            //to16p = new WaveFloatTo16Provider(wip);

            sampleAggregator = new SampleAggregator(8192 / 4);
            sampleAggregator.FftCalculated += new EventHandler<FftEventArgs>(FftCalculated);
            sampleAggregator.PerformFFT = true;

            r = new RawSourceWaveStream(new byte[19200], 0, 19200, wf);
            //waveIn = new WaveIn() { WaveFormat = new WaveFormat(44100, 2), };

            _capture.DataAvailable += OnDataAvailable;

            _capture.DataAvailable += delegate (object sender, WaveInEventArgs e)
            {
                byte[] b = new byte[e.BytesRecorded];
                //var l = to16p.Read(b, 0, e.BytesRecorded);

                r = new RawSourceWaveStream(e.Buffer, 0, e.BytesRecorded, wf);
                //r.Write(e.Buffer, 0, e.BytesRecorded);
                //byte[] buffer = e.Buffer;
                //int bytesRecorded = e.BytesRecorded;
                //int bufferIncrement = _capture.WaveFormat.BlockAlign;

                //for (int index = 0; index < bytesRecorded; index += bufferIncrement)
                //{
                //    float sample32 = BitConverter.ToSingle(buffer, index);
                //}
                //to16p.Read(b, 0, e.BytesRecorded);
                ams.Position = 0;
                ams.Write(b, 0, e.BytesRecorded);
                byteBuffer = e.Buffer;
            };

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

        void FftCalculated(object sender, FftEventArgs e)
        {
            if (Spectrum.Mode == Spectrum.DrawingMode.Spectrum)
                //spectrum.Evaluate(nawf, mm.vertScrollWavefactor.Value, mm.PointToClient(MousePosition));
                spectrum.Evaluate(e.Result, mm.vertScrollWavefactor.Value, mm.PointToClient(MousePosition));
            //else if(nawf != null)

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
                    //sampleAggregator.Add((float)Math.Pow(sample32 / 4, 3));
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

        static Bitmap img;

        public static void MainSpectrum()
        {
            //cg = Graphics.FromHwnd(mm.canvas1.Handle);
            //spectrum.Host = mm.canvas1;
            spectrum.MonoHost = mm.spectrumViewer1;
            awaiter.Restart();
        }

        static float
            backPeakLerp1,
            backPeakLerp2,
            newPeakLerp;

        static Complex[] oawf, nawf;
        static int awfl;

        static Stopwatch awaiter = new Stopwatch();

        public static void UpdateSpectrum()
        {
            //Task.Run(() =>
            //if (false)
            {
                oawf = nawf;
                nawf = new Complex[awfl = (mm.spectrumViewer1.Width * 1)];
                oawf = oawf == null || nawf.Length != oawf.Length ? nawf : oawf;
                if (awaiter.ElapsedMilliseconds >= 9)
                {
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
                        var s = new WdlResamplingSampleProvider(r.ToSampleProvider(), 44100);

                        SampleToWaveProvider16 pcma = new SampleToWaveProvider16(r.ToSampleProvider());

                        r.Position = 0L;
                        var samplesPerPixel = 2;
                        var bytesPerSample = 4 / 4 * 2;
                        var startPosition = 0;
                        byte[] array = new byte[samplesPerPixel * bytesPerSample];
                        r.Position = startPosition + mm.canvas1.ClientRectangle.Left * bytesPerSample * samplesPerPixel;
                        wb.BindTo(array);

                        for (float num = 0; num < awfl; num += 2)
                        {
                            //short num2 = 0;
                            //int num4 = r.Read(array, 0, samplesPerPixel * bytesPerSample);
                            ////for (int i = 0; i < num4; i += 2)
                            //var hw = 1;// (float)FastFourierTransform.HannWindow((int)num, num4);
                            //float num5 = (BitConverter.ToInt16(array, 0) + 32768f) / 65535f;
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
                            float num6 = ((float)num2 - -32768f) / 65535f;
                            float num7 = ((float)num3 - -32768f) / 65535f;
                            nawf[(int)num].Y = (num6 + num7 + oawf[(int)num].Y) / 2f;
                        }

                        if (Spectrum.Mode == Spectrum.DrawingMode.Freq)
                            spectrum.Evaluate(nawf, mm.vertScrollWavefactor.Value, mm.PointToClient(MousePosition));

                    }
                    catch
                    {
                        //nawf = oawf0;
                    }
                    awaiter.Restart();
                }
            }
            //);

            backPeakLerp2 = backPeakLerp1;
            backPeakLerp1 = newPeakLerp;
            newPeakLerp = pad.AudioMeterInformation.PeakValues[0];
            var mixed = (newPeakLerp + backPeakLerp1 + backPeakLerp2) / 3;
            mixed *= mixed * 2 * spectrum.Exponent;
            if (mm.checkBoxColoriseCanvas.Checked)
            {
                mm.spectrumViewer1.Peak = mixed;
                mm.spectrumViewer1.EmitColor = (mm.canvas1.BackColor = LerpCol(LerpCol(Spectrum.SpectrumMidColor, Spectrum.SpectrumLowColor, (mixed)), Spectrum.SpectrumHighColor, ((mixed) * 6))).ToXNA();
            }
            else if (mm.canvas1.BackColor != canvback)
            {
                mm.spectrumViewer1.BackColor = (mm.canvas1.BackColor = canvback)/*.ToXNA()*/;
            }

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
