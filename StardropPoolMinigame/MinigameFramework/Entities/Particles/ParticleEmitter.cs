using Microsoft.Xna.Framework;
using MinigameFramework.Constants;
using MinigameFramework.Entities.Particles.ParticleRules;
using MinigameFramework.Enums;
using MinigameFramework.Helpers;
using MinigameFramework.Render.Filters;
using MinigameFramework.Structures;

namespace MinigameFramework.Entities.Particles
{
    /// <summary>
	/// Emits <see cref="Particle"/> at a given rate and manages updating them.
	/// </summary>
    abstract class ParticleEmitter : Entity
    {
        /// <summary>
		/// Whether the <see cref="ParticleEmitter"/> is active.
		/// </summary>
		protected bool _active;

        /// <summary>
		/// The direction as a <see cref="Vector2"/> the <see cref="Particle"/> are emitted.
		/// </summary>
		protected Vector2 _direction;

        /// <summary>
        /// <see cref="IParticleRules"/> system of rules applied to <see cref="Particle"/>.
        /// </summary>
        protected IParticleRules? _rules;

        /// <summary>
		/// <see cref="QuadTree{T}"/> managing <see cref="Particle"/>.
		/// </summary>
		protected QuadTree _graph;

        /// <summary>
		/// Radius <see cref="Particle"/> can be born in.
		/// </summary>
		protected float _radius;

        /// <summary>
        /// Rate at which <see cref="Particle"/> are emitted.
        /// </summary>
        protected float _rate;

        /// <summary>
		/// Instantiates a <see cref="ParticleEmitter"/>.
		/// </summary>
        /// <param name="anchor"><see cref="Entity">Entity's</see> anchor, or position<inheritdoc cref="_anchor"/></param>
		/// <param name="layerDepth"><see cref="Entity">Entity's</see> layer depth for rendering</param>
		/// <param name="origin">Anchor's relation to <see cref="Entity">Entity's</see> position</param>
		/// <param name="enteringTransition"><see cref="Entity">Entity's</see> entering <see cref="Transition"/></param>
		/// <param name="exitingTransition"><see cref="Entity">Entity's</see> exiting <see cref="Transition"/></param>
		public ParticleEmitter(
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
            float? width = -1f,
            bool? active = false,
            Vector2? direction = null,
            IParticleRules? rules = null,
            float? radius = 0f,
            float? rate = 0f
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
        ) {
            _graph = new QuadTree(new Structures.Primitives.Rectangle(
                new Vector2(0, 0),
                GenericRenderConstants.MinigameScreen.Width,
                GenericRenderConstants.MinigameScreen.Height
            ));

            _active = active ?? false;
            _direction = direction ?? new Vector2(0, 0);
            _rules = rules;
            _radius = radius ?? 0f;
            _rate = rate ?? 0f;
        }

        /// <summary>
        /// Activates the particle emitter.
        /// </summary>
        public void Activate()
        {
            _active = true;

            Utilities.Timer.StartTimer($"{GetName()}-creation-cycle");
        }

        /// <summary>
        /// Deactivates the particle emitter.
        /// </summary>
        public void Deactivate()
        {
            _active = false;

            Utilities.Timer.EndTimer($"{GetName()}-creation-cycle");
        }

        /// <inheritdoc cref="IEntity.GetEntities"/>
        public override IList<IEntity> GetChildren()
        {
            return _graph.Query();
        }

        /// <summary>
        /// Retrieve's the particle emitter's direction.
        /// </summary>
        public virtual Vector2 GetDirection()
        {
            return _direction;
        }

        /// <inheritdoc cref="IEntity.GetHeight"/>
        public override float GetHeight()
        {
            return _graph.GetBoundary().GetHeight();
        }

        /// <inheritdoc cref="IEntity.GetName"/>
        public override string GetName()
        {
            return $"particle-emitter-{_key}";
        }

        /// <summary>
        /// Retrieves the particle emitter's radius.
        /// </summary>
        public virtual float GetRadius()
        {
            return _radius;
        }

        /// <summary>
        /// Retrieves the particle emitter's emittion rate.
        /// </summary>
        public virtual float GetRate()
        {
            return _rate;
        }

        /// <summary>
        /// Retrieves the particle emitter's rules.
        /// </summary>
        public virtual IParticleRules? GetRules()
        {
            return _rules;
        }

        /// <inheritdoc cref="IEntity.GetWidth"/>
        public override float GetWidth()
        {
            return _graph.GetBoundary().GetWidth();
        }

        /// <summary>
        /// Whether the emitter is actively emitting.
        /// </summary>
        public bool IsActive()
        {
            return _active;
        }

        /// <summary>
        /// Sets the particle emitter's direction.
        /// </summary>
        public virtual void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        /// <summary>
        /// Sets the particle emitter's radius.
        /// </summary>
        public virtual void SetRadius(float radius)
        {
            _radius = radius;
        }

        /// <summary>
        /// Sets the particle emitter's emission rate.
        /// </summary>
        public virtual void SetRate(float rate)
        {
            _rate = rate;
        }

        /// <summary>
        /// Sets the particle emitter's rules.
        /// </summary>
        public virtual void SetRules(IParticleRules rules)
        {
            _rules = rules;
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
        /// Retrieves a random position in the creation window.
        /// </summary>
        protected Vector2 GetPositionInCreationWindow()
        {
            return Vector2.Add(
                _anchor,
                new Vector2(
                    MiscellaneousHelpers.Random() * _radius,
                    MiscellaneousHelpers.Random() * _radius
                )
            );
        }
    }
}
