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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openProjBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.saveProjBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveAsProjBtn = new System.Windows.Forms.ToolStripButton();
            this.projSettingsBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.generateReportBtn = new System.Windows.Forms.ToolStripButton();
            this.fileListBox = new System.Windows.Forms.CheckedListBox();
            this.listView = new System.Windows.Forms.ListView();
            this.lineId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.proposal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.editLineBtn = new System.Windows.Forms.Button();
            this.delLineBtn = new System.Windows.Forms.Button();
            this.completeLabel = new System.Windows.Forms.Label();
            this.addNoteBtn = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // addLineBtn
            // 
            this.addLineBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addLineBtn.Enabled = false;
            this.addLineBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addLineBtn.Location = new System.Drawing.Point(966, 436);
            this.addLineBtn.Name = "addLineBtn";
            this.addLineBtn.Size = new System.Drawing.Size(128, 42);
            this.addLineBtn.TabIndex = 2;
            this.addLineBtn.Text = "Add Line";
            this.addLineBtn.UseVisualStyleBackColor = true;
            this.addLineBtn.Click += new System.EventHandler(this.addLineBtn_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjBtn,
            this.toolStripSeparator1,
            this.openProjBtn,
            this.toolStripSeparator4,
            this.saveProjBtn,
            this.toolStripSeparator3,
            this.saveAsProjBtn,
            this.projSettingsBtn,
            this.toolStripSeparator2,
            this.generateReportBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // generateReportBtn
            // 
            this.generateReportBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.generateReportBtn.Enabled = false;
            this.generateReportBtn.Image = ((System.Drawing.Image)(resources.GetObject("generateReportBtn.Image")));
            this.generateReportBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.generateReportBtn.Name = "generateReportBtn";
            this.generateReportBtn.Size = new System.Drawing.Size(112, 22);
            this.generateReportBtn.Text = "Generate Report";
            this.generateReportBtn.Click += new System.EventHandler(this.generateReportBtn_Click);
            // 
            // fileListBox
            // 
            this.fileListBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.fileListBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileListBox.FormattingEnabled = true;
            this.fileListBox.Location = new System.Drawing.Point(0, 25);
            this.fileListBox.Name = "fileListBox";
            this.fileListBox.Size = new System.Drawing.Size(222, 463);
            this.fileListBox.TabIndex = 4;
            this.fileListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.fileListBox_ItemCheck);
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
            this.listView.Location = new System.Drawing.Point(228, 25);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(866, 401);
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
            this.editLineBtn.Location = new System.Drawing.Point(832, 436);
            this.editLineBtn.Name = "editLineBtn";
            this.editLineBtn.Size = new System.Drawing.Size(128, 42);
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
            this.delLineBtn.Location = new System.Drawing.Point(698, 436);
            this.delLineBtn.Name = "delLineBtn";
            this.delLineBtn.Size = new System.Drawing.Size(128, 42);
            this.delLineBtn.TabIndex = 7;
            this.delLineBtn.Text = "Delete Line";
            this.delLineBtn.UseVisualStyleBackColor = true;
            this.delLineBtn.Click += new System.EventHandler(this.delLineBtn_Click);
            // 
            // completeLabel
            // 
            this.completeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.completeLabel.BackColor = System.Drawing.Color.Transparent;
            this.completeLabel.Enabled = false;
            this.completeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completeLabel.Location = new System.Drawing.Point(276, 436);
            this.completeLabel.Name = "completeLabel";
            this.completeLabel.Size = new System.Drawing.Size(416, 42);
            this.completeLabel.TabIndex = 8;
            this.completeLabel.Text = "This file was marked as complete.\r\nIf you want to edit it, untick it from the fil" +
    "e list.";
            this.completeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.completeLabel.Visible = false;
            // 
            // addNoteBtn
            // 
            this.addNoteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addNoteBtn.Location = new System.Drawing.Point(228, 436);
            this.addNoteBtn.Name = "addNoteBtn";
            this.addNoteBtn.Size = new System.Drawing.Size(42, 42);
            this.addNoteBtn.TabIndex = 9;
            this.addNoteBtn.UseVisualStyleBackColor = true;
            this.addNoteBtn.Click += new System.EventHandler(this.addNoteBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 488);
            this.Controls.Add(this.addNoteBtn);
            this.Controls.Add(this.completeLabel);
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton generateReportBtn;
        private System.Windows.Forms.Label completeLabel;
        private System.Windows.Forms.Button addNoteBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}

