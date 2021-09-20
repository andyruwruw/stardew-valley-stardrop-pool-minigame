using System;
using Microsoft.Xna.Framework;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Primitives;
using System.Collections.Generic;
using StardropPoolMinigame.Structures;
using StardropPoolMinigame.Constants;

namespace StardropPoolMinigame.Behaviors.Physics
{
    /// <summary>
    /// <para><inheritdoc cref="Physics"/></para>
    /// <para>Flocking simulation.</para>
    /// </summary>
    internal class FlockingPhysics : Physics
    {
        /// <summary>
        /// How strong alignment impacts acceleration (multiplier).
        /// </summary>
        private float _alignmentStrength;

        /// <summary>
        /// How strong cohesion impacts acceleration (multiplier).
        /// </summary>
        private float _cohesionStrength;

        /// <summary>
        /// How strong separation impacts acceleration (multiplier).
        /// </summary>
        private float _separationStrength;

        public FlockingPhysics(
            float alignmentStrength,
            float separationStrength,
            float cohesionStrength) : base()
        {
            this._alignmentStrength = alignmentStrength;
            this._separationStrength = separationStrength;
            this._cohesionStrength = cohesionStrength;
        }

        /// <inheritdoc cref="Physics.HasIntangibleInteractions"/>
        public override bool HasIntangibleInteractions()
        {
            return true;
        }

        /// <inheritdoc cref="Physics.GetIntangiblePerception(EntityPhysics)"/>
        protected override IRange GetIntangiblePerception(EntityPhysics entity)
        {
            return new Circle(entity.GetAnchor(), entity.GetIntangibleRadius());
        }

		/// <inheritdoc />
		public override Tuple<IGraph<EntityPhysics>, bool> IntangibleInteractions(IGraph<EntityPhysics> graph, Table table)
		{
			var newGraph = new QuadTree<EntityPhysics>(
				new Primitives.Rectangle(
					Vector2.Zero,
					RenderConstants.MinigameScreen.Width,
					RenderConstants.MinigameScreen.Height));

			var boids = ((QuadTree<EntityPhysics>)graph).Query();

			foreach (EntityPhysics boid in boids)
			{
				var boundary = this.GetIntangiblePerception(boid);
				var neighbors = ((QuadTree<EntityPhysics>)graph).Query(boundary);
				
                this.InteractWithIntangible(boid, neighbors, new List<IRange>());
				newGraph.Insert(boid.GetAnchor(), boid);
			}

			return new Tuple<IGraph<EntityPhysics>, bool>(newGraph, false);
        }

		/// <inheritdoc cref="Physics.InteractWithIntangible(EntityPhysics, IList{EntityPhysics}, IList{IRange})"/>
        protected override void InteractWithIntangible(EntityPhysics entity, IList<EntityPhysics> neighbors, IList<IRange> barriers)
		{
			Vector2 alignment = Vector2.Multiply(
				this.Align(entity, neighbors),
				this._alignmentStrength);
			Vector2 separation = Vector2.Multiply(
				this.Separation(entity, neighbors),
				this._separationStrength);
			Vector2 cohesion = Vector2.Multiply(
				this.Cohesion(entity, neighbors),
				this._cohesionStrength);

			Logger.Info($"{neighbors.Count} {Logger.LogVector2(alignment)}, {Logger.LogVector2(separation)}, {Logger.LogVector2(cohesion)}");
			entity.AddAcceleration(alignment);
            entity.AddAcceleration(separation);
            entity.AddAcceleration(cohesion);
        }
    }
}