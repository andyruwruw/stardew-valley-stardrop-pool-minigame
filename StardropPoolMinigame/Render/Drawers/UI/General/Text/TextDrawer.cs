using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Entities;

namespace StardropPoolMinigame.Render.Drawers
{
    internal class TextDrawer : Drawer
    {
        public TextDrawer(Text text) : base(text)
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
            // Draw all characters
            IList<Character> characters = ((Text)this._entity).GetCharacters();

            foreach (Character character in characters)
            {
                character.GetDrawer().Draw(
                    batch,
                    overrideDestination,
                    overrideSource,
                    overrideColor,
                    overrideRotation,
                    overrideOrigin,
                    ((Text)this._entity).GetScale(),
                    overrideEffects,
                    overrideLayerDepth);
            }
        }

        protected override Rectangle GetRawSource()
        {
            return ((Character)this._entity).GetCharacterBounds();
        }
    }
}