﻿using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Primitives;
using StardropPoolMinigame.Render.Filters;
using System;

namespace StardropPoolMinigame.Entities
{
    class SouthEastEdge : TableSegment
    {
        public SouthEastEdge(
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
            return $"table-segment-south-east-edge-{this._id}";
        }

        public override TableSegmentType GetTableSegmentType()
        {
            return TableSegmentType.SouthEastEdge;
        }

        public override void InicializeBounceableSurfaces()
        {
            base.InicializeBounceableSurfaces();

            // South Edge
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            0,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth(),
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE))));

            
        }
    }
}