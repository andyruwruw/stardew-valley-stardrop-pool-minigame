using Microsoft.Xna.Framework;

namespace StardropPoolMinigame.Attributes
{
    /// <summary>
    /// Maintains position, velocity and acceleration of an object.
    /// </summary>
    internal class PhysicsObject
    {
        /// <summary>
        /// Acceleration of <see cref="PhysicsObject"/> as <see cref="Vector2"/>.
        /// </summary>
        private Vector2 _acceleration;

        /// <summary>
        /// Mass of the <see cref="PhysicsObject"/>.
        /// </summary>
        private float _mass;

        /// <summary>
        /// Maximum acceleration <see cref="PhysicsObject"/> can speed up.
        /// </summary>
        private float _maximumAcceleration;

        /// <summary>
        /// Maximum velocity <see cref="PhysicsObject"/> can travel.
        /// </summary>
        private float _maximumVelocity;

        /// <summary>
        /// Position of <see cref="PhysicsObject"/> as <see cref="Vector2"/>.
        /// </summary>
        private Vector2 _position;

        /// <summary>
        /// Velocity of <see cref="PhysicsObject"/> as <see cref="Vector2"/>.
        /// </summary>
        private Vector2 _velocity;

        /// <summary>
        /// Instantiates a <see cref="PhysicsObject"/>.
        /// </summary>
        /// <param name="position">Position of <see cref="PhysicsObject"/> as <see cref="Vector2"/></param>
        /// <param name="velocity">Velocity of <see cref="PhysicsObject"/> as <see cref="Vector2"/></param>
        /// <param name="acceleration">Acceleration of <see cref="PhysicsObject"/> as <see cref="Vector2"/></param>
        /// <param name="mass">Mass of the <see cref="PhysicsObject"/></param>
        /// <param name="maximumVelocity">Maximum velocity <see cref="PhysicsObject"/> can travel</param>
        /// <param name="maximumAcceleration">Maximum acceleration <see cref="PhysicsObject"/> can speed up</param>
        public PhysicsObject(
            Vector2 position,
            Vector2 velocity,
            Vector2 acceleration,
            float mass,
            float maximumVelocity = float.MaxValue,
            float maximumAcceleration = float.MaxValue)
        {
            this._position = position;
            this._velocity = velocity;
            this._acceleration = acceleration;
            this._mass = mass;
            this._maximumVelocity = maximumVelocity;
            this._maximumAcceleration = maximumAcceleration;
        }

        /// <summary>
        /// <para>Instantiates a <see cref="PhysicsObject"/>.</para>
        /// <para>Acceleration defaulted to a <see cref="Vector2"/> of 0.</para>
        /// </summary>
        /// <param name="position">Position of <see cref="PhysicsObject"/> as <see cref="Vector2"/></param>
        /// <param name="velocity">Velocity of <see cref="PhysicsObject"/> as <see cref="Vector2"/></param>
        /// <param name="mass">Mass of the <see cref="PhysicsObject"/></param>
        /// <param name="maximumVelocity">Maximum velocity <see cref="PhysicsObject"/> can travel</param>
        /// <param name="maximumAcceleration">Maximum acceleration <see cref="PhysicsObject"/> can speed up</param>
        public PhysicsObject(
            Vector2 position,
            Vector2 velocity,
            float mass,
            float maximumVelocity = float.MaxValue,
            float maximumAcceleration = float.MaxValue)
        {
            this._position = position;
            this._velocity = velocity;
            this._acceleration = Vector2.Zero;
            this._mass = mass;
            this._maximumVelocity = maximumVelocity;
            this._maximumAcceleration = maximumAcceleration;
        }

        /// <summary>
        /// <para>Instantiates a <see cref="PhysicsObject"/>.</para>
        /// <para>Velocity and acceleration defaulted to a <see cref="Vector2"/> of 0.</para>
        /// </summary>
        /// <param name="position">Position of <see cref="PhysicsObject"/> as <see cref="Vector2"/></param>
        /// <param name="mass">Mass of the <see cref="PhysicsObject"/></param>
        /// <param name="maximumVelocity">Maximum velocity <see cref="PhysicsObject"/> can travel</param>
        /// <param name="maximumAcceleration">Maximum acceleration <see cref="PhysicsObject"/> can speed up</param>
        public PhysicsObject(
            Vector2 position,
            float mass,
            float maximumVelocity = float.MaxValue,
            float maximumAcceleration = float.MaxValue)
        {
            this._position = position;
            this._velocity = Vector2.Zero;
            this._acceleration = Vector2.Zero;
            this._mass = mass;
            this._maximumVelocity = maximumVelocity;
            this._maximumAcceleration = maximumAcceleration;
        }

        /// <summary>
        /// Adds a <see cref="Vector2"/> to the acceleration of the <see cref="PhysicsObject"/>.
        /// </summary>
        /// <param name="acceleration"><see cref="Vector2"/> to be added to acceleration</param>
        public void AddAcceleration(Vector2 acceleration)
        {
            this._acceleration = Vector2.Add(this._acceleration, acceleration);
        }

