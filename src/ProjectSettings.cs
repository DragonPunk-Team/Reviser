using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;

using Ookii.Dialogs.WinForms;

namespace Reviser
{
    public partial class ProjectSettings : Form
    {
        bool newProj;
        ProjectFile pf;
        MainForm mf;

        string[] projectFilesList;

        public ProjectSettings(bool newp, ProjectFile projf = null, MainForm mainf = null)
        {
            InitializeComponent();

            newProj = newp;

            if (projf == null)
                pf = new ProjectFile();
            else
                pf = projf;

            mf = mainf;
        }

        private void ProjectSettings_Load(object sender, EventArgs e)
        {
            if (newProj)
            {
                Text = Language.Strings.Generic_NewProject;

                projTypeBox.SelectedItem = "SoJ";
            }
            else
            {
                Text = Language.Strings.Generic_ProjectSettings;

                projNameBox.Text = pf.project.name;
                projTypeBox.SelectedItem = pf.project.type;
                origFilesBox.Text = pf.project.orig_path;
                tranFilesBox.Text = pf.project.tran_path;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private string[] GetFiles(string path)
        {
            var files = new List<string>();

            if (Directory.Exists(path))
                files.AddRange(Directory.GetFiles(path).Select(Path.GetFileName));
            else
                return new string[0];

            return files.ToArray();
        }

        private string[] MakeFileList(string first, string last)
        {
            var files = new List<string>();
            var fileList = GetFiles(tranFilesBox.Text);
            var firstIndex = Array.IndexOf(fileList, first);
            var lastIndex = Array.IndexOf(fileList, last);

            files.AddRange(new ArraySegment<string>(fileList.ToArray(), firstIndex, lastIndex - firstIndex + 1));

            return files.ToArray();
        }

        private void origFilesBtn_Click(object sender, EventArgs e)
        {
            var path = FolderSelect(Language.Strings.ProjectSettings_OrigFolderSelect);

            if (!string.IsNullOrWhiteSpace(path))
                origFilesBox.Text = path;
        }

        private void tranFilesBtn_Click(object sender, EventArgs e)
        {
            var path = FolderSelect(Language.Strings.ProjectSettings_TranFolderSelect);

            if (!string.IsNullOrWhiteSpace(path))
                tranFilesBox.Text = path;
        }

        private string FolderSelect(string desc)
        {
            var fbd = new VistaFolderBrowserDialog()
            {
                Description = string.Format(desc),
                UseDescriptionForTitle = true
            };

            if (fbd.ShowDialog() == DialogResult.OK)
                return fbd.SelectedPath;
            else
                return "";
        }

        private void tranFilesBox_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(tranFilesBox.Text))
            {
                UpdateFirstFileList();
            }
            else
            {
                firstFileBox.Enabled = false;
                lastFileBox.Enabled = false;
                fileSelectBtn.Enabled = false;
                saveBtn.Enabled = false;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(projNameBox.Text))
            {
                SystemSounds.Beep.Play();
                MessageBox.Show(Language.Strings.ProjectSettings_EmptyProjNameError, Language.Strings.Generic_Error, MessageBoxButtons.OK);
            }
            else
            {
                Save();
            }
        }

