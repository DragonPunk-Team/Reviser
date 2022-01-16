using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using Reviser.LE;
using Reviser.Tweaks;

namespace Reviser
{
    public partial class MainForm : Form
    {
        private ProjectFile pf;
        private bool fileChanged;
        private MouseButtons mouse;

        public MainForm()
        {
            InitializeComponent();

            FileAssociations.EnsureAssociationsSet();

            toolStrip.Renderer = new ToolStripOverride();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var args = Environment.GetCommandLineArgs();

            if (args.Length > 1)
                Open(args[1]);
        }

        private void EnableControls()
        {
            addLineBtn.Enabled = true;
            addNoteBtn.Enabled = true;
            projSettingsBtn.Enabled = true;
            saveProjBtn.Enabled = true;
            generateReportBtn.Enabled = true;
        }

        public void Open(string filename)
        {
            pf = new ProjectFile() { path = filename };

            pf.ReadProject();

            CheckDirectories(pf.project.orig_path, pf.project.tran_path);
        }

        private void LoadProject()
        {
            Text = string.Format($@"{pf.project.name} - {Language.Strings.MainForm_WindowTitle}");

            fileListBox.BeginUpdate();

            if (fileListBox.Items.Count > 0)
                fileListBox.Items.Clear();

            fileListBox.Items.AddRange(pf.project.file_list);
            fileListBox.SelectedIndex = 0;

            EnableControls();

            fileListBox.ItemCheck -= fileListBox_ItemCheck;

            foreach (var file in pf.project.file_list)
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

            CompleteToggle(fileListBox.CheckedItems.Contains(fileListBox.SelectedItem));

            fileListBox.ItemCheck += fileListBox_ItemCheck;

            SetFileChanged(false);
        }

        private string PathError(bool orig, bool tran)
        {
            if (!orig && !tran)
                return Language.Strings.MainForm_PathErrorOrigTran;
            
            if (!orig)
                return Language.Strings.MainForm_PathErrorOrig;
            
            if (!tran)
                return Language.Strings.MainForm_PathErrorTran;

            return string.Empty;
        }

        private void CheckDirectories(string origPath, string tranPath)
        {
            var orig = Directory.Exists(origPath);
            var tran = Directory.Exists(tranPath);

            if (orig && tran)
            {
                LoadProject();
            }
            else
            {
                var msgdr = MessageBox.Show(PathError(orig, tran), Language.Strings.Generic_Error, MessageBoxButtons.OKCancel);

                if (msgdr == DialogResult.OK)
                {
                    var projectSettings = new ProjectSettings(false, true, pf, this) { StartPosition = FormStartPosition.CenterScreen };
                    var psdr = projectSettings.ShowDialog();

                    if (psdr == DialogResult.OK)
                    {
                        LoadProject();
                        return;
                    }
                }

                pf = null;
            }
        }

        private void openProjBtn_Click(object sender, EventArgs e)
        {
            CheckUnsaved();

            var ofd = new OpenFileDialog
            {
                Title = Language.Strings.MainForm_OpenProject,
                Filter = $@"{Language.Strings.Generic_ProjectFileType} (*.drpj)|*.drpj"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
                Open(ofd.FileName);
        }

        private void fileListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = fileListBox.SelectedItem;

            editLineBtn.Enabled = false;
            delLineBtn.Enabled = false;

            CompleteToggle(fileListBox.CheckedItems.Contains(item));

            ChangeNoteIcon(item.ToString());
            ListViewUpdate();
            ResizeListView();
        }

        private void newProjBtn_Click(object sender, EventArgs e)
        {
            CheckUnsaved();

            var projectSettings = new ProjectSettings(true, false, mainf: this);
            projectSettings.ShowDialog();
        }

        private void projSettingsBtn_Click(object sender, EventArgs e)
        {
            var projectSettings = new ProjectSettings(false, false, pf, this);
            projectSettings.ShowDialog();
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!fileListBox.CheckedItems.Contains(fileListBox.SelectedItem))
            {
                if (listView.SelectedItems.Count <= 0 || listView.Items.Count <= 0)
                {
                    editLineBtn.Enabled = false;
                    delLineBtn.Enabled = false;
                }
                else if (listView.SelectedItems.Count == 1)
                {
                    editLineBtn.Enabled = true;
                    delLineBtn.Enabled = true;
                }
                else if (listView.SelectedItems.Count > 1)
                {
                    editLineBtn.Enabled = false;
                    delLineBtn.Enabled = true;
                }
            }
        }

