using Microsoft.Xna.Framework;
using MinigameFramework.Enums;
using MinigameFramework.Entities;
using MinigameFramework.Render.Filters;
using StardopPoolMinigame.Constants;

namespace StardopPoolMinigame.Entities.UI.Backgrounds
{
    /// <summary>
    /// Background that emulates the background of Gus' bar.
    /// </summary>
    class BarShelves : Entity
    {
        /// <summary>
        /// Instantiates a bar-shelf background.
        /// </summary>
        /// <param name="anchor"><see cref="Entity">Entity's</see> anchor, or position<inheritdoc cref="_anchor"/></param>
		/// <param name="layerDepth"><see cref="Entity">Entity's</see> layer depth for rendering</param>
		/// <param name="origin">Anchor's relation to <see cref="Entity">Entity's</see> position</param>
		/// <param name="enteringTransition"><see cref="Entity">Entity's</see> entering <see cref="Transition"/></param>
		/// <param name="exitingTransition"><see cref="Entity">Entity's</see> exiting <see cref="Transition"/></param>
        public BarShelves(
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
            return TextureConstants.BarShelves.Height;
        }

        /// <inheritdoc cref="IEntity.GetId"/>
        public override string GetId()
        {
            return $"bar-shelves-{_id}";
        }

        /// <inheritdoc cref="IEntity.GetRawSource"/>
        public override Rectangle GetRawSource()
        {
            return TextureConstants.BarShelves;
        }

        /// <inheritdoc cref="IEntity.GetWidth"/>
        public override float GetWidth()
        {
            return TextureConstants.BarShelves.Width;
        }
    }
}
