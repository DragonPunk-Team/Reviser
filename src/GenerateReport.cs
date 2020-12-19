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

        string lastChar = "";
        GMD origGMD;
        GMD tranGMD;

        public GenerateReport(ProjectFile project)
        {
            InitializeComponent();

            pf = project;
        }

        private void GenerateReport_Load(object sender, EventArgs e)
        {
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

                if (file.Value.content.Count > 1)
                    file.Value.content.Sort(new CustomListSort());

                progressBar.Value = (Array.IndexOf(pf.project.files.ToArray(), file) + 1 ) / pf.project.files.Count;
            }
        }

        private void Generate()
        {
            progressBar.Value = 0;
            statusLabel.Text = "Generating report...";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("# " + pf.project.name);
            sb.AppendLine();

            foreach (string file in pf.project.files.Keys)
            {
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
                        var proposal = fc.proposal;

                        proposal = Replace(@"(\r\n| |)(\`[a-z0-9_.:]*\`)(\r\n| |)", proposal);
                        proposal = Replace(@"(\r\n| |)<n>(.*)</n>(\r\n| |)", proposal);

                        if (!(Matches(@"_", proposal) % 2 == 0))
                            sb.Append("_");

                        sb.Append(proposal);

                        if ((Matches(@"_", proposal) % 2 == 0))
                            sb.Append("_");

                        sb.AppendLine();
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
                }

                progressBar.Value = (Array.IndexOf(pf.project.files.Keys.ToArray(), file) + 1) / pf.project.files.Count;
            }

            sb.Length -= 3;

            File.WriteAllText(path, sb.ToString());

            this.Hide();
            SystemSounds.Beep.Play();
            MessageBox.Show("Report generated successfully.", "Done!", MessageBoxButtons.OK);
            this.Close();
        }

        private string Replace(string regex, string line)
        {
            StringBuilder sb = new StringBuilder();
            Regex rx = new Regex(regex, RegexOptions.Compiled);

            MatchCollection matches = rx.Matches(line);

            foreach (Match match in matches)
            {
                if (!string.IsNullOrEmpty(match.Groups[1].Value))
                    sb.Append("_" + match.Groups[1].Value);

                sb.Append(match.Groups[2]);

                if (!string.IsNullOrEmpty(match.Groups[3].Value))
                    sb.Append(match.Groups[3].Value + "_");
            }

            return rx.Replace(line, sb.ToString());
        }

        private string FormatLine(string origLine, string tranLine, string character, string file, int contentId)
        {
            StringBuilder sb = new StringBuilder();
            lastChar = "";

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

        private int Matches(string regex, string line)
        {
            Regex rx = new Regex(regex, RegexOptions.Compiled);
            var matches = rx.Matches(line);

            return matches.Count;
        }
    }
}
