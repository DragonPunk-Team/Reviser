using System;
using System.Collections;
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

            listView.Items.Clear();

            string currentItem = fileListBox.SelectedItem.ToString();

            if (pf.project.files.ContainsKey(currentItem))
            {
                listView.BeginUpdate();

                foreach (ProjectFile.FileContent content in pf.project.files[currentItem].content)
                {
                    string[] row = { content.id, GetLine(content.character), GetLine(content.orig_line), GetLine(content.tran_line), content.proposal, pf.Comment(content.comment) };
                    listView.Items.Add(new ListViewItem(row));
                }

                listView.EndUpdate();
            }
        }

        private string GetLine(string[] strarr)
        {
            if (strarr.Length > 1)
                return strarr.Length + " lines";
            else
                return strarr[0];
        }

        private void newProjBtn_Click(object sender, EventArgs e)
        {
            ProjectSettings projectSettings = new ProjectSettings(true, null, this);
            projectSettings.Show();
        }

        private void projSettingsBtn_Click(object sender, EventArgs e)
        {
            ProjectSettings projectSettings = new ProjectSettings(false, pf);
            projectSettings.Show();
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems != null)
            {
                editLineBtn.Enabled = true;
                delLineBtn.Enabled = true;
            }
        }

        private void addLineBtn_Click(object sender, EventArgs e)
        {
            string currentFile = fileListBox.SelectedItem.ToString();

            LineEditor.LineData ld = new LineEditor.LineData()
            {
                newLine = true,
                currentFile = currentFile
            };
            
            LineEditor lineEditor = new LineEditor(ld);
            lineEditor.Show();
        }

        private void editLineBtn_Click(object sender, EventArgs e)
        {
            string currentFile = fileListBox.SelectedItem.ToString();
            string lineId = listView.SelectedItems[0].SubItems[0].Text;

            LineEditor.LineData ld = new LineEditor.LineData()
            {
                newLine = false,
                fc = pf.project.files[currentFile].content.Single(content => content.id.ToString() == lineId),
                lineId = lineId,
                currentFile = currentFile
            };

            LineEditor lineEditor = new LineEditor(ld);
            lineEditor.Show();
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            editLineBtn_Click(sender, e);
        }
    }
}
