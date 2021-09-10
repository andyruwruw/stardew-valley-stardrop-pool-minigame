using Microsoft.Xna.Framework;

namespace StardropPoolMinigame.Structures
{
    /// <summary>
    /// List of interconnected nodes.
    /// </summary>
    /// <typeparam name="T">Type of nodes stored</typeparam>
    interface IGraph<T>
    {
        /// <summary>
        /// Adds a node to the <see cref="IGraph"/>.
        /// </summary>
        /// <param name="position"><see cref="Vector2"/> position of the node</param>
        /// <param name="data">The node data</param>
        /// <returns>Whether the node was added</returns>
        bool Insert(Vector2 position, T data);

        /// <summary>
        /// Removes a node from the <see cref="IGraph"/>.
        /// </summary>
        /// <param name="position"><see cref="Vector2"/> position of the node</param>
        /// <returns>Whether the node as removed</returns>
        bool Remove(Vector2 position);

        /// <summary>
        /// Removes a node from the <see cref="IGraph"/>.
        /// </summary>
        /// <param name="data">The node data</param>
        /// <returns>Whether the node as removed</returns>
        bool Remove(T data);

        /// <summary>
        /// Gets the total number of nodes stored.
        /// </summary>
        /// <returns>Number of nodes</returns>
        int GetCount();
    }
}
