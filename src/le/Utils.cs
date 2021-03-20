using System;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;

using Reviser.SoJ;

namespace Reviser.LE
{
    public class Utils
    {
        #region Regex
        static Regex commaRx = new Regex(@",([^ ])", RegexOptions.Compiled);
        static Regex idRx = new Regex(@"[^0-9-, ]*", RegexOptions.Compiled);
        static Regex sepRx = new Regex(@"(-|,| )+", RegexOptions.Compiled);
        #endregion

        public static Tuple<string, int> FormatIds(string ids, int cursor)
        {
            var newText = idRx.Replace(ids, "");
            newText = sepRx.Replace(newText, "$1");

            if (ids != newText)
                cursor--;

            return new Tuple<string, int>(newText, cursor);
        }

        public static string CleanIds(string ids)
        {
            string clean;
            var chars = new char[] { ',', '-' };

            clean = ids.TrimStart(chars);
            clean = clean.TrimEnd(chars);

            MatchCollection matches = commaRx.Matches(ids);

            foreach (Match match in matches)
                clean = commaRx.Replace(clean, ", $1");

            return clean;
        }

        public static string FormatLines(GMDv2 origGMD, GMDv2 tranGMD, string ids, bool color)
        {
            StringBuilder sb = new StringBuilder();

            var origLines = origGMD.GetLines(ids);
            var tranLines = tranGMD.GetLines(ids);

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
                    origLine = origGMD.RemoveColors(origLine);

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
                        tranLine = tranGMD.RemoveColors(tranLine);

                    sb.AppendLine(tranLine);
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
