using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Structures;
using StardropPoolMinigame.Utilities;
using System;
using System.Collections.Generic;

namespace StardropPoolMinigame.Entities
{
    internal abstract class ParticleEmitter : Entity
    {
        protected bool _active;

        protected Vector2 _direction;

        protected QuadTree<Particle> _quadTree;

        protected float _radius;

        protected float _rate;

        protected float _rateBase;

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
            this._quadTree = new QuadTree<Particle>(
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

        public void AddParticle()
        {
            Particle particle = this.CreateParticle();

            this._quadTree.Insert(particle.GetAnchor(), particle);
        }

        public abstract Particle CreateParticle();

        public IList<Particle> GetEntities()
        {
            return this._quadTree.Query();
        }

        public override string GetId()
        {
            return $"particle-emitter-{this._id}";
        }

        public float GetRadius()
        {
            return this._radius;
        }

        public float GetRate()
        {
            return this._rate;
        }

        public override float GetTotalHeight()
        {
            return 0;
        }

        public override float GetTotalWidth()
        {
            return 0;
        }

        public bool IsActive()
        {
            return this._active;
        }

        public void SetActive(bool state)
        {
            this._active = state;
        }

        public void SetDirection(Vector2 direction)
        {
            this._direction = VectorHelper.RadiansToVector(VectorHelper.VectorToRadians(direction) + (float)(Math.PI / 3));
        }

        public void SetRadius(float radius)
        {
            this._radius = radius;
        }

        public void SetRate(float rate)
        {
            this._rate = rate * this._rateBase;
        }

        public override void Update()
        {
            base.Update();

            IList<Particle> particles = this._quadTree.Query();

            QuadTree<Particle> quadTree = new QuadTree<Particle>(
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

        protected virtual Vector2 GetMaximumInitialVelocity()
        {
            return this._direction;
        }

        protected virtual Vector2 GetMinimumInitialVelocity()
        {
            return this._direction;
        }

        protected Vector2 GetPositionInCreationWindow()
        {
            return Vector2.Add(this._anchor, new Vector2(MiscellaneousHelper.Random() * this._radius, MiscellaneousHelper.Random() * this._radius));
        }
    }
}