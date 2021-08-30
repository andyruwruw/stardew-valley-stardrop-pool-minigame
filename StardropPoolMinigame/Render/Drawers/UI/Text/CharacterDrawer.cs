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

        protected override Texture2D GetTileset()
        {
            return Textures.Tileset.Font;
        }

        protected override Rectangle GetRawSource()
        {
            return ((Character)this._entity).GetCharacterBounds();
        }

        protected override Vector2 GetRawDestination()
        {
            Vector2 destination = base.GetRawDestination();
            return new Vector2(destination.X, destination.Y + (RenderConstants.Font.Y_OFFSET * RenderConstants.TileScale()));
        }
    }
}
