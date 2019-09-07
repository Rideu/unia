using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data.EntityFramework;

namespace UniaCore.Peripherals
{

    public partial class MySQLMGR : Form
    {
        class DBMGR
        {
            MySqlConnection cnt, pcnt;
            MySQLMGR fref;
            //private string server, database, uid, pass;

            public string GetConStr { get { return cnt.ConnectionString; } }

            public event Action<int, string> OnConnectionError;
            public event Action<int, string> OnQueryError;

            public DBMGR(MySQLMGR descriptor)
            {
                fref = descriptor;
                OnConnectionError += new Action<int, string>(delegate (int s, string m) { fref.Log("Error occured: " + s + " -> " + m); });
                OnQueryError += new Action<int, string>(delegate (int s, string m) { fref.Log("Error occured: " + s + " -> " + m); });
                cnt = new MySqlConnection();
                pcnt = new MySqlConnection();
            }

            public void Init(string constr)
            {
                //var server = "a222068_6.mysql.mchost.ru";
                //////"m13.i.h.mchost.ru" "a222068_6.mysql.mchost.ru"

                //var database = "'a222068_6'";
                //var uid = "a222068_6@10.0.2.13";
                //var pass = "BD_connection_for";
                //MySqlConnectionStringBuilder csb = new MySqlConnectionStringBuilder()
                //{
                //    UserID = uid,
                //    Database = database,
                //    Password = pass,
                //    Server = server,
                //    SslMode = MySqlSslMode.None,
                //};

                //constr = "SERVER=" + server + ";DATABASE=" + database + ";UID=\"" + uid + "\";PASSWORD=" + pass + ";SSL Mode=None;";
                cnt = new MySqlConnection(constr);
                cnt.StateChange += Cnt_StateChange;
                pcnt = new MySqlConnection(constr);
            }


            BackgroundWorker bwc = new BackgroundWorker();

            public int EstCon(string constr)
            {
                try
                {
                    if (cnt.State == ConnectionState.Closed)
                    {
                        Init(constr);
                        fref.button1.Enabled = !true;
                        if (!bwc.IsBusy)
                        {
                            
                            bwc.DoWork += Bwc_DoWork;
                            bwc.RunWorkerCompleted += Bwc_RunWorkerCompleted;
                            bwc.RunWorkerAsync();
                            return 3;
                        }
                        return 1;
                    }
                    else
                    if (cnt.State == ConnectionState.Open)
                    {
                        return 2;
                    }
                    else return 3;
                }
                catch (MySqlException e)
                {
                    OnConnectionError(e.Number, e.Message);
                    return 0;
                }
            }

            public void ActDbRfr()
            {
                pcnt.Open();
                MySqlDataAdapter cmd = new MySqlDataAdapter("SHOW TABLES;", pcnt);

                var ds = new DataSet();
                cmd.Fill(ds);
                fref.treeView1.Nodes.Clear();
                fref.treeView1.Nodes.Add(ds.Tables[0].Columns[0].Caption.Remove(0, 10));
                for (var i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    fref.treeView1.Nodes[0].Nodes.Add(ds.Tables[0].Rows[i].ItemArray[0].ToString());
                }

                foreach (TreeNode n in fref.treeView1.Nodes[0].Nodes)
                {
                    n.ContextMenuStrip = fref.contextMenuStrip1;
                }
                fref.treeView1.Nodes[0].Expand();
                fref.treeView1.Nodes[0].NodeFont = new Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
                pcnt.Close();
            }

            private void Bwc_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                if (cnt.State == ConnectionState.Open)
                {
                    try
                    {
                        ActDbRfr();

                        fref.ConnectionOpened();
                    }
                    catch (MySqlException ex)
                    {
                        fref.lg = ("Error occured: " + ex.Number + " -> " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        fref.lg = ("System Error occured: -> " + ex.Message);
                    }
                }
                fref.button1.Enabled = true;
                bwc = new BackgroundWorker();
            }

            private void Bwc_DoWork(object sender, DoWorkEventArgs e)
            {
                try
                {
                    cnt.Open();
                }
                catch (MySqlException ex)
                {
                    fref.lg = ("Error occured: " + ex.Number + " -> " + ex.Message);
                }
                catch (Exception ex)
                {
                    fref.lg = ("System Error occured: -> " + ex.Message);
                }
            }

