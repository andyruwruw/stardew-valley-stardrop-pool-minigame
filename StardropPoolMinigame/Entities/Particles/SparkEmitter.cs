using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Helpers;
using System;

namespace StardropPoolMinigame.Entities
{
    internal class SparkEmitter : ParticleEmitter
    {
        public SparkEmitter(
            Vector2 anchor,
            float radius,
            float layerDepth,
            float rate
        ) : base(
            anchor,
            radius,
            layerDepth,
            rate)
        {
        }

        public override Particle CreateParticle()
        {
            return new Spark(
                this.GetPositionInCreationWindow(),
                this._layerDepth,
                TransitionConstants.Game.Sparks.Entering(),
                TransitionConstants.Game.Sparks.Exiting(),
                this.GetMaximumInitialVelocity(),
                this.GetMinimumInitialVelocity());
        }

        public override string GetId()
        {
            return $"spark-emitter-{this._id}";
        }

        protected override Vector2 GetMaximumInitialVelocity()
        {
            return VectorHelper.RadiansToVector(VectorHelper.VectorToRadians(this._direction) - (float)(Math.PI / 3));
        }

        protected override Vector2 GetMinimumInitialVelocity()
        {
            return VectorHelper.RadiansToVector(VectorHelper.VectorToRadians(this._direction) + (float)(Math.PI / 3));
        }
    }
}