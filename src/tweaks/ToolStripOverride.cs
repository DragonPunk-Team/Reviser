using System.Drawing;
using System.Windows.Forms;

namespace Reviser.Tweaks
{
    public class ToolStripOverride : ToolStripProfessionalRenderer
    {
        // Background color for ToolStrip buttons.
        Brush bgBtnColor = Brushes.White;

        // Pressed button background color.
        Brush bgPressedColor = Brushes.LightGray;

        public ToolStripOverride() : base(new CustomColorTable()) { base.RoundedEdges = false; }

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

                if (e.Item.Pressed)
                    e.Graphics.FillRectangle(bgPressedColor, rectangle);
                else
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

                var br = sb.ButtonPressed ? bgPressedColor : bgBtnColor;

                if (e.Item.Pressed)
                    e.Graphics.FillRectangle(bgPressedColor, button);
                else
                    e.Graphics.FillRectangle(br, button);

                e.Graphics.DrawRectangle(Pens.Olive, button);

                if (e.Item.Pressed)
                    e.Graphics.FillRectangle(bgPressedColor, dropdown);
                else
                    e.Graphics.FillRectangle(br, dropdown);

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

                if (e.Item.Pressed)
                    e.Graphics.FillRectangle(bgPressedColor, rectangle);
                else
                    e.Graphics.FillRectangle(bgBtnColor, rectangle);

                e.Graphics.DrawRectangle(Pens.Olive, rectangle);
            }
        }
    }
}
