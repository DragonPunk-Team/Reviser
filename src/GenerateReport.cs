using System;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

using Reviser.SoJ;
using Reviser.Tweaks;

namespace Reviser
{
    public partial class GenerateReport : Form
    {
        ProjectFile pf;
        public string path;

        private GMDv2 origGMD = new GMDv2();
        private GMDv2 tranGMD = new GMDv2();

        #region Regex
        // Used in FormatProposal()
        private Regex codeRx = new Regex(@"(.*)([ ?])(\`.*\`)(.*)", RegexOptions.Compiled);
        private Regex normRx = new Regex(@"<n>(.*)</n>", RegexOptions.Compiled);
        #endregion

        public GenerateReport(ProjectFile project)
        {
            InitializeComponent();

            pf = project;
        }

        private void GenerateReport_Load(object sender, EventArgs e)
        {
            Show();
            OrderProjectFile();
            Generate();
        }

        public bool ProjectEmpty()
        {
            if (pf.project.files.Count > 0)
            {
                foreach (string file in pf.project.files.Keys)
                    if (pf.project.files[file].content.Count > 0)
                        return false;

                return true;
            }
            else
            {
                return true;
            }
        }

        private void OrderProjectFile()
        {
            foreach (var file in pf.project.files)
                if (file.Value.content.Count > 1)
                    file.Value.content.Sort(new CustomListSort());
        }

        private void Generate()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("# " + pf.project.name);
            sb.AppendLine();

            int totalPBValue = 0;

            foreach (string file in pf.project.files.Keys)
            {
                if (pf.project.files[file].complete)
                {
                    int fileIndex = Array.IndexOf(pf.project.files.Keys.ToArray(), file) + 1;
                    int filePBValue = fileIndex * 100 / pf.project.files.Count;

                    statusLabel.Text = "Adding file " + file + "...";

                    var filePath = "\\" + file;

                    Thread orig = new Thread(origGMD.ReadFile);
                    Thread tran = new Thread(tranGMD.ReadFile);

                    orig.Start(pf.project.orig_path + filePath);
                    tran.Start(pf.project.tran_path + filePath);

                    while (orig.ThreadState == ThreadState.Running || tran.ThreadState == ThreadState.Running)
                        Application.DoEvents();

                    if (pf.project.files[file].content.Count > 0)
                    {
                        sb.AppendLine("## `" + file + "`");
                        sb.AppendLine();

                        if (!string.IsNullOrWhiteSpace(pf.project.files[file].note))
                        {
                            sb.AppendLine("### " + pf.project.files[file].note);
                            sb.AppendLine();
                        }

                        foreach (ProjectFile.FileContent fc in pf.project.files[file].content)
                        {
                            sb.AppendLine("### " + fc.lineId);
                            sb.AppendLine();

                            var origLines = origGMD.GetLines(fc.lineId);
                            var tranLines = tranGMD.GetLines(fc.lineId);

                            foreach (var line in origLines)
                            {
                                if (line.Item1.Length == 0)
                                    sb.Length -= 4;

                                int index = Array.IndexOf(origLines, line);
                                sb.AppendLine(FormatLine(line.Item2, tranLines[index].Item2, line.Item1, file, fc.contentId));
                            }

                            sb.AppendLine("**Proposta:**");

                            if (fc.comment)
                                sb.AppendLine(FormatProposal(fc.proposal).Replace("*", "\\*"));
                            else
                                sb.AppendLine(fc.proposal.Replace("*", "\\*"));

                            if (fc.prevLineId != "-1")
                            {
                                var origPrevLines = origGMD.GetLines(fc.prevLineId);
                                var tranPrevLines = tranGMD.GetLines(fc.prevLineId);

                                sb.Append("\n\n");

                                if (origPrevLines.Length > 1)
                                    sb.AppendLine("**Frasi precedenti:**");
                                else
                                    sb.AppendLine("**Frase precedente:**");

                                sb.Append("\n\n");

                                foreach (var prevLine in origPrevLines)
                                {
                                    int prevIndex = Array.IndexOf(origPrevLines, prevLine);
                                    sb.AppendLine(FormatLine(prevLine.Item2, tranPrevLines[prevIndex].Item2, prevLine.Item1, file, fc.contentId));
                                }
                            }

                            sb.Append("\n\n\n");

                            int fcIndex = Array.IndexOf(pf.project.files[file].content.ToArray(), fc) + 1;
                            totalPBValue += fcIndex / pf.project.files[file].content.Count;
                            progressBar.Value = totalPBValue;
                            Application.DoEvents();
                        }

                        totalPBValue = filePBValue;
                        progressBar.Value = totalPBValue;
                        Application.DoEvents();
                    }
                }
            }

            sb.Length -= 3;

            File.WriteAllText(path, sb.ToString());

            Hide();
            SystemSounds.Beep.Play();
            MessageBox.Show("Report generated successfully.", "Done!", MessageBoxButtons.OK);
            Close();
        }

        private string FormatProposal(string proposal)
        {
            proposal = proposal.Replace("\r\n", "\n");
            var lines = proposal.Split('\n');

            StringBuilder sb = new StringBuilder();

            foreach (string line in lines)
            {
                if (line.Length > 0)
                {
                    if (line.Contains("`"))
                    {
                        foreach (Match match in codeRx.Matches(line))
                        {
                            sb.Append("_" + match.Groups[1].Value + "_" + match.Groups[2].Value + match.Groups[3].Value);

                            if (match.Groups[4].Length > 0)
                                sb.Append("_" + match.Groups[4].Value + "_");
                        }
                    }

                    if (line.Contains("<n>") && line.Contains("</n>"))
                    {
                        foreach (Match match in normRx.Matches(line))
                        {
                            var plain = match.Groups[1].Value;
                            var text = line.Replace("<n>" + plain + "</n>", "");

                            if (!string.IsNullOrWhiteSpace(text))
                            {
                                sb.Append("_" + text);

                                if (sb[sb.Length - 1] == ' ')
                                {
                                    sb.Remove(sb.Length - 1, 1);
                                    sb.Append("_ ");
                                }
                                else
                                {
                                    sb.Append("_");
                                }
                            }

                            sb.Append(plain);
                        }
                    }

                    if (!line.Contains("`") && !line.Contains("<n>") && !line.Contains("</n>"))
                        sb.Append("_" + line + "_");
                }

                sb.AppendLine();
            }

            if (sb.ToString().EndsWith("\n"))
                sb.Length -= 2;

            return sb.ToString();
        }

        private string FormatLine(string origLine, string tranLine, string character, string file, int contentId)
        {
            StringBuilder sb = new StringBuilder();
            string lastChar = "";

            if (character == lastChar)
            {
                sb.Append("\n\n");
            }
            else if (character.Length > 0)
            {
                lastChar = character;
                sb.AppendLine("**" + character + ":**");
            }

            var item = pf.project.files[file].content.Single(line => line.contentId == contentId);

            if (!item.color)
                origLine = origGMD.RemoveColors(origLine);

            sb.AppendLine(origLine.Replace("*", "\\*"));

            if (!item.color)
                tranLine = tranGMD.RemoveColors(tranLine);

            sb.AppendLine(tranLine.Replace("*", "\\*"));

            return sb.ToString();
        }
    }
}
