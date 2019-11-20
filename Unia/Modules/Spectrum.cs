using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static UniaCore.Helper;


namespace UniaCore
{

    public partial class MainWindow
    {
        static IWaveIn _capture;
        static WaveInProvider wip;
        static WaveFloatTo16Provider to16p;
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

            wip = new WaveInProvider(_capture);
            to16p = new WaveFloatTo16Provider(wip);

            sampleAggregator = new SampleAggregator(8192 / 4);
            sampleAggregator.FftCalculated += new EventHandler<FftEventArgs>(FftCalculated);
            sampleAggregator.PerformFFT = true;


            //waveIn = new WaveIn() { WaveFormat = new WaveFormat(44100, 2), };

            _capture.DataAvailable += OnDataAvailable;

            _capture.DataAvailable += delegate (object sender, WaveInEventArgs e)
            {

                byte[] buffer = e.Buffer;
                int bytesRecorded = e.BytesRecorded;
                int bufferIncrement = _capture.WaveFormat.BlockAlign;

                for (int index = 0; index < bytesRecorded; index += bufferIncrement)
                {
                    float sample32 = BitConverter.ToSingle(buffer, index);
                }
                byte[] b = new byte[e.BytesRecorded];
                var l = to16p.Read(b, 0, e.BytesRecorded);
                ams.Position = 0;
                ams.Write(e.Buffer, 0, e.BytesRecorded);
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
            spectrum.Evaluate(e.Result, mm.vertScrollWavefactor.Value, mm.PointToClient(MousePosition));
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

        static Bitmap img;

        public static void MainSpectrum()
        {
            //cg = Graphics.FromHwnd(mm.canvas1.Handle);
            //spectrum.Host = mm.canvas1;
            spectrum.MonoHost = mm.spectrumViewer1;

            //mm.canvas1.Paint += delegate (object sender, PaintEventArgs e)
            //{
            //    e.Graphics.DrawImage(img, 0, 0, mm.canvas1.Width, mm.canvas1.Height);
            //    e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            //    e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
            //    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //    sw.Restart();
            //    var mp = mm.canvas1.PointToClient(MousePosition);
            //    var mpofs = mp;
            //    mpofs.Offset(-mm.canvas1.Width / 2, -mm.canvas1.Height / 2);
            //    spectrum.DrawSpectrum(e.Graphics);

            //    wfb.Color = Color.FromArgb(((int)((1 - (float)Math.Abs(Spectrum.HorizontalOffset - mp.Y) * 4 / Spectrum.HorizontalOffset) * 255)).Clamp(0, 255), 205, 205, 205);
            //    //wfb.Color = Color.FromArgb(100, 255, 255, 255);
            //    e.Graphics.DrawString($"{((float)mp.X / mm.canvas1.Width) * 5600:0} Hz", freqFont, wfb, mp.X - 55 * (float)mp.X / mm.canvas1.Width, Spectrum.HorizontalOffset);

            //    //);
            //    sw.Stop();
            //    //Console.WriteLine(sw.ElapsedMilliseconds);
            //};
        }

        public static void UpdateSpectrum()
        {
            //await Task.Run(() =>
            {


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
                mm.spectrumViewer1.BackColor = (mm.canvas1.BackColor = canvback).ToXNA();
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
