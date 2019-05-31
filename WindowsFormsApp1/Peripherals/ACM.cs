using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading;
using System.Net;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    public partial class ACM : Form
    {

        public ACM()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            refact.Interval = 100;
            refact.Tick += Refact_Tick;
        }

        private static List<PortInfo> GetOpenPort()
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] tcpEndPoints = properties.GetActiveTcpListeners();
            TcpConnectionInformation[] tcpConnections = properties.GetActiveTcpConnections();
            
            return tcpConnections.Select(p =>
            {
                return new PortInfo(p.LocalEndPoint.Port,
                    String.Format("{0}:{1}", p.LocalEndPoint.Address, p.LocalEndPoint.Port),
                    String.Format("{0}:{1}", p.RemoteEndPoint.Address, p.RemoteEndPoint.Port),
                    p.State.ToString(),
                    "Undefined"
                        );
            }).ToList();
        }

        class PortInfo
        {
            public int PortNumber { get; set; }
            public string Local { get; set; }
            public string Remote { get; set; }
            public string State { get; set; }
            public string Name { get; set; }

            public PortInfo(int i, string local, string remote, string state, string name)
            {
                PortNumber = i;
                Local = local;
                Remote = remote;
                State = state;
                Name = name;
            }
        }

        private void Form3_Shown(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            RefreshAC();
            dataGridView1.RowHeadersVisible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Process.Start(@"cmd.exe", @" @echo off " + dataGridView1.SelectedCells[0].Value);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                var val = dataGridView1.SelectedCells[0].Value;
                if (checkBox1.Checked)
                    Clipboard.SetText(((string)val).Remove(((string)val).LastIndexOf(":"), ((string)val).Length - ((string)val).LastIndexOf(":")));
                label1.Text = ((string)val).Remove(((string)val).LastIndexOf(":"), ((string)val).Length - ((string)val).LastIndexOf(":"));
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            RefreshAC();
        }

        void RefreshAC()
        {
            int row = 0;
            var Ports = GetOpenPort();
            dataGridView1.RowCount = Ports.Count;
            dataGridView1[0, 0].Value = new object();
            foreach (var node in Ports)
            {
                {
                    dataGridView1[0, row].Value = "" + node.PortNumber;
                    dataGridView1[1, row].Value = "" + node.Local;
                    dataGridView1[2, row].Value = "" + node.Remote;
                    dataGridView1[3, row].Value = "" + node.State;
                    dataGridView1[4, row].Value = "" + node.Name;
                }
                row++;
            }
            label2.Text = ("Total: " + Ports.Count);

            // Network Utilization (in Bytes/Sec)
            PerformanceCounterCategory category =
                new PerformanceCounterCategory("Network Interface");
            String[] instanceName = category.GetInstanceNames();
            row = 0;
            foreach (string ns in instanceName)
            {
                PerformanceCounter netSentCounter = new PerformanceCounter("Network Interface", "Bytes Received/sec", ns);
                PerformanceCounter netRecCounter = new PerformanceCounter("Network Interface", "Bytes Sent/sec", ns);
                Console.WriteLine("Network Interface: {0}", ns);
                Console.WriteLine("Network Usage (Sent): {0}",
                    netSentCounter.NextValue() + " Bytes/s");
                Console.WriteLine("Network Usage (Received): {0}",
                    netRecCounter.NextValue() + " Bytes/s");
                dataGridView1[4, row].Value = "" + netSentCounter.NextValue();
                row++;
            }
            var props = IPGlobalProperties.GetIPGlobalProperties();
            //var cons = new IPInterfaceProperties().GetIPv4Properties.;
        }


        System.Windows.Forms.Timer refact = new System.Windows.Forms.Timer();
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                refact.Start();
            else refact.Stop();
        }

        private void Refact_Tick(object sender, EventArgs e)
        {
            RefreshAC();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0 && dataGridView1.SelectedCells[0].ColumnIndex == 2)
            {
                var val = dataGridView1.SelectedCells[0].Value;
                System.Diagnostics.Process.Start("http://" + ((string)val).Remove(((string)val).LastIndexOf(":"), ((string)val).Length - ((string)val).LastIndexOf(":")) + "/");
            }

        }
    }
}
