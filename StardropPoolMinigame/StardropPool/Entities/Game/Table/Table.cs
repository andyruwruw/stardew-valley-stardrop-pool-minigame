using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MinigameFramework.Entities;
using MinigameFramework.Enums;
using MinigameFramework.Render;
using MinigameFramework.Render.Filters;
using StardopPoolMinigame.Constants;
using StardopPoolMinigame.Enums;
using StardopPoolMinigame.Render;

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
            Vector2 anchor,
            TableType type,
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

        /// <inheritdoc cref="IEntity.GetId"/>
        public override string GetId()
        {
            return $"table-{_id}";
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
