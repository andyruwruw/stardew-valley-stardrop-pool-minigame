using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Primitives;
using StardropPoolMinigame.Render.Filters;
using System;

namespace StardropPoolMinigame.Entities
{
    internal class EastPocket : TableSegment
    {
        public EastPocket(
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
            return $"table-segment-east-pocket-{this._id}";
        }

        public override TableSegmentType GetTableSegmentType()
        {
            return TableSegmentType.EastPocket;
        }

        public override void InitializeBounceableSurfaces()
        {
            base.InitializeBounceableSurfaces();

            // North East Edge
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
                            RenderConstants.Entities.TableSegment.VerticalPocketStraightEdgeHeight))));

            // North East Edge Bare
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
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.SpaceToBounceableSurface + RenderConstants.Entities.TableSegment.UnpassableLip,
                            RenderConstants.Entities.TableSegment.VerticalPocketStraightEdgeHeight + 1 + RenderConstants.Entities.TableSegment.PocketAngledEdgeHeight))));

            // North East Pocket Angle
            //this._bounceableSurfaces.Add(
            //    new Line(
            //        Vector2.Add(
            //            this._anchor,
            //            new Vector2(
            //                this.GetTotalWidth() - RenderConstants.Entities.TableSegment.SpaceToBounceableSurface,
            //                RenderConstants.Entities.TableSegment.VerticalPocketStraightEdgeHeight + 1)),
            //        Vector2.Add(
            //            this._anchor,
            //            new Vector2(
            //                this.GetTotalWidth() - RenderConstants.Entities.TableSegment.SpaceToBounceableSurface + RenderConstants.Entities.TableSegment.UnpassableLip,
            //                RenderConstants.Entities.TableSegment.VerticalPocketStraightEdgeHeight + 1 + RenderConstants.Entities.TableSegment.PocketAngledEdgeHeight))));

            // South East Edge
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.SpaceToBounceableSurface,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.VerticalPocketStraightEdgeHeight)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.SpaceToBounceableSurface,
                            this.GetTotalHeight()))));

            // South East Edge Bare
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.SpaceToBounceableSurface,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.VerticalPocketStraightEdgeHeight)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.SpaceToBounceableSurface + RenderConstants.Entities.TableSegment.UnpassableLip,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.VerticalPocketStraightEdgeHeight - 1 - RenderConstants.Entities.TableSegment.PocketAngledEdgeHeight))));

            //// South East Pocket Angle
            //this._bounceableSurfaces.Add(
            //    new Line(
            //        Vector2.Add(
            //            this._anchor,
            //            new Vector2(
            //                this.GetTotalWidth() - RenderConstants.Entities.TableSegment.SpaceToBounceableSurface,
            //                this.GetTotalHeight() - RenderConstants.Entities.TableSegment.VerticalPocketStraightEdgeHeight - 1)),
            //        Vector2.Add(
            //            this._anchor,
            //            new Vector2(
            //                this.GetTotalWidth() - RenderConstants.Entities.TableSegment.SpaceToBounceableSurface + RenderConstants.Entities.TableSegment.UnpassableLip,
            //                this.GetTotalHeight() - RenderConstants.Entities.TableSegment.VerticalPocketStraightEdgeHeight - 1 - RenderConstants.Entities.TableSegment.PocketAngledEdgeHeight))));
        }
    }
}