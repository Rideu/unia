using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniaCore.Peripherals.Treegex
{
    public partial class RegCell : UserControl
    {
        [Browsable(true)]
        [Category("Data")]
        public string RegText { get => expText.Text; private set => expText.Text = value; }
        [Browsable(true)]
        [Category("Data")]
        public string RegName { get => expName.Text; set => expName.Text = value; }
        RegView owner;

        public RegCell()
        {
            owner = (RegView)ParentForm;
            InitializeComponent();
            this.Apply((c) =>
            {
                c.Click += C_Click;
            });
        }

        private void C_Click(object sender, EventArgs e)
        {

        }

    }
}
