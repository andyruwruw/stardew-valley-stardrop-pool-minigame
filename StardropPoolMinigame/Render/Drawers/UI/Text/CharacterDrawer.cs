using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;

namespace StardropPoolMinigame.Render.Drawers
{
    class CharacterDrawer : Drawer
    {
        public CharacterDrawer(Character character) : base(character)
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
            base.Draw(
                batch,
                overrideDestination,
                overrideSource,
                overrideColor,
                overrideRotation,
                overrideOrigin,
                overrideScale,
                overrideEffects,
                overrideLayerDepth);
        }

        protected override Texture2D GetTileSheet()
        {
            return Textures.FontTileSheet;
        }

        protected override Rectangle GetRawSource()
        {
            return ((Character)this._entity).GetCharacterBounds();
        }

        protected override Vector2 GetRawDestination()
        {
            Vector2 destination = base.GetRawDestination();
            return new Vector2(destination.X, destination.Y + (RenderConstants.FONT_Y_OFFSET * RenderConstants.TileScale()));
        }
    }
}
