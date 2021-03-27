using System.Windows.Forms;

class BufferedListView : ListView
{
    public BufferedListView() { DoubleBuffered = true; }
}
