using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Entities;

namespace StardropPoolMinigame.Render.Drawers
{
    class FloorTiles : Drawer
    {
        public FloorTiles(Table table) : base(table)
        {
        }

        public override void Draw(SpriteBatch batch)
        {

        }

        protected override Rectangle GetRawSource()
        {
            return Textures.BACKGROUND_FLOOR_TILES_HIGH_RESOLUTION_BOUNDS;
        }
    }
}
