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
        /// Nested entities.
        /// </summary>
        protected IList<IEntity> _entities;

        /// <summary>
        /// Whether to show the popup instantly.
        /// </summary>
        protected bool _visible;

        /// <summary>
        /// How long to show before disappearing.
        /// </summary>
        protected int _timer;

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
            _entities = entities;
            _visible = visible;
            _timer = timer;

            InitializeDefaults();
        }

        /// <inheritdoc cref="IEntity.GetEntities"/>
        public virtual IList<IEntity> GetEntities()
        {
            return _entities;
        }

        /// <inheritdoc cref="IEntity.GetHeight"/>
        public override float GetHeight()
        {
            float minimum = float.MaxValue;
            float maximum = float.MinValue;

            foreach (IEntity entity in _entities)
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
            float minimum = float.MaxValue;
            float maximum = float.MinValue;

            foreach (IEntity entity in _entities)
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

            return maximum - minimum;
        }

        /// <inheritdoc cref="EntityPhysics.Update"/>
		public override void Update(GameTime time)
        {
            base.Update(time);

            foreach (IEntity entity in _entities)
            {
                if (entity != null)
                {
                    entity.Update(time);
                }
            }
        }

        /// <summary>
        /// Sets up default values and shows the popup if needed.
        /// </summary>
        protected virtual void InitializeDefaults()
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
