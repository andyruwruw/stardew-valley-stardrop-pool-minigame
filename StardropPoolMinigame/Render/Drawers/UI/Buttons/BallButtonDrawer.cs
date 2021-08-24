using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;

namespace StardropPoolMinigame.Render.Drawers
{
    class BallButtonDrawer : IDrawer
    {
        private BallButton _entity;

        public BallButtonDrawer(BallButton button)
        {
            this._entity = button;
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(
                this.GetTileSheet(),
                this.GetTextDestination(),
                this.GetSource(),
                this.GetColor(),
                this.GetRotation(),
                this.GetOrigin(),
                this.GetScale(),
                this.GetEffects(),
                this.GetLayerDepth());

            Ball ball = this._entity.GetBall();
            ball.GetDrawer().Draw(batch);
        }

        public BallButton GetEntity()
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
            return new Vector2(topLeft.X * RenderConstants.TileScale() + RenderConstants.AdjustedScreenWidthMargin(), topLeft.Y * RenderConstants.TileScale() + RenderConstants.AdjustedScreenHeightMargin());
        }

        public Rectangle GetSource()
        {
            if (this._entity.IsHovered())
            {
                return this._entity.GetTextBounds();
            }
            return this._entity.GetTextBounds();
        }

        public Color GetColor()
        {
            if (this._entity.IsHovered())
            {
                return Textures.TEXT_HOVER_COLOR;
            }
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
        private Vector2 GetTextDestination()
        {
            Vector2 topLeft = this._entity.GetTopLeft();
            return new Vector2(
                (topLeft.X + (GameConstants.BALL_RADIUS * 2) + RenderConstants.BALL_BUTTON_INNER_PADDING) * RenderConstants.TileScale() + RenderConstants.AdjustedScreenWidthMargin(),
                topLeft.Y * RenderConstants.TileScale() + RenderConstants.AdjustedScreenHeightMargin());
        }
    }
}
