using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrayLib
{
    [DefaultEvent("OnScroll")]
    public partial class GrayScroll : UserControl
    {
        public GrayScroll()
        {
            InitializeComponent();

        }

        public new event EventHandler OnScroll;

        public enum Orientype { Horizontal, Vertical }
        [Category("Appearance")]
        public Orientype Orient { get => orient; set { orient = orient != value ? ChangeOrient(value) : orient; } }
        Orientype orient = Orientype.Vertical;

        [DefaultValue(0)]
        public float Value
        {
            get => orient == Orientype.Vertical ?
                ((slider.Location.Y - 1) / (float)(Height - slider.Height - 4)) :
                ((slider.Location.X - 1) / (float)(Width - slider.Width - 4));
            set
            {
                value = value > 1 ? 1 : value < 0 ? 0 : value;
                slider.Location = orient == Orientype.Vertical ?
                    new Point(slider.Location.X, (int)((Height - slider.Height - 4) * value - 1)) :
                    new Point((int)((Width - slider.Width - 4) * value) - 1, slider.Location.Y);
            }
        }
        float oldval;

        Orientype ChangeOrient(Orientype val)
        {

            if (orient != val && this.Created)
            {
                Size = new Size(Height, Width);
                MaximumSize = new Size(MaximumSize.Height, MaximumSize.Width);
                MinimumSize = new Size(MinimumSize.Height, MinimumSize.Width);

                slider.Size = new Size(slider.Size.Height, slider.Size.Width);
            }
            else
                slider.Size = new Size(slider.Size.Height, slider.Size.Width);

            return val;
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            slider.BackColor = Color.FromArgb(120, 120, 120);
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            slider.BackColor = Color.FromArgb(80, 80, 80);
        }

        bool ismousedown;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ismousedown = true;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            ismousedown = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            oldval = Value;
            if (ismousedown)
            {
                if (orient == Orientype.Vertical)
                {
                    Point l = new Point(slider.Location.X, PointToClient(Cursor.Position).Y);
                    l.Y -= slider.Height / 2 + 1;
                    l.Y = l.Y < 1 ? 1 : l.Y;
                    l.Y = l.Y + slider.Height + 3 > Height ? Height - slider.Height - 3 : l.Y;
                    slider.Location = l;
                }
                else
                {
                    Point l = new Point(PointToClient(Cursor.Position).X, slider.Location.Y);
                    l.X -= slider.Width / 2 + 1;
                    l.X = l.X < 1 ? 1 : l.X;
                    l.X = l.X + slider.Width + 3 > Width ? Width - slider.Width - 3 : l.X;
                    slider.Location = l;
                }
            }
            if (oldval != Value)
            {
                OnScroll?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
