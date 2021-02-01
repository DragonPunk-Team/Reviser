using System;
using System.IO;
using System.Windows.Forms;

namespace Reviser
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
            if (fileComboBox.Text.Length != 0)
            {
                filename = fileComboBox.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                DialogResult dr = MessageBox.Show("Select a file to continue.", null, MessageBoxButtons.OKCancel);

                if (dr == DialogResult.OK)
                {
                    fileComboBox.Text = "";
                }
                else if (dr == DialogResult.Cancel)
                {
                    DialogResult = dr;
                    Close();
                }
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
                foreach (string file in Directory.GetFiles(path))
                    fileComboBox.Items.Add(Path.GetFileName(file));
            else
                fileComboBox.Items.AddRange(filelist);

            if (fileComboBox.Items.Count > 0)
                fileComboBox.Enabled = true;
            else
                fileComboBox.Enabled = false;
        }
    }
}
