using System.Text.RegularExpressions;

namespace Reviser
{
    class LEUtils
    {
        public static string CleanIds(string ids)
        {
            string clean;
            var chars = new char[] { ',', '-' };

            clean = ids.TrimStart(chars);
            clean = clean.TrimEnd(chars);

            var commaRx = new Regex(@",([^ ])", RegexOptions.Compiled);

            MatchCollection matches = commaRx.Matches(ids);

            foreach (Match match in matches)
                clean = commaRx.Replace(clean, ", $1");

            return clean;
        }
    }
}
