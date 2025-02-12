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
            Vector2 anchor,
            TableSegmentType type,
            int row = 0,
            int column = 0,
            float layerDepth = 0,
            Origin origin = Origin.CenterCenter,
            IFilter? enteringTransition = null,
            IFilter? exitingTransition = null
        ) : base(
            anchor,
            layerDepth,
            origin,
            enteringTransition,
            exitingTransition
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
