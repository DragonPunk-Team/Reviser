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

        private void openProjBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Open Project",
                Filter = "DragonPunk Reviser Project (*.dtr)|*.dtr|All files (*.*)|*.*"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Text = "DragonPunk Reviser - " + ofd.SafeFileName;
                filename = ofd.FileName;

                project = JsonConvert.DeserializeObject<ProjectFile.Project>(File.ReadAllText(filename));
            }
        }
    }
}
