using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    class Cursor : EntityStatic
    {
        public Cursor(
            Origin origin,
            Vector2 anchor,
            float layerDepth,
            int delay = 0,
            bool delayOnce = false
        ) : base(
            origin,
            anchor,
            layerDepth,
            new CursorAnimation(delay, delayOnce),
            null)
        {
            this.SetDrawer(new CursorDrawer(this));
        }

        public override void Update()
        {
            this.UpdateTransitionState();
        }

        public override float GetTotalHeight()
        {
            return Textures.CURSOR_BOUNDS.Height;
        }

        public override float GetTotalWidth()
        {
            return Textures.CURSOR_BOUNDS.Width;
        }
    }
}
