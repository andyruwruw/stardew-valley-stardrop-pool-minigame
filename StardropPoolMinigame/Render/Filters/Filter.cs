using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Helpers;

namespace StardropPoolMinigame.Render.Filters
{
    internal abstract class Filter : IFilter
    {
        protected string _key;

        public Filter()
        {
            this._key = null;
        }

        public Filter(string key)
        {
            this.SetKey(key);
        }

        public virtual Color ExecuteColor(Color color)
        {
            return color;
        }

        public virtual Vector2 ExecuteDestination(Vector2 destination)
        {
            return destination;
        }

        public virtual SpriteEffects ExecuteEffects(SpriteEffects effects)
        {
            return effects;
        }

        public virtual float ExecuteLayerDepth(float layerDepth)
        {
            return layerDepth;
        }

        public virtual Vector2 ExecuteOrigin(Vector2 origin)
        {
            return origin;
        }

        public virtual float ExecuteRotation(float rotation)
        {
            return rotation;
        }

        public virtual float ExecuteScale(float scale)
        {
            return scale;
        }

        public virtual Rectangle ExecuteSource(Rectangle source)
        {
            return source;
        }

        public abstract string GetName();

        public virtual void SetKey(string key)
        {
            this._key = $"{key}-filter-{this.GetName()}";
        }

        public virtual void StartFilter()
        {
            Timer.StartTimer(this._key);
        }

        public void StopTransition()
        {
            Timer.EndTimer(this._key);
        }

        protected float GetTimePassed()
        {
            if (this._key != null)
            {
                return (float)(Timer.CheckTimer(this._key));
            }
            return 0;
        }
    }
}