using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Primitives;
using StardropPoolMinigame.Render.Filters;
using System;
using System.Collections.Generic;

namespace StardropPoolMinigame.Entities
{
    abstract class EntityBoid : Entity
    {
        protected Circle _perception;

        protected Vector2 _velocity;

        protected Vector2 _acceleration;

        protected float _maxVelocity;

        protected float _maxForce;

        protected float _alignmentStrength;

        protected float _cohesionStrength;

        protected float _separationStrength;

        protected int _duration;

        public EntityBoid(
            Origin origin,
            Vector2 anchor,
            float layerDepth,
            IFilter enteringTransition,
            IFilter exitingTransition,
            float perceptionRadius,
            float alignmentStrength,
            float cohesionStrength,
            float separationStrength,
            float maxVelocity,
            float maxForce,
            Vector2 maxInitialVelocity,
            Vector2 minInitialVelocity,
            int duration
        ) : base(
            origin,
            anchor,
            layerDepth,
            enteringTransition,
            exitingTransition)
        {
            this._maxVelocity = maxVelocity;
            this._maxForce = maxForce;
            this._alignmentStrength = alignmentStrength;
            this._cohesionStrength = cohesionStrength;
            this._separationStrength = separationStrength;
            this._duration = duration;

            this._perception = new Circle(Vector2.Add(this.GetTopLeft(), new Vector2(this.GetTotalWidth() / 2, this.GetTotalHeight() / 2)), perceptionRadius);
            this._acceleration = new Vector2(
                Helpers.Random.Fraction() * (maxInitialVelocity.X - minInitialVelocity.X) + minInitialVelocity.X,
                Helpers.Random.Fraction() * (maxInitialVelocity.Y - minInitialVelocity.Y) + minInitialVelocity.Y);

            Timer.StartTimer($"{this.GetId()}-lifetime");
        }

        public override string GetId()
        {
            return $"generic-boid-entity-{this._id}";
        }

        public override void Update()
        {
            base.Update();

            this._anchor = Vector2.Add(this._anchor, this._velocity);
            this._velocity = Vector2.Add(this._velocity, this._acceleration);
            this._acceleration = Vector2.Zero;

            if (Math.Abs(Operators.GetMagnitude(this._velocity)) > this._maxVelocity)
            {
                this._velocity = Vector2.Multiply(Vector2.Normalize(this._velocity), this._maxVelocity);
            }

            this._perception.SetCenter(this.GetCenter());

            if (this._transitionState != TransitionState.Exiting
                && this._transitionState != TransitionState.Dead
                && Timer.CheckTimer($"{this.GetId()}-lifetime") > this._duration)
            {
                this.SetTransitionState(TransitionState.Exiting, true);
            }
        }

        public void Flock(IList<IEntity> neighbors)
        {
            IList<EntityBoid> filtered = new List<EntityBoid>();

            foreach (IEntity boid in neighbors)
            {
                if (boid.GetId() != this.GetId())
                {
                    float distance = (float)Distance.Pythagorean(this.GetPerceptionCenter(), ((EntityBoid)boid).GetPerceptionCenter());

                    if (distance < this._perception.GetRadius())
                    {
                        filtered.Add((EntityBoid)boid);
                    }
                }
            }

            Vector2 alignmentChange = Vector2.Multiply(
                this.Align(filtered),
                this._alignmentStrength);
            Vector2 separationChange = Vector2.Multiply(
                this.Separation(filtered),
                this._separationStrength);
            Vector2 cohesionChange = Vector2.Multiply(
                this.Cohesion(filtered),
                this._cohesionStrength);

            this._acceleration = Vector2.Add(
                this._acceleration,
                alignmentChange);
            this._acceleration = Vector2.Add(
                this._acceleration,
                separationChange);
            this._acceleration = Vector2.Add(
                this._acceleration,
                cohesionChange);

            if (Math.Abs(Operators.GetMagnitude(this._acceleration)) > Math.Abs(this._maxForce)) {
                this._acceleration = Vector2.Multiply(Vector2.Normalize(this._acceleration), this._maxForce);
            }
        }

        public Vector2 Align(IList<EntityBoid> neighbors)
        {
            Vector2 steering = Vector2.Zero;
            int total = 0;

            foreach (EntityBoid boid in neighbors)
            {
                steering = Vector2.Add(steering, boid.GetVelocity());

                total += 1;
            }

            if (steering.X == 0 && steering.Y == 0)
            {
                return steering;
            }
            
            steering = Vector2.Divide(steering, total);
            steering = Vector2.Multiply(Vector2.Normalize(steering), this._maxVelocity);
            steering = Vector2.Subtract(steering, this._velocity);

            return steering;
        }

        public Vector2 Separation(IList<EntityBoid> neighbors)
        {
            Vector2 steering = Vector2.Zero;
            int total = 0;

            foreach (EntityBoid boid in neighbors)
            {
                float distance = (float)Distance.Pythagorean(this.GetPerceptionCenter(), boid.GetPerceptionCenter());

                Vector2 diff = Vector2.Subtract(this.GetPerceptionCenter(), boid.GetPerceptionCenter());
                diff = Vector2.Multiply(diff, distance * distance);

                steering = Vector2.Add(steering, diff);

                total += 1;
            }

            if (steering.X == 0 && steering.Y == 0)
            {
                return steering;
            }

            steering = Vector2.Divide(steering, total);
            steering = Vector2.Multiply(Vector2.Normalize(steering), this._maxVelocity);
            steering = Vector2.Subtract(steering, this._velocity);

            return steering;
        }

        public Vector2 Cohesion(IList<EntityBoid> neighbors)
        {
            Vector2 steering = Vector2.Zero;
            int total = 0;

            foreach (EntityBoid boid in neighbors)
            {
                steering = Vector2.Add(steering, boid.GetCenter());

                total += 1;
            }

            if (steering.X == 0 && steering.Y == 0)
            {
                return steering;
            }

            steering = Vector2.Divide(steering, total);
            steering = Vector2.Subtract(steering, this.GetCenter());
            steering = Vector2.Multiply(Vector2.Normalize(steering), this._maxVelocity);
            steering = Vector2.Subtract(steering, this._velocity);

            return steering;
        }

        public Vector2 GetPerceptionCenter()
        {
            return this._perception.GetCenter();
        }
        
        public Vector2 GetVelocity()
        {
            return this._velocity;
        }

        public int GetDuration()
        {
            return this._duration;
        }

        public Circle GetPerception()
        {
            return this._perception;
        }
    }
}
