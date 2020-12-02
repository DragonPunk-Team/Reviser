using System;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace Reviser
{
    public partial class LineEditor : Form
    {
        public class LineData
        {
            public bool newLine { get; set; }
            public string origPath { get; set; }
            public string tranPath { get; set; }
            public string currentFile { get; set; }
            public ProjectFile.FileContent fc { get; set; }
            public int lastContentId { get; set; }
        }

        public ProjectFile.FileContent newfc;

        LineData ld;
        GMD origGMD;
        GMD tranGMD;
        int contentId;

        public LineEditor(LineData lineData)
        {
            InitializeComponent();

            ld = lineData;
            var filePath = "\\" + ld.currentFile;
            origGMD = new GMD(ld.origPath + filePath);
            tranGMD = new GMD(ld.tranPath + filePath);
        }

        private void LineEditor_Load(object sender, EventArgs e)
        {
            if (ld.newLine)
            {
                contentId = ld.lastContentId + 1;

                Text = "Add New Line";
            }
            else
            {
                Text = "Edit Line";

                idBox.Text = ld.fc.lineId;
                lineBox.Text = FormatLines();
                commentBox.Text = ld.fc.proposal;
                commentCheckBox.Checked = ld.fc.comment;
                colorCheckBox.Checked = ld.fc.color;
            }
        }

        private string FormatLines()
        {
            StringBuilder sb = new StringBuilder();

            var origLines = origGMD.GetLines(idBox.Text);
            var tranLines = tranGMD.GetLines(idBox.Text);

            string lastChar = "";

            foreach (var line in origLines)
            {
                int index = Array.IndexOf(origLines, line);

                if (line.Item1 == lastChar)
                {
                    sb.Append("\n\n");
                }
                else
                {
                    lastChar = line.Item1;
                    sb.AppendLine("[" + line.Item1 + "]");
                }

                var origLine = line.Item2;

                if (!colorCheckBox.Checked)
                    origLine = origGMD.RemoveColors(origLine);

                sb.AppendLine(origLine);

                if (line.Item1 == "Error")
                {
                    SystemSounds.Beep.Play();
                    break;
                }
                else
                {
                    var tranLine = tranLines[index].Item2;

                    if (!colorCheckBox.Checked)
                        tranLine = tranGMD.RemoveColors(tranLine);

                    sb.AppendLine(tranLine);
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            lineBox.Text = FormatLines();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            CloseForm(false);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            newfc = new ProjectFile.FileContent
            {
                lineId = idBox.Text,
                proposal = commentBox.Text,
                comment = commentCheckBox.Checked,
                color = colorCheckBox.Checked
            };

            if (ld.newLine)
                newfc.contentId = contentId;
            else
                newfc.contentId = ld.fc.contentId;

            CloseForm(true);
        }

        private void colorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            lineBox.Text = FormatLines();
        }

        private void CloseForm(bool save)
        {
            if (save)
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

        private void commentBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(commentBox.Text))
                commentCheckBox.Enabled = false;
            else
                commentCheckBox.Enabled = true;

            CheckSaveBtn();
        }

        private void lineBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lineBox.Text))
                colorCheckBox.Enabled = false;
            else
                colorCheckBox.Enabled = true;

            CheckSaveBtn();
        }

        private void CheckSaveBtn()
        {
            if (lineBox.Text.Contains("[Error]") || 
                string.IsNullOrWhiteSpace(commentBox.Text) || 
                string.IsNullOrWhiteSpace(lineBox.Text))
                saveBtn.Enabled = false;
            else
                saveBtn.Enabled = true;
        }
    }
}
