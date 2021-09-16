﻿using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Primitives;
using StardropPoolMinigame.Render.Filters;
using System;

namespace StardropPoolMinigame.Entities
{
    internal class NorthWestEdge : TableSegment
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

        public override string GetId()
        {
            return $"table-segment-north-west-edge-{this._id}";
        }

        public override TableSegmentType GetTableSegmentType()
        {
            return TableSegmentType.NorthWestEdge;
        }

        public override void InitializeBounceableSurfaces()
        {
            base.InitializeBounceableSurfaces();

            // North Edge
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            0,
                            RenderConstants.Entities.TableSegment.SpaceToBounceableSurface)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth(),
                            RenderConstants.Entities.TableSegment.SpaceToBounceableSurface))));

            // West Edge
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            RenderConstants.Entities.TableSegment.SpaceToBounceableSurface,
                            0)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            RenderConstants.Entities.TableSegment.SpaceToBounceableSurface,
                            this.GetTotalHeight()))));
        }
    }
}