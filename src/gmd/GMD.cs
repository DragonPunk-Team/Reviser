using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Reviser
{
    public class GMD
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
        private Regex tagRx = new Regex(@"<[A-Z 0-9]*>", RegexOptions.Compiled);
        #endregion

        public void ReadGMD(object filepath)
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
                {
                    Regex rx = new Regex(@"<\/red>", RegexOptions.Compiled);
                    return rx.Replace(line, "", 1);
                }

                return coloredLine;
            }
        }

        public string RemoveColors(string line)
        {
            return colRx.Replace(line, "");
        }

        public int[] GetIdList(string lineIds)
        {
            var idList = new List<int>();

            Regex mainRx = new Regex(@"[0-9]*", RegexOptions.Compiled);
            Regex sepRx = new Regex(@"-|,", RegexOptions.Compiled);

            // Check for ids separated by a dash (-),
            // multiple different lines.
            bool multiline = false;

            // Check for ids separated by a comma (,),
            // they may be two different lines.
            bool diffLines = false;

            MatchCollection ids = mainRx.Matches(lineIds);
            MatchCollection seps = sepRx.Matches(lineIds);

            foreach (Match sep in seps)
            {
                if (sep.Value == "-")
                    multiline = true;

                if (sep.Value == ",")
                    diffLines = true;
            }

            int startLine;

            if (int.TryParse(ids[0].Value, out _))
                startLine = int.Parse(ids[0].Value);
            else
                return new int[0];

            int endLine = 0;

            if (multiline || diffLines)
            {
                foreach (Match id in ids)
                {
                    if (id.Value != ids[0].Value && id.Value != "" && int.TryParse(id.Value, out _))
                    {
                        endLine = int.Parse(id.Value);
                        break;
                    }
                }
            }

            idList.Add(startLine);

            if (endLine != 0)
            {
                if (diffLines)
                {
                    idList.Add(endLine);
                }
                else
                {
                    int lineCount = startLine;

                    while (lineCount < endLine)
                    {
                        lineCount++;
                        idList.Add(lineCount);
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

            Tuple<string, string> lastTuple = new Tuple<string, string>("", "");

            foreach (int id in idList)
            {
                if (id < 1)
                    break;

                var line = GetLine(id);

                if (line != null && !string.IsNullOrEmpty(line.Item2) && line.Item2 != lastTuple.Item2)
                    lines.Add(line);

                lastTuple = line;
            }

            if (lines.Count == 0)
                lines.Add(new Tuple<string, string>("Error", "No lines found!"));

            return lines.ToArray();
        }
    }
}
