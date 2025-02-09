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
            this._intervalLength = intervalLength;

            this.Start();
        }

        /// <summary>
        /// Get progress as a decimal of animation.
        /// </summary>
        protected float GetProgress()
        {
            float progress = (float)Utilities.Timer.CheckTimer(this._key) / this._intervalLength;

            if (progress > 1f)
            {
                Utilities.Timer.EndTimer(this._key);

                this.Start();

                return 1f;
            }
            return progress;
        }
    }
}
