using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace Reviser
{
    public partial class MainForm : Form
    {
        private ProjectFile pf;

        public MainForm()
        {
            InitializeComponent();

            toolStrip1.Renderer = new ToolStripOverride();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FileAssociations.EnsureAssociationsSet();

            string[] args = Environment.GetCommandLineArgs();

            if (args.Length > 1)
                Open(args[1]);
        }

        private void EnableControls()
        {
            addLineBtn.Enabled = true;
            addNoteBtn.Enabled = true;
            listView.Enabled = true;
            projSettingsBtn.Enabled = true;
            saveProjBtn.Enabled = true;
            generateReportBtn.Enabled = true;
        }

        public void Open(string filename)
        {
            pf = new ProjectFile()
            {
                path = filename
            };

            pf.ReadProject();

            Text = "DragonPunk Reviser - " + pf.project.name;

            fileListBox.BeginUpdate();

            if (fileListBox.Items.Count > 0)
                fileListBox.Items.Clear();

            fileListBox.Items.AddRange(pf.project.file_list);
            fileListBox.SelectedIndex = 0;

            EnableControls();

            fileListBox.ItemCheck -= fileListBox_ItemCheck;

            foreach (string file in pf.project.file_list)
                if (pf.project.files.ContainsKey(file) && pf.project.files[file].complete)
                    fileListBox.SetItemChecked(Array.IndexOf(pf.project.file_list, file), true);

            foreach (var item in fileListBox.Items)
            {
                if (!fileListBox.CheckedItems.Contains(item))
                {
                    fileListBox.SelectedItem = item;
                    break;
                }
            }

            fileListBox.EndUpdate();

            if (fileListBox.CheckedItems.Contains(fileListBox.SelectedItem))
            {
                listView.Enabled = false;
                addLineBtn.Enabled = false;
                addNoteBtn.Enabled = false;
                completeLabel.Visible = true;
            }
            else
            {
                listView.Enabled = true;
                addLineBtn.Enabled = true;
                addNoteBtn.Enabled = true;
                completeLabel.Visible = false;
            }

            fileListBox.ItemCheck += fileListBox_ItemCheck;
        }

        private void openProjBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Open Project",
                Filter = "DragonPunk Reviser Project (*.drpj)|*.drpj"
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

            if (fileListBox.CheckedItems.Contains(fileListBox.SelectedItem))
            {
                listView.Enabled = false;
                addLineBtn.Enabled = false;
                addNoteBtn.Enabled = false;
                completeLabel.Visible = true;
            }
            else
            {
                listView.Enabled = true;
                addLineBtn.Enabled = true;
                addNoteBtn.Enabled = true;
                completeLabel.Visible = false;
            }

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
            if (listView.SelectedItems.Count <= 0 || listView.Items.Count <= 0)
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
                foreach (var content in pf.project.files[currentFile].content)
                    if (content.contentId > currentId)
                        currentId = content.contentId;

            LineEditor.LineData ld = new LineEditor.LineData()
            {
                newLine = true,
                origPath = pf.project.orig_path,
                tranPath = pf.project.tran_path,
                currentFile = currentFile,
                lastContentId = currentId,
                filelist = pf.project.file_list
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
                lastContentId = item.contentId,
                filelist = pf.project.file_list
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

            if (lineEditor.ShowDialog() == DialogResult.OK)
            {
                string currentItem = fileListBox.SelectedItem.ToString();

                if (!pf.project.files.ContainsKey(currentItem))
                {
                    ProjectFile.RevisedFile rf = new ProjectFile.RevisedFile
                    {
                        complete = false,
                        note = "",
                        content = new List<ProjectFile.FileContent>(),
                    };

                    pf.project.files.Add(currentItem, rf);
                }

                int contentId = lineEditor.newfc.contentId;

                if (pf.project.files[currentItem].content.FindIndex(line => line.contentId == contentId) != -1)
                {
                    var item = pf.project.files[currentItem].content.Single(line => line.contentId == contentId);

                    if (pf.project.files[currentItem].content.Contains(item))
                        pf.project.files[currentItem].content.Remove(item);
                }

                ProjectFile.FileContent fc = new ProjectFile.FileContent
                {
                    contentId = lineEditor.newfc.contentId,
                    lineId = lineEditor.newfc.lineId,
                    proposal = lineEditor.newfc.proposal,
                    prevLineId = lineEditor.newfc.prevLineId,
                    comment = lineEditor.newfc.comment,
                    color = lineEditor.newfc.color
                };

                pf.project.files[currentItem].content.Add(fc);

                ListViewUpdate();
            }
        }

        private void ListViewUpdate()
        {
            listView.BeginUpdate();

            listView.Items.Clear();

            string currentItem = fileListBox.SelectedItem.ToString();

            if (pf.project.files.ContainsKey(currentItem))
            {
                foreach (ProjectFile.FileContent content in pf.project.files[currentItem].content)
                {
                    string[] row = { content.lineId, content.proposal.Replace("\r\n", " "), pf.Comment(content.comment) };
                    listView.Items.Add(new ListViewItem(row) { Tag = content.lineId });
                }
            }

            listView.ListViewItemSorter = new CustomListViewSort();

            listView.EndUpdate();
        }

        private void delLineBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this line?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string currentItem = fileListBox.SelectedItem.ToString();
                string lineId = listView.SelectedItems[0].SubItems[0].Text;
                var item = pf.project.files[currentItem].content.Single(line => line.lineId == lineId);

                pf.project.files[currentItem].content.Remove(item);

                if (pf.project.files[currentItem].content.Count == 0)
                    pf.project.files.Remove(currentItem);

                ListViewUpdate();

                listView_SelectedIndexChanged(sender, e);
            }
        }

        private void saveProjBtn_ButtonClick(object sender, EventArgs e)
        {
            pf.WriteProject();
            SystemSounds.Beep.Play();
        }

        private void saveProjectAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Title = "Save Project",
                Filter = "DragonPunk Reviser Project (*.drpj)|*.drpj",
                FileName = pf.project.name
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var currentPath = pf.path;
                pf.path = sfd.FileName;

                pf.WriteProject();

                if (MessageBox.Show("Do you want to open the new copy of the project now?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    Open(sfd.FileName);
                else
                    pf.path = currentPath;
            }
        }

        private void generateReportBtn_Click(object sender, EventArgs e)
        {
            GenerateReport gr = new GenerateReport(pf);

            if (!gr.ProjectEmpty())
            {
                SaveFileDialog sfd = new SaveFileDialog()
                {
                    Title = "Select report destination",
                    Filter = "Markdown File (*.md)|*.md",
                    FileName = pf.project.name
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    gr.path = sfd.FileName;
                    gr.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("You can't generate a report right now, since the project is empty.", "Error", MessageBoxButtons.OK);
            }
        }

        private void fileListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var item = fileListBox.SelectedItem.ToString();

            if (e.NewValue == CheckState.Checked)
            {
                DialogResult dr = DialogResult.Yes;

                if (pf.project.files.ContainsKey(item))
                    if (pf.project.files[item].content.Count > 0)
                        dr = MessageBox.Show("Are you sure you want to mark this file as complete?\nThis operation CAN be undone.", "Warning", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    if (pf.project.files.ContainsKey(item))
                        pf.project.files[item].complete = true;

                    listView.Enabled = false;
                    addLineBtn.Enabled = false;
                    addNoteBtn.Enabled = false;
                    completeLabel.Visible = true;
                }
                else
                {
                    e.NewValue = CheckState.Unchecked;
                }
            }
            else
            {
                DialogResult dr = DialogResult.Yes;

                if (pf.project.files.ContainsKey(item))
                    if (pf.project.files[item].content.Count > 0)
                        dr = MessageBox.Show("Are you sure you want to mark this file as not complete?\nThis operation CAN be undone.", "Warning", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    if (pf.project.files.ContainsKey(item))
                        pf.project.files[item].complete = false;

                    listView.Enabled = true;
                    addLineBtn.Enabled = true;
                    addNoteBtn.Enabled = true;
                    completeLabel.Visible = false;
                }
                else
                {
                    e.NewValue = CheckState.Checked;
                }
            }
        }

        private void addNoteBtn_Click(object sender, EventArgs e)
        {
            string currentFile = fileListBox.SelectedItem.ToString();

            if (!pf.project.files.ContainsKey(currentFile))
            {
                ProjectFile.RevisedFile rf = new ProjectFile.RevisedFile
                {
                    complete = false,
                    note = "",
                    content = new List<ProjectFile.FileContent>(),
                };

                pf.project.files.Add(currentFile, rf);
            }

            NoteEditor ne = new NoteEditor(currentFile, pf.project.files[currentFile].note);
            DialogResult dr = ne.ShowDialog();

            if (dr == DialogResult.OK)
            {
                pf.project.files[currentFile].note = ne.note;
            }
            else if (dr == DialogResult.Abort)
            {
                pf.project.files[currentFile].note = "";
            }
        }

        private void infoBtn_Click(object sender, EventArgs e)
        {
            InfoForm info = new InfoForm();
            info.ShowDialog();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            var lineWidth = listView.Columns[0].Width;
            var commentWidth = listView.Columns[2].Width;

            listView.Columns[1].Width = listView.Width - (lineWidth + commentWidth + 5);
        }
    }
}
