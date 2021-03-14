using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Reviser
{
    public partial class FileSelector : Form
    {
        private string[] partialFileList;
        private string[] originalFileList;
        public string[] newFileList;

        public FileSelector(string[] pfl, string[] ofl = null)
        {
            InitializeComponent();

            partialFileList = pfl;
            originalFileList = ofl;
        }

        private void FileSelector_Load(object sender, EventArgs e)
        {
            fileListBox.Items.AddRange(partialFileList);

            if (originalFileList == null)
                CheckAll(true);
            else
                CheckOriginalFiles();
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

        private void CheckOriginalFiles()
        {
            foreach (string item in partialFileList)
            {
                if (originalFileList.Contains(item))
                {
                    var index = fileListBox.Items.IndexOf(item);
                    fileListBox.SetItemChecked(index, true);
                }
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
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
