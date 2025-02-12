using Microsoft.Xna.Framework;
using MinigameFramework.Enums;
using MinigameFramework.Render.Filters;

namespace MinigameFramework.Entities.UI.Text
{
    /// <summary>
    /// Just a text entity with some different defaults (larger).
    /// </summary>
    class PageTitle : Text
    {
        /// <summary>
        /// Instantiates a new page title.
        /// </summary>
        /// <param name="text">The text to be displayed.</param>
        /// <param name="anchor"><see cref="Entity">Entity's</see> anchor, or position<inheritdoc cref="_anchor"/></param>
		/// <param name="layerDepth"><see cref="Entity">Entity's</see> layer depth for rendering</param>
		/// <param name="origin">Anchor's relation to <see cref="Entity">Entity's</see> position</param>
		/// <param name="enteringTransition"><see cref="Entity">Entity's</see> entering <see cref="Transition"/></param>
		/// <param name="exitingTransition"><see cref="Entity">Entity's</see> exiting <see cref="Transition"/></param>
        /// <param name="maxWidth">Maximum width of the component.</param>
        /// <param name="scale">Scale multiplier for sizing.</param>
        /// <param name="isCentered">Whether to center the content.</param>
        /// <param name="isHoverable">Whether this component is hoverable.</param>
        public PageTitle(
            string text,
            Vector2 anchor,
            float layerDepth = 0,
            Origin origin = Origin.TopLeft,
            IFilter? enteringTransition = null,
            IFilter? exitingTransition = null,
            float maxWidth = float.MaxValue,
            float scale = 1.1f,
            bool isCentered = false,
            bool isHoverable = false
        ) : base(
            text,
            anchor,
            layerDepth,
            origin,
            enteringTransition,
            exitingTransition,
            maxWidth,
            scale,
            isCentered,
            isHoverable
        )
        {
        }

        /// <inheritdoc cref="IEntity.GetName"/>
        public override string GetName()
        {
            return $"page-title-{_text}-{_key}";
        }
    }
}
