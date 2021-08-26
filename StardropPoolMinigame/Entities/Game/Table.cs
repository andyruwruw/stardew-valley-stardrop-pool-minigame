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

        public override void Update()
        {
            this.UpdateTransitionState();
        }

        public override string GetId()
        {
            return $"table-{this._id}";
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
