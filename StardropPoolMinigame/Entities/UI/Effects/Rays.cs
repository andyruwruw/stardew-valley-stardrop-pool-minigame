using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities.UI.Background
{
    class Rays : EntityStatic
    {
        public Rays(
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
            return Textures.EFFECTS_SHINE_BOUNDS.Height;
        }

        public override float GetTotalWidth()
        {
            return Textures.EFFECTS_SHINE_BOUNDS.Width;
        }
    }
}