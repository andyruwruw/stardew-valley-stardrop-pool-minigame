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
    }
}
