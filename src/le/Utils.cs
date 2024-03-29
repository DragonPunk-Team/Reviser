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
        private static readonly Regex commaRx = new (@",([^ ])", RegexOptions.Compiled);
        private static readonly Regex idRx = new (@"[^0-9-, ]*", RegexOptions.Compiled);
        private static readonly Regex sepRx = new (@"(-|,)+", RegexOptions.Compiled);
        private static readonly Regex spaceRx = new(@" +", RegexOptions.Compiled);
        #endregion

        public static (string text, int cursor) FormatIds(string ids, int cursor)
        {
            var text = idRx.Replace(ids, "");
            text = sepRx.Replace(text, "$1");
            text = spaceRx.Replace(text, " ");
            text = text.Replace(" - ", "-");

            if (ids != text)
                cursor--;

            return (text, cursor);
        }

        public static string CleanIds(string ids)
        {
            var chars = new[] { ',', '-' };

            var clean = ids.TrimStart(chars);
            clean = clean.TrimEnd(chars);
            clean = clean.Replace(" ", string.Empty);

            return commaRx.Replace(clean, ", $1");
        }

        public static string FormatLines(IFile origFile, IFile tranFile, string ids, bool color)
        {
            var sb = new StringBuilder();

            var origLines = origFile.GetLines(ids);
            var tranLines = tranFile.GetLines(ids);

            var lastChar = string.Empty;

            foreach (var line in origLines)
            {
                var index = Array.IndexOf(origLines, line);

                if (line.Item1 == lastChar)
                {
                    sb.Append("\n\n");
                }
                else
                {
                    lastChar = line.Item1;
                    sb.AppendLine($"[{line.Item1}]");
                }

                var origLine = line.Item2;

                if (!color)
                    origLine = origFile.RemoveColors(origLine);

                sb.AppendLine(origLine);

                if (line.Item1 == Language.Strings.Generic_Error)
                {
                    SystemSounds.Beep.Play();
                    break;
                }
                
                var tranLine = tranLines[index].Item2;

                if (!color)
                    tranLine = tranFile.RemoveColors(tranLine);

                sb.AppendLine(tranLine);

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
