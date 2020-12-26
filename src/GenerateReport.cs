using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Reviser
{
    public partial class GenerateReport : Form
    {
        ProjectFile pf;
        public string path;

        GMD origGMD;
        GMD tranGMD;

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
                int count = 0;

                foreach (string file in pf.project.files.Keys)
                {
                    count += pf.project.files[file].content.Count;
                }

                if (count > 0)
                    return false;
                else
                    return true;
            }
            else
            {
                return true;
            }
        }

        private void OrderProjectFile()
        {
            statusLabel.Text = "Ordering files...";
            progressBar.Style = ProgressBarStyle.Marquee;
            Application.DoEvents();

            if (pf.project.files.Count > 1)
            {
                var files = new Dictionary<string, ProjectFile.RevisedFile>();

                foreach (string filename in pf.project.file_list)
                    foreach (var file in pf.project.files)
                        if (filename == file.Key)
                            files.Add(file.Key, file.Value);

                pf.project.files = files;
            }

            progressBar.Style = ProgressBarStyle.Continuous;

            foreach (var file in pf.project.files)
            {
                statusLabel.Text = "Ordering " + file.Key + "...";
                Application.DoEvents();

                if (file.Value.content.Count > 1)
                    file.Value.content.Sort(new CustomListSort());

                progressBar.Value = ((Array.IndexOf(pf.project.files.Keys.ToArray(), file) + 1) * 100) / pf.project.files.Count;
                Application.DoEvents();
            }
        }

        private void Generate()
        {
            progressBar.Value = 0;
            statusLabel.Text = "Generating report...";
            Application.DoEvents();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("# " + pf.project.name);
            sb.AppendLine();

            int totalPBValue = 0;

            foreach (string file in pf.project.files.Keys)
            {
                int fileIndex = Array.IndexOf(pf.project.files.Keys.ToArray(), file) + 1;
                int filePBValue = fileIndex * 100 / pf.project.files.Count;

                statusLabel.Text = "Adding file " + file + "...";

                origGMD = new GMD();
                tranGMD = new GMD();

                var filePath = "\\" + file;

                origGMD.ReadGMD(pf.project.orig_path + filePath);
                tranGMD.ReadGMD(pf.project.tran_path + filePath);

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
                    {
                        var proposal = "_" + fc.proposal + "_";
                        proposal = proposal.Replace("\r\n", "\n");

                        proposal = Regex.Replace(proposal, @"(\n)<n>", "_\n");
                        proposal = Regex.Replace(proposal, @"</n>_", "");
                        proposal = MatchReplace(@"^_<n>(.*)</n>\n", proposal, "", "\n_");
                        proposal = Regex.Replace(proposal, @"</n>(\n)", "\n_");
                        proposal = MatchReplace(@" (`.*`)[\n|]*_?", proposal, "_ ", "");
                        proposal = Regex.Replace(proposal, @"__", "");
                        proposal = MatchReplaceTwo(@"(`.*`)([^\n])", proposal, "_");
                        proposal = MatchReplace(@"(:)\n", proposal, "", "_\n");

                        foreach (string line in proposal.Split('\n'))
                            if (line.Length > 0 && !line.StartsWith("_"))
                                proposal = proposal.Replace(line, MatchReplace(@"^_?(.*)_$", line, "", ""));

                        proposal = MatchReplace(@"\n_\n(.)", proposal, "\n\n", "");

                        sb.AppendLine(proposal);
                    }
                    else
                    {
                        sb.AppendLine(fc.proposal);
                    }

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

            sb.Length -= 3;

            File.WriteAllText(path, sb.ToString());

            Hide();
            SystemSounds.Beep.Play();
            MessageBox.Show("Report generated successfully.", "Done!", MessageBoxButtons.OK);
            Close();
        }

        private string MatchReplace(string regex, string line, string beforeRepl, string afterRepl)
        {
            Regex rx = new Regex(regex, RegexOptions.Compiled);
            Match match = rx.Match(line);
            return rx.Replace(line, beforeRepl + match.Groups[1].Value + afterRepl);
        }

        private string MatchReplaceTwo(string regex, string line, string betweenRepl)
        {
            Regex rx = new Regex(regex, RegexOptions.Compiled);
            Match match = rx.Match(line);
            return rx.Replace(line, match.Groups[1].Value + betweenRepl + match.Groups[2].Value);
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

            sb.AppendLine(origLine);

            if (!item.color)
                tranLine = tranGMD.RemoveColors(tranLine);

            sb.AppendLine(tranLine);

            return sb.ToString();
        }
    }
}
