using System.Drawing;
using System.Windows.Forms;

namespace Reviser
{
    public class ToolStripOverride : ToolStripProfessionalRenderer
    {
        // Background color for ToolStrip buttons.
        Brush bgBtnColor = Brushes.White;

        public ToolStripOverride() : base(new CustomColorTable()) { }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e) { }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (!e.Item.Selected)
            {
                base.OnRenderButtonBackground(e);
            }
            else
            {
                Rectangle rectangle = new Rectangle(0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1);
                e.Graphics.FillRectangle(bgBtnColor, rectangle);
                e.Graphics.DrawRectangle(Pens.Olive, rectangle);
            }
        }

        protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (!e.Item.Selected)
            {
                base.OnRenderSplitButtonBackground(e);
            }
            else
            {
                var sb = e.Item as ToolStripSplitButton;
                var button = sb.ButtonBounds;
                var dropdown = sb.DropDownButtonBounds;

                button.Width++;
                button.Height--;
                dropdown.Width--;
                dropdown.Height--;

                e.Graphics.FillRectangle(bgBtnColor, button);
                e.Graphics.DrawRectangle(Pens.Olive, button);
                e.Graphics.FillRectangle(Brushes.White, dropdown);
                e.Graphics.DrawRectangle(Pens.Olive, dropdown);

                OnRenderArrow(new ToolStripArrowRenderEventArgs(e.Graphics, e.Item, sb.DropDownButtonBounds, e.Item.ForeColor, ArrowDirection.Down));
            }
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (!e.Item.Selected)
            {
                base.OnRenderMenuItemBackground(e);
            }
            else
            {
                Rectangle rectangle = new Rectangle(0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1);
                e.Graphics.FillRectangle(bgBtnColor, rectangle);
                e.Graphics.DrawRectangle(Pens.Olive, rectangle);
            }
        }
    }
}
