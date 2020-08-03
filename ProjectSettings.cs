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
        ProjectFile.Project project;
        public ProjectSettings(bool newp, ProjectFile.Project proj = null)
        {
            InitializeComponent();
            newProj = newp;
            project = proj;
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
                caseNumBox.Enabled = false;

                projNameBox.Text = project.name;
                projTypeBox.SelectedItem = project.type;
                caseNumBox.Value = project.case_num;
                origFilesBox.Text = project.orig_path;
                tranFilesBox.Text = project.tran_path;
                firstFileBox.Text = TrimFilename(project.file_list[0], project.type);
                lastFileBox.Text = TrimFilename(project.file_list[project.file_list.Length - 1], project.type);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private string TrimFilename(string filename, string type)
        {
            if (type == "SoJ")
            {
                return filename.Remove(0, 7).Remove(9, 8);      // removes _sce0X and _eng.gmd
            }

            return filename;
        }

        private string FillFilename(string filename, string type)
        {
            if (type == "SoJ")
            {
                return string.Format("_sce0{0}_{1}_eng.gmd", (project.case_num - 1), filename);
            }

            return filename;
        }

        private string[] GetFiles(string first, string last, string path)
        {
            List<string> files = new List<string>();
            bool add = false;

            foreach (string file in Directory.GetFiles(path))
            {
                string filename = Path.GetFileName(file);

                if (filename == first)
                    add = true;
                else if (filename == last)
                    add = false;

                if (add)
                    files.Add(filename);
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
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (newProj)
            {
                project = new ProjectFile.Project()
                {
                    name = projNameBox.Text,
                    type = projTypeBox.SelectedItem.ToString(),
                    case_num = (int)caseNumBox.Value,
                    orig_path = origFilesBox.Text,
                    tran_path = tranFilesBox.Text,
                    files = new Dictionary<string, ProjectFile.RevisedFile>()
                };

                project.file_list = GetFiles(FillFilename(firstFileBox.Text, project.type), FillFilename(lastFileBox.Text, project.type), origFilesBox.Text);

                SaveFileDialog sfd = new SaveFileDialog()
                {
                    Title = "Save Project",
                    Filter = "DragonPunk Reviser Project (*.dtr)|*.dtr|All files (*.*)|*.*",
                    FileName = project.name
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, JsonConvert.SerializeObject(project, Formatting.Indented));
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
