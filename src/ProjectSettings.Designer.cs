namespace Reviser
{
    partial class ProjectSettings
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
            this.projNameLabel = new System.Windows.Forms.Label();
            this.projNameBox = new System.Windows.Forms.TextBox();
            this.projTypeLabel = new System.Windows.Forms.Label();
            this.projTypeBox = new System.Windows.Forms.ComboBox();
            this.origFilesLabel = new System.Windows.Forms.Label();
            this.origFilesBox = new System.Windows.Forms.TextBox();
            this.origFilesBtn = new System.Windows.Forms.Button();
            this.tranFilesBtn = new System.Windows.Forms.Button();
            this.tranFilesBox = new System.Windows.Forms.TextBox();
            this.tranFilesLabel = new System.Windows.Forms.Label();
            this.firstFileLabel = new System.Windows.Forms.Label();
            this.lastFileLabel = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.firstFileBox = new System.Windows.Forms.ComboBox();
            this.lastFileBox = new System.Windows.Forms.ComboBox();
            this.fileSelectBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // projNameLabel
            // 
            this.projNameLabel.AutoSize = true;
            this.projNameLabel.Location = new System.Drawing.Point(9, 15);
            this.projNameLabel.Name = "projNameLabel";
            this.projNameLabel.Size = new System.Drawing.Size(74, 13);
            this.projNameLabel.TabIndex = 0;
            this.projNameLabel.Text = Language.Strings.ProjectSettings_projNameLabel;
            // 
            // projNameBox
            // 
            this.projNameBox.Location = new System.Drawing.Point(102, 12);
            this.projNameBox.Name = "projNameBox";
            this.projNameBox.Size = new System.Drawing.Size(188, 20);
            this.projNameBox.TabIndex = 0;
            // 
            // projTypeLabel
            // 
            this.projTypeLabel.AutoSize = true;
            this.projTypeLabel.Location = new System.Drawing.Point(9, 41);
            this.projTypeLabel.Name = "projTypeLabel";
            this.projTypeLabel.Size = new System.Drawing.Size(70, 13);
            this.projTypeLabel.TabIndex = 2;
            this.projTypeLabel.Text = Language.Strings.ProjectSettings_projTypeLabel;
            // 
            // projTypeBox
            // 
            this.projTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.projTypeBox.Enabled = false;
            this.projTypeBox.FormattingEnabled = true;
            this.projTypeBox.Items.AddRange(new object[] {
            "DD",
            "SoJ",
            "AAT"});
            this.projTypeBox.Location = new System.Drawing.Point(102, 38);
            this.projTypeBox.Name = "projTypeBox";
            this.projTypeBox.Size = new System.Drawing.Size(54, 21);
            this.projTypeBox.TabIndex = 1;
            // 
            // origFilesLabel
            // 
            this.origFilesLabel.AutoSize = true;
            this.origFilesLabel.Location = new System.Drawing.Point(9, 88);
            this.origFilesLabel.Name = "origFilesLabel";
            this.origFilesLabel.Size = new System.Drawing.Size(69, 13);
            this.origFilesLabel.TabIndex = 4;
            this.origFilesLabel.Text = Language.Strings.ProjectSettings_origFilesLabel;
            // 
            // origFilesBox
            // 
            this.origFilesBox.Location = new System.Drawing.Point(102, 85);
            this.origFilesBox.Name = "origFilesBox";
            this.origFilesBox.Size = new System.Drawing.Size(157, 20);
            this.origFilesBox.TabIndex = 2;
            // 
            // origFilesBtn
            // 
            this.origFilesBtn.Location = new System.Drawing.Point(265, 85);
            this.origFilesBtn.Name = "origFilesBtn";
            this.origFilesBtn.Size = new System.Drawing.Size(25, 20);
            this.origFilesBtn.TabIndex = 3;
            this.origFilesBtn.Text = "...";
            this.origFilesBtn.UseVisualStyleBackColor = true;
            this.origFilesBtn.Click += new System.EventHandler(this.origFilesBtn_Click);
            // 
            // tranFilesBtn
            // 
            this.tranFilesBtn.Location = new System.Drawing.Point(265, 111);
            this.tranFilesBtn.Name = "tranFilesBtn";
            this.tranFilesBtn.Size = new System.Drawing.Size(25, 20);
            this.tranFilesBtn.TabIndex = 5;
            this.tranFilesBtn.Text = "...";
            this.tranFilesBtn.UseVisualStyleBackColor = true;
            this.tranFilesBtn.Click += new System.EventHandler(this.tranFilesBtn_Click);
            // 
            // tranFilesBox
            // 
            this.tranFilesBox.Location = new System.Drawing.Point(102, 111);
            this.tranFilesBox.Name = "tranFilesBox";
            this.tranFilesBox.Size = new System.Drawing.Size(157, 20);
            this.tranFilesBox.TabIndex = 4;
            this.tranFilesBox.TextChanged += new System.EventHandler(this.tranFilesBox_TextChanged);
            // 
            // tranFilesLabel
            // 
            this.tranFilesLabel.AutoSize = true;
            this.tranFilesLabel.Location = new System.Drawing.Point(9, 115);
            this.tranFilesLabel.Name = "tranFilesLabel";
            this.tranFilesLabel.Size = new System.Drawing.Size(84, 13);
            this.tranFilesLabel.TabIndex = 7;
            this.tranFilesLabel.Text = Language.Strings.ProjectSettings_tranFilesLabel;
            // 
            // firstFileLabel
            // 
            this.firstFileLabel.AutoSize = true;
            this.firstFileLabel.Location = new System.Drawing.Point(9, 160);
            this.firstFileLabel.Name = "firstFileLabel";
            this.firstFileLabel.Size = new System.Drawing.Size(48, 13);
            this.firstFileLabel.TabIndex = 12;
            this.firstFileLabel.Text = Language.Strings.ProjectSettings_firstFileLabel;
            // 
            // lastFileLabel
            // 
            this.lastFileLabel.AutoSize = true;
            this.lastFileLabel.Location = new System.Drawing.Point(9, 187);
            this.lastFileLabel.Name = "lastFileLabel";
            this.lastFileLabel.Size = new System.Drawing.Size(49, 13);
            this.lastFileLabel.TabIndex = 13;
            this.lastFileLabel.Text = Language.Strings.ProjectSettings_lastFileLabel;
            // 
            // saveBtn
            // 
            this.saveBtn.Enabled = false;
            this.saveBtn.Location = new System.Drawing.Point(215, 222);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 9;
            this.saveBtn.Text = Language.Strings.Generic_Save;
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(134, 222);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 10;
            this.cancelBtn.Text = Language.Strings.Generic_Cancel;
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // firstFileBox
            // 
            this.firstFileBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.firstFileBox.Enabled = false;
            this.firstFileBox.FormattingEnabled = true;
            this.firstFileBox.Location = new System.Drawing.Point(102, 157);
            this.firstFileBox.Name = "firstFileBox";
            this.firstFileBox.Size = new System.Drawing.Size(188, 21);
            this.firstFileBox.TabIndex = 6;
            this.firstFileBox.SelectedIndexChanged += new System.EventHandler(this.firstFileBox_SelectedIndexChanged);
            // 
            // lastFileBox
            // 
            this.lastFileBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lastFileBox.Enabled = false;
            this.lastFileBox.FormattingEnabled = true;
            this.lastFileBox.Location = new System.Drawing.Point(102, 184);
            this.lastFileBox.Name = "lastFileBox";
            this.lastFileBox.Size = new System.Drawing.Size(188, 21);
            this.lastFileBox.TabIndex = 7;
            this.lastFileBox.SelectedIndexChanged += new System.EventHandler(this.lastFileBox_SelectedIndexChanged);
            // 
            // fileSelectBtn
            // 
            this.fileSelectBtn.Enabled = false;
            this.fileSelectBtn.Location = new System.Drawing.Point(12, 222);
            this.fileSelectBtn.Name = "fileSelectBtn";
            this.fileSelectBtn.Size = new System.Drawing.Size(75, 23);
            this.fileSelectBtn.TabIndex = 8;
            this.fileSelectBtn.Text = Language.Strings.ProjectSettings_fileSelectBtn;
            this.fileSelectBtn.UseVisualStyleBackColor = true;
            this.fileSelectBtn.Click += new System.EventHandler(this.fileSelectBtn_Click);
            // 
            // ProjectSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(302, 257);
            this.Controls.Add(this.fileSelectBtn);
            this.Controls.Add(this.lastFileBox);
            this.Controls.Add(this.firstFileBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.lastFileLabel);
            this.Controls.Add(this.firstFileLabel);
            this.Controls.Add(this.tranFilesBtn);
            this.Controls.Add(this.tranFilesBox);
            this.Controls.Add(this.tranFilesLabel);
            this.Controls.Add(this.origFilesBtn);
            this.Controls.Add(this.origFilesBox);
            this.Controls.Add(this.origFilesLabel);
            this.Controls.Add(this.projTypeBox);
            this.Controls.Add(this.projTypeLabel);
            this.Controls.Add(this.projNameBox);
            this.Controls.Add(this.projNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.ProjectSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label projNameLabel;
        private System.Windows.Forms.TextBox projNameBox;
        private System.Windows.Forms.Label projTypeLabel;
        private System.Windows.Forms.ComboBox projTypeBox;
        private System.Windows.Forms.Label origFilesLabel;
        private System.Windows.Forms.TextBox origFilesBox;
        private System.Windows.Forms.Button origFilesBtn;
        private System.Windows.Forms.Button tranFilesBtn;
        private System.Windows.Forms.TextBox tranFilesBox;
        private System.Windows.Forms.Label tranFilesLabel;
        private System.Windows.Forms.Label firstFileLabel;
        private System.Windows.Forms.Label lastFileLabel;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.ComboBox firstFileBox;
        private System.Windows.Forms.ComboBox lastFileBox;
        private System.Windows.Forms.Button fileSelectBtn;
    }
}