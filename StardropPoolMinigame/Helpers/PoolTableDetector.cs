using Microsoft.Xna.Framework;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xTile.Tiles;

namespace StardropPoolMinigame
{
    public class PoolTableDetector
    {
        public static IList<int> IS_POOL_TABLE_FRONT = new List<int>() { 1415, 1416, 1417, 1418, 1419 };

        public static IList<int> IS_POOL_TABLE_BUILDING = new List<int>() { 1447, 1448, 1449, 1450, 1451, 1479, 1480, 1481, 1482, 1483 };

        public static bool IsPoolTable()
        {
            Vector2 mousePosition = Utility.PointToVector2(Game1.getMousePosition()) + new Vector2(Game1.viewport.X, Game1.viewport.Y);
            int clickX = (int)Math.Floor(mousePosition.X / Game1.tileSize) * 64;
            int clickY = (int)Math.Floor(mousePosition.Y / Game1.tileSize) * 64;

            Tile front = Game1.currentLocation.map.GetLayer("Front").PickTile(new xTile.Dimensions.Location(clickX, clickY), Game1.viewport.Size);
            Tile building = Game1.currentLocation.map.GetLayer("Buildings").PickTile(new xTile.Dimensions.Location(clickX, clickY), Game1.viewport.Size);

            if ((front != null && IS_POOL_TABLE_FRONT.Contains(front.TileIndex)) ||
                building != null && IS_POOL_TABLE_BUILDING.Contains(building.TileIndex))
            {
                return true;
            }

            return false;
        }
    }
}
