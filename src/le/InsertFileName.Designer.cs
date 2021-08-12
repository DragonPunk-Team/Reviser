
namespace Reviser.LE
{
    partial class InsertFileName
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
            this.okButton = new System.Windows.Forms.Button();
            this.fileComboBox = new System.Windows.Forms.ComboBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.allFilesCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Enabled = false;
            this.okButton.Location = new System.Drawing.Point(111, 39);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(83, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = Language.Strings.Generic_OK;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // fileComboBox
            // 
            this.fileComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fileComboBox.FormattingEnabled = true;
            this.fileComboBox.Location = new System.Drawing.Point(12, 12);
            this.fileComboBox.Name = "fileComboBox";
            this.fileComboBox.Size = new System.Drawing.Size(182, 21);
            this.fileComboBox.TabIndex = 3;
            this.fileComboBox.SelectedIndexChanged += new System.EventHandler(this.fileComboBox_SelectedIndexChanged);
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(222, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(16, 16);
            this.closeButton.TabStop = false;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // allFilesCheckBox
            // 
            this.allFilesCheckBox.AutoSize = true;
            this.allFilesCheckBox.Location = new System.Drawing.Point(12, 43);
            this.allFilesCheckBox.Name = "allFilesCheckBox";
            this.allFilesCheckBox.Size = new System.Drawing.Size(58, 17);
            this.allFilesCheckBox.TabIndex = 5;
            this.allFilesCheckBox.Text = Language.Strings.InsertFileName_allFilesCheckBox;
            this.allFilesCheckBox.UseVisualStyleBackColor = true;
            this.allFilesCheckBox.CheckedChanged += new System.EventHandler(this.allFilesCheckBox_CheckedChanged);
            // 
            // InsertFileName
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(206, 71);
            this.Controls.Add(this.allFilesCheckBox);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.fileComboBox);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InsertFileName";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = Language.Strings.InsertFileName_WindowTitle;
            this.Load += new System.EventHandler(this.InsertFileName_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ComboBox fileComboBox;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.CheckBox allFilesCheckBox;
    }
}