using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Reviser
{
	public class GMD
    {   
        public class GMDContent
        {
            public string[] Labels;
            public Dictionary<string, Tuple<string, string>[]> Content;
        }

        public GMDContent ReadGMD(string filepath)
        {
            GMDContent gmd = new GMDContent();

            var fstr = File.OpenRead(filepath);
            var br = new BinaryReader(fstr);

            // Skip first 28 bytes: we don't need those
            fstr.Seek(28, SeekOrigin.Begin);

            // Get sizes for labels and sections
            int LabelSize = br.ReadInt32();
            int SectionSize = br.ReadInt32();

            // Seek the content from the end of the file
            fstr.Seek( - (LabelSize + SectionSize), SeekOrigin.End);

            // Split label
            gmd.Labels = SplitBytes(br.ReadBytes(LabelSize));

            // Split contents
            var contentBlob = SplitBytes(br.ReadBytes(SectionSize));
            gmd.Content = SplitStrings(gmd.Labels, contentBlob);

            return gmd;
        }

        private string[] SplitBytes(byte[] blob)
        {
            List<string> content = new List<string>();

            StringBuilder sb = new StringBuilder();

            foreach (byte ch in blob)
            {
                if (ch == 0)
                {
                    content.Add(sb.ToString());
                    sb.Clear();
                }
                else
                {
                    sb.Append((char)ch);
                }
            }

            return content.ToArray();
        }

        private Dictionary<string, Tuple<string, string>[]> SplitStrings(string[] labels, string[] blob)
        {
            Dictionary<string, Tuple<string, string>[]> content = new Dictionary<string, Tuple<string, string>[]>();

            foreach (string str in blob)
            {
                int labelIndex = Array.IndexOf(blob, str);
                string[] strContent = str.Split(new string[] { "<PAGE>" }, StringSplitOptions.None);
                List<Tuple<string, string>> sectionData = new List<Tuple<string, string>>();

                foreach (string strC in strContent)
                {
                    string line = strC.Trim().Replace("\r\n", " ");
                    string characterName = GetCharacter(line);
                    line = RemoveTags(line);
                    sectionData.Add(new Tuple<string, string> (characterName, line));
                }

                content.Add(labels[labelIndex], sectionData.ToArray());
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
    }
}
