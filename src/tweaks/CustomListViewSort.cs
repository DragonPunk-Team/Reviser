using System.Collections;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Reviser.Tweaks
{
    internal class CustomListViewSort : IComparer
    {
        private readonly Regex rx = new(@"[0-9]*", RegexOptions.Compiled);

        public int Compare(object x, object y)
        {
            var intX = int.Parse(rx.Match((x as ListViewItem).SubItems[0].Text).Value);
            var intY = int.Parse(rx.Match((y as ListViewItem).SubItems[0].Text).Value);

            if (intX < intY)
                return -1;

            if (intX > intY)
                return 1;

            // if (intX == intY)
            return 0;
        }
    }
}
