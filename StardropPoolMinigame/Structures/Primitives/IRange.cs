using Microsoft.Xna.Framework;

namespace StardropPoolMinigame.Primitives
{
    internal interface IRange
    {
        /// <summary>
        /// Whether a point lies within the <see cref="IRange"/>
        /// </summary>
        /// <param name="point"><see cref="Vector2"/> of the point to check</param>
        /// <returns>Whether the point is inside <see cref="IRange"/></returns>
        bool Contains(Vector2 point);

        /// <summary>
        /// Returns the <see cref="Vector2"/> of the center of the <see cref="IRange"/>
        /// </summary>
        /// <returns>Center of <see cref="IRange"/></returns>
        Vector2 GetCenter();

        /// <summary>
        /// Whether a range intersects with the <see cref="IRange"/>
        /// </summary>
        /// <param name="other"><see cref="IRange"/> to check</param>
        /// <returns>Whether the <see cref="IRange"/> intersects with this <see cref="IRange"/></returns>
        bool Intersects(IRange other);
    }
}