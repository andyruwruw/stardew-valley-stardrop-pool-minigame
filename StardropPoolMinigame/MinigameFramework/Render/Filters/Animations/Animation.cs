namespace MinigameFramework.Render.Filters.Animations
{
    /// <summary>
    /// A repeating animation for an entity.
    /// </summary>
    abstract class Animation : Filter
    {
        /// <summary>
        /// Length of the animation.
        /// </summary>
        protected int _intervalLength;

        /// <summary>
        /// Instantiates a new animation.
        /// </summary>
        /// <param name="key">Forces a filter key value.</param>
        /// <param name="intervalLength">Length of the animation.</param>
        public Animation(
            string key,
            int intervalLength
        ) : base(key) {
            _intervalLength = intervalLength;

            Start();
        }

        /// <summary>
        /// Get progress as a decimal of animation.
        /// </summary>
        protected float GetProgress()
        {
            if (_key == null)
            {
                SetKey();
            }

            float progress = (float)Utilities.Timer.CheckTimer($"{_key}") / _intervalLength;

            if (progress > 1f)
            {
                Utilities.Timer.EndTimer($"{_key}");

                Start();

                return 1f;
            }
            return progress;
        }
    }
}
