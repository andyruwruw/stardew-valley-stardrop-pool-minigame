using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Filters;
using System;

namespace StardropPoolMinigame.Entities
{
    class SouthEastPocket : TableSegment
    {
        public SouthEastPocket(
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

        public override string GetId()
        {
            return $"table-segment-south-east-pocket-{this._id}";
        }

        public override TableSegmentType GetTableSegmentType()
        {
            return TableSegmentType.SouthEastPocket;
        }
    }
}