            public void SendCmd(string query)
            {
                if (cnt != null)
                {
                    if (cnt.State == ConnectionState.Open)
                    {
                        try
                        {
                            if(query.ToUpper().Contains("DROP") || query.ToUpper().Contains("DELETE"))
                            {
                                if(MessageBox.Show("Query contains DROP and/or DELETE statements. Continue execution?", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
                                { } else { fref.Log("Aborted by user."); return; }
                            }
                            MySqlDataAdapter cmd = new MySqlDataAdapter(query, cnt);

                            var ds = new DataSet();
                            cmd.Fill(ds);
                            fref.SetTableData(ds);
                            ActDbRfr();
                            fref.Log("Command executed.");
                        }
                        catch (MySqlException e)
                        {
                            OnQueryError(e.Number, e.Message);
                        }
                        catch (Exception e)
                        {
                            
                            OnQueryError(e.HResult, e.Message);
                        }
                    }
                }
                else
                {
                    fref.Log("Connection isn't established.");
                }
            }

            public void ClsCon() => cnt.Close();

            public ConnectionState GetState()
            {
                //cnt.StateChange += new fref.
                return cnt.State;
            }

            private void Cnt_StateChange(object sender, StateChangeEventArgs e)
            {
                if (e.CurrentState == ConnectionState.Fetching)
                    fref.panel1.BackColor = Color.FromArgb(204, 255, 51);
            }

            public bool Ping()
            {
                return cnt.Ping();
            }
        }


        DBMGR m;
        Timer evtlstnr, chkcnctn
            //, dbrenew
            ;

        public MySQLMGR()
        {
            InitializeComponent();
            m = new DBMGR(this);
            //m.OnQueryError += Log()

            chkcnctn = new Timer();
            chkcnctn.Tick += CheckConnection;
            chkcnctn.Interval = 100;

            //dbrenew = new Timer();
            //dbrenew.Tick += RefreshDB;
            //dbrenew.Interval = 100;

            evtlstnr = new Timer();
            evtlstnr.Tick += AutoLogger;
            evtlstnr.Interval += 100;
            evtlstnr.Start();
        }

        //private void RefreshDB(object sender, EventArgs e)
        //{
        //    m.ActDbRfr();
        //}

        public string lg = "";

        private void AutoLogger(object sender, EventArgs e)
        {
            if (lg.Length > 0)
            {
                Log(lg);
                lg = "";
            }
        }
        
        int chkatmpt = 0;

        public void CheckConnection(object sender, EventArgs e)
        {
            if (m.GetState() == ConnectionState.Connecting || m.GetState() == ConnectionState.Broken)
            {
                panel1.BackColor = Color.Orange;
            }
            if (m.GetState() == ConnectionState.Closed)
            {
                //LockEditor();
            }

            if (!m.Ping())
            {
                chkatmpt++;
                panel1.BackColor = Color.Orange;
                m.EstCon(m.GetConStr);
                if (m.GetState() == ConnectionState.Open)
                {

                    panel1.BackColor = Color.Lime;
                    chkatmpt = 0;
                }
                if (chkatmpt == 40)
                {
                    chkatmpt = 0;
                    textBox1.Enabled = !true;
                    button1.Text = "Connect";
                    panel1.BackColor = Color.Red;
                    chkcnctn.Stop();
                    //dbrenew.Stop();
                }
            }

        }

        //void LockEditor()
        //{
        //    panel1.BackColor = Color.Red;
        //    richTextBox1.Enabled = !true;
        //    richTextBox1.Text = "Waiting for connection...";
        //    richTextBox1.ForeColor = Color.DimGray;
        //}

        public void ConnectionOpened()
        {
            panel1.BackColor = Color.Lime;
            chkcnctn.Start();
            if (tabControl1.Controls.Count == 0)
                toolStripButton1.PerformClick();
            textBox1.Enabled = !true;
            button1.Text = "Disconnect";
            Log("Connection established.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (m.EstCon(textBox1.Text))
            {
                case 0:
                    {
                        panel1.BackColor = Color.Red;
                    }
                    break;

                case 1:
                    {
                        //panel1.BackColor = Color.Lime;
                        ////richTextBox1.Text = "Query...";
                        ////richTextBox1.ForeColor = Color.DimGray;
                        ////richTextBox1.BackColor = Color.White;
                        ////userkey = !true;
                        ////richTextBox1.Enabled = true;
                        //chkcnctn.Start();
                        //if (tabControl1.Controls.Count == 0)
                        //    toolStripButton1.PerformClick();
                        ////dbrenew.Start();
                        //textBox1.Enabled = !true;
                        //button1.Text = "Disconnect";
                        //Log("Connection established.");
                    }
                    break;

                case 2:
                    {
                        chkcnctn.Stop();
                        //dbrenew.Stop();
                        m.ClsCon();
                        textBox1.Enabled = true;
                        button1.Text = "Connect";
                        panel1.BackColor = Color.Red;
                        treeView1.Nodes.Clear();
                        Log("Connection closed.");
                    }
                    break;

                default:
                    break;
            }
        }

        public void Log(string msg)
        {
            textBox2.AppendText("[" + DateTime.Now.ToLongTimeString() + "] -> " + msg + "\r\n\r\n");
            textBox2.AutoScrollOffset = new Point(0, 4122);
        }

        public void SetTableData(DataSet ds)
        {
            if (ds.Tables.Count > 0)
                dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.ClearSelection();
        }

        //bool userkey = !true;

        //private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (!userkey)
        //    {
        //        richTextBox1.Text = "";
        //        richTextBox1.ForeColor = Color.Black;
        //    }
        //}

        //private void richTextBox1_Leave(object sender, EventArgs e)
        //{
        //    if (richTextBox1.Text.Length == 0)
        //    {
        //        richTextBox1.Text = "Query...";
        //        richTextBox1.ForeColor = Color.DimGray;
        //        userkey = !true;
        //    }
        //}

        //private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    userkey = true;
        //}

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void MySQLMGR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (m.GetState() == ConnectionState.Open)
                    m.SendCmd(ActiveEditor.Text);
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Node.Parent == treeView1.Nodes[0] && e.Button == MouseButtons.Left)
            {
                ActiveEditor.AppendText((ActiveEditor.Text[ActiveEditor.Text.Length-1] == ' '?"":" ") + e.Node.Text);
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent == treeView1.Nodes[0] && e.Button == MouseButtons.Right)
            {
                chknd = e.Node;
            }
        }

