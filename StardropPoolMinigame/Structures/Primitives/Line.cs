using Microsoft.Xna.Framework;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Primitives.Helpers;
using System;

namespace StardropPoolMinigame.Primitives
{
    /// <summary>
    /// Simple line class
    /// </summary>
    internal class Line : IRange
    {
        /// <summary>
        /// <see cref="Vector2"/> of the end of the line
        /// </summary>
        private Vector2 _end;

        /// <summary>
        /// <see cref="Vector2"/> of the start of the line
        /// </summary>
        private Vector2 _start;

        public Line(Vector2 start, Vector2 end)
        {
            this._start = start;
            this._end = end;
        }

        /// <inheritdoc cref="IRange.Contains(Vector2)"/>
        public bool Contains(Vector2 point)
        {
            return true;
        }

        /// <inheritdoc cref="IRange.GetCenter"/>
        public Vector2 GetCenter()
        {
            return Vector2.Add(this._start, Vector2.Multiply(Vector2.Subtract(this._start, this._end), 0.5f));
        }

        /// <summary>
        /// Gets the <see cref="Vector2"/> of the end of the line
        /// </summary>
        /// <returns><see cref="Vector2"/> of end of line</returns>
        public Vector2 GetEnd()
        {
            return this._end;
        }

        /// <summary>
        /// Returns the length of the <see cref="Line"/>
        /// </summary>
        /// <returns>Length of <see cref="Line"/></returns>
        public float GetLength()
        {
            return (float)VectorHelper.Pythagorean(this._start, this._end);
        }

        /// <summary>
        /// Returns the slope of the <see cref="Line"/>
        /// </summary>
        /// <returns><see cref="Vector2"/> of angle from start to end</returns>
        public Vector2 GetSlope()
        {
            return Vector2.Subtract(this._start, this._end);
        }

        /// <summary>
        /// Gets the <see cref="Vector2"/> of the start of the line
        /// </summary>
        /// <returns><see cref="Vector2"/> of start of line</returns>
        public Vector2 GetStart()
        {
            return this._start;
        }

        /// <inheritdoc cref="IRange.Intersects(IRange)"/>
        public bool Intersects(IRange other)
        {
            return IntersectionHelper.IsIntersecting(this, other);
        }
    }
}