using System.Windows.Forms;

namespace Reviser
{
    partial class FileSelector
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
            this.selectAllBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.selectNoneBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.fileListBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // selectAllBtn
            // 
            this.selectAllBtn.Location = new System.Drawing.Point(13, 226);
            this.selectAllBtn.Name = "selectAllBtn";
            this.selectAllBtn.Size = new System.Drawing.Size(45, 23);
            this.selectAllBtn.TabIndex = 0;
            this.selectAllBtn.Text = "All";
            this.selectAllBtn.UseVisualStyleBackColor = true;
            this.selectAllBtn.Click += new System.EventHandler(this.selectAllBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(215, 226);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 2;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // selectNoneBtn
            // 
            this.selectNoneBtn.Location = new System.Drawing.Point(64, 226);
            this.selectNoneBtn.Name = "selectNoneBtn";
            this.selectNoneBtn.Size = new System.Drawing.Size(45, 23);
            this.selectNoneBtn.TabIndex = 3;
            this.selectNoneBtn.Text = "None";
            this.selectNoneBtn.UseVisualStyleBackColor = true;
            this.selectNoneBtn.Click += new System.EventHandler(this.selectNoneBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(134, 226);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // fileListBox
            // 
            this.fileListBox.CheckOnClick = true;
            this.fileListBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileListBox.FormattingEnabled = true;
            this.fileListBox.Location = new System.Drawing.Point(12, 12);
            this.fileListBox.Name = "fileListBox";
            this.fileListBox.Size = new System.Drawing.Size(278, 208);
            this.fileListBox.TabIndex = 5;
            // 
            // FileSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(302, 257);
            this.Controls.Add(this.fileListBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.selectNoneBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.selectAllBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileSelector";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select files";
            this.Load += new System.EventHandler(this.FileSelector_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button selectAllBtn;
        private Button okBtn;
        private Button selectNoneBtn;
        private Button cancelBtn;
        private CheckedListBox fileListBox;
    }
}