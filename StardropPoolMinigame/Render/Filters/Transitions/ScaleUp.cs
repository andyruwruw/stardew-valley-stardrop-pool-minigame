using Microsoft.Xna.Framework;
using System;

namespace StardropPoolMinigame.Render.Filters
{
    class ScaleUp : Transition
    {
        private float _startingScale;

        public ScaleUp(
            int duration,
            bool keyframeOpacity,
            float startingScale = 0
        ) : base(duration, keyframeOpacity)
        {
            this._startingScale = startingScale;
        }

        public ScaleUp(
            int duration,
            int delay,
            bool keyframeOpacity,
            float startingScale = 0
        ) : base(
            duration,
            keyframeOpacity,
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
                return new Color(
                    color.R,
                    color.G,
                    color.B,
                    (byte)(Math.Round(this.GetProgress() * 255)));
            }
            return color;
        }

        public override float ExecuteScale(float scale)
        {
            return this._startingScale + ((1 - this._startingScale) * this.GetProgress());
        }
    }
}
