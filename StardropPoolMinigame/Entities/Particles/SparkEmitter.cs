using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Helpers;
using System;

namespace StardropPoolMinigame.Entities
{
    class SparkEmitter : ParticleEmitter
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

        public override string GetId()
        {
            return $"spark-emitter-{this._id}";
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

        protected override Vector2 GetMaximumInitialVelocity()
        {
            return Operators.RadiansToVector(Operators.VectorToRadians(this._direction) - (float)(Math.PI / 3));
        }

        protected override Vector2 GetMinimumInitialVelocity()
        {
            return Operators.RadiansToVector(Operators.VectorToRadians(this._direction) + (float)(Math.PI / 3));
        }
    }
}
