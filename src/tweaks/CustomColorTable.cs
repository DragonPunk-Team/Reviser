using System.Drawing;
using System.Windows.Forms;

namespace Reviser.Tweaks
{
    public class CustomColorTable : ProfessionalColorTable
    {
        // ToolStrip gradient background color.
        private readonly Color bgColor = SystemColors.Control;

        public override Color ToolStripGradientBegin => bgColor;
        public override Color ToolStripGradientMiddle => bgColor;
        public override Color ToolStripGradientEnd => bgColor;
    }
}
