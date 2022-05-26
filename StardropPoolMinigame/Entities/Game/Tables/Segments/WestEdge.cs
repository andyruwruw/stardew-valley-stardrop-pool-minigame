using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Primitives;
using StardropPoolMinigame.Render.Filters;
using System;

namespace StardropPoolMinigame.Entities
{
    internal class WestEdge : TableSegment
    {
        public WestEdge(
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
            return $"table-segment-west-edge-{this._id}";
        }

        public override TableSegmentType GetTableSegmentType()
        {
            return TableSegmentType.WestEdge;
        }

        public override void InitializeBounceableSurfaces()
        {
            base.InitializeBounceableSurfaces();

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