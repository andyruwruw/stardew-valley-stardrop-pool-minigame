using Microsoft.Xna.Framework;

namespace StardropPoolMinigame.Behaviors
{
    /// <summary>
    /// Maintains position, velocity and acceleration of an object.
    /// </summary>
    class PhysicsObject
    {
        private Vector2 _position;

        private Vector2 _velocity;

        private Vector2 _acceleration;

        public PhysicsObject(
            Vector2 position,
            Vector2 velocity,
            Vector2 acceleration)
        {
            this._position = position;
            this._velocity = velocity;
            this._acceleration = acceleration;
        }

        public PhysicsObject(
            Vector2 position,
            Vector2 velocity)
        {
            this._position = position;
            this._velocity = velocity;
            this._acceleration = Vector2.Zero;
        }

        public PhysicsObject(Vector2 position)
        {
            this._position = position;
            this._velocity = Vector2.Zero;
            this._acceleration = Vector2.Zero;
        }

        public void Update()
        {
            this._position = Vector2.Add(this._position, this._velocity);
            this._velocity = Vector2.Add(this._velocity, this._acceleration);
            this._acceleration = Vector2.Zero;
        }

        public Vector2 GetPosition()
        {
            return this._position;
        }

        public void SetPosition(Vector2 position)
        {
            this._position = position;
        }

        public void AddPosition(Vector2 position)
        {
            this._position = Vector2.Add(this._position, position);
        }

        public void SubtractPosition(Vector2 position)
        {
            this._position = Vector2.Subtract(this._position, position);
        }

        public void MultiplyPosition(Vector2 position)
        {
            this._position = Vector2.Multiply(this._position, position);
        }

        public void DividePosition(Vector2 position)
        {
            this._position = Vector2.Divide(this._position, position);
        }

        public Vector2 GetVelocity()
        {
            return this._velocity;
        }

        public void SetVelocity(Vector2 velocity)
        {
            this._velocity = velocity;
        }

        public void AddVelocity(Vector2 velocity)
        {
            this._velocity = Vector2.Add(this._velocity, velocity);
        }

        public void SubtractVelocity(Vector2 velocity)
        {
            this._velocity = Vector2.Subtract(this._velocity, velocity);
        }

        public void MultiplyVelocity(Vector2 velocity)
        {
            this._velocity = Vector2.Multiply(this._velocity, velocity);
        }

        public void DivideVelocity(Vector2 velocity)
        {
            this._velocity = Vector2.Divide(this._velocity, velocity);
        }

        public Vector2 GetAcceleration()
        {
            return this._acceleration;
        }

        public void SetAcceleration(Vector2 velocity)
        {
            this._velocity = velocity;
        }

        public void AddAcceleration(Vector2 acceleration)
        {
            this._acceleration = Vector2.Add(this._acceleration, acceleration);
        }

        public void SubtractAcceleration(Vector2 acceleration)
        {
            this._acceleration = Vector2.Subtract(this._acceleration, acceleration);
        }

        public void MultiplyAcceleration(Vector2 acceleration)
        {
            this._acceleration = Vector2.Multiply(this._acceleration, acceleration);
        }

        public void DivideAcceleration(Vector2 acceleration)
        {
            this._acceleration = Vector2.Divide(this._acceleration, acceleration);
        }
    }
}
