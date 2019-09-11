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
using static UniaCore.Properties.Settings;

public class Spectrum
{

    struct FreqPoint
    {
        public Color col;
        public PointF point;
    }

    public static Color SpectrumLowColor = Default.salc;
    public static Color SpectrumMidColor = Default.samc;
    public static Color SpectrumHighColor = Default.sahc;

    int hofs = 150; int step = 3;

    public enum SpectrumStyle
    {
        Blocks,
        Lines
    }

    public Spectrum()
    {

    }


    static Pen wfp = new Pen(Color.Green)
    {
        Alignment = System.Drawing.Drawing2D.PenAlignment.Center,
        LineJoin = System.Drawing.Drawing2D.LineJoin.Round,
        Width = 1.6f
    };

    static SolidBrush wfb = new SolidBrush(Color.Green);

    //public Func<float, float> freqFunc = new Func<float, float>((f) => { return 1; });

    FreqPoint[] freqPoints;

    public void Evaluate(float[] frequencies, float exponent)
    {
        freqPoints = new FreqPoint[frequencies.Length];
        freqPoints[0].point = new PointF(0, hofs);

        for (int i = 0; i < frequencies.Length; i++)
        {
            var v = frequencies[i];
            var exp = (float)Math.Pow(v, 1 + exponent * 1);
            var c = LerpCol(SpectrumLowColor, LerpCol(SpectrumMidColor, SpectrumHighColor, (exp / 40)), (exp / 40));
            //var c = LerpCol(SpectrumLowColor, SpectrumMidColor, (exp / 40));

            //wfb.Color = c;
            //wfp.Color = c;
            var tx = i * step;
            var s = i % 2 == 0 ? 1 : -1;
            //var ty = hofs - ((exp / hofs).Amplify(4, 10f) + 0.0f).Clamp(0, 1) * 190;
            var ty = hofs - ((exp / hofs).Amplify(4, 10f) + 0.0f).Clamp(0, 1) * 190 * s;

            freqPoints[i].point = new PointF(tx, ty);
            freqPoints[i].col = c;
        }
    }

    public void DrawSpectrum(Graphics g)
    {
        if (freqPoints != null)
            for (int i = 1; i < freqPoints.Length; i++)
            {
                wfp.Color = freqPoints[i].col;
                g.DrawLine(wfp, freqPoints[i].point.X, freqPoints[i].point.Y, freqPoints[i - 1].point.X, freqPoints[i - 1].point.Y);
            }
    }
}
