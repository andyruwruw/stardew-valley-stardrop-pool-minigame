using Microsoft.Xna.Framework;
using StardropPoolMinigame.Attributes;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
	/// <summary>
	/// <para><inheritdoc cref="Entity"/></para>
	/// <para>Includes a <see cref="PhysicsObject"/> to track velocity and acceleration.</para>
	/// </summary>
	internal abstract class EntityPhysics : Entity
	{
		/// <summary>
		/// Tracks velocity and acceleration.
		/// </summary>
		protected readonly PhysicsObject _physics;

		/// <summary>
		/// Radius of perception for intangible interactions.
		/// </summary>
		protected float _intangibleRadius;

		/// <summary>
		/// Instantiates an <see cref="EntityPhysics"/>.
		/// </summary>
		/// <param name="origin">Anchor's relation to <see cref="IEntity">IEntity's</see> position</param>
		/// <param name="anchor"><see cref="IEntity">IEntity's</see> anchor, or position</param>
		/// <param name="layerDepth"><see cref="IEntity">IEntity's</see> layer depth for rendering</param>
		/// <param name="enteringTransition"><see cref="IEntity">IEntity's</see> entering <see cref="Transition"/></param>
		/// <param name="exitingTransition"><see cref="IEntity">IEntity's</see> exiting <see cref="Transition"/></param>
		/// <param name="startingVelocity">Starting velocity for <see cref="PhysicsObject"/> as <see cref="Vector2"/></param>
		/// <param name="startinngAcceleration">Starting acceleration for <see cref="PhysicsObject"/> as <see cref="Vector2"/></param>
		/// <param name="intangibleRadius">Radius of perception for intangible interactions</param>
		public EntityPhysics(
			Origin origin,
			Vector2 anchor,
			float layerDepth,
			IFilter enteringTransition,
			IFilter exitingTransition,
			float mass,
			Vector2? startingVelocity = null,
			Vector2? startingAcceleration = null,
			float intangibleRadius = 0f
		) : base(
			origin,
			anchor,
			layerDepth,
			enteringTransition,
			exitingTransition)
		{
			_physics = new PhysicsObject(
				_anchor,
				startingVelocity != null ? (Vector2) startingVelocity : Vector2.Zero,
				startingAcceleration != null ? (Vector2) startingAcceleration : Vector2.Zero,
				mass);
			_intangibleRadius = intangibleRadius;
		}

		/// <inheritdoc cref="PhysicsObject.AddAcceleration"/>
		public void AddAcceleration(Vector2 acceleration)
		{
			_physics.AddAcceleration(acceleration);
		}

		/// <inheritdoc cref="PhysicsObject.AddPosition"/>
		public void AddPosition(Vector2 position)
		{
			_physics.AddPosition(position);
			_anchor = _physics.GetPosition();
		}

		/// <inheritdoc cref="PhysicsObject.AddVelocity"/>
		public void AddVelocity(Vector2 velocity)
		{
			_physics.AddVelocity(velocity);
		}

		/// <summary>
		/// Callback for when <see cref="EntityPhysics"/> collides.
		/// </summary>
		/// <param name="against">What the <see cref="EntityPhysics"/> collided with</param>
		public virtual void CollisionCallback(object against)
		{
		}

		/// <inheritdoc cref="PhysicsObject.DivideAcceleration"/>
		public void DivideAcceleration(Vector2 acceleration)
		{
			_physics.DivideAcceleration(acceleration);
		}

		/// <inheritdoc cref="PhysicsObject.DivideAcceleration"/>
		public void DivideAcceleration(float acceleration)
		{
			_physics.DivideAcceleration(acceleration);
		}

		/// <inheritdoc cref="PhysicsObject.DividePosition"/>
		public void DividePosition(Vector2 position)
		{
			_physics.DividePosition(position);
			_anchor = _physics.GetPosition();
		}

		/// <inheritdoc cref="PhysicsObject.DividePosition"/>
		public void DividePosition(float position)
		{
			_physics.DividePosition(position);
			_anchor = _physics.GetPosition();
		}

		/// <inheritdoc cref="PhysicsObject.DivideVelocity"/>
		public void DivideVelocity(Vector2 velocity)
		{
			_physics.DivideVelocity(velocity);
		}

		/// <inheritdoc cref="PhysicsObject.DivideVelocity"/>
		public void DivideVelocity(float velocity)
		{
			_physics.DivideVelocity(velocity);
		}

		/// <inheritdoc cref="PhysicsObject.GetAcceleration"/>
		public Vector2 GetAcceleration()
		{
			return _physics.GetAcceleration();
		}

		/// <summary>
		/// Retrieves radius of perception for intangible interactions.
		/// </summary>
		/// <returns>Radius of perception for intangible interactions</returns>
		public virtual float GetIntangibleRadius()
		{
			return _intangibleRadius;
		}

		/// <inheritdoc cref="PhysicsObject.GetMass"/>
		public virtual float GetMass()
		{
			return _physics.GetMass();
		}

		/// <inheritdoc cref="PhysicsObject.GetMaximumAcceleration"/>
		public virtual float GetMaximumAcceleration()
		{
			return _physics.GetMaximumAcceleration();
		}

		/// <inheritdoc cref="PhysicsObject.GetMaximumVelocity"/>
		public virtual float GetMaximumVelocity()
		{
			return _physics.GetMaximumVelocity();
		}

		/// <inheritdoc cref="PhysicsObject.GetPosition"/>
		public Vector2 GetPosition()
		{
			return _physics.GetPosition();
		}

		/// <inheritdoc cref="PhysicsObject.GetVelocity"/>
		public Vector2 GetVelocity()
		{
			return _physics.GetVelocity();
		}

		/// <inheritdoc cref="PhysicsObject.MultiplyAcceleration"/>
		public void MultiplyAcceleration(Vector2 acceleration)
		{
			_physics.MultiplyAcceleration(acceleration);
		}

		/// <inheritdoc cref="PhysicsObject.MultiplyAcceleration"/>
		public void MultiplyAcceleration(float acceleration)
		{
			_physics.MultiplyAcceleration(acceleration);
		}

		/// <inheritdoc cref="PhysicsObject.MultiplyPosition"/>
		public void MultiplyPosition(Vector2 position)
		{
			_physics.MultiplyPosition(position);
			_anchor = _physics.GetPosition();
		}

		/// <inheritdoc cref="PhysicsObject.MultiplyPosition"/>
		public void MultiplyPosition(float position)
		{
			_physics.MultiplyPosition(position);
			_anchor = _physics.GetPosition();
		}

		/// <inheritdoc cref="PhysicsObject.MultiplyVelocity"/>
		public void MultiplyVelocity(Vector2 velocity)
		{
			_physics.MultiplyVelocity(velocity);
		}

		/// <inheritdoc cref="PhysicsObject.MultiplyVelocity"/>
		public void MultiplyVelocity(float velocity)
		{
			_physics.MultiplyVelocity(velocity);
		}

		/// <inheritdoc cref="PhysicsObject.SetAcceleration"/>
		public void SetAcceleration(Vector2 acceleration)
		{
			_physics.SetAcceleration(acceleration);
		}

		/// <summary>
		/// Sets radius of perception for intangible interactions.
		/// </summary>
		/// <param name="intangibleRadius">New radius of perception for intangible interactions</param>
		public virtual void SetIntangibleRadius(float intangibleRadius)
		{
			_intangibleRadius = intangibleRadius;
		}

		/// <inheritdoc cref="PhysicsObject.SetMass"/>
		public virtual void SetMass(float mass)
		{
			_physics.SetMass(mass);
		}

		/// <inheritdoc cref="PhysicsObject.SetMaximumAcceleration"/>
		public virtual void SetMaximumAcceleration(float maximumAcceleration)
		{
			_physics.SetMaximumAcceleration(maximumAcceleration);
		}

		/// <inheritdoc cref="PhysicsObject.SetMaximumVelocity"/>
		public virtual void SetMaximumVelocity(float maximumVelocity)
		{
			_physics.SetMaximumVelocity(maximumVelocity);
		}

		/// <inheritdoc cref="PhysicsObject.SetPosition"/>
		public void SetPosition(Vector2 position)
		{
			_physics.SetPosition(position);
			_anchor = position;
		}

		/// <inheritdoc cref="PhysicsObject.SetVelocity"/>
		public void SetVelocity(Vector2 velocity)
		{
			_physics.SetVelocity(velocity);
		}

		/// <inheritdoc cref="PhysicsObject.SubtractAcceleration"/>
		public void SubtractAcceleration(Vector2 acceleration)
		{
			_physics.SubtractAcceleration(acceleration);
		}

		/// <inheritdoc cref="PhysicsObject.SubtractPosition"/>
		public void SubtractPosition(Vector2 position)
		{
			_physics.SubtractPosition(position);
			_anchor = _physics.GetPosition();
		}

		/// <inheritdoc cref="PhysicsObject.SubtractVelocity"/>
		public void SubtractVelocity(Vector2 velocity)
		{
			_physics.SubtractVelocity(velocity);
		}

		/// <inheritdoc cref="Entity.Update"/>
		public override void Update()
		{
			UpdatePhysics();
			base.Update();
		}

		/// <inheritdoc cref="PhysicsObject.Update"/>
		protected virtual void UpdatePhysics()
		{
			_physics.Update();
			_anchor = _physics.GetPosition();
		}

		/// <inheritdoc cref="IEntity.SetAnchor(Vector2)"/>
		public override void SetAnchor(Vector2 anchor)
		{
			this.SetPosition(anchor);
		}
	}
}