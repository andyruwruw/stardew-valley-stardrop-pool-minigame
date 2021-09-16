using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Primitives;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    internal class SouthPocket : TableSegment
    {
        public SouthPocket(
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
            return $"table-segment-south-pocket-{this._id}";
        }

        public override TableSegmentType GetTableSegmentType()
        {
            return TableSegmentType.SouthPocket;
        }

        public override void InitializeBounceableSurfaces()
        {
            base.InitializeBounceableSurfaces();

            // South West Edge
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            0,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.SpaceToBounceableSurface)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            RenderConstants.Entities.TableSegment.VerticalPocketStraightEdgeHeight,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.SpaceToBounceableSurface))));

            // South West Pocket Angle
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            RenderConstants.Entities.TableSegment.VerticalPocketStraightEdgeHeight,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.SpaceToBounceableSurface)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            RenderConstants.Entities.TableSegment.VerticalPocketStraightEdgeHeight + RenderConstants.Entities.TableSegment.PocketAngledEdgeHeight,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.SpaceToBounceableSurface + RenderConstants.Entities.TableSegment.UnpassableLip))));

            // South West Bare Edge
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            RenderConstants.Entities.TableSegment.VerticalPocketStraightEdgeHeight + RenderConstants.Entities.TableSegment.PocketAngledEdgeHeight,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.SpaceToBounceableSurface + RenderConstants.Entities.TableSegment.UnpassableLip)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            RenderConstants.Entities.TableSegment.VerticalPocketStraightEdgeHeight + RenderConstants.Entities.TableSegment.PocketAngledEdgeHeight + RenderConstants.Entities.TableSegment.FlatPocketBareEdgeLength,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.SpaceToBounceableSurface + RenderConstants.Entities.TableSegment.UnpassableLip))));

            // South East Edge
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth(),
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.SpaceToBounceableSurface)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.VerticalPocketStraightEdgeHeight,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.SpaceToBounceableSurface))));

            // South East Pocket Angle
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.VerticalPocketStraightEdgeHeight,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.SpaceToBounceableSurface)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.VerticalPocketStraightEdgeHeight - RenderConstants.Entities.TableSegment.PocketAngledEdgeHeight,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.SpaceToBounceableSurface + RenderConstants.Entities.TableSegment.UnpassableLip))));

            // South East Bare Edge
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.VerticalPocketStraightEdgeHeight - RenderConstants.Entities.TableSegment.PocketAngledEdgeHeight,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.SpaceToBounceableSurface + RenderConstants.Entities.TableSegment.UnpassableLip)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.VerticalPocketStraightEdgeHeight - RenderConstants.Entities.TableSegment.PocketAngledEdgeHeight - RenderConstants.Entities.TableSegment.FlatPocketBareEdgeLength,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.SpaceToBounceableSurface + RenderConstants.Entities.TableSegment.UnpassableLip))));
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
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.Margin - RenderConstants.Entities.TableSegment.Border - RenderConstants.Entities.TableSegment.FlatPocketBorderOffset)),
                    RenderConstants.Entities.TableSegment.PocketRadius));
        }
    }
}