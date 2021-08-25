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
            return Textures.BACKGROUND_BAR_SHELVES_BOUNDS;
        }
    }
}
