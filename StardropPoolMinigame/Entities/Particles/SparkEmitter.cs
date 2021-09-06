using Microsoft.Xna.Framework;

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
                this._enteringTransition,
                this._exitingTransition,
                this.GetMaximumInitialVelocity(),
                this.GetMinimumInitialVelocity());
        }
    }
}
