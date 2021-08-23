using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Drawers;

namespace StardropPoolMinigame.Entities
{
    class GameTitle : Entity
    {
        public GameTitle(Origin origin, Vector2 anchor) : base(origin, anchor)
        {
        }

        public override void Update()
        {
        }

        public Microsoft.Xna.Framework.Rectangle GetSource()
        {
            return Textures.TITLE_GAME_BOUNDS;
        }

        public override IDrawer GetDrawer()
        {
            return new GameTitleDrawer(this);
        }

        public override string GetId()
        {
            return $"game-title-{this._id}";
        }

        public override float GetTotalWidth()
        {
            return Textures.TITLE_GAME_BOUNDS.Width;
        }

        public override float GetTotalHeight()
        {
            return Textures.TITLE_GAME_BOUNDS.Height;
        }
    }
}
