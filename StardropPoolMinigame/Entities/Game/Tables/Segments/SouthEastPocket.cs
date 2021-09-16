using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Primitives;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    internal class SouthEastPocket : TableSegment
    {
        public SouthEastPocket(
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
            return $"table-segment-south-east-pocket-{this._id}";
        }

        public override TableSegmentType GetTableSegmentType()
        {
            return TableSegmentType.SouthEastPocket;
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
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.SpaceToBounceableSurface,
                            0)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.SpaceToBounceableSurface + RenderConstants.Entities.TableSegment.UnpassableLip,
                            RenderConstants.Entities.TableSegment.PocketAngledEdgeHeight))));

            // North East Bare Edge
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.SpaceToBounceableSurface + RenderConstants.Entities.TableSegment.UnpassableLip,
                            RenderConstants.Entities.TableSegment.PocketAngledEdgeHeight)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.SpaceToBounceableSurface + RenderConstants.Entities.TableSegment.UnpassableLip,
                            RenderConstants.Entities.TableSegment.PocketAngledEdgeHeight + RenderConstants.Entities.TableSegment.AngledPocketBareEdgeLength))));

            // South West Pocket Angle
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
                            RenderConstants.Entities.TableSegment.PocketAngledEdgeHeight,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.SpaceToBounceableSurface + RenderConstants.Entities.TableSegment.UnpassableLip))));

            // South West Bare Edge
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                         new Vector2(
                            RenderConstants.Entities.TableSegment.PocketAngledEdgeHeight,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.SpaceToBounceableSurface + RenderConstants.Entities.TableSegment.UnpassableLip)),
                    Vector2.Add(
                        this._anchor,
                         new Vector2(
                            RenderConstants.Entities.TableSegment.PocketAngledEdgeHeight + RenderConstants.Entities.TableSegment.AngledPocketBareEdgeLength,
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
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.Margin - RenderConstants.Entities.TableSegment.Border - RenderConstants.Entities.TableSegment.AngledPocketBorderOffset,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.Margin - RenderConstants.Entities.TableSegment.Border - RenderConstants.Entities.TableSegment.AngledPocketBorderOffset)),
                    RenderConstants.Entities.TableSegment.PocketRadius));
        }
    }
}