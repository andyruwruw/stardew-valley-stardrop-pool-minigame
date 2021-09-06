using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    class Particle : EntityBoid
    {

        private int _lifespan;

        public Particle(
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
            Vector2 maxInitialVelocity,
            Vector2 minInitialVelocity,
            int lifespan
        ) : base(
            origin,
            anchor,
            layerDepth,
            enteringTransition,
            exitingTransition,
            perceptionRadius,
            alignmentStrength,
            cohesionStrength,
            separationStrength,
            maxVelocity,
            maxInitialVelocity,
            minInitialVelocity,
            lifespan)
        {
            this._lifespan = lifespan;

            Timer.StartTimer($"{this.GetId()}-lifespan");
        }

        public override void Update()
        {
            base.Update();

            if (this._transitionState != TransitionState.Exiting
                && this._transitionState != TransitionState.Dead
                && Timer.CheckTimer($"{this.GetId()}-lifespan") > this._lifespan)
            {
                Timer.EndTimer($"{this.GetId()}-lifespan");
                if (this._exitingTransition != null)
                {
                    this.SetTransitionState(TransitionState.Exiting, true);
                } else
                {
                    this.SetTransitionState(TransitionState.Dead, true);
                }
            }
        }

        public override string GetId()
        {
            return $"generic-particle-{this._id}";
        }

        public override float GetTotalWidth()
        {
            return Textures.Particle.Spark.FRAME_1.Width;
        }

        public override float GetTotalHeight()
        {
            return Textures.Particle.Spark.FRAME_1.Height;
        }
    }
}
