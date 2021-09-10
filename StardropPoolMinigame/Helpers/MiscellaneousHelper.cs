using System;

namespace StardropPoolMinigame.Helpers
{
    /// <summary>
    /// Miscellaneous helper functions.
    /// </summary>
    class MiscellaneousHelper
    {
        /// <summary>
        /// Custom implementation of modulo to account for negative values.
        /// </summary>
        /// <param name="a">First value</param>
        /// <param name="b">Second value</param>
        /// <returns><c>a % b</c> result</returns>
        public static float Modulo(float a, float b)
        {
            return (float)(a - b * Math.Floor(a / b));
        }

        /// <summary>
        /// Random float between <c>0</c> and <c>1</c>.
        /// </summary>
        /// <returns>Random float</returns>
        public static float Random()
        {
            return (float)(new System.Random()).NextDouble();
        }
    }
}
