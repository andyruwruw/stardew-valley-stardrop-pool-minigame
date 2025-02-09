using Microsoft.Xna.Framework;

namespace MinigameFramework.Helpers
{
    /// <summary>
    /// Various distance formulas.
    /// </summary>
    static class DistanceHelpers
    {
        /// <summary>
        /// Returns <see href="https://en.wikipedia.org/wiki/Taxicab_geometry">manhattan distance</see> between two <see cref="Vector2"/>
        /// </summary>
        /// <param name="startX">X of starting position</param>
        /// <param name="startY">Y of starting position</param>
        /// <param name="endX">X of ending position</param>
        /// <param name="endY">Y of ending position</param>
        /// <returns>Distance between two <see cref="Vector2"/></returns>
        public static double Manhattan(
            float startX,
            float startY,
            float endX,
            float endY
        )
        {
            return (startX - endX) + (startY - endY);
        }

        /// <summary>
        /// Returns <see href="https://en.wikipedia.org/wiki/Taxicab_geometry">manhattan distance</see> between two <see cref="Vector2"/>
        /// </summary>
        /// <param name="startX">X of starting position</param>
        /// <param name="startY">Y of starting position</param>
        /// <param name="endX">X of ending position</param>
        /// <param name="endY">Y of ending position</param>
        /// <returns>Distance between two <see cref="Vector2"/></returns>
        public static double Manhattan(
            int startX,
            int startY,
            int endX,
            int endY
        )
        {
            return DistanceHelpers.Manhattan(
                (float)startX,
                (float)startY,
                (float)endX,
                (float)endY
            );
        }

        /// <summary>
        /// Returns <see href="https://en.wikipedia.org/wiki/Taxicab_geometry">manhattan distance</see> between two <see cref="Vector2"/>
        /// </summary>
        /// <param name="start"><see cref="Vector2"/> of starting position</param>
        /// <param name="end"><see cref="Vector2"/> of ending position</param>
        /// <returns>Distance between two <see cref="Vector2"/></returns>
        public static double Manhattan(
            Vector2 start,
            Vector2 end
        )
        {
            return DistanceHelpers.Manhattan(
                start.X,
                start.Y,
                end.X,
                end.Y
            );
        }

        /// <summary>
        /// Returns <see href="https://en.wikipedia.org/wiki/Euclidean_distance">pythagorean distance</see> between two <see cref="Vector2"/>.
        /// </summary>
        /// <param name="startX">X of starting position</param>
        /// <param name="startY">Y of starting position</param>
        /// <param name="endX">X of ending position</param>
        /// <param name="endY">Y of ending position</param>
        /// <returns>Distance between two <see cref="Vector2"/></returns>
        public static double Pythagorean(
            float startX,
            float startY,
            float endX,
            float endY
        )
        {
            return Math.Sqrt(
                Math.Pow(
                    startX - endX,
                    2
                ) + Math.Pow(
                    startY - endY,
                    2
                )
            );
        }

        /// <summary>
        /// Returns <see href="https://en.wikipedia.org/wiki/Euclidean_distance">pythagorean distance</see> between two <see cref="Vector2"/>.
        /// </summary>
        /// <param name="startX">X of starting position</param>
        /// <param name="startY">Y of starting position</param>
        /// <param name="endX">X of ending position</param>
        /// <param name="endY">Y of ending position</param>
        /// <returns>Distance between two <see cref="Vector2"/></returns>
        public static double Pythagorean(
            int startX,
            int startY,
            int endX,
            int endY
        )
        {
            return DistanceHelpers.Pythagorean(
                (float)startX,
                (float)startY,
                (float)endX,
                (float)endY
            );
        }

        /// <summary>
        /// Returns <see href="https://en.wikipedia.org/wiki/Euclidean_distance">pythagorean distance</see> between two <see cref="Vector2"/>.
        /// </summary>
        /// <param name="start"><see cref="Vector2"/> of starting position</param>
        /// <param name="end"><see cref="Vector2"/> of ending position</param>
        /// <returns>Distance between two <see cref="Vector2"/></returns>
        public static double Pythagorean(
            Vector2 start,
            Vector2 end
        )
        {
            return DistanceHelpers.Pythagorean(
                start.X,
                start.Y,
                end.X,
                end.Y
            );
        }
    }
}
