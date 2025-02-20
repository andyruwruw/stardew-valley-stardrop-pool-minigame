using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MinigameFramework.Constants;
using MinigameFramework.Enums;
using MinigameFramework.Helpers;
using MinigameFramework.Render;
using MinigameFramework.Render.Filters;

namespace MinigameFramework.Entities.UI.Text
{
    /// <summary>
    /// Entity depicting a single character.
    /// </summary>
    class Character : Entity
    {
        /// <summary>
        /// Character to be displayed.
        /// </summary>
        protected char _character;

        /// <summary>
        /// Bounds of the character on the sprite sheet.
        /// </summary>
        protected Rectangle _charBounds;

        /// <summary>
        /// Scale of the text.
        /// </summary>
        protected float _scale;

        /// <summary>
        /// Instantiates a single character as an entity.
        /// </summary>
        /// <param name="character">Character to be displayed.</param>
        /// <param name="scale">Scale of the character.</param>
        /// <param name="anchor"><see cref="Entity">Entity's</see> anchor, or position<inheritdoc cref="_anchor"/></param>
		/// <param name="layerDepth"><see cref="Entity">Entity's</see> layer depth for rendering</param>
		/// <param name="origin">Anchor's relation to <see cref="Entity">Entity's</see> position</param>
		/// <param name="enteringTransition"><see cref="Entity">Entity's</see> entering <see cref="Transition"/></param>
		/// <param name="exitingTransition"><see cref="Entity">Entity's</see> exiting <see cref="Transition"/></param>
        public Character(
            char character,
            IEntity? parent = null,
            string? key = null,
            Vector2? anchor = null,
            Position? position = Position.Relative,
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
            float? scale = 1f
        ) : base(
            parent,
            key,
            anchor,
            position,
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
            _character = character;
            _scale = scale ?? 1f;
            
            _charBounds = GenericTextures.GetCharacterBoundsFromChar(character);
        }

        /// <inheritdoc cref="IEntity.GetHeight"/>
        public override float GetHeight()
        {
            return _charBounds.Height * _scale;
        }

        /// <inheritdoc cref="IEntity.GetName"/>
        public override string GetName()
        {
            return $"text-character-{_key}";
        }

        /// <inheritdoc cref="IEntity.GetWidth"/>
        public override float GetWidth()
        {
            return _charBounds.Width * _scale;
        }

        /// <inheritdoc cref="IEntity.HandleHover"/>
		public override void HandleHover()
        {
            _isHovered = true;
        }

        /// <inheritdoc cref="IEntity.HandleHover"/>
		public override void HandleUnhover()
        {
            _isHovered = false;
        }

        /// <summary>
        /// Sets the display character to something else.
        /// </summary>
        /// <param name="character">New character to set to.</param>
        public void SetCharacter(char character)
        {
            _character = character;
            _charBounds = GenericTextures.GetCharacterBoundsFromChar(_character);
        }

        /// <inheritdoc cref="Entity.GetTileset"/>
        protected override Texture2D? GetTileset()
        {
            return GenericTextures.Tileset.Default;
        }

        /// <summary>
        /// Color before filters.
        /// </summary>
        protected override Color GetRawColor()
        {
            if (IsHovered())
            {
                return GenericTextureConstants.Color.Solid.HoverAccent;
            }
            return Color.White;
        }

        /// <inheritdoc cref="Entity.GetRawDestination"/>
        protected override Vector2 GetRawDestination()
        {
            Vector2 destination = base.GetRawDestination();

            return new Vector2(
                destination.X,
                destination.Y + (GenericRenderConstants.Font.YOffset * RenderHelpers.TileScale())
            );
        }

        /// <inheritdoc cref="Entity.GetRawSource"/>
        protected override Microsoft.Xna.Framework.Rectangle GetRawSource()
        {
            return _charBounds;
        }
    }
}
