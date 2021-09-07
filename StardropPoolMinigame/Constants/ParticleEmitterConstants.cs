using Microsoft.Xna.Framework;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;

namespace StardropPoolMinigame.Constants
{
    class ParticleEmitterConstants
    {
        public class Cue
        {
            public static ParticleEmitter GetParticleEmitter(CueType type, float layerDepth)
            {
                switch (type)
                {
                    case CueType.Flames:
                        return new SparkEmitter(
                            Vector2.Zero,
                            5,
                            layerDepth - 0.0001f,
                            5);
                    default:
                        return new SparkEmitter(
                            Vector2.Zero,
                            1,
                            layerDepth - 0.0001f,
                            1);
                }
            }
        }
    }
}
