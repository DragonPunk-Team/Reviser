using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Reviser.Files;
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

        private LineData ld;
        private string projectType;
        private int contentID;
        Tuple<string, string>[] tranLines;

        private IFile origFile;
        private IFile tranFile;

        public LineEditor(LineData lineData, string projectType)
        {
            InitializeComponent();

            toolStrip.Renderer = new ToolStripOverride();
            toolStripContainer1.TopToolStripPanel.RowMargin = new Padding(0);
            toolStrip.Location = new Point(0, 0);
            toolStrip.Size = new Size(toolStrip.Size.Width + 3, toolStrip.Size.Height);

            ld = lineData;
            this.projectType = projectType;

            PrepareGameFiles($"\\{ld.currentFile}");

            if (ld.fc != null && ld.fc.prevLineId != "-1")
            {
                prevLinesBtn.Text = ld.fc.prevLineId;
                prevLinesBtn.Image = Properties.Resources.Add_previous_lines;
                prevLinesBtn.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            }
        }

        private void PrepareGameFiles(string path)
        {
            origFile = GameFile.Get(projectType);
            tranFile = GameFile.Get(projectType);

            origFile.SetGame(projectType);
            tranFile.SetGame(projectType);

            ReadFiles(path);
        }

        private void ReadFiles(string path)
        {
            var orig = new Thread(origFile.ReadFile);
            var tran = new Thread(tranFile.ReadFile);

            orig.Start(ld.origPath + path);
            tran.Start(ld.tranPath + path);

            while (orig.ThreadState == ThreadState.Running || tran.ThreadState == ThreadState.Running)
                Application.DoEvents();
        }

        private void LineEditor_Load(object sender, EventArgs e)
        {
            if (ld.newLine)
            {
                contentID = ld.lastContentId + 1;

                Text = Language.Strings.LineEditor_WindowTitle_Add;
            }
            else
            {
                Text = Language.Strings.LineEditor_WindowTitle_Edit;

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
            tranLines = tranFile.GetLines(idBox.Text);
            lineBox.Text = Utils.FormatLines(origFile, tranFile, idBox.Text, colorCheckBox.Checked);

            if (string.IsNullOrWhiteSpace(lineBox.Text) || lineBox.Text.Contains($"[{Language.Strings.Generic_Error}]"))
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
                newfc.contentId = contentID;
            else
                newfc.contentId = ld.fc.contentId;

            CloseForm(true);
        }

        private void colorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            lineBox.Text = Utils.FormatLines(origFile, tranFile, idBox.Text, colorCheckBox.Checked);
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
            if (string.IsNullOrWhiteSpace(lineBox.Text) || lineBox.Text.Contains($"[{Language.Strings.Generic_Error}]"))
                colorCheckBox.Enabled = false;
            else
                colorCheckBox.Enabled = true;

            CheckSaveBtn();
        }

        private void CheckSaveBtn()
        {
            if (lineBox.Text.Contains($"[{Language.Strings.Generic_Error}]") ||
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
                insertLineIDBtn.Enabled = true;
                insertFileLineIDBtn.Enabled = true;
            }
            else
            {
                plainTextBtn.Enabled = false;
                insertLineIDBtn.Enabled = false;
                insertFileLineIDBtn.Enabled = false;
            }
        }

        private void copyLineBtn_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            string currentLine;
            var gmd = GameFile.Get(projectType);

            if (tranLines.Length == 1)
            {
                currentLine = tranLines[0].Item2;

                if (!colorCheckBox.Checked)
                    currentLine = gmd.RemoveColors(currentLine);

                if (commentCheckBox.Checked)
                    sb.Append($"<n>{currentLine}</n>");
                else
                    sb.Append(currentLine);
            }
            else
            {
                var lastChar = string.Empty;
                var sameChar = false;

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
                            sb.AppendLine($"<n>**{line.Item1}**</n>");
                        else
                            sb.AppendLine($"**{line.Item1}:**");
                    }

                    currentLine = line.Item2;

                    if (!colorCheckBox.Checked)
                        currentLine = gmd.RemoveColors(currentLine);

                    if (commentCheckBox.Checked)
                        sb.AppendLine($"<n>{currentLine}</n>");
                    else
                        sb.AppendLine(currentLine);

                    if (!Equals(tranLines.Last(), line))
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
            var ilid = new InsertLineID();

            if (ilid.ShowDialog() == DialogResult.OK)
            {
                var sb = new StringBuilder();

                if (!commentBox.Text.EndsWith(" ") && commentBox.Text.Length > 0)
                    sb.Append(" ");

                sb.Append($"`{ilid.lineId}`");

                commentBox.SelectedText = sb.ToString();
            }

            commentBox.Focus();
        }

        private void insertFileLineIdBtn_Click(object sender, EventArgs e)
        {
            var ifn = new InsertFileName(ld.filelist, ld.tranPath);

            if (ifn.ShowDialog() == DialogResult.OK)
            {
                var ilid = new InsertLineID();

                if (ilid.ShowDialog() == DialogResult.OK)
                {
                    var sb = new StringBuilder();

                    if (!commentBox.Text.EndsWith(" ") && commentBox.Text.Length > 0)
                        sb.Append(" ");

                    sb.Append($"`{ifn.filename}:{ilid.lineId}`");

                    commentBox.SelectedText = sb.ToString();
                }
            }

            commentBox.Focus();
        }

        private void normalTextBtn_Click(object sender, EventArgs e)
        {
            commentBox.SelectedText = $"<n>{commentBox.SelectedText}</n>";
            commentBox.Select(commentBox.SelectionStart - 4, 0);
            commentBox.Focus();
        }

        private void prevLinesBtn_Click(object sender, EventArgs e)
        {
            var ole = new OtherLinesEditor(origFile, tranFile, prevLinesBtn.Text);
            var dr = ole.ShowDialog();

            if (dr == DialogResult.OK)
            {
                prevLinesBtn.Text = ole.lineId;
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
            var (text, cursor) = Utils.FormatIds(idBox.Text, idBox.SelectionStart);

            idBox.Text = text;
            idBox.Select(cursor, 0);
        }
    }
}
