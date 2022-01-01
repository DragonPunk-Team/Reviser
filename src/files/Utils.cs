using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Reviser.Files
{
    public enum OtherLines
    {
        Previous,
        Next
    }

    public static class Utils
    {
        #region Regex
        private static readonly Regex idRx = new (@"([0-9]*-?)*", RegexOptions.Compiled);
        #endregion

        public static int[] GetIDList(string lineIDs)
        {
            var idList = new List<int>();

            var ids = idRx.Matches(lineIDs.Replace(" ", string.Empty));

            foreach (Match id in ids)
            {
                if (string.IsNullOrWhiteSpace(id.Value)) continue;

                if (id.Value.Contains("-"))
                {
                    var split = id.Value.Split('-');
                    var limits = new[] { int.Parse(split[0]), int.Parse(split[1]) };

                    for (var i = limits[0]; i <= limits[1]; i++)
                        idList.Add(i);
                }
                else
                {
                    idList.Add(int.Parse(id.Value));
                }
            }

            return idList.ToArray();
        }
    }
}
