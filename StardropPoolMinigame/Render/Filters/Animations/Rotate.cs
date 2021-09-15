using System;

namespace StardropPoolMinigame.Render.Filters
{
    internal class Rotate : Animation
    {
        public Rotate(string key, int speed) : base(key, speed)
        {
        }

        public override float ExecuteRotation(float rotation)
        {
            return (float)(rotation + (this.GetProgress() * 2 * Math.PI));
        }
    }
}