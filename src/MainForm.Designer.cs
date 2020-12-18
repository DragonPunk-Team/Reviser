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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.addLineBtn = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newProjBtn = new System.Windows.Forms.ToolStripButton();
            this.openProjBtn = new System.Windows.Forms.ToolStripButton();
            this.saveProjBtn = new System.Windows.Forms.ToolStripSplitButton();
            this.saveProjectAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.generateReportBtn = new System.Windows.Forms.ToolStripButton();
            this.projSettingsBtn = new System.Windows.Forms.ToolStripButton();
            this.infoBtn = new System.Windows.Forms.ToolStripButton();
            this.fileListBox = new System.Windows.Forms.CheckedListBox();
            this.listView = new System.Windows.Forms.ListView();
            this.lineId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.proposal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.editLineBtn = new System.Windows.Forms.Button();
            this.delLineBtn = new System.Windows.Forms.Button();
            this.completeLabel = new System.Windows.Forms.Label();
            this.addNoteTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.addNoteBtn = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // addLineBtn
            // 
            this.addLineBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addLineBtn.Enabled = false;
            this.addLineBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addLineBtn.Location = new System.Drawing.Point(948, 460);
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
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjBtn,
            this.openProjBtn,
            this.saveProjBtn,
            this.toolStripSeparator1,
            this.generateReportBtn,
            this.projSettingsBtn,
            this.infoBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1082, 32);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newProjBtn
            // 
            this.newProjBtn.AutoSize = false;
            this.newProjBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newProjBtn.Image = global::Reviser.Properties.Resources.New_Project;
            this.newProjBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newProjBtn.Name = "newProjBtn";
            this.newProjBtn.Size = new System.Drawing.Size(32, 32);
            this.newProjBtn.Text = "New Project";
            this.newProjBtn.Click += new System.EventHandler(this.newProjBtn_Click);
            // 
            // openProjBtn
            // 
            this.openProjBtn.AutoSize = false;
            this.openProjBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openProjBtn.Image = global::Reviser.Properties.Resources.Open_Project;
            this.openProjBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openProjBtn.Name = "openProjBtn";
            this.openProjBtn.Size = new System.Drawing.Size(32, 32);
            this.openProjBtn.Text = "Open Project";
            this.openProjBtn.Click += new System.EventHandler(this.openProjBtn_Click);
            // 
            // saveProjBtn
            // 
            this.saveProjBtn.AutoSize = false;
            this.saveProjBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveProjBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveProjectAsToolStripMenuItem});
            this.saveProjBtn.Enabled = false;
            this.saveProjBtn.Image = global::Reviser.Properties.Resources.Save_Project;
            this.saveProjBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveProjBtn.Name = "saveProjBtn";
            this.saveProjBtn.Size = new System.Drawing.Size(43, 32);
            this.saveProjBtn.Text = "Save Project";
            this.saveProjBtn.ButtonClick += new System.EventHandler(this.saveProjBtn_ButtonClick);
            // 
            // saveProjectAsToolStripMenuItem
            // 
            this.saveProjectAsToolStripMenuItem.Name = "saveProjectAsToolStripMenuItem";
            this.saveProjectAsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.saveProjectAsToolStripMenuItem.Text = "Save Project As...";
            this.saveProjectAsToolStripMenuItem.Click += new System.EventHandler(this.saveProjectAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // generateReportBtn
            // 
            this.generateReportBtn.AutoSize = false;
            this.generateReportBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.generateReportBtn.Enabled = false;
            this.generateReportBtn.Image = global::Reviser.Properties.Resources.Generate_Report;
            this.generateReportBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.generateReportBtn.Name = "generateReportBtn";
            this.generateReportBtn.Size = new System.Drawing.Size(32, 32);
            this.generateReportBtn.Text = "Generate Report";
            this.generateReportBtn.Click += new System.EventHandler(this.generateReportBtn_Click);
            // 
            // projSettingsBtn
            // 
            this.projSettingsBtn.AutoSize = false;
            this.projSettingsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.projSettingsBtn.Enabled = false;
            this.projSettingsBtn.Image = global::Reviser.Properties.Resources.Project_Settings;
            this.projSettingsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.projSettingsBtn.Name = "projSettingsBtn";
            this.projSettingsBtn.Size = new System.Drawing.Size(32, 32);
            this.projSettingsBtn.Text = "Project Settings";
            this.projSettingsBtn.Click += new System.EventHandler(this.projSettingsBtn_Click);
            // 
            // infoBtn
            // 
            this.infoBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.infoBtn.AutoSize = false;
            this.infoBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.infoBtn.Image = global::Reviser.Properties.Resources.Info;
            this.infoBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.infoBtn.Name = "infoBtn";
            this.infoBtn.Size = new System.Drawing.Size(32, 32);
            this.infoBtn.ToolTipText = "Info";
            this.infoBtn.Click += new System.EventHandler(this.infoBtn_Click);
            // 
            // fileListBox
            // 
            this.fileListBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.fileListBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileListBox.FormattingEnabled = true;
            this.fileListBox.Location = new System.Drawing.Point(0, 32);
            this.fileListBox.Name = "fileListBox";
            this.fileListBox.Size = new System.Drawing.Size(222, 480);
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
            this.listView.Location = new System.Drawing.Point(228, 32);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(854, 418);
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
            this.editLineBtn.Location = new System.Drawing.Point(814, 460);
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
            this.delLineBtn.Location = new System.Drawing.Point(680, 460);
            this.delLineBtn.Name = "delLineBtn";
            this.delLineBtn.Size = new System.Drawing.Size(128, 42);
            this.delLineBtn.TabIndex = 7;
            this.delLineBtn.Text = "Delete Line";
            this.delLineBtn.UseVisualStyleBackColor = true;
            this.delLineBtn.Click += new System.EventHandler(this.delLineBtn_Click);
            // 
            // completeLabel
            // 
            this.completeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.completeLabel.BackColor = System.Drawing.Color.Transparent;
            this.completeLabel.Enabled = false;
            this.completeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completeLabel.Location = new System.Drawing.Point(680, 460);
            this.completeLabel.Name = "completeLabel";
            this.completeLabel.Size = new System.Drawing.Size(396, 42);
            this.completeLabel.TabIndex = 8;
            this.completeLabel.Text = "This file was marked as complete.\r\nIf you want to edit it, untick it from the fil" +
    "e list.";
            this.completeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.completeLabel.Visible = false;
            // 
            // addNoteBtn
            // 
            this.addNoteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addNoteBtn.Enabled = false;
            this.addNoteBtn.Image = global::Reviser.Properties.Resources.Add_Note;
            this.addNoteBtn.Location = new System.Drawing.Point(228, 460);
            this.addNoteBtn.Name = "addNoteBtn";
            this.addNoteBtn.Size = new System.Drawing.Size(42, 42);
            this.addNoteBtn.TabIndex = 9;
            this.addNoteTooltip.SetToolTip(this.addNoteBtn, "Add Note");
            this.addNoteBtn.UseVisualStyleBackColor = true;
            this.addNoteBtn.Click += new System.EventHandler(this.addNoteBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 512);
            this.Controls.Add(this.addNoteBtn);
            this.Controls.Add(this.completeLabel);
            this.Controls.Add(this.delLineBtn);
            this.Controls.Add(this.fileListBox);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.editLineBtn);
            this.Controls.Add(this.addLineBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(695, 404);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DragonPunk Reviser";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button addLineBtn;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newProjBtn;
        private System.Windows.Forms.ToolStripButton openProjBtn;
        private System.Windows.Forms.CheckedListBox fileListBox;
        private System.Windows.Forms.ToolStripButton projSettingsBtn;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader lineId;
        private System.Windows.Forms.ColumnHeader proposal;
        private System.Windows.Forms.ColumnHeader comment;
        private System.Windows.Forms.Button editLineBtn;
        private System.Windows.Forms.Button delLineBtn;
        private System.Windows.Forms.ToolStripButton generateReportBtn;
        private System.Windows.Forms.Label completeLabel;
        private System.Windows.Forms.Button addNoteBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton saveProjBtn;
        private System.Windows.Forms.ToolStripMenuItem saveProjectAsToolStripMenuItem;
        private System.Windows.Forms.ToolTip addNoteTooltip;
        private System.Windows.Forms.ToolStripButton infoBtn;
    }
}

