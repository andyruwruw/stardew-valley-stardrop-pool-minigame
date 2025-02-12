using Microsoft.Xna.Framework;
using MinigameFramework.Helpers;

namespace MinigameFramework.Structures.Primitives
{
    /// <summary>
    /// Simple rectangle class.
    /// </summary>
    /// <remarks>It should be noted that this rectangle class inverts the Y-axis, meaning higher Y values are associated with being lower on the screen.</remarks>
    public class Rectangle : IRange
    {
        /// <summary>
        /// <see cref="Vector2"/> of top left of the <see cref="Rectangle"/>.
        /// </summary>
        private Vector2 _anchor;

        /// <summary>
        /// Height of the rectangle.
        /// </summary>
        private float _height;

        /// <summary>
        /// Width of the rectangle.
        /// </summary>
        private float _width;

        /// <summary>
        /// Instantiates a rectangle around a given anchor.
        /// </summary>
        /// <param name="anchor"><see cref="Vector2"/> of top left of the <see cref="Rectangle"/>.</param>
        /// <param name="width">Width of the rectangle.</param>
        /// <param name="height">Height of the rectangle.</param>
        public Rectangle(
            Vector2 anchor,
            float width,
            float height
        ) {
            _anchor = anchor;
            _width = width;
            _height = height;
        }

        /// <summary>
        /// Instantiates a rectangle around a given anchor.
        /// </summary>
        /// <param name="x">X value of the top left of the rectangle.</param>
        /// <param name="y">Y value of the top left of the rectangle.</param>
        /// <param name="width">Width of the rectangle.</param>
        /// <param name="height">Height of the rectangle.</param>
        public Rectangle(
            float x,
            float y,
            float width,
            float height
        ) {
            _anchor = new Vector2(
                x,
                y
            );
            _width = width;
            _height = height;
        }

        /// <summary>
        /// Instantiates a rectangle around a given anchor.
        /// </summary>
        /// <param name="anchor"><see cref="Vector2"/> of top left of the <see cref="Rectangle"/>.</param>
        /// <param name="anchor">Corner opposite to the anchor.</param>
        public Rectangle(
            Vector2 anchor,
            Vector2 oppositeCorner
        )
        {
            _anchor = anchor;
            _width = oppositeCorner.X - anchor.X;
            _height = oppositeCorner.Y - anchor.Y;
        }

        /// <summary>
        /// Instantiates a rectangle based on an XNA Rectangle.
        /// </summary>
        /// <param name="rectangle">XNA <see cref="Microsoft.Xna.Framework.Rectangle"/>.</param>
        public Rectangle(Microsoft.Xna.Framework.Rectangle rectangle)
        {
            _anchor = new Vector2(
                rectangle.X,
                rectangle.Y
            );
            _width = rectangle.Width;
            _height = rectangle.Height;
        }

        /// <inheritdoc cref="IRange.GetCenter(IRange)"/>
        public Vector2 GetCenter()
        {
            return new Vector2(
                GetCenterX(),
                GetCenterY()
            );
        }