        /// <summary>
        /// Adds a <see cref="Vector2"/> to the position of the <see cref="PhysicsObject"/>.
        /// </summary>
        /// <param name="position"><see cref="Vector2"/> to be added to position</param>
        public void AddPosition(Vector2 position)
        {
            this._position = Vector2.Add(this._position, position);
        }

        /// <summary>
        /// Adds a <see cref="Vector2"/> to the velocity of the <see cref="PhysicsObject"/>.
        /// </summary>
        /// <param name="velocity"><see cref="Vector2"/> to be added to velocity</param>
        public void AddVelocity(Vector2 velocity)
        {
            this._velocity = Vector2.Add(this._velocity, velocity);
        }

        /// <summary>
        /// Divides a <see cref="Vector2"/> from the acceleration of the <see cref="PhysicsObject"/>.
        /// </summary>
        /// <param name="acceleration"><see cref="Vector2"/> to be divided from acceleration</param>
        public void DivideAcceleration(Vector2 acceleration)
        {
            this._acceleration = Vector2.Divide(this._acceleration, acceleration);
        }

        /// <summary>
        /// Divides a float from the acceleration of the <see cref="PhysicsObject"/>.
        /// </summary>
        /// <param name="acceleration">Float to be divided from acceleration</param>
        public void DivideAcceleration(float acceleration)
        {
            this._acceleration = Vector2.Divide(this._acceleration, acceleration);
        }

        /// <summary>
        /// Divides a <see cref="Vector2"/> from the position of the <see cref="PhysicsObject"/>.
        /// </summary>
        /// <param name="position"><see cref="Vector2"/> to be divided from position</param>
        public void DividePosition(Vector2 position)
        {
            this._position = Vector2.Divide(this._position, position);
        }

        /// <summary>
        /// Divides a float from the position of the <see cref="PhysicsObject"/>.
        /// </summary>
        /// <param name="position">Float to be divided from position</param>
        public void DividePosition(float position)
        {
            this._position = Vector2.Divide(this._position, position);
        }

        /// <summary>
        /// Divides a <see cref="Vector2"/> from the velocity of the <see cref="PhysicsObject"/>.
        /// </summary>
        /// <param name="velocity"><see cref="Vector2"/> to be divided from velocity</param>
        public void DivideVelocity(Vector2 velocity)
        {
            this._velocity = Vector2.Divide(this._velocity, velocity);
        }

        /// <summary>
        /// Divides a float from the velocity of the <see cref="PhysicsObject"/>.
        /// </summary>
        /// <param name="velocity">Float to be divided from velocity</param>
        public void DivideVelocity(float velocity)
        {
            this._velocity = Vector2.Divide(this._velocity, velocity);
        }

        /// <summary>
        /// Retrieves acceleration of <see cref="PhysicsObject"/> as <see cref="Vector2"/>.
        /// </summary>
        /// <returns>Acce;eratopm of <see cref="PhysicsObject"/> as <see cref="Vector2"/></returns>
        public Vector2 GetAcceleration()
        {
            return this._acceleration;
        }

        /// <summary>
        /// Retrieves mass of the <see cref="PhysicsObject"/>.
        /// </summary>
        /// <returns>Mass of the <see cref="PhysicsObject"/></returns>
        public float GetMass()
        {
            return this._mass;
        }

        /// <summary>
        /// Retrieves maximum acceleration <see cref="PhysicsObject"/> can speed up.
        /// </summary>
        /// <returns>Maximum acceleration <see cref="PhysicsObject"/> can speed up</returns>
        public float GetMaximumAcceleration()
        {
            return this._maximumAcceleration;
        }

        /// <summary>
        /// Retrieves maximum velocity <see cref="PhysicsObject"/> can travel.
        /// </summary>
        /// <returns>Maximum velocity <see cref="PhysicsObject"/> can travel</returns>
        public float GetMaximumVelocity()
        {
            return this._maximumVelocity;
        }

        /// <summary>
        /// Retrieves position of <see cref="PhysicsObject"/> as <see cref="Vector2"/>.
        /// </summary>
        /// <returns>Position of <see cref="PhysicsObject"/> as <see cref="Vector2"/></returns>
        public Vector2 GetPosition()
        {
            return this._position;
        }

        /// <summary>
        /// Retrieves velocity of <see cref="PhysicsObject"/> as <see cref="Vector2"/>.
        /// </summary>
        /// <returns>Velocity of <see cref="PhysicsObject"/> as <see cref="Vector2"/></returns>
        public Vector2 GetVelocity()
        {
            return this._velocity;
        }

        /// <summary>
        /// Multiplies a <see cref="Vector2"/> with the acceleration of the <see cref="PhysicsObject"/>.
        /// </summary>
        /// <param name="acceleration"><see cref="Vector2"/> to be multiplied with acceleration</param>
        public void MultiplyAcceleration(Vector2 acceleration)
        {
            this._acceleration = Vector2.Multiply(this._acceleration, acceleration);
        }

