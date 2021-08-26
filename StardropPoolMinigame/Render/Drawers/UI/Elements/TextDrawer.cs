using Microsoft.Xna.Framework;
using StardropPoolMinigame.Entities;

namespace StardropPoolMinigame.Render.Drawers
{
    class TextDrawer : Drawer
    {
        public TextDrawer(Text text) : base(text)
        {
        }

        protected override Rectangle GetRawSource()
        {
            return ((Text)this._entity).GetTextBounds();
        }
    }
}
