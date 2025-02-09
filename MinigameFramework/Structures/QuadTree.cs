using MinigameFramework.Entities;
using MinigameFramework.Structures.Primitives;

namespace MinigameFramework.Structures
{
    class QuadTree<T> : IGraph<T>
    {
        /// <summary>
        /// Number of nodes before QuadTree <see cref="Subdivide">Subdivides</see>.
        /// </summary>
        private int _capacity;

        /// <summary>
        /// <see cref="IRange"/> of QuadTree.
        /// </summary>
        private Rectangle _boundary;

        /// <summary>
        /// Whether QuadTree is root QuadTree.
        /// </summary>
        private bool _isRoot;

        /// <summary>
        /// Whether QuadTree has <see cref="Subdivide">Subdivided</see>.
        /// </summary>
        private bool _divided;

        /// <summary>
        /// List of points in QuadTree.
        /// </summary>
        private IList<T> _points;

        /// <summary>
        /// North-west quadrant QuadTree
        /// </summary>
        private QuadTree<T> _northWest;

        /// <summary>
        /// North-east quadrant QuadTree
        /// </summary>
        private QuadTree<T> _northEast;

        /// <summary>
        /// South-west quadrant QuadTree
        /// </summary>
        private QuadTree<T> _southWest;

        /// <summary>
        /// South-east quadrant QuadTree
        /// </summary>
        private QuadTree<T> _southEast;

        /// <summary>
        /// Instantiates a QuadTree
        /// </summary>
        /// <param name="boundary"><see cref="IRange"/> for QuadTree</param>
        /// <param name="capacity">Number of nodes before QuadTree <see cref="Subdivide">Subdivides</see></param>
        /// <param name="isRoot">Whether QuadTree is root QuadTree</param>
        public QuadTree(
            Rectangle boundary,
            int capacity = 4,
            bool isRoot = true
        ) {
            this._capacity = capacity;
            this._boundary = boundary;
            this._isRoot = isRoot;
            this._divided = false;
            this._points = new List<T>();
        }

        /// <summary>
        /// Number of items in QuadTree.
        /// </summary>
        public int Count()
        {
            return _points.Count();
        }

        /// <summary>
        /// Retrieves the QuadTree's <see cref="_boundary"/>.
        /// </summary>
        public Rectangle GetBoundary()
        {
            return this._boundary;
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
        public bool Insert(T point)
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

        public bool Remove(T point)
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
        public IList<T> Query(
            IRange? range = null,
            IList<T>? found = null
        ) {
            if (range == null)
            {
                range = this._boundary;
            }

            if (found == null)
            {
                found = new List<T>();
            }

            if (!range.Intersects(this._boundary))
            {
                return found;
            }

            foreach (T ball in this._points)
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
    }
}
