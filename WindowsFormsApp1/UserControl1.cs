﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.Internals;
using CefSharp.WinForms;

namespace WindowsFormsApp1
{
    public partial class UserControl1 : Form
    {
        ChromiumWebBrowser c = new ChromiumWebBrowser("");
        public UserControl1()
        {
            c.Dock = DockStyle.Fill;
            Controls.Add(c);
            InitializeComponent();
        }
    }
}