using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Text.RegularExpressions.Regex;

namespace UniaCore
{
    public partial class Treegex : Form
    {
        public Treegex()
        {
            InitializeComponent();
            inputEditor = Input.Editor;
            errorLog = ErrorList.Editor;
        }

        RichTextBox inputEditor, errorLog;

        private void RegexIn_TextChanged(object sender, EventArgs e)
        {

            UpdateMatches();
        }

        private void Input_TextChanged(object sender, EventArgs e)
        {

            UpdateMatches();
        }

        static Color
            selCol = Color.FromArgb(64, 94, 24),
            altCol = Color.FromArgb(24, 64, 94);

        private void OpenRegex_Click(object sender, EventArgs e)
        {

        }

        private void SaveRegex_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.regexcollection += $"{RegexIn.Text}";
        }

        void UpdateMatches()
        {
            ErrorList.Text = "";
            ErrorList.BackColor = Color.FromArgb(64, 64, 64);

            var sl = inputEditor.SelectionStart;

            inputEditor.SelectionStart = 0;
            inputEditor.SelectionLength = inputEditor.Text.Length;
            inputEditor.SelectionBackColor = inputEditor.BackColor;
            //inputEditor.DeselectAll();
            try
            {

                var mats = Matches(Input.Text, RegexIn.Text);

                var sign = 0;
                Context.Editor.Clear();
                foreach (Match m in mats)
                {
                    sign++;
                    inputEditor.Select(m.Index, m.Length);
                    inputEditor.SelectionBackColor = sign % 2 == 0 ? selCol : altCol;
                    Context.Text += $"{sign}. {m.Value}\n";
                }
            }
            catch (Exception e)
            {
                ErrorList.BackColor = Color.FromArgb(54, 30, 30);
                ErrorList.Text = e.Message;
            }
            inputEditor.DeselectAll();

            inputEditor.SelectionStart = sl;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://docs.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference");
        }
    }
}
