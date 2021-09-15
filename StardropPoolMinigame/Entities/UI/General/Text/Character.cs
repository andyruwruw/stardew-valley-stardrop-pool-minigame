using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    internal class Character : Entity
    {
        private char _character;

        private Rectangle _charBounds;

        public Character(
            Origin origin,
            Vector2 anchor,
            float layerDepth,
            IFilter enteringTransition,
            IFilter exitingTransition,
            char character
        ) : base(
            origin,
            anchor,
            layerDepth,
            enteringTransition,
            exitingTransition)
        {
            this._character = character;
            this._charBounds = Textures.GetCharacterBoundsFromChar(this._character);

            this.SetDrawer(new CharacterDrawer(this));
        }

        public Rectangle GetCharacterBounds()
        {
            return this._charBounds;
        }

        public override string GetId()
        {
            return $"text-character-{this._id}";
        }

        public override float GetTotalHeight()
        {
            return this._charBounds.Height;
        }

        public override float GetTotalWidth()
        {
            return this._charBounds.Width;
        }
    }
}