using System.Windows.Forms;

namespace Reviser.Tweaks
{
    internal class BufferedListView : ListView
    {
        public BufferedListView() { DoubleBuffered = true; }
    }
}
