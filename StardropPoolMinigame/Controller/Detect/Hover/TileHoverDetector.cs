﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardewValley;
using xTile.Dimensions;
using xTile.Tiles;

namespace StardropPoolMinigame.Detect.Hover
{
	/// <summary>
	/// Detects if player is currently hovering certain tile IDs
	/// </summary>
	internal abstract class TileHoverDetector : ITileHoverDetector
	{
		// List of building tile IDs
		protected IList<int> _buildingTileIds;

		// List of front tile IDs
		protected IList<int> _frontTileIds;

		public TileHoverDetector()
		{
			CreateTileIdLists();
			InitializeTileIdLists();
		}

		/// <summary>
		/// Returns whether the player is hovering over designated tile IDs
		/// </summary>
		/// <returns>Whether player is hovering tile IDs</returns>
		public virtual bool IsHovering()
		{
			var positionClicked = GetPositionHovered();
			var front = GetFrontTileHovered(positionClicked);
			var building = GetBuildingTileHovered(positionClicked);

			return front != null && _frontTileIds.Contains(front.TileIndex)
				|| building != null && _buildingTileIds.Contains(building.TileIndex);
		}

		/// <summary>
		/// Generates lists for front and building ID lists
		/// </summary>
		protected void CreateTileIdLists()
		{
			_frontTileIds = new List<int>();
			_buildingTileIds = new List<int>();
		}

		/// <summary>
		/// Retrieves building tile currently hovered
		/// </summary>
		/// <param name="positionHovered">Overrides position hovered if previously retrieved</param>
		/// <returns>Building tile</returns>
		protected Tile GetBuildingTileHovered(Vector2? positionHovered = null)
		{
			return GetTileHovered("Buildings", positionHovered);
		}

		/// <summary>
		/// Retrieves front tile currently hovered
		/// </summary>
		/// <param name="positionHovered">Overrides position hovered if previously retrieved</param>
		/// <returns>Front tile</returns>
		protected Tile GetFrontTileHovered(Vector2? positionHovered = null)
		{
			return GetTileHovered("Front", positionHovered);
		}

		/// <summary>
		/// Retrieves <see cref="Vector2"/> of tile hovered
		/// </summary>
		/// <returns>Position hovered</returns>
		protected Vector2 GetPositionHovered()
		{
			var mousePosition = Vector2.Add(
				Utility.PointToVector2(Game1.getMousePosition()),
				new Vector2(Game1.viewport.X, Game1.viewport.Y)
			);

			return Vector2.Multiply(
				new Vector2(
					(int) Math.Floor(mousePosition.X / Game1.tileSize),
					(int) Math.Floor(mousePosition.Y / Game1.tileSize)),
				64);
		}

		/// <summary>
		/// Retrieves tile hovered on designated layer
		/// </summary>
		/// <param name="layer">Layer desired</param>
		/// <param name="positionHovered">Overrides position hovered if previously retrieved</param>
		/// <returns>Tile hovered</returns>
		protected Tile GetTileHovered(string layer, Vector2? positionHovered = null)
		{
			var overridePositionHovered = positionHovered == null ? GetPositionHovered() : (Vector2) positionHovered;

			return Game1.currentLocation.map.GetLayer(layer).PickTile(
				new Location((int) overridePositionHovered.X, (int) overridePositionHovered.Y), Game1.viewport.Size);
		}

		/// <summary>
		/// Adds tile IDs to lists of front and building tile IDs
		/// </summary>
		protected abstract void InitializeTileIdLists();
	}
}