        /// <inheritdoc cref="IRange.Contains(Vector2)"/>
        public bool Contains(Vector2 point)
        {
            return (point.X >= GetWestX() &&
                point.X <= GetEastX() &&
                point.Y <= GetSouthY() &&
                point.Y >= GetNorthY());
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
        /// <see cref="Vector2"/> of top-left of the <see cref="Rectangle"/>
        /// </summary>
        /// <returns>Top-left of <see cref="Rectangle"/></returns>
        public Vector2 GetAnchor()
        {
            return _anchor;
        }

        /// <summary>
        /// Sets a new anchor for the rectangle.
        /// </summary>
        /// <param name="anchor">New top-left point of the rectangle.</param>
        public void SetAnchor(Vector2 anchor)
        {
            _width = _width + (anchor.X - _anchor.X);
            _height = _height + (anchor.Y - _anchor.Y);

            _anchor = anchor;
        }

        /// <summary>
        /// Sets a new anchor, allowing other parameters to change to remain the same shape.
        /// </summary>
        /// <param name="anchor">New top-left point of the rectangle.</param>
        public void TransformAnchor(Vector2 anchor)
        {
            _anchor = anchor;
        }

        /// <summary>
        /// Gets the height of the <see cref="Rectangle"/>
        /// </summary>
        /// <returns>Height of <see cref="Rectangle"/></returns>
        public float GetHeight()
        {
            return _height;
        }

        /// <summary>
        /// Sets a new height for the rectangle.
        /// </summary>
        /// <param name="height">New height.</param>
        public void SetHeight(float height)
        {
            _height = height;
        }

        /// <summary>
        /// Gets half the height of the <see cref="Rectangle"/>
        /// </summary>
        /// <returns>Half the height</returns>
        public float GetHalfHeight()
        {
            return _height / 2;
        }

        /// <summary>
        /// Gets the width of the <see cref="Rectangle"/>
        /// </summary>
        /// <returns>Width of <see cref="Rectangle"/></returns>
        public float GetWidth()
        {
            return _width;
        }

        /// <summary>
        /// Sets a new width for the rectangle.
        /// </summary>
        /// <param name="width">New width.</param>
        public void SetWidth(float width)
        {
            _width = width;
        }

        /// <summary>
        /// Gets half the width of the <see cref="Rectangle"/>
        /// </summary>
        /// <returns>Half the width</returns>
        public float GetHalfWidth()
        {
            return _width / 2;
        }

        /// <summary>
        /// Gets the center X value of the <see cref="Rectangle"/>
        /// </summary>
        /// <returns>Center X value></returns>
        public float GetCenterX()
        {
            return _anchor.X + GetHalfWidth();
        }

        /// <summary>
        /// Gets the center Y value of the <see cref="Rectangle"/>
        /// </summary>
        /// <returns>Center Y value></returns>
        public float GetCenterY()
        {
            return _anchor.Y + GetHalfHeight();
        }

        /// <summary>
        /// Gets the right-most X value of the <see cref="Rectangle"/>
        /// </summary>
        /// <returns>Right-most X value></returns>
        public float GetEastX()
        {
            return _anchor.X + _width;
        }

        /// <summary>
        /// <see cref="Vector2"/> of top-right of the <see cref="Rectangle"/>
        /// </summary>
        /// <returns>Top-right of <see cref="Rectangle"/></returns>
        public Vector2 GetNorthEastCorner()
        {
            return new Vector2(
                GetEastX(),
                _anchor.Y
            );
        }

        /// <summary>
        /// Gets <see cref="Rectangle"/> of the top-right quadrant
        /// </summary>
        /// <returns>Top-right quadrant as <see cref="Rectangle"/></returns>
        public Rectangle GetNorthEastQuadrant()
        {
            Vector2 newAnchor = new Vector2(
                GetCenterX(),
                _anchor.Y
            );

            return new Rectangle(
                newAnchor,
                GetHalfWidth(),
                GetHalfHeight()
            );
        }

        /// <summary>
        /// <see cref="Vector2"/> of top-left of the <see cref="Rectangle"/>
        /// </summary>
        /// <returns>Top-left of <see cref="Rectangle"/></returns>
        public Vector2 GetNorthWestCorner()
        {
            return _anchor;
        }

        /// <summary>
        /// Gets <see cref="Rectangle"/> of the top-left quadrant
        /// </summary>
        /// <returns>Top-left quadrant as <see cref="Rectangle"/></returns>
        public Rectangle GetNorthWestQuadrant()
        {
            return new Rectangle(
                _anchor,
                GetHalfWidth(),
                GetHalfHeight()
            );
        }

        /// <summary>
        /// Gets the top Y value of the <see cref="Rectangle"/>
        /// </summary>
        /// <returns>Top Y value></returns>
        public float GetNorthY()
        {
            return _anchor.Y;
        }

        /// <summary>
        /// Returns XNA <see cref="Microsoft.Xna.Framework.Rectangle"/> equivolent of <see cref="Rectangle"/> readjusted to viewport
        /// </summary>
        /// <returns><see cref="Microsoft.Xna.Framework.Rectangle"/> equivolent</returns>
        public Microsoft.Xna.Framework.Rectangle GetRawXnaRectangle()
        {
            return new Microsoft.Xna.Framework.Rectangle(
                (int)(_anchor.X * RenderHelpers.TileScale() + RenderHelpers.AdjustedScreen.Margin.Width()),
                (int)(_anchor.Y * RenderHelpers.TileScale() + RenderHelpers.AdjustedScreen.Margin.Height()),
                (int)(_width * RenderHelpers.TileScale()),
                (int)(_height * RenderHelpers.TileScale()));
        }

        /// <summary>
        /// <see cref="Vector2"/> of bottom-right of the <see cref="Rectangle"/>
        /// </summary>
        /// <returns>Bottom-right of <see cref="Rectangle"/></returns>
        public Vector2 GetSouthEastCorner()
        {
            return new Vector2(
                GetEastX(),
                GetSouthY()
            );
        }

        /// <summary>
        /// Gets <see cref="Rectangle"/> of the bottom-right quadrant
        /// </summary>
        /// <returns>Bottom-right quadrant as <see cref="Rectangle"/></returns>
        public Rectangle GetSouthEastQuadrant()
        {
            Vector2 newAnchor = new Vector2(
                GetCenterX(),
                GetCenterY()
            );

            return new Rectangle(
                newAnchor,
                GetHalfWidth(),
                GetHalfHeight()
            );
        }

        /// <summary>
        /// <see cref="Vector2"/> of bottom-left of the <see cref="Rectangle"/>
        /// </summary>
        /// <returns>Bottom-left of <see cref="Rectangle"/></returns>
        public Vector2 GetSouthWestCorner()
        {
            return new Vector2(
                _anchor.X,
                GetSouthY()
            );
        }

        /// <summary>
        /// Gets <see cref="Rectangle"/> of the bottom-left quadrant
        /// </summary>
        /// <returns>Bottom-left quadrant as <see cref="Rectangle"/></returns>
        public Rectangle GetSouthWestQuadrant()
        {
            Vector2 newAnchor = new Vector2(
                _anchor.X,
                GetCenterY()
            );

            return new Rectangle(
                newAnchor,
                GetHalfWidth(),
                GetHalfHeight()
            );
        }

        /// <summary>
        /// Gets the bottom Y value of the <see cref="Rectangle"/>
        /// </summary>
        /// <returns>Bottom Y value></returns>
        public float GetSouthY()
        {
            return _anchor.Y + _height;
        }

        /// <summary>
        /// Gets the left-most X value of the <see cref="Rectangle"/>
        /// </summary>
        /// <returns>Left-most X value></returns>
        public float GetWestX()
        {
            return _anchor.X;
        }

        /// <summary>
        /// Returns XNA <see cref="Microsoft.Xna.Framework.Rectangle"/> equivolent of <see cref="Rectangle"/>
        /// </summary>
        /// <returns><see cref="Microsoft.Xna.Framework.Rectangle"/> equivolent</returns>
        public Microsoft.Xna.Framework.Rectangle GetXnaRectangle()
        {
            return new Microsoft.Xna.Framework.Rectangle(
                (int)_anchor.X,
                (int)_anchor.Y,
                (int)_width,
                (int)_height
            );
        }
    }
}
