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
            this.label1 = new System.Windows.Forms.Label();
            this.projNameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.projTypeBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.origFilesBox = new System.Windows.Forms.TextBox();
            this.origFilesBtn = new System.Windows.Forms.Button();
            this.tranFilesBtn = new System.Windows.Forms.Button();
            this.tranFilesBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.firstFileBox = new System.Windows.Forms.ComboBox();
            this.lastFileBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project Name:";
            // 
            // projNameBox
            // 
            this.projNameBox.Location = new System.Drawing.Point(102, 12);
            this.projNameBox.Name = "projNameBox";
            this.projNameBox.Size = new System.Drawing.Size(188, 20);
            this.projNameBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Project Type:";
            // 
            // projTypeBox
            // 
            this.projTypeBox.Enabled = false;
            this.projTypeBox.FormattingEnabled = true;
            this.projTypeBox.Items.AddRange(new object[] {
            "SoJ",
            "Trilogy"});
            this.projTypeBox.Location = new System.Drawing.Point(102, 38);
            this.projTypeBox.Name = "projTypeBox";
            this.projTypeBox.Size = new System.Drawing.Size(54, 21);
            this.projTypeBox.TabIndex = 3;
            this.projTypeBox.Text = "SoJ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Original Files:";
            // 
            // origFilesBox
            // 
            this.origFilesBox.Location = new System.Drawing.Point(102, 85);
            this.origFilesBox.Name = "origFilesBox";
            this.origFilesBox.Size = new System.Drawing.Size(157, 20);
            this.origFilesBox.TabIndex = 5;
            // 
            // origFilesBtn
            // 
            this.origFilesBtn.Location = new System.Drawing.Point(265, 85);
            this.origFilesBtn.Name = "origFilesBtn";
            this.origFilesBtn.Size = new System.Drawing.Size(25, 20);
            this.origFilesBtn.TabIndex = 6;
            this.origFilesBtn.Text = "...";
            this.origFilesBtn.UseVisualStyleBackColor = true;
            this.origFilesBtn.Click += new System.EventHandler(this.origFilesBtn_Click);
            // 
            // tranFilesBtn
            // 
            this.tranFilesBtn.Location = new System.Drawing.Point(265, 111);
            this.tranFilesBtn.Name = "tranFilesBtn";
            this.tranFilesBtn.Size = new System.Drawing.Size(25, 20);
            this.tranFilesBtn.TabIndex = 9;
            this.tranFilesBtn.Text = "...";
            this.tranFilesBtn.UseVisualStyleBackColor = true;
            this.tranFilesBtn.Click += new System.EventHandler(this.tranFilesBtn_Click);
            // 
            // tranFilesBox
            // 
            this.tranFilesBox.Location = new System.Drawing.Point(102, 111);
            this.tranFilesBox.Name = "tranFilesBox";
            this.tranFilesBox.Size = new System.Drawing.Size(157, 20);
            this.tranFilesBox.TabIndex = 8;
            this.tranFilesBox.TextChanged += new System.EventHandler(this.tranFilesBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Translated Files:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "First File:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Last File:";
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(215, 222);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 17;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(134, 222);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 18;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // firstFileBox
            // 
            this.firstFileBox.Enabled = false;
            this.firstFileBox.FormattingEnabled = true;
            this.firstFileBox.Location = new System.Drawing.Point(102, 157);
            this.firstFileBox.Name = "firstFileBox";
            this.firstFileBox.Size = new System.Drawing.Size(188, 21);
            this.firstFileBox.TabIndex = 22;
            this.firstFileBox.DropDown += new System.EventHandler(this.firstFileBox_DropDown);
            // 
            // lastFileBox
            // 
            this.lastFileBox.Enabled = false;
            this.lastFileBox.FormattingEnabled = true;
            this.lastFileBox.Location = new System.Drawing.Point(102, 184);
            this.lastFileBox.Name = "lastFileBox";
            this.lastFileBox.Size = new System.Drawing.Size(188, 21);
            this.lastFileBox.TabIndex = 23;
            this.lastFileBox.DropDown += new System.EventHandler(this.lastFileBox_DropDown);
            // 
            // ProjectSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(302, 257);
            this.Controls.Add(this.lastFileBox);
            this.Controls.Add(this.firstFileBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tranFilesBtn);
            this.Controls.Add(this.tranFilesBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.origFilesBtn);
            this.Controls.Add(this.origFilesBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.projTypeBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.projNameBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ProjectSettings";
            this.Load += new System.EventHandler(this.ProjectSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox projNameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox projTypeBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox origFilesBox;
        private System.Windows.Forms.Button origFilesBtn;
        private System.Windows.Forms.Button tranFilesBtn;
        private System.Windows.Forms.TextBox tranFilesBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.ComboBox firstFileBox;
        private System.Windows.Forms.ComboBox lastFileBox;
    }
}