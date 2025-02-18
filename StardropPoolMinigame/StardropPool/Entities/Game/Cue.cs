using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MinigameFramework.Entities;
using MinigameFramework.Render.Filters;
using StardopPoolMinigame.Constants;
using StardopPoolMinigame.Enums;
using StardopPoolMinigame.Render;

namespace StardopPoolMinigame.Entities.Game
{
    class Cue : Entity
    {
        /// <summary>
        /// Whether this is the player's cue.
        /// </summary>
        protected bool _isPlayers;

        /// <summary>
        /// Style of cue.
        /// </summary>
        private CueType _type;

        /// <summary>
        /// Instantiates a pool cue.
        /// </summary>
        public Cue(
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
            bool? isPlayers = true,
            CueType? type = CueType.Basic
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
            _isPlayers = isPlayers;
            _type = type;
        }

        /// <inheritdoc cref="IEntity.Draw"/>
        public override void Draw(
            SpriteBatch batch,
            Vector2? overrideDestination = null,
            Microsoft.Xna.Framework.Rectangle? overrideSource = null,
            Color? overrideColor = null,
            float? overrideRotation = null,
            Vector2? overrideOrigin = null,
            float? overrideScale = null,
            SpriteEffects? overrideEffects = null,
            float? overrideLayerDepth = null
        )
        {
        }

        /// <inheritdoc cref="IEntity.GetHeight"/>
        public override float GetHeight()
        {
            return TextureConstants.Cue.Basic.Height;
        }

        /// <inheritdoc cref="IEntity.GetName"/>
        public override string GetName()
        {
            return $"cue-{_type}-{_isPlayers}-{_key}";
        }

        /// <inheritdoc cref="IEntity.GetWidth"/>
        public override float GetWidth()
        {
            return TextureConstants.Cue.Basic.Width;
        }

        /// <inheritdoc cref="EntityPhysics.Update"/>
		public override void Update(GameTime time)
        {
            base.Update(time);
        }

        /// <inheritdoc cref="Entity.GetTileset"/>
        protected override Texture2D? GetTileset()
        {
            return Textures.Tileset.Default;
        }
    }
}
