using System;
using System.Collections.Generic;
using System.Linq;
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
            public string[] filelist { get; set; }
        }

        public ProjectFile.FileContent newfc;

        LineData ld;
        GMD origGMD;
        GMD tranGMD;
        int contentId;
        Tuple<string, string>[] tranLines;

        public LineEditor(LineData lineData)
        {
            InitializeComponent();

            ld = lineData;
            var filePath = "\\" + ld.currentFile;

            origGMD = new GMD();
            tranGMD = new GMD();

            origGMD.ReadGMD(ld.origPath + filePath);
            tranGMD.ReadGMD(ld.tranPath + filePath);
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
                commentBox.Text = ld.fc.proposal;
                commentCheckBox.Checked = ld.fc.comment;
                colorCheckBox.Checked = ld.fc.color;

                searchBtn_Click(sender, e);
                commentCheckBox_CheckedChanged(sender, e);
            }
        }

        private string FormatLines()
        {
            StringBuilder sb = new StringBuilder();

            var origLines = origGMD.GetLines(idBox.Text);
            tranLines = tranGMD.GetLines(idBox.Text);

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

            if (string.IsNullOrWhiteSpace(lineBox.Text) || lineBox.Text.Contains("[Error]"))
            {
                copyLineBtn.Enabled = false;
                insertLineIdBtn.Enabled = false;
                insertFileLineIdBtn.Enabled = false;
                commentBox.Enabled = false;
                commentCheckBox.Enabled = false;
                prevLinesBtn.Enabled = false;
            }
            else
            {
                copyLineBtn.Enabled = true;
                insertLineIdBtn.Enabled = true;
                insertFileLineIdBtn.Enabled = true;
                commentBox.Enabled = true;
                commentCheckBox.Enabled = true;
                prevLinesBtn.Enabled = true;
            }

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
                prevLineId = prevLinesBtn.Text,
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
            CheckSaveBtn();
        }

        private void lineBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lineBox.Text) || lineBox.Text.Contains("[Error]"))
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

        private void commentCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (commentCheckBox.Checked)
                normalTextBtn.Enabled = true;
            else
                normalTextBtn.Enabled = false;
        }

        private void copyLineBtn_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string currentLine;
            GMD gmd = new GMD();

            if (tranLines.Count() == 1)
            {
                currentLine = tranLines[0].Item2;

                if (!colorCheckBox.Checked)
                    currentLine = gmd.RemoveColors(currentLine);

                if (commentCheckBox.Checked)
                    sb.Append("<n>" + currentLine + "</n>");
                else
                    sb.Append(currentLine);
            }
            else
            {
                string lastChar = "";
                bool sameChar = false;

                foreach (var line in tranLines)
                {
                    sameChar = (line.Item1 == lastChar);

                    if (sameChar)
                    {
                        if (!sb.ToString().EndsWith("\n"))
                            sb.AppendLine();
                    }
                    else
                    {
                        lastChar = line.Item1;

                        if (commentCheckBox.Checked)
                            sb.AppendLine("<n>**" + line.Item1 + ":**</n>");
                        else
                            sb.AppendLine("**" + line.Item1 + ":**");
                    }

                    currentLine = line.Item2;

                    if (!colorCheckBox.Checked)
                        currentLine = gmd.RemoveColors(currentLine);

                    if (commentCheckBox.Checked)
                        sb.AppendLine("<n>" + currentLine + "</n>");
                    else
                        sb.AppendLine(currentLine);

                    if (tranLines.Last() != line)
                        sb.AppendLine();
                }

                if (sameChar)
                    sb.Remove(0, sb.ToString().Split('\n').FirstOrDefault().Length + 1);
            }

            commentBox.Text += sb.ToString();
            commentBox.Select(commentBox.Text.Length, 0);
        }

        private void insertLineIdBtn_Click(object sender, EventArgs e)
        {
            InsertLineID ilid = new InsertLineID();
            
            if (ilid.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();

                if (!commentBox.Text.EndsWith(" ") && commentBox.Text.Length > 0)
                    sb.Append(" ");

                sb.Append("`");
                sb.Append(ilid.lineId);
                sb.Append("`");

                commentBox.Text += sb.ToString();
            }
        }

        private void insertFileLineIdBtn_Click(object sender, EventArgs e)
        {
            InsertFileName ifn = new InsertFileName(ld.filelist);

            if (ifn.ShowDialog() == DialogResult.OK)
            {
                InsertLineID ilid = new InsertLineID();

                if (ilid.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder sb = new StringBuilder();

                    if (!commentBox.Text.EndsWith(" ") && commentBox.Text.Length > 0)
                       sb.Append(" ");

                    sb.Append("`");
                    sb.Append(ifn.filename);
                    sb.Append(":");
                    sb.Append(ilid.lineId);
                    sb.Append("`");

                    commentBox.Text += sb.ToString();
                }
            }
        }

        private void normalTextBtn_Click(object sender, EventArgs e)
        {
            commentBox.Text += "<n></n>";
            commentBox.Select(commentBox.Text.Length - 4, 0);
        }

        private void prevLinesBtn_Click(object sender, EventArgs e)
        {
            PrevLinesEditor ple = new PrevLinesEditor(origGMD, tranGMD, colorCheckBox.Checked, prevLinesBtn.Text);
            DialogResult dr = ple.ShowDialog();

            if (dr == DialogResult.OK)
            {
                prevLinesBtn.Text = ple.lineId;
                prevLinesBtn.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            }
            else if (dr == DialogResult.Abort)
            {
                prevLinesBtn.Text = "-1";
                prevLinesBtn.DisplayStyle = ToolStripItemDisplayStyle.Image;
            }
        }
    }
}
