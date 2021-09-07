using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    class Spark : Particle
    {
        private IFilter _sparkAnimation;

        public Spark(
            Vector2 anchor,
            float layerDepth,
            IFilter enteringTransition,
            IFilter exitingTransition,
            Vector2 maximumInitialVelcity,
            Vector2 minimumInitialVelcity
        ) : base(
            Origin.CenterCenter,
            anchor,
            layerDepth,
            enteringTransition,
            exitingTransition,
            GameConstants.Particle.Spark.PERCEPTION_RADIUS,
            GameConstants.Particle.Spark.ALIGNMENT_STRENGTH,
            GameConstants.Particle.Spark.COHESION_STRENGTH,
            GameConstants.Particle.Spark.SEPARATION_STRENGTH,
            GameConstants.Particle.Spark.MAXIMUM_VELOCITY,
            GameConstants.Particle.Spark.MAXIMUM_FORCE,
            Vector2.Multiply(maximumInitialVelcity, GameConstants.Particle.Spark.MAXIMUM_INITIAL_VELOCITY_SCOLAR),
            Vector2.Multiply(minimumInitialVelcity, GameConstants.Particle.Spark.MINIMUM_INITIAL_VELOCITY_SCOLAR),
            GameConstants.Particle.Spark.LIFESPAN)
        {
            this._sparkAnimation = new SparkAnimation(this.GetId());
            this._filters.Add(this._sparkAnimation);

            this.SetDrawer(new SparkDrawer(this));
        }

        public override string GetId()
        {
            return $"particle-spark-{this._id}";
        }

        public override float GetTotalHeight()
        {
            return Textures.Particle.Spark.FRAME_1.Height;
        }

        public override float GetTotalWidth()
        {
            return Textures.Particle.Spark.FRAME_1.Width;
        }
    }
}
