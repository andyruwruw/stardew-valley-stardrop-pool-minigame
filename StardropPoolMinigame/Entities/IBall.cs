using Microsoft.Xna.Framework;
using StardropPoolMinigame.Attributes;
using StardropPoolMinigame.Enums;

namespace StardropPoolMinigame.Entities
{
    interface IBall
    {
        void SetVelocity(Vector2 velocity);

        Vector2 GetPosition();

        Vector2 GetVelocity();

        Vector2 GetAcceleration();

        Orientation GetOrientation();

        float GetMass();

        int GetNumber();

        BallType GetBallType();

        BallColor GetBallColor();
    }
}
