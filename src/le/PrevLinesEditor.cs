using System;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Reviser
{
    public partial class PrevLinesEditor : Form
    {
        GMD origGMD;
        GMD tranGMD;
        bool color;
        public string lineId;

        Regex idRx = new Regex(@"[^0-9-, ]*", RegexOptions.Compiled);

        public PrevLinesEditor(GMD origGMD, GMD tranGMD, bool color, string lineId)
        {
            InitializeComponent();

            this.origGMD = origGMD;
            this.tranGMD = tranGMD;
            this.color = color;
            this.lineId = lineId;
        }

        private void PrevLinesEditor_Load(object sender, EventArgs e)
        {
            if (lineId != "-1")
            {
                Text = Text.Replace("Add", "Edit");
                idBox.Text = lineId;
                removeBtn.Enabled = true;

                searchBtn_Click(sender, e);
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

                if (!color)
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

                    if (!color)
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
            CheckAddBtn();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            CloseForm(remove: true);
        }

        private void CloseForm(bool save = false, bool remove = false)
        {
            if (save)
                DialogResult = DialogResult.OK;
            else if (remove)
                DialogResult = DialogResult.Abort;
            else
                DialogResult = DialogResult.Cancel;

            Close();
        }

        private void CheckAddBtn()
        {
            if (lineBox.Text.Contains("[Error]") || string.IsNullOrWhiteSpace(lineBox.Text))
                addBtn.Enabled = false;
            else
                addBtn.Enabled = true;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            lineId = LEUtils.CleanIds(idBox.Text);
            CloseForm(save: true);
        }

        private void idBox_TextChanged(object sender, EventArgs e)
        {
            var cursorPos = idBox.SelectionStart;
            var newText = idRx.Replace(idBox.Text, "");

            if (idBox.Text != newText)
                cursorPos--;

            idBox.Text = newText;
            idBox.Select(cursorPos, 0);
        }
    }
}
