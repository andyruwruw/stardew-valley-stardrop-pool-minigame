using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Structures
{
    class QuadTree
    {
        private Rectangle _boundary;

        private int _capacity;

        private IList<IBall> _points;

        private bool _divided;

        private QuadTree _northWest;
        private QuadTree _northEast;
        private QuadTree _southWest;
        private QuadTree _southEast;

        public QuadTree(Rectangle boundary, int capacity = 4)
        {
            this._boundary = boundary;
            this._capacity = capacity;
            this._points = new List<IBall>();
            this._divided = false;
        }

        public bool Insert(IBall point)
        {
            if (!this._boundary.Contains(point.GetPosition()))
            {
                return false;
            }

            if (this._points.Count < this._capacity)
            {
                this._points.Add(point);
                return true;
            }

            if (!this._divided)
            {
                this.Subdivide();
            }

            return (this._northEast.Insert(point) ||
                this._northWest.Insert(point) ||
                this._southEast.Insert(point) ||
                this._southWest.Insert(point));
        }

        public IList<IBall> Query(IRange range = null, List<IBall> found = null)
        {
            if (range == null)
            {
                range = this._boundary;
            }

            if (found == null)
            {
                found = new List<IBall>();
            }

            if (!range.Intersects(this._boundary))
            {
                return found;
            }

            foreach (IBall ball in this._points)
            {
                if (range.Contains(ball.GetPosition()))
                {
                    found.Add(ball);
                }
            }

            if (this._divided)
            {
                this._northWest.Query(range, found);
                this._northEast.Query(range, found);
                this._southWest.Query(range, found);
                this._southEast.Query(range, found);
            }

            return found;
        }

        private void Subdivide()
        {
            this._northWest = new QuadTree(this._boundary.GetNorthWest(), this._capacity);
            this._northEast = new QuadTree(this._boundary.GetNorthEast(), this._capacity);
            this._southWest = new QuadTree(this._boundary.GetSouthWest(), this._capacity);
            this._southEast = new QuadTree(this._boundary.GetSouthEast(), this._capacity);
        }
    }
}
