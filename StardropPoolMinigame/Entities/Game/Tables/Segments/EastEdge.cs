﻿using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Primitives;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    internal class EastEdge : TableSegment
    {
        public EastEdge(
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
            return $"table-segment-east-edge-{this._id}";
        }

        public override TableSegmentType GetTableSegmentType()
        {
            return TableSegmentType.EastEdge;
        }

        public override void InitializeBounceableSurfaces()
        {
            base.InitializeBounceableSurfaces();

            // East Edge
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.SpaceToBounceableSurface,
                            0)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.SpaceToBounceableSurface,
                            this.GetTotalHeight()))));
        }
    }
}