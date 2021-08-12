using System;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

using Reviser.Files;
using Reviser.Tweaks;

namespace Reviser
{
    public partial class GenerateReport : Form
    {
        private readonly ProjectFile pf;
        public string path;

        private IFile origFile;
        private IFile tranFile;

        #region Regex
        // Used in FormatProposal()
        private readonly Regex codeRx = new (@"(.*)([ ?])(\`.*\`)(.*)", RegexOptions.Compiled);
        private readonly Regex normRx = new (@"<n>(.*)</n>", RegexOptions.Compiled);
        #endregion

        public GenerateReport(ProjectFile project)
        {
            InitializeComponent();

            pf = project;
        }

        private void GenerateReport_Load(object sender, EventArgs e)
        {
            Show();

            origFile = GameFile.Get(pf.project.type);
            tranFile = GameFile.Get(pf.project.type);

            OrderProjectFile();
            Generate();
        }

        public bool ProjectEmpty()
        {
            return pf.project.files.Count <= 0 || pf.project.files.Keys.All(file => pf.project.files[file].content.Count <= 0);
        }

        private void OrderProjectFile()
        {
            foreach (var file in pf.project.files.Where(file => file.Value.content.Count > 1))
                file.Value.content.Sort(new CustomListSort());
        }

        private void Generate()
        {
            var sb = new StringBuilder();

            sb.AppendLine("# " + pf.project.name);
            sb.AppendLine();

            var totalPBValue = 0;

            foreach (var file in pf.project.files.Keys)
            {
                if (!pf.project.files[file].complete) continue;

                var fileIndex = Array.IndexOf(pf.project.files.Keys.ToArray(), file) + 1;
                var filePBValue = fileIndex * 100 / pf.project.files.Count;

                statusLabel.Text = string.Format(Language.Strings.GenerateReport_AddingFile, file);

                var filePath = "\\" + file;

                var orig = new Thread(origFile.ReadFile);
                var tran = new Thread(tranFile.ReadFile);

                orig.Start(pf.project.orig_path + filePath);
                tran.Start(pf.project.tran_path + filePath);

                while (orig.ThreadState == ThreadState.Running || tran.ThreadState == ThreadState.Running)
                    Application.DoEvents();

                if (pf.project.files[file].content.Count <= 0) continue;

                sb.AppendLine("## `" + file + "`");
                sb.AppendLine();

                if (!string.IsNullOrWhiteSpace(pf.project.files[file].note))
                {
                    sb.AppendLine("### " + pf.project.files[file].note);
                    sb.AppendLine();
                }

                foreach (var fc in pf.project.files[file].content)
                {
                    sb.AppendLine("### " + fc.lineId);
                    sb.AppendLine();

                    var origLines = origFile.GetLines(fc.lineId);
                    var tranLines = tranFile.GetLines(fc.lineId);

                    foreach (var line in origLines)
                    {
                        if (line.Item1.Length == 0)
                            sb.Length -= 4;

                        var index = Array.IndexOf(origLines, line);
                        sb.AppendLine(FormatLine(line.Item2, tranLines[index].Item2, line.Item1, file, fc.contentId));
                    }

                    sb.AppendLine($@"**{Language.Strings.GenerateReport_Proposal}:**");

                    if (fc.comment)
                        sb.AppendLine(FormatProposal(fc.proposal).Replace("*", "\\*"));
                    else
                        sb.AppendLine(fc.proposal.Replace("*", "\\*"));

                    if (fc.prevLineId != "-1")
                    {
                        var origPrevLines = origFile.GetLines(fc.prevLineId);
                        var tranPrevLines = tranFile.GetLines(fc.prevLineId);

                        sb.Append("\n\n");

                        if (origPrevLines.Length > 1)
                            sb.AppendLine($@"**{Language.Strings.GenerateReport_PreviousLine_Plural}:**");
                        else
                            sb.AppendLine($@"**{Language.Strings.GenerateReport_PreviousLine}:**");

                        sb.Append("\n\n");

                        foreach (var prevLine in origPrevLines)
                        {
                            var prevIndex = Array.IndexOf(origPrevLines, prevLine);
                            sb.AppendLine(FormatLine(prevLine.Item2, tranPrevLines[prevIndex].Item2, prevLine.Item1, file, fc.contentId));
                        }
                    }

                    sb.Append("\n\n\n");

                    var fcIndex = Array.IndexOf(pf.project.files[file].content.ToArray(), fc) + 1;
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
            MessageBox.Show(Language.Strings.GenerateReport_DoneMsg, Language.Strings.GenerateReport_Done, MessageBoxButtons.OK);
            Close();
        }

        private string FormatProposal(string proposal)
        {
            proposal = proposal.Replace("\r\n", "\n");
            var lines = proposal.Split('\n');

            var sb = new StringBuilder();

            foreach (var line in lines)
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
            var sb = new StringBuilder();
            var lastChar = "";

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
                origLine = origFile.RemoveColors(origLine);

            sb.AppendLine(origLine.Replace("*", "\\*"));

            if (!item.color)
                tranLine = tranFile.RemoveColors(tranLine);

            sb.AppendLine(tranLine.Replace("*", "\\*"));

            return sb.ToString();
        }
    }
}
