using XNA = Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Uniview.Properties;

namespace Uniview
{
    public partial class UniviewForm : Form
    {
        #region Resizer

        private const int
        HTLEFT = 10,
        HTRIGHT = 11,
        HTTOP = 12,
        HTTOPLEFT = 13,
        HTTOPRIGHT = 14,
        HTBOTTOM = 15,
        HTBOTTOMLEFT = 16,
        HTBOTTOMRIGHT = 17;

        const int BorderSize = 5;

        Rectangle TopBorder { get { return new Rectangle(0, 0, this.ClientSize.Width, BorderSize); } }
        Rectangle BottomBorder { get { return new Rectangle(0, this.ClientSize.Height - BorderSize, this.ClientSize.Width, BorderSize); } }
        Rectangle RightBorder { get { return new Rectangle(this.ClientSize.Width - BorderSize, 0, BorderSize, this.ClientSize.Height); } }
        Rectangle LeftBorder { get { return new Rectangle(0, 0, BorderSize, this.ClientSize.Height); } }

        Rectangle TopLeft { get { return new Rectangle(0, 0, BorderSize, BorderSize); } }
        Rectangle TopRight { get { return new Rectangle(this.ClientSize.Width - BorderSize, 0, BorderSize, BorderSize); } }
        Rectangle BottomLeft { get { return new Rectangle(0, this.ClientSize.Height - BorderSize, BorderSize, BorderSize); } }
        Rectangle BottomRight { get { return new Rectangle(this.ClientSize.Width - BorderSize, this.ClientSize.Height - BorderSize, BorderSize, BorderSize); } }


        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == 0x84)
            {
                var cp = MousePosition;
                var cursor = this.PointToClient(cp);

                if (TopLeft.Contains(cursor)) message.Result = (IntPtr)HTTOPLEFT;
                else if (TopRight.Contains(cursor)) message.Result = (IntPtr)HTTOPRIGHT;
                else if (BottomLeft.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMLEFT;
                else if (BottomRight.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMRIGHT;

                else if (TopBorder.Contains(cursor)) message.Result = (IntPtr)HTTOP;
                else if (LeftBorder.Contains(cursor)) message.Result = (IntPtr)HTLEFT;
                else if (RightBorder.Contains(cursor)) message.Result = (IntPtr)HTRIGHT;
                else if (BottomBorder.Contains(cursor)) message.Result = (IntPtr)HTBOTTOM;
            }
        }

        #endregion

        bool verbose = false;

        private void grayButtonBackground_Click(object sender, EventArgs e)
        {
            colorDialogBackground.ShowDialog(this);
            SetViewerBackgroundColor(colorDialogBackground.Color);
        }

        public UniviewForm()
        {
            InitializeComponent();
            imageViewer1.ResizeRequired += (s, size) =>
            {
                Size = new Size(Math.Max(size.X, Size.Width), Math.Max(size.Y + imageViewer1.Location.Y, Size.Height));
                var imageb = Size;
                var viewb = Screen.PrimaryScreen.Bounds;

                var position = new Point(viewb.Width / 2 - imageb.Width / 2, viewb.Height / 2 - imageb.Height / 2);
                position.X = Math.Max(position.X, 0);
                position.Y = Math.Max(position.Y, 0);
                Location = position;
            };

            richTextBox1.Visible = verbose = false;

            SetViewerBackgroundColor(Settings.Default.backcolor);
        }

        void SetViewerBackgroundColor(Color c)
        {
            Settings.Default.backcolor =
            imageViewer1.BackColor = c;

            Settings.Default.Save();
        }

        private void UniviewForm_Load(object sender, EventArgs e)
        {

            ShowImage(@"C:\Users\Rideu\Documents\Visual Studio 2017\Projects\CruxRepo\Crux\Crux\Content\images\form_layout - копия.png");
            SetArgs(Environment.GetCommandLineArgs());
        }

        public void SetArgs(string[] param)
        {
            try
            {

                foreach (var n in param)
                {
                    richTextBox1.Text += n + "\n";
                    var ext = Path.GetExtension(n);
                    if (ext.IsMatch(@"\.png|\.jpg"))
                    {
                        ShowImage(n);

                    }
                    if (n == "-v") EnableVerbose();

                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Err occured: {e.Message}");
                throw;
            }
        }

        public void EnableVerbose()
        {
            richTextBox1.Visible = verbose = true;
        }

        public void ShowImage(string path)
        {
            var img = imageViewer1.ShowImage(Text = path);
            Text += $" [{img.Width}x{img.Height}]";
        }

        private void grayButton1_Click(object sender, EventArgs e)
        {
            openFileDialogImage.ShowDialog(this);
        }

        private void openFileDialogImage_FileOk(object sender, CancelEventArgs e)
        {
            ShowImage(openFileDialogImage.FileName);
        }
    }
}
