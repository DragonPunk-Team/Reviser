﻿using System;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;

using Reviser.Files;

namespace Reviser.LE
{
    public class Utils
    {
        #region Regex
        static readonly Regex commaRx = new Regex(@",([^ ])", RegexOptions.Compiled);
        static readonly Regex idRx = new Regex(@"[^0-9-, ]*", RegexOptions.Compiled);
        static readonly Regex sepRx = new Regex(@"(-|,| )+", RegexOptions.Compiled);
        #endregion

        public static (string text, int cursor) FormatIds(string ids, int cursor)
        {
            var text = idRx.Replace(ids, "");
            text = sepRx.Replace(text, "$1");

            if (ids != text)
                cursor--;

            return (text, cursor);
        }

        public static string CleanIds(string ids)
        {
            var chars = new char[] { ',', '-' };

            var clean = ids.TrimStart(chars);
            clean = clean.TrimEnd(chars);

            MatchCollection matches = commaRx.Matches(ids);

            foreach (Match match in matches)
                clean = commaRx.Replace(clean, ", $1");

            return clean;
        }

        public static string FormatLines(IFile origFile, IFile tranFile, string ids, bool color)
        {
            StringBuilder sb = new StringBuilder();

            var origLines = origFile.GetLines(ids);
            var tranLines = tranFile.GetLines(ids);

            string lastChar = "";

            foreach (var line in origLines)
            {
                int index = Array.IndexOf(origLines, line);

                if (line.Item1 == lastChar)
                {
                    sb.Append("\n\n");
                }
                else
                {
                    lastChar = line.Item1;
                    sb.AppendLine("[" + line.Item1 + "]");
                }

                var origLine = line.Item2;

                if (!color)
                    origLine = origFile.RemoveColors(origLine);

                sb.AppendLine(origLine);

                if (line.Item1 == "Error")
                {
                    SystemSounds.Beep.Play();
                    break;
                }
                else
                {
                    var tranLine = tranLines[index].Item2;

                    if (!color)
                        tranLine = tranFile.RemoveColors(tranLine);

                    sb.AppendLine(tranLine);
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
