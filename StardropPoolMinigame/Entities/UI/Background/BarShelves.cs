using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Drawers.UI;

namespace StardropPoolMinigame.Entities
{
    class BarShelves : Entity
    {
        public BarShelves(Origin origin, Vector2 anchor) : base(origin, anchor)
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