        private void addLineBtn_Click(object sender, EventArgs e)
        {
            var currentFile = fileListBox.SelectedItem.ToString();
            var currentId = -1;

            if (pf.project.files.ContainsKey(currentFile))
                currentId = pf.project.files[currentFile].content.Select(content => content.contentId).Prepend(currentId).Max();

            var ld = new LineEditor.LineData()
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
            var currentFile = fileListBox.SelectedItem.ToString();
            var contentID = (int)listView.SelectedItems[0].Tag;
            var item = pf.project.files[currentFile].content.Single(line => line.contentId == contentID);

            var ld = new LineEditor.LineData()
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

        private void listView_MouseUp(object sender, MouseEventArgs e)
        {
            mouse = e.Button;
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            if (mouse == MouseButtons.Left)
                editLineBtn_Click(sender, e);
        }

        private void OpenLineEditor(LineEditor.LineData ld)
        {
            var lineEditor = new LineEditor(ld, pf.project.type);

            if (lineEditor.ShowDialog() == DialogResult.OK)
            {
                var currentItem = fileListBox.SelectedItem.ToString();

                if (!pf.project.files.ContainsKey(currentItem))
                {
                    var rf = new ProjectFile.RevisedFile
                    {
                        complete = false,
                        note = string.Empty,
                        content = new List<ProjectFile.FileContent>(),
                    };

                    pf.project.files.Add(currentItem, rf);
                }

                var contentId = lineEditor.newfc.contentId;

                if (pf.project.files[currentItem].content.FindIndex(line => line.contentId == contentId) != -1)
                {
                    var item = pf.project.files[currentItem].content.Single(line => line.contentId == contentId);

                    if (pf.project.files[currentItem].content.Contains(item))
                        pf.project.files[currentItem].content.Remove(item);
                }

                var fc = new ProjectFile.FileContent
                {
                    contentId = lineEditor.newfc.contentId,
                    lineId = lineEditor.newfc.lineId,
                    proposal = lineEditor.newfc.proposal,
                    prevLineId = lineEditor.newfc.prevLineId,
                    nextLineId = lineEditor.newfc.nextLineId,
                    comment = lineEditor.newfc.comment,
                    color = lineEditor.newfc.color
                };

                pf.project.files[currentItem].content.Add(fc);

                ListViewUpdate();

                var index = Array.IndexOf(pf.project.files[currentItem].content.ToArray(), fc);
                listView.Items[index].EnsureVisible();

                SetFileChanged(true);
            }
        }

        private void ListViewUpdate()
        {
            var currentItem = fileListBox.SelectedItem.ToString();

            listView.BeginUpdate();

            listView.Items.Clear();

            if (pf.project.files.ContainsKey(currentItem))
            {
                foreach (var content in pf.project.files[currentItem].content)
                {
                    string[] row = { content.lineId, content.proposal.Replace("\r\n", " "), pf.Comment(content.comment) };
                    listView.Items.Add(new ListViewItem(row) { Tag = content.contentId });
                }
            }

            listView.ListViewItemSorter = new CustomListViewSort();

            listView.EndUpdate();
        }

        private void delLineBtn_Click(object sender, EventArgs e)
        {
            var msg = Language.Strings.MainForm_DeleteLineWarning;

            if (listView.SelectedItems.Count > 1)
                msg = Language.Strings.MainForm_DeleteLineWarning_Plural;

            if (MessageBox.Show(msg, Language.Strings.Generic_Warning, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var currentItem = fileListBox.SelectedItem.ToString();

                foreach (ListViewItem lvi in listView.SelectedItems)
                {
                    var contentID = (int)lvi.Tag;
                    var item = pf.project.files[currentItem].content.Single(fc => fc.contentId == contentID);

                    pf.project.files[currentItem].content.Remove(item);

                    if (pf.project.files[currentItem].content.Count == 0)
                        pf.project.files.Remove(currentItem);
                }

                ListViewUpdate();
                listView_SelectedIndexChanged(sender, e);
                SetFileChanged(true);
            }
        }

        private void saveProjBtn_ButtonClick(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            if (fileChanged)
            {
                pf.WriteProject();
                SystemSounds.Beep.Play();
                SetFileChanged(false);
            }
        }

        private void saveProjectAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog()
            {
                Title = Language.Strings.Generic_SaveProject,
                Filter = $@"{Language.Strings.Generic_ProjectFileType} (*.drpj)|*.drpj",
                FileName = pf.project.name
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var currentPath = pf.path;
                pf.path = sfd.FileName;

                pf.WriteProject();

                if (MessageBox.Show(Language.Strings.MainForm_OpenNewProjectCopy, Language.Strings.Generic_Warning, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    Open(sfd.FileName);
                else
                    pf.path = currentPath;
            }
        }

        private void generateReportBtn_Click(object sender, EventArgs e)
        {
            var dr = DialogResult.Yes;

            if (fileChanged)
                CheckUnsaved();

            if (fileListBox.CheckedItems.Count != fileListBox.Items.Count)
                dr = MessageBox.Show(Language.Strings.MainForm_IncompleteFiles, Language.Strings.Generic_Warning, MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                var gr = new GenerateReport(pf);

                if (!gr.ProjectEmpty())
                {
                    var sfd = new SaveFileDialog()
                    {
                        Title = Language.Strings.MainForm_ReportDestination,
                        Filter = $@"{Language.Strings.Generic_MarkdownFileType} (*.md)|*.md",
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
                    MessageBox.Show(Language.Strings.MainForm_EmptyProjectError, Language.Strings.Generic_Error, MessageBoxButtons.OK);
                }
            }
        }

        private void fileListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var dr = DialogResult.Yes;
            var item = fileListBox.SelectedItem.ToString();

            if (e.NewValue == CheckState.Checked)
            {
                if (!pf.project.files.ContainsKey(item))
                {
                    var rf = new ProjectFile.RevisedFile
                    {
                        complete = false,
                        note = string.Empty,
                        content = new List<ProjectFile.FileContent>(),
                    };

                    pf.project.files.Add(item, rf);
                }

                if (pf.project.files[item].content.Count > 0)
                    dr = MessageBox.Show(Language.Strings.MainForm_MarkAsCompleteWarning, Language.Strings.Generic_Warning, MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    pf.project.files[item].complete = true;
                    CompleteToggle(true);
                    SetFileChanged(true);
                }
                else
                {
                    e.NewValue = CheckState.Unchecked;
                }
            }
            else
            {
                if (!pf.project.files.ContainsKey(item))
                {
                    var rf = new ProjectFile.RevisedFile
                    {
                        complete = true,
                        note = string.Empty,
                        content = new List<ProjectFile.FileContent>(),
                    };

                    pf.project.files.Add(item, rf);
                }

                if (pf.project.files[item].content.Count > 0)
                    dr = MessageBox.Show(Language.Strings.MainForm_MarkAsNotCompleteWarning, Language.Strings.Generic_Warning, MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    pf.project.files[item].complete = false;
                    CompleteToggle(false);
                    SetFileChanged(true);
                }
                else
                {
                    e.NewValue = CheckState.Checked;
                }
            }
        }

        private void addNoteBtn_Click(object sender, EventArgs e)
        {
            var currentFile = fileListBox.SelectedItem.ToString();

            if (!pf.project.files.ContainsKey(currentFile))
            {
                var rf = new ProjectFile.RevisedFile
                {
                    complete = false,
                    note = string.Empty,
                    content = new List<ProjectFile.FileContent>(),
                };

                pf.project.files.Add(currentFile, rf);
            }

            var ne = new NoteEditor(currentFile, pf.project.files[currentFile].note);
            var dr = ne.ShowDialog();

            if (dr == DialogResult.OK)
                pf.project.files[currentFile].note = ne.note;
            else if (dr == DialogResult.Abort)
                pf.project.files[currentFile].note = string.Empty;

            ChangeNoteIcon(currentFile);

            if (dr != DialogResult.Cancel)
                SetFileChanged(true);
        }

        private void infoBtn_Click(object sender, EventArgs e)
        {
            var info = new InfoForm();
            info.ShowDialog();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            ResizeListView();
        }

        private void ResizeListView()
        {
            var lineWidth = listView.Columns[0].Width;
            var commentWidth = listView.Columns[2].Width;

            const int largeOffset = 21;
            const int smallOffset = 4;

            if (listView.Items.Count > 0 && listView.ClientSize.Height < (listView.Items.Count + 1) * listView.Items[0].Bounds.Height)
                listView.Columns[1].Width = listView.Width - (lineWidth + commentWidth + largeOffset);
            else
                listView.Columns[1].Width = listView.Width - (lineWidth + commentWidth + smallOffset);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CheckUnsaved();
        }

        private void CheckUnsaved()
        {
            if (!fileChanged) return;

            var dr = MessageBox.Show(Language.Strings.MainForm_UnsavedChanges, Language.Strings.Generic_Warning, MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
                Save();
        }

        private void CompleteToggle(bool complete)
        {
            listView.DoubleClick -= listView_DoubleClick;

            if (complete)
            {
                addNoteBtn.Enabled = false;
                completeLabel.Visible = true;
            }
            else
            {
                listView.DoubleClick += listView_DoubleClick;
                addNoteBtn.Enabled = true;
                completeLabel.Visible = false;
            }
        }

        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && listView.FocusedItem.Bounds.Contains(e.Location))
            {
                if (!fileListBox.CheckedItems.Contains(fileListBox.SelectedItem))
                {
                    if (listView.SelectedItems.Count == 1)
                    {
                        editSelectedToolStripMenuItem.Enabled = true;

                        commentToolStripMenuItem.Checked = listView.SelectedItems[0].SubItems[2].Text == Language.Strings.Generic_Yes;

                        deleteSelectedToolStripMenuItem.Text = Language.Strings.MainForm_deleteSelectedToolStripMenuItem;
                    }
                    else
                    {
                        editSelectedToolStripMenuItem.Enabled = false;

                        var check = true;

                        foreach (ListViewItem item in listView.SelectedItems)
                            check = item.SubItems[2].Text != Language.Strings.Generic_No;

                        commentToolStripMenuItem.Checked = check;

                        deleteSelectedToolStripMenuItem.Text = Language.Strings.MainForm_deleteSelectedToolStripMenuItem_Plural;
                    }

                    contextMenuStrip.Show(Cursor.Position);
                }
            }
        }

        private void editSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editLineBtn_Click(sender, e);
        }

        private void deleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delLineBtn_Click(sender, e);
        }

