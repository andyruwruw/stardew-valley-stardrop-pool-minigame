using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Primitives;
using System;

namespace StardropPoolMinigame.Behaviors.Physics
{
    /// <summary>
    /// Resembles real life physics
    /// </summary>
    class RealPhysics
    {
        /// <summary>
        /// Bounces two balls together
        /// </summary>
        /// <param name="ball1">First ball to be bounced</param>
        /// <param name="ball2">Second ball to be bounced</param>
        /// <param name="offsetOnly">Does not alter velocity, but offsets balls to not overlap</param>
        public static void Bounce(Ball ball1, Ball ball2, bool offsetOnly = false)
        {
            Vector2 angle = Vector2.Subtract(ball1.GetAnchor(), ball2.GetPosition());
            angle = Vector2.Normalize(angle);

            if (!offsetOnly)
            {
                float ball1CollisionForce = Vector2.Dot(ball1.GetVelocity(), angle);
                float ball2CollisionForce = Vector2.Dot(ball2.GetVelocity(), angle);

                float momentum = GetMomentum(ball1, ball2, ball1CollisionForce, ball2CollisionForce);

                Vector2 ball1ResultingVelocity = Vector2.Subtract(
                    ball1.GetVelocity(),
                    Vector2.Multiply(
                        angle,
                        new Vector2(
                            (float)momentum * (ball2.GetMass()),
                            (float)momentum * (ball2.GetMass()))));
                Vector2 ball2ResultingVelocity = Vector2.Add(
                    ball2.GetVelocity(),
                    Vector2.Multiply(
                        angle,
                        new Vector2(
                            (float)momentum * (ball1.GetMass()),
                            (float)momentum * (ball1.GetMass()))));

                ball1.SetVelocity(ball1ResultingVelocity);
                ball2.SetVelocity(ball2ResultingVelocity);
            }

            // Stop touching
            float overlapping = (float)(Distance.Pythagorean(ball1.GetAnchor(), ball2.GetAnchor()) - GameConstants.Ball.RADIUS * 2);

            ball1.SetAnchor(Vector2.Add(ball1.GetAnchor(), Vector2.Multiply(Vector2.Negate(angle), overlapping / 1.9f)));
            ball2.SetAnchor(Vector2.Add(ball2.GetAnchor(), Vector2.Multiply(angle, overlapping / 1.9f)));
        }

        /// <summary>
        /// Bounces ball off a wall
        /// </summary>
        /// <remarks>
        /// Sourced from https://www.mathsisfun.com/algebra/vectors-dot-product.html
        /// </remarks>
        /// <param name="ball">Ball to be bounced</param>
        /// <param name="bounceableSurface">Bounceable surface as line</param>
        public static void Bounce(Ball ball, Line bounceableSurface)
        {
            float length = bounceableSurface.GetLength();
            float dotProduct = (float)((((ball.GetAnchor().X - bounceableSurface.GetStart().X) * (bounceableSurface.GetEnd().X - bounceableSurface.GetStart().X)) + ((ball.GetAnchor().Y - bounceableSurface.GetStart().Y) * (bounceableSurface.GetEnd().Y - bounceableSurface.GetStart().Y))) / Math.Pow(length, 2));

            Vector2 closestPoint = new Vector2(
                bounceableSurface.GetStart().X + (dotProduct * (bounceableSurface.GetEnd().X - bounceableSurface.GetStart().X)),
                bounceableSurface.GetStart().Y + (dotProduct * (bounceableSurface.GetEnd().Y - bounceableSurface.GetStart().Y)));

            Vector2 collisionNormal = Vector2.Normalize(Vector2.Subtract(closestPoint, ball.GetAnchor()));
            Vector2 reflectedVelocity = Vector2.Reflect(ball.GetVelocity(), collisionNormal);
            
            ball.SetVelocity(reflectedVelocity);

            float overlapping = (float)(Distance.Pythagorean(ball.GetAnchor(), closestPoint) - GameConstants.Ball.RADIUS);

            ball.SetAnchor(Vector2.Add(ball.GetAnchor(), Vector2.Multiply(collisionNormal, overlapping / 1.9f)));
        }

        /// <summary>
        /// Calculates conservation of momentum
        /// </summary>
        /// <param name="ball1">First ball in collision</param>
        /// <param name="ball2"></param>
        /// <param name="ball1CollisionForce"></param>
        /// <param name="ball2CollisionForce"></param>
        /// <returns></returns>
        private static float GetMomentum(Ball ball1, Ball ball2, float ball1CollisionForce, float ball2CollisionForce)
        {
            return ((float)2.0 * (ball1CollisionForce - ball2CollisionForce)) / (ball1.GetMass() + ball2.GetMass());
        }
    }
}
