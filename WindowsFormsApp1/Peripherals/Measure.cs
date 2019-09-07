using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics.PerformanceData;
using System.Management;
using System.Management.Instrumentation;

namespace UniaCore
{
    public partial class Measure : Form
    {
        public Measure()
        {
            InitializeComponent();
        }

        private void Measure_Load(object sender, EventArgs e)
        {
            
        }

        string GetDeviceProp(string namespace_, string category, string property)
        {
            string inout = "";
            try
            {
                //@"root\CIMV2"
                string nmspc = namespace_;
                string ctg = category;
                string prop = "CurrentTemperature";

                ManagementObjectSearcher mos = new ManagementObjectSearcher(nmspc, "SELECT * FROM " + ctg);
                
                foreach (ManagementObject n in mos.Get())
                {
                    inout = n[prop].ToString();
                }
            }
            catch
            {
                inout = "Invalid query";
            }
            return inout;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Return)
            {
                label1.Text = GetDeviceProp("","","");
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
            textBox1.Text = "";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.DimGray;
            textBox1.Text = "Query...";
        }
    }
}
