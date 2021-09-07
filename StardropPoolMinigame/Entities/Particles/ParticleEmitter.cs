using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Structures;
using System;
using System.Collections.Generic;

namespace StardropPoolMinigame.Entities
{
    abstract class ParticleEmitter : EntityStatic
    {
        protected QuadTree _quadTree;

        protected float _radius;

        protected float _rateBase;

        protected float _rate;

        protected Vector2 _direction;

        protected bool _active;

        public ParticleEmitter(
            Vector2 anchor,
            float radius,
            float layerDepth,
            float rate,
            bool active = false
        ) : base(
            Origin.TopLeft,
            anchor,
            layerDepth,
            null,
            null)
        {
            this._quadTree = new QuadTree(
                new Primitives.Rectangle(
                    new Vector2(0, 0),
                    RenderConstants.MinigameScreen.WIDTH,
                    RenderConstants.MinigameScreen.HEIGHT));
            this._radius = radius;
            this._rateBase = rate;
            this._rate = rate;
            this._direction = Vector2.Zero;
            this._active = active;

            this.SetDrawer(new ParticleEmitterDrawer(this));
            Timer.StartTimer($"{this.GetId()}-creation-cycle");
        }

        public override string GetId()
        {
            return $"particle-emitter-{this._id}";
        }

        public override void Update()
        {
            base.Update();

            IList<IEntity> particles = this._quadTree.Query();

            QuadTree quadTree = new QuadTree(
                new Primitives.Rectangle(
                    new Vector2(0, 0),
                    RenderConstants.MinigameScreen.WIDTH,
                    RenderConstants.MinigameScreen.HEIGHT));

            foreach (IEntity particle in particles)
            {
                if (particle.GetTransitionState() != TransitionState.Dead)
                {
                    ((Particle)particle).Flock(this._quadTree.Query(((Particle)particle).GetPerception()));
                    ((Particle)particle).Update();
                    if (particle.GetTransitionState() != TransitionState.Dead)
                    {
                        quadTree.Insert(particle);
                    }
                }
            }

            this._quadTree = quadTree;
            if (this._active && Timer.CheckTimer($"{this.GetId()}-creation-cycle") > this._rate)
            {
                Timer.EndTimer($"{this.GetId()}-creation-cycle");
                Timer.StartTimer($"{this.GetId()}-creation-cycle");

                this.AddParticle();
            }
        }

        public void AddParticle()
        {
            Particle particle = this.CreateParticle();

            this._quadTree.Insert(particle);
        }

        public abstract Particle CreateParticle();

        public override float GetTotalHeight()
        {
            return 0;
        }

        public override float GetTotalWidth()
        {
            return 0;
        }

        public float GetRate()
        {
            return this._rate;
        }

        public void SetRate(float rate)
        {
            this._rate = rate * this._rateBase;
        }

        public float GetRadius()
        {
            return this._radius;
        }

        public void SetRadius(float radius)
        {
            this._radius = radius;
        }

        public IList<IEntity> GetEntities()
        {
            return this._quadTree.Query();
        }

        public bool IsActive()
        {
            return this._active;
        }

        public void SetActive(bool state)
        {
            this._active = state;
        }

        protected Vector2 GetPositionInCreationWindow()
        {
            return Vector2.Add(this._anchor, new Vector2(Helpers.Random.Fraction() * this._radius, Helpers.Random.Fraction() * this._radius));
        }

        public void SetDirection(Vector2 direction)
        {
            this._direction = Operators.RadiansToVector(Operators.VectorToRadians(direction) + (float)(Math.PI / 3));
        }

        protected virtual Vector2 GetMaximumInitialVelocity()
        {
            return this._direction;
        }

        protected virtual Vector2 GetMinimumInitialVelocity()
        {
            return this._direction;
        }
    }
}
