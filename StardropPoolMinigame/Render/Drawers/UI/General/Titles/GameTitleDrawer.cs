using Microsoft.Xna.Framework;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Render.Filters;
using System.Collections.Generic;

namespace StardropPoolMinigame.Render.Drawers
{
    internal class GameTitleDrawer : Drawer
    {
        public GameTitleDrawer(GameTitle title) : base(title)
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

        protected override Rectangle GetRawSource()
        {
            return Textures.GAME_TITLE;
        }
    }
}