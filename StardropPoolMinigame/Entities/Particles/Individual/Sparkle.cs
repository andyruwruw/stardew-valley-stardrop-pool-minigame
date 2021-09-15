using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    internal class Sparkle : Particle
    {
        public Sparkle(
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
            GameConstants.Particle.Sparkle.PERCEPTION_RADIUS,
            GameConstants.Particle.Sparkle.ALIGNMENT_STRENGTH,
            GameConstants.Particle.Sparkle.COHESION_STRENGTH,
            GameConstants.Particle.Sparkle.SEPARATION_STRENGTH,
            GameConstants.Particle.Sparkle.MAXIMUM_VELOCITY,
            GameConstants.Particle.Sparkle.MAXIMUM_FORCE,
            Vector2.Multiply(maximumInitialVelcity, GameConstants.Particle.Sparkle.MAXIMUM_INITIAL_VELOCITY_SCOLAR),
            Vector2.Multiply(minimumInitialVelcity, GameConstants.Particle.Sparkle.MINIMUM_INITIAL_VELOCITY_SCOLAR),
            GameConstants.Particle.Sparkle.LIFESPAN)
        {
        }

        public override string GetId()
        {
            return $"particle-sparkle-{this._id}";
        }

        public override float GetTotalHeight()
        {
            return Textures.Particle.Sparkle.FRAME_1.Height;
        }

        public override float GetTotalWidth()
        {
            return Textures.Particle.Sparkle.FRAME_1.Width;
        }
    }
}