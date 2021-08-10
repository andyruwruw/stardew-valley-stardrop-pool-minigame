using Microsoft.Xna.Framework;

namespace StardropPoolMinigame.Attributes
{
    class Orientation
    {
        private Vector2 _orientation;

        public Orientation(float x = 0, float y = 0)
        {
            this._orientation = new Vector2(x, y);
        }
    }
}
