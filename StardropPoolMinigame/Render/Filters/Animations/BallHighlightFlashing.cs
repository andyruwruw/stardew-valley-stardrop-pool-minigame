using Microsoft.Xna.Framework;
using System;

namespace StardropPoolMinigame.Render.Filters
{
    internal class BallHighlightFlashing : Animation
    {
        public BallHighlightFlashing(string key) : base(key, 50)
        {
        }

        public override Color ExecuteColor(Color color)
        {
            float progress = this.GetProgress();

            return new Color(
                (byte)Math.Round(progress <= 0.5f ? (progress * color.R * 2) : color.R - ((progress - .5f) * color.R * 2)),
                (byte)Math.Round(progress <= 0.5f ? (progress * color.G * 2) : color.G - ((progress - .5f) * color.G * 2)),
                (byte)Math.Round(progress <= 0.5f ? (progress * color.B * 2) : color.B - ((progress - .5f) * color.B * 2)),
                (byte)Math.Round(progress <= 0.5f ? (progress * color.A * 2) : color.A - ((progress - .5f) * color.A * 2)));
        }
    }
}