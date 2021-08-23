using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Players;

namespace StardropPoolMinigame.Render.Drawers
{
    class ComputerOpponentDrawer: IDrawer
    {
        private ComputerOpponent _entity;

        public ComputerOpponentDrawer(ComputerOpponent character)
        {
            this._entity = character;
        }

        public void Draw(SpriteBatch batch)
        {

        }

        public ComputerOpponent GetEntity()
        {
            return this._entity;
        }

        public Texture2D GetTileSheet()
        {
            return Textures.TileSheet;
        }

        public Vector2 GetDestination()
        {
            return new Vector2();
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
            return 1f;
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
