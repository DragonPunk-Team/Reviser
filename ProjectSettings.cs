using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
