using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace Reviser
{
    public partial class ProjectSettings : Form
    {
        bool newProj;
        ProjectFile pf;
        MainForm mf;

        string[] projectFilesList = null;

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
                Text = "New Project";

                projTypeBox.SelectedItem = "SoJ";
            }
            else
            {
                Text = "Project Settings";

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
            List<string> files = new List<string>();

            if (Directory.Exists(path))
                foreach (string file in Directory.GetFiles(path))
                    files.Add(Path.GetFileName(file));
            else
                return new string[0];

            return files.ToArray();
        }

        private string[] MakeFileList(string first, string last)
        {
            List<string> files = new List<string>();

            var fileList = GetFiles(tranFilesBox.Text);

            int firstIndex = Array.IndexOf(fileList, first);
            int lastIndex = Array.IndexOf(fileList, last);
            files.AddRange(new ArraySegment<string>(fileList.ToArray(), firstIndex, lastIndex - firstIndex + 1));

            return files.ToArray();
        }

        private void origFilesBtn_Click(object sender, EventArgs e)
        {
            var path = FolderSelect("Original");
            Console.WriteLine("Original: [" + path + "]");

            if (!string.IsNullOrWhiteSpace(path))
                origFilesBox.Text = path;
        }

        private void tranFilesBtn_Click(object sender, EventArgs e)
        {
            var path = FolderSelect("Translated");

            if (!string.IsNullOrWhiteSpace(path))
                tranFilesBox.Text = path;
        }

        private string FolderSelect(string fileType)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog()
            {
                Description = String.Format("Select {0} Files Folder", fileType)
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
                MessageBox.Show("Project must have a name!", "Error", MessageBoxButtons.OK);
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
                    Title = "Save Project",
                    Filter = "DragonPunk Reviser Project (*.drpj)|*.drpj",
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

                if (diff.Count() > 0)
                {
                    bool lines = false;

                    foreach (string file in diff)
                    {
                        if (pf.project.files.ContainsKey(file) && pf.project.files[file].content.Count > 0)
                        {
                            lines = true;
                            break;
                        }
                    }

                    if (lines)
                    {
                        if (MessageBox.Show("Looks like the file list has changed." +
                                                "\nBy saving the project right now, you will lose the comments related to the files which are not in the file list anymore." +
                                                "\nAre you sure you want to continue?" +
                                                "\n\n(clicking \"No\" will ignore the new file list and the new file paths.)", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            foreach (string file in diff)
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
