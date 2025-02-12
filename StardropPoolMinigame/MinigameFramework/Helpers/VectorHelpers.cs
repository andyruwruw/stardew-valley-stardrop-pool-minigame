using Microsoft.Xna.Framework;

namespace MinigameFramework.Helpers
{
    /// <summary>
    /// Various vector math.
    /// </summary>
    static class VectorHelpers
    {
        /// <summary>
        /// Returns the magnitude of a <see cref="Vector"/>
        /// </summary>
        /// <param name="vector"><see cref="Vector2"/> in question</param>
        /// <returns>Magnitude of <see cref="Vector2"/></returns>
        public static float GetMagnitude(Vector2 vector)
        {
            return (float)Math.Sqrt(Math.Pow(
                    vector.X,
                    2
                ) + Math.Pow(
                    vector.Y,
                    2
                )
            );
        }

        /// <summary>
        /// Converts <see cref="Vector2"/> to radians.
        /// </summary>
        /// <param name="angle"><see cref="Vector2"/> value to convert</param>
        /// <returns>Value as radians</returns>
        public static float VectorToRadians(Vector2 angle)
        {
            return (float)Math.Atan2(
                angle.Y,
                angle.X
            );
        }

        /// <summary>
        /// Converts radians to <see cref="Vector2"/>
        /// </summary>
        /// <param name="radians">Radian value to convert</param>
        /// <returns>Value as <see cref="Vector2"/></returns>
        public static Vector2 RadiansToVector(float radians)
        {
            return new Vector2(
                (float)Math.Cos(radians),
                (float)Math.Sin(radians)
            );
        }

        /// <summary>
        /// Pulls a position towards a location based on progress.
        /// </summary>
        /// <param name="position">Original position.</param>
        /// <param name="destination">Desired destination.</param>
        /// <param name="progress">Progress to destination.</param>
        public static Vector2 PullVector(
            Vector2 position,
            Vector2 destination,
            float progress
        ) {
            return Vector2.Add(
                position,
                Vector2.Multiply(
                    Vector2.Subtract(
                        destination,
                        position
                    ),
                    progress
                )
            );
        }
    }
}
