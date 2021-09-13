using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Primitives;
using System;
using System.Collections.Generic;

namespace StardropPoolMinigame.Behaviors.Physics
{
    /// <inheritdoc cref="IPhysics"/>
    abstract class Physics : IPhysics
    {
        /// <summary>
        /// Instantiates a physics system, or rules of interactions.
        /// </summary>
        public Physics()
        {
        }

        /// <inheritdoc cref="IPhysics.HasIntangibleInteractions"/>
        public virtual bool HasIntangibleInteractions()
        {
            return false;
        }

        /// <inheritdoc cref="IPhysics.HasTangibleInteractions"/>
        public virtual bool HasTangibleInteractions()
        {
            return false;
        }

        /// <inheritdoc cref="IPhysics.GetIntangiblePerception(EntityPhysics)"/>
        public virtual IRange GetIntangiblePerception(EntityPhysics entity)
        {
            return new Circle(entity.GetAnchor(), 0f);
        }

        /// <inheritdoc cref="IPhysics.GetTangiblePerception(EntityPhysics)"/>
        public virtual IRange GetTangiblePerception(EntityPhysics entity)
        {
            return new Circle(entity.GetAnchor(), 0f);
        }

        /// <inheritdoc cref="IPhysics.InteractWithIntangible(EntityPhysics, IList{EntityPhysics}, IList{IRange})"/>
        public virtual void InteractWithIntangible(EntityPhysics entity, IList<EntityPhysics> neighbors, IList<IRange> barriers)
        {
        }

        /// <inheritdoc cref="IPhysics.InteractWithTangible(EntityPhysics, IList{EntityPhysics}, IList{IRange})"/>
        public virtual void InteractWithTangible(EntityPhysics entity, IList<EntityPhysics> neighbors, IList<IRange> barriers)
        {
        }

        /// <summary>
        /// <see cref="Bounce(EntityPhysics, EntityPhysics, bool)"/> off all neighbors.
        /// </summary>
        /// <param name="entity">Main <see cref="EntityPhysics"/></param>
        /// <param name="neighbors">Neighboring <see cref="EntityPhysics"/> within the main <see cref="EntityPhysics"/> tangible perception radius</param>
        protected virtual void BounceAllNeighbors(EntityPhysics entity, IList<EntityPhysics> neighbors)
        {
            foreach (EntityPhysics neighbor in neighbors)
            {
                if (entity.GetId() != neighbor.GetId())
                {
                    bool offsetOnly = (Math.Abs(VectorHelper.GetMagnitude(entity.GetVelocity())) + Math.Abs(VectorHelper.GetMagnitude(neighbor.GetVelocity())) < GameConstants.Ball.MINIMUM_BOUNCE_VELOCITY * 2);

                    this.Bounce(entity, neighbor, offsetOnly);

                    if (!offsetOnly)
                    {
                        entity.CollisionCallback(neighbor);
                    }
                }
            }
        }

        /// <summary>
        /// <see cref="Bounce(EntityPhysics, EntityPhysics, bool)"/> off all barriers.
        /// </summary>
        /// <param name="entity">Main <see cref="EntityPhysics"/></param>
        /// <param name="barriers">Neighboring <see cref="IRange">IRanges</see> within the main <see cref="EntityPhysics"/> tangible perception radius</param>
        protected virtual void BounceAllBarriers(EntityPhysics entity, IList<IRange> barriers)
        {
            foreach (Line bounceableSurface in barriers)
            {
                if (bounceableSurface.Intersects(entity.GetBoundary()))
                {
                    this.Bounce(entity, bounceableSurface);

                    entity.CollisionCallback(bounceableSurface);
                }
            }
        }

