namespace Reviser
{
    partial class InfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoForm));
            this.titleVersionLabel = new System.Windows.Forms.Label();
            this.authorLabel = new System.Windows.Forms.Label();
            this.programIconLinkLabel = new System.Windows.Forms.LinkLabel();
            this.colorIconsLinkLabel = new System.Windows.Forms.LinkLabel();
            this.jsonParserLinkButton = new System.Windows.Forms.LinkLabel();
            this.closeButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // titleVersionLabel
            // 
            this.titleVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleVersionLabel.Location = new System.Drawing.Point(13, 102);
            this.titleVersionLabel.Name = "titleVersionLabel";
            this.titleVersionLabel.Size = new System.Drawing.Size(237, 23);
            this.titleVersionLabel.TabIndex = 1;
            this.titleVersionLabel.Text = "DragonPunk Reviser 1.0.8";
            this.titleVersionLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // authorLabel
            // 
            this.authorLabel.Location = new System.Drawing.Point(17, 125);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(233, 17);
            this.authorLabel.TabIndex = 2;
            this.authorLabel.Text = "by Dj_Mike238";
            this.authorLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // programIconLinkLabel
            // 
            this.programIconLinkLabel.LinkArea = new System.Windows.Forms.LinkArea(16, 7);
            this.programIconLinkLabel.Location = new System.Drawing.Point(12, 155);
            this.programIconLinkLabel.Name = "programIconLinkLabel";
            this.programIconLinkLabel.Size = new System.Drawing.Size(238, 16);
            this.programIconLinkLabel.TabIndex = 3;
            this.programIconLinkLabel.TabStop = true;
            this.programIconLinkLabel.Text = "Program icon by Freepik on Flaticon";
            this.programIconLinkLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.programIconLinkLabel.UseCompatibleTextRendering = true;
            this.programIconLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // colorIconsLinkLabel
            // 
            this.colorIconsLinkLabel.LinkArea = new System.Windows.Forms.LinkArea(15, 6);
            this.colorIconsLinkLabel.Location = new System.Drawing.Point(12, 171);
            this.colorIconsLinkLabel.Name = "colorIconsLinkLabel";
            this.colorIconsLinkLabel.Size = new System.Drawing.Size(238, 16);
            this.colorIconsLinkLabel.TabIndex = 4;
            this.colorIconsLinkLabel.TabStop = true;
            this.colorIconsLinkLabel.Text = "Color icons by Icons8.";
            this.colorIconsLinkLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.colorIconsLinkLabel.UseCompatibleTextRendering = true;
            this.colorIconsLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // jsonParserLinkButton
            // 
            this.jsonParserLinkButton.LinkArea = new System.Windows.Forms.LinkArea(15, 10);
            this.jsonParserLinkButton.Location = new System.Drawing.Point(12, 198);
            this.jsonParserLinkButton.Name = "jsonParserLinkButton";
            this.jsonParserLinkButton.Size = new System.Drawing.Size(238, 16);
            this.jsonParserLinkButton.TabIndex = 6;
            this.jsonParserLinkButton.TabStop = true;
            this.jsonParserLinkButton.Text = "JSON Parser by NewtonSoft.";
            this.jsonParserLinkButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.jsonParserLinkButton.UseCompatibleTextRendering = true;
            this.jsonParserLinkButton.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(279, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(16, 16);
            this.closeButton.TabIndex = 0;
            this.closeButton.TabStop = false;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::Reviser.Properties.Resources.Reviser;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(238, 83);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // InfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(263, 221);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.jsonParserLinkButton);
            this.Controls.Add(this.colorIconsLinkLabel);
            this.Controls.Add(this.programIconLinkLabel);
            this.Controls.Add(this.authorLabel);
            this.Controls.Add(this.titleVersionLabel);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InfoForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Info";
            this.Load += new System.EventHandler(this.InfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label titleVersionLabel;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.LinkLabel programIconLinkLabel;
        private System.Windows.Forms.LinkLabel colorIconsLinkLabel;
        private System.Windows.Forms.LinkLabel jsonParserLinkButton;
        private System.Windows.Forms.Button closeButton;
    }
}