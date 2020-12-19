using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Reviser
{
    public partial class ProjectSettings : Form
    {
        bool newProj;
        ProjectFile pf;
        MainForm mf;
        List<string> fileList = new List<string>();

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
            }
            else
            {
                Text = "Project Settings";

                projNameBox.Text = pf.project.name;
                projTypeBox.SelectedItem = pf.project.type;
                origFilesBox.Text = pf.project.orig_path;
                tranFilesBox.Text = pf.project.tran_path;
                firstFileBox.Text = pf.project.file_list[0];
                lastFileBox.Text = pf.project.file_list[pf.project.file_list.Length - 1];
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
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

            int firstIndex = fileList.IndexOf(first);
            int lastIndex = fileList.IndexOf(last);
            files.AddRange(new ArraySegment<string>(fileList.ToArray(), firstIndex, lastIndex - firstIndex + 1));

            return files.ToArray();
        }

        private void origFilesBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog()
            {
                Description = "Select Original Files Folder"
            };

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                origFilesBox.Text = fbd.SelectedPath;
            }
        }

        private void tranFilesBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog()
            {
                Description = "Select Translated Files Folder"
            };

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tranFilesBox.Text = fbd.SelectedPath;
            }
        }

        private void tranFilesBox_TextChanged(object sender, EventArgs e)
        {
            UpdateFileLists();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            ProjectFile newpf = new ProjectFile();

            newpf.project = new ProjectFile.Project()
            {
                name = projNameBox.Text,
                type = projTypeBox.SelectedItem.ToString(),
                orig_path = origFilesBox.Text,
                tran_path = tranFilesBox.Text
            };

            newpf.project.file_list = MakeFileList(firstFileBox.Text, lastFileBox.Text);

            if (newProj)
            {
                newpf.project.files = new Dictionary<string, ProjectFile.RevisedFile>();

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

                    this.Close();
                }
            }
            else
            {
                IEnumerable<string> diff = pf.project.file_list.Except(newpf.project.file_list);

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

                this.Close();
            }
        }

        private void UpdateFileLists()
        {
            if (fileList.Count == 0)
            {
                fileList.AddRange(GetFiles(tranFilesBox.Text));

                if (fileList.Count > 0)
                {
                    firstFileBox.Enabled = true;
                    lastFileBox.Enabled = true;

                    firstFileBox.Items.AddRange(fileList.ToArray());
                    lastFileBox.Items.AddRange(fileList.ToArray());
                }
                else
                {
                    firstFileBox.Enabled = false;
                    lastFileBox.Enabled = false;
                }
            }
            else
            {
                fileList.Clear();
                UpdateFileLists();
            }
        }
    }
}