        /// <summary>
        /// Bounces two <see cref="EntityPhysics"/> together with realistic physics.
        /// </summary>
        /// <param name="entity1">First <see cref="EntityPhysics"/> in collision</param>
        /// <param name="entity2">Second <see cref="EntityPhysics"/> in collision</param>
        /// <param name="offsetOnly">Whether to only ensure the balls do not overlap</param>
        protected virtual void Bounce(EntityPhysics entity1, EntityPhysics entity2, bool offsetOnly = false)
        {
            Vector2 angle = Vector2.Normalize(Vector2.Subtract(entity1.GetAnchor(), entity2.GetAnchor()));

            // Alter velocity
            if (!offsetOnly)
            {
                float momentum = this.GetMomentum(entity1, entity2, angle);

                Vector2 ball1ResultingVelocity = Vector2.Subtract(
                    entity1.GetVelocity(),
                    Vector2.Multiply(
                        angle,
                        new Vector2(
                            (float)momentum * (entity2.GetMass()),
                            (float)momentum * (entity2.GetMass()))));
                Vector2 ball2ResultingVelocity = Vector2.Add(
                    entity2.GetVelocity(),
                    Vector2.Multiply(
                        angle,
                        new Vector2(
                            (float)momentum * (entity1.GetMass()),
                            (float)momentum * (entity1.GetMass()))));

                entity1.SetVelocity(ball1ResultingVelocity);
                entity2.SetVelocity(ball2ResultingVelocity);
            }

            // Prevent overlap
            float overlapping = (float)(VectorHelper.Pythagorean(entity1.GetAnchor(), entity2.GetAnchor()) - GameConstants.Ball.RADIUS * 2);

            entity1.SetAnchor(Vector2.Add(entity1.GetAnchor(), Vector2.Multiply(Vector2.Negate(angle), overlapping / 1.9f)));
            entity2.SetAnchor(Vector2.Add(entity2.GetAnchor(), Vector2.Multiply(angle, overlapping / 1.9f)));
        }

        /// <summary>
        /// Bounces an <see cref="EntityPhysics"/> against a <see cref="Line"/> with realistic physics.
        /// </summary>
        /// <param name="entity"><see cref="EntityPhysics"/> in collision</param>
        /// <param name="bounceableSurface">Bounceable surface as <see cref="Line"/></param>
        protected virtual void Bounce(EntityPhysics entity, Line bounceableSurface)
        {
            float length = bounceableSurface.GetLength();
            float dotProduct = (float)((((entity.GetAnchor().X - bounceableSurface.GetStart().X) * (bounceableSurface.GetEnd().X - bounceableSurface.GetStart().X)) + ((entity.GetAnchor().Y - bounceableSurface.GetStart().Y) * (bounceableSurface.GetEnd().Y - bounceableSurface.GetStart().Y))) / Math.Pow(length, 2));

            Vector2 closestPoint = new Vector2(
                bounceableSurface.GetStart().X + (dotProduct * (bounceableSurface.GetEnd().X - bounceableSurface.GetStart().X)),
                bounceableSurface.GetStart().Y + (dotProduct * (bounceableSurface.GetEnd().Y - bounceableSurface.GetStart().Y)));

            Vector2 collisionNormal = Vector2.Normalize(Vector2.Subtract(closestPoint, entity.GetAnchor()));
            Vector2 reflectedVelocity = Vector2.Reflect(entity.GetVelocity(), collisionNormal);

            entity.SetVelocity(reflectedVelocity);

            float overlapping = (float)(VectorHelper.Pythagorean(entity.GetAnchor(), closestPoint) - GameConstants.Ball.RADIUS);

            entity.SetAnchor(Vector2.Add(entity.GetAnchor(), Vector2.Multiply(collisionNormal, overlapping / 1.9f)));
        }

        /// <summary>
        /// Calculates collision force of <see cref="EntityPhysics"/>.
        /// </summary>
        /// <param name="entity1"><see cref="EntityPhysics"/> in collision</param>
        /// <param name="angle">Angle of collision as <see cref="Vector2"/></param>
        /// <returns>Collision force of <see cref="EntityPhysics"/></returns>
        protected virtual float GetCollisionForce(EntityPhysics entity, Vector2 angle)
        {
            return Vector2.Dot(entity.GetVelocity(), angle);
        }

