using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;

namespace StardropPoolMinigame.Behaviors.Physics
{
    class RealPhysics
    {
        public static void Bounce(Ball ball1, Ball ball2)
        {
            Vector2 angle = Vector2.Subtract(ball1.GetAnchor(), ball2.GetPosition());
            angle = Vector2.Normalize(angle);

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

        private static float GetMomentum(Ball ball1, Ball ball2, float ball1CollisionForce, float ball2CollisionForce)
        {
            return ((float)2.0 * (ball1CollisionForce - ball2CollisionForce)) / (ball1.GetMass() + ball2.GetMass());
        }
    }
}
