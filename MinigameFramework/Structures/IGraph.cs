using MinigameFramework.Structures.Primitives;

namespace MinigameFramework.Structures
{
    /// <summary>
    /// General querying data structure.
    /// </summary>
    interface IGraph<T>
    {
        /// <summary>
        /// Number of items in graph.
        /// </summary>
        int Count();

        /// <summary>
        /// Inserts a new entity.
        /// </summary>
        bool Insert(T entity);

        /// <summary>
        /// Removes an entity.
        /// </summary>
        bool Remove(T entity);

        /// <summary>
        /// Queries the graph.
        /// </summary>
        /// <param name="range">Range to search.</param>
        /// <param name="found">Pass by reference array.</param>
        /// <returns>List of found items.</returns>
        public IList<T> Query(
            IRange? range = null,
            IList<T>? found = null
        );
    }
}