        TreeNode chknd;

        private void showContentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            m.SendCmd("SELECT * FROM " + chknd.Text);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //if(userkey)
            if (m.GetState() == ConnectionState.Open && tabControl1.Controls.Count > 0)
                m.SendCmd(ActiveEditor.Text);
        }
        
        void CreateNewTextwriter()
        {

        }

        CodeTextBox ActiveEditor;

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var n = new TabPage()
            {
                Text = "Query" + (tabControl1.Controls.Count + 1),
                
            };
            
            CodeTextBox c = new CodeTextBox()
            {
                AutoWordSelection = true,
                BackColor = Color.White,
                BorderStyle = System.Windows.Forms.BorderStyle.None,
                Dock = System.Windows.Forms.DockStyle.Fill,
                Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))),
                ForeColor = Color.Black,
                Location = new System.Drawing.Point(3, 3),
                Size = new System.Drawing.Size(431, 225),
                Name = "codeTextBox" + (tabControl1.Controls.Count + 1),
                TabIndex = 1,
            };
            c.GotFocus += delegate
            {
                ActiveEditor = c;
            };
            c.KeyDown += C_KeyDown;
            c.ContextMenuStrip = CodeEditorStrip1;
            n.Controls.Add(c);
            tabControl1.Controls.Add(n);
            tabControl1.SelectTab((tabControl1.Controls.Count-1));
            c.Focus();
            ActiveEditor = c;
            //tabControl1.Controls;
        }

        private void C_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                if (m.GetState() == ConnectionState.Open && tabControl1.Controls.Count > 0)
                    m.SendCmd(ActiveEditor.Text);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(ActiveEditor.Text);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveEditor.SelectedText = Clipboard.GetText();
        }

        private void CodeEditorStrip1_Opening(object sender, CancelEventArgs e)
        {
            if(!Clipboard.ContainsText())
            {
                pasteToolStripMenuItem.Enabled = !true;
            } else { pasteToolStripMenuItem.Enabled = true; }
            
            if(ActiveEditor.SelectedText.Length > 0)
            {
                copyToolStripMenuItem.Enabled = true;
            } else { copyToolStripMenuItem.Enabled = !true;  }
        }

        private void copyToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Copy selected text";
        }

        private void pasteToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Paste text from clipboard";
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            if(m.GetState() == ConnectionState.Closed)
            toolStripStatusLabel1.Text = "Open connection using specified connection string";
            else 
            if(m.GetState() == ConnectionState.Open)
            toolStripStatusLabel1.Text = "Close connection";
        }

        private void toolStripButton2_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Send current query";
        }

        private void toolStripButton1_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Create new query";
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Send query.";
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.F)
            {
                contextMenuStrip2.Show(MySQLMGR.MousePosition);
            }
        }

        private void toolStripTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                FindInTable(toolStripTextBox2.Text);
        }

        void FindInTable(string obj)
        {
            dataGridView1.ClearSelection();
            for (int row = 0; row < dataGridView1.RowCount-1; row++)
            {
                for (int col = 0; col < dataGridView1.ColumnCount; col++)
                {
                    if (dataGridView1[col, row].Value.ToString() == obj)
                        dataGridView1[col, row].Selected = true;
                }
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GetHelp().Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

            var src = "https://dev.mysql.com/doc/connector-net/en/connector-net-connection-options.html";
            Process.Start(src);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }
    }
}
