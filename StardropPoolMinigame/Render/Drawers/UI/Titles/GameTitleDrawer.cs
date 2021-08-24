using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;

namespace StardropPoolMinigame.Render.Drawers
{
    class GameTitleDrawer : IDrawer
    {
        private GameTitle _entity;

        public GameTitleDrawer(GameTitle title)
        {
            this._entity = title;
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

        public GameTitle GetEntity()
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
            return Textures.TITLE_GAME_BOUNDS;
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
