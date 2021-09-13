using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Primitives;
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
        /// Retrives the <see cref="IRange"/> of a <see cref="EntityPhysics">EntityPhysics'</see> intangible forces.
        /// </summary>
        /// <param name="entity"><see cref="EntityPhysics"/> in question</param>
        /// <returns><see cref="IRange"/> of <see cref="EntityPhysics"/> intangible perception</returns>
        IRange GetIntangiblePerception(EntityPhysics entity);

        /// <summary>
        /// Retrives the <see cref="IRange"/> of a <see cref="EntityPhysics">EntityPhysics'</see> tangible forces.
        /// </summary>
        /// <param name="entity"><see cref="EntityPhysics"/> in question</param>
        /// <returns><see cref="IRange"/> of <see cref="EntityPhysics"/> tangible perception</returns>
        IRange GetTangiblePerception(EntityPhysics entity);

        /// <summary>
        /// Simulate interaction between main <see cref="EntityPhysics"/> and its intangible neighbors / barriers.
        /// </summary>
        /// <param name="entity">Main <see cref="EntityPhysics"/></param>
        /// <param name="neighbors">Neighboring <see cref="EntityPhysics"/> within the main <see cref="EntityPhysics"/> intangible perception radius</param>
        /// <param name="barriers">Neighboring <see cref="IRange">IRanges</see> within the main <see cref="EntityPhysics"/> intangible perception radius</param>
        void InteractWithIntangible(EntityPhysics entity, IList<EntityPhysics> neighbors, IList<IRange> barriers);

        /// <summary>
        /// Simulate interaction between main <see cref="EntityPhysics"/> and its tangible neighbors / barriers.
        /// </summary>
        /// <param name="entity">Main <see cref="EntityPhysics"/></param>
        /// <param name="neighbors">Neighboring <see cref="EntityPhysics"/> within the main <see cref="EntityPhysics"/> tangible perception radius</param>
        /// <param name="barriers">Neighboring <see cref="IRange">IRanges</see> within the main <see cref="EntityPhysics"/> tangible perception radius</param>
        void InteractWithTangible(EntityPhysics entity, IList<EntityPhysics> neighbors, IList<IRange> barriers);
    }
}
