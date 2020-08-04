using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Reviser
{
    public partial class ProjectSettings : Form
    {
        bool newProj;
        ProjectFile pf;
        string[] fileList = { };

        public ProjectSettings(bool newp, ProjectFile projf = null)
        {
            InitializeComponent();
            newProj = newp;
            pf = projf;
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
            Close();
        }

        private string[] GetFiles(string path)
        {
            List<string> files = new List<string>();

            foreach (string file in Directory.GetFiles(path))
                files.Add(Path.GetFileName(file));

            return files.ToArray();
        }

        private string[] MakeFileList(string first, string last, string path)
        {
            List<string> files = new List<string>();
            bool add = false;

            foreach (string file in fileList)
            {
                if (file == first)
                    add = true;
                else if (file == last)
                    add = false;

                if (add)
                    files.Add(file);
            }

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

                firstFileBox.Enabled = true;
                lastFileBox.Enabled = true;
            }
        }

        private void tranFilesBox_TextChanged(object sender, EventArgs e)
        {
            firstFileBox.Enabled = true;
            lastFileBox.Enabled = true;
        }

        private void firstFileBox_DropDown(object sender, EventArgs e)
        {
            if (fileList.Length == 0)
                fileList = GetFiles(tranFilesBox.Text);

            firstFileBox.Items.AddRange(fileList);
        }

        private void lastFileBox_DropDown(object sender, EventArgs e)
        {
            if (fileList.Length == 0)
                fileList = GetFiles(tranFilesBox.Text);

            lastFileBox.Items.AddRange(fileList);
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (newProj)
            {
                pf.project = new ProjectFile.Project()
                {
                    name = projNameBox.Text,
                    type = projTypeBox.SelectedItem.ToString(),
                    orig_path = origFilesBox.Text,
                    tran_path = tranFilesBox.Text,
                    files = new Dictionary<string, ProjectFile.RevisedFile>()
                };

                pf.project.file_list = MakeFileList(firstFileBox.SelectedItem.ToString(), lastFileBox.SelectedItem.ToString(), pf.project.tran_path);

                SaveFileDialog sfd = new SaveFileDialog()
                {
                    Title = "Save Project",
                    Filter = "DragonPunk Reviser Project (*.dtr)|*.dtr|All files (*.*)|*.*",
                    FileName = pf.project.name
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, JsonConvert.SerializeObject(pf.project, Formatting.Indented));
                    Close();
                }
            }
            else
            {
                // TODO: implement saving to existing project
            }
        }
    }
}
