using Microsoft.Xna.Framework;
using StardropPoolMinigame.Behaviors;
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
        /// Radius of perception for intangible interactions.
        /// </summary>
        private float _intangibleRadius;

        /// <summary>
        /// Tracks velocity and acceleration.
        /// </summary>
        private PhysicsObject _physics;

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
            this._physics = new PhysicsObject(
                this._anchor,
                startingVelocity != null ? (Vector2)startingVelocity : Vector2.Zero,
                startingAcceleration != null ? (Vector2)startingAcceleration : Vector2.Zero,
                mass);
            this._intangibleRadius = intangibleRadius;
        }

        /// <inheritdoc cref="PhysicsObject.AddAcceleration"/>
        public void AddAcceleration(Vector2 acceleration)
        {
            this._physics.AddAcceleration(acceleration);
        }

        /// <inheritdoc cref="PhysicsObject.AddPosition"/>
        public void AddPosition(Vector2 position)
        {
            this._physics.AddPosition(position);
            this._anchor = this._physics.GetPosition();
        }

        /// <inheritdoc cref="PhysicsObject.AddVelocity"/>
        public void AddVelocity(Vector2 velocity)
        {
            this._physics.AddVelocity(velocity);
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
            this._physics.DivideAcceleration(acceleration);
        }

        /// <inheritdoc cref="PhysicsObject.DivideAcceleration"/>
        public void DivideAcceleration(float acceleration)
        {
            this._physics.DivideAcceleration(acceleration);
        }

        /// <inheritdoc cref="PhysicsObject.DividePosition"/>
        public void DividePosition(Vector2 position)
        {
            this._physics.DividePosition(position);
            this._anchor = this._physics.GetPosition();
        }

        /// <inheritdoc cref="PhysicsObject.DividePosition"/>
        public void DividePosition(float position)
        {
            this._physics.DividePosition(position);
            this._anchor = this._physics.GetPosition();
        }

        /// <inheritdoc cref="PhysicsObject.DivideVelocity"/>
        public void DivideVelocity(Vector2 velocity)
        {
            this._physics.DivideVelocity(velocity);
        }

        /// <inheritdoc cref="PhysicsObject.DivideVelocity"/>
        public void DivideVelocity(float velocity)
        {
            this._physics.DivideVelocity(velocity);
        }

        /// <inheritdoc cref="PhysicsObject.GetAcceleration"/>
        public Vector2 GetAcceleration()
        {
            return this._physics.GetAcceleration();
        }

        /// <summary>
        /// Retrieves radius of perception for intangible interactions.
        /// </summary>
        /// <returns>Radius of perception for intangible interactions</returns>
        public virtual float GetIntangibleRadius()
        {
            return this._intangibleRadius;
        }

        /// <inheritdoc cref="PhysicsObject.GetMass"/>
        public virtual float GetMass()
        {
            return this._physics.GetMass();
        }

        /// <inheritdoc cref="PhysicsObject.GetMaximumAcceleration"/>
        public virtual float GetMaximumAcceleration()
        {
            return this._physics.GetMaximumAcceleration();
        }

        /// <inheritdoc cref="PhysicsObject.GetMaximumVelocity"/>
        public virtual float GetMaximumVelocity()
        {
            return this._physics.GetMaximumVelocity();
        }

        /// <inheritdoc cref="PhysicsObject.GetPosition"/>
        public Vector2 GetPosition()
        {
            return this._physics.GetPosition();
        }

        /// <inheritdoc cref="PhysicsObject.GetVelocity"/>
        public Vector2 GetVelocity()
        {
            return this._physics.GetVelocity();
        }

        /// <inheritdoc cref="PhysicsObject.MultiplyAcceleration"/>
        public void MultiplyAcceleration(Vector2 acceleration)
        {
            this._physics.MultiplyAcceleration(acceleration);
        }

        /// <inheritdoc cref="PhysicsObject.MultiplyAcceleration"/>
        public void MultiplyAcceleration(float acceleration)
        {
            this._physics.MultiplyAcceleration(acceleration);
        }

        /// <inheritdoc cref="PhysicsObject.MultiplyPosition"/>
        public void MultiplyPosition(Vector2 position)
        {
            this._physics.MultiplyPosition(position);
            this._anchor = this._physics.GetPosition();
        }

        /// <inheritdoc cref="PhysicsObject.MultiplyPosition"/>
        public void MultiplyPosition(float position)
        {
            this._physics.MultiplyPosition(position);
            this._anchor = this._physics.GetPosition();
        }

        /// <inheritdoc cref="PhysicsObject.MultiplyVelocity"/>
        public void MultiplyVelocity(Vector2 velocity)
        {
            this._physics.MultiplyVelocity(velocity);
        }

        /// <inheritdoc cref="PhysicsObject.MultiplyVelocity"/>
        public void MultiplyVelocity(float velocity)
        {
            this._physics.MultiplyVelocity(velocity);
        }

        /// <inheritdoc cref="PhysicsObject.SetAcceleration"/>
        public void SetAcceleration(Vector2 acceleration)
        {
            this._physics.DividePosition(acceleration);
        }

        /// <summary>
        /// Sets radius of perception for intangible interactions.
        /// </summary>
        /// <param name="intangibleRadius">New radius of perception for intangible interactions</param>
        public virtual void SetIntangibleRadius(float intangibleRadius)
        {
            this._intangibleRadius = intangibleRadius;
        }

        /// <inheritdoc cref="PhysicsObject.SetMass"/>
        public virtual void SetMass(float mass)
        {
            this._physics.SetMass(mass);
        }

        /// <inheritdoc cref="PhysicsObject.SetMaximumAcceleration"/>
        public virtual void SetMaximumAcceleration(float maximumAcceleration)
        {
            this._physics.SetMaximumAcceleration(maximumAcceleration);
        }

        /// <inheritdoc cref="PhysicsObject.SetMaximumVelocity"/>
        public virtual void SetMaximumVelocity(float maximumVelocity)
        {
            this._physics.SetMaximumVelocity(maximumVelocity);
        }

        /// <inheritdoc cref="PhysicsObject.SetPosition"/>
        public void SetPosition(Vector2 position)
        {
            this._physics.SetPosition(position);
            this._anchor = position;
        }

        /// <inheritdoc cref="PhysicsObject.SetVelocity"/>
        public void SetVelocity(Vector2 velocity)
        {
            this._physics.SetVelocity(velocity);
        }

        /// <inheritdoc cref="PhysicsObject.SubtractAcceleration"/>
        public void SubtractAcceleration(Vector2 acceleration)
        {
            this._physics.SubtractAcceleration(acceleration);
        }

        /// <inheritdoc cref="PhysicsObject.SubtractPosition"/>
        public void SubtractPosition(Vector2 position)
        {
            this._physics.SubtractPosition(position);
            this._anchor = this._physics.GetPosition();
        }

        /// <inheritdoc cref="PhysicsObject.SubtractVelocity"/>
        public void SubtractVelocity(Vector2 velocity)
        {
            this._physics.SubtractVelocity(velocity);
        }

        /// <inheritdoc cref="Entity.Update"/>
        public override void Update()
        {
            this.UpdatePhysics();
            base.Update();
        }

        /// <inheritdoc cref="PhysicsObject.Update"/>
        protected virtual void UpdatePhysics()
        {
            this._physics.Update();
            this._anchor = this._physics.GetPosition();
        }
    }
}