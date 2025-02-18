using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MinigameFramework.Entities;
using MinigameFramework.Enums;
using MinigameFramework.Render.Filters;
using StardopPoolMinigame.Constants;
using StardopPoolMinigame.Enums;
using StardopPoolMinigame.Render;

namespace StardopPoolMinigame.Entities.Game.Table
{
    class TableSegment : Entity
    {
        /// <summary>
        /// Type of table (specifies a layout).
        /// </summary>
        protected TableSegmentType _type;

        /// <summary>
        /// Row position in table.
        /// </summary>
        protected int _row;

        /// <summary>
        /// Column position in table.
        /// </summary>
        protected int _column;

        /// <summary>
        /// Instantiates a table segment.
        /// </summary>
        public TableSegment(
            IEntity? parent = null,
            Vector2? anchor = null,
            string? key = null,
            IList<IEntity>? children = null,
            float? layerDepth = null,
            bool? isHoverable = false,
            bool? isInteractable = false,
            IFilter? enteringTransition = null,
            IFilter? exitingTransition = null,
            bool? isRow = false,
            bool? centerContent = false,
            bool? center = false,
            Vector2? contentOffset = null,
            bool? fixedPosition = true,
            float? gap = 0f,
            float? height = -1f,
            float? margin = 0f,           
            float? marginBottom = 0f,
            float? marginLeft = 0f,
            float? marginRight = 0f,
            float? marginTop = 0f,
            float? maxHeight = -1f,
            float? maxWidth = -1f,
            float? minHeight = -1f,
            float? minWidth = -1f,
            bool? overflow = false,
            float? padding = 0f,
            float? paddingBottom = 0f,
            float? paddingLeft = 0f,
            float? paddingRight = 0f,
            float? paddingTop = 0f,
            float? width = -1f,
            TableSegmentType? type = TableSegmentType.Felt,
            int row = 0,
            int column = 0
        ) : base(
            parent,
            key,
            anchor,
            children,
            layerDepth,
            isHoverable,
            isInteractable,
            enteringTransition,
            exitingTransition,
            isRow,
            centerContent,
            center,
            contentOffset,
            fixedPosition,
            gap,
            height,
            margin,
            marginBottom,
            marginLeft,
            marginRight,
            marginTop,
            maxHeight,
            maxWidth,
            minHeight,
            minWidth,
            overflow,
            padding,
            paddingBottom,
            paddingLeft,
            paddingRight,
            paddingTop,
            width
        )
        {
            _type = type;
            _row = row;
            _column = column;
        }

        /// <inheritdoc cref="IEntity.GetHeight"/>
        public override float GetHeight()
        {
            return TextureConstants.Table.Felt.Height;
        }

        /// <inheritdoc cref="IEntity.GetName"/>
        public override string GetName()
        {
            return $"table-segment-{_row}-{_column}-{_type}-{_key}";
        }

        /// <inheritdoc cref="IEntity.GetWidth"/>
        public override float GetWidth()
        {
            return TextureConstants.Table.Felt.Width;
        }

        /// <inheritdoc cref="EntityPhysics.Update"/>
		public override void Update(GameTime time)
        {
            base.Update(time);
        }

        /// <inheritdoc cref="Entity.GetRawSource"/>
        protected override Microsoft.Xna.Framework.Rectangle GetRawSource()
        {
            return Textures.GetTableSegmentBackFromType(_type);
        }

        /// <inheritdoc cref="Entity.GetTileset"/>
        protected override Texture2D? GetTileset()
        {
            return Textures.Tileset.Default;
        }
    }
}
