using Microsoft.Xna.Framework;
using StardropPoolMinigame.Entities;

namespace StardropPoolMinigame.Render.Drawers
{
    internal class BarShelvesDrawer : Drawer
    {
        public BarShelvesDrawer(BarShelves shelves) : base(shelves)
        {
        }

        protected override Rectangle GetRawSource()
        {
            return Textures.BAR_SHELVES;
        }
    }
}