using Microsoft.Xna.Framework;
using MinigameFramework.Enums;
using MinigameFramework.Render.Filters;

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
            Vector2 anchor,
            float width,
            float height,
            float layerDepth = 0,
            Origin origin = Origin.TopLeft,
            IFilter enteringTransition = null,
            IFilter exitingTransition = null
        ) : base(
            anchor,
            layerDepth,
            origin,
            enteringTransition,
            exitingTransition
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
            IFilter enteringTransition = null,
            IFilter exitingTransition = null
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
            IFilter enteringTransition = null,
            IFilter exitingTransition = null
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

        /// <summary>
        /// Retrieves the color of the solid.
        /// </summary>
        /// <returns></returns>
        public Color GetColor()
        {
            return this._color;
        }

        /// <inheritdoc cref="IEntity.GetHeight"/>
        public override float GetHeight()
        {
            return this._destination.GetHeight();
        }

        /// <inheritdoc cref="IEntity.GetId"/>
        public override string GetId()
        {
            return $"solid-{this._id}";
        }

        /// <inheritdoc cref="IEntity.GetWidth"/>
        public override float GetWidth()
        {
            return this._destination.GetWidth();
        }

        /// <summary>
        /// Sets the solid color to a new color.
        /// </summary>
        /// <param name="color">The new color.</param>
        public void SetColor(Color color)
        {
            this._color = color;
        }
    }
}
