using System.Collections;
using System.Windows.Forms;

namespace Reviser.Tweaks
{
    internal class CustomListViewSort : IComparer
    {
        public int Compare(object x, object y)
        {
            var intX = (int)(x as ListViewItem).Tag;
            var intY = (int)(y as ListViewItem).Tag;

            if (intX < intY)
                return -1;

            if (intX > intY)
                return 1;

            // if (intX == intY)
            return 0;
        }
    }
}
