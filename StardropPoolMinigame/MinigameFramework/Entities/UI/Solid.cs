using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using MinigameFramework.Constants;
using MinigameFramework.Enums;
using MinigameFramework.Helpers;
using MinigameFramework.Render.Filters;
using MinigameFramework.Structures.Primitives;

namespace MinigameFramework.Entities.UI
{
    /// <summary>
    /// A solid rectangle of a choice color.
    /// </summary>
    class Solid : Entity
    {
        /// <summary>
        /// Color of the solid.
        /// </summary>
        protected Color _color;

        /// <summary>
        /// Where to display the solid.
        /// </summary>
        protected Structures.Primitives.Rectangle _destination;

        /// <summary>
        /// Instantiates a solid.
        /// </summary>
        /// <param name="color">Color of the solid.</param>
        /// <param name="anchor"><see cref="Entity">Entity's</see> anchor, or position<inheritdoc cref="_anchor"/></param>
        /// <param name="width">Width of the solid.</param>
        /// <param name="height">Height of the solid.</param>
		/// <param name="layerDepth"><see cref="Entity">Entity's</see> layer depth for rendering</param>
		/// <param name="origin">Anchor's relation to <see cref="Entity">Entity's</see> position</param>
		/// <param name="enteringTransition"><see cref="Entity">Entity's</see> entering <see cref="Transition"/></param>
		/// <param name="exitingTransition"><see cref="Entity">Entity's</see> exiting <see cref="Transition"/></param>
        public Solid(
            Color color,
            IEntity? parent = null,
            string? key = null,
            Vector2? anchor = null,
            Position? position = Position.Relative,
            IList<IEntity>? children = null,
            float? layerDepth = null,
            bool? isHoverable = false,
            bool? isInteractable = false,
            IFilter? enteringTransition = null,
            IFilter? exitingTransition = null,
            bool? isRow = false,
            bool? centerContent = false,
            bool? center = false,
            Vector2? contentOffset = null,
            bool? fixedPosition = false,
            float? gap = 0f,
            float? height = -1f,
            float? margin = 0f,           
            float? marginBottom = 0f,
            float? marginLeft = 0f,
            float? marginRight = 0f,
            float? marginTop = 0f,
            float? maxHeight = -1f,
            float? maxWidth = -1f,
            float? minHeight = -1f,
            float? minWidth = -1f,
            bool? overflow = false,
            float? padding = 0f,
            float? paddingBottom = 0f,
            float? paddingLeft = 0f,
            float? paddingRight = 0f,
            float? paddingTop = 0f,
            float? width = -1f
        ) : base(
            parent,
            key,
            anchor,
            position,
            children,
            layerDepth,
            isHoverable,
            isInteractable,
            enteringTransition,
            exitingTransition,
            isRow,
            centerContent,
            center,
            contentOffset,
            fixedPosition,
            gap,
            height,
            margin,
            marginBottom,
            marginLeft,
            marginRight,
            marginTop,
            maxHeight,
            maxWidth,
            minHeight,
            minWidth,
            overflow,
            padding,
            paddingBottom,
            paddingLeft,
            paddingRight,
            paddingTop,
            width
        )
        {
            _destination = new Structures.Primitives.Rectangle(
                anchor,
                width,
                height
            );
            _color = color;
        }

        /// <summary>
        /// Instantiates a solid.
        /// </summary>
        /// <param name="color">Color of the solid.</param>
        /// <param name="destination">Destination of the solid.</param>
		/// <param name="layerDepth"><see cref="Entity">Entity's</see> layer depth for rendering</param>
		/// <param name="origin">Anchor's relation to <see cref="Entity">Entity's</see> position</param>
		/// <param name="enteringTransition"><see cref="Entity">Entity's</see> entering <see cref="Transition"/></param>
		/// <param name="exitingTransition"><see cref="Entity">Entity's</see> exiting <see cref="Transition"/></param>
        public Solid(
            Color color,
            Structures.Primitives.Rectangle destination,
            float layerDepth = 0,
            Origin origin = Origin.TopLeft,
            IFilter? enteringTransition = null,
            IFilter? exitingTransition = null
        ) : base(
            destination.GetAnchor(),
            layerDepth,
            origin,
            enteringTransition,
            exitingTransition
        )
        {
            _destination = destination;
            _color = color;
        }

