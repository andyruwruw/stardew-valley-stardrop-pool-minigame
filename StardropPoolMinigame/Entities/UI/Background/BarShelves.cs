using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Drawers.UI;

namespace StardropPoolMinigame.Entities
{
    class BarShelves : EntityStatic
    {
        public BarShelves(Origin origin, Vector2 anchor, float layerDepth) : base(origin, anchor, layerDepth)
        {
        }

        public override void Update()
        {
        }

        public Microsoft.Xna.Framework.Rectangle GetSource()
        {
            return Textures.BACKGROUND_BAR_SHELVES_BOUNDS;
        }

        public override IDrawer GetDrawer()
        {
            return new BarShelvesDrawer(this);
        }

        public override string GetId()
        {
            return $"bar-shelves-background-{this._id}";
        }
    }
}
