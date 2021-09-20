using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Primitives;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Render.Drawers
{
    internal class BallDrawer : Drawer
    {
        private IFilter _flashingAnimation;

        public BallDrawer(Ball ball) : base(ball)
        {
            this._flashingAnimation = new BallHighlightFlashing($"{this._entity.GetId()}-animation");
        }

        public override void Draw(
            SpriteBatch batch,
            Vector2? overrideDestination = null,
			Microsoft.Xna.Framework.Rectangle? overrideSource = null,
            Color? overrideColor = null,
            float? overrideRotation = null,
            Vector2? overrideOrigin = null,
            float? overrideScale = null,
            SpriteEffects? overrideEffects = null,
            float? overrideLayerDepth = null)
        {
            this.DrawBase(
                batch,
                overrideDestination,
                overrideSource,
                overrideColor,
                overrideRotation,
                overrideOrigin,
                overrideScale,
                overrideEffects,
                overrideLayerDepth);

            if (((Ball)this._entity).GetBallType() != BallType.White)
            {
                this.DrawCore(
                    batch,
                    overrideDestination,
                    overrideRotation,
                    overrideOrigin,
                    overrideScale,
                    overrideEffects,
                    overrideLayerDepth);

                this.DrawStripes(
                    batch,
                    overrideDestination,
                    overrideRotation,
                    overrideOrigin,
                    overrideScale,
                    overrideEffects,
                    overrideLayerDepth);
            }

            this.DrawShadows(
                batch,
                overrideDestination,
                overrideRotation,
                overrideOrigin,
                overrideScale,
                overrideEffects,
                overrideLayerDepth);

            if (((Ball)this._entity).IsHighlighted() || ((Ball)this._entity).IsFlashing())
            {
                this.DrawHighlight(
                    batch,
                    overrideDestination,
                    overrideRotation,
                    overrideOrigin,
                    overrideScale,
                    overrideEffects,
                    overrideLayerDepth);
            }

            if (DevConstants.DebugVisuals)
            {
                this.DrawDebugVisuals(batch);
            }
        }

        protected override void DrawDebugVisuals(SpriteBatch batch)
        {
            DrawDebugPoint(batch, this._entity.GetAnchor());

			Circle boundary = (Circle)this._entity.GetBoundary();

            DrawDebugCircle(batch, boundary.GetCenter(), boundary.GetRadius(), Color.Yellow);

            DrawDebugCircle(batch, boundary.GetCenter(), boundary.GetRadius() * 2, Color.Purple);

            DrawDebugVelocity(batch, (EntityPhysics)this._entity);
		}

        protected override Vector2 GetRawDestination()
        {
            Vector2 topLeft = this._entity.GetTopLeft();
            return new Vector2(
                (topLeft.X - RenderConstants.Entities.Ball.MarginLeft) * RenderConstants.TileScale() + RenderConstants.AdjustedScreen.Margin.Width(),
                (topLeft.Y - RenderConstants.Entities.Ball.MarginTop) * RenderConstants.TileScale() + RenderConstants.AdjustedScreen.Margin.Height());
        }

        protected override Microsoft.Xna.Framework.Rectangle GetRawSource()
        {
            switch (((Ball)this._entity).GetBallColor())
            {
                case BallColor.Yellow:
                    return Textures.Ball.Base.YELLOW;
                case BallColor.Blue:
                    return Textures.Ball.Base.BLUE;
                case BallColor.Red:
                    return Textures.Ball.Base.RED;
                case BallColor.Purple:
                    return Textures.Ball.Base.PURPLE;
                case BallColor.Orange:
                    return Textures.Ball.Base.ORANGE;
                case BallColor.Green:
                    return Textures.Ball.Base.GREEN;
                case BallColor.Maroon:
                    return Textures.Ball.Base.MAROON;
                case BallColor.White:
                    return Textures.Ball.Base.WHITE;
                default:
                    return Textures.Ball.Base.BLACK;
            }
        }

        private void DrawBase(
            SpriteBatch batch,
            Vector2? overrideDestination = null,
			Microsoft.Xna.Framework.Rectangle? overrideSource = null,
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
        }

        private void DrawCore(
            SpriteBatch batch,
            Vector2? overrideDestination = null,
            float? overrideRotation = null,
            Vector2? overrideOrigin = null,
            float? overrideScale = null,
            SpriteEffects? overrideEffects = null,
            float? overrideLayerDepth = null)
        {
            batch.Draw(
                this.GetTileset(),
                this.GetDestination(overrideDestination),
                this.GetCoreSource(),
                this.GetColor(),
                this.GetRotation(overrideRotation),
                this.GetOrigin(overrideOrigin),
                this.GetScale(overrideScale),
                this.GetEffects(overrideEffects),
                this.GetLayerDepth(overrideLayerDepth) + 0.0001f);
        }

        private void DrawHighlight(
            SpriteBatch batch,
            Vector2? overrideDestination = null,
            float? overrideRotation = null,
            Vector2? overrideOrigin = null,
            float? overrideScale = null,
            SpriteEffects? overrideEffects = null,
            float? overrideLayerDepth = null)
        {
            batch.Draw(
                this.GetTileset(),
                this.GetDestination(overrideDestination),
                Textures.Ball.HIGHLIGHT,
                ((Ball)this._entity).IsFlashing() ? this._flashingAnimation.ExecuteColor(this.GetColor()) : this.GetColor(),
                this.GetRotation(overrideRotation),
                this.GetOrigin(overrideOrigin),
                this.GetScale(overrideScale),
                this.GetEffects(overrideEffects),
                this.GetLayerDepth(overrideLayerDepth) + 0.0003f);
        }

        private void DrawShadows(
            SpriteBatch batch,
            Vector2? overrideDestination = null,
            float? overrideRotation = null,
            Vector2? overrideOrigin = null,
            float? overrideScale = null,
            SpriteEffects? overrideEffects = null,
            float? overrideLayerDepth = null)
        {
            batch.Draw(
                this.GetTileset(),
                this.GetDestination(overrideDestination),
                Textures.Ball.SHADOW,
                this.GetColor(),
                this.GetRotation(overrideRotation),
                this.GetOrigin(overrideOrigin),
                this.GetScale(overrideScale),
                this.GetEffects(overrideEffects),
                this.GetLayerDepth(overrideLayerDepth) + 0.0002f);
        }

        private void DrawStripes(
                            SpriteBatch batch,
            Vector2? overrideDestination = null,
            float? overrideRotation = null,
            Vector2? overrideOrigin = null,
            float? overrideScale = null,
            SpriteEffects? overrideEffects = null,
            float? overrideLayerDepth = null)
        {
            if (((Ball)this._entity).GetBallType() == BallType.Stripped)
            {
                batch.Draw(
                    this.GetTileset(),
                    this.GetDestination(overrideDestination),
                    this.GetStripeSource(),
                    this.GetColor(),
                    this.GetRotation(overrideRotation),
                    this.GetOrigin(overrideOrigin),
                    this.GetScale(overrideScale),
                    this.GetEffects(overrideEffects),
                    this.GetLayerDepth(overrideLayerDepth) + 0.0001f);
            }
        }

        private Microsoft.Xna.Framework.Rectangle GetCoreSource()
        {
            return Textures.GetBallCoreBounds(((Ball)this._entity).GetOrientation().GetFace());
        }

        private Microsoft.Xna.Framework.Rectangle GetStripeSource()
        {
            return Textures.GetBallStripesBounds(((Ball)this._entity).GetOrientation().GetFace());
        }
    }
}