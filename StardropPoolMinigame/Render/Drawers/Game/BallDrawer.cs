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

        public override void Draw(SpriteBatch batch)
        {
            this.DrawBase(batch);
            this.DrawCore(batch);
            this.DrawStripes(batch);
            this.DrawShadows(batch);
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

        private void DrawBase(SpriteBatch batch)
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

        private void DrawCore(SpriteBatch batch)
        {
            batch.Draw(
                this.GetTileSheet(),
                this.GetDestination(),
                this.GetCoreSource(),
                this.GetColor(),
                this.GetRotation(),
                this.GetOrigin(),
                this.GetScale(),
                this.GetEffects(),
                this.GetLayerDepth() + 0.0001f);
        }

        private void DrawStripes(SpriteBatch batch)
        {
            if (((Ball)this._entity).GetBallType() == BallType.Stripped)
            {
                batch.Draw(
                    this.GetTileSheet(),
                    this.GetDestination(),
                    this.GetStripeSource(),
                    this.GetColor(),
                    this.GetRotation(),
                    this.GetOrigin(),
                    this.GetScale(),
                    this.GetEffects(),
                    this.GetLayerDepth() + 0.0001f);
            }
        }

        private void DrawShadows(SpriteBatch batch)
        {
            batch.Draw(
                this.GetTileSheet(),
                this.GetDestination(),
                Textures.BALL_SHADOW,
                this.GetColor(),
                this.GetRotation(),
                this.GetOrigin(),
                this.GetScale(),
                this.GetEffects(),
                this.GetLayerDepth() + 0.0002f);
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
