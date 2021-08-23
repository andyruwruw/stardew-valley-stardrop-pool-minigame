using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Drawers;

namespace StardropPoolMinigame.Entities
{
    class Table: Entity
    {
        public Table(Origin origin, Vector2 anchor) : base(origin, anchor)
        {

        }

        public override void Update()
        {
        }

        public override IDrawer GetDrawer()
        {
            return new TableDrawer(this);
        }

        public override string GetId()
        {
            return $"table-{this._id}";
        }
    }
}
