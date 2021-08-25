using System;

namespace StardropPoolMinigame.Helpers
{
    class Random
    {
        public static System.Random RANDOM = new System.Random();

        public static float Fraction()
        {
            return (float)RANDOM.NextDouble();
        }
    }
}
