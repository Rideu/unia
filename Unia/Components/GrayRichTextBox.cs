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

    [DefaultEvent("TextChanged")]
    public partial class GrayRichTextBox : UserControl
    {
        #region Events

        [Category("Action")]
        [Browsable(true)]
        new public event EventHandler TextChanged { remove { editorBox.TextChanged -= value; } add { editorBox.TextChanged += value; } }

        #endregion

        #region Props

        [Category("Appearance")]
        [Browsable(true)]
        new public Color ForeColor { get => editorBox.ForeColor; set => editorBox.ForeColor = value; }

        [Category("Appearance")]
        [Browsable(true)]
        new public string Text { get => editorBox.Text; set => editorBox.Text = value; }

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
                    Padding = new Padding(2, 20, 2, 2);
                }
                else
                {
                    Padding = new Padding(2, 2, 2, 2);
                }
            }
        }

        string placeHolder;
        bool state_empty;

        Color placeHolderColor = Color.FromArgb(115, 114, 114, 114);
        Color foreColor = Color.FromArgb(255, 164, 164, 164);

        [Category("Appearance")]
        [Browsable(true)]
        public string PlaceHolder
        {
            get => placeHolder;
            set
            {
                placeHolder = value;
                UpdatePlaceHolder();
            }
        }

        [Category("Behavior")]
        [Browsable(true)]
        public bool ReadOnly { get => editorBox.ReadOnly; set => editorBox.ReadOnly = value; }

        void UpdatePlaceHolder()
        {
            if (labelPlaceholder.Visible = (state_empty = (editorBox.Text.Length == 0)))
            {
                labelPlaceholder.Text = placeHolder;
            }
        }

        #endregion

        public RichTextBox Editor => editorBox;

        public GrayRichTextBox()
        {
            InitializeComponent();
            editorBox.GotFocus += EditorBox_GotFocus;
            editorBox.LostFocus += EditorBox_LostFocus;
            labelPlaceholder.Text = "";
            //editorBox.TextChanged += EditorBox_TextChanged;
            //Load += GrayRichTexBox_Load;
        }


        private void EditorBox_GotFocus(object sender, EventArgs e)
        {
            if (state_empty)
            {
                labelPlaceholder.Visible = false;
            }
        }

        private void EditorBox_LostFocus(object sender, EventArgs e)
        {
            UpdatePlaceHolder();
        }
    }
}
