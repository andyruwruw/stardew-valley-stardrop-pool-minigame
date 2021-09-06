using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using System;

namespace StardropPoolMinigame.Render.Filters
{
    class SparkAnimation : Animation
    {
        public SparkAnimation(string key) : base(key, RenderConstants.Entities.Particle.Spark.FRAMES * RenderConstants.Entities.Particle.Spark.FRAME_DURATION)
        {
        }

        public override Rectangle ExecuteSource(Rectangle source)
        {
            switch (Math.Floor(this.GetProgress() * RenderConstants.Entities.Particle.Spark.FRAMES))
            {
                case 1:
                    return Textures.Particle.Spark.FRAME_2;
                case 2:
                    return Textures.Particle.Spark.FRAME_3;
                default:
                    return Textures.Particle.Spark.FRAME_1;
            }
        }
    }
}
