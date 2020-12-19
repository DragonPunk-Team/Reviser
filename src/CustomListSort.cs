using System.Collections;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Reviser
{
    class CustomListSort : IComparer
    {
        public int Compare(object x, object y)
        {
            Regex rx = new Regex(@"[0-9]*", RegexOptions.Compiled);

            MatchCollection matchX = rx.Matches((x as ListViewItem).Tag as string);
            MatchCollection matchY = rx.Matches((y as ListViewItem).Tag as string);

            var intX = int.Parse(matchX[0].Value);
            var intY = int.Parse(matchY[0].Value);

            if (intX < intY)
                return -1;

            if (intX > intY)
                return 1;

            if (intX == intY)
                return 0;

            return 0;
        }
    }
}
