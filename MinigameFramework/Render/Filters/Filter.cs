using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MinigameFramework.Render.Filters
{
    /// <inheritdoc cref="IFilter"/>
    abstract class Filter : IFilter
    {
        /// <summary>
        /// Filter unique ID.
        /// </summary>
        protected string _key;

        /// <summary>
        /// Instantiates a new filter.
        /// </summary>
        public Filter()
        {
            _key = null;
        }

        /// <summary>
        /// Instantiates a new filter.
        /// </summary>
        /// <param name="key">Forces a filter key value.</param>
        public Filter(string key)
        {
            SetKey(key);
        }

        /// <inheritdoc cref="IFilter.GetColor"/>
        public virtual Color GetColor(Color color)
        {
            return color;
        }

        /// <inheritdoc cref="IFilter.GetDestination"/>
        public virtual Vector2 GetDestination(Vector2 destination)
        {
            return destination;
        }

        /// <inheritdoc cref="IFilter.GetEffects"/>
        public virtual SpriteEffects GetEffects(SpriteEffects effects)
        {
            return effects;
        }

        /// <inheritdoc cref="IFilter.GetLayerDepth"/>
        public virtual float GetLayerDepth(float layerDepth)
        {
            return layerDepth;
        }

        /// <inheritdoc cref="IFilter.GetOrigin"/>
        public virtual Vector2 GetOrigin(Vector2 origin)
        {
            return origin;
        }

        /// <inheritdoc cref="IFilter.GetRotation"/>
        public virtual float GetRotation(float rotation)
        {
            return rotation;
        }

        /// <inheritdoc cref="IFilter.GetScale"/>
        public virtual float GetScale(float scale)
        {
            return scale;
        }

        /// <inheritdoc cref="IFilter.GetSource"/>
        public virtual Rectangle GetSource(Rectangle source)
        {
            return source;
        }

        /// <inheritdoc cref="IFilter.GetName"/>
        public abstract string GetName();

        /// <inheritdoc cref="IFilter.SetKey"/>
        public virtual void SetKey(string key)
        {
            _key = $"{key}-filter-{GetName()}";
        }

        /// <inheritdoc cref="IFilter.Start"/>
        public virtual void Start()
        {
            Utilities.Timer.StartTimer(_key);
        }

        /// <inheritdoc cref="IFilter.Stop"/>
        public virtual void Stop()
        {
            Utilities.Timer.EndTimer(_key);
        }

        /// <summary>
        /// Returns the duration of the filter passed.
        /// </summary>
        protected float GetTimePassed()
        {
            if (_key != null)
            {
                return Utilities.Timer.CheckTimer(_key);
            }

            return 0;
        }
    }
}
