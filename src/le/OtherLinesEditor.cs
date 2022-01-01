using System;
using System.Windows.Forms;

using Reviser.Files;

namespace Reviser.LE
{
    public partial class OtherLinesEditor : Form
    {
        IFile origFile;
        IFile tranFile;
        public string lineId;

        public OtherLinesEditor(IFile origFile, IFile tranFile, string lineId)
        {
            InitializeComponent();

            this.origFile = origFile;
            this.tranFile = tranFile;
            this.lineId = lineId;
        }

        private void OtherLinesEditor_Load(object sender, EventArgs e)
        {
            if (lineId != "-1")
            {
                Text = Language.Strings.PrevLinesEditor_WindowTitle_Edit;
                idBox.Text = lineId;
                removeBtn.Enabled = true;

                searchBtn_Click(sender, e);
            }
            else
            {
                Text = Language.Strings.PrevLinesEditor_WindowTitle_Add;
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            lineBox.Text = Utils.FormatLines(origFile, tranFile, idBox.Text, false);
            CheckAddBtn();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            CloseForm(remove: true);
        }

        private void CloseForm(bool save = false, bool remove = false)
        {
            if (save)
                DialogResult = DialogResult.OK;
            else if (remove)
                DialogResult = DialogResult.Abort;
            else
                DialogResult = DialogResult.Cancel;

            Close();
        }

        private void CheckAddBtn()
        {
            if (lineBox.Text.Contains($@"[{Language.Strings.Generic_Error}]") || string.IsNullOrWhiteSpace(lineBox.Text))
                addBtn.Enabled = false;
            else
                addBtn.Enabled = true;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            lineId = Utils.CleanIds(idBox.Text);
            CloseForm(save: true);
        }

        private void idBox_TextChanged(object sender, EventArgs e)
        {
            var f = Utils.FormatIds(idBox.Text, idBox.SelectionStart);

            idBox.Text = f.text;
            idBox.Select(f.cursor, 0);
        }
    }
}