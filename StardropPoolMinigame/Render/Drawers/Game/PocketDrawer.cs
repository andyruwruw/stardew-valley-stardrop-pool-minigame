using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;

namespace StardropPoolMinigame.Render.Drawers
{
    class PocketDrawer : IDrawer
    {
        private Pocket _entity;

        public PocketDrawer(Pocket pocket)
        {
            this._entity = pocket;
        }

        public void Draw(SpriteBatch batch)
        {

        }

        public Pocket GetEntity()
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
            return new Rectangle();
        }

        public Color GetColor()
        {
            return new Color();
        }

        public float GetRotation()
        {
            return 1;
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
            return new SpriteEffects();
        }

        public float GetLayerDepth()
        {
            return 1;
        }
    }
}
