using Microsoft.Xna.Framework;
using StardropPoolMinigame.Helpers;

namespace StardropPoolMinigame.Primitives
{
    class Circle : IRange
    {
        private Vector2 _center;

        private float _radius;

        public Circle(Vector2 center, float radius)
        {
            this._center = center;
            this._radius = radius;
        }

        public bool Contains(Vector2 point)
        {
            return Distance.Between(point, this.GetCenter()) <= this._radius;
        }

        public void SetCenter(Vector2 center)
        {
            this._center = center;
        }

        public void SetRadius(float radius)
        {
            this._radius = radius;
        }

        public Vector2 GetCenter()
        {
            return this._center;
        }

        public float GetRadius()
        {
            return this._radius;
        }
    }
}
