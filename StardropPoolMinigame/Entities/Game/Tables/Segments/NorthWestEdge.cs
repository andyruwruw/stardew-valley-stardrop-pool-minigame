﻿using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    class NorthWestEdge : TableSegment
    {
        public NorthWestEdge(
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
            return TableSegmentType.NorthWestEdge;
        }
    }
}
