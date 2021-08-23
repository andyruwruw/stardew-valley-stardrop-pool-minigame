using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
                this.GetDestination(),
                this.GetSource(),
                this.GetColor(),
                this.GetRotation(),
                this.GetOrigin(),
                this.GetScale(),
                this.GetEffects(),
                this.GetLayerDepth());
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
                return new Rectangle(0, 0, 0, 0);
            }
            return this._entity.GetTextBounds();
        }

        public Color GetColor()
        {
            if (this._entity.IsHovered())
            {
                return Color.Yellow;
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
            return 1f;
        }
    }
}
