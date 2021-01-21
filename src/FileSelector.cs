using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Reviser
{
    public partial class FileSelector : Form
    {
        private string[] partialFileList;
        public string[] newFileList;

        public FileSelector(string[] pfl)
        {
            InitializeComponent();

            partialFileList = pfl;
        }

        private void FileSelector_Load(object sender, EventArgs e)
        {
            fileListBox.Items.AddRange(partialFileList);

            CheckAll(true);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void selectAllBtn_Click(object sender, EventArgs e)
        {
            CheckAll(true);
        }

        private void selectNoneBtn_Click(object sender, EventArgs e)
        {
            CheckAll(false);
        }

        private void CheckAll(bool value)
        {
            foreach (string item in partialFileList)
            {
                var index = fileListBox.Items.IndexOf(item);
                fileListBox.SetItemChecked(index, value);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            List<string> fileList = new List<string>();

            foreach (string item in fileListBox.CheckedItems)
                fileList.Add(item);

            newFileList = fileList.ToArray();

            DialogResult = DialogResult.OK;

            Close();
        }
    }
}
