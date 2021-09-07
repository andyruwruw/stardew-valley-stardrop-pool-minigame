using Microsoft.Xna.Framework;
using System;

namespace StardropPoolMinigame.Primitives
{
    class Line
    {
        private Vector2 _start;

        private Vector2 _end;

        public Line(Vector2 start, Vector2 end)
        {
            this._start = start;
            this._end = end;
        }

        public Vector2 GetAngle()
        {
            return Vector2.Subtract(this._start, this._end);
        }

        public bool Intersects(Circle circle)
        {
            float startDistanceX = this._start.X - circle.GetCenter().X;
            float startDistanceY = this._start.Y - circle.GetCenter().Y;

            float endDistanceX = this._end.X - circle.GetCenter().X;
            float endDistanceY = this._end.Y -= circle.GetCenter().Y;

            float a = (float)(Math.Pow(endDistanceX - startDistanceX, 2) + Math.Pow(endDistanceY - startDistanceY, 2));
            float b = 2 * (startDistanceX * (endDistanceX - startDistanceX) + startDistanceY * (endDistanceY - startDistanceY));
            float c = (float)(Math.Pow(startDistanceX, 2) + Math.Pow(startDistanceY, 2) - Math.Pow(circle.GetRadius(), 2));
            float disc = (float)(Math.Pow(b, 2) - 4 * a * c);

            if (disc <= 0)
            {
                return false;
            }

            float sqrtdisc = (float)Math.Sqrt(disc);

            float t1 = (-b + sqrtdisc) / (2 * a);
            float t2 = (-b - sqrtdisc) / (2 * a);

            return (0 < t1 && t1 < 1) || (0 < t2 && t2 < 1);
        }

        public bool Intersects(Line other)
        {
            float o1 = this.Orientation(this._start, other.GetStart(), this._end);
            float o2 = this.Orientation(this._start, other.GetStart(), other.GetEnd());
            float o3 = this.Orientation(this._end, other.GetEnd(), this._start);
            float o4 = this.Orientation(this._end, other.GetEnd(), other.GetStart());

            if (o1 != o2 && o3 != o4)
            {
                return true;
            }

            if (o1 == 0 && this.OnSegment(this._start, this._end, other.GetStart()))
            {
                return true;
            }
            
            if (o2 == 0 && this.OnSegment(this._start, other.GetEnd(), other.GetStart()))
            {
                return true;
            }

            if (o3 == 0 && this.OnSegment(this._end, this._start, other.GetEnd()))
            {
                return true;
            }

            if (o4 == 0 && this.OnSegment(this._end, other.GetStart(), other.GetEnd()))
            {
                return true;
            }

            return false;
        }

        public Vector2 GetStart()
        {
            return this._start;
        }

        public Vector2 GetEnd()
        {
            return this._end;
        }

        private bool OnSegment(Vector2 p, Vector2 q, Vector2 r)
        {
            return q.X <= Math.Max(p.X, r.X) && q.X >= Math.Min(p.X, r.X) && q.Y <= Math.Max(p.Y, r.Y) && q.Y >= Math.Min(p.Y, r.Y);
        }

        private float Orientation(Vector2 p, Vector2 q, Vector2 r)
        {
            float value = (q.Y - p.Y) * (r.X - q.X) - (q.X - p.X) * (r.Y - q.Y);

            if (value == 0f)
            {
                return value;
            }

            return value > 0f ? 1f : 2f;
        }
    }
}
