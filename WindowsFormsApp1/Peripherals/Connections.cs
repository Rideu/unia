using System;
using System.Collections.Generic;
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

namespace UniaCore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        Socket mr;

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
            textBox2.AppendText(GtDte()+log+"\n");
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            LgSnd("ms socket ignited and ready.");
            listen_timer.Tick += Listen_timer_Tick; ;
            listen_timer.Interval = 100;
            listen_timer.Start();
            f3.Shown += F3_Shown;
            f3.FormClosed += F3_FormClosed;

            f2.Shown += F2_Shown;
            f2.FormClosed += F2_FormClosed;
            //client.Show();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            {
                SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                UpdateStyles();
                BackColor = Color.Transparent;
            }

        }

        bool f2state;

        private void F2_FormClosed(object sender, FormClosedEventArgs e)
        {
            f2state = false;
            f2 = new VC();
            f2.FormClosed += F3_FormClosed;
            f2.Shown += F3_Shown;
        }

        private void F2_Shown(object sender, EventArgs e)
        {
            f2state = true;
        }

        private void Listen_timer_Tick(object sender, EventArgs e)
        {
            if(lgbuff.Length > 0)
            LgSnd(lgbuff + "");
            lgbuff = "";
        }

        bool f3state;

        private void F3_FormClosed(object sender, FormClosedEventArgs e)
        {
            f3state = false;
            f3 = new ACM();
            f3.FormClosed += F3_FormClosed;
            f3.Shown += F3_Shown;
        }

        private void F3_Shown(object sender, EventArgs e)
        {
            f3state = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(!backgroundWorker1.IsBusy)
            backgroundWorker1.RunWorkerAsync();
            else
            {
                LgSnd("Receiver is already working.");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                mr.Close();
                backgroundWorker1.CancelAsync();
            } catch
            {
                lgbuff = ("[RECV_TERM_CATCH]");
            }
            if (!backgroundWorker1.IsBusy)
                lgbuff = "Receiver isn't launched";
        }

        void Receiver()
        {

        }
        
        
        System.Windows.Forms.Timer listen_timer = new System.Windows.Forms.Timer();
        TimeSpan ltts = new TimeSpan(0, 0, 0, 0, 1000);

        static IPHostEntry ip_host = Dns.GetHostEntry("localhost");
        IPEndPoint ip_end = new IPEndPoint(ip_host.AddressList[0], 1111);
        IPAddress ip_addr = ip_host.AddressList[0];

        void SetListening(object o, EventArgs e)
        {
            try
            {

                mr = new Socket(ip_host.AddressList[0].AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                
                mr.Bind(ip_end);
                mr.Listen(1);
                var ml = mr.Accept();

                string data = Encoding.UTF8.GetString(new byte[1024], 0, ml.Receive(new byte[1024]));

                lgbuff = "[RECV_CONNECTED]: < " + data;
                backgroundWorker2.RunWorkerAsync();
                
            } catch
            {
                lgbuff = mr.Connected?"Receiver terminated and got connected ": "Receiver terminated " + ": [RECV_CATCH]";
            }
            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length > 0)
            {
                if(mr != null)
                if (mr.Connected)
                {
                    mr.Send(Encoding.UTF8.GetBytes(textBox1.Text));
                    lgbuff = " >> " + textBox1.Text;
                }
                else
                    lgbuff = ("No connections available.");
                else
                    lgbuff = ("No connections available.");
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        ACM f3 = new ACM();
        private void button7_Click(object sender, EventArgs e)
        {
            if (!f3state)
            {
                f3.Show();
            } else { f3.Activate(); }
        }
        
        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Open Active Connections Manager";
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Set base socket to Listening state";
        }


        String lgbuff = "";

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            lgbuff = "Receiver launched.";
            SetListening(new object(), e);
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (mr.Connected)
                {
                    mr.Listen(1);
                    mr = mr.Accept();

                    string data = Encoding.UTF8.GetString(new byte[1024], 0, mr.Receive(new byte[1024]));

                    lgbuff = " < " + data;
                }
            }
            catch
            {
                backgroundWorker2.CancelAsync();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        VC f2 = new VC();

        private void button8_Click(object sender, EventArgs e)
        {
            if (!f2state)
            {
                f2.Show();
            }
            else { f2.Activate(); }
        }
    }
}
