using Microsoft.Xna.Framework;
using StardropPoolMinigame.Entities;

namespace StardropPoolMinigame.Render.Drawers
{
    class PageTitleDrawer : Drawer
    {
        public PageTitleDrawer(PageTitle title) : base(title)
        {
        }

        protected override Rectangle GetRawSource()
        {
            return ((PageTitle)this._entity).GetTextBounds();
        }
    }
}
