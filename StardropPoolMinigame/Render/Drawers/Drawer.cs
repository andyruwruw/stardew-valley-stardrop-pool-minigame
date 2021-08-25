using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Filters;
using System.Collections.Generic;

namespace StardropPoolMinigame.Render.Drawers
{
    abstract class Drawer : IDrawer
    {
        protected IEntity _entity;

        public Drawer(IEntity entity)
        {
            this._entity = entity;
        }

        public virtual void Draw(SpriteBatch batch)
        {
            batch.Draw(
                this.GetTileSheet(),
                this.GetDestination(),
                this.GetSource(),
                this.GetColor(),
                this.GetRotation(),
                this.GetOrigin(),
                this.GetScale(),
                this.GetEffects(),
                this.GetLayerDepth());
        }

        protected virtual Vector2 GetDestination()
        {
            Vector2 destination = this.GetRawDestination();

            IList<IFilter> filters = this._entity.GetFilters();

            foreach (IFilter filter in filters)
            {
                destination = filter.ExecuteDestination(destination);
            }

            return destination;
        }

        protected Rectangle GetSource()
        {
            Rectangle source = this.GetRawSource();

            IList<IFilter> filters = this._entity.GetFilters();

            foreach (IFilter filter in filters)
            {
                source = filter.ExecuteSource(source);
            }

            return source;
        }

        protected Color GetColor()
        {
            Color color = this.GetRawColor();

            IList<IFilter> filters = this._entity.GetFilters();

            foreach (IFilter filter in filters)
            {
                color = filter.ExecuteColor(color);
            }

            return color;
        }

        protected float GetRotation()
        {
            float rotation = this.GetRawRotation();

            IList<IFilter> filters = this._entity.GetFilters();

            foreach (IFilter filter in filters)
            {
                rotation = filter.ExecuteRotation(rotation);
            }

            return rotation;
        }

        protected Vector2 GetOrigin()
        {
            Vector2 origin = this.GetRawOrigin();

            IList<IFilter> filters = this._entity.GetFilters();

            foreach (IFilter filter in filters)
            {
                origin = filter.ExecuteOrigin(origin);
            }

            return origin;
        }

        protected float GetScale()
        {
            float scale = this.GetRawScale();

            IList<IFilter> filters = this._entity.GetFilters();

            foreach (IFilter filter in filters)
            {
                scale = filter.ExecuteScale(scale);
            }

            return scale;
        }

        protected SpriteEffects GetEffects()
        {
            SpriteEffects effects = this.GetRawEffects();

            IList<IFilter> filters = this._entity.GetFilters();

            foreach (IFilter filter in filters)
            {
                effects = filter.ExecuteEffects(effects);
            }

            return effects;
        }

        protected float GetLayerDepth()
        {
            float layerDepth = this.GetRawLayerDepth();

            IList<IFilter> filters = this._entity.GetFilters();

            foreach (IFilter filter in filters)
            {
                layerDepth = filter.ExecuteLayerDepth(layerDepth);
            }

            return layerDepth;
        }

        protected TransitionState GetTransitionState()
        {
            return this._entity.GetTransitionState();
        }

        protected IFilter GetEnteringTransition()
        {
            return this._entity.GetEnteringTransition();
        }

        protected IFilter GetExitingTransition()
        {
            return this._entity.GetExitingTransition();
        }

        protected virtual Texture2D GetTileSheet()
        {
            return Textures.TileSheet;
        }

        protected virtual Vector2 GetRawDestination()
        {
            Vector2 topLeft = this._entity.GetTopLeft();
            return new Vector2(
                topLeft.X * RenderConstants.TileScale() + RenderConstants.AdjustedScreenWidthMargin(),
                topLeft.Y * RenderConstants.TileScale() + RenderConstants.AdjustedScreenHeightMargin());
        }

        protected virtual Color GetRawColor()
        {
            return Color.White;
        }

        protected virtual float GetRawRotation()
        {
            return 0f;
        }

        protected virtual Vector2 GetRawOrigin()
        {
            return new Vector2(0, 0);
        }

        protected virtual float GetRawScale()
        {
            return RenderConstants.TileScale();
        }

        protected virtual SpriteEffects GetRawEffects()
        {
            return SpriteEffects.None;
        }

        protected virtual float GetRawLayerDepth()
        {
            return this._entity.GetLayerDepth();
        }

        protected abstract Rectangle GetRawSource();
    }
}
