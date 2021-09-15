using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Primitives;
using StardropPoolMinigame.Structures;
using System;
using System.Collections.Generic;

namespace StardropPoolMinigame.Behaviors.Physics
{
    /// <summary>
    /// <para><inheritdoc cref="Physics"/></para>
    /// <para>Resembles real life physics.</para>
    /// </summary>
    internal class NewtonianPhysics : Physics
    {
        public NewtonianPhysics() : base()
        {
        }

        /// <inheritdoc cref="IPhysics.HasTangibleInteractions"/>
        public override bool HasTangibleInteractions()
        {
            return true;
        }

        /// <inheritdoc cref="Physics.TangibleInteractions(IGraph{EntityPhysics}, Table)"/>
        public override Tuple<IGraph<EntityPhysics>, bool> TangibleInteractions(IGraph<EntityPhysics> graph, Table table)
        {
            QuadTree<EntityPhysics> newGraph = new QuadTree<EntityPhysics>(
                new Primitives.Rectangle(
                    Vector2.Zero,
                    RenderConstants.MinigameScreen.WIDTH,
                    RenderConstants.MinigameScreen.HEIGHT));

            IList<EntityPhysics> balls = ((QuadTree<EntityPhysics>)graph).Query();
            IDictionary<EntityPhysics, IList<EntityPhysics>> collisionsHandled = new Dictionary<EntityPhysics, IList<EntityPhysics>>();

            bool finishedMoving = true;

            foreach (Ball ball in balls)
            {
                if (finishedMoving && VectorHelper.GetMagnitude(ball.GetVelocity()) != 0)
                {
                    finishedMoving = false;
                }

                IList<EntityPhysics> neighbors = ((QuadTree<EntityPhysics>)graph).Query(this.GetTangiblePerception(ball));
                IList<EntityPhysics> filteredNeighbors = new List<EntityPhysics>();

                TableSegment tableSegment = table.GetTableSegmentFromPosition(ball.GetAnchor());
                IList<IRange> barriers = tableSegment.GetBounceableSurfaces();

                foreach (Ball neighbor in neighbors)
                {
                    if (this.HasTangibleInteractions()
                        && (collisionsHandled.ContainsKey(neighbor)
                        && !collisionsHandled[neighbor].Contains(ball))
                        || !collisionsHandled.ContainsKey(neighbor))
                    {
                        filteredNeighbors.Add(neighbor);
                    }
                }

                this.InteractWithTangible(ball, filteredNeighbors, barriers);
                this.CheckIfPocketed(ball, tableSegment);
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
        protected override void InteractWithTangible(EntityPhysics entity, IList<EntityPhysics> neighbors, IList<IRange> barriers)
        {
            this.BounceAllNeighbors(entity, neighbors);
            this.BounceAllBarriers(entity, barriers);
        }
    }
}