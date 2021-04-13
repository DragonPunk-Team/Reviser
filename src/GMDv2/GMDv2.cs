using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Reviser.SoJ
{
    public class GMDv2
    {
        private Tuple<string, string>[][] Content;

        #region Regex
        // Used in GetCharacter()
        private Regex charRx = new Regex(@"<E041 [0-9]* ([0-9]*)>", RegexOptions.Compiled);

        // Used in GetColor()
        private Regex redRx = new Regex(@"<E006>", RegexOptions.Compiled);
        private Regex endRx = new Regex(@"<E00(5|7|8)>", RegexOptions.Compiled);

        // Used in RemoveColors()
        private Regex colRx = new Regex(@"<(|\/)red>", RegexOptions.Compiled);

        // Used to remove tags.
        private Regex tagRx = new Regex(@"<[A-Z 0-9_]*>", RegexOptions.Compiled);
        #endregion

        public void ReadFile(object filepath)
        {
            var path = filepath.ToString();

            var fstr = File.OpenRead(path);
            var br = new BinaryReader(fstr);

            // Skip first 24 bytes: we don't need those
            fstr.Seek(24, SeekOrigin.Begin);

            // Get amount of sections
            int Sections = br.ReadInt32();

            // Skip next 4 bytes: we don't need those
            fstr.Seek(4, SeekOrigin.Current);

            // Get total size of sections
            int SectionSize = br.ReadInt32();

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
            List<string> content = new List<string>();
            List<byte> bytes = new List<byte>();

            foreach (byte ch in blob)
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
            int section = 0;

            foreach (string str in blob)
            {
                int labelIndex = Array.IndexOf(blob, str);
                string[] strContent = str.Split(new string[] { "<PAGE>" }, StringSplitOptions.None);
                var sectionData = new List<Tuple<string, string>>();

                foreach (string strC in strContent)
                {
                    string line = strC.Trim().Replace("\r\n", " ");
                    string characterName = GetCharacter(line);
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
            var characterName = "";
            Cast cast = new Cast();
            MatchCollection matches = charRx.Matches(line);

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
            return colRx.Replace(line, "");
        }

        private int[] GetIdList(string lineIds)
        {
            var idList = new List<int>();

            Regex rx = new Regex(@"([0-9]*-?)*", RegexOptions.Compiled);

            MatchCollection ids = rx.Matches(lineIds);

            foreach (Match id in ids)
            {
                if (!string.IsNullOrWhiteSpace(id.Value))
                {
                    if (id.Value.Contains("-"))
                    {
                        var split = id.Value.Split('-');
                        var limits = new int[] { int.Parse(split[0]), int.Parse(split[1]) };

                        for (int i = limits[0]; i <= limits[1]; i++)
                            idList.Add(i);
                    }
                    else
                    {
                        idList.Add(int.Parse(id.Value));
                    }
                }
            }

            return idList.ToArray();
        }

        private Tuple<string, string> GetLine(int lineId)
        {
            // First line is always 5, but since we are going to
            // use lineId as an array index, we need to add 1,
            // since we are going to subtract this value to
            // obtain the actual index.
            int firstLine = 6;

            // Also, keep count of the sections and headers/footers
            // length to be able to find the requested line in the file.
            int totalLength = 0;

            foreach (var section in Content)
            {
                int index = lineId - totalLength - firstLine;

                if (index >= 0 && index < section.Length)
                    return section[index];
                else
                    totalLength += section.Length + 2;
            }

            return null;
        }

        public Tuple<string, string>[] GetLines(string lineIds)
        {
            var lines = new List<Tuple<string, string>>();

            int[] idList = GetIdList(lineIds);

            foreach (int id in idList)
            {
                if (id > 0)
                {
                    var line = GetLine(id);

                    if (line != null && !string.IsNullOrEmpty(line.Item2) && !lines.Contains(line))
                        lines.Add(line);
                }
            }

            if (lines.Count == 0)
                lines.Add(new Tuple<string, string>("Error", "No lines found!"));

            return lines.ToArray();
        }
    }
}
