using System.Collections.Generic;
using StardropPoolMinigame.Constants;

namespace StardropPoolMinigame.Detect.Hover
{
	internal class PoolTableHoverDetector : TileHoverDetector
	{
		/// <summary>
		/// Tile IDs for pool table on building layer
		/// </summary>
		public static IList<int> TileIdsBuilding = new List<int>
			{1447, 1448, 1449, 1450, 1451, 1479, 1480, 1481, 1482, 1483};

		/// <summary>
		/// Tile IDs for pool table on front layer
		/// </summary>
		public static IList<int> TileIdsFront = new List<int> {1415, 1416, 1417, 1418, 1419};

		public override bool IsHovering()
		{
			if (DevConstants.OverrideIsPoolTable) return true;

			return base.IsHovering();
		}

		protected override void InitializeTileIdLists()
		{
			_buildingTileIds = TileIdsBuilding;
			_frontTileIds = TileIdsFront;
		}
	}
}