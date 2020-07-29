using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reviser
{
    public partial class Form1 : Form
    {
        string filename;
        ProjectFile.Project project;

        public Form1()
        {
            InitializeComponent();
        }

        private void EnableControls()
        {
            addLineBtn.Enabled = true;
            dataGrid.Enabled = true;
            projSettingsBtn.Enabled = true;
            saveAsProjBtn.Enabled = true;
            saveProjBtn.Enabled = true;
        }

        private void openProjBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Open Project",
                Filter = "DragonPunk Reviser Project (*.dtr)|*.dtr|All files (*.*)|*.*"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;

                project = JsonConvert.DeserializeObject<ProjectFile.Project>(File.ReadAllText(filename));

                Text = "DragonPunk Reviser - " + project.name;

                fileListBox.Items.AddRange(project.file_list);
                fileListBox.SelectedIndex = 0;

                EnableControls();

                foreach (string file in project.file_list)
                {
                    if (project.files.ContainsKey(file) && project.files[file].complete)
                    {
                        fileListBox.SetItemChecked(Array.IndexOf(project.file_list, file), true);
                    }
                }
            }
        }

        private void fileListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGrid.Rows.Clear();
            string currentItem = fileListBox.SelectedItem.ToString();

            if (project.files.ContainsKey(currentItem))
            {
                foreach (ProjectFile.FileContent content in project.files[currentItem].content)
                {
                    object[] row = { content.id, content.character, content.orig_line, content.tran_line, content.proposal, content.comment };
                    dataGrid.Rows.Add(row);
                }
            }
        }
    }
}
