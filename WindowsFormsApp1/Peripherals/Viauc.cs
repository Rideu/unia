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

//Attribution:
//This is a derivative work done with:
//
//https://github.com/FFmpeg/FFmpeg
//https://github.com/ytdl-org/youtube-dl
//
//Some pieces of code may be licensed under their respective licenses

namespace WindowsFormsApp1.Peripherals
{
    public partial class Viauc : Form
    {
        public Viauc()
        {
            TopMost = true;
            InitializeComponent();
            folderBrowserDialog1.SelectedPath = textBoxOut.Text = Properties.Settings.Default.convout;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.convout =
                textBoxOut.Text = folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        static ProcessStartInfo dlStartInfo = new ProcessStartInfo(@"Evals\youtube-dl.exe")
        {
            WindowStyle = ProcessWindowStyle.Hidden,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            Verb = "runas"

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
            dlStartInfo.Arguments = $"-o \"{textBoxOut.Text}\\{textBoxWID.Text}.mp4\" -f \"bestvideo[ext = mp4] + bestaudio[ext = m4a] / best[ext = mp4] / best\" -v {textBoxWID.Text}";

            dlProcess = Process.Start(dlStartInfo);
            dlProcess.OutputDataReceived += DlProcess_OutputDataReceived;
            dlProcess.ErrorDataReceived += DlProcess_OutputDataReceived;
            dlProcess.BeginOutputReadLine();
        }

        private void DlProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {

        }
    }
}
