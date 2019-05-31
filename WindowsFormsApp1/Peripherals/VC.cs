using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;


namespace WindowsFormsApp1
{
    public partial class VC : Form
    {
        public VC()
        {
            InitializeComponent();
        }

        private string GtDte()
        {
            return
                "[" +
                (DateTime.Now.Hour < 10 ? "0" + DateTime.Now.Hour : DateTime.Now.Hour + "") + ":" +
                (DateTime.Now.Minute < 10 ? "0" + DateTime.Now.Minute : DateTime.Now.Minute + "") + ":" +
                (DateTime.Now.Second < 10 ? "0" + DateTime.Now.Second : DateTime.Now.Second + "") +
                "] ";
        }

        private void LgSnd(string log)
        {
            textBox2.AppendText(GtDte() + log + "\n");
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            listen_timer.Tick += Listen_timer_Tick; ;
            listen_timer.Interval = 100;
            listen_timer.Start();
        }

        Socket ms = new Socket(ip_addr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        static IPHostEntry ip_host = Dns.GetHostEntry("localhost");
        static IPEndPoint ip_end = new IPEndPoint(ip_host.AddressList[0], 1111);
        static IPAddress ip_addr = ip_host.AddressList[0];

        private void Connect()
        {
            
            for (int i = 0; i < 2; i++)
            {
                try
                {
                    ms.Connect(ip_end);
                    ms.Send(Encoding.UTF8.GetBytes("Helo"));
                    lgbuff = ("[STATE_CNCTD]: " + ms.Connected + "");
                    backgroundWorker2.RunWorkerAsync();
                }
                catch (Exception e)
                {
                    lgbuff = ("[STATE_CATCH]: " + ms.Connected + " " + e.Message);
                }

            }
        }

        System.Windows.Forms.Timer listen_timer = new System.Windows.Forms.Timer();
        String lgbuff = "";
        private void Listen_timer_Tick(object sender, EventArgs e)
        {
            if (lgbuff.Length > 0)
                LgSnd(lgbuff + "");
            lgbuff = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
            else
                lgbuff = "[CON_ACTIVE]";
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!ms.Connected)
                Connect();
            else backgroundWorker1.CancelAsync();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ms != null)
            if(textBox1.TextLength > 0 && ms.Connected)
            {
                ms.Send(Encoding.UTF8.GetBytes(textBox1.Text));
                lgbuff = " >> " + textBox1.Text;
            }
            else
            {
                if (!ms.Connected)
                    lgbuff = "No connections available";
                if (textBox1.TextLength == 0)
                    lgbuff += "Empty message";
            }
            else
                lgbuff = "No connections available";
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (ms.Connected)
                {
                    ms.Listen(1);
                    ms = ms.Accept();

                    string data = Encoding.UTF8.GetString(new byte[1024], 0, ms.Receive(new byte[1024]));

                    lgbuff = " < " + data;
                }
            }
            catch
            {
                backgroundWorker2.CancelAsync();
            }
        }
    }
}
