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

        public void ReadGMD(string filepath)
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
            Tuple<string, string>[][] content = new Tuple<string, string>[sections][];
            int section = 0;

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
    }
}
