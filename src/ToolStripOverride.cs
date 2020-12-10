using System.Windows.Forms;

namespace Reviser
{
    public class ToolStripOverride : ToolStripProfessionalRenderer
    {
        public ToolStripOverride() { }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e) { }
    }
}
