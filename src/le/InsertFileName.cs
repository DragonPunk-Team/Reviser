using System;
using System.IO;
using System.Windows.Forms;

namespace Reviser.LE
{
    public partial class InsertFileName : Form
    {
        public string filename;
        string[] filelist;
        string path;

        public InsertFileName(string[] filelist, string path)
        {
            InitializeComponent();

            this.filelist = filelist;
            this.path = path;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(fileComboBox.Text))
            {
                filename = fileComboBox.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void InsertFileName_Load(object sender, EventArgs e)
        {
            fileComboBox.Items.AddRange(filelist);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void allFilesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            fileComboBox.Items.Clear();

            if (allFilesCheckBox.Checked)
                foreach (var file in Directory.GetFiles(path))
                    fileComboBox.Items.Add(Path.GetFileName(file));
            else
                fileComboBox.Items.AddRange(filelist);

            fileComboBox.Enabled = fileComboBox.Items.Count > 0;
            okButton.Enabled = false;
        }

        private void fileComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            okButton.Enabled = !string.IsNullOrEmpty(fileComboBox.Text);
        }
    }
}
