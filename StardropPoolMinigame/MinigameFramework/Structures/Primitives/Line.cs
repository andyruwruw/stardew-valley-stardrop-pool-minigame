using Microsoft.Xna.Framework;
using MinigameFramework.Helpers;

namespace MinigameFramework.Structures.Primitives
{
    /// <summary>
    /// Simple line class.
    /// </summary>
    /// <remarks>Not really a range...but fits with some of the logic.</remarks>
    public class Line : IRange
    {
        /// <summary>
        /// <see cref="Vector2"/> of the end of the line.
        /// </summary>
        private Vector2 _end;

        /// <summary>
        /// <see cref="Vector2"/> of the start of the line.
        /// </summary>
        private Vector2 _start;

        /// <summary>
        /// Instantiates a new line.
        /// </summary>
        /// <param name="start"><see cref="Vector2"/> of the end of the line.</param>
        /// <param name="end"><see cref="Vector2"/> of the start of the line.</param>
        public Line(
            Vector2 start,
            Vector2 end
        ) {
            _start = start;
            _end = end;
        }

        /// <summary>
        /// Instantiates a new line.
        /// </summary>
        /// <param name="startX">X value of the start of the <see cref="Line"/>.</param>
        /// <param name="startY">Y value of the start of the <see cref="Line"/>.</param>
        /// <param name="endX">X value of the end of the <see cref="Line"/>.</param>
        /// <param name="endY">Y value of the end of the <see cref="Line"/>.</param>
        public Line(
            float startX,
            float startY,
            float endX,
            float endY
        ) {
            _start = new Vector2(
                startX,
                startY
            );
            _end = new Vector2(
                endX,
                endY
            );
        }

        /// <inheritdoc cref="IRange.GetCenter"/>
        public Vector2 GetCenter()
        {
            return Vector2.Add(
                _start,
                Vector2.Multiply(
                    Vector2.Subtract(
                        _start,
                        _end
                    ),
                    0.5f
                )
            );
        }

        /// <inheritdoc cref="IRange.Contains(Vector2)"/>
        public bool Contains(Vector2 point)
        {
            return GetValue(point.X) == point.Y;
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
        /// Returns the length of the <see cref="Line"/>.
        /// </summary>
        /// <returns>Length of <see cref="Line"/>.</returns>
        public float GetLength()
        {
            return (float)DistanceHelpers.Pythagorean(
                _start,
                _end
            );
        }

        /// <summary>
        /// Sets a new length of line.
        /// </summary>
        /// <param name="length">Length of the line.</param>
        public void SetLength(float length)
        {
            _end = Vector2.Add(
                _start,
                Vector2.Multiply(
                    GetSlope(),
                    length
                )
            );
        }

        /// <summary>
        /// Gets the <see cref="Vector2"/> of the start of the line.
        /// </summary>
        /// <returns><see cref="Vector2"/> of start of line.</returns>
        public Vector2 GetStart()
        {
            return _start;
        }

        /// <summary>
        /// Sets a new start to the line.
        /// </summary>
        /// <param name="start"><see cref="Vector2"/> of start of line.</param>
        public void SetStart(Vector2 start)
        {
            _start = start;
        }

        /// <summary>
        /// Moves start but adjusts end to fit the same slope.
        /// </summary>
        /// <param name="start"><see cref="Vector2"/> of start of line.</param>
        public void TransformStart(Vector2 start)
        {
            _end = Vector2.Add(
                _start,
                GetSlope()
            );
            _start = start;
        }

        /// <summary>
        /// Gets the <see cref="Vector2"/> of the end of the line.
        /// </summary>
        /// <returns><see cref="Vector2"/> of end of line.</returns>
        public Vector2 GetEnd()
        {
            return _end;
        }

        /// <summary>
        /// Sets a new end to the line.
        /// </summary>
        /// <param name="end"><see cref="Vector2"/> of end of line.</param>
        public void SetEnd(Vector2 end)
        {
            _end = end;
        }

        /// <summary>
        /// Moves end but adjusts end to fit the same slope.
        /// </summary>
        /// <param name="end"><see cref="Vector2"/> of end of line.</param>
        public void TransformEnd(Vector2 end)
        {
            _start = Vector2.Subtract(
                _end,
                GetSlope()
            );
            _end = end;
        }

        /// <summary>
        /// Returns the slope of the <see cref="Line"/>.
        /// </summary>
        /// <returns><see cref="Vector2"/> of angle from start to end.</returns>
        public Vector2 GetSlope()
        {
            return Vector2.Subtract(
                _start,
                _end
            );
        }

        /// <summary>
        /// Returns Y value of a given X parameter given slope.
        /// </summary>
        /// <param name="x">X value to search.</param>
        /// <returns>Y value of that X.</returns>
        public float GetValue(float x)
        {
            // Following point slope form: y - y1 = m(x - x1) : y = (slopeY / slopeX) * (x - x1) - y1
            Vector2 slope = GetSlope();
            return ((slope.Y / slope.X) * (x - _start.X)) + _start.Y;
        }
    }
}
