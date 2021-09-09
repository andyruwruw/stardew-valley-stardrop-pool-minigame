using System;
using Microsoft.Xna.Framework;

namespace StardropPoolMinigame.Helpers
{
    /// <summary>
    /// Vector math functions
    /// </summary>
    public class VectorHelper
    {
        /// <summary>
        /// Returns pythagorean distance between two <see cref="Vector2"/>
        /// </summary>
        /// <param name="start"><see cref="Vector2"/> of starting position</param>
        /// <param name="end"><see cref="Vector2"/> of ending position</param>
        /// <returns>Distance between two <see cref="Vector2"/></returns>
        public static double Pythagorean(Vector2 start, Vector2 end)
        {
            return Math.Sqrt(Math.Pow(start.X - end.X, 2) + Math.Pow(start.Y - end.Y, 2));
        }

        /// <summary>
        /// Returns manhattan distance between two <see cref="Vector2"/>
        /// </summary>
        /// <param name="start"><see cref="Vector2"/> of starting position</param>
        /// <param name="end"><see cref="Vector2"/> of ending position</param>
        /// <returns>Distance between two <see cref="Vector2"/></returns>
        public static double Manhattan(Vector2 point1, Vector2 point2)
        {
            return (point1.X - point2.X) + (point1.Y - point2.Y);
        }

        /// <summary>
        /// Returns the magnitude of a <see cref="Vector"/>
        /// </summary>
        /// <param name="vector"><see cref="Vector2"/> in question</param>
        /// <returns>Magnitude of <see cref="Vector2"/></returns>
        public static float GetMagnitude(Vector2 vector)
        {
            return (float)(Math.Sqrt(Math.Pow(vector.X, 2) + Math.Pow(vector.Y, 2)));
        }
    }
}
