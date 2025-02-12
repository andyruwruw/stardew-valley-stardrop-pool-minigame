using Microsoft.Xna.Framework;
using MinigameFramework.Enums;

namespace MinigameFramework.Render.Filters.Transitions
{
    /// <summary>
    /// Entity starts small and scales to size.
    /// </summary>
    class ScaleUp : Transition
    {
        /// <summary>
        /// How small the sprite should start.
        /// </summary>
        protected float _startingScale;

        /// <summary>
        /// Instantiates a scaling up transition.
        /// </summary>
        /// <param name="duration">Duration of the transition.</param>
        /// <param name="keyframeOpacity">Whether to keyframe the opacity as it scales.</param>
        /// <param name="type"><see cref="TransitionState"/> of transition.</param>
        /// <param name="startingScale">How small the sprite should start.</param>
        public ScaleUp(
            int duration,
            bool keyframeOpacity,
            TransitionState type,
            float startingScale = 0
        ) : base(
            duration,
            keyframeOpacity,
            type
        ) {
            _startingScale = startingScale;
        }

        /// <summary>
        /// Instantiates a scaling up transition.
        /// </summary>
        /// <param name="duration">Duration of the transition.</param>
        /// <param name="keyframeOpacity">Whether to keyframe the opacity as it scales.</param>
        /// <param name="type"><see cref="TransitionState"/> of transition.</param>
        /// <param name="delay">Delay the transition.</param>
        /// <param name="startingScale">How small the sprite should start.</param>
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
            delay
        ) {
            _startingScale = startingScale;
        }

        /// <inheritdoc cref="IFilter.GetColor"/>
        public override Color GetColor(Color color)
        {
            if (_keyframeOpacity)
            {
                float progress = _type == TransitionState.Entering ? GetProgress() : GetInvertedProgress();

                return new Color(
                    (byte)Math.Round(progress * color.R),
                    (byte)Math.Round(progress * color.G),
                    (byte)Math.Round(progress * color.B),
                    (byte)Math.Round(progress * 255));

            }
            return color;
        }

        /// <inheritdoc cref="IFilter.GetScale"/>
        public override float GetScale(float scale)
        {
            float progress = _type == TransitionState.Entering ? GetProgress() : GetInvertedProgress();

            return _startingScale + ((1 - _startingScale) * progress) + 0.001f;
        }

        /// <inheritdoc cref="IFilter.GetName"/>
        public override string GetName()
        {
            return "scale-up";
        }
    }
}
