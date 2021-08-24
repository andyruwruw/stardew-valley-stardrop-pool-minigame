using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Drawers;

namespace StardropPoolMinigame.Entities
{
    class Table : EntityStatic
    {
        public Table(Origin origin, Vector2 anchor, float layerDepth) : base(origin, anchor, layerDepth)
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
