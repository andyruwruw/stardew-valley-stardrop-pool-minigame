using Microsoft.Xna.Framework;
using MinigameFramework.Attributes;
using MinigameFramework.Render.Filters;

namespace MinigameFramework.Entities.Particles
{
    abstract class Particle : Entity
    {
        /// <summary>
        /// Physical attributes of the ball.
        /// </summary>
        protected Physics _physics;
        
        /// <summary>
		/// Instantiates a <see cref="ParticleEmitter"/>.
		/// </summary>
		public Particle(
            IEntity? parent = null,
            string? key = null,
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
        ) {
            _physics = new Physics(GetAnchor());
        }

        /// <inheritdoc cref="IEntity.GetHeight"/>
        public override float GetHeight()
        {
            return 16f;
        }

        /// <inheritdoc cref="IEntity.GetName"/>
        public override string GetName()
        {
            return $"particle-{_key}";
        }

        /// <summary>
        /// Retrieves the particles internal physics tracker.
        /// </summary>
        public Physics GetPhysics()
        {
            return _physics;
        }

        /// <inheritdoc cref="IEntity.GetWidth"/>
        public override float GetWidth()
        {
            return 16f;
        }
    }
}
