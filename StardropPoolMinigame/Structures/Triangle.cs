using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Structures
{
    class Triangle : IRange
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
        /// Instantiates a Triangle
        /// </summary>
        /// 
        /// <param name="x">Center point X value</param>
        /// <param name="y">Center point Y value</param>
        /// <param name="width">Width of rectangle</param>
        /// <param name="height">Height of rectangle</param>
        public Triangle(float x, float y, float width, float height)
        {
            this._x = x;
            this._y = y;
            this._width = width;
            this._height = height;
        }

        public bool Contains(Vector2 point)
        {
            throw new NotImplementedException();
        }

        public bool Intersects(IRange range)
        {
            throw new NotImplementedException();
        }
    }
}
