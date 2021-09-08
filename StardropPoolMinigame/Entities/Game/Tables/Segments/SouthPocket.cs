using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Primitives;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    class SouthPocket : TableSegment
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

        public override void InicializeBounceableSurfaces()
        {
            base.InicializeBounceableSurfaces();

            // South West Edge
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
                            RenderConstants.Entities.TableSegment.VERTICAL_POCKET_STRAIGHT_EDGE_HEIGHT,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE))));

            // South West Pocket Angle
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            RenderConstants.Entities.TableSegment.VERTICAL_POCKET_STRAIGHT_EDGE_HEIGHT,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            RenderConstants.Entities.TableSegment.VERTICAL_POCKET_STRAIGHT_EDGE_HEIGHT + RenderConstants.Entities.TableSegment.POCKET_ANGLED_EDGE_HEIGHT,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE + RenderConstants.Entities.TableSegment.UNPASSABLE_LIP))));

            // South West Bare Edge
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            RenderConstants.Entities.TableSegment.VERTICAL_POCKET_STRAIGHT_EDGE_HEIGHT + RenderConstants.Entities.TableSegment.POCKET_ANGLED_EDGE_HEIGHT,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE + RenderConstants.Entities.TableSegment.UNPASSABLE_LIP)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            RenderConstants.Entities.TableSegment.VERTICAL_POCKET_STRAIGHT_EDGE_HEIGHT + RenderConstants.Entities.TableSegment.POCKET_ANGLED_EDGE_HEIGHT + RenderConstants.Entities.TableSegment.FLAT_POCKET_BARE_EDGE_LENGTH,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE + RenderConstants.Entities.TableSegment.UNPASSABLE_LIP))));

            // South East Edge
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth(),
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.VERTICAL_POCKET_STRAIGHT_EDGE_HEIGHT,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE))));

            // South East Pocket Angle
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.VERTICAL_POCKET_STRAIGHT_EDGE_HEIGHT,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.VERTICAL_POCKET_STRAIGHT_EDGE_HEIGHT - RenderConstants.Entities.TableSegment.POCKET_ANGLED_EDGE_HEIGHT,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE + RenderConstants.Entities.TableSegment.UNPASSABLE_LIP))));

            // South East Bare Edge
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.VERTICAL_POCKET_STRAIGHT_EDGE_HEIGHT - RenderConstants.Entities.TableSegment.POCKET_ANGLED_EDGE_HEIGHT,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE + RenderConstants.Entities.TableSegment.UNPASSABLE_LIP)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.VERTICAL_POCKET_STRAIGHT_EDGE_HEIGHT - RenderConstants.Entities.TableSegment.POCKET_ANGLED_EDGE_HEIGHT - RenderConstants.Entities.TableSegment.FLAT_POCKET_BARE_EDGE_LENGTH,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE + RenderConstants.Entities.TableSegment.UNPASSABLE_LIP))));
        }

        public override void InicializePockets()
        {
            base.InicializePockets();

            this._pockets.Add(
                new Circle(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() / 2,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.MARGIN - RenderConstants.Entities.TableSegment.BORDER - RenderConstants.Entities.TableSegment.FLAT_POCKET_BORDER_OFFSET)),
                    RenderConstants.Entities.TableSegment.POCKET_RADIUS));
        }
    }
}
