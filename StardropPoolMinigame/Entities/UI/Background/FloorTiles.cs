using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    class FloorTiles : EntityStatic
    {
        public FloorTiles(
            IFilter enteringTransition,
            IFilter exitingTransition
        ) : base(
            Origin.TopLeft,
            new Vector2(0, 0),
            0.0001f,
            enteringTransition,
            exitingTransition)
        {
            this.SetDrawer(new FloorTilesDrawer(this));
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
