using Microsoft.Xna.Framework;
using System;

namespace StardropPoolMinigame.Helpers
{
    class Operators
    {
        public static float Modulo(float a, float b)
        {
            return (float)(a - b * Math.Floor(a / b));
        }

        public static float DegreesToRadians(float degrees)
        {
            return (float)(degrees * Math.PI / 180);
        }

        public static float VectorToRadians(Vector2 angle)
        {
            return (float)Math.Atan2(angle.Y, angle.X);
        }

        public static float RadiansToDegrees(float radians)
        {
            return (float)(radians / Math.PI * 180);
        }

        public static Vector2 RadiansToVector(float radians)
        {
            return new Vector2((float)Math.Cos(radians), (float)Math.Sin(radians));
        }
    }
}
