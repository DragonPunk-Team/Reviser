namespace Reviser
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.AddLineButton = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newProjBtn = new System.Windows.Forms.ToolStripButton();
            this.openProjBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveProjBtn = new System.Windows.Forms.ToolStripButton();
            this.saveAsProjBtn = new System.Windows.Forms.ToolStripButton();
            this.fileListBox = new System.Windows.Forms.CheckedListBox();
            this.lineId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.character = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.origLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tranLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proposal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comment = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lineId,
            this.character,
            this.origLine,
            this.tranLine,
            this.proposal,
            this.comment});
            this.dataGrid.Enabled = false;
            this.dataGrid.Location = new System.Drawing.Point(138, 27);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(893, 405);
            this.dataGrid.TabIndex = 1;
            // 
            // AddLineButton
            // 
            this.AddLineButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddLineButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddLineButton.Location = new System.Drawing.Point(872, 438);
            this.AddLineButton.Name = "AddLineButton";
            this.AddLineButton.Size = new System.Drawing.Size(159, 42);
            this.AddLineButton.TabIndex = 2;
            this.AddLineButton.Text = "Add Line";
            this.AddLineButton.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjBtn,
            this.openProjBtn,
            this.toolStripSeparator1,
            this.saveProjBtn,
            this.saveAsProjBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1043, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newProjBtn
            // 
            this.newProjBtn.Image = ((System.Drawing.Image)(resources.GetObject("newProjBtn.Image")));
            this.newProjBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newProjBtn.Name = "newProjBtn";
            this.newProjBtn.Size = new System.Drawing.Size(91, 22);
            this.newProjBtn.Text = "New Project";
            // 
            // openProjBtn
            // 
            this.openProjBtn.Image = ((System.Drawing.Image)(resources.GetObject("openProjBtn.Image")));
            this.openProjBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openProjBtn.Name = "openProjBtn";
            this.openProjBtn.Size = new System.Drawing.Size(96, 22);
            this.openProjBtn.Text = "Open Project";
            this.openProjBtn.Click += new System.EventHandler(this.openProjBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // saveProjBtn
            // 
            this.saveProjBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveProjBtn.Image")));
            this.saveProjBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveProjBtn.Name = "saveProjBtn";
            this.saveProjBtn.Size = new System.Drawing.Size(91, 22);
            this.saveProjBtn.Text = "Save Project";
            // 
            // saveAsProjBtn
            // 
            this.saveAsProjBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveAsProjBtn.Image")));
            this.saveAsProjBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveAsProjBtn.Name = "saveAsProjBtn";
            this.saveAsProjBtn.Size = new System.Drawing.Size(116, 22);
            this.saveAsProjBtn.Text = "Save Project As...";
            // 
            // fileListBox
            // 
            this.fileListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.fileListBox.FormattingEnabled = true;
            this.fileListBox.Location = new System.Drawing.Point(12, 28);
            this.fileListBox.Name = "fileListBox";
            this.fileListBox.Size = new System.Drawing.Size(120, 454);
            this.fileListBox.TabIndex = 4;
            // 
            // lineId
            // 
            this.lineId.HeaderText = "Id";
            this.lineId.Name = "lineId";
            this.lineId.ReadOnly = true;
            this.lineId.Width = 40;
            // 
            // character
            // 
            this.character.HeaderText = "Character";
            this.character.Name = "character";
            this.character.ReadOnly = true;
            // 
            // origLine
            // 
            this.origLine.HeaderText = "Original Line";
            this.origLine.Name = "origLine";
            this.origLine.ReadOnly = true;
            this.origLine.Width = 200;
            // 
            // tranLine
            // 
            this.tranLine.HeaderText = "Translated Line";
            this.tranLine.Name = "tranLine";
            this.tranLine.ReadOnly = true;
            this.tranLine.Width = 200;
            // 
            // proposal
            // 
            this.proposal.HeaderText = "Proposal";
            this.proposal.Name = "proposal";
            this.proposal.Width = 250;
            // 
            // comment
            // 
            this.comment.HeaderText = "Comment";
            this.comment.Name = "comment";
            this.comment.Width = 60;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 492);
            this.Controls.Add(this.fileListBox);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.AddLineButton);
            this.Controls.Add(this.dataGrid);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DragonPunk Reviser";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button AddLineButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newProjBtn;
        private System.Windows.Forms.ToolStripButton openProjBtn;
        private System.Windows.Forms.ToolStripButton saveProjBtn;
        private System.Windows.Forms.ToolStripButton saveAsProjBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.CheckedListBox fileListBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineId;
        private System.Windows.Forms.DataGridViewTextBoxColumn character;
        private System.Windows.Forms.DataGridViewTextBoxColumn origLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn tranLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn proposal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn comment;
    }
}