        /// <summary>
        /// Multiplies a float with the acceleration of the <see cref="PhysicsObject"/>.
        /// </summary>
        /// <param name="acceleration">Float to be multiplied with acceleration</param>
        public void MultiplyAcceleration(float acceleration)
        {
            this._acceleration = Vector2.Multiply(this._acceleration, acceleration);
        }

        /// <summary>
        /// Multiplies a <see cref="Vector2"/> with the position of the <see cref="PhysicsObject"/>.
        /// </summary>
        /// <param name="position"><see cref="Vector2"/> to be multiplied with position</param>
        public void MultiplyPosition(Vector2 position)
        {
            this._position = Vector2.Multiply(this._position, position);
        }

        /// <summary>
        /// Multiplies a float with the position of the <see cref="PhysicsObject"/>.
        /// </summary>
        /// <param name="position">Float to be multiplied with position</param>
        public void MultiplyPosition(float position)
        {
            this._position = Vector2.Multiply(this._position, position);
        }

        /// <summary>
        /// Multiplies a <see cref="Vector2"/> with the velocity of the <see cref="PhysicsObject"/>.
        /// </summary>
        /// <param name="velocity"><see cref="Vector2"/> to be multiplied with velocity</param>
        public void MultiplyVelocity(Vector2 velocity)
        {
            this._velocity = Vector2.Multiply(this._velocity, velocity);
        }

        /// <summary>
        /// Multiplies a float with the velocity of the <see cref="PhysicsObject"/>.
        /// </summary>
        /// <param name="velocity">Float to be multiplied with velocity</param>
        public void MultiplyVelocity(float velocity)
        {
            this._velocity = Vector2.Multiply(this._velocity, velocity);
        }

        /// <summary>
        /// Sets acceleration of <see cref="PhysicsObject"/> as <see cref="Vector2"/>.
        /// </summary>
        /// <param name="acceleration">New acceleration of <see cref="PhysicsObject"/> as <see cref="Vector2"/></param>
        public void SetAcceleration(Vector2 velocity)
        {
            this._velocity = velocity;
        }

        /// <summary>
        /// Sets mass of the <see cref="PhysicsObject"/>.
        /// </summary>
        /// <param name="mass">New mass of the <see cref="PhysicsObject"/></param>
        public void SetMass(float mass)
        {
            this._mass = mass;
        }

        /// <summary>
        /// Sets maximum acceleration <see cref="PhysicsObject"/> can speed up.
        /// </summary>
        /// <param name="maximumAcceleration">New maximum acceleration <see cref="PhysicsObject"/> can speed up</param>
        public void SetMaximumAcceleration(float maximumAcceleration)
        {
            this._maximumAcceleration = maximumAcceleration;
        }

        /// <summary>
        /// Sets maximum velocity <see cref="PhysicsObject"/> can travel.
        /// </summary>
        /// <returns>New maximum velocity <see cref="PhysicsObject"/> can travel</returns>
        public void SetMaximumVelocity(float maximumVelocity)
        {
            this._maximumVelocity = maximumVelocity;
        }

        /// <summary>
        /// Sets position of <see cref="PhysicsObject"/> as <see cref="Vector2"/>.
        /// </summary>
        /// <param name="position">New position of <see cref="PhysicsObject"/> as <see cref="Vector2"/></param>
        public void SetPosition(Vector2 position)
        {
            this._position = position;
        }

        /// <summary>
        /// Sets velocity of <see cref="PhysicsObject"/> as <see cref="Vector2"/>.
        /// </summary>
        /// <param name="velocity">New velocity of <see cref="PhysicsObject"/> as <see cref="Vector2"/></param>
        public void SetVelocity(Vector2 velocity)
        {
            this._velocity = velocity;
        }

        /// <summary>
        /// Subtracts a <see cref="Vector2"/> from the acceleration of the <see cref="PhysicsObject"/>.
        /// </summary>
        /// <param name="acceleration"><see cref="Vector2"/> to be subtracted from acceleration</param>
        public void SubtractAcceleration(Vector2 acceleration)
        {
            this._acceleration = Vector2.Subtract(this._acceleration, acceleration);
        }

        /// <summary>
        /// Subtracts a <see cref="Vector2"/> from the position of the <see cref="PhysicsObject"/>.
        /// </summary>
        /// <param name="position"><see cref="Vector2"/> to be subtracted from position</param>
        public void SubtractPosition(Vector2 position)
        {
            this._position = Vector2.Subtract(this._position, position);
        }

        /// <summary>
        /// Subtracts a <see cref="Vector2"/> from the velocity of the <see cref="PhysicsObject"/>.
        /// </summary>
        /// <param name="velocity"><see cref="Vector2"/> to be subtracted from velocity</param>
        public void SubtractVelocity(Vector2 velocity)
        {
            this._velocity = Vector2.Subtract(this._velocity, velocity);
        }

        /// <summary>
        /// Updates position, velocity and acceleration of <see cref="PhysicsObject"/>.
        /// </summary>
        public void Update()
        {
            this._position = Vector2.Add(this._position, this._velocity);
            this._velocity = Vector2.Add(this._velocity, this._acceleration);
            this._acceleration = Vector2.Zero;
        }
    }
}