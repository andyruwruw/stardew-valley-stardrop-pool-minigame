using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;

namespace StardropPoolMinigame.Render.Drawers
{
    class BallDrawer : IDrawer
    {
        private Ball _entity;

        public BallDrawer(Ball ball)
        {
            this._entity = ball;
        }

        public void Draw(SpriteBatch batch)
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

            if (this._entity.GetBallType() == BallType.Stripped)
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

        public Ball GetEntity()
        {
            return this._entity;
        }

        public Texture2D GetTileSheet()
        {
            return Textures.TileSheet;
        }

        public Vector2 GetDestination()
        {
            Vector2 topLeft = this._entity.GetTopLeft();
            return new Vector2(
                (topLeft.X - RenderConstants.BALL_MARGIN_LEFT) * RenderConstants.TileScale() + RenderConstants.AdjustedScreenWidthMargin(), 
                (topLeft.Y - RenderConstants.BALL_MARGIN_TOP) * RenderConstants.TileScale() + RenderConstants.AdjustedScreenHeightMargin());
        }

        public Rectangle GetCoreSource()
        {
            return Textures.GetBallCoreBounds(this._entity.GetOrientation().GetFace());
        }

        public Rectangle GetStripeSource()
        {
            return Textures.GetBallStripesBounds(this._entity.GetOrientation().GetFace());
        }

        public Rectangle GetSource()
        {
            switch (this._entity.GetBallColor())
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

        public Color GetColor()
        {
            return Color.White;
        }

        public float GetRotation()
        {
            return 0f;
        }

        public Vector2 GetOrigin()
        {
            return new Vector2(0, 0);
        }

        public float GetScale()
        {
            return RenderConstants.TileScale();
        }

        public SpriteEffects GetEffects()
        {
            return SpriteEffects.None;
        }

        public float GetLayerDepth()
        {
            return this._entity.GetLayerDepth();
        }
    }
}
