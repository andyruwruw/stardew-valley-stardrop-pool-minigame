using System.Collections.Generic;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Primitives;
using StardropPoolMinigame.Structures;

namespace StardropPoolMinigame.Behaviors.Physics
{
	/// <summary>
	/// <para><inheritdoc cref="Physics"/></para>
	/// <para>Resembles real life physics.</para>
	/// </summary>
	internal class NewtonianPhysics : Physics
	{
		/// <inheritdoc cref="IPhysics.HasTangibleInteractions"/>
		public override bool HasTangibleInteractions()
		{
			return true;
		}

		/// <inheritdoc cref="Physics.TangibleInteractions"/>
		public override InteractionsResults TangibleInteractions(
			EntityPhysics entity,
			IGraph<EntityPhysics> graph,
			TableSegment tableSegment = null,
			IList<string> ignoreEntitiesKeys = null)
		{
			InteractionsResults results = new InteractionsResults();

			var boundary = GetTangiblePerception(entity);
			var neighbors = ((QuadTree<EntityPhysics>) graph).Query(new Circle(boundary.GetCenter(), ((Circle)boundary).GetRadius() * 2));

			IList<EntityPhysics> filteredNeighbors = new List<EntityPhysics>();

			var barriers = tableSegment.GetBounceableSurfaces();

			foreach (Ball neighbor in neighbors)
			{
				if (HasTangibleInteractions()
					&& (ignoreEntitiesKeys == null
					|| (!ignoreEntitiesKeys.Contains(neighbor.GetId()))))
				{
					filteredNeighbors.Add(neighbor);
				}
			}

			InteractWithTangible(entity, filteredNeighbors, barriers);

			results.SetInteractedWith(filteredNeighbors);
			return results;
		}

		/// <inheritdoc cref="Physics.GetTangiblePerception"/>
		protected override IRange GetTangiblePerception(EntityPhysics entity)
		{
			return entity.GetBoundary();
		}

		/// <inheritdoc cref="Physics.InteractWithTangible"/>
		protected override void InteractWithTangible(
			EntityPhysics entity,
			IList<EntityPhysics> neighbors,
			IList<IRange> barriers)
		{
			BounceAllNeighbors(entity, neighbors);
			BounceAllBarriers(entity, barriers);
			ApplyFriction(entity);
		}
	}
}