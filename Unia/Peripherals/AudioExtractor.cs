using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Input;
using System.Net.NetworkInformation;
using System.Net;
using System.IO;
using static System.Text.RegularExpressions.Regex;

//Attribution:
//This is a derivative work done with:
//
//https://github.com/FFmpeg/FFmpeg
//https://github.com/ytdl-org/youtube-dl
//https://gist.github.com/umidjons/8a15ba3813039626553929458e3ad1fc
//
//Some pieces of code may be licensed under their respective licenses

namespace UniaCore.Peripherals
{
    public partial class YDLBridge : Form
    {
        public YDLBridge()
        {
            TopMost = true;
            InitializeComponent();
            fileSystemWatcher1.Path = folderBrowserDialog1.SelectedPath = textBoxOut.Text = Properties.Settings.Default.convout;
            grayRichTexBox1.Editor.TextChanged += Editor_TextChanged;
        }

        private void Editor_TextChanged(object sender, EventArgs e)
        {
            grayRichTexBox1.Editor.SelectionStart = grayRichTexBox1.Editor.Text.Length;
            grayRichTexBox1.Editor.ScrollToCaret();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                fileSystemWatcher1.Path =
                Properties.Settings.Default.convout =
                textBoxOut.Text = folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        static StreamReader dl_stdout;
        static ProcessStartInfo dlStartInfo = new ProcessStartInfo(@"Evals\youtube-dl.exe")
        {
            WindowStyle = ProcessWindowStyle.Hidden,
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true,
            Verb = "runas",
        };

        static ProcessStartInfo ffmpegStartInfo = new ProcessStartInfo(@"Evals\ffmpeg.exe")
        {
            WindowStyle = ProcessWindowStyle.Hidden,
            UseShellExecute = true,
            RedirectStandardOutput = false,
            Verb = "runas"
        };

        static Process dlProcess, ffmpegProcess;

        private void grayButton1_Click(object sender, EventArgs e)
        {
            var wid = Match(textBoxWID.Text, "(?<=(v=)).{11}").Value;
            dlStartInfo.Arguments = $" -o {Properties.Settings.Default.convout}\\%(title)s.%(ext)s -i -x --audio-format mp3 --audio-quality 0 --hls-prefer-ffmpeg {wid}";

            dlProcess = Process.Start(dlStartInfo);
            dl_stdout = dlProcess.StandardOutput;

            //dlProcess.OutputDataReceived += DlProcess_OutputDataReceived;
            //dlProcess.ErrorDataReceived += DlProcess_OutputDataReceived;
            //dlProcess.BeginOutputReadLine();
            BeginOutputRead();
        }

        void BeginOutputRead()
        {
            Task.Run(() =>
            {
                var lc = 0;
                while (!dlProcess.HasExited)
                {
                    var data = dl_stdout.ReadLine();
                    //var s = data.Split('\u000A', '\u000D');
                    //var c = s.Length;
                    //if (lc > c)
                    //{
                    //    lc = c;
                    //    var ndata = s[lc];
                    //}
                    DlProcess_OutputDataReceived(null, new DataReceivedEventArgs(data));
                }
            });
        }

        class DataReceivedEventArgs : EventArgs
        {
            public DataReceivedEventArgs(string d) => Data = d;
            public string Data { private set; get; }
        }

        private delegate void FloatCallDelegate(float v);
        private delegate void StringCallDelegate(string v);

        private void DlProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (grayProgressBar1.InvokeRequired)
            {
                var d = new StringCallDelegate(UpdateOutputLog);
                Invoke(d, new object[] { e.Data });
            }

            if (!string.IsNullOrEmpty(e.Data) && IsMatch(e.Data, @"\[download\].+\d.\d%{1}"))
            {
                var s = Match(e.Data, @"(?<=(\[download\]) +).+(?=%)").Value.Replace('.', ',');
                try
                {

                    var val = (float)double.Parse(s);
                    if (grayProgressBar1.InvokeRequired)
                    {
                        var d = new FloatCallDelegate(UpdateProgress);
                        Invoke(d, new object[] { val });
                    }
                    else
                    {

                        UpdateProgress(val);
                    }
                }
                catch
                {

                }
            }
        }

        void UpdateOutputLog(string text)
        {
            grayRichTexBox1.Text += text + "\n";
        }

        private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {

        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {

        }

        void UpdateProgress(float v)
        {
            grayProgressBar1.SetProgress(v / 100);
            if (v == 1)
            {

            }
        }
    }
}
