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
    internal abstract class Drawer : IDrawer
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

            if (DevConstants.DebugVisuals)
            {
                this.DrawDebugVisuals(batch);
            }
        }

        public IEntity GetEntity()
        {
            return this._entity;
        }

        public virtual bool ShouldDraw()
        {
            return this._entity.GetTransitionState() != TransitionState.Dead;
        }

        protected virtual void DrawDebugVisuals(SpriteBatch batch)
        {
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

        protected IFilter GetEnteringTransition()
        {
            return this._entity.GetEnteringTransition();
        }

        protected IFilter GetExitingTransition()
        {
            return this._entity.GetExitingTransition();
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

        protected Vector2 GetOrigin(Vector2? overrideOrigin = null)
        {
            Vector2 origin = overrideOrigin == null ? this.GetRawOrigin() : (Vector2)overrideOrigin;

            IList<IFilter> filters = this._entity.GetFilters();

            foreach (IFilter filter in filters)
            {
                origin = filter.ExecuteOrigin(origin);
            }

            return origin;
        }

        protected virtual Color GetRawColor()
        {
            return Color.White;
        }

        protected virtual Vector2 GetRawDestination()
        {
            Vector2 topLeft = this._entity.GetTopLeft();
            return new Vector2(
                topLeft.X * RenderConstants.TileScale() + RenderConstants.AdjustedScreen.Margin.Width(),
                topLeft.Y * RenderConstants.TileScale() + RenderConstants.AdjustedScreen.Margin.Height());
        }

        protected virtual SpriteEffects GetRawEffects()
        {
            return SpriteEffects.None;
        }

        protected virtual float GetRawLayerDepth()
        {
            return this._entity.GetLayerDepth();
        }

        protected virtual Vector2 GetRawOrigin()
        {
            return new Vector2(0, 0);
        }

        protected virtual float GetRawRotation()
        {
            return 0f;
        }

        protected virtual float GetRawScale()
        {
            return RenderConstants.TileScale();
        }

        protected abstract Rectangle GetRawSource();

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

        protected float GetScale(float? overrideScale = null)
        {
            float scale = overrideScale == null ? this.GetRawScale() : (float)overrideScale * RenderConstants.TileScale();

            IList<IFilter> filters = this._entity.GetFilters();

            foreach (IFilter filter in filters)
            {
                scale = filter.ExecuteScale(scale);
            }

            if (scale == 0)
            {
                scale = 0.001f;
            }

            return scale;
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

        protected virtual Texture2D GetTileset()
        {
            return Textures.Tileset.Default;
        }

        protected TransitionState GetTransitionState()
        {
            return this._entity.GetTransitionState();
        }

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
                adjustedPoint = RenderConstants.ConvertAdjustedScreenToRaw(adjustedPoint);
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
        public static void DrawDebugCircle(SpriteBatch batch, Vector2 center, float radius, Color? color = null, int size = 1, bool isRaw = false)
        {
            int maxLineLength = 3;
            float circumference = (float)(radius * 2 * Math.PI);
            int segments = (int)Math.Floor(circumference / maxLineLength);

            float angle = (float)(2 * Math.PI) / segments;
            Vector2 firstPoint = new Vector2(center.X + radius, center.Y);
            Vector2 lastPoint = firstPoint;

            for (int i = 1; i < segments; i++)
            {
                Vector2 newPoint = Vector2.Add(center, Vector2.Multiply(Vector2.Normalize(VectorHelper.RadiansToVector(angle * i)), radius));
                DrawDebugLine(
                    batch,
                    lastPoint,
                    newPoint,
                    color,
                    size,
                    isRaw);
                lastPoint = newPoint;
            }

            DrawDebugLine(
                batch,
                lastPoint,
                firstPoint,
                color,
                size,
                isRaw);
        }

        public static void DrawDebugLine(
            SpriteBatch batch,
            Vector2 point1,
            Vector2 point2,
            Color? color = null,
            int size = 4,
            bool isRaw = false)
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
                adjustedPoint1 = RenderConstants.ConvertAdjustedScreenToRaw(point1);
                adjustedPoint2 = RenderConstants.ConvertAdjustedScreenToRaw(point2);
            }

            Vector2 difference = Vector2.Subtract(adjustedPoint2, adjustedPoint1);

            batch.Draw(
                Game1.staminaRect,
                new Rectangle(
                    (int)Math.Round(adjustedPoint1.X - (size / 2)),
                    (int)Math.Round(adjustedPoint1.Y - (size / 2)),
                    (int)Math.Round(VectorHelper.Pythagorean(
                        adjustedPoint1,
                        adjustedPoint2)),
                    size),
                Game1.staminaRect.Bounds,
                (Color)adjustedColor,
                VectorHelper.VectorToRadians(difference),
                Vector2.Zero,
                SpriteEffects.None,
                1f);
        }

        public static void DrawDebugVelocity(
            SpriteBatch batch,
            EntityPhysics entity,
            Color? color = null,
            int size = 1,
            bool isRaw = false)
        {
            DrawDebugLine(
                batch,
                entity.GetAnchor(),
                Vector2.Add(
                    entity.GetAnchor(),
                    Vector2.Multiply(
                        entity.GetVelocity(),
                        4)),
                color == null ? Color.Red : color,
                size,
                isRaw);
        }
    }
}