using StardropPoolMinigame.Helpers;

namespace StardropPoolMinigame.Render.Filters
{
    abstract class Transition : Filter
    {
        protected int _duration;

        protected int _delay;

        protected bool _keyframeOpacity;

        protected bool _isFinished;

        protected int _endingTick;

        public Transition(int duration, bool keyframeOpacity, int delay = 0) : base()
        {
            this._duration = duration;
            this._delay = delay;
            this._keyframeOpacity = keyframeOpacity;
            this._key = null;
            this._isFinished = false;
        }

        public override string GetName()
        {
            return "generic-transition";
        }

        public override void StartTransition(string key)
        {
            this._key = $"{key}-filter-{this.GetName()}";
            this._endingTick = Timer.StartTimer(this._key) + this._delay + this._duration;
        }

        protected float GetProgress()
        {
            if (this._isFinished)
            {
                return 1f;
            }

            if (this.GetTimePassed() < this._delay)
            {
                return 0f;
            }

            float progress = ((float)Timer.CheckTimer(this._key) - this._delay) / (float)this._duration;

            if (progress > 1f)
            {
                Timer.EndTimer(this._key);
                this._isFinished = true;
                return 1f;
            }
            return progress;
        }

        protected float GetInvertedProgress()
        {
            return 1f - this.GetProgress();
        }

        public void ResetTransition()
        {
            this._key = null;
            this._isFinished = false;
        }

        public bool IsFinished()
        {
            return this._isFinished;
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
    }
}
