using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Primitives;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    internal class NorthPocket : TableSegment
    {
        public NorthPocket(
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
            return $"table-segment-north-pocket-{this._id}";
        }

        public override TableSegmentType GetTableSegmentType()
        {
            return TableSegmentType.NorthPocket;
        }

        public override void InitializeBounceableSurfaces()
        {
            base.InitializeBounceableSurfaces();

            // North West Edge
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
                            RenderConstants.Entities.TableSegment.VerticalPocketStraightEdgeHeight,
                            RenderConstants.Entities.TableSegment.SpaceToBounceableSurface))));

            // North West Pocket Angle
            //this._bounceableSurfaces.Add(
            //    new Line(
            //        Vector2.Add(
            //            this._anchor,
            //            new Vector2(
            //                RenderConstants.Entities.TableSegment.VerticalPocketStraightEdgeHeight,
            //                RenderConstants.Entities.TableSegment.SpaceToBounceableSurface)),
            //        Vector2.Add(
            //            this._anchor,
            //            new Vector2(
            //                RenderConstants.Entities.TableSegment.VerticalPocketStraightEdgeHeight + RenderConstants.Entities.TableSegment.PocketAngledEdgeHeight,
            //                RenderConstants.Entities.TableSegment.SpaceToBounceableSurface - RenderConstants.Entities.TableSegment.UnpassableLip))));

            // North West Bare Edge
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            RenderConstants.Entities.TableSegment.VerticalPocketStraightEdgeHeight + RenderConstants.Entities.TableSegment.PocketAngledEdgeHeight,
                            RenderConstants.Entities.TableSegment.SpaceToBounceableSurface - RenderConstants.Entities.TableSegment.UnpassableLip)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            RenderConstants.Entities.TableSegment.VerticalPocketStraightEdgeHeight + RenderConstants.Entities.TableSegment.PocketAngledEdgeHeight + RenderConstants.Entities.TableSegment.FlatPocketBareEdgeLength,
                            RenderConstants.Entities.TableSegment.SpaceToBounceableSurface - RenderConstants.Entities.TableSegment.UnpassableLip))));

            // North East Edge
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
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.VerticalPocketStraightEdgeHeight,
                            RenderConstants.Entities.TableSegment.SpaceToBounceableSurface))));

            // North East Pocket Angle
            //this._bounceableSurfaces.Add(
            //    new Line(
            //        Vector2.Add(
            //            this._anchor,
            //            new Vector2(
            //                this.GetTotalWidth() - RenderConstants.Entities.TableSegment.VerticalPocketStraightEdgeHeight,
            //                RenderConstants.Entities.TableSegment.SpaceToBounceableSurface)),
            //        Vector2.Add(
            //            this._anchor,
            //            new Vector2(
            //                this.GetTotalWidth() - RenderConstants.Entities.TableSegment.VerticalPocketStraightEdgeHeight - RenderConstants.Entities.TableSegment.PocketAngledEdgeHeight,
            //                RenderConstants.Entities.TableSegment.SpaceToBounceableSurface - RenderConstants.Entities.TableSegment.UnpassableLip))));

            // North East Bare Edge
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.VerticalPocketStraightEdgeHeight - RenderConstants.Entities.TableSegment.PocketAngledEdgeHeight,
                            RenderConstants.Entities.TableSegment.SpaceToBounceableSurface - RenderConstants.Entities.TableSegment.UnpassableLip)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.VerticalPocketStraightEdgeHeight - RenderConstants.Entities.TableSegment.PocketAngledEdgeHeight - RenderConstants.Entities.TableSegment.FlatPocketBareEdgeLength,
                            RenderConstants.Entities.TableSegment.SpaceToBounceableSurface - RenderConstants.Entities.TableSegment.UnpassableLip))));
        }

        public override void InitializePockets()
        {
            base.InitializePockets();

            this._pockets.Add(
                new Circle(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() / 2,
                            RenderConstants.Entities.TableSegment.Margin + RenderConstants.Entities.TableSegment.Border + RenderConstants.Entities.TableSegment.FlatPocketBorderOffset)),
                    RenderConstants.Entities.TableSegment.PocketRadius));
        }
    }
}