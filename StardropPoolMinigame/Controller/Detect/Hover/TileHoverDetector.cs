using System;
using StardewValley;
using Microsoft.Xna.Framework;
using xTile.Tiles;
using System.Collections.Generic;

namespace StardropPoolMinigame.Detect.Hover
{
    /// <summary>
    /// Detects if player is currently hovering certain tile IDs
    /// </summary>
    abstract class TileHoverDetector : ITileHoverDetector
    {
        // List of front tile IDs
        protected IList<int> _frontTileIds;

        // List of building tile IDs
        protected IList<int> _buildingTileIds;

        public TileHoverDetector()
        {
            this.CreateTileIdLists();
            this.InicializeTileIdLists();
        }

        /// <summary>
        /// Returns whether the player is hovering over designated tile IDs
        /// </summary>
        /// <returns>Whether player is hovering tile IDs</returns>
        public virtual bool IsHovering()
        {
            Vector2 positionClicked = this.GetPositionHovered();
            Tile front = this.GetFrontTileHovered(positionClicked);
            Tile building = this.GetBuildingTileHovered(positionClicked);

            return ((front != null && this._frontTileIds.Contains(front.TileIndex))
                || (building != null && this._buildingTileIds.Contains(building.TileIndex)));
        }

        /// <summary>
        /// Generates lists for front and building ID lists
        /// </summary>
        protected void CreateTileIdLists()
        {
            this._frontTileIds = new List<int>();
            this._buildingTileIds = new List<int>();
        }

        /// <summary>
        /// Adds tile IDs to lists of front and building tile IDs
        /// </summary>
        protected abstract void InicializeTileIdLists();

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
            Vector2 mousePosition = Vector2.Add(
                Utility.PointToVector2(Game1.getMousePosition()),
                new Vector2(Game1.viewport.X, Game1.viewport.Y)
            );

            return Vector2.Multiply(
                new Vector2(
                    (int)Math.Floor(mousePosition.X / Game1.tileSize),
                    (int)Math.Floor(mousePosition.Y / Game1.tileSize)),
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
            Vector2 overridePositionHovered = positionHovered == null ? this.GetPositionHovered() : (Vector2)positionHovered;
            return Game1.currentLocation.map.GetLayer(layer).PickTile(new xTile.Dimensions.Location((int)overridePositionHovered.X, (int)overridePositionHovered.Y), Game1.viewport.Size);
        }
    }
}

