using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    class SouthWestPocket : TableSegment
    {
        public SouthWestPocket(
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

        public override TableSegmentType GetTableSegmentType()
        {
            return TableSegmentType.SouthWestPocket;
        }
    }
}