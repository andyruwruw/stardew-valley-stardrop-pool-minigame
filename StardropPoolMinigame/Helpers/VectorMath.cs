using Microsoft.Xna.Framework;
using System;

namespace StardropPoolMinigame
{
    class VectorMath
    {
        public static Vector2 VectorBetweenTwoPoints(Vector2 a, Vector2 b)
        {
            return Vector2.Subtract(b, a);
        }

        public static float VectorToRadians(Vector2 vector)
        {
            return (float)Math.Atan2(vector.Y, vector.X);
        }

        /// <summary>
        /// Returns a modulo b
        /// </summary>
        /// 
        /// <param name="a">Number to modulo</param>
        /// <param name="b">Modulo base</param>
        /// <returns>a % b</returns>
        public static double Modulo(double a, double b)
        {
            return a - b * Math.Floor(a / b);
        }

        /// <summary>
        /// Finds distance from a line made from two <see cref="Vector2"/> to a point (<see cref="Vector2"/>)
        /// </summary>
        /// <remarks>
        /// <see href="https://en.wikipedia.org/wiki/Distance_from_a_point_to_a_line">See here for equation</see>
        /// </remarks>
        /// 
        /// <param name="linePoint1">First point on the line</param>
        /// <param name="linePoint2">Second point on the line</param>
        /// <param name="point">Point in question</param>
        /// <returns>Distance from point to line</returns>
        public static double DistanceToLine(Vector2 linePoint1, Vector2 linePoint2, Vector2 point)
        {
            double m = ((linePoint2.Y - linePoint1.Y) / (linePoint2.X - linePoint1.X));

            double a = m;
            double b = -1;
            double c = (m * -1 * linePoint1.X) + linePoint1.Y;

            return ((Math.Abs(a * point.X + b * point.Y + c)) / (Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2))));
        }
    }
}
