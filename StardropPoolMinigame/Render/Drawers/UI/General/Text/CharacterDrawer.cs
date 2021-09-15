using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Render.Filters;
using System.Collections.Generic;

namespace StardropPoolMinigame.Render.Drawers
{
    internal class CharacterDrawer : Drawer
    {
        public CharacterDrawer(Character character) : base(character)
        {
        }

        protected override Vector2 GetDestination(Vector2? overrideDestination = null)
        {
            Vector2 destination = overrideDestination == null ? this.GetRawDestination() : (Vector2)overrideDestination;

            IList<IFilter> filters = this._entity.GetFilters();

            foreach (IFilter filter in filters)
            {
                destination = filter.ExecuteDestination(destination);
            }

            return destination;
        }

        protected override Vector2 GetRawDestination()
        {
            Vector2 destination = base.GetRawDestination();
            return new Vector2(destination.X, destination.Y + (RenderConstants.Font.Y_OFFSET * RenderConstants.TileScale()));
        }

        protected override Rectangle GetRawSource()
        {
            return ((Character)this._entity).GetCharacterBounds();
        }

        protected override Texture2D GetTileset()
        {
            return Textures.Tileset.Font;
        }
    }
}