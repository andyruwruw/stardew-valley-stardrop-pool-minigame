using Microsoft.Xna.Framework;
using MinigameFramework.Entities;
using MinigameFramework.Structures.Primitives;

namespace MinigameFramework.Structures
{
    /// <summary>
    /// General querying data structure.
    /// </summary>
    interface IGraph
    {
        /// <summary>
        /// Number of items in graph.
        /// </summary>
        int Count();

        /// <summary>
        /// Inserts a new entity.
        /// </summary>
        bool Insert(IEntity entity);

        /// <summary>
        /// Removes an entity.
        /// </summary>
        bool Remove(IEntity entity);

        /// <summary>
        /// Queries the graph.
        /// </summary>
        /// <param name="range">Range to search.</param>
        /// <param name="found">Pass by reference array.</param>
        /// <returns>List of found items.</returns>
        public IList<IEntity> Query(
            IRange? range = null,
            IList<IEntity>? found = null
        );

        /// <summary>
        /// Allows for the update of all contained entities.
        /// </summary>
        /// <param name="time">Game time.</param>
        void Update(GameTime time);
    }
}
