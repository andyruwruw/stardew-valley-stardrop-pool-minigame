using Microsoft.Xna.Framework;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Primitives;

namespace StardropPoolMinigame.Structures
{
    class QuadTree2<T> : EntityStatic, IGraph<T>
    {
        /// <summary>
        /// The total number of nodes stored.
        /// </summary>
        private int _count;

        public QuadTree2(
            Primitives.Rectangle boundary,
            int capacity = 4,
            bool isRoot = true
        ) : base(
            Origin.TopLeft,
            boundary.GetNorthWestCorner(),
            )
        {

        }

        /// <inheritdoc cref="IGraph{T}.Insert(Vector2, T)"/>
        public bool Insert(Vector2 position, T data)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc cref="IGraph{T}.Remove(Vector2)"/>
        public bool Remove(Vector2 point)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc cref="IGraph{T}.Remove(T)"/>
        public bool Remove(T data)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc cref="IGraph{T}.GetCount"/>
        public int GetCount()
        {
            return this._count;
        }
    }
}
