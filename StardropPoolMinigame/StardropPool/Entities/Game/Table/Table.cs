using Microsoft.Xna.Framework;
using MinigameFramework.Entities;
using MinigameFramework.Enums;
using MinigameFramework.Render.Filters;
using StardopPoolMinigame.Constants;
using StardopPoolMinigame.Enums;

namespace StardopPoolMinigame.Entities.Game.Table
{
    /// <summary>
    /// A pool table!
    /// </summary>
    class Table : Entity
    {
        /// <summary>
        /// Type of table (specifies a layout).
        /// </summary>
        private TableType _type;

        /// <summary>
        /// The individual segment entities.
        /// </summary>
        protected IList<IList<IEntity>> _layout;

        /// <summary>
        /// Instantiates a table.
        /// </summary>
        public Table(
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
            TableType? type = TableType.Classic
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
            _layout = new List<IList<IEntity>>();
        }

        /// <inheritdoc cref="IEntity.GetEntities"/>
        public override IList<IEntity> GetChildren()
        {
            return _layout.SelectMany(entity => entity).ToList();
        }

        /// <inheritdoc cref="IEntity.GetHeight"/>
        public override float GetHeight()
        {
            return TextureConstants.Ball.Base.White.Height;
        }

        /// <inheritdoc cref="IEntity.GetName"/>
        public override string GetName()
        {
            return $"table-{_key}";
        }

        /// <inheritdoc cref="IEntity.GetWidth"/>
        public override float GetWidth()
        {
            return TextureConstants.Ball.Base.White.Width;
        }

        /// <inheritdoc cref="IEntity.ShouldDrawChildren"/>
        public override bool ShouldDrawChildren()
        {
            return true;
        }

        /// <inheritdoc cref="IEntity.ShouldDrawSelf"/>
        public override bool ShouldDrawSelf()
        {
            return false;
        }
    }
}
