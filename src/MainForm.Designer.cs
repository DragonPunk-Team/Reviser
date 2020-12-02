namespace Reviser
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.addLineBtn = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newProjBtn = new System.Windows.Forms.ToolStripButton();
            this.openProjBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveProjBtn = new System.Windows.Forms.ToolStripButton();
            this.saveAsProjBtn = new System.Windows.Forms.ToolStripButton();
            this.projSettingsBtn = new System.Windows.Forms.ToolStripButton();
            this.fileListBox = new System.Windows.Forms.CheckedListBox();
            this.listView = new System.Windows.Forms.ListView();
            this.lineId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.proposal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.editLineBtn = new System.Windows.Forms.Button();
            this.delLineBtn = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // addLineBtn
            // 
            this.addLineBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addLineBtn.Enabled = false;
            this.addLineBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addLineBtn.Location = new System.Drawing.Point(935, 449);
            this.addLineBtn.Name = "addLineBtn";
            this.addLineBtn.Size = new System.Drawing.Size(159, 42);
            this.addLineBtn.TabIndex = 2;
            this.addLineBtn.Text = "Add Line";
            this.addLineBtn.UseVisualStyleBackColor = true;
            this.addLineBtn.Click += new System.EventHandler(this.addLineBtn_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjBtn,
            this.openProjBtn,
            this.toolStripSeparator1,
            this.saveProjBtn,
            this.saveAsProjBtn,
            this.projSettingsBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1106, 25);
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
            this.newProjBtn.Click += new System.EventHandler(this.newProjBtn_Click);
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
            this.saveProjBtn.Enabled = false;
            this.saveProjBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveProjBtn.Image")));
            this.saveProjBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveProjBtn.Name = "saveProjBtn";
            this.saveProjBtn.Size = new System.Drawing.Size(91, 22);
            this.saveProjBtn.Text = "Save Project";
            this.saveProjBtn.Click += new System.EventHandler(this.saveProjBtn_Click);
            // 
            // saveAsProjBtn
            // 
            this.saveAsProjBtn.Enabled = false;
            this.saveAsProjBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveAsProjBtn.Image")));
            this.saveAsProjBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveAsProjBtn.Name = "saveAsProjBtn";
            this.saveAsProjBtn.Size = new System.Drawing.Size(116, 22);
            this.saveAsProjBtn.Text = "Save Project As...";
            this.saveAsProjBtn.Click += new System.EventHandler(this.saveAsProjBtn_Click);
            // 
            // projSettingsBtn
            // 
            this.projSettingsBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.projSettingsBtn.Enabled = false;
            this.projSettingsBtn.Image = ((System.Drawing.Image)(resources.GetObject("projSettingsBtn.Image")));
            this.projSettingsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.projSettingsBtn.Name = "projSettingsBtn";
            this.projSettingsBtn.Size = new System.Drawing.Size(109, 22);
            this.projSettingsBtn.Text = "Project Settings";
            this.projSettingsBtn.Click += new System.EventHandler(this.projSettingsBtn_Click);
            // 
            // fileListBox
            // 
            this.fileListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.fileListBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileListBox.FormattingEnabled = true;
            this.fileListBox.Location = new System.Drawing.Point(12, 28);
            this.fileListBox.Name = "fileListBox";
            this.fileListBox.Size = new System.Drawing.Size(222, 463);
            this.fileListBox.TabIndex = 4;
            this.fileListBox.SelectedIndexChanged += new System.EventHandler(this.fileListBox_SelectedIndexChanged);
            // 
            // listView
            // 
            this.listView.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.AutoArrange = false;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lineId,
            this.proposal,
            this.comment});
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(240, 28);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(854, 414);
            this.listView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView.TabIndex = 5;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            // 
            // lineId
            // 
            this.lineId.Text = "Line";
            this.lineId.Width = 50;
            // 
            // proposal
            // 
            this.proposal.Text = "Proposal";
            this.proposal.Width = 740;
            // 
            // comment
            // 
            this.comment.Text = "Comment";
            // 
            // editLineBtn
            // 
            this.editLineBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editLineBtn.Enabled = false;
            this.editLineBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editLineBtn.Location = new System.Drawing.Point(770, 449);
            this.editLineBtn.Name = "editLineBtn";
            this.editLineBtn.Size = new System.Drawing.Size(159, 42);
            this.editLineBtn.TabIndex = 6;
            this.editLineBtn.Text = "Edit Line";
            this.editLineBtn.UseVisualStyleBackColor = true;
            this.editLineBtn.Click += new System.EventHandler(this.editLineBtn_Click);
            // 
            // delLineBtn
            // 
            this.delLineBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.delLineBtn.Enabled = false;
            this.delLineBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delLineBtn.Location = new System.Drawing.Point(605, 449);
            this.delLineBtn.Name = "delLineBtn";
            this.delLineBtn.Size = new System.Drawing.Size(159, 42);
            this.delLineBtn.TabIndex = 7;
            this.delLineBtn.Text = "Delete Line";
            this.delLineBtn.UseVisualStyleBackColor = true;
            this.delLineBtn.Click += new System.EventHandler(this.delLineBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 502);
            this.Controls.Add(this.delLineBtn);
            this.Controls.Add(this.fileListBox);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.editLineBtn);
            this.Controls.Add(this.addLineBtn);
            this.MinimumSize = new System.Drawing.Size(591, 404);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DragonPunk Reviser";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button addLineBtn;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newProjBtn;
        private System.Windows.Forms.ToolStripButton openProjBtn;
        private System.Windows.Forms.ToolStripButton saveProjBtn;
        private System.Windows.Forms.ToolStripButton saveAsProjBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.CheckedListBox fileListBox;
        private System.Windows.Forms.ToolStripButton projSettingsBtn;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader lineId;
        private System.Windows.Forms.ColumnHeader proposal;
        private System.Windows.Forms.ColumnHeader comment;
        private System.Windows.Forms.Button editLineBtn;
        private System.Windows.Forms.Button delLineBtn;
    }
}

