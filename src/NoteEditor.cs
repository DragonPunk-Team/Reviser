using System;
using System.Windows.Forms;

namespace Reviser
{
    public partial class NoteEditor : Form
    {
        bool remove;
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
                cancelBtn.Text = "Remove";
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (cancelBtn.Text == "Remove")
                remove = true;
            else
                remove = false;

            CloseForm(false);
        }

        private void CloseForm(bool save)
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
