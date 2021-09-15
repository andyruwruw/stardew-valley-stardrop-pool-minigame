using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    internal class BarShelves : Entity
    {
        public BarShelves(
            Origin origin,
            Vector2 anchor,
            float layerDepth,
            IFilter enteringTransition,
            IFilter exitingTransition
        ) : base(
            origin,
            anchor,
            layerDepth,
            enteringTransition,
            exitingTransition)
        {
            this.SetDrawer(new BarShelvesDrawer(this));
        }

        public override string GetId()
        {
            return $"bar-shelves-{this._id}";
        }

        public override float GetTotalHeight()
        {
            return Textures.BAR_SHELVES.Height;
        }

        public override float GetTotalWidth()
        {
            return Textures.BAR_SHELVES.Width;
        }
    }
}