using Microsoft.Xna.Framework;
using StardropPoolMinigame.Helpers;

namespace StardropPoolMinigame.Primitives
{
    /// <summary>
    /// Simple circle class
    /// </summary>
    class Circle : IRange
    {
        /// <summary>
        /// <see cref="Vector2"/> of the center of the <see cref="Circle"/>
        /// </summary>
        protected Vector2 _center;

        /// <summary>
        /// Radius of the <see cref="Circle"/>
        /// </summary>
        protected float _radius;

        public Circle(Vector2 center, float radius)
        {
            this._center = center;
            this._radius = radius;
        }

        /// <summary>
        /// Whether a point lies within the <see cref="IRange"/>
        /// </summary>
        /// <param name="point"><see cref="Vector2"/> of the point to check</param>
        /// <returns>Whether the point is inside <see cref="IRange"/></returns>
        public bool Contains(Vector2 point)
        {
            return DistanceHelper.Pythagorean(point, this._center) <= this._radius;
        }

        /// <summary>
        /// Whether a range intersects with the <see cref="IRange"/>
        /// </summary>
        /// <param name="other"><see cref="IRange"/> to check</param>
        /// <returns>Whether the <see cref="IRange"/> intersects with this <see cref="IRange"/></returns>
        public bool Intersects(IRange other)
        {
            return true;
        }

        /// <summary>
        /// Returns the <see cref="Vector2"/> of the center of the <see cref="IRange"/>
        /// </summary>
        /// <returns>Center of <see cref="IRange"/></returns>
        public Vector2 GetCenter()
        {
            return this._center;
        }

        /// <summary>
        /// Sets the center of the <see cref="Circle"/>
        /// </summary>
        /// <param name="center"><see cref="Vector2"/> of new center</param>
        public void SetCenter(Vector2 center)
        {
            this._center = center;
        }

        /// <summary>
        /// Returns the radius of the <see cref="Circle"/>
        /// </summary>
        /// <returns>Radius of <see cref="Circle"/></returns>
        public float GetRadius()
        {
            return this._radius;
        }

        /// <summary>
        /// Sets the radius of the <see cref="Circle"/>
        /// </summary>
        /// <param name="radius">New radius</param>
        public void SetRadius(float radius)
        {
            this._radius = radius;
        }
    }
}
