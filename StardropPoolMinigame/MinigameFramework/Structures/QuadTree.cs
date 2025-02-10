using Microsoft.Xna.Framework;
using MinigameFramework.Entities;
using MinigameFramework.Structures.Primitives;

namespace MinigameFramework.Structures
{
    /// <summary>
    /// Holds points in a subdividing grid defined by a boundary.
    /// </summary>
    class QuadTree : IGraph
    {
        /// <summary>
        /// <see cref="IRange"/> of QuadTree.
        /// </summary>
        protected Primitives.Rectangle _boundary;

        /// <summary>
        /// Number of nodes before QuadTree <see cref="Subdivide">Subdivides</see>.
        /// </summary>
        protected int _capacity;

        /// <summary>
        /// Whether QuadTree has <see cref="Subdivide">Subdivided</see>.
        /// </summary>
        protected bool _subdivided;

        /// <summary>
        /// Whether QuadTree is root QuadTree.
        /// </summary>
        protected bool _isRoot;

        /// <summary>
        /// List of points in QuadTree.
        /// </summary>
        protected IList<IEntity> _items;

        /// <summary>
        /// North-west quadrant QuadTree
        /// </summary>
        protected QuadTree? _northWest;

        /// <summary>
        /// North-east quadrant QuadTree
        /// </summary>
        protected QuadTree? _northEast;

        /// <summary>
        /// South-west quadrant QuadTree
        /// </summary>
        protected QuadTree? _southWest;

        /// <summary>
        /// South-east quadrant QuadTree
        /// </summary>
        protected QuadTree? _southEast;

        /// <summary>
        /// Instantiates a QuadTree
        /// </summary>
        /// <param name="boundary"><see cref="IRange"/> for QuadTree</param>
        /// <param name="capacity">Number of nodes before QuadTree <see cref="Subdivide">Subdivides</see></param>
        /// <param name="isRoot">Whether QuadTree is root QuadTree</param>
        public QuadTree(
            Primitives.Rectangle boundary,
            int capacity = 4,
            bool isRoot = true
        )
        {
            _capacity = capacity;
            _boundary = boundary;
            _isRoot = isRoot;
            _subdivided = false;
            _items = new List<IEntity>();
        }

        /// <summary>
        /// Number of items in QuadTree.
        /// </summary>
        public int Count()
        {
            return _items.Count();
        }

        /// <summary>
        /// Retrieves the QuadTree's <see cref="_boundary"/>.
        /// </summary>
        public Primitives.Rectangle GetBoundary()
        {
            return _boundary;
        }

        /// <summary>
        /// Inserts a point into the QuadTree.
        /// </summary>
        /// <remarks>
        /// The QuadTree will <see cref="Subdivide">Subdivide</see> if it is already at capacity.
        /// </remarks>
        /// <param name="entity">Entity to be inserted</param>
        /// <returns>Whether entity was added successfully</returns>
        public bool Insert(IEntity entity)
        {
            // If the point doesn't belong in this subdivision, skip.
            if (!_boundary.Contains(entity.GetAnchor()))
            {
                return false;
            }

            // If we haven't reached capacity, add the entity.
            if (_items.Count < _capacity)
            {
                _items.Add(entity);
                return true;
            }

            // If we've reach capacity and not subdivided, take care of that now.
            if (!_subdivided)
            {
                Subdivide();
            }

            // Add point to children.
            return (_northEast != null ? _northEast.Insert(entity) : false
                || _northWest != null ? _northWest.Insert(entity) : false
                || _southEast != null ? _southEast.Insert(entity) : false
                || _southWest != null ? _southWest.Insert(entity) : false);
        }

        /// <summary>
        /// Whether <see cref="QuadTree{T}"/> has <see cref="Subdivide">Subdivided</see>.
        /// </summary>
        public bool IsSubdivided()
        {
            return _subdivided;
        }

        /// <summary>
        /// Remove a point from the tree.
        /// </summary>
        /// <param name="point">Point to be removed.</param>
        /// <returns>Whether the item was removed successfully.</returns>
        public bool Remove(IEntity point)
        {
            if (!_subdivided && _items.Contains(point))
            {
                _items.Remove(point);
                return true;
            }

            if (_subdivided)
            {
                return _northEast != null ? _northEast.Remove(point) : false ||
                    _northWest != null ? _northWest.Remove(point) : false ||
                    _southEast != null ? _southEast.Remove(point) : false ||
                    _southWest != null ? _southWest.Remove(point) : false;
            }

            return false;
        }

        /// <summary>
        /// Retrieves all entities within a given <see cref="IRange"/>.
        /// </summary>
        /// 
        /// <param name="range"><see cref="IRange"/> to query, defaults to range of tree.</param>
        /// <param name="found">List of found entities so far.</param>
        /// <returns>List of entities found</returns>
        public IList<IEntity> Query(
            IRange? range = null,
            IList<IEntity>? found = null
        )
        {
            // Define the range if needed.
            IRange? resolvedRange = range;
            if (resolvedRange == null)
            {
                resolvedRange = _boundary;
            }

            IList<IEntity>? resolvedFound = found;
            if (resolvedFound == null)
            {
                resolvedFound = new List<IEntity>();
            }

            if (!resolvedRange.Intersects(_boundary))
            {
                return resolvedFound;
            }

            foreach (IEntity entity in _items)
            {
                if (resolvedRange.Contains(entity.GetAnchor()))
                {
                    resolvedFound.Add(entity);
                }
            }

            if (_subdivided)
            {
                if (_northEast != null)
                {
                    _northEast.Query(
                        resolvedRange,
                        resolvedFound
                    );
                }
                if (_northWest != null)
                {
                    _northWest.Query(
                        resolvedRange,
                        resolvedFound
                    );
                }
                if (_southEast != null)
                {
                    _southEast.Query(
                        resolvedRange,
                        resolvedFound
                    );
                }
                if (_southWest != null)
                {
                    _southWest.Query(
                        resolvedRange,
                        resolvedFound
                    );
                }
            }

            return resolvedFound;
        }

        /// <summary>
        /// Updates all items.
        /// </summary>
        public void Update(GameTime time)
        {
            foreach (IEntity entity in Query())
            {
                entity.Update(time);
            }
        }

        /// <summary>
        /// Subdivides the tree into four parts.
        /// </summary>
        protected void Subdivide()
        {
            _northEast = new QuadTree(
                _boundary.GetNorthEastQuadrant(),
                _capacity,
                false
            );
            _northWest = new QuadTree(
                _boundary.GetNorthWestQuadrant(),
                _capacity,
                false
            );
            _southEast = new QuadTree(
                _boundary.GetSouthEastQuadrant(),
                _capacity,
                false
            );
            _southWest = new QuadTree(
                _boundary.GetSouthWestQuadrant(),
                _capacity,
                false
            );

            foreach (IEntity entity in _items)
            {
                bool added = _northEast != null ? _northEast.Insert(entity) : false
                    || _northWest != null ? _northWest.Insert(entity) : false
                    || _southEast != null ? _southEast.Insert(entity) : false
                    || _southWest != null ? _southWest.Insert(entity) : false;
            }

            _items.Clear();

            _subdivided = true;
        }
    }
}
