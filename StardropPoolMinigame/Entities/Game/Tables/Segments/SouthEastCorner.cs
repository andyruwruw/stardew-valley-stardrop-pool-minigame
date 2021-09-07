using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Filters;
using System;

namespace StardropPoolMinigame.Entities
{
    class SouthEastCorner : TableSegment
    {
        public SouthEastCorner(
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
            return $"table-segment-south-east-corner-{this._id}";
        }

        public override TableSegmentType GetTableSegmentType()
        {
            return TableSegmentType.SouthEastCorner;
        }
    }
}