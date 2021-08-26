using Microsoft.Xna.Framework;
using StardropPoolMinigame.Entities;

namespace StardropPoolMinigame.Render.Drawers
{
    class ButtonDrawer : Drawer
    {
        public ButtonDrawer(Button button) : base(button)
        {
        }

        protected override Rectangle GetRawSource()
        {
            return ((Button)this._entity).GetTextBounds();
        }

        protected override Color GetRawColor()
        {
            if (((EntityHoverable)this._entity).IsHovered())
            {
                return Textures.TEXT_HOVER_COLOR;
            }
            return Color.White;
        }
    }
}
