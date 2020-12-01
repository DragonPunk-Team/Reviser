using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Reviser
{
    public partial class MainForm : Form
    {
        private ProjectFile pf;

        public MainForm()
        {
            InitializeComponent();
        }

        private void EnableControls()
        {
            addLineBtn.Enabled = true;
            listView.Enabled = true;
            projSettingsBtn.Enabled = true;
            saveAsProjBtn.Enabled = true;
            saveProjBtn.Enabled = true;
        }

        public void Open(string filename)
        {
            pf = new ProjectFile()
            {
                path = filename
            };

            pf.GetProject();

            Text = "DragonPunk Reviser - " + pf.project.name;

            if (fileListBox.Items.Count > 0)
                fileListBox.Items.Clear();

            fileListBox.Items.AddRange(pf.project.file_list);
            fileListBox.SelectedIndex = 0;

            EnableControls();

            foreach (string file in pf.project.file_list)
            {
                if (pf.project.files.ContainsKey(file) && pf.project.files[file].complete)
                {
                    fileListBox.SetItemChecked(Array.IndexOf(pf.project.file_list, file), true);
                }
            }
        }

        private void openProjBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Open Project",
                Filter = "DragonPunk Reviser Project (*.dtr)|*.dtr"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Open(ofd.FileName);
            }
        }

        private void fileListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            editLineBtn.Enabled = false;
            delLineBtn.Enabled = false;

            ListViewUpdate();
        }

        private void newProjBtn_Click(object sender, EventArgs e)
        {
            ProjectSettings projectSettings = new ProjectSettings(true, mainf: this);
            projectSettings.ShowDialog();
        }

        private void projSettingsBtn_Click(object sender, EventArgs e)
        {
            ProjectSettings projectSettings = new ProjectSettings(false, pf, this);
            projectSettings.ShowDialog();
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems == null || listView.Items.Count == 0)
            {
                editLineBtn.Enabled = false;
                delLineBtn.Enabled = false;
            }
            else
            {
                editLineBtn.Enabled = true;
                delLineBtn.Enabled = true;
            }
        }

        private void addLineBtn_Click(object sender, EventArgs e)
        {
            string currentFile = fileListBox.SelectedItem.ToString();
            int currentId = -1;

            if (pf.project.files.ContainsKey(currentFile))
                currentId = pf.project.files[currentFile].content.Last().contentId;

            LineEditor.LineData ld = new LineEditor.LineData()
            {
                newLine = true,
                origPath = pf.project.orig_path,
                tranPath = pf.project.tran_path,
                currentFile = currentFile,
                lastContentId = currentId
            };

            OpenLineEditor(ld);
        }

        private void editLineBtn_Click(object sender, EventArgs e)
        {
            string currentFile = fileListBox.SelectedItem.ToString();
            string lineId = listView.SelectedItems[0].SubItems[0].Text;
            var item = pf.project.files[currentFile].content.Single(line => line.lineId == lineId);

            LineEditor.LineData ld = new LineEditor.LineData()
            {
                newLine = false,
                origPath = pf.project.orig_path,
                tranPath = pf.project.tran_path,
                fc = item,
                currentFile = currentFile,
                lastContentId = item.contentId
            };

            OpenLineEditor(ld);
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            editLineBtn_Click(sender, e);
        }

        private void OpenLineEditor(LineEditor.LineData ld)
        {
            LineEditor lineEditor = new LineEditor(ld);
            lineEditor.ShowDialog();

            string currentItem = fileListBox.SelectedItem.ToString();

            if (!pf.project.files.ContainsKey(currentItem))
            {
                ProjectFile.RevisedFile rf = new ProjectFile.RevisedFile
                {
                    complete = false,
                    content = new List<ProjectFile.FileContent>(),
                };

                pf.project.files.Add(currentItem, rf);
            }

            try
            {
                int contentId = lineEditor.newfc.contentId;
                var item = pf.project.files[currentItem].content.Single(line => line.contentId == contentId);

                if (pf.project.files[currentItem].content.Contains(item))
                    pf.project.files[currentItem].content.Remove(item);
            }
            catch (System.InvalidOperationException)
            {
                ;
            }

            ProjectFile.FileContent fc = new ProjectFile.FileContent
            {
                contentId = lineEditor.newfc.contentId,
                lineId = lineEditor.newfc.lineId,
                proposal = lineEditor.newfc.proposal,
                comment = lineEditor.newfc.comment
            };
            
            pf.project.files[currentItem].content.Add(fc);

            ListViewUpdate();
        }

        private void ListViewUpdate()
        {
            listView.Items.Clear();

            string currentItem = fileListBox.SelectedItem.ToString();

            if (pf.project.files.ContainsKey(currentItem))
            {
                listView.BeginUpdate();

                foreach (ProjectFile.FileContent content in pf.project.files[currentItem].content)
                {
                    string[] row = { content.lineId, content.proposal, pf.Comment(content.comment) };
                    listView.Items.Add(new ListViewItem(row));
                }

                listView.EndUpdate();
            }
        }

        private void delLineBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this line?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string currentItem = fileListBox.SelectedItem.ToString();
                string lineId = listView.SelectedItems[0].SubItems[0].Text;
                var item = pf.project.files[currentItem].content.Single(line => line.lineId == lineId);

                pf.project.files[currentItem].content.Remove(item);
                ListViewUpdate();

                listView_SelectedIndexChanged(sender, e);
            }
        }
    }
}
