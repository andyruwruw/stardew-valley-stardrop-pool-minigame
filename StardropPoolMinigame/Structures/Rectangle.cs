using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Structures
{
    class Rectangle : IRange
    {
        private float _x;

        private float _y;

        private float _width;

        private float _height;

        public Rectangle(float x, float y, float width, float height)
        {
            this._x = x;
            this._y = y;
            this._width = width;
            this._height = height;
        }

        public bool Intersects(IRange range)
        {
            Vector2 topLeft = this.GetTopLeft();
            Vector2 bottomRight = this.GetBottomRight();

            if (range is Rectangle)
            {
                Vector2 otherTopLeft = ((Rectangle)range).GetTopLeft();
                Vector2 otherBottomRight = ((Rectangle)range).GetBottomRight();

                if (topLeft.X >= otherBottomRight.X ||
                    otherTopLeft.X >= bottomRight.X ||
                    topLeft.Y <= otherBottomRight.Y ||
                    otherTopLeft.Y <= bottomRight.Y) {
                    return false;
                }
            } else if (range is Circle)
            {
                return ((Circle)range).Intersects(this);
            }
            return false;
        }

        public bool Contains(Vector2 point)
        {
            Vector2 topLeft = this.GetTopLeft();
            Vector2 bottomRight = this.GetBottomRight();

            return (point.X >= topLeft.X &&
                point.X <= bottomRight.X &&
                point.Y >= topLeft.Y &&
                point.Y <= bottomRight.Y);
        }

        public float GetWidth()
        {
            return this._width;
        }

        public float GetHeight()
        {
            return this._height;
        }

        public Vector2 GetTopLeft()
        {
            return new Vector2(this._x, this._y);
        }

        public Vector2 GetBottomLeft()
        {
            return new Vector2(this._x, this._y + this._height);
        }

        public Vector2 GetTopRight()
        {
            return new Vector2(this._x + this._width, this._y);
        }

        public Vector2 GetBottomRight()
        {
            return new Vector2(this._x + this._width, this._y + this._height);
        }

        public Rectangle GetNorthWest()
        {
            return new Rectangle(this._x, this._y, this._width / 2, this._height / 2);
        }

        public Rectangle GetNorthEast()
        {
            return new Rectangle(this._x + (this._width / 2), this._y, this._width / 2, this._height / 2);
        }

        public Rectangle GetSouthWest()
        {
            return new Rectangle(this._x, this._y + (this._height / 2), this._width / 2, this._height / 2);
        }

        public Rectangle GetSouthEast()
        {
            return new Rectangle(this._x + (this._width / 2), this._y + (this._height / 2), this._width / 2, this._height / 2);
        }
    }
}
