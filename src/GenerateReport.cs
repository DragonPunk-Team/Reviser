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
        private readonly Regex codeRx = new (@"`([^`]*)`", RegexOptions.Compiled);
        private readonly Regex normRx = new (@"<n>([^</>]*)</n>", RegexOptions.Compiled);

        // Used in FormatPlainText()
        private readonly Regex nonWordRx = new(@"\W", RegexOptions.Compiled);
        #endregion

        public GenerateReport(ProjectFile project)
        {
            InitializeComponent();

            pf = project;
        }

        private void GenerateReport_Load(object sender, EventArgs e)
        {
            Show();

            PrepareGameFiles();
            OrderProjectFile();
            Generate();
        }

        private void PrepareGameFiles()
        {
            origFile = GameFile.Get(pf.project.type);
            tranFile = GameFile.Get(pf.project.type);

            origFile.SetGame(pf.project.type);
            tranFile.SetGame(pf.project.type);
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

            sb.AppendLine($"# {pf.project.name}\n");

            var totalPBValue = 0;

            foreach (var file in pf.project.files.Keys)
            {
                if (!pf.project.files[file].complete) continue;

                var fileIndex = Array.IndexOf(pf.project.files.Keys.ToArray(), file) + 1;
                var filePBValue = fileIndex * 100 / pf.project.files.Count;

                statusLabel.Text = string.Format(Language.Strings.GenerateReport_AddingFile, file);

                var orig = new Thread(origFile.ReadFile);
                var tran = new Thread(tranFile.ReadFile);

                orig.Start($"{pf.project.orig_path}\\{file}");
                tran.Start($"{pf.project.tran_path}\\{file}");

                while (orig.ThreadState == ThreadState.Running || tran.ThreadState == ThreadState.Running)
                    Application.DoEvents();

                if (pf.project.files[file].content.Count <= 0) continue;

                sb.AppendLine($"## `{file}`\n");

                if (!string.IsNullOrWhiteSpace(pf.project.files[file].note))
                    sb.AppendLine($"### {pf.project.files[file].note}\n");

                foreach (var fc in pf.project.files[file].content)
                {
                    sb.AppendLine($"### {fc.lineId}\n");

                    var origLines = origFile.GetLines(fc.lineId);
                    var tranLines = tranFile.GetLines(fc.lineId);

                    foreach (var line in origLines)
                    {
                        if (line.Item1.Length == 0)
                            sb.Length -= 4;

                        var index = Array.IndexOf(origLines, line);
                        sb.AppendLine(FormatLine(line.Item2, tranLines[index].Item2, line.Item1, file, fc.contentId));
                    }

                    sb.AppendLine($"**{Language.Strings.GenerateReport_Proposal}:**");

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
                            sb.AppendLine($"**{Language.Strings.GenerateReport_PreviousLine_Plural}:**");
                        else
                            sb.AppendLine($"**{Language.Strings.GenerateReport_PreviousLine}:**");

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
            var lines = proposal.Replace("\r\n", "\n").Split('\n');

            var sb = new StringBuilder();

            foreach (var line in lines)
            {
                if (line.Length > 0)
                {
                    var newLine = line;

                    if (newLine.Contains("`"))
                    {
                        foreach (Match match in codeRx.Matches(line))
                        {
                            var plain = match.Groups[1].Value;
                            newLine = newLine.Replace($"`{plain}`", $"<n>`{plain}`</n>");
                        }
                    }

                    if (newLine.Contains("<n>") && newLine.Contains("</n>"))
                    {
                        var strIndex = 0;
                        var matches = normRx.Matches(newLine);

                        foreach (Match match in matches)
                        {
                            var plain = match.Groups[1].Value;
                            var text = newLine.Substring(strIndex).Split(new[] { $"<n>{plain}</n>" }, StringSplitOptions.None);

                            if (text.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(text[0]))
                                {
                                    sb.Append(FormatPlainText(text[0]));
                                    strIndex += text[0].Length;
                                }

                                sb.Append(plain);
                                strIndex += 7 + plain.Length;
                            }
                        }

                        var endLine = newLine.Substring(strIndex);

                        if (!string.IsNullOrEmpty(endLine))
                            sb.Append(FormatPlainText(endLine));
                    }

                    if (!newLine.Contains("`") && !newLine.Contains("<n>") && !newLine.Contains("</n>"))
                        sb.Append($"_{newLine}_");
                }

                sb.AppendLine();
            }

            if (sb.ToString().EndsWith("\n"))
                sb.Length -= 2;

            return sb.ToString();
        }

        private string FormatPlainText(string text)
        {
            var sb = new StringBuilder();

            if (nonWordRx.IsMatch(text.Substring(0, 1)))
            {
                var ch = text[0];

                if (ch == ' ')
                    sb.Append(" _");
                else
                    sb.Append($"_{ch}");

                text = text.Remove(0, 1);
            }
            else
            {
                sb.Append("_");
            }

            sb.Append(text);

            var len = text.Length;

            if (nonWordRx.IsMatch(text.Substring(len - 1, 1)))
            {
                var ch = text[len - 1];

                sb.Remove(sb.Length - 1, 1);

                if (ch == ' ')
                    sb.Append("_ ");
                else
                    sb.Append($"{ch}_");
            }
            else
            {
                sb.Append("_");
            }

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
                sb.AppendLine($"**{character}:**");
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
