using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Primitives.Helpers;

namespace StardropPoolMinigame.Primitives
{
    /// <summary>
    /// Simple rectangle class
    /// </summary>
    /// <remarks>It should be noted that this rectangle class inverts the Y-axis, meaning higher Y values are associated with being lower on the screen.</remarks>
    internal class Rectangle : IRange
    {
        /// <summary>
        /// <see cref="Vector2"/> of top left of the <see cref="Rectangle"/>
        /// </summary>
        private Vector2 _anchor;

        /// <summary>
        /// Height of the rectangle
        /// </summary>
        private float _height;

        /// <summary>
        /// Width of the rectangle
        /// </summary>
        private float _width;

        public Rectangle(Vector2 anchor, float width, float height)
        {
            this._anchor = anchor;
            this._width = width;
            this._height = height;
        }

        /// <inheritdoc cref="IRange.Contains(Vector2)"/>
        public bool Contains(Vector2 point)
        {
            return (point.X >= this.GetWestX() &&
                point.X <= this.GetEastX() &&
                point.Y <= this.GetSouthY() &&
                point.Y >= this.GetNorthY());
        }

        /// <summary>
        /// <see cref="Vector2"/> of top-left of the <see cref="Rectangle"/>
        /// </summary>
        /// <returns>Top-left of <see cref="Rectangle"/></returns>
        public Vector2 GetAnchor()
        {
            return this._anchor;
        }

        /// <inheritdoc cref="IRange.GetCenter(IRange)"/>
        public Vector2 GetCenter()
        {
            return new Vector2(this.GetCenterX(), this.GetCenterY());
        }

        /// <summary>
        /// Gets the center X value of the <see cref="Rectangle"/>
        /// </summary>
        /// <returns>Center X value></returns>
        public float GetCenterX()
        {
            return this._anchor.X + this.GetHalfWidth();
        }

        /// <summary>
        /// Gets the center Y value of the <see cref="Rectangle"/>
        /// </summary>
        /// <returns>Center Y value></returns>
        public float GetCenterY()
        {
            return this._anchor.Y + this.GetHalfHeight();
        }

        /// <summary>
        /// Gets the right-most X value of the <see cref="Rectangle"/>
        /// </summary>
        /// <returns>Right-most X value></returns>
        public float GetEastX()
        {
            return this._anchor.X + this._width;
        }

        /// <summary>
        /// Gets half the height of the <see cref="Rectangle"/>
        /// </summary>
        /// <returns>Half the height</returns>
        public float GetHalfHeight()
        {
            return this._height / 2;
        }

        /// <summary>
        /// Gets half the width of the <see cref="Rectangle"/>
        /// </summary>
        /// <returns>Half the width</returns>
        public float GetHalfWidth()
        {
            return this._width / 2;
        }

        /// <summary>
        /// Gets the height of the <see cref="Rectangle"/>
        /// </summary>
        /// <returns>Height of <see cref="Rectangle"/></returns>
        public float GetHeight()
        {
            return this._height;
        }

        /// <summary>
        /// <see cref="Vector2"/> of top-right of the <see cref="Rectangle"/>
        /// </summary>
        /// <returns>Top-right of <see cref="Rectangle"/></returns>
        public Vector2 GetNorthEastCorner()
        {
            return new Vector2(this.GetEastX(), this._anchor.Y);
        }

        /// <summary>
        /// Gets <see cref="Rectangle"/> of the top-right quadrant
        /// </summary>
        /// <returns>Top-right quadrant as <see cref="Rectangle"/></returns>
        public Rectangle GetNorthEastQuadrant()
        {
            Vector2 newAnchor = new Vector2(GetCenterX(), this._anchor.Y);
            return new Rectangle(newAnchor, this.GetHalfWidth(), this.GetHalfHeight());
        }

        /// <summary>
        /// <see cref="Vector2"/> of top-left of the <see cref="Rectangle"/>
        /// </summary>
        /// <returns>Top-left of <see cref="Rectangle"/></returns>
        public Vector2 GetNorthWestCorner()
        {
            return this._anchor;
        }

        /// <summary>
        /// Gets <see cref="Rectangle"/> of the top-left quadrant
        /// </summary>
        /// <returns>Top-left quadrant as <see cref="Rectangle"/></returns>
        public Rectangle GetNorthWestQuadrant()
        {
            return new Rectangle(this._anchor, this.GetHalfWidth(), this.GetHalfHeight());
        }

