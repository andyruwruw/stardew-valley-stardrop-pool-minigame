using Microsoft.Xna.Framework;
using System;

namespace StardropPoolMinigame.Render.Filters
{
    class Wiggle : Animation
    {
        private float _frequency;

        private float _amplitude;

        public Wiggle(string key, float frequency, float amplitude) : base(key, 1000)
        {
            this._frequency = frequency;
            this._amplitude = amplitude;
        }

        public void SetAmplitude(float value)
        {
            this._amplitude = value;
        }

        public override Vector2 ExecuteDestination(Vector2 destination)
        {
            return Vector2.Add(
                destination,
                new Vector2(
                    (float)(this._amplitude * Math.Sin(this._frequency * this.GetProgress()) + this._amplitude / .3 * Math.Sin(this._frequency * this.GetProgress())),
                    (float)(this._amplitude * Math.Sin(this._frequency * this.GetProgress()) + this._amplitude / 2 * Math.Cos(this._frequency * this.GetProgress()))));
        }
    }
}