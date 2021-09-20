using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Primitives;
using StardropPoolMinigame.Structures;
using Rectangle = StardropPoolMinigame.Primitives.Rectangle;

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

		/// <inheritdoc cref="Physics.TangibleInteractions(IGraph{EntityPhysics}, Table)"/>
		public override Tuple<IGraph<EntityPhysics>, bool> TangibleInteractions(
			IGraph<EntityPhysics> graph,
			Table table)
		{
			var newGraph = new QuadTree<EntityPhysics>(
				new Rectangle(
					Vector2.Zero,
					RenderConstants.MinigameScreen.Width,
					RenderConstants.MinigameScreen.Height));

			var balls = ((QuadTree<EntityPhysics>) graph).Query();
			IDictionary<EntityPhysics, IList<EntityPhysics>> collisionsHandled = new Dictionary<EntityPhysics, IList<EntityPhysics>>();

			var finishedMoving = true;

			foreach (Ball ball in balls)
            {
				if (finishedMoving && VectorHelper.GetMagnitude(ball.GetVelocity()) != 0)
				{
					finishedMoving = false;
				}

				var boundary = GetTangiblePerception(ball);
				var neighbors = ((QuadTree<EntityPhysics>) graph).Query(new Circle(boundary.GetCenter(), ((Circle)boundary).GetRadius() * 2));

				IList<EntityPhysics> filteredNeighbors = new List<EntityPhysics>();

				var tableSegment = table.GetTableSegmentFromPosition(ball.GetAnchor());
				var barriers = tableSegment.GetBounceableSurfaces();

				foreach (Ball neighbor in neighbors)
				{
					if (HasTangibleInteractions()
						&& collisionsHandled.ContainsKey(neighbor)
						&& !collisionsHandled[neighbor].Contains(ball)
						|| !collisionsHandled.ContainsKey(neighbor))
					{
						filteredNeighbors.Add(neighbor);
					}
				}

				InteractWithTangible(ball, filteredNeighbors, barriers);
				CheckIfPocketed(ball, tableSegment);
				collisionsHandled.Add(ball, neighbors);

				if (!ball.IsPocketed())
				{
					newGraph.Insert(ball.GetAnchor(), ball);
				}
			}

            return new Tuple<IGraph<EntityPhysics>, bool>(newGraph, finishedMoving);
		}

		/// <inheritdoc cref="IPhysics.GetTangiblePerception(EntityPhysics)"/>
		protected override IRange GetTangiblePerception(EntityPhysics entity)
		{
			return entity.GetBoundary();
		}

		/// <inheritdoc cref="Physics.InteractWithTangible(EntityPhysics, IList{EntityPhysics}, IList{IRange})"/>
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