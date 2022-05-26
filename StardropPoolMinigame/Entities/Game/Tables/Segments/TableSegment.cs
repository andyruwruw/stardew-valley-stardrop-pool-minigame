using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Primitives;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;
using System;
using System.Collections.Generic;

namespace StardropPoolMinigame.Entities
{
    internal abstract class TableSegment : Entity
    {
        protected IList<IRange> _bounceableSurfaces;

        protected IList<Circle> _pockets;

        public TableSegment(
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
            this.InitializeBounceableSurfaces();
            this.InitializePockets();
            this.SetDrawer(new TableSegmentDrawer(this));
        }

        public static TableSegment GetTableSegmentFromType(
            TableSegmentType type,
            Origin origin,
            Vector2 anchor,
            float layerDepth,
            IFilter enteringTransition,
            IFilter exitingTransition)
        {
            switch (type)
            {
                case TableSegmentType.NorthEdge:
                    return new NorthEdge(origin, anchor, layerDepth, enteringTransition, exitingTransition);
                case TableSegmentType.SouthEdge:
                    return new SouthEdge(origin, anchor, layerDepth, enteringTransition, exitingTransition);
                case TableSegmentType.WestEdge:
                    return new WestEdge(origin, anchor, layerDepth, enteringTransition, exitingTransition);
                case TableSegmentType.EastEdge:
                    return new EastEdge(origin, anchor, layerDepth, enteringTransition, exitingTransition);
                case TableSegmentType.NorthWestEdge:
                    return new NorthWestEdge(origin, anchor, layerDepth, enteringTransition, exitingTransition);
                case TableSegmentType.NorthEastEdge:
                    return new NorthEastEdge(origin, anchor, layerDepth, enteringTransition, exitingTransition);
                case TableSegmentType.SouthWestEdge:
                    return new SouthWestEdge(origin, anchor, layerDepth, enteringTransition, exitingTransition);
                case TableSegmentType.SouthEastEdge:
                    return new SouthEastEdge(origin, anchor, layerDepth, enteringTransition, exitingTransition);
                case TableSegmentType.NorthWestCorner:
                    return new NorthWestCorner(origin, anchor, layerDepth, enteringTransition, exitingTransition);
                case TableSegmentType.NorthEastCorner:
                    return new NorthEastCorner(origin, anchor, layerDepth, enteringTransition, exitingTransition);
                case TableSegmentType.SouthWestCorner:
                    return new SouthWestCorner(origin, anchor, layerDepth, enteringTransition, exitingTransition);
                case TableSegmentType.SouthEastCorner:
                    return new SouthEastCorner(origin, anchor, layerDepth, enteringTransition, exitingTransition);
                case TableSegmentType.NorthPocket:
                    return new NorthPocket(origin, anchor, layerDepth, enteringTransition, exitingTransition);
                case TableSegmentType.SouthPocket:
                    return new SouthPocket(origin, anchor, layerDepth, enteringTransition, exitingTransition);
                case TableSegmentType.WestPocket:
                    return new WestPocket(origin, anchor, layerDepth, enteringTransition, exitingTransition);
                case TableSegmentType.EastPocket:
                    return new EastPocket(origin, anchor, layerDepth, enteringTransition, exitingTransition);
                case TableSegmentType.NorthWestPocket:
                    return new NorthWestPocket(origin, anchor, layerDepth, enteringTransition, exitingTransition);
                case TableSegmentType.NorthEastPocket:
                    return new NorthEastPocket(origin, anchor, layerDepth, enteringTransition, exitingTransition);
                case TableSegmentType.SouthWestPocket:
                    return new SouthWestPocket(origin, anchor, layerDepth, enteringTransition, exitingTransition);
                case TableSegmentType.SouthEastPocket:
                    return new SouthEastPocket(origin, anchor, layerDepth, enteringTransition, exitingTransition);
                case TableSegmentType.Felt:
                    return new Felt(origin, anchor, layerDepth, enteringTransition, exitingTransition);
                default:
                    return null;
            }
        }

        public IList<IRange> GetBounceableSurfaces()
        {
            return this._bounceableSurfaces;
        }

        public override string GetId()
        {
            return $"generic-table-segment-{this._id}";
        }

        public IList<Circle> GetPockets()
        {
            return this._pockets;
        }

        public abstract TableSegmentType GetTableSegmentType();

        public override float GetTotalHeight()
        {
            return Textures.Table.Edge.Back.NORTH.Height;
        }

        public override float GetTotalWidth()
        {
            return Textures.Table.Edge.Back.NORTH.Width;
        }

        public virtual void InitializeBounceableSurfaces()
        {
            this._bounceableSurfaces = new List<IRange>();
        }

        public virtual void InitializePockets()
        {
            this._pockets = new List<Circle>();
        }
    }
}