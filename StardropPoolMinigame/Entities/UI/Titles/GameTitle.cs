using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    class GameTitle : EntityStatic
    {
        public GameTitle(
            Origin origin,
            Vector2 anchor,
            float layerDepth,
            IFilter enteringTransition,
            IFilter exitingTransition
        ) : base(
            origin,
            anchor,
            layerDepth,
            enteringTransition,
            exitingTransition)
        {
            this.SetDrawer(new GameTitleDrawer(this));
        }

        public override string GetId()
        {
            return $"game-title-{this._id}";
        }

        public override float GetTotalWidth()
        {
            return Textures.GAME_TITLE.Width;
        }

        public override float GetTotalHeight()
        {
            return Textures.GAME_TITLE.Height;
        }
    }
}
