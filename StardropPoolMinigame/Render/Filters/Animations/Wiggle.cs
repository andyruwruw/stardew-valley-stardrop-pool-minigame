namespace StardropPoolMinigame.Render.Filters
{
    class Wiggle : Animation
    {
        private float _frequency;

        private float _amplitude;

        public Wiggle(string key, float frequency, float amplitude) : base(key)
        {
            this._frequency = frequency;
            this._amplitude = amplitude;
        }
    }
}