using Microsoft.Xna.Framework;
using MinigameFramework.Enums;
using MinigameFramework.Constants;

namespace MinigameFramework.Render.Filters.Transitions
{
    /// <summary>
    /// Entity starts with a positional displacement and moves to it's position.
    /// </summary>
    class SlideIn : Transition
    {
        /// <summary>
        /// How displaced the entity should start.
        /// </summary>
        private Vector2 _difference;

        /// <summary>
        /// Instantiates a slide in transition.
        /// </summary>
        /// <param name="duration">Duration of the transition.</param>
        /// <param name="keyframeOpacity">Whether to keyframe the opacity as it scales.</param>
        /// <param name="type"><see cref="TransitionState"/> of transition.</param>
        /// <param name="difference">How displaced the entity should start.</param>
        public SlideIn(
            int duration,
            bool keyframeOpacity,
            TransitionState type,
            Vector2 difference
        ) : base(
            duration,
            keyframeOpacity,
            type
        ) {
            this._difference = difference;
        }

        /// <summary>
        /// Instantiates a slide in transition.
        /// </summary>
        /// <param name="duration">Duration of the transition.</param>
        /// <param name="keyframeOpacity">Whether to keyframe the opacity as it scales.</param>
        /// <param name="type"><see cref="TransitionState"/> of transition.</param>
        /// <param name="delay">How displaced the entity should start.</param>
        /// <param name="difference">How displaced the entity should start.</param>
        /// <param name="delayOnce">Whether to only delay the transition once.</param>
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
            delayOnce
        ) {
            this._difference = difference;
        }

        /// <inheritdoc cref="IFilter.GetColor"/>
        public override Color GetColor(Color color)
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

        /// <inheritdoc cref="IFilter.GetDestination"/>
        public override Vector2 GetDestination(Vector2 destination)
        {
            float progress = this._type == TransitionState.Entering ? this.GetInvertedProgress() : this.GetProgress();

            return new Vector2(
                this.EaseOut(
                    progress * this._duration,
                    destination.X,
                    this._difference.X * GenericRenderConstants.TileScale(),
                    this._duration),
                this.EaseOut(
                    progress * this._duration,
                    destination.Y,
                    this._difference.Y * GenericRenderConstants.TileScale(),
                    this._duration));
        }

        /// <inheritdoc cref="IFilter.GetName"/>
        public override string GetName()
        {
            return "slide-in";
        }
    }
}
