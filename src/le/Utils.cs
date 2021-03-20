using System;
using System.Text.RegularExpressions;

namespace Reviser
{
    class LEUtils
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
    }
}
