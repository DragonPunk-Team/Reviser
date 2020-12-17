namespace Reviser
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
            this.label1 = new System.Windows.Forms.Label();
            this.idBox = new System.Windows.Forms.TextBox();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.commentBox = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.copyLineBtn = new System.Windows.Forms.ToolStripButton();
            this.insertLineIdBtn = new System.Windows.Forms.ToolStripButton();
            this.insertFileLineIdBtn = new System.Windows.Forms.ToolStripButton();
            this.prevLinesBtn = new System.Windows.Forms.ToolStripButton();
            this.normalTextBtn = new System.Windows.Forms.ToolStripButton();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.lineBox = new System.Windows.Forms.TextBox();
            this.commentCheckBox = new System.Windows.Forms.CheckBox();
            this.colorCheckBox = new System.Windows.Forms.CheckBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Insert Line ID:";
            // 
            // idBox
            // 
            this.idBox.Location = new System.Drawing.Point(91, 6);
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(67, 20);
            this.idBox.TabIndex = 0;
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
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // commentBox
            // 
            this.commentBox.AcceptsReturn = true;
            this.commentBox.Enabled = false;
            this.commentBox.Location = new System.Drawing.Point(0, 0);
            this.commentBox.Multiline = true;
            this.commentBox.Name = "commentBox";
            this.commentBox.Size = new System.Drawing.Size(402, 181);
            this.commentBox.TabIndex = 1;
            this.commentBox.TextChanged += new System.EventHandler(this.commentBox_TextChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyLineBtn,
            this.insertLineIdBtn,
            this.insertFileLineIdBtn,
            this.prevLinesBtn,
            this.normalTextBtn});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip1.Size = new System.Drawing.Size(399, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // copyLineBtn
            // 
            this.copyLineBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyLineBtn.Enabled = false;
            this.copyLineBtn.Image = global::Reviser.Properties.Resources.Copy_line_from_above;
            this.copyLineBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyLineBtn.Name = "copyLineBtn";
            this.copyLineBtn.Size = new System.Drawing.Size(23, 22);
            this.copyLineBtn.ToolTipText = "Copy line from above";
            this.copyLineBtn.Click += new System.EventHandler(this.copyLineBtn_Click);
            // 
            // insertLineIdBtn
            // 
            this.insertLineIdBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.insertLineIdBtn.Enabled = false;
            this.insertLineIdBtn.Image = global::Reviser.Properties.Resources.Insert_line_ID;
            this.insertLineIdBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.insertLineIdBtn.Name = "insertLineIdBtn";
            this.insertLineIdBtn.Size = new System.Drawing.Size(23, 22);
            this.insertLineIdBtn.ToolTipText = "Insert line ID";
            this.insertLineIdBtn.Click += new System.EventHandler(this.insertLineIdBtn_Click);
            // 
            // insertFileLineIdBtn
            // 
            this.insertFileLineIdBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.insertFileLineIdBtn.Enabled = false;
            this.insertFileLineIdBtn.Image = global::Reviser.Properties.Resources.Insert_filename_and_line_ID;
            this.insertFileLineIdBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.insertFileLineIdBtn.Name = "insertFileLineIdBtn";
            this.insertFileLineIdBtn.Size = new System.Drawing.Size(23, 22);
            this.insertFileLineIdBtn.ToolTipText = "Insert filename and line ID";
            this.insertFileLineIdBtn.Click += new System.EventHandler(this.insertFileLineIdBtn_Click);
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
            this.prevLinesBtn.ToolTipText = "Add previous lines";
            this.prevLinesBtn.Click += new System.EventHandler(this.prevLinesBtn_Click);
            // 
            // normalTextBtn
            // 
            this.normalTextBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.normalTextBtn.Enabled = false;
            this.normalTextBtn.Image = global::Reviser.Properties.Resources.Normal_text;
            this.normalTextBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.normalTextBtn.Name = "normalTextBtn";
            this.normalTextBtn.Size = new System.Drawing.Size(23, 22);
            this.normalTextBtn.ToolTipText = "Normal text";
            this.normalTextBtn.Click += new System.EventHandler(this.normalTextBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Enabled = false;
            this.saveBtn.Location = new System.Drawing.Point(339, 428);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 4;
            this.saveBtn.Text = "Save";
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
            this.cancelBtn.Text = "Cancel";
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
            this.commentCheckBox.Text = "Comment";
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
            this.colorCheckBox.Text = "Include colors";
            this.colorCheckBox.UseVisualStyleBackColor = true;
            this.colorCheckBox.CheckedChanged += new System.EventHandler(this.colorCheckBox_CheckedChanged);
            // 
            // searchBtn
            // 
            this.searchBtn.Image = global::Reviser.Properties.Resources.Search;
            this.searchBtn.Location = new System.Drawing.Point(164, 6);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(20, 20);
            this.searchBtn.TabIndex = 0;
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
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LineEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LineEditor";
            this.Load += new System.EventHandler(this.LineEditor_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox idBox;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.TextBox commentBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TextBox lineBox;
        private System.Windows.Forms.CheckBox commentCheckBox;
        private System.Windows.Forms.CheckBox colorCheckBox;
        private System.Windows.Forms.ToolStripButton copyLineBtn;
        private System.Windows.Forms.ToolStripButton insertLineIdBtn;
        private System.Windows.Forms.ToolStripButton normalTextBtn;
        private System.Windows.Forms.ToolStripButton insertFileLineIdBtn;
        private System.Windows.Forms.ToolStripButton prevLinesBtn;
    }
}