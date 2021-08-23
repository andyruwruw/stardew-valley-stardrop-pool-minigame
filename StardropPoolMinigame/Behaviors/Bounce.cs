using Microsoft.Xna.Framework;
using StardewValley;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using System;

namespace StardropPoolMinigame.Geometry
{
    class Bounce
    {
        private Ball _ball1;

        private Ball _ball2;

        public Bounce(Ball ball1, Ball ball2)
        {
            this._ball1 = ball1;
            this._ball2 = ball2;

            this.PlaySound();

            Vector2 angle = this.GetAngleBetween();

            Tuple<float, float> collisionForces = this.GetCollisonForce(angle);
            float momentum = this.GetMomentum(collisionForces.Item1, collisionForces.Item2);
            Tuple<Vector2, Vector2> resultingVelocities = this.GetResultingVelocity(angle, momentum);

            this._ball1.SetVelocity(resultingVelocities.Item1);
            this._ball2.SetVelocity(resultingVelocities.Item2);
        }

        private Vector2 GetAngleBetween()
        {
            Vector2 angle = Vector2.Subtract(this._ball1.GetPosition(), this._ball2.GetPosition());
            angle.Normalize();

            return angle;
        }

        private Tuple<float, float> GetCollisonForce(Vector2 angle)
        {
            float ball1CollisionForce = Vector2.Dot(this._ball1.GetVelocity(), angle);
            float ball2CollisionForce = Vector2.Dot(this._ball2.GetVelocity(), angle);

            return new Tuple<float, float>(ball1CollisionForce, ball2CollisionForce);
        }

        private float GetMomentum(float ball1CollisionForce, float ball2CollisionForce)
        {
            return ((float)2.0 * (ball1CollisionForce - ball2CollisionForce)) / (this._ball1.GetMass() + this._ball2.GetMass());
        }

        private Tuple<Vector2, Vector2> GetResultingVelocity(Vector2 angle, float momentum)
        {
            Vector2 ball1ResultingVelocity = Vector2.Subtract(
                this._ball1.GetVelocity(),
                Vector2.Multiply(
                    angle, 
                    new Vector2(
                        (float)momentum * (this._ball2.GetMass() * GameConstants.BALL_TO_BALL_BOUNCE_MOMENTUM_LOSS_MULTIPLIER),
                        (float)momentum * (this._ball2.GetMass() * GameConstants.BALL_TO_BALL_BOUNCE_MOMENTUM_LOSS_MULTIPLIER))));
            Vector2 ball2ResultingVelocity = Vector2.Add(
                this._ball2.GetVelocity(),
                Vector2.Multiply(
                    angle,
                    new Vector2(
                        (float)momentum * (this._ball1.GetMass() * GameConstants.BALL_TO_BALL_BOUNCE_MOMENTUM_LOSS_MULTIPLIER),
                        (float)momentum * (this._ball1.GetMass() * GameConstants.BALL_TO_BALL_BOUNCE_MOMENTUM_LOSS_MULTIPLIER)))); ;
            
            return new Tuple<Vector2, Vector2>(ball1ResultingVelocity, ball2ResultingVelocity);
        }

        private void PlaySound()
        {
            Game1.playSound(SoundConstants.BALLS_COLLIDING);
        }
    }
}
