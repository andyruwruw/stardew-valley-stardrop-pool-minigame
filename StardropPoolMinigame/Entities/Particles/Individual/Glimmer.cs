using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    class Glimmer : Particle
    {
        public Glimmer(
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
            GameConstants.Particle.Glimmer.PERCEPTION_RADIUS,
            GameConstants.Particle.Glimmer.ALIGNMENT_STRENGTH,
            GameConstants.Particle.Glimmer.COHESION_STRENGTH,
            GameConstants.Particle.Glimmer.SEPARATION_STRENGTH,
            GameConstants.Particle.Glimmer.MAXIMUM_VELOCITY,
            Vector2.Multiply(maximumInitialVelcity, GameConstants.Particle.Glimmer.MAXIMUM_INITIAL_VELOCITY_SCOLAR),
            Vector2.Multiply(minimumInitialVelcity, GameConstants.Particle.Glimmer.MINIMUM_INITIAL_VELOCITY_SCOLAR),
            GameConstants.Particle.Glimmer.LIFESPAN)
        {
        }

        public override string GetId()
        {
            return $"particle-glimmer-{this._id}";
        }

        public override float GetTotalHeight()
        {
            return Textures.Particle.Glimmer.FRAME_1.Height;
        }

        public override float GetTotalWidth()
        {
            return Textures.Particle.Glimmer.FRAME_1.Width;
        }
    }
}