        private void commentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currentFile = fileListBox.SelectedItem.ToString();

            foreach (ListViewItem item in listView.SelectedItems)
            {
                if (item.SubItems[2].Text == Language.Strings.Generic_Yes)
                {
                    pf.project.files[currentFile].content.Find(fc => fc.lineId == item.SubItems[0].Text).comment = false;
                    item.SubItems[2].Text = Language.Strings.Generic_No;
                }
                else if (item.SubItems[2].Text == Language.Strings.Generic_No)
                {
                    pf.project.files[currentFile].content.Find(fc => fc.lineId == item.SubItems[0].Text).comment = true;
                    item.SubItems[2].Text = Language.Strings.Generic_Yes;
                }
            }

            commentToolStripMenuItem.Checked = !commentToolStripMenuItem.Checked;
            SetFileChanged(true);
        }

        private void ChangeNoteIcon(string item)
        {
            if (!pf.project.files.ContainsKey(item) || string.IsNullOrWhiteSpace(pf.project.files[item].note))
                addNoteBtn.Image = Properties.Resources.Add_Note;
            else
                addNoteBtn.Image = Properties.Resources.Edit_Note;
        }

        private void SetFileChanged(bool hasChanged)
        {
            var titleChanged = Text[0] == '*';

            if (hasChanged)
            {
                fileChanged = true; 
                if (!titleChanged) Text = $@"*{Text}";
            }
            else
            {
                fileChanged = false;
                if (titleChanged) Text = Text.Substring(1);
            }
        }
    }
}
