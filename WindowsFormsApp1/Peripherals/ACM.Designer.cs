namespace UniaCore
{
    partial class ACM
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.PortColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocalAddrColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemoteAddrColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PortColumn,
            this.LocalAddrColumn,
            this.RemoteAddrColumn,
            this.StateColumn,
            this.PIDColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, 39);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 5;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(510, 426);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // PortColumn
            // 
            this.PortColumn.Frozen = true;
            this.PortColumn.HeaderText = "Port";
            this.PortColumn.Name = "PortColumn";
            this.PortColumn.ReadOnly = true;
            this.PortColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PortColumn.Width = 40;
            // 
            // LocalAddrColumn
            // 
            this.LocalAddrColumn.Frozen = true;
            this.LocalAddrColumn.HeaderText = "Local Address";
            this.LocalAddrColumn.Name = "LocalAddrColumn";
            this.LocalAddrColumn.ReadOnly = true;
            this.LocalAddrColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LocalAddrColumn.Width = 150;
            // 
            // RemoteAddrColumn
            // 
            this.RemoteAddrColumn.Frozen = true;
            this.RemoteAddrColumn.HeaderText = "Remote Address";
            this.RemoteAddrColumn.Name = "RemoteAddrColumn";
            this.RemoteAddrColumn.ReadOnly = true;
            this.RemoteAddrColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RemoteAddrColumn.Width = 150;
            // 
            // StateColumn
            // 
            this.StateColumn.Frozen = true;
            this.StateColumn.HeaderText = "State";
            this.StateColumn.Name = "StateColumn";
            this.StateColumn.ReadOnly = true;
            this.StateColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.StateColumn.Width = 70;
            // 
            // PIDColumn
            // 
            this.PIDColumn.Frozen = true;
            this.PIDColumn.HeaderText = "PID Name";
            this.PIDColumn.Name = "PIDColumn";
            this.PIDColumn.ReadOnly = true;
            this.PIDColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.DimGray;
            this.button1.ForeColor = System.Drawing.Color.Silver;
            this.button1.Location = new System.Drawing.Point(521, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Tracert Selected";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(521, 381);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Selected IP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.BackColor = System.Drawing.Color.DimGray;
            this.checkBox1.ForeColor = System.Drawing.Color.Silver;
            this.checkBox1.Location = new System.Drawing.Point(521, 429);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.checkBox1.Size = new System.Drawing.Size(115, 24);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Autocopy";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.DimGray;
            this.button2.ForeColor = System.Drawing.Color.Silver;
            this.button2.Location = new System.Drawing.Point(521, 72);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Refresh";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox2.BackColor = System.Drawing.Color.DimGray;
            this.checkBox2.ForeColor = System.Drawing.Color.Silver;
            this.checkBox2.Location = new System.Drawing.Point(521, 399);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.checkBox2.Size = new System.Drawing.Size(115, 24);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Text = "Autorefresh";
            this.checkBox2.UseVisualStyleBackColor = false;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.DimGray;
            this.button3.ForeColor = System.Drawing.Color.Silver;
            this.button3.Location = new System.Drawing.Point(521, 101);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Open as URL";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(648, 39);
            this.panel1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(11, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ACM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(648, 465);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(700, 800);
            this.MinimumSize = new System.Drawing.Size(600, 200);
            this.Name = "ACM";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Active Connections Manager";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.Shown += new System.EventHandler(this.Form3_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn PortColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocalAddrColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RemoteAddrColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PIDColumn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
    }
}