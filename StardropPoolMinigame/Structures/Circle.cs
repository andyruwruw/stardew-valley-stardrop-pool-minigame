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
        private Vector2 _center;

        private float _radius;

        public Circle(Vector2 center, float radius)
        {
            this._center = center;
            this._radius = radius;
        }

        public bool Intersects(IRange other)
        {
            if (other is Circle)
            {
                return ((((Circle)other).GetCenter() - this._center).Length() < (((Circle)other).GetRadius() - this._radius));
            } else if (other is Rectangle)
            {
                double xDist = Math.Abs(((Rectangle)other).GetTopLeft().X - this._center.X);
                double yDist = Math.Abs(((Rectangle)other).GetTopLeft().Y - this._center.Y);

                if (xDist > (this._radius + ((Rectangle)other).GetWidth()) || yDist > (this._radius + ((Rectangle)other).GetHeight()))
                {
                    return false;
                }

                if (xDist <= ((Rectangle)other).GetWidth() || yDist <= ((Rectangle)other).GetHeight()) {
                    return true;
                }

                double edges = Math.Pow(xDist - ((Rectangle)other).GetWidth(), 2) + Math.Pow(yDist - ((Rectangle)other).GetHeight(), 2);

                return edges <= Math.Pow(this._radius, 2);
            }
            return false;
        }

        public bool Contains(Vector2 point)
        {
            return ((point - this._center).Length() <= this._radius);
        }

        public Vector2 GetCenter()
        {
            return this._center;
        }

        public float GetRadius()
        {
            return this._radius;
        }
    }
}
