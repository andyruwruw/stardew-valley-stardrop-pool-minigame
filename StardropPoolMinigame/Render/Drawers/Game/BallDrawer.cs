using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;

namespace StardropPoolMinigame.Render.Drawers
{
    class BallDrawer : Drawer
    {
        public BallDrawer(Ball ball) : base(ball)
        {
        }

        public override void Draw(
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
            this.DrawShadows(
                batch,
                overrideDestination,
                overrideRotation,
                overrideOrigin,
                overrideScale,
                overrideEffects,
                overrideLayerDepth);
        }

        protected override Vector2 GetRawDestination()
        {
            Vector2 topLeft = this._entity.GetTopLeft();
            return new Vector2(
                (topLeft.X - RenderConstants.BALL_MARGIN_LEFT) * RenderConstants.TileScale() + RenderConstants.AdjustedScreenWidthMargin(), 
                (topLeft.Y - RenderConstants.BALL_MARGIN_TOP) * RenderConstants.TileScale() + RenderConstants.AdjustedScreenHeightMargin());
        }

        protected override Rectangle GetRawSource()
        {
            switch (((Ball)this._entity).GetBallColor())
            {
                case BallColor.Yellow:
                    return Textures.BALL_COLOR_YELLOW;
                case BallColor.Blue:
                    return Textures.BALL_COLOR_BLUE;
                case BallColor.Red:
                    return Textures.BALL_COLOR_RED;
                case BallColor.Purple:
                    return Textures.BALL_COLOR_PURPLE;
                case BallColor.Orange:
                    return Textures.BALL_COLOR_ORANGE;
                case BallColor.Green:
                    return Textures.BALL_COLOR_GREEN;
                case BallColor.Maroon:
                    return Textures.BALL_COLOR_MAROON;
                default:
                    return Textures.BALL_COLOR_BLACK;
            }
        }

        private void DrawBase(
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
                this.GetTileSheet(),
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
                this.GetTileSheet(),
                this.GetDestination(overrideDestination),
                this.GetCoreSource(),
                this.GetColor(),
                this.GetRotation(overrideRotation),
                this.GetOrigin(overrideOrigin),
                this.GetScale(overrideScale),
                this.GetEffects(overrideEffects),
                this.GetLayerDepth(overrideLayerDepth) + 0.0001f);
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
                    this.GetTileSheet(),
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
                this.GetTileSheet(),
                this.GetDestination(overrideDestination),
                Textures.BALL_SHADOW,
                this.GetColor(),
                this.GetRotation(overrideRotation),
                this.GetOrigin(overrideOrigin),
                this.GetScale(overrideScale),
                this.GetEffects(overrideEffects),
                this.GetLayerDepth(overrideLayerDepth) + 0.0002f);
        }

        private Rectangle GetCoreSource()
        {
            return Textures.GetBallCoreBounds(((Ball)this._entity).GetOrientation().GetFace());
        }

        private Rectangle GetStripeSource()
        {
            return Textures.GetBallStripesBounds(((Ball)this._entity).GetOrientation().GetFace());
        }
    }
}
