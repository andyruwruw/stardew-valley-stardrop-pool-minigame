using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Primitives;
using StardropPoolMinigame.Scenes.States;
using StardropPoolMinigame.Structures;
using System;
using System.Collections.Generic;

namespace StardropPoolMinigame.Behaviors.Physics
{
    /// <summary>
    /// How <see cref="EntityPhysics"/> interact with other objects and their environment.
    /// </summary>
    internal interface IPhysics
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
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="graph"></param>
        /// <param name="ignoreEntitiesKeys"></param>
        /// <returns></returns>
		InteractionsResults IntangibleInteractions(
			EntityPhysics entity,
			IGraph<EntityPhysics> graph,
			IList<string> ignoreEntitiesKeys = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="graph"></param>
        /// <param name="tableSegment"></param>
        /// <param name="ignoreEntitiesKeys"></param>
        /// <returns></returns>
		InteractionsResults TangibleInteractions(
			EntityPhysics entity,
			IGraph<EntityPhysics> graph,
			TableSegment tableSegment = null,
			IList<string> ignoreEntitiesKeys = null);
    }
}