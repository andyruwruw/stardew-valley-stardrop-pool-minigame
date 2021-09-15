using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame.Render.Filters
{
    internal abstract class Transition : Filter
    {
        protected int _delay;

        protected bool _delayOnce;

        protected int _duration;

        protected int _endingTick;

        protected bool _firstExecution;

        protected bool _isFinished;

        protected bool _keyframeOpacity;

        protected int _postDelay;

        protected TransitionState _type;

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

        public override string GetName()
        {
            return "generic-transition";
        }

        public bool IsFinished()
        {
            return this._isFinished;
        }

        public void ResetTransition()
        {
            this._key = null;
            this._isFinished = false;
        }

        public override void SetKey(string key)
        {
            string transitionType = this._type == TransitionState.Entering ? "entering" : "exiting";
            this._key = $"{key}-filter-{this.GetName()}-{transitionType}";
        }

        public void SetPostDelay(int delay)
        {
            this._postDelay = delay;
        }

        public override void StartFilter()
        {
            this._endingTick = Timer.StartTimer(this._key) + this.GetDelay() + this._duration;
        }

        protected float EaseOut(float time, float startValue, float change, float duration)
        {
            time /= duration / 2;
            if (time < 1)
            {
                return change / 2 * time * time + startValue;
            }

            time--;
            return -change / 2 * (time * (time - 2) - 1) + startValue;
        }

        protected int GetDelay()
        {
            if (this._delayOnce && !this._firstExecution)
            {
                return 0;
            }

            return this._delay + this._postDelay;
        }

        protected float GetInvertedProgress()
        {
            return 1f - this.GetProgress();
        }

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

            float progress = ((float)Timer.CheckTimer(this._key) - this.GetDelay()) / (float)this._duration;

            if (progress > 1f)
            {
                this.StopTransition();
                this._isFinished = true;
                this._firstExecution = false;
                return 1f;
            }
            return progress;
        }
    }
}