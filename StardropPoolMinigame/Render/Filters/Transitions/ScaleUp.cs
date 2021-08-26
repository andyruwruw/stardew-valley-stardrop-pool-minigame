using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using System;

namespace StardropPoolMinigame.Render.Filters
{
    class ScaleUp : Transition
    {
        private float _startingScale;

        public ScaleUp(
            int duration,
            bool keyframeOpacity,
            TransitionState type,
            float startingScale = 0
        ) : base(
            duration,
            keyframeOpacity,
            type)
        {
            this._startingScale = startingScale;
        }

        public ScaleUp(
            int duration,
            bool keyframeOpacity,
            TransitionState type,
            int delay,
            float startingScale = 0
        ) : base(
            duration,
            keyframeOpacity,
            type,
            delay)
        {
            this._startingScale = startingScale;
        }

        public override string GetName()
        {
            return "scale-up";
        }

        public override Vector2 ExecuteDestination(Vector2 destination)
        {
            return destination;
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

        public override float ExecuteScale(float scale)
        {
            float progress = this._type == TransitionState.Entering ? this.GetProgress() : this.GetInvertedProgress();

            return this._startingScale + ((1 - this._startingScale) * progress);
        }
    }
}
