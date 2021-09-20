﻿using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;
using System;
using System.Collections.Generic;

namespace StardropPoolMinigame.Entities
{
    internal class Table : Entity
    {
        private IList<IList<TableSegment>> _layout;

        private TableType _type;

        public Table(
            Origin origin,
            Vector2 anchor,
            float layerDepth,
            IFilter enteringTransition,
            IFilter exitingTransition,
            TableType type
        ) : base(
            origin,
            anchor,
            layerDepth,
            enteringTransition,
            exitingTransition)
        {
            this._type = type;
            this._layout = null;

            this.CreateTable();
            this.SetDrawer(new TableDrawer(this));
        }

        public static Table GetDefaultTable()
        {
            return new Table(
                Origin.CenterCenter,
                new Vector2(RenderConstants.MinigameScreen.Width / 2, RenderConstants.MinigameScreen.Height / 2),
                RenderConstants.Scenes.Game.LayerDepth.Table,
                null,
                null,
                TableType.Classic);
        }

        public override string GetId()
        {
            return $"table-{this._id}";
        }

        public int GetSegmentSize()
        {
            return Textures.Table.Edge.Back.NORTH.Width;
        }

        public TableSegment GetTableSegmentFromPosition(Vector2 position)
        {
            Vector2 topLeft = this.GetTopLeft();
            int row = (int)Math.Floor((position.Y - topLeft.Y) / this.GetSegmentSize());
            int col = (int)Math.Floor((position.X - topLeft.X) / this.GetSegmentSize());
			return this._layout[row][col];
        }

        /// <summary>
        /// Returns layout <see cref="TableSegment"/>
        /// </summary>
        /// <returns>2D list of <see cref="TableSegment"/></returns>
        public IList<IList<TableSegment>> GetTableSegments()
        {
            return this._layout;
        }

        public TableType GetTableType()
        {
            return this._type;
        }

        public override float GetTotalHeight()
        {
            return TableConstants.GetLayout(this._type).Count * this.GetSegmentSize();
        }

        public override float GetTotalWidth()
        {
            return TableConstants.GetLayout(this._type)[0].Count * this.GetSegmentSize();
        }

        /// <summary>
        /// Creates <see cref="TableSegment"/> list based on layout
        /// </summary>
        /// <param name="layout">2D list of <see cref="TableSegmentType"/></param>
        private void CreateTable()
        {
            IList<IList<TableSegmentType>> layoutTypes = TableConstants.GetLayout(this._type);

            int textureSize = this.GetSegmentSize();
            Vector2 topLeft = this.GetTopLeft();

            this._layout = new List<IList<TableSegment>>();

            for (int i = 0; i < layoutTypes.Count; i++)
            {
                IList<TableSegment> row = new List<TableSegment>();

                for (int j = 0; j < layoutTypes[i].Count; j++)
                {
                    Vector2 newDestination = new Vector2(topLeft.X + (j * textureSize), topLeft.Y + (i * textureSize));

                    row.Add(TableSegment.GetTableSegmentFromType(
                        layoutTypes[i][j],
                        Origin.TopLeft,
                        new Vector2(topLeft.X + (j * textureSize), topLeft.Y + (i * textureSize)),
                        this._layerDepth,
                        this._enteringTransition,
                        this._exitingTransition));
                }

                this._layout.Add(row);
            }
        }
    }
}