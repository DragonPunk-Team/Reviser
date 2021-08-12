namespace Reviser
{
    partial class NoteEditor
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
            this.saveBtn = new System.Windows.Forms.Button();
            this.noteBox = new System.Windows.Forms.TextBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.removeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // saveBtn
            // 
            this.saveBtn.Enabled = false;
            this.saveBtn.Location = new System.Drawing.Point(339, 196);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 1;
            this.saveBtn.Text = Language.Strings.Generic_Save;
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // noteBox
            // 
            this.noteBox.AcceptsReturn = true;
            this.noteBox.Location = new System.Drawing.Point(12, 12);
            this.noteBox.Multiline = true;
            this.noteBox.Name = "noteBox";
            this.noteBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.noteBox.Size = new System.Drawing.Size(402, 178);
            this.noteBox.TabIndex = 0;
            this.noteBox.TextChanged += new System.EventHandler(this.lineBox_TextChanged);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(258, 196);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = Language.Strings.Generic_Cancel;
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // removeBtn
            // 
            this.removeBtn.Enabled = false;
            this.removeBtn.Location = new System.Drawing.Point(12, 196);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(75, 23);
            this.removeBtn.TabIndex = 7;
            this.removeBtn.Text = Language.Strings.Generic_Remove;
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // NoteEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(430, 226);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.noteBox);
            this.Controls.Add(this.saveBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NoteEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.NoteEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox noteBox;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button removeBtn;
    }
}