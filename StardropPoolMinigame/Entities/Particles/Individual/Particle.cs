using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    internal class Particle : EntityPhysics
    {
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
            float maxForce,
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
            maxForce,
            maxInitialVelocity,
            minInitialVelocity,
            lifespan)
        {
        }

        public override string GetId()
        {
            return $"generic-particle-{this._id}";
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