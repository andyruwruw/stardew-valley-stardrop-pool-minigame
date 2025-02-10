using Microsoft.Xna.Framework;
using MinigameFramework.Enums;
using MinigameFramework.Helpers;

namespace MinigameFramework.Structures.Primitives
{
    /// <summary>
    /// Simple circle class.
    /// </summary>
    public class Circle : IRange
    {
        /// <summary>
        /// <see cref="Vector2"/> of the center of the <see cref="Circle"/>.
        /// </summary>
        protected Vector2 _center;

        /// <summary>
        /// Radius of the <see cref="Circle"/>.
        /// </summary>
        protected float _radius;

        /// <summary>
        /// Instantiates a new circle range.
        /// </summary>
        /// <param name="center"><see cref="Vector2"/> of the center of the <see cref="Circle"/>.</param>
        /// <param name="radius">Radius of the <see cref="Circle"/>.</param>
        public Circle(
            Vector2 center,
            float radius
        ) {
            this._center = center;
            this._radius = radius;
        }

        /// <summary>
        /// Instantiates a new circle range.
        /// </summary>
        /// <param name="x">X value of the center of the <see cref="Circle"/></param>
        /// <param name="y">Y value of the center of the <see cref="Circle"/></param>
        /// <param name="radius">Radius of the <see cref="Circle"/>.</param>
        public Circle(
            float x,
            float y,
            float radius
        ) {
            this._center = new Vector2(
                x,
                y
            );
            this._radius = radius;
        }

        /// <inheritdoc cref="IRange.GetCenter"/>
        public Vector2 GetCenter()
        {
            return this._center;
        }

        /// <inheritdoc cref="IRange.Contains(Vector2)"/>
        public bool Contains(Vector2 point)
        {
            return DistanceHelpers.Pythagorean(
                point,
                this._center
            ) <= this._radius;
        }

        /// <inheritdoc cref="IRange.Intersects(IRange)"/>
        public bool Intersects(IRange other)
        {
            return RangeIntersection.IsIntersecting(
                this,
                other
            );
        }

        /// <summary>
        /// Sets the center of the <see cref="Circle"/>.
        /// </summary>
        /// <param name="center"><see cref="Vector2"/> of new center.</param>
        public void SetCenter(Vector2 center)
        {
            this._center = center;
        }

        /// <summary>
        /// Returns the radius of the <see cref="Circle"/>.
        /// </summary>
        /// <returns>Radius of <see cref="Circle"/>.</returns>
        public float GetRadius()
        {
            return this._radius;
        }

        /// <summary>
        /// Sets the radius of the <see cref="Circle"/>.
        /// </summary>
        /// <param name="radius">New radius.</param>
        public void SetRadius(float radius)
        {
            this._radius = radius;
        }

        /// <summary>
        /// Returns the circumference of the circle.
        /// </summary>
        public float GetCircumference()
        {
            return 2 * (float)Math.PI * this._radius;
        }

        /// <summary>
        /// Returns the area of the circle.
        /// </summary>
        public float GetArea()
        {
            return (float)(Math.PI * Math.Pow(this._radius, 2));
        }

        /// <summary>
        /// Retrieves a point in a given direction.
        /// </summary>
        /// <param name="direction">Normalized direction vector.</param>
        /// <returns><see cref="Vector2"/> on circle in the given direction.</returns>
        public Vector2 GetPointByDirection(Vector2 direction)
        {
            Vector2 normalized = new Vector2(
                direction.X,
                direction.Y
            );

            if (normalized.Length() != 1)
            {
                normalized.Normalize();
            }

            return Vector2.Add(
                this._center,
                Vector2.Multiply(
                    normalized,
                    this._radius
                )
            );
        }

        /// <summary>
        /// Retrieves a point in a given direction.
        /// </summary>
        /// <param name="direction">Direction enum.</param>
        /// <returns><see cref="Vector2"/> on circle in the given direction.</returns>
        public Vector2 GetPointByDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.NorthEast:
                    return this.GetPointByDirection(new Vector2(
                        1,
                        -1
                    ));
                case Direction.East:
                    return this.GetPointByDirection(new Vector2(
                        1,
                        0
                    ));
                case Direction.SouthEast:
                    return this.GetPointByDirection(new Vector2(
                        1,
                        1
                    ));
                case Direction.South:
                    return this.GetPointByDirection(new Vector2(
                        0,
                        1
                    ));
                case Direction.SouthWest:
                    return this.GetPointByDirection(new Vector2(
                        -1,
                        1
                    ));
                case Direction.West:
                    return this.GetPointByDirection(new Vector2(
                        -1,
                        0
                    ));
                case Direction.NorthWest:
                    return this.GetPointByDirection(new Vector2(
                        -1,
                        -1
                    ));
                case Direction.North:
                default:
                    return this.GetPointByDirection(new Vector2(
                        0,
                        -1
                    ));
            }
        }
    }
}
