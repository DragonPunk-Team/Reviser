﻿using System.Collections;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Reviser.Tweaks
{
    class CustomListViewSort : IComparer
    {
        Regex rx = new Regex(@"[0-9]*", RegexOptions.Compiled);

        public int Compare(object x, object y)
        {
            var intX = int.Parse(rx.Match((x as ListViewItem).Tag as string).Value);
            var intY = int.Parse(rx.Match((y as ListViewItem).Tag as string).Value);

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
