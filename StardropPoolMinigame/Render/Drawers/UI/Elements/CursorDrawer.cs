using Microsoft.Xna.Framework;
using StardropPoolMinigame.Entities;

namespace StardropPoolMinigame.Render.Drawers
{
    class CursorDrawer : Drawer
    {
        public CursorDrawer(Cursor cursor) : base(cursor)
        {
        }

        protected override Rectangle GetRawSource()
        {
            return Textures.CURSOR_BOUNDS;
        }
    }
}
