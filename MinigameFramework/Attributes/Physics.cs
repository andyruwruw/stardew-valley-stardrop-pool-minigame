using Microsoft.Xna.Framework;

namespace MinigameFramework.Attributes
{
    /// <summary>
    /// Maintains position, velocity and acceleration of an object.
    /// </summary>
    class Physics
    {
        /// <summary>
        /// Acceleration of the object as <see cref="Vector2"/>.
        /// </summary>
        protected Vector2 _acceleration;

        /// <summary>
        /// Velocity of the object as <see cref="Vector2"/>.
        /// </summary>
        protected Vector2 _velocity;

        /// <summary>
        /// Position of the object as <see cref="Vector2"/>.
        /// </summary>
        protected Vector2 _position;

        /// <summary>
        /// Mass of the object.
        /// </summary>
        protected float _mass;

        /// <summary>
        /// Maximum acceleration the object can speed up.
        /// </summary>
        protected float _maxAcceleration;

        /// <summary>
        /// Maximum velocity the object can travel.
        /// </summary>
        protected float _maxVelocity;

        /// <summary>
        /// Instantiates a physics tracking object.
        /// </summary>
        /// <param name="position">Position of the object as <see cref="Vector2"/></param>
        /// <param name="velocity">Velocity of the object as <see cref="Vector2"/></param>
        /// <param name="acceleration">Acceleration of the object as <see cref="Vector2"/></param>
        /// <param name="mass">Mass of the the object</param>
        /// <param name="maxVelocity">Maximum velocity the object can travel</param>
        /// <param name="maxAcceleration">Maximum acceleration the object can speed up</param>
        public Physics(
            Vector2 position,
            Vector2 velocity,
            Vector2 acceleration,
            float mass = 0,
            float maxVelocity = float.MaxValue,
            float maxAcceleration = float.MaxValue)
        {
            this._position = position;
            this._velocity = velocity;
            this._acceleration = acceleration;
            this._mass = mass;
            this._maxVelocity = maxVelocity;
            this._maxAcceleration = maxAcceleration;
        }

        /// <summary>
        /// <para>Instantiates a physics tracking object.</para>
        /// <para>Acceleration defaulted to a <see cref="Vector2"/> of 0.</para>
        /// </summary>
        /// <param name="position">Position of the object as <see cref="Vector2"/></param>
        /// <param name="velocity">Velocity of the object as <see cref="Vector2"/></param>
        /// <param name="mass">Mass of the the object</param>
        /// <param name="maxVelocity">Maximum velocity the object can travel</param>
        /// <param name="maxAcceleration">Maximum acceleration the object can speed up</param>
        public Physics(
            Vector2 position,
            Vector2 velocity,
            float mass = 0,
            float maxVelocity = float.MaxValue,
            float maxAcceleration = float.MaxValue)
        {
            this._position = position;
            this._velocity = velocity;
            this._acceleration = Vector2.Zero;
            this._mass = mass;
            this._maxVelocity = maxVelocity;
            this._maxAcceleration = maxAcceleration;
        }

        /// <summary>
        /// <para>Instantiates a physics tracking object.</para>
        /// <para>Acceleration and velocity defaulted to a <see cref="Vector2"/> of 0.</para>
        /// </summary>
        /// <param name="position">Position of the object as <see cref="Vector2"/></param>
        /// <param name="mass">Mass of the the object</param>
        /// <param name="maxVelocity">Maximum velocity the object can travel</param>
        /// <param name="maxAcceleration">Maximum acceleration the object can speed up</param>
        public Physics(
            Vector2 position,
            float mass = 0,
            float maxVelocity = float.MaxValue,
            float maxAcceleration = float.MaxValue)
        {
            this._position = position;
            this._velocity = Vector2.Zero;
            this._acceleration = Vector2.Zero;
            this._mass = mass;
            this._maxVelocity = maxVelocity;
            this._maxAcceleration = maxAcceleration;
        }

        /// <summary>
        /// Retrieves acceleration of the object as <see cref="Vector2"/>.
        /// </summary>
        /// <returns>Acceleration of the object as <see cref="Vector2"/></returns>
        public Vector2 GetAcceleration()
        {
            return this._acceleration;
        }

        /// <summary>
        /// Sets acceleration of the object as <see cref="Vector2"/>.
        /// </summary>
        /// <param name="acceleration">New acceleration of the object as <see cref="Vector2"/></param>
        public void SetAcceleration(Vector2 acceleration)
        {
            this._acceleration = acceleration;
        }

        /// <summary>
        /// Retrieves velocity of the object as <see cref="Vector2"/>.
        /// </summary>
        /// <returns>Velocity of the object as <see cref="Vector2"/></returns>
        public Vector2 GetVelocity()
        {
            return this._velocity;
        }

        /// <summary>
        /// Sets velocity of the object as <see cref="Vector2"/>.
        /// </summary>
        /// <param name="velocity">New velocity of the object as <see cref="Vector2"/></param>
        public void SetVelocity(Vector2 velocity)
        {
            this._velocity = velocity;
        }

        /// <summary>
        /// Retrieves position of the object as <see cref="Vector2"/>.
        /// </summary>
        /// <returns>Position of the object as <see cref="Vector2"/></returns>
        public Vector2 GetPosition()
        {
            return this._velocity;
        }

        /// <summary>
        /// Sets position of the object as <see cref="Vector2"/>.
        /// </summary>
        /// <param name="position">New position of the object as <see cref="Vector2"/></param>
        public void SetPosition(Vector2 position)
        {
            this._position = position;
        }

        /// <summary>
        /// Retrieves mass of the object.
        /// </summary>
        /// <returns>Mass of the object</returns>
        public float GetMass()
        {
            return this._mass;
        }

        /// <summary>
        /// Sets mass of the the object.
        /// </summary>
        /// <param name="mass">New mass of the the object</param>
        public void SetMass(float mass)
        {
            this._mass = mass;
        }

        /// <summary>
        /// Retrieves maximum acceleration the object can speed up.
        /// </summary>
        /// <returns>Maximum acceleration the object can speed up</returns>
        public float GetMaxAcceleration()
        {
            return this._maxAcceleration;
        }

        /// <summary>
        /// Sets maximum acceleration the object can speed up.
        /// </summary>
        /// <param name="maxAcceleration">New maximum acceleration the object can speed up</param>
        public void SetMaxAcceleration(float maxAcceleration)
        {
            this._maxAcceleration = maxAcceleration;
        }

        /// <summary>
        /// Retrieves maximum velocity the object can travel.
        /// </summary>
        /// <returns>Maximum velocity the object can travel</returns>
        public float GetMaxVelocity()
        {
            return this._maxVelocity;
        }

        /// <summary>
        /// Sets maximum acceleration the object can speed up.
        /// </summary>
        /// <param name="maxVelocity">New maximum acceleration the object can speed up</param>
        public void SetMaxVelocity(float maxVelocity)
        {
            this._maxVelocity = maxVelocity;
        }

        /// <summary>
        /// Updates position, velocity and acceleration of the object.
        /// </summary>
        /// <param name="time">Game time.</param>
        public void Update(GameTime time)
        {
            this._position = Vector2.Add(
                this._position,
                this._velocity
            );
            this._velocity = Vector2.Add(
                this._velocity,
                this._acceleration
            );
            this._acceleration = Vector2.Zero;
        }
    }
}
