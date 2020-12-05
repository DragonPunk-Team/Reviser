using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Reviser
{
    public partial class InsertFileName : Form
    {
        public InsertFileName(string[] fl)
        {
            InitializeComponent();

            filelist = fl;
        }

        public string filename;
        string[] filelist;

        private void okButton_Click(object sender, EventArgs e)
        {
            if (fileComboBox.Text.Length != 0)
            {
                filename = fileComboBox.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
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
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
        }

        private void InsertFileName_Load(object sender, EventArgs e)
        {
            fileComboBox.Items.AddRange(filelist);
        }
    }
}