        /// <summary>
        /// Calculates momentum between two <see cref="EntityPhysics"/>.
        /// </summary>
        /// <param name="entity1">First <see cref="EntityPhysics"/> in collision</param>
        /// <param name="entity2">Second <see cref="EntityPhysics"/> in collision</param>
        /// <param name="angle">Angle of collision as <see cref="Vector2"/></param>
        /// <returns>Momentum between the <see cref="EntityPhysics"/></returns>
        protected float GetMomentum(EntityPhysics entity1, EntityPhysics entity2, Vector2 angle)
        {
            return ((float)2.0 * (this.GetCollisionForce(entity1, angle) - this.GetCollisionForce(entity2, angle)) / (entity1.GetMass() + entity2.GetMass()));
        }

        /// <summary>
        /// <see cref="EntityPhysics"/> attempt to align their velocities with one another.
        /// </summary>
        /// <param name="neighbors">Neighboring <see cref="EntityPhysics"/> within the main <see cref="EntityPhysics"/> intangible perception radius</param>
        /// <returns>Alignment <see cref="Vector2"/> to add to acceleration</returns>
        protected Vector2 Align(EntityPhysics entity, IList<EntityPhysics> neighbors)
        {
            Vector2 steering = Vector2.Zero;
            int total = 0;

            foreach (EntityPhysics boid in neighbors)
            {
                steering = Vector2.Add(steering, boid.GetVelocity());

                total += 1;
            }

            if (steering.X == 0 && steering.Y == 0)
            {
                return steering;
            }

            steering = Vector2.Divide(steering, total);
            steering = Vector2.Multiply(Vector2.Normalize(steering), entity.GetMaximumVelocity());
            steering = Vector2.Subtract(steering, entity.GetVelocity());

            return steering;
        }

        /// <summary>
        /// <see cref="EntityPhysics"/> attempt to not get to close to one another.
        /// </summary>
        /// <param name="neighbors">Neighboring <see cref="EntityPhysics"/> within the main <see cref="EntityPhysics"/> intangible perception radius</param>
        /// <returns>Separation <see cref="Vector2"/> to add to acceleration</returns>
        protected Vector2 Separation(EntityPhysics entity, IList<EntityPhysics> neighbors)
        {
            Vector2 steering = Vector2.Zero;
            int total = 0;

            foreach (EntityPhysics boid in neighbors)
            {
                float distance = (float)VectorHelper.Pythagorean(entity.GetAnchor(), boid.GetAnchor());

                Vector2 diff = Vector2.Subtract(entity.GetAnchor(), boid.GetAnchor());
                diff = Vector2.Multiply(diff, distance * distance);

                steering = Vector2.Add(steering, diff);

                total += 1;
            }

            if (steering.X == 0 && steering.Y == 0)
            {
                return steering;
            }

            steering = Vector2.Divide(steering, total);
            steering = Vector2.Multiply(Vector2.Normalize(steering), entity.GetMaximumVelocity());
            steering = Vector2.Subtract(steering, entity.GetVelocity());

            return steering;
        }

        /// <summary>
        /// <see cref="EntityPhysics"/> attempt to drift towards the center off mass.
        /// </summary>
        /// <param name="neighbors">Neighboring <see cref="EntityPhysics"/> within the main <see cref="EntityPhysics"/> intangible perception radius</param>
        /// <returns>Cohesion <see cref="Vector2"/> to add to acceleration</returns>
        protected Vector2 Cohesion(EntityPhysics entity, IList<EntityPhysics> neighbors)
        {
            Vector2 steering = Vector2.Zero;
            int total = 0;

            foreach (EntityPhysics boid in neighbors)
            {
                steering = Vector2.Add(steering, boid.GetAnchor());

                total += 1;
            }

            if (steering.X == 0 && steering.Y == 0)
            {
                return steering;
            }

            steering = Vector2.Divide(steering, total);
            steering = Vector2.Subtract(steering, entity.GetAnchor());
            steering = Vector2.Multiply(Vector2.Normalize(steering), entity.GetMaximumVelocity());
            steering = Vector2.Subtract(steering, entity.GetVelocity());

            return steering;
        }
    }
}
