using Microsoft.Xna.Framework;
using StardropPoolMinigame.Entities;

namespace StardropPoolMinigame.Render.Drawers
{
    class CharacterDrawer : Drawer
    {
        public CharacterDrawer(Character character) : base(character)
        {
        }

        protected override Rectangle GetRawSource()
        {
            return ((Character)this._entity).GetCharacterBounds();
        }
    }
}
