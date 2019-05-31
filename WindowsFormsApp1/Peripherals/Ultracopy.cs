using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace WindowsFormsApp1
{
    public partial class Ultracopy : Form
    {
        Properties.Settings Sets => Properties.Settings.Default;
        public Ultracopy()
        {
            InitializeComponent();
            //Sets.FoldersPaths.OfType<string>().ToList().ForEach(n => checkedListBox1.Items.Add(n));
            textBox1.Text = Sets.MainFolder; 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(Directory.Exists(textBox2.Text) && !Sets.FoldersPaths.Contains(textBox2.Text))
            {
                Sets.FoldersPaths = Sets.FoldersPaths;
                Sets.FoldersPaths.Add(textBox2.Text);
                Sets.Save();
                checkedListBox1.Items.Add(textBox2.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = folderBrowserDialog1.ShowDialog() == DialogResult.OK ? folderBrowserDialog1.SelectedPath : textBox1.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = folderBrowserDialog1.ShowDialog() == DialogResult.OK ? folderBrowserDialog1.SelectedPath : textBox2.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedItem != null)
            {
                Sets.FoldersPaths.Remove(checkedListBox1.SelectedItem as string);
                checkedListBox1.Items.Remove(checkedListBox1.SelectedItem);
                Sets.Save();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(Directory.Exists(Sets.MainFolder) && checkedListBox1.Items.Count > 0)
            {
                
                checkedListBox1.CheckedItems.OfType<string>().ToList().ForEach(
                    delegate(string n) 
                    {
                        Directory.CreateDirectory(Sets.MainFolder + "\\" + FileSystem.GetName(n));
                        FileSystem.CopyDirectory(n, Sets.MainFolder + "\\" + FileSystem.GetName(n), UIOption.AllDialogs);
                    });
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Sets.MainFolder = textBox1.Text;
            Sets.Save();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, true);
        }

        private void invertSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //checkedListBox1.Sel
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, !checkedListBox1.GetItemChecked(i));
        }
    }
}
