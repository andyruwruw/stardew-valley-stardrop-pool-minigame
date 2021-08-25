using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using System;

namespace StardropPoolMinigame.Render.Filters
{
    class SlideIn : Transition
    {
        private Vector2 _difference;

        public SlideIn(
            int duration,
            bool keyframeOpacity,
            Vector2 difference
        ) : base(duration, keyframeOpacity)
        {
            this._difference = difference;
        }

        public SlideIn(
            int duration,
            int delay,
            bool keyframeOpacity,
            Vector2 difference
        ) : base(
            duration,
            keyframeOpacity,
            delay)
        {
            this._difference = difference;
        }

        public override string GetName()
        {
            return "slide-in";
        }

        public override Vector2 ExecuteDestination(Vector2 destination)
        {
            return new Vector2(
                this.EaseOut(
                    this.GetInvertedProgress() * this._duration,
                    destination.X,
                    this._difference.X * RenderConstants.TileScale(),
                    this._duration),
                this.EaseOut(
                    this.GetInvertedProgress() * this._duration, 
                    destination.Y,
                    this._difference.Y * RenderConstants.TileScale(),
                    this._duration));
        }

        public override Color ExecuteColor(Color color)
        {
            if (this._keyframeOpacity)
            {
                float progress = this.GetProgress();

                return new Color(
                    (byte)Math.Round(progress * color.R),
                    (byte)Math.Round(progress * color.G),
                    (byte)Math.Round(progress * color.B),
                    (byte)Math.Round(progress * 255));
            }
            return color;
        }
    }
}
