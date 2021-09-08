using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Primitives;
using StardropPoolMinigame.Render.Filters;
using System;

namespace StardropPoolMinigame.Entities
{
    class NorthWestPocket : TableSegment
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

        public override void InicializeBounceableSurfaces()
        {
            base.InicializeBounceableSurfaces();

            // North East Pocket Angle
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth(),
                            RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.POCKET_ANGLED_EDGE_HEIGHT,
                            RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE - RenderConstants.Entities.TableSegment.UNPASSABLE_LIP))));

            // North East Bare Edge
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.POCKET_ANGLED_EDGE_HEIGHT - RenderConstants.Entities.TableSegment.ANGLED_POCKET_BARE_EDGE_LENGTH,
                            RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE - RenderConstants.Entities.TableSegment.UNPASSABLE_LIP)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            this.GetTotalWidth() - RenderConstants.Entities.TableSegment.POCKET_ANGLED_EDGE_HEIGHT,
                            RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE - RenderConstants.Entities.TableSegment.UNPASSABLE_LIP))));

            // South West Pocket Angle
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE,
                            this.GetTotalHeight())),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE - RenderConstants.Entities.TableSegment.UNPASSABLE_LIP,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.POCKET_ANGLED_EDGE_HEIGHT))));

            // South West Bare Edge
            this._bounceableSurfaces.Add(
                new Line(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE - RenderConstants.Entities.TableSegment.UNPASSABLE_LIP,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.POCKET_ANGLED_EDGE_HEIGHT)),
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            RenderConstants.Entities.TableSegment.SPACE_TO_BOUNCEABLE_SURFACE - RenderConstants.Entities.TableSegment.UNPASSABLE_LIP,
                            this.GetTotalHeight() - RenderConstants.Entities.TableSegment.POCKET_ANGLED_EDGE_HEIGHT - RenderConstants.Entities.TableSegment.ANGLED_POCKET_BARE_EDGE_LENGTH))));
        }

        public override void InicializePockets()
        {
            base.InicializePockets();

            this._pockets.Add(
                new Circle(
                    Vector2.Add(
                        this._anchor,
                        new Vector2(
                            RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER + RenderConstants.Entities.TableSegment.ANGLED_POCKET_BORDER_OFFSET,
                            RenderConstants.Entities.TableSegment.MARGIN + RenderConstants.Entities.TableSegment.BORDER + RenderConstants.Entities.TableSegment.ANGLED_POCKET_BORDER_OFFSET)),
                    RenderConstants.Entities.TableSegment.POCKET_RADIUS));
        }
    }
}