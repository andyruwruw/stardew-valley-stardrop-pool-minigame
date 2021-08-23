using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Drawers;

namespace StardropPoolMinigame.Entities
{
    class Pocket : EntityHoverable
    {
        public Pocket(Origin origin, Vector2 anchor) : base(origin, anchor)
        {

        }

        public override void Update()
        {
            this.UpdateHoverable();
        }

        public override IDrawer GetDrawer()
        {
            return new PocketDrawer(this);
        }

        public override string GetId()
        {
            return $"pocket-{this._id}";
        }
    }
}
