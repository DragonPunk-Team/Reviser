using System;
using System.Windows.Forms;

using Reviser.Files;

namespace Reviser.LE
{
    public partial class OtherLinesEditor : Form
    {
        private IFile origFile;
        private IFile tranFile;
        private OtherLines type;
        public string lineId;

        public OtherLinesEditor(OtherLines type, IFile origFile, IFile tranFile, string lineId)
        {
            InitializeComponent();

            this.origFile = origFile;
            this.tranFile = tranFile;
            this.type = type;
            this.lineId = lineId;
        }

        private void OtherLinesEditor_Load(object sender, EventArgs e)
        {
            if (lineId != "-1")
            {
                Text = WindowTitle(true);
                idBox.Text = lineId;
                removeBtn.Enabled = true;

                searchBtn_Click(sender, e);
            }
            else
            {
                Text = WindowTitle(false);
            }
        }

        private string WindowTitle(bool withLineID)
        {
            if (type == OtherLines.Previous)
                return withLineID ? Language.Strings.OtherLinesEditor_WindowTitle_Edit_Previous : Language.Strings.OtherLinesEditor_WindowTitle_Add_Previous;

            if (type == OtherLines.Next)
                return withLineID ? Language.Strings.OtherLinesEditor_WindowTitle_Edit_Next : Language.Strings.OtherLinesEditor_WindowTitle_Add_Next;

            return string.Empty;
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            idBox.Text = Utils.CleanIds(idBox.Text);
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
            lineId = idBox.Text;
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
