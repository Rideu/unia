namespace UniaCore.Components
{
    partial class GrayRichTextBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.editorBox = new System.Windows.Forms.RichTextBox();
            this.labelHeader = new System.Windows.Forms.Label();
            this.mainContainer = new System.Windows.Forms.Panel();
            this.labelPlaceholder = new System.Windows.Forms.Label();
            this.mainContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // editorBox
            // 
            this.editorBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.editorBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editorBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(164)))), ((int)(((byte)(164)))));
            this.editorBox.Location = new System.Drawing.Point(5, 5);
            this.editorBox.Name = "editorBox";
            this.editorBox.Size = new System.Drawing.Size(500, 331);
            this.editorBox.TabIndex = 0;
            this.editorBox.Text = "";
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(164)))), ((int)(((byte)(164)))));
            this.labelHeader.Location = new System.Drawing.Point(3, 4);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(0, 13);
            this.labelHeader.TabIndex = 1;
            // 
            // mainContainer
            // 
            this.mainContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.mainContainer.Controls.Add(this.labelPlaceholder);
            this.mainContainer.Controls.Add(this.editorBox);
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.Location = new System.Drawing.Point(0, 20);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Padding = new System.Windows.Forms.Padding(5);
            this.mainContainer.Size = new System.Drawing.Size(510, 341);
            this.mainContainer.TabIndex = 2;
            // 
            // labelPlaceholder
            // 
            this.labelPlaceholder.AutoSize = true;
            this.labelPlaceholder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(164)))), ((int)(((byte)(164)))));
            this.labelPlaceholder.Location = new System.Drawing.Point(2, 5);
            this.labelPlaceholder.Name = "labelPlaceholder";
            this.labelPlaceholder.Size = new System.Drawing.Size(35, 13);
            this.labelPlaceholder.TabIndex = 1;
            this.labelPlaceholder.Text = "label1";
            // 
            // GrayRichTexBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.labelHeader);
            this.Name = "GrayRichTexBox";
            this.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.Size = new System.Drawing.Size(510, 361);
            this.mainContainer.ResumeLayout(false);
            this.mainContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox editorBox;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel mainContainer;
        private System.Windows.Forms.Label labelPlaceholder;
    }
}
