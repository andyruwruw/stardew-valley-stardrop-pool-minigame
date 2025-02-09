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
        protected IParticleRules _rules;

        /// <summary>
		/// <see cref="QuadTree{T}"/> managing <see cref="Particle"/>.
		/// </summary>
		protected QuadTree<IEntity> _quadTree;

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
        ) {
            _quadTree = new QuadTree<IEntity>(new MinigameFramework.Structures.Primitives.Rectangle(
                new Vector2(0, 0),
                GenericRenderConstants.MinigameScreen.Width,
                GenericRenderConstants.MinigameScreen.Height
            ));
        }

        /// <summary>
        /// Activates the particle emitter.
        /// </summary>
        public void Activate()
        {
            _active = true;

            MinigameFramework.Utilities.Timer.StartTimer($"{GetId()}-creation-cycle");
        }

        /// <summary>
        /// Deactivates the particle emitter.
        /// </summary>
        public void Deactivate()
        {
            _active = false;

            MinigameFramework.Utilities.Timer.EndTimer($"{GetId()}-creation-cycle");
        }

        /// <summary>
        /// Retrieve's the particle emitter's direction.
        /// </summary>
        public virtual Vector2 GetDirection()
        {
            return _direction;
        }

        /// <inheritdoc cref="IEntity.GetEntities"/>
        public override IList<IEntity> GetEntities()
        {
            return _quadTree.Query();
        }

        /// <inheritdoc cref="IEntity.GetHeight"/>
        public override float GetHeight()
        {
            return _quadTree.GetBoundary().GetHeight();
        }

        /// <inheritdoc cref="IEntity.GetId"/>
        public override string GetId()
        {
            return $"particle-emitter-{_id}";
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
        public virtual IParticleRules GetRules()
        {
            return _rules;
        }

        /// <inheritdoc cref="IEntity.GetWidth"/>
        public override float GetWidth()
        {
            return _quadTree.GetBoundary().GetWidth();
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

        /// <summary>
        /// Updates the particle system.
        /// </summary>
        /// <param name="time">Game time.</param>
        public override void Update(GameTime time)
        {
            base.Update(time);
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
