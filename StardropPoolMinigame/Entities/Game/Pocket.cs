using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Drawers;

namespace StardropPoolMinigame.Entities
{
    class Pocket : EntityHoverable
    {
        public Pocket(
            Origin origin, 
            Vector2 anchor, 
            float layerDepth
        ) : base(
            origin, 
            anchor, 
            layerDepth,
            null,
            null)
        {
            this.SetDrawer(new PocketDrawer(this));
        }

        public override void Update()
        {
            this.UpdateHoverable();
            this.UpdateTransitionState();
        }

        public override string GetId()
        {
            return $"pocket-{this._id}";
        }

        public override float GetTotalWidth()
        {
            return Textures.BACKGROUND_BAR_SHELVES_BOUNDS.Width;
        }

        public override float GetTotalHeight()
        {
            return Textures.BACKGROUND_BAR_SHELVES_BOUNDS.Height;
        }
    }
}
