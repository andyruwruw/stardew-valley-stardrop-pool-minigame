using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Primitives;
using System.Collections.Generic;

namespace StardropPoolMinigame.Behaviors.Physics
{
    class FlockingNewtonianPhysics : Physics
    {
        public FlockingNewtonianPhysics() : base()
        {
        }

        /// <inheritdoc cref="IPhysics.HasTangibleInteractions"/>
        public override bool HasTangibleInteractions()
        {
            return true;
        }

        /// <inheritdoc cref="IPhysics.GetTangiblePerception(EntityPhysics)"/>
        public override IRange GetTangiblePerception(EntityPhysics entity)
        {
            return entity.GetBoundary();
        }

        /// <inheritdoc cref="Physics.InteractWithTangible(EntityPhysics, IList{EntityPhysics}, IList{IRange})"/>
        public override void InteractWithTangible(EntityPhysics entity, IList<EntityPhysics> neighbors, IList<IRange> barriers)
        {
            this.BounceAllNeighbors(entity, neighbors);
            this.BounceAllBarriers(entity, barriers);
        }
    }
}
