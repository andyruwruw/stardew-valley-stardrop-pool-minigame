using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Primitives;
using StardropPoolMinigame.Render.Filters;
using System;

namespace StardropPoolMinigame.Entities
{
    class EastPocket : TableSegment
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

        public override void InicializeBounceableSurfaces()
        {
            base.InicializeBounceableSurfaces();

            // North East Edge
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE,
                            0)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE,
                            RenderConstants.Entities.TableSegment.VERTICAL_POCKET_STRAIGHT_EDGE_HEIGHT))));

            // North East Edge Bare
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE,
                            0)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE + RenderConstants.Entities.TableSegment.UNPASSABLE_LIP,
                            RenderConstants.Entities.TableSegment.VERTICAL_POCKET_STRAIGHT_EDGE_HEIGHT + 1 + RenderConstants.Entities.TableSegment.POCKET_ANGLED_EDGE_HEIGHT))));

            // North East Pocket Angle
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE,
                            RenderConstants.Entities.TableSegment.VERTICAL_POCKET_STRAIGHT_EDGE_HEIGHT + 1)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE + RenderConstants.Entities.TableSegment.UNPASSABLE_LIP,
                            RenderConstants.Entities.TableSegment.VERTICAL_POCKET_STRAIGHT_EDGE_HEIGHT + 1 + RenderConstants.Entities.TableSegment.POCKET_ANGLED_EDGE_HEIGHT))));

            // South East Edge
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.VERTICAL_POCKET_STRAIGHT_EDGE_HEIGHT)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE,
                            this.GetTotalHeight()))));

            // South East Edge Bare
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.VERTICAL_POCKET_STRAIGHT_EDGE_HEIGHT)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE + RenderConstants.Entities.TableSegment.UNPASSABLE_LIP,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.VERTICAL_POCKET_STRAIGHT_EDGE_HEIGHT - 1 - RenderConstants.Entities.TableSegment.POCKET_ANGLED_EDGE_HEIGHT))));

            // South East Pocket Angle
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.VERTICAL_POCKET_STRAIGHT_EDGE_HEIGHT - 1)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE + RenderConstants.Entities.TableSegment.UNPASSABLE_LIP,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.VERTICAL_POCKET_STRAIGHT_EDGE_HEIGHT - 1 - RenderConstants.Entities.TableSegment.POCKET_ANGLED_EDGE_HEIGHT))));
        }
    }
}