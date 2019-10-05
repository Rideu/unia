using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniaCore.Components
{
    public partial class GrayPanel : Panel
    {
        [Category("Appearance")]
        [Browsable(true)]
        public string Header
        {
            get => labelHeader.Text;
            set
            {
                labelHeader.Text = value;
                if (value.Length > 0)
                {
                    Padding = new Padding(0, 20, 0, 0);
                }
                else
                {
                    Padding = new Padding(0, 0, 0, 0);
                }
            }
        }

        public GrayPanel()
        {
            InitializeComponent();
        }
    }
}
