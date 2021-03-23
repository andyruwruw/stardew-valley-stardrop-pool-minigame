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
        /// <summary>
        /// Center point X value.
        /// </summary>
        private float _x;

        /// <summary>
        /// Center point Y value.
        /// </summary>
        private float _y;

        /// <summary>
        /// Width of rectangle.
        /// </summary>
        private float _width;

        /// <summary>
        /// Height of rectangle.
        /// </summary>
        private float _height;

        /// <summary>
        /// Instantiates a Rectangle
        /// </summary>
        /// 
        /// <param name="x">Center point X value</param>
        /// <param name="y">Center point Y value</param>
        /// <param name="width">Width of rectangle</param>
        /// <param name="height">Height of rectangle</param>
        public Rectangle(float x, float y, float width, float height)
        {
            this._x = x;
            this._y = y;
            this._width = width;
            this._height = height;
        }

        /// <summary>
        /// Whether another range intersects with this range.
        /// </summary>
        /// 
        /// <param name="range">Other <see cref="IRange"/></param>
        /// <returns>Whether range intersects</returns>
        public bool Intersects(IRange range)
        {
            if (range is Rectangle)
            {
                return (!(this.GetEast() < ((Rectangle)range).GetWest() ||
                    ((Rectangle)range).GetEast() < this.GetWest() ||
                    this.GetSouth() < ((Rectangle)range).GetNorth() ||
                    ((Rectangle)range).GetSouth() < this.GetNorth()));
            } else if (range is Circle)
            {
                return ((Circle)range).Intersects(this);
            }
            return false;
        }

        /// <summary>
        /// Whether a point lies within the range.
        /// </summary>
        /// 
        /// <param name="point">Point to check</param>
        /// <returns>Whether range contains</returns>
        public bool Contains(Vector2 point)
        {
            return (this.GetWest() <= point.X &&
              point.X <= this.GetEast() &&
              this.GetNorth() <= point.Y &&
              point.Y <= this.GetSouth());
        }

        /// <summary>
        /// Retrieves Rectangle center X property.
        /// </summary>
        /// 
        /// <returns>Center point X value</returns>
        public float GetX()
        {
            return this._x;
        }

        /// <summary>
        /// Retrieves Rectangle center Y property.
        /// </summary>
        /// 
        /// <returns>Center point Y value</returns>
        public float GetY()
        {
            return this._y;
        }

        /// <summary>
        /// Retrieves the width of the Rectangle.
        /// </summary>
        /// 
        /// <returns>Width of rectangle</returns>
        public float GetWidth()
        {
            return this._width;
        }

        /// <summary>
        /// Retrieves the height of the Rectangle.
        /// </summary>
        /// 
        /// <returns>Height of rectangle</returns>
        public float GetHeight()
        {
            return this._height;
        }

        /// <summary>
        /// Retrieves the X property of the west wall of the Rectangle.
        /// </summary>
        /// 
        /// <returns>Minimum X value</returns>
        public float GetWest()
        {
            return this._x - this._width / 2;
        }

        /// <summary>
        /// Retrieves the X property of the east wall of the Rectangle.
        /// </summary>
        /// 
        /// <returns>Maximum X value</returns>
        public float GetEast()
        {
            return this._x + this._width / 2;
        }

        /// <summary>
        /// Retrieves the Y property of the north wall of the Rectangle.
        /// </summary>
        /// 
        /// <returns>Minimum Y value</returns>
        public float GetNorth()
        {
            return this._y - this._height / 2;
        }

        /// <summary>
        /// Retrieves the Y property of the south wall of the Rectangle.
        /// </summary>
        /// 
        /// <returns>Maximum Y value</returns>
        public float GetSouth()
        {
            return this._y + this._height / 2;
        }

        /// <summary>
        /// Retrieves the north-west vertex of the Rectangle.
        /// </summary>
        /// 
        /// <returns>North-west vertex</returns>
        public Vector2 GetNorthWest()
        {
            return new Vector2(this.GetWest(), this.GetNorth());
        }

        /// <summary>
        /// Retrieves the south-west vertex of the Rectangle.
        /// </summary>
        /// 
        /// <returns>South-west vertex</returns>
        public Vector2 GetSouthWest()
        {
            return new Vector2(this.GetWest(), this.GetSouth());
        }

        /// <summary>
        /// Retrieves the north-east vertex of the Rectangle.
        /// </summary>
        /// 
        /// <returns>North-east vertex</returns>
        public Vector2 GetNorthEast()
        {
            return new Vector2(this.GetEast(), this.GetNorth());
        }

        /// <summary>
        /// Retrieves the south-east vertex of the Rectangle.
        /// </summary>
        /// 
        /// <returns>South-east vertex</returns>
        public Vector2 GetSouthEast()
        {
            return new Vector2(this.GetEast(), this.GetSouth());
        }

        /// <summary>
        /// Retrieves the north-west quadrant range of the Rectangle.
        /// </summary>
        /// 
        /// <returns>North-west quadrant</returns>
        public Rectangle GetNorthWestRange()
        {
            return new Rectangle(this._x - this._width / 4, this._y - this._height / 4, this._width / 2, this._height / 2);
        }

        /// <summary>
        /// Retrieves the north-east quadrant range of the Rectangle.
        /// </summary>
        /// 
        /// <returns>North-east quadrant</returns>
        public Rectangle GetNorthEastRange()
        {
            return new Rectangle(this._x + this._width / 4, this._y - this._height / 4, this._width / 2, this._height / 2);
        }

        /// <summary>
        /// Retrieves the south-west quadrant range of the Rectangle.
        /// </summary>
        /// 
        /// <returns>South-west quadrant</returns>
        public Rectangle GetSouthWestRange()
        {
            return new Rectangle(this._x - this._width / 4, this._y + this._height / 4, this._width / 2, this._height / 2);
        }

        /// <summary>
        /// Retrieves the south-east quadrant range of the Rectangle.
        /// </summary>
        /// 
        /// <returns>South-east quadrant</returns>
        public Rectangle GetSouthEastRange()
        {
            return new Rectangle(this._x + this._width / 4, this._y + this._height / 4, this._width / 2, this._height / 2);
        }
    }
}
