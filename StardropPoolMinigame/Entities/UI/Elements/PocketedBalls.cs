using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities.UI.Background
{
    class PocketedBalls : EntityStatic
    {
        public PocketedBalls(
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
        }

        public override float GetTotalHeight()
        {
            return Textures.POCKETED_BALLS_BORDER_BOX_SUPPORTS_BOUNDS.Height;
        }

        public override float GetTotalWidth()
        {
            return Textures.POCKETED_BALLS_BORDER_BOX_SUPPORTS_BOUNDS.Width;
        }
    }
}
