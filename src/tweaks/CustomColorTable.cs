using System.Drawing;
using System.Windows.Forms;

namespace Reviser.Tweaks
{
    public class CustomColorTable : ProfessionalColorTable
    {
        // ToolStrip gradient background color.
        Color bgColor = SystemColors.Control;

        public override Color ToolStripGradientBegin { get { return bgColor; } }
        public override Color ToolStripGradientMiddle { get { return bgColor; } }
        public override Color ToolStripGradientEnd { get { return bgColor; } }
    }
}
