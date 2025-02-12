using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MinigameFramework.Enums;
using MinigameFramework.Entities;
using MinigameFramework.Render.Filters;
using StardopPoolMinigame.Constants;
using StardopPoolMinigame.Render;

namespace StardopPoolMinigame.Entities.UI.Backgrounds
{
    /// <summary>
    /// Background that emulates the floor of Gus' bar.
    /// </summary>
    class FloorTiles : Entity
    {
        /// <summary>
        /// Instantiates a floor-tile background.
        /// </summary>
        /// <param name="anchor"><see cref="Entity">Entity's</see> anchor, or position<inheritdoc cref="_anchor"/></param>
		/// <param name="layerDepth"><see cref="Entity">Entity's</see> layer depth for rendering</param>
		/// <param name="origin">Anchor's relation to <see cref="Entity">Entity's</see> position</param>
		/// <param name="enteringTransition"><see cref="Entity">Entity's</see> entering <see cref="Transition"/></param>
		/// <param name="exitingTransition"><see cref="Entity">Entity's</see> exiting <see cref="Transition"/></param>
        public FloorTiles(
            Vector2 anchor,
            float layerDepth = 0,
            Origin origin = Origin.TopLeft,
            IFilter? enteringTransition = null,
            IFilter? exitingTransition = null
        ) : base(
            anchor,
            layerDepth,
            origin,
            enteringTransition,
            exitingTransition
        ) { }

        /// <inheritdoc cref="IEntity.GetHeight"/>
        public override float GetHeight()
        {
            return TextureConstants.FloorTiles.Height;
        }

        /// <inheritdoc cref="IEntity.GetName"/>
        public override string GetName()
        {
            return $"floor-tile-{_key}";
        }

        /// <inheritdoc cref="IEntity.GetWidth"/>
        public override float GetWidth()
        {
            return TextureConstants.FloorTiles.Width;
        }

        /// <inheritdoc cref="Entity.GetRawSource"/>
        protected override Rectangle GetRawSource()
        {
            return TextureConstants.FloorTiles;
        }

        /// <inheritdoc cref="Entity.GetTileset"/>
        protected override Texture2D? GetTileset()
        {
            return Textures.Tileset.Default;
        }
    }
}
