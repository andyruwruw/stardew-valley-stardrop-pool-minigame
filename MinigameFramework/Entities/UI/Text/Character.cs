using Microsoft.Xna.Framework;
using MinigameFramework.Enums;
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
            float scale,
            Vector2 anchor,
            float layerDepth = 0,
            Origin origin = Origin.TopLeft,
            IFilter enteringTransition = null,
            IFilter exitingTransition = null
        ) : base(
            anchor,
            layerDepth,
            origin,
            enteringTransition,
            exitingTransition
        )
        {
            _character = character;
            _scale = scale;
            _charBounds = GenericTextures.GetCharacterBoundsFromChar(character);
        }

        /// <inheritdoc cref="IEntity.GetHeight"/>
        public override float GetHeight()
        {
            return _charBounds.Height * _scale;
        }

        /// <inheritdoc cref="IEntity.GetId"/>
        public override string GetId()
        {
            return $"text-character-{_id}";
        }

        /// <inheritdoc cref="IEntity.GetRawSource"/>
        public override Microsoft.Xna.Framework.Rectangle GetRawSource()
        {
            return _charBounds;
        }

        /// <inheritdoc cref="IEntity.GetWidth"/>
        public override float GetWidth()
        {
            return _charBounds.Width * _scale;
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
    }
}