        private void Save()
        {
            var newpf = new ProjectFile
            {
                project = new ProjectFile.Project()
                {
                    name = projNameBox.Text,
                    type = projTypeBox.SelectedItem.ToString(),
                    orig_path = origFilesBox.Text,
                    tran_path = tranFilesBox.Text
                }
            };

            if (projectFilesList == null)
                newpf.project.file_list = MakeFileList(firstFileBox.Text, lastFileBox.Text);
            else
                newpf.project.file_list = projectFilesList.ToArray();

            if (newProj)
            {
                newpf.project.files = new SortedDictionary<string, ProjectFile.RevisedFile>();

                SaveFileDialog sfd = new SaveFileDialog()
                {
                    Title = Language.Strings.Generic_SaveProject,
                    Filter = $@"{Language.Strings.Generic_ProjectFileType} (*.drpj)|*.drpj",
                    FileName = newpf.project.name
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    newpf.path = sfd.FileName;
                    newpf.WriteProject();

                    mf.Open(sfd.FileName);

                    Close();
                }
            }
            else
            {
                var diff = pf.project.file_list.Except(newpf.project.file_list);

                if (diff.Any())
                {
                    var lines = false;

                    foreach (var file in diff)
                    {
                        if (pf.project.files.ContainsKey(file) && pf.project.files[file].content.Count > 0)
                        {
                            lines = true;
                            break;
                        }
                    }

                    if (lines)
                    {
                        if (MessageBox.Show(Language.Strings.ProjectSettings_ChangedFileListWarning, Language.Strings.Generic_Warning, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            foreach (var file in diff)
                            {
                                if (pf.project.files.ContainsKey(file))
                                    pf.project.files.Remove(file);
                            }
                        }
                        else
                        {
                            newpf.project.orig_path = pf.project.orig_path;
                            newpf.project.tran_path = pf.project.tran_path;
                            newpf.project.file_list = pf.project.file_list;
                        }
                    }
                }

                newpf.project.files = pf.project.files;

                newpf.path = pf.path;
                newpf.WriteProject();

                mf.Open(pf.path);

                DialogResult = DialogResult.OK;

                Close();
            }
        }

        private string[] GetPartialList()
        {
            var firstSelection = firstFileBox.SelectedItem.ToString();

            if (string.IsNullOrWhiteSpace(firstSelection))
            {
                return new string[0];
            }
            else
            {
                var files = GetFiles(tranFilesBox.Text);
                var index = Array.IndexOf(files, firstSelection);
                return new ArraySegment<string>(files, index, files.Length - index).ToArray();
            }
        }

        private void UpdateFirstFileList()
        {
            if (firstFileBox.Items.Count > 0)
            {
                firstFileBox.Items.Clear();
                lastFileBox.Items.Clear();

                UpdateFirstFileList();
            }
            else
            {
                var files = GetFiles(tranFilesBox.Text);

                if (files.Length > 0)
                {
                    firstFileBox.Items.AddRange(files);

                    if (pf.project != null && pf.project.file_list != null && pf.project.file_list.Length > 0)
                        firstFileBox.SelectedItem = pf.project.file_list[0];

                    firstFileBox.Enabled = true;
                }
                else
                {
                    firstFileBox.Enabled = false;
                }
            }
        }

        private void UpdateLastFileList()
        {
            if (lastFileBox.Items.Count > 0)
            {
                lastFileBox.Items.Clear();

                UpdateLastFileList();
            }
            else
            {
                var files = GetPartialList();

                if (files.Length > 0)
                {
                    lastFileBox.Items.AddRange(files);

                    if (pf.project != null && pf.project.file_list != null && pf.project.file_list.Length > 0)
                        lastFileBox.SelectedItem = pf.project.file_list[pf.project.file_list.Length - 1];

                    lastFileBox.Enabled = true;
                }
                else
                {
                    lastFileBox.Enabled = false;
                }
            }
        }

        private void firstFileBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(firstFileBox.SelectedItem.ToString()))
                UpdateLastFileList();
        }

        private void lastFileBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lastFileBox.Text))
            {
                fileSelectBtn.Enabled = false;
                saveBtn.Enabled = false;
            }
            else
            {
                fileSelectBtn.Enabled = true;
                saveBtn.Enabled = true;
            }

            if (lastFileBox.Text == firstFileBox.Text)
                fileSelectBtn.Enabled = false;
        }

        private void fileSelectBtn_Click(object sender, EventArgs e)
        {
            FileSelector fs;

            if (pf.project != null && pf.project.file_list != null && pf.project.file_list.Length > 0)
                fs = new FileSelector(MakeFileList(firstFileBox.Text, lastFileBox.Text), pf.project.file_list);
            else
                fs = new FileSelector(MakeFileList(firstFileBox.Text, lastFileBox.Text));

            var dr = fs.ShowDialog();

            if (dr == DialogResult.OK)
                projectFilesList = fs.newFileList;
        }
    }
}
