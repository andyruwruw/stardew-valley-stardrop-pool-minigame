using MinigameFramework.Structures;
using StardopPoolMinigame.Entities.Game.Table;

namespace MinigameFramework.Entities.Particles.ParticleRules
{
    /// <summary>
    /// How <see cref="IEntity"/> interact with other objects and their environment.
    /// </summary>
    interface IParticleRules
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
		void IntangibleInteractions(
            IEntity entity,
            IGraph? graph,
            IList<string>? ignoreEntitiesKeys = null
        );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="graph"></param>
        /// <param name="tableSegment"></param>
        /// <param name="ignoreEntitiesKeys"></param>
        /// <returns></returns>
		void TangibleInteractions(
            IEntity entity,
            IGraph? graph,
            TableSegment? tableSegment = null,
            IList<string>? ignoreEntitiesKeys = null
        );
    }
}
