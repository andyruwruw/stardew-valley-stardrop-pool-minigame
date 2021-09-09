using StardropPoolMinigame.Constants;
using System.Collections.Generic;

namespace StardropPoolMinigame.Detect.Hover
{
    class PoolTableHoverDetector : TileHoverDetector
    {
        /// <summary>
        /// Tile IDs for pool table on building layer
        /// </summary>
        public static IList<int> TILE_IDS_BUILDING = new List<int>() { 1447, 1448, 1449, 1450, 1451, 1479, 1480, 1481, 1482, 1483 };

        /// <summary>
        /// Tile IDs for pool table on front layer
        /// </summary>
        public static IList<int> TILE_IDS_FRONT = new List<int>() { 1415, 1416, 1417, 1418, 1419 };

        public PoolTableHoverDetector() : base()
        {
        }

        public override bool IsHovering()
        {
            if (DevConstants.OVERRIDE_IS_POOL_TABLE)
            {
                return true;
            }
            return base.IsHovering();
        }

        protected override void InicializeTileIdLists()
        {
            this._buildingTileIds = TILE_IDS_BUILDING;
            this._frontTileIds = TILE_IDS_FRONT;
        }
    }
}
