using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    class Table : EntityStatic
    {
        public Table(
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
            this.SetDrawer(new TableDrawer(this));
        }

        public override string GetId()
        {
            return $"table-{this._id}";
        }

        public override float GetTotalWidth()
        {
            return Textures.Table.Pocket.Back.NORTH.Width * 9;
        }

        public override float GetTotalHeight()
        {
            return Textures.Table.Pocket.Back.NORTH.Width * 5;
        }
    }
}
