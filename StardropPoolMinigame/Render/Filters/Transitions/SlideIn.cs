using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using System;

namespace StardropPoolMinigame.Render.Filters
{
    class SlideIn : Transition
    {
        private Vector2 _difference;

        public SlideIn(
            int duration,
            bool keyframeOpacity,
            TransitionState type,
            Vector2 difference
        ) : base(
            duration,
            keyframeOpacity,
            type)
        {
            this._difference = difference;
        }

        public SlideIn(
            int duration,
            bool keyframeOpacity,
            TransitionState type,
            int delay,
            Vector2 difference,
            bool delayOnce = false
        ) : base(
            duration,
            keyframeOpacity,
            type,
            delay,
            delayOnce)
        {
            this._difference = difference;
        }

        public override string GetName()
        {
            return "slide-in";
        }

        public override Vector2 ExecuteDestination(Vector2 destination)
        {
            float progress = this._type == TransitionState.Entering ? this.GetInvertedProgress() : this.GetProgress();

            return new Vector2(
                this.EaseOut(
                    progress * this._duration,
                    destination.X,
                    this._difference.X * RenderConstants.TileScale(),
                    this._duration),
                this.EaseOut(
                    progress * this._duration, 
                    destination.Y,
                    this._difference.Y * RenderConstants.TileScale(),
                    this._duration));
        }

        public override Color ExecuteColor(Color color)
        {
            if (this._keyframeOpacity)
            {
                float progress = this._type == TransitionState.Entering ? this.GetProgress() : this.GetInvertedProgress();

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
