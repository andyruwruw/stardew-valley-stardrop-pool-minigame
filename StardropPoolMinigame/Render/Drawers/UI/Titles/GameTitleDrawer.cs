using Microsoft.Xna.Framework;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Render.Filters;
using System.Collections.Generic;

namespace StardropPoolMinigame.Render.Drawers
{
    class GameTitleDrawer : Drawer
    {
        public GameTitleDrawer(GameTitle title) : base(title)
        {
        }

        protected override Vector2 GetDestination()
        {
            Vector2 destination = this.GetRawDestination();

            IList<IFilter> filters = this._entity.GetFilters();

            foreach (IFilter filter in filters)
            {
                destination = filter.ExecuteDestination(destination);
            }

            return destination;
        }

        protected override Rectangle GetRawSource()
        {
            return Textures.TITLE_GAME_BOUNDS;
        }
    }
}
