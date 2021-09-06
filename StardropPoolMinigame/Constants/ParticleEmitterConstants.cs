using Microsoft.Xna.Framework;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;

namespace StardropPoolMinigame.Constants
{
    class ParticleEmitterConstants
    {
        public class Cue
        {
            public static ParticleEmitter GetParticleEmitter(CueType type)
            {
                switch (type)
                {
                    case CueType.Flames:
                        return new SparkEmitter(
                            Vector2.Zero,
                            5,
                            0.0400f,
                            5);
                    default:
                        return new SparkEmitter(
                            Vector2.Zero,
                            5,
                            0.0400f,
                            5);
                }
            }
        }
    }
}
