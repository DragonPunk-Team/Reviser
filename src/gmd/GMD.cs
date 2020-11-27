using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Reviser
{
    public class GMD
    {   
        Tuple<string, string>[][] Content;

        public GMD (string file)
        {
            ReadGMD(file);
        }

        private void ReadGMD(string filepath)
        {
            var fstr = File.OpenRead(filepath);
            var br = new BinaryReader(fstr);

            // Skip first 24 bytes: we don't need those
            fstr.Seek(24, SeekOrigin.Begin);

            // Get amount of sections
            int Sections = br.ReadInt32();

            // Skip next 4 bytes: we don't need those
            fstr.Seek(4, SeekOrigin.Current);

            // Get totale size of sections
            int SectionSize = br.ReadInt32();

            // Seek the content from the end of the file
            fstr.Seek( - SectionSize, SeekOrigin.End);

            // Split contents
            var contentBlob = SplitBytes(br.ReadBytes(SectionSize));
            Content = SplitStrings(Sections, contentBlob);
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
                    line = RemoveTags(line);
                    sectionData.Add(new Tuple<string, string> (characterName, line));
                }

                content[section] = sectionData.ToArray();
                section++;
            }

            return content;
        }

        private string GetCharacter (string line)
        {
            string characterName = "";
            Cast cast = new Cast();

            Regex rx = new Regex(@"<E041 [0-9]* ([0-9]*)>", RegexOptions.Compiled);
            MatchCollection matches = rx.Matches(line);

            foreach (Match match in matches)
                characterName = cast.GS6[int.Parse(match.Groups[1].Value)];

            return characterName;
        }

        private string RemoveTags (string line)
        {
            Regex rx = new Regex(@"<[A-Z 0-9]*>", RegexOptions.Compiled);
            return rx.Replace(line, "");
        }

        private int[] GetId (string lineIds)
        {
            var idList = new List<int>();

            Regex mainRx = new Regex(@"[0-9]*", RegexOptions.Compiled);
            Regex sepRx = new Regex(@"-", RegexOptions.Compiled);

            // Check for ids separated by a dash (-),
            // multiple different lines.
            bool multiline = false;

            MatchCollection ids = mainRx.Matches(lineIds);
            MatchCollection seps = sepRx.Matches(lineIds);

            foreach (Match sep in seps)
            {
                if (sep.Value == "-")
                    multiline = true;
            }

            int startLine = int.Parse(ids[0].Value);
            int endLine;

            if (multiline)
                endLine = int.Parse(ids[2].Value);
            else
                endLine = 0;

            idList.Add(startLine);

            if (endLine != 0)
            {
                int lineCount = startLine;
                
                while (lineCount < endLine)
                {
                    lineCount++;
                    idList.Add(lineCount);
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
                if ((section.Length + totalLength) > lineId)
                {
                    int index = lineId - totalLength - firstLine;
                    return section[index];
                }
                else
                {
                    totalLength++;
                }

                totalLength += 1 + section.Length;
            }

            return null;
        }

        public Tuple<string, string>[] GetLines (string lineIds)
        {
            var lines = new List<Tuple<string, string>>();

            int[] idList = GetId(lineIds);

            foreach (int id in idList)
            {
                var line = GetLine(id);

                if (!string.IsNullOrEmpty(line.Item2))
                    lines.Add(line);
            }

            if (lines.Count == 0)
                lines.Add(new Tuple<string, string>("Error", "No lines found!"));

            return lines.ToArray();
        }
    }
}
