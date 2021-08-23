﻿using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Geometry;
using StardropPoolMinigame.Primitives;
using System.Collections.Generic;

namespace StardropPoolMinigame.Structures
{
    class QuadTree
    {
        /// <summary>
        /// Number of items in QuadTree.
        /// </summary>
        public int Count;

        /// <summary>
        /// <see cref="IRange"/> of QuadTree.
        /// </summary>
        private Rectangle _boundary;

        /// <summary>
        /// Number of nodes before QuadTree <see cref="Subdivide">Subdivides</see>.
        /// </summary>
        private int _capacity;

        /// <summary>
        /// List of points in QuadTree.
        /// </summary>
        private IList<Ball> _points;

        /// <summary>
        /// Whether QuadTree has <see cref="Subdivide">Subdivided</see>.
        /// </summary>
        private bool _divided;

        /// <summary>
        /// Whether QuadTree is root QuadTree.
        /// </summary>
        private bool _isRoot;

        /// <summary>
        /// North-west quadrant QuadTree
        /// </summary>
        private QuadTree _northWest;

        /// <summary>
        /// North-east quadrant QuadTree
        /// </summary>
        private QuadTree _northEast;

        /// <summary>
        /// South-west quadrant QuadTree
        /// </summary>
        private QuadTree _southWest;

        /// <summary>
        /// South-east quadrant QuadTree
        /// </summary>
        private QuadTree _southEast;

        /// <summary>
        /// Reference to cue ball
        /// </summary>
        private Ball _cueBall;

        /// <summary>
        /// Instantiates a QuadTree
        /// </summary>
        /// <param name="boundary"><see cref="Rectangle"/> for QuadTree boundary</param>
        /// <param name="capacity">Number of nodes before QuadTree <see cref="Subdivide">Subdivides</see></param>
        /// <param name="isRoot">Whether QuadTree is root QuadTree</param>
        public QuadTree(Rectangle boundary, int capacity = 4, bool isRoot = true)
        {
            this.Count = 0;
            this._boundary = boundary;
            this._capacity = capacity;
            this._points = new List<Ball>();
            this._divided = false;
            this._isRoot = isRoot;
        }

        /// <summary>
        /// Inserts a point into the QuadTree.
        /// </summary>
        /// <remarks>
        /// The QuadTree will <see cref="Subdivide">Subdivide</see> if it is already at capacity.
        /// </remarks>
        /// 
        /// <param name="point">Point to be inserted</param>
        /// <returns>Whether point was added successfully</returns>
        public bool Insert(Ball point)
        {
            if (this._isRoot && point.GetNumber() == 0)
            {
                this._cueBall = point;
            }

            if (!this._boundary.Contains(point.GetPosition()))
            {
                return false;
            }

            if (this._points.Count < this._capacity)
            {
                this._points.Add(point);
                this.Count += 1;
                return true;
            }

            if (!this._divided)
            {
                this.Subdivide();
            }

            if (this._northEast.Insert(point) ||
                this._northWest.Insert(point) ||
                this._southEast.Insert(point) ||
                this._southWest.Insert(point))
            {
                this.Count += 1;
                return true;
            }

            return false;
        }

        public bool Remove(Ball point)
        {
            if (this._points.Contains(point))
            {
                this._points.Remove(point);
                return true;
            }

            if (this._divided)
            {
                return (this._northEast.Remove(point) ||
                    this._northWest.Remove(point) ||
                    this._southEast.Remove(point) ||
                    this._southWest.Remove(point));
            }

            return false;
        }

        /// <summary>
        /// Retrieves all points within a given <see cref="IRange"/>.
        /// </summary>
        /// 
        /// <param name="range"><see cref="IRange"/> to query</param>
        /// <param name="found">List of found points so far</param>
        /// <returns>List of points found</returns>
        public IList<Ball> Query(IRange range = null, List<Ball> found = null)
        {
            if (range == null)
            {
                range = this._boundary;
            }

            if (found == null)
            {
                found = new List<Ball>();
            }

            if (!Intersection.IsIntersecting(range, this._boundary))
            {
                return found;
            }

            foreach (Ball ball in this._points)
            {
                if (range.Contains(ball.GetPosition()))
                {
                    found.Add(ball);
                }
            }

            if (this._divided)
            {
                found.AddRange(this._northWest.Query(range));
                found.AddRange(this._northEast.Query(range));
                found.AddRange(this._southWest.Query(range));
                found.AddRange(this._southEast.Query(range));
            }

            return found;
        }

        public Ball GetCueBall()
        {
            return this._cueBall;
        }

        public IRange GetBoundary()
        {
            return this._boundary;
        }

        /// <summary>
        /// Subdivides the QuadTree into quadrants.
        /// </summary>
        private void Subdivide()
        {
            this._northWest = new QuadTree(this._boundary.GetNorthWestRange(), this._capacity, false);
            this._northEast = new QuadTree(this._boundary.GetNorthEastRange(), this._capacity, false);
            this._southWest = new QuadTree(this._boundary.GetSouthWestRange(), this._capacity, false);
            this._southEast = new QuadTree(this._boundary.GetSouthEastRange(), this._capacity, false);

            this._divided = true;
        }
    }
}
