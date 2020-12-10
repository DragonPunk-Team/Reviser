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

            this.Text += file;
            this.note = note;
        }

        private void NoteEditor_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(note))
            {
                noteBox.Text = note;
                removeBtn.Enabled = true;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            CloseForm(save: false);
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            CloseForm(remove: false);
        }

        private void CloseForm(bool save = false, bool remove = false)
        {
            if (save)
                this.DialogResult = DialogResult.OK;
            else if (remove)
                this.DialogResult = DialogResult.Abort;
            else
                this.DialogResult = DialogResult.Cancel;

            this.Close();
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
            CloseForm(true);
        }
    }
}
