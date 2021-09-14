using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Primitives;
using StardropPoolMinigame.Structures;
using System;
using System.Collections.Generic;

namespace StardropPoolMinigame.Behaviors.Physics
{
    /// <summary>
    /// How <see cref="EntityPhysics"/> interact with other objects and their environment.
    /// </summary>
    interface IPhysics
    {
        /// <summary>
        /// <para>Whether the <see cref="IPhysics"/> system includes intangible forces.</para>
        /// <para>Meaning, do objects influence each other's position without touching.</para>
        /// </summary>
        /// <returns>Whether intangible forces apply</returns>
        bool HasIntangibleInteractions();

        /// <summary>
        /// <para>Whether the <see cref="IPhysics"/> system includes tangible forces.</para>
        /// <para>Meaning, do objects influence each other's position by touching.</para>
        /// </summary>
        /// <returns>Whether tangible forces apply</returns>
        bool HasTangibleInteractions();

        /// <summary>
        /// Simulates intangible interactions for <see cref="IGraph{T}"/>, generating a new <see cref="IGraph{T}"/> in its place.
        /// </summary>
        /// <param name="graph"><see cref="IGraph{T}"/> of <see cref="EntityPhysics"/></param>
        /// <param name="table"></param>
        /// <returns>New <see cref="IGraph{T}"/></returns>
        Tuple<IGraph<EntityPhysics>, bool> IntangibleInteractions(IGraph<EntityPhysics> graph, Table table);

        /// <summary>
        /// Simulates tangible interactions for <see cref="IGraph{T}"/>, generating a new <see cref="IGraph{T}"/> in its place.
        /// </summary>
        /// <param name="graph"><see cref="IGraph{T}"/> of <see cref="EntityPhysics"/></param>
        /// <param name="table"></param>
        /// <returns>New <see cref="IGraph{T}"/></returns>
        Tuple<IGraph<EntityPhysics>, bool> TangibleInteractions(IGraph<EntityPhysics> graph, Table table);
    }
}
