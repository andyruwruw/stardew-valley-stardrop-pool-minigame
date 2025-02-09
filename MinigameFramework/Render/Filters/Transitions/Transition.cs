using MinigameFramework.Enums;

namespace MinigameFramework.Render.Filters.Transitions
{
    /// <summary>
    /// An entering or exiting transition for an entity.
    /// </summary>
    abstract class Transition : Filter
    {
        /// <summary>
        /// Delay before starting transition.
        /// </summary>
        protected int _delay;

        /// <summary>
        /// Whether to delay on subsequent transitions.
        /// </summary>
        protected bool _delayOnce;

        /// <summary>
        /// Duration of the transition.
        /// </summary>
        protected int _duration;

        /// <summary>
        /// When the transition should end.
        /// </summary>
        protected int _endingTick;

        /// <summary>
        /// Whether this is the first execution.
        /// </summary>
        protected bool _firstExecution;

        /// <summary>
        /// Whether the transition has finished.
        /// </summary>
        protected bool _isFinished;

        /// <summary>
        /// Whether to keyframe opacity.
        /// </summary>
        protected bool _keyframeOpacity;

        /// <summary>
        /// Add delay after instantiation.
        /// </summary>
        protected int _postDelay;

        /// <summary>
        /// Transition type.
        /// </summary>
        protected TransitionState _type;

        /// <summary>
        /// Instantiates a transition.
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="keyframeOpacity"></param>
        /// <param name="type"></param>
        /// <param name="delay"></param>
        /// <param name="delayOnce"></param>
        public Transition(
            int duration,
            bool keyframeOpacity,
            TransitionState type,
            int delay = 0,
            bool delayOnce = false
        ) : base()
        {
            this._duration = duration;
            this._keyframeOpacity = keyframeOpacity;
            this._type = type;
            this._delay = delay;
            this._postDelay = 0;
            this._delayOnce = delayOnce;
            this._key = null;
            this._isFinished = false;
            this._firstExecution = true;
        }

        /// <summary>
        /// Returns whether the transition has concluded.
        /// </summary>
        public bool IsFinished()
        {
            return this._isFinished;
        }

        /// <summary>
        /// Resets the transition.
        /// </summary>
        public void ResetTransition()
        {
            this._key = null;
            this._isFinished = false;
        }

        /// <inheritdoc cref="IFilter.SetKey"/>
        public override void SetKey(string key)
        {
            string transitionType = this._type == TransitionState.Entering ? "entering" : "exiting";
            this._key = $"{key}-filter-{this.GetName()}-{transitionType}";
        }

        /// <summary>
        /// Manually add more delay.
        /// </summary>
        public void SetPostDelay(int delay)
        {
            this._postDelay = delay;
        }

        /// <inheritdoc cref="IFilter.Start"/>
        public override void Start()
        {
            this._endingTick = Utilities.Timer.StartTimer(this._key) + this.GetDelay() + this._duration;
        }

        /// <summary>
        /// Progress completed.
        /// </summary>
        /// <returns></returns>
        protected float GetProgress()
        {
            if (this._isFinished)
            {
                return 1f;
            }

            if (this.GetTimePassed() < this.GetDelay())
            {
                return 0f;
            }

            float progress = ((float)Utilities.Timer.CheckTimer(this._key) - this.GetDelay()) / (float)this._duration;

            if (progress > 1f)
            {
                this.Stop();
                this._isFinished = true;
                this._firstExecution = false;
                return 1f;
            }
            return progress;
        }

        /// <summary>
        /// Progress not completed.
        /// </summary>
        protected float GetInvertedProgress()
        {
            return 1f - this.GetProgress();
        }

        /// <summary>
        /// Retrieves the delay of the animation.
        /// </summary>
        protected int GetDelay()
        {
            if (this._delayOnce && !this._firstExecution)
            {
                return 0;
            }

            return this._delay + this._postDelay;
        }

        /// <summary>
        /// Animates the transition with ease.
        /// </summary>
        protected float EaseOut(
            float time,
            float startValue,
            float change,
            float duration
        ) {
            time /= duration / 2;
            if (time < 1)
            {
                return change / 2 * time * time + startValue;
            }

            time--;
            return -change / 2 * (time * (time - 2) - 1) + startValue;
        }
    }
}
