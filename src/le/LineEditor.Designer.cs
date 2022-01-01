namespace Reviser.LE
{
    partial class LineEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LineEditor));
            this.lineIDLabel = new System.Windows.Forms.Label();
            this.idBox = new System.Windows.Forms.TextBox();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.commentBox = new System.Windows.Forms.TextBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.copyLineBtn = new System.Windows.Forms.ToolStripButton();
            this.insertLineIDBtn = new System.Windows.Forms.ToolStripButton();
            this.insertFileLineIDBtn = new System.Windows.Forms.ToolStripButton();
            this.plainTextBtn = new System.Windows.Forms.ToolStripButton();
            this.nextLinesBtn = new System.Windows.Forms.ToolStripButton();
            this.prevLinesBtn = new System.Windows.Forms.ToolStripButton();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.lineBox = new System.Windows.Forms.TextBox();
            this.commentCheckBox = new System.Windows.Forms.CheckBox();
            this.colorCheckBox = new System.Windows.Forms.CheckBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lineIDLabel
            // 
            this.lineIDLabel.AutoSize = true;
            this.lineIDLabel.Location = new System.Drawing.Point(12, 9);
            this.lineIDLabel.Name = "lineIDLabel";
            this.lineIDLabel.Size = new System.Drawing.Size(44, 13);
            this.lineIDLabel.TabIndex = 0;
            this.lineIDLabel.Text = Language.Strings.Generic_LineID_Colon;
            // 
            // idBox
            // 
            this.idBox.Location = new System.Drawing.Point(91, 6);
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(67, 20);
            this.idBox.TabIndex = 0;
            this.idBox.TextChanged += new System.EventHandler(this.idBox_TextChanged);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.commentBox);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(402, 181);
            this.toolStripContainer1.Location = new System.Drawing.Point(12, 216);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(402, 206);
            this.toolStripContainer1.TabIndex = 1;
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip);
            // 
            // commentBox
            // 
            this.commentBox.AcceptsReturn = true;
            this.commentBox.Enabled = false;
            this.commentBox.Location = new System.Drawing.Point(0, 0);
            this.commentBox.Multiline = true;
            this.commentBox.Name = "commentBox";
            this.commentBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.commentBox.Size = new System.Drawing.Size(402, 181);
            this.commentBox.TabIndex = 1;
            this.commentBox.TextChanged += new System.EventHandler(this.commentBox_TextChanged);
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyLineBtn,
            this.insertLineIDBtn,
            this.insertFileLineIDBtn,
            this.plainTextBtn,
            this.nextLinesBtn,
            this.prevLinesBtn});
            this.toolStrip.Location = new System.Drawing.Point(3, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip.Size = new System.Drawing.Size(399, 25);
            this.toolStrip.TabIndex = 0;
            // 
            // copyLineBtn
            // 
            this.copyLineBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyLineBtn.Enabled = false;
            this.copyLineBtn.Image = global::Reviser.Properties.Resources.Copy_line_from_above;
            this.copyLineBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyLineBtn.Name = "copyLineBtn";
            this.copyLineBtn.Size = new System.Drawing.Size(23, 22);
            this.copyLineBtn.ToolTipText = Language.Strings.LineEditor_copyLineBtn;
            this.copyLineBtn.Click += new System.EventHandler(this.copyLineBtn_Click);
            // 
            // insertLineIDBtn
            // 
            this.insertLineIDBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.insertLineIDBtn.Enabled = false;
            this.insertLineIDBtn.Image = global::Reviser.Properties.Resources.Insert_line_ID;
            this.insertLineIDBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.insertLineIDBtn.Name = "insertLineIDBtn";
            this.insertLineIDBtn.Size = new System.Drawing.Size(23, 22);
            this.insertLineIDBtn.ToolTipText = Language.Strings.LineEditor_insertLineIDBtn;
            this.insertLineIDBtn.Click += new System.EventHandler(this.insertLineIdBtn_Click);
            // 
            // insertFileLineIDBtn
            // 
            this.insertFileLineIDBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.insertFileLineIDBtn.Enabled = false;
            this.insertFileLineIDBtn.Image = global::Reviser.Properties.Resources.Insert_filename_and_line_ID;
            this.insertFileLineIDBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.insertFileLineIDBtn.Name = "insertFileLineIDBtn";
            this.insertFileLineIDBtn.Size = new System.Drawing.Size(23, 22);
            this.insertFileLineIDBtn.ToolTipText = Language.Strings.LineEditor_insertFileLineIDBtn;
            this.insertFileLineIDBtn.Click += new System.EventHandler(this.insertFileLineIdBtn_Click);
            // 
            // plainTextBtn
            // 
            this.plainTextBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.plainTextBtn.Enabled = false;
            this.plainTextBtn.Image = global::Reviser.Properties.Resources.Normal_text;
            this.plainTextBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.plainTextBtn.Name = "plainTextBtn";
            this.plainTextBtn.Size = new System.Drawing.Size(23, 22);
            this.plainTextBtn.ToolTipText = Language.Strings.LineEditor_plainTextBtn;
            this.plainTextBtn.Click += new System.EventHandler(this.normalTextBtn_Click);
            // 
            // nextLinesBtn
            // 
            this.nextLinesBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.nextLinesBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nextLinesBtn.Enabled = false;
            this.nextLinesBtn.Image = ((System.Drawing.Image)(resources.GetObject("nextLinesBtn.Image")));
            this.nextLinesBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nextLinesBtn.Name = "nextLinesBtn";
            this.nextLinesBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.nextLinesBtn.Size = new System.Drawing.Size(23, 22);
            this.nextLinesBtn.Text = "-1";
            this.nextLinesBtn.ToolTipText = Language.Strings.LineEditor_nextLinesBtn;
            this.nextLinesBtn.Click += new System.EventHandler(this.nextLinesBtn_Click);
            // 
            // prevLinesBtn
            // 
            this.prevLinesBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.prevLinesBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.prevLinesBtn.Enabled = false;
            this.prevLinesBtn.Image = global::Reviser.Properties.Resources.Add_previous_lines___no_lines;
            this.prevLinesBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.prevLinesBtn.Name = "prevLinesBtn";
            this.prevLinesBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.prevLinesBtn.Size = new System.Drawing.Size(23, 22);
            this.prevLinesBtn.Text = "-1";
            this.prevLinesBtn.ToolTipText = Language.Strings.LineEditor_prevLinesBtn;
            this.prevLinesBtn.Click += new System.EventHandler(this.prevLinesBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Enabled = false;
            this.saveBtn.Location = new System.Drawing.Point(339, 428);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 4;
            this.saveBtn.Text = Language.Strings.Generic_Save;
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(258, 428);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 5;
            this.cancelBtn.Text = Language.Strings.Generic_Cancel;
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // lineBox
            // 
            this.lineBox.Location = new System.Drawing.Point(12, 32);
            this.lineBox.Multiline = true;
            this.lineBox.Name = "lineBox";
            this.lineBox.ReadOnly = true;
            this.lineBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lineBox.Size = new System.Drawing.Size(402, 178);
            this.lineBox.TabIndex = 0;
            this.lineBox.TabStop = false;
            this.lineBox.TextChanged += new System.EventHandler(this.lineBox_TextChanged);
            // 
            // commentCheckBox
            // 
            this.commentCheckBox.AutoSize = true;
            this.commentCheckBox.Enabled = false;
            this.commentCheckBox.Location = new System.Drawing.Point(124, 432);
            this.commentCheckBox.Name = "commentCheckBox";
            this.commentCheckBox.Size = new System.Drawing.Size(70, 17);
            this.commentCheckBox.TabIndex = 3;
            this.commentCheckBox.Text = Language.Strings.Generic_Comment;
            this.commentCheckBox.UseVisualStyleBackColor = true;
            this.commentCheckBox.CheckedChanged += new System.EventHandler(this.commentCheckBox_CheckedChanged);
            // 
            // colorCheckBox
            // 
            this.colorCheckBox.AutoSize = true;
            this.colorCheckBox.Enabled = false;
            this.colorCheckBox.Location = new System.Drawing.Point(12, 432);
            this.colorCheckBox.Name = "colorCheckBox";
            this.colorCheckBox.Size = new System.Drawing.Size(92, 17);
            this.colorCheckBox.TabIndex = 2;
            this.colorCheckBox.Text = Language.Strings.LineEditor_colorCheckBox;
            this.colorCheckBox.UseVisualStyleBackColor = true;
            this.colorCheckBox.CheckedChanged += new System.EventHandler(this.colorCheckBox_CheckedChanged);
            // 
            // searchBtn
            // 
            this.searchBtn.Image = global::Reviser.Properties.Resources.Search;
            this.searchBtn.Location = new System.Drawing.Point(164, 6);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(20, 20);
            this.searchBtn.TabIndex = 6;
            this.searchBtn.TabStop = false;
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // LineEditor
            // 
            this.AcceptButton = this.searchBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(430, 458);
            this.Controls.Add(this.colorCheckBox);
            this.Controls.Add(this.commentCheckBox);
            this.Controls.Add(this.lineBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.idBox);
            this.Controls.Add(this.lineIDLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LineEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.LineEditor_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lineIDLabel;
        private System.Windows.Forms.TextBox idBox;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.TextBox commentBox;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TextBox lineBox;
        private System.Windows.Forms.CheckBox commentCheckBox;
        private System.Windows.Forms.CheckBox colorCheckBox;
        private System.Windows.Forms.ToolStripButton copyLineBtn;
        private System.Windows.Forms.ToolStripButton insertLineIDBtn;
        private System.Windows.Forms.ToolStripButton plainTextBtn;
        private System.Windows.Forms.ToolStripButton insertFileLineIDBtn;
        private System.Windows.Forms.ToolStripButton prevLinesBtn;
        private System.Windows.Forms.ToolStripButton nextLinesBtn;
    }
}