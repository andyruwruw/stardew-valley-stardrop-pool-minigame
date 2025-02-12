using Microsoft.Xna.Framework;
using MinigameFramework.Render.Filters.Animations;

namespace StardopPoolMinigame.Render.Filters.Animations
{
    class BallFlashingAnimation : Animation
    {
        /// <summary>
        /// Instantiates the animation.
        /// </summary>
        public BallFlashingAnimation(
            string key,
            int intervalLength = 50
        ) : base (
            key,
            intervalLength
        ) { }

        /// <inheritdoc cref="IFilter.GetName"/>
        public override string GetName()
        {
            return "ball-flashing";
        }

        /// <inheritdoc cref="IFilter.GetColor"/>
        public override Color GetColor(Color color)
        {
            float progress = GetProgress();

            bool firstHalf = progress <= 0.5f;
            float doubleProgress = progress * 2;

            return new Color(
                (byte)Math.Round(firstHalf ? (doubleProgress * color.R) : color.R - (progress * color.R )),
                (byte)Math.Round(firstHalf ? (doubleProgress * color.G) : color.G - (progress * color.G )),
                (byte)Math.Round(firstHalf ? (doubleProgress * color.B) : color.B - (progress * color.B )),
                (byte)Math.Round(firstHalf ? (doubleProgress * color.A) : color.A - (progress * color.A ))
            );
        }
    }
}
