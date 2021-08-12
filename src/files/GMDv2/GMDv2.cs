using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Reviser.Files.SoJ
{
    public class GMDv2 : IFile
    {
        private Tuple<string, string>[][] Content;

        #region Regex
        // Used in GetCharacter()
        private readonly Regex charRx = new (@"<E041 [0-9]* ([0-9]*)>", RegexOptions.Compiled);

        // Used in GetColor()
        private readonly Regex redRx = new (@"<E006>", RegexOptions.Compiled);
        private readonly Regex endRx = new (@"<E00(5|7|8)>", RegexOptions.Compiled);

        // Used in RemoveColors()
        private readonly Regex colRx = new (@"<(|\/)red>", RegexOptions.Compiled);

        // Used to remove tags.
        private readonly Regex tagRx = new (@"<[A-Z 0-9_]*>", RegexOptions.Compiled);
        #endregion

        public void ReadFile(object filepath)
        {
            var path = filepath.ToString();

            var fstr = File.OpenRead(path);
            var br = new BinaryReader(fstr);

            // Skip first 24 bytes: we don't need those
            fstr.Seek(24, SeekOrigin.Begin);

            // Get amount of sections
            var Sections = br.ReadInt32();

            // Skip next 4 bytes: we don't need those
            fstr.Seek(4, SeekOrigin.Current);

            // Get total size of sections
            var SectionSize = br.ReadInt32();

            // Seek the content from the end of the file
            fstr.Seek(-SectionSize, SeekOrigin.End);

            // Split contents
            var contentBlob = SplitBytes(br.ReadBytes(SectionSize));
            Content = SplitStrings(Sections, contentBlob);

            br.Close();
            fstr.Close();
        }

        private string[] SplitBytes(byte[] blob)
        {
            var content = new List<string>();
            var bytes = new List<byte>();

            foreach (var ch in blob)
            {
                if (ch == 0)
                {
                    content.Add(Encoding.UTF8.GetString(bytes.ToArray()));
                    bytes.Clear();
                }
                else
                {
                    bytes.Add(ch);
                }
            }

            return content.ToArray();
        }

        private Tuple<string, string>[][] SplitStrings(int sections, string[] blob)
        {
            var content = new Tuple<string, string>[sections][];
            var section = 0;

            foreach (var str in blob)
            {
                var strContent = str.Split(new[] { "<PAGE>" }, StringSplitOptions.None);
                var sectionData = new List<Tuple<string, string>>();

                foreach (var strC in strContent)
                {
                    var line = strC.Trim().Replace("\r\n", " ");
                    var characterName = GetCharacter(line);
                    line = GetColor(line);
                    sectionData.Add(new Tuple<string, string>(characterName, line));
                }

                content[section] = sectionData.ToArray();
                section++;
            }

            return content;
        }

        private string GetCharacter(string line)
        {
            var characterName = string.Empty;
            var cast = new Cast();
            var matches = charRx.Matches(line);

            foreach (Match match in matches)
                characterName = cast.GS6[int.Parse(match.Groups[1].Value)];

            return characterName;
        }

        private string GetColor(string line)
        {
            var coloredLine = redRx.Replace(line, "<red>");

            if (coloredLine == line)
            {
                return tagRx.Replace(line, "");
            }
            else
            {
                coloredLine = endRx.Replace(coloredLine, "</red>");
                coloredLine = tagRx.Replace(coloredLine, "");

                if (coloredLine.StartsWith("</red>"))
                    // The string "</red>" is 6 characters long.
                    coloredLine = coloredLine.Remove(0, 6);

                return coloredLine;
            }
        }

        public string RemoveColors(string line)
        {
            return colRx.Replace(line, string.Empty);
        }

        private Tuple<string, string> GetLine(int lineID)
        {
            // First line is always 5, but since we are going to
            // use lineID as an array index, we need to add 1,
            // since we are going to subtract this value to
            // obtain the actual index.
            const int firstLine = 6;

            // Also, keep count of the sections and headers/footers
            // length to be able to find the requested line in the file.
            var totalLength = 0;

            foreach (var section in Content)
            {
                var index = lineID - totalLength - firstLine;

                if (index >= 0 && index < section.Length)
                    return section[index];
                else
                    totalLength += section.Length + 2;
            }

            return null;
        }

        public Tuple<string, string>[] GetLines(string lineIDs)
        {
            var lines = new List<Tuple<string, string>>();

            var idList = Utils.GetIDList(lineIDs);

            foreach (var id in idList)
            {
                if (id <= 0) continue;

                var line = GetLine(id);

                if (line != null && !string.IsNullOrEmpty(line.Item2) && !lines.Contains(line))
                    lines.Add(line);
            }

            if (lines.Count == 0)
                lines.Add(new Tuple<string, string>(Language.Strings.Generic_Error, Language.Strings.Generic_NoLinesFoundError));

            return lines.ToArray();
        }
    }
}
