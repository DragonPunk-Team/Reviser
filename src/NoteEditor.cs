using System;
using System.Windows.Forms;

namespace Reviser
{
    public partial class NoteEditor : Form
    {
        public string note;

        public NoteEditor(string file, string note)
        {
            InitializeComponent();

            Text += file;
            this.note = note;
        }

        private void NoteEditor_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(note))
            {
                Text = Text.Replace("Add", "Edit");
                noteBox.Text = note;
                removeBtn.Enabled = true;
            }
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

        private void lineBox_TextChanged(object sender, EventArgs e)
        {
            CheckAddBtn();
        }

        private void CheckAddBtn()
        {
            if (string.IsNullOrWhiteSpace(noteBox.Text))
                addBtn.Enabled = false;
            else
                addBtn.Enabled = true;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            note = noteBox.Text;
            CloseForm(save: true);
        }
    }
}
