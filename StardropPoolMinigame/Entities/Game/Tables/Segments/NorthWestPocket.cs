using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Primitives;
using StardropPoolMinigame.Render.Filters;
using System;

namespace StardropPoolMinigame.Entities
{
    internal class NorthWestPocket : TableSegment
    {
        public NorthWestPocket(
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
            return $"table-segment-north-west-pocket-{this._id}";
        }

        public override TableSegmentType GetTableSegmentType()
        {
            return TableSegmentType.NorthWestPocket;
        }

        public override void InitializeBounceableSurfaces()
        {
            base.InitializeBounceableSurfaces();

            // North East Pocket Angle
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth(),
                            RenderConstants.Entities.TableSegment.SpaceToBounceableSurface)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.PocketAngledEdgeHeight,
                            RenderConstants.Entities.TableSegment.SpaceToBounceableSurface - RenderConstants.Entities.TableSegment.UnpassableLip))));

            // North East Bare Edge
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.PocketAngledEdgeHeight - RenderConstants.Entities.TableSegment.AngledPocketBareEdgeLength,
                            RenderConstants.Entities.TableSegment.SpaceToBounceableSurface - RenderConstants.Entities.TableSegment.UnpassableLip)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.PocketAngledEdgeHeight,
                            RenderConstants.Entities.TableSegment.SpaceToBounceableSurface - RenderConstants.Entities.TableSegment.UnpassableLip))));

            // South West Pocket Angle
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            RenderConstants.Entities.TableSegment.SpaceToBounceableSurface,
                            this.GetTotalHeight())),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            RenderConstants.Entities.TableSegment.SpaceToBounceableSurface - RenderConstants.Entities.TableSegment.UnpassableLip,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.PocketAngledEdgeHeight))));

            // South West Bare Edge
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            RenderConstants.Entities.TableSegment.SpaceToBounceableSurface - RenderConstants.Entities.TableSegment.UnpassableLip,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.PocketAngledEdgeHeight)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            RenderConstants.Entities.TableSegment.SpaceToBounceableSurface - RenderConstants.Entities.TableSegment.UnpassableLip,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.PocketAngledEdgeHeight - RenderConstants.Entities.TableSegment.AngledPocketBareEdgeLength))));
        }

        public override void InitializePockets()
        {
            base.InitializePockets();

            this._pockets.Add(
                new Circle(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border + RenderConstants.Entities.TableSegment.AngledPocketBorderOffset,
                            RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border + RenderConstants.Entities.TableSegment.AngledPocketBorderOffset)),
                    RenderConstants.Entities.TableSegment.PocketRadius));
        }
    }
}