using Microsoft.Xna.Framework;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Primitives;
using System.Collections.Generic;

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

        /// <inheritdoc cref="Physics.InteractWithIntangible(EntityPhysics, IList{EntityPhysics}, IList{IRange})"/>
        protected override void InteractWithIntangible(EntityPhysics entity, IList<EntityPhysics> neighbors, IList<IRange> barriers)
        {
            entity.AddAcceleration(Vector2.Multiply(
                this.Align(entity, neighbors),
                this._alignmentStrength));
            entity.AddAcceleration(Vector2.Multiply(
                this.Separation(entity, neighbors),
                this._separationStrength));
            entity.AddAcceleration(Vector2.Multiply(
                this.Cohesion(entity, neighbors),
                this._cohesionStrength));
        }
    }
}