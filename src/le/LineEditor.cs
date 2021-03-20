using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Reviser.SoJ;
using Reviser.Tweaks;

namespace Reviser.LE
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
        int contentId;
        Tuple<string, string>[] tranLines;

        GMDv2 origGMD = new GMDv2();
        GMDv2 tranGMD = new GMDv2();

        public LineEditor(LineData lineData)
        {
            InitializeComponent();

            toolStrip.Renderer = new ToolStripOverride();
            toolStripContainer1.TopToolStripPanel.RowMargin = new Padding(0);
            toolStrip.Location = new Point(0, 0);
            toolStrip.Size = new Size(toolStrip.Size.Width + 3, toolStrip.Size.Height);

            ld = lineData;

            ReadFiles("\\" + ld.currentFile);

            if (ld.fc != null && ld.fc.prevLineId != "-1")
            {
                prevLinesBtn.Text = ld.fc.prevLineId;
                prevLinesBtn.Image = Properties.Resources.Add_previous_lines;
                prevLinesBtn.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            }
        }

        private void ReadFiles(string filePath)
        {
            Thread orig = new Thread(origGMD.ReadGMD);
            Thread tran = new Thread(tranGMD.ReadGMD);

            orig.Start(ld.origPath + filePath);
            tran.Start(ld.tranPath + filePath);

            while (orig.ThreadState == ThreadState.Running || tran.ThreadState == ThreadState.Running)
                Application.DoEvents();
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

        private void searchBtn_Click(object sender, EventArgs e)
        {
            tranLines = tranGMD.GetLines(idBox.Text);
            lineBox.Text = Utils.FormatLines(origGMD, tranGMD, idBox.Text, colorCheckBox.Checked);

            if (string.IsNullOrWhiteSpace(lineBox.Text) || lineBox.Text.Contains("[Error]"))
            {
                copyLineBtn.Enabled = false;
                commentBox.Enabled = false;
                commentCheckBox.Enabled = false;
                prevLinesBtn.Enabled = false;
            }
            else
            {
                copyLineBtn.Enabled = true;
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
                lineId = Utils.CleanIds(idBox.Text),
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
            lineBox.Text = Utils.FormatLines(origGMD, tranGMD, idBox.Text, colorCheckBox.Checked);
        }

        private void CloseForm(bool save)
        {
            if (save)
                DialogResult = DialogResult.OK;
            else
                DialogResult = DialogResult.Cancel;

            Close();
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
            {
                plainTextBtn.Enabled = true;
                insertLineIdBtn.Enabled = true;
                insertFileLineIdBtn.Enabled = true;
            }
            else
            {
                plainTextBtn.Enabled = false;
                insertLineIdBtn.Enabled = false;
                insertFileLineIdBtn.Enabled = false;
            }
        }

        private void copyLineBtn_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string currentLine;
            GMDv2 gmd = new GMDv2();

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

            commentBox.SelectedText = sb.ToString();
            commentBox.Select(commentBox.SelectionStart + sb.Length, 0);
            commentBox.Focus();
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

                commentBox.SelectedText = sb.ToString();
            }

            commentBox.Focus();
        }

        private void insertFileLineIdBtn_Click(object sender, EventArgs e)
        {
            InsertFileName ifn = new InsertFileName(ld.filelist, ld.tranPath);

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

                    commentBox.SelectedText = sb.ToString();
                }
            }

            commentBox.Focus();
        }

        private void normalTextBtn_Click(object sender, EventArgs e)
        {
            commentBox.SelectedText = "<n></n>";
            commentBox.Select(commentBox.SelectionStart - 4, 0);
            commentBox.Focus();
        }

        private void prevLinesBtn_Click(object sender, EventArgs e)
        {
            PrevLinesEditor ple = new PrevLinesEditor(origGMD, tranGMD, colorCheckBox.Checked, prevLinesBtn.Text);
            DialogResult dr = ple.ShowDialog();

            if (dr == DialogResult.OK)
            {
                prevLinesBtn.Text = ple.lineId;
                prevLinesBtn.Image = Properties.Resources.Add_previous_lines;
                prevLinesBtn.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            }
            else if (dr == DialogResult.Abort)
            {
                prevLinesBtn.Text = "-1";
                prevLinesBtn.Image = Properties.Resources.Add_previous_lines___no_lines;
                prevLinesBtn.DisplayStyle = ToolStripItemDisplayStyle.Image;
            }

            commentBox.Focus();
        }

        private void idBox_TextChanged(object sender, EventArgs e)
        {
            var format = Utils.FormatIds(idBox.Text, idBox.SelectionStart);

            idBox.Text = format.Item1;
            idBox.Select(format.Item2, 0);
        }
    }
}
