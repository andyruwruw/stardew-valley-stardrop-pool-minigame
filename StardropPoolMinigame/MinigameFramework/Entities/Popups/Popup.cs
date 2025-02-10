using Microsoft.Xna.Framework;
using MinigameFramework.Enums;
using MinigameFramework.Render.Filters;

namespace MinigameFramework.Entities.Popups
{
    /// <summary>
    /// A general popup, any entities that appear for a short time over everything else.
    /// </summary>
    class Popup : Entity
    {
        /// <summary>
        /// Height of the component.
        /// </summary>
        protected float _height = -1;

        /// <summary>
        /// How long to show before disappearing.
        /// </summary>
        protected int _timer;

        /// <summary>
        /// Whether to show the popup instantly.
        /// </summary>
        protected bool _visible;

        /// <summary>
        /// The width of the component.
        /// </summary>
        protected float _width = -1;

        /// <summary>
        /// Instantiates a new <see cref="Popup"/>.
        /// </summary>
        public Popup(
            IList<IEntity> entities,
            Vector2? anchor = null,
            float layerDepth = 1f,
            Origin origin = Origin.CenterCenter,
            IFilter? enteringTransition = null,
            IFilter? exitingTransition = null,
            bool visible = false,
            int timer = 100
        ) : base(
            new Vector2(0, 0),
            layerDepth,
            origin,
            enteringTransition,
            exitingTransition
        )
        {
            _children = entities;
            _visible = visible;
            _timer = timer;

            InitializeDefaults(anchor);
        }

        /// <inheritdoc cref="IEntity.GetHeight"/>
        public override float GetHeight()
        {
            if (_height != -1)
            {
                return _height;
            }

            float minimum = float.MaxValue;
            float maximum = float.MinValue;

            foreach (IEntity entity in GetChildren())
            {
                Vector2 topLeft = entity.GetTopLeft();

                if (topLeft.Y < minimum)
                {
                    minimum = entity.GetTopLeft().X;
                }
                if (topLeft.Y + entity.GetHeight() > maximum)
                {
                    maximum = topLeft.Y + entity.GetWidth();
                }
            }

            _height = maximum - minimum;

            return maximum - minimum;
        }

        /// <inheritdoc cref="IEntity.GetId"/>
        public override string GetId()
        {
            return $"popup-{_id}";
        }

        /// <inheritdoc cref="IEntity.GetWidth"/>
        public override float GetWidth()
        {
            if (_width != -1)
            {
                return _width;
            }

            float minimum = float.MaxValue;
            float maximum = float.MinValue;

            foreach (IEntity entity in GetChildren())
            {
                Vector2 topLeft = entity.GetTopLeft();

                if (topLeft.X < minimum)
                {
                    minimum = entity.GetTopLeft().X;
                }
                if (topLeft.X + entity.GetWidth()  > maximum)
                {
                    maximum = topLeft.X + entity.GetWidth();
                }
            }

            _width = maximum - minimum;

            return maximum - minimum;
        }

        /// <inheritdoc cref="IEntity.ShouldDrawChildren"/>
        public override bool ShouldDrawChildren()
        {
            return true;
        }

        /// <inheritdoc cref="IEntity.ShouldDrawSelf"/>
        public override bool ShouldDrawSelf()
        {
            return false;
        }

        /// <summary>
        /// Sets up default values and shows the popup if needed.
        /// </summary>
        protected virtual void InitializeDefaults(Vector2? initialAnchor)
        {

        }

        /// <summary>
        /// Setup default entities.
        /// </summary>
        protected virtual void InitializeEntities()
        {

        }
    }
}