        /// <summary>
        /// Instantiates a solid.
        /// </summary>
        /// <param name="color">Color of the solid.</param>
        /// <param name="destination">Destination of the solid.</param>
		/// <param name="layerDepth"><see cref="Entity">Entity's</see> layer depth for rendering</param>
		/// <param name="origin">Anchor's relation to <see cref="Entity">Entity's</see> position</param>
		/// <param name="enteringTransition"><see cref="Entity">Entity's</see> entering <see cref="Transition"/></param>
		/// <param name="exitingTransition"><see cref="Entity">Entity's</see> exiting <see cref="Transition"/></param>
        public Solid(
            Color color,
            Microsoft.Xna.Framework.Rectangle destination,
            float layerDepth = 0,
            Origin origin = Origin.TopLeft,
            IFilter? enteringTransition = null,
            IFilter? exitingTransition = null
        ) : base(
            new Vector2(
                destination.X,
                destination.Y
            ),
            layerDepth,
            origin,
            enteringTransition,
            exitingTransition
        )
        {
            _destination = new Structures.Primitives.Rectangle(destination);
            _color = color;
        }

        /// <inheritdoc cref="IEntity.Draw"/>
        public override void Draw(
            SpriteBatch batch,
            Vector2? overrideDestination = null,
            Microsoft.Xna.Framework.Rectangle? overrideSource = null,
            Color? overrideColor = null,
            float? overrideRotation = null,
            Vector2? overrideOrigin = null,
            float? overrideScale = null,
            SpriteEffects? overrideEffects = null,
            float? overrideLayerDepth = null
        )
        {
            if (!ShouldDraw())
            {
                return;
            }

            batch.Draw(
                GetTileset(),
                GetRectangleDestination(),
                GetSource(overrideSource),
                GetColor(overrideColor),
                GetRotation(overrideRotation),
                GetOrigin(overrideOrigin),
                GetEffects(overrideEffects),
                GetLayerDepth(overrideLayerDepth)
            );

            if (DevConstants.DebugVisuals)
            {
                DrawDebug(batch);
            }
        }

        /// <inheritdoc cref="IEntity.GetBoundary()"/>
        public override IRange GetBoundary()
        {
            return _destination;
        }

        /// <inheritdoc cref="IEntity.GetHeight"/>
        public override float GetHeight()
        {
            return _destination.GetHeight();
        }

        /// <inheritdoc cref="IEntity.GetName"/>
        public override string GetName()
        {
            return $"solid-{_key}";
        }

        /// <inheritdoc cref="IEntity.GetWidth"/>
        public override float GetWidth()
        {
            return _destination.GetWidth();
        }

        /// <summary>
        /// Sets the solid color to a new color.
        /// </summary>
        /// <param name="color">The new color.</param>
        public void SetColor(Color color)
        {
            _color = color;
        }

        /// <inheritdoc cref="Entity.DrawDebug"/>
        protected override void DrawDebug(SpriteBatch batch)
        {
            Structures.Primitives.Rectangle boundary = (Structures.Primitives.Rectangle)GetBoundary();

            RenderHelpers.DrawDebugRectangle(
                batch,
                new Structures.Primitives.Rectangle(boundary.GetRawXnaRectangle())
            );
        }

        /// <inheritdoc cref="Entity.GetRawColor()"/>
        protected override Color GetRawColor()
        {
            return _color;
        }

        /// <summary>
        /// We need a rectangle as a destination.
        /// </summary>
        protected virtual Microsoft.Xna.Framework.Rectangle GetRawRectangleDestination()
        {
            return _destination.GetRawXnaRectangle();
        }

        /// <inheritdoc cref="Entity.GetRawSource"/>
        protected override Microsoft.Xna.Framework.Rectangle GetRawSource()
        {
            return Game1.staminaRect.Bounds;
        }

        /// <summary>
        /// We need a rectangle as a destination.
        /// </summary>
        protected virtual Microsoft.Xna.Framework.Rectangle GetRectangleDestination(Microsoft.Xna.Framework.Rectangle? overrideDestination = null)
        {
            // We aren't really set up to filter rectangles.
            return overrideDestination == null ? GetRawRectangleDestination() : (Microsoft.Xna.Framework.Rectangle)overrideDestination;
        }

        /// <inheritdoc cref="Entity.GetTileset"/>
        protected override Texture2D? GetTileset()
        {
            return Game1.staminaRect;
        }
    }
}
