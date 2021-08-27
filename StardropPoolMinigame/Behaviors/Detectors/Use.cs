using System;
using StardewValley;
using Microsoft.Xna.Framework;
using xTile.Tiles;
using StardropPoolMinigame.Constants;

namespace StardropPoolMinigame.Detect
{
    class Use
    {
        /// <summary>
        /// Detects if player is attempting to use pool table
        /// </summary>
        /// <returns>Whether player used pool table</returns>
        public static bool IsPoolTable()
        {
            if (DevConstants.OVERRIDE_IS_POOL_TABLE && Game1.currentMinigame == null)
            {
                return true;
            }

            Vector2 mousePosition = Utility.PointToVector2(Game1.getMousePosition()) + new Vector2(Game1.viewport.X, Game1.viewport.Y);

            int clickX = (int)Math.Floor(mousePosition.X / Game1.tileSize) * 64;
            int clickY = (int)Math.Floor(mousePosition.Y / Game1.tileSize) * 64;

            Tile front = Game1.currentLocation.map.GetLayer("Front").PickTile(new xTile.Dimensions.Location(clickX, clickY), Game1.viewport.Size);
            Tile building = Game1.currentLocation.map.GetLayer("Buildings").PickTile(new xTile.Dimensions.Location(clickX, clickY), Game1.viewport.Size);

            if ((front != null && GameConstants.POOL_TABLE_TILE_ID_FRONT.Contains(front.TileIndex)) ||
                building != null && GameConstants.POOL_TABLE_TILE_ID_BUILDING.Contains(building.TileIndex))
            {
                return true;
            }

            return false;
        }
    }
}
