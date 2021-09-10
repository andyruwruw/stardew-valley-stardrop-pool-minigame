using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Primitives;
using StardropPoolMinigame.Render.Drawers;
using System.Collections.Generic;

namespace StardropPoolMinigame.Structures
{
    class QuadTree<T> : EntityStatic, IGraph<T>
    {
        /// <summary>
        /// The total number of nodes stored.
        /// </summary>
        private int _count;

        /// <summary>
        /// <see cref="IRange"/> of <see cref="QuadTree{T}"/>.
        /// </summary>
        private Primitives.Rectangle _boundary;

        /// <summary>
        /// Number of nodes before <see cref="QuadTree{T}"/> <see cref="Subdivide">Subdivides</see>.
        /// </summary>
        private int _capacity;

        /// <summary>
        /// North-west quadrant <see cref="QuadTree{T}"/>.
        /// </summary>
        private QuadTree<T> _northWest;

        /// <summary>
        /// North-east quadrant <see cref="QuadTree{T}"/>.
        /// </summary>
        private QuadTree<T> _northEast;

        /// <summary>
        /// South-west quadrant <see cref="QuadTree{T}"/>.
        /// </summary>
        private QuadTree<T> _southWest;

        /// <summary>
        /// South-east quadrant <see cref="QuadTree{T}"/>.
        /// </summary>
        private QuadTree<T> _southEast;

        /// <summary>
        /// List of points in <see cref="QuadTree{T}"/>.
        /// </summary>
        private Dictionary<Vector2, T> _points;

        /// <summary>
        /// Whether <see cref="QuadTree{T}"/> has <see cref="Subdivide">Subdivided</see>.
        /// </summary>
        private bool _isDivided;

        /// <summary>
        /// Whether <see cref="QuadTree{T}"/> is root <see cref="QuadTree{T}"/>.
        /// </summary>
        private bool _isRoot;

        /// <summary>
        /// Instantiates a <see cref="QuadTree{T}"/>.
        /// </summary>
        /// <param name="boundary"><see cref="Rectangle"/> for <see cref="QuadTree{T}"/> boundary</param>
        /// <param name="capacity">Number of nodes before <see cref="QuadTree{T}"/> <see cref="Subdivide">Subdivides</see></param>
        /// <param name="isRoot">Whether <see cref="QuadTree{T}"/> is root <see cref="QuadTree{T}"/></param>
        public QuadTree(
            Primitives.Rectangle boundary,
            int capacity = 4,
            bool isRoot = true
        ) : base(
            Origin.TopLeft,
            boundary.GetNorthWestCorner(),
            RenderConstants.Scenes.General.LayerDepth.QUAD_TREE,
            null,
            null)
        {
            this._count = 0;
            this._boundary = boundary;
            this._capacity = capacity;
            this._points = new Dictionary<Vector2, T>();
            this._isDivided = false;
            this._isRoot = isRoot;

            this.SetDrawer(new QuadTreeDrawer(this));
        }

        /// <inheritdoc cref="IGraph{T}.Insert(Vector2, T)"/>
        public bool Insert(Vector2 position, T data)
        {
            if (!this._boundary.Contains(position))
            {
                return false;
            }

            if (this._points.Count < this._capacity)
            {
                this._points.Add(position, data);
                this._count += 1;
                return true;
            }

            if (!this._isDivided)
            {
                this.Subdivide();
            }

            if (this._northEast.Insert(position, data))
            {
                this._count += 1;
                return true;
            }

            if (this._northWest.Insert(position, data))
            {
                this._count += 1;
                return true;
            }

            if (this._southEast.Insert(position, data))
            {
                this._count += 1;
                return true;
            }

            if (this._southWest.Insert(position, data))
            {
                this._count += 1;
                return true;
            }

            return false;
        }

        /// <inheritdoc cref="IGraph{T}.Remove(Vector2)"/>
        public bool Remove(Vector2 position)
        {
            if (this._points.ContainsKey(position))
            {
                this._points.Remove(position);
                return true;
            }

            if (this._isDivided)
            {
                return (this._northEast.Remove(position) ||
                    this._northWest.Remove(position) ||
                    this._southEast.Remove(position) ||
                    this._southWest.Remove(position));
            }

            return false;
        }

        /// <inheritdoc cref="IGraph{T}.Remove(T)"/>
        public bool Remove(T data)
        {
            return false;
        }

        /// <inheritdoc cref="IGraph{T}.GetCount"/>
        public int GetCount()
        {
            return this._count;
        }

        /// <inheritdoc cref="IEntity.GetTotalWidth"/>
        public override float GetTotalWidth()
        {
            return this._boundary.GetWidth();
        }

        /// <inheritdoc cref="IEntity.GetTotalHeight"/>
        public override float GetTotalHeight()
        {
            return this._boundary.GetHeight();
        }

        /// <summary>
        /// Retrieves all points within a given <see cref="IRange"/>.
        /// </summary>
        /// 
        /// <param name="range"><see cref="IRange"/> to query</param>
        /// <param name="found">List of found points so far</param>
        /// <returns>List of points found</returns>
        public IList<T> Query(IRange range = null, List<T> found = null)
        {
            if (range == null)
            {
                range = this._boundary;
            }

            if (found == null)
            {
                found = new List<T>();
            }

            if (!this._boundary.Intersects(range))
            {
                return found;
            }

            foreach (Vector2 position in this._points.Keys)
            {
                if (range.Contains(position))
                {
                    found.Add(this._points[position]);
                }
            }

            if (this._isDivided)
            {
                found.AddRange(this._northWest.Query(range));
                found.AddRange(this._northEast.Query(range));
                found.AddRange(this._southWest.Query(range));
                found.AddRange(this._southEast.Query(range));
            }

            return found;
        }

        /// <summary>
        /// <see cref="IRange"/> of <see cref="QuadTree{T}"/>.
        /// </summary>
        public IRange GetBoundary()
        {
            return this._boundary;
        }

        /// <summary>
        /// Whether <see cref="QuadTree{T}"/> has <see cref="Subdivide">Subdivided</see>.
        /// </summary>
        public bool IsSubdivided()
        {
            return this._isDivided;
        }

        /// <summary>
        /// North-west quadrant <see cref="QuadTree{T}"/>.
        /// </summary>
        public QuadTree<T> GetNorthWestQuadrant()
        {
            return this._northWest;
        }

        /// <summary>
        /// North-east quadrant <see cref="QuadTree{T}"/>.
        /// </summary>
        public QuadTree<T> GetNorthEastQuadrant()
        {
            return this._northEast;
        }

        /// <summary>
        /// South-west quadrant <see cref="QuadTree{T}"/>.
        /// </summary>
        public QuadTree<T> GetSouthWestQuadrant()
        {
            return this._southWest;
        }

        /// <summary>
        /// South-east quadrant <see cref="QuadTree{T}"/>.
        /// </summary>
        public QuadTree<T> GetSouthEastQuadrant()
        {
            return this._southEast;
        }

        /// <summary>
        /// Subdivides the <see cref="QuadTree{T}"/> into quadrants.
        /// </summary>
        private void Subdivide()
        {
            this._northWest = new QuadTree<T>(this._boundary.GetNorthWestQuadrant(), this._capacity, false);
            this._northEast = new QuadTree<T>(this._boundary.GetNorthEastQuadrant(), this._capacity, false);
            this._southWest = new QuadTree<T>(this._boundary.GetSouthWestQuadrant(), this._capacity, false);
            this._southEast = new QuadTree<T>(this._boundary.GetSouthEastQuadrant(), this._capacity, false);

            this._isDivided = true;
        }
    }
}
