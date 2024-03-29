﻿using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Reviser.Tweaks
{
    internal class CustomListSort : IComparer<ProjectFile.FileContent>
    {
        private readonly Regex rx = new (@"[0-9]*", RegexOptions.Compiled);

        public int Compare(ProjectFile.FileContent x, ProjectFile.FileContent y)
        {
            var intX = int.Parse(rx.Match(x.lineId).Value);
            var intY = int.Parse(rx.Match(y.lineId).Value);

            if (intX < intY)
                return -1;

            if (intX > intY)
                return 1;

            // if (intX == intY)
            return 0;
        }
    }
}
