using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Render.Filters;
using System;
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

        public virtual void Draw(
            SpriteBatch batch,
            Vector2? overrideDestination = null,
            Rectangle? overrideSource = null,
            Color? overrideColor = null,
            float? overrideRotation = null,
            Vector2? overrideOrigin = null,
            float? overrideScale = null,
            SpriteEffects? overrideEffects = null,
            float? overrideLayerDepth = null)
        {
            batch.Draw(
                this.GetTileset(),
                this.GetDestination(overrideDestination),
                this.GetSource(overrideSource),
                this.GetColor(overrideColor),
                this.GetRotation(overrideRotation),
                this.GetOrigin(overrideOrigin),
                this.GetScale(overrideScale),
                this.GetEffects(overrideEffects),
                this.GetLayerDepth(overrideLayerDepth));

            if (DevConstants.DEBUG_VISUALS)
            {
                this.DrawDebugVisuals(batch);
            }
        }

        protected virtual void DrawDebugVisuals(SpriteBatch batch)
        {
        }

        public IEntity GetEntity()
        {
            return this._entity;
        }

        public virtual bool ShouldDraw()
        {
            return this._entity.GetTransitionState() != TransitionState.Dead;
        }

        protected virtual Vector2 GetDestination(Vector2? overrideDestination = null)
        {
            Vector2 destination = overrideDestination == null ? this.GetRawDestination() : (Vector2)overrideDestination;

            IList<IFilter> filters = this._entity.GetFilters();

            foreach (IFilter filter in filters)
            {
                destination = filter.ExecuteDestination(destination);
            }

            return destination;
        }

        protected Rectangle GetSource(Rectangle? overrideSource = null)
        {
            Rectangle source = overrideSource == null ? this.GetRawSource() : (Rectangle)overrideSource;

            IList<IFilter> filters = this._entity.GetFilters();

            foreach (IFilter filter in filters)
            {
                source = filter.ExecuteSource(source);
            }

            return source;
        }

        protected Color GetColor(Color? overrideColor = null)
        {
            Color color = overrideColor == null ? this.GetRawColor() : (Color)overrideColor;

            IList<IFilter> filters = this._entity.GetFilters();

            foreach (IFilter filter in filters)
            {
                color = filter.ExecuteColor(color);
            }

            return color;
        }

        protected float GetRotation(float? overrideRotation = null)
        {
            float rotation = overrideRotation == null ? this.GetRawRotation() : (float)overrideRotation;

            IList<IFilter> filters = this._entity.GetFilters();

            foreach (IFilter filter in filters)
            {
                rotation = filter.ExecuteRotation(rotation);
            }

            return rotation;
        }

        protected Vector2 GetOrigin(Vector2? overrideOrigin = null)
        {
            Vector2 origin = overrideOrigin == null ? this.GetRawOrigin(): (Vector2)overrideOrigin;

            IList<IFilter> filters = this._entity.GetFilters();

            foreach (IFilter filter in filters)
            {
                origin = filter.ExecuteOrigin(origin);
            }

            return origin;
        }

        protected float GetScale(float? overrideScale = null)
        {
            float scale = overrideScale == null ? this.GetRawScale() : (float)overrideScale * RenderConstants.TileScale();

            IList<IFilter> filters = this._entity.GetFilters();

            foreach (IFilter filter in filters)
            {
                scale = filter.ExecuteScale(scale);
            }

            return scale;
        }

        protected SpriteEffects GetEffects(SpriteEffects? overrideEffects = null)
        {
            SpriteEffects effects = overrideEffects == null ? this.GetRawEffects() : (SpriteEffects)overrideEffects;

            IList<IFilter> filters = this._entity.GetFilters();

            foreach (IFilter filter in filters)
            {
                effects = filter.ExecuteEffects(effects);
            }

            return effects;
        }

        protected float GetLayerDepth(float? overrideLayerDepth = null)
        {
            float layerDepth = overrideLayerDepth == null ? this.GetRawLayerDepth() : (float)overrideLayerDepth;

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

        protected virtual Texture2D GetTileset()
        {
            return Textures.Tileset.Default;
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

        public static void DrawDebugPoint(SpriteBatch batch, Vector2 point, Color? color = null, int size = 4, bool isRaw = false)
        {
            Color? adjustedColor = color;
            if (color == null)
            {
                adjustedColor = Color.GreenYellow;
            }

            Vector2 adjustedPoint = point;
            if (!isRaw)
            {
                adjustedPoint = RenderConstants.ConvertMinigameWindowToRaw(adjustedPoint);
            }

            batch.Draw(
                Game1.staminaRect,
                new Rectangle(
                    (int)Math.Round(adjustedPoint.X - (size / 2)),
                    (int)Math.Round(adjustedPoint.Y - (size / 2)),
                    size,
                    size),
                Game1.staminaRect.Bounds,
                (Color)adjustedColor,
                0f,
                Vector2.Zero,
                SpriteEffects.None,
                0.90000f);
        }

        public static void DrawDebugLine(SpriteBatch batch, Vector2 point1, Vector2 point2, Color? color = null, int size = 4, bool isRaw = false)
        {
            Color? adjustedColor = color;
            if (color == null)
            {
                adjustedColor = Color.Yellow;
            }

            Vector2 adjustedPoint1 = point1;
            Vector2 adjustedPoint2 = point2;
            if (!isRaw)
            {
                adjustedPoint1 = RenderConstants.ConvertMinigameWindowToRaw(point1);
                adjustedPoint2 = RenderConstants.ConvertMinigameWindowToRaw(point2);
            }

            Vector2 difference = Vector2.Subtract(adjustedPoint2, adjustedPoint1);

            batch.Draw(
                Game1.staminaRect,
                new Rectangle(
                    (int)Math.Round(adjustedPoint1.X - (size / 2)),
                    (int)Math.Round(adjustedPoint1.Y - (size / 2)),
                    (int)Math.Round(Distance.Pythagorean(
                        adjustedPoint1,
                        adjustedPoint2)),
                    size),
                Game1.staminaRect.Bounds,
                (Color)adjustedColor,
                Operators.VectorToRadians(difference),
                Vector2.Zero,
                SpriteEffects.None,
                1f);
        }

        public static void DrawDebugCircle(SpriteBatch batch, Vector2 center, int radius, Color? color = null, int size = 4, bool isRaw = false)
        {
            float pythag = (float)(radius * Math.Sqrt(2) / 2);

            DrawDebugPoint(batch, Vector2.Add(center, new Vector2(radius, 0)), color, size, isRaw);
            DrawDebugPoint(batch, Vector2.Add(center, new Vector2(radius * -1, 0)), color, size, isRaw);
            DrawDebugPoint(batch, Vector2.Add(center, new Vector2(0, radius)), color, size, isRaw);
            DrawDebugPoint(batch, Vector2.Add(center, new Vector2(0, radius * -1)), color, size, isRaw);
            DrawDebugPoint(batch, Vector2.Add(center, new Vector2(pythag, pythag)), color, size, isRaw);
            DrawDebugPoint(batch, Vector2.Add(center, new Vector2(pythag, pythag * -1)), color, size, isRaw);
            DrawDebugPoint(batch, Vector2.Add(center, new Vector2(pythag * -1, pythag)), color, size, isRaw);
            DrawDebugPoint(batch, Vector2.Add(center, new Vector2(pythag * -1, pythag * -1)), color, size, isRaw);
        }
    }
}
