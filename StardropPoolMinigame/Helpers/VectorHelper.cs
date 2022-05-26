using System;
using Microsoft.Xna.Framework;

namespace StardropPoolMinigame.Helpers
{
    /// <summary>
    /// <see cref="Vector2"/> math functions.
    /// </summary>
    public class VectorHelper
    {
        /// <summary>
        /// Converts degrees to radians.
        /// </summary>
        /// <param name="degrees">Degree value to convert</param>
        /// <returns>Value as radians</returns>
        public static float DegreesToRadians(float degrees)
        {
            return (float)(degrees * Math.PI / 180);
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

        /// <summary>
        /// Returns <see href="https://en.wikipedia.org/wiki/Taxicab_geometry">manhattan distance</see> between two <see cref="Vector2"/>
        /// </summary>
        /// <param name="start"><see cref="Vector2"/> of starting position</param>
        /// <param name="end"><see cref="Vector2"/> of ending position</param>
        /// <returns>Distance between two <see cref="Vector2"/></returns>
        public static double Manhattan(Vector2 point1, Vector2 point2)
        {
            return (point1.X - point2.X) + (point1.Y - point2.Y);
        }

        /// <summary>
        /// Returns <see href="https://en.wikipedia.org/wiki/Euclidean_distance">pythagorean distance</see> between two <see cref="Vector2"/>.
        /// </summary>
        /// <param name="start"><see cref="Vector2"/> of starting position</param>
        /// <param name="end"><see cref="Vector2"/> of ending position</param>
        /// <returns>Distance between two <see cref="Vector2"/></returns>
        public static double Pythagorean(Vector2 start, Vector2 end)
        {
            return Math.Sqrt(Math.Pow(start.X - end.X, 2) + Math.Pow(start.Y - end.Y, 2));
        }

        /// <summary>
        /// Converts radians to degrees.
        /// </summary>
        /// <param name="radians">Radian value to convert</param>
        /// <returns>Value as degrees</returns>
        public static float RadiansToDegrees(float radians)
        {
            return (float)(radians / Math.PI * 180);
        }

        /// <summary>
        /// Converts radians to <see cref="Vector2"/>
        /// </summary>
        /// <param name="radians">Radian value to convert</param>
        /// <returns>Value as <see cref="Vector2"/></returns>
        public static Vector2 RadiansToVector(float radians)
        {
            return new Vector2((float)Math.Cos(radians), (float)Math.Sin(radians));
        }

        /// <summary>
        /// Converts <see cref="Vector2"/> to radians.
        /// </summary>
        /// <param name="angle"><see cref="Vector2"/> value to convert</param>
        /// <returns>Value as radians</returns>
        public static float VectorToRadians(Vector2 angle)
        {
            return (float)Math.Atan2(angle.Y, angle.X);
        }
    }
}