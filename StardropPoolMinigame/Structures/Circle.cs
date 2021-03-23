using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Structures
{
    class Circle : IRange
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
        /// Radius of the Circle.
        /// </summary>
        private float _radius;

        /// <summary>
        /// Instantiates a Circle.
        /// </summary>
        /// <param name="x">Center point X value</param>
        /// <param name="y">Center point Y value</param>
        /// <param name="radius">Radius of the Circle</param>
        public Circle(float x, float y, float radius)
        {
            this._x = x;
            this._y = y;
            this._radius = radius;
        }

        /// <summary>
        /// Whether another range intersects with this range.
        /// </summary>
        /// 
        /// <param name="range">Other <see cref="IRange"/></param>
        /// <returns>Whether range intersects</returns>
        public bool Intersects(IRange other)
        {
            if (other is Circle)
            {
                double distance = Math.Sqrt(Math.Pow(((Circle)other).GetX() - this._x, 2) + Math.Pow(((Circle)other).GetY() - this._y, 2));
                return (distance <= (this._radius + ((Circle)other).GetRadius()));
            } else if (other is Rectangle)
            {
                double xDist = Math.Abs(((Rectangle)other).GetX() - this._x);
                double yDist = Math.Abs(((Rectangle)other).GetY() - this._y);

                if (xDist > (this._radius + ((Rectangle)other).GetWidth() / 2) || yDist > (this._radius + ((Rectangle)other).GetHeight() / 2))
                {
                    return false;
                }

                if (xDist <= ((Rectangle)other).GetWidth() / 2 || yDist <= ((Rectangle)other).GetHeight() / 2)
                {
                    return true;
                }

                double edges = Math.Pow(xDist - (((Rectangle)other).GetWidth() / 2), 2) + Math.Pow(yDist - (((Rectangle)other).GetHeight() / 2), 2);

                return edges <= Math.Pow(this._radius, 2);
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
            double distance = Math.Pow((point.X - this._x), 2) + Math.Pow((point.Y - this._y), 2);
            return (distance <= Math.Pow(this._radius, 2));
        }

        /// <summary>
        /// Retrieves Circle center X property.
        /// </summary>
        /// 
        /// <returns>Center point X value</returns>
        public float GetX()
        {
            return this._x;
        }

        /// <summary>
        /// Retrieves Circle center Y property.
        /// </summary>
        /// 
        /// <returns>Center point Y value</returns>
        public float GetY()
        {
            return this._y;
        }

        /// <summary>
        /// Retrieves Circle center point.
        /// </summary>
        /// 
        /// <returns>Center point</returns>
        public Vector2 GetCenter()
        {
            return new Vector2(this._x, this._y);
        }

        /// <summary>
        /// Retrieves Circle radius.
        /// </summary>
        /// 
        /// <returns>Radius of the circle</returns>
        public float GetRadius()
        {
            return this._radius;
        }
    }
}
