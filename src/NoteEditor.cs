using System;
using System.Windows.Forms;

namespace Reviser
{
    public partial class NoteEditor : Form
    {
        public string note;
        private string file;

        public NoteEditor(string file, string note)
        {
            InitializeComponent();

            this.note = note;
            this.file = file;
        }

        private void NoteEditor_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(note))
            {
                Text = @$"{Language.Strings.NoteEditor_WindowTitle_Edit} {file}";
                noteBox.Text = note;
                removeBtn.Enabled = true;
            }
            else
            {
                Text = @$"{Language.Strings.NoteEditor_WindowTitle_Add} {file}";
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
            saveBtn.Enabled = !string.IsNullOrWhiteSpace(noteBox.Text);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            note = noteBox.Text;
            CloseForm(save: true);
        }
    }
}
