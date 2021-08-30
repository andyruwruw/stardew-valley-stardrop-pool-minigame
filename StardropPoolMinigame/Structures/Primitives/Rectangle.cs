using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;

namespace StardropPoolMinigame.Primitives
{
    class Rectangle: IRange
    {
        private Vector2 _anchor;

        private float _width;

        private float _height;

        public Rectangle(Vector2 anchor, float width, float height)
        {
            this._anchor = anchor;
            this._width = width;
            this._height = height;
        }

        public bool Contains(Vector2 point)
        {
            return (point.X > this.GetWestX() &&
                point.X < this.GetEastX() &&
                point.Y < this.GetSouthY() &&
                point.Y > this.GetNorthY());
        }

        public Microsoft.Xna.Framework.Rectangle GetXnaRectangle()
        {
            return new Microsoft.Xna.Framework.Rectangle((int)this._anchor.X, (int)this._anchor.Y, (int)this._width, (int)this._height);
        }

        public Microsoft.Xna.Framework.Rectangle GetRawXnaRectangle()
        {
            return new Microsoft.Xna.Framework.Rectangle(
                (int)(this._anchor.X * RenderConstants.TileScale() + RenderConstants.AdjustedScreenWidthMargin()),
                (int)(this._anchor.Y * RenderConstants.TileScale() + RenderConstants.AdjustedScreenHeightMargin()),
                (int)(this._width * RenderConstants.TileScale()),
                (int)(this._height * RenderConstants.TileScale()));
        }

        public Vector2 GetAnchor()
        {
            return this._anchor;
        }

        public float GetWidth()
        {
            return this._width;
        }

        public float GetHeight()
        {
            return this._height;
        }

        public float GetNorthY()
        {
            return this._anchor.Y;
        }

        public float GetSouthY()
        {
            return this._anchor.Y + this._height;
        }

        public float GetWestX()
        {
            return this._anchor.X;
        }

        public float GetEastX()
        {
            return this._anchor.X + this._width;
        }

        public float GetCenterX()
        {
            return this._anchor.X + this.GetHalfWidth();
        }

        public float GetCenterY()
        {
            return this._anchor.Y + this.GetHalfHeight();
        }

        public float GetHalfWidth()
        {
            return this._width / 2;
        }

        public float GetHalfHeight()
        {
            return this._height / 2;
        }

        public Vector2 GetNorthWestCorner()
        {
            return this._anchor;
        }

        public Vector2 GetNorthEastCorner()
        {
            return new Vector2(this.GetEastX(), this._anchor.Y);
        }

        public Vector2 GetSouthWestCorner()
        {
            return new Vector2(this._anchor.X, this.GetSouthY());
        }

        public Vector2 GetSouthEastCorner()
        {
            return new Vector2(this.GetEastX(), this.GetSouthY());
        }

        public Rectangle GetNorthWestRange()
        {
            return new Rectangle(this._anchor, this.GetHalfWidth(), this.GetHalfHeight());
        }

        public Rectangle GetNorthEastRange()
        {
            Vector2 newAnchor = new Vector2(GetCenterX(), this._anchor.Y);
            return new Rectangle(newAnchor, this.GetHalfWidth(), this.GetHalfHeight());
        }

        public Rectangle GetSouthWestRange()
        {
            Vector2 newAnchor = new Vector2(this._anchor.X, this.GetCenterY());
            return new Rectangle(newAnchor, this.GetHalfWidth(), this.GetHalfHeight());
        }

        public Rectangle GetSouthEastRange()
        {
            Vector2 newAnchor = new Vector2(GetCenterX(), this.GetCenterY());
            return new Rectangle(newAnchor, this.GetHalfWidth(), this.GetHalfHeight());
        }
    }
}