        /// <summary>
        /// Gets the top Y value of the <see cref="Rectangle"/>
        /// </summary>
        /// <returns>Top Y value></returns>
        public float GetNorthY()
        {
            return this._anchor.Y;
        }

        /// <summary>
        /// Returns XNA <see cref="Microsoft.Xna.Framework.Rectangle"/> equivolent of <see cref="Rectangle"/> readjusted to viewport
        /// </summary>
        /// <returns><see cref="Microsoft.Xna.Framework.Rectangle"/> equivolent</returns>
        public Microsoft.Xna.Framework.Rectangle GetRawXnaRectangle()
        {
            return new Microsoft.Xna.Framework.Rectangle(
                (int)(this._anchor.X * RenderConstants.TileScale() + RenderConstants.AdjustedScreen.Margin.Width()),
                (int)(this._anchor.Y * RenderConstants.TileScale() + RenderConstants.AdjustedScreen.Margin.Height()),
                (int)(this._width * RenderConstants.TileScale()),
                (int)(this._height * RenderConstants.TileScale()));
        }

        /// <summary>
        /// <see cref="Vector2"/> of bottom-right of the <see cref="Rectangle"/>
        /// </summary>
        /// <returns>Bottom-right of <see cref="Rectangle"/></returns>
        public Vector2 GetSouthEastCorner()
        {
            return new Vector2(this.GetEastX(), this.GetSouthY());
        }

        /// <summary>
        /// Gets <see cref="Rectangle"/> of the bottom-right quadrant
        /// </summary>
        /// <returns>Bottom-right quadrant as <see cref="Rectangle"/></returns>
        public Rectangle GetSouthEastQuadrant()
        {
            Vector2 newAnchor = new Vector2(GetCenterX(), this.GetCenterY());
            return new Rectangle(newAnchor, this.GetHalfWidth(), this.GetHalfHeight());
        }

        /// <summary>
        /// <see cref="Vector2"/> of bottom-left of the <see cref="Rectangle"/>
        /// </summary>
        /// <returns>Bottom-left of <see cref="Rectangle"/></returns>
        public Vector2 GetSouthWestCorner()
        {
            return new Vector2(this._anchor.X, this.GetSouthY());
        }

        /// <summary>
        /// Gets <see cref="Rectangle"/> of the bottom-left quadrant
        /// </summary>
        /// <returns>Bottom-left quadrant as <see cref="Rectangle"/></returns>
        public Rectangle GetSouthWestQuadrant()
        {
            Vector2 newAnchor = new Vector2(this._anchor.X, this.GetCenterY());
            return new Rectangle(newAnchor, this.GetHalfWidth(), this.GetHalfHeight());
        }

        /// <summary>
        /// Gets the bottom Y value of the <see cref="Rectangle"/>
        /// </summary>
        /// <returns>Bottom Y value></returns>
        public float GetSouthY()
        {
            return this._anchor.Y + this._height;
        }

        /// <summary>
        /// Gets the left-most X value of the <see cref="Rectangle"/>
        /// </summary>
        /// <returns>Left-most X value></returns>
        public float GetWestX()
        {
            return this._anchor.X;
        }

        /// <summary>
        /// Gets the width of the <see cref="Rectangle"/>
        /// </summary>
        /// <returns>Width of <see cref="Rectangle"/></returns>
        public float GetWidth()
        {
            return this._width;
        }

        /// <summary>
        /// Returns XNA <see cref="Microsoft.Xna.Framework.Rectangle"/> equivolent of <see cref="Rectangle"/>
        /// </summary>
        /// <returns><see cref="Microsoft.Xna.Framework.Rectangle"/> equivolent</returns>
        public Microsoft.Xna.Framework.Rectangle GetXnaRectangle()
        {
            return new Microsoft.Xna.Framework.Rectangle((int)this._anchor.X, (int)this._anchor.Y, (int)this._width, (int)this._height);
        }

        /// <inheritdoc cref="IRange.Intersects(IRange)"/>
        public bool Intersects(IRange other)
        {
            return IntersectionHelper.IsIntersecting(this, other);
        }
    }
}