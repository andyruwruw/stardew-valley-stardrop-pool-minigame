using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    internal class FloorTiles : Entity
    {
        public FloorTiles(
            IFilter enteringTransition,
            IFilter exitingTransition
        ) : base(
            Origin.TopLeft,
            new Vector2(0, 0),
            LayerDepthConstants.Game.FLOOR_TILES,
            enteringTransition,
            exitingTransition)
        {
            this.SetDrawer(new FloorTilesDrawer(this));
        }

        public override string GetId()
        {
            return $"floor-tile-{this._id}";
        }

        public override float GetTotalHeight()
        {
            return Textures.FLOOR_TILES.Height;
        }

        public override float GetTotalWidth()
        {
            return Textures.FLOOR_TILES.Width;
        }
    }
}