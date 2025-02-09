using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MinigameFramework.Constants;
using MinigameFramework.Enums;
using MinigameFramework.Render.Filters;

namespace MinigameFramework.Entities.UI.Text
{
    /// <summary>
    /// Displays text as an entity.
    /// </summary>
    class Text : Entity
    {
        /// <summary>
        /// Characters that make up the text entity.
        /// </summary>
        protected IList<Character> _characters;

        /// <summary>
        /// Whether to center the text.
        /// </summary>
        protected bool _isCentered;

        /// <summary>
        /// Whether the text is hoverable.
        /// </summary>
        protected bool _isHoverable;

        /// <summary>
        /// Maximum width to allow the text to span.
        /// </summary>
        protected float _maxWidth;

        /// <summary>
        /// The height resulting from the width and text displayed.
        /// </summary>
        protected float _resultingHeight;

        /// <summary>
        /// Scale of the text.
        /// </summary>
        protected float _scale;

        /// <summary>
        /// Text to display.
        /// </summary>
        protected string _text;

        /// <summary>
        /// Instantiates a new text item.
        /// </summary>
        /// <param name="text">The text to be displayed.</param>
        /// <param name="anchor"><see cref="Entity">Entity's</see> anchor, or position<inheritdoc cref="_anchor"/></param>
		/// <param name="layerDepth"><see cref="Entity">Entity's</see> layer depth for rendering</param>
		/// <param name="origin">Anchor's relation to <see cref="Entity">Entity's</see> position</param>
		/// <param name="enteringTransition"><see cref="Entity">Entity's</see> entering <see cref="Transition"/></param>
		/// <param name="exitingTransition"><see cref="Entity">Entity's</see> exiting <see cref="Transition"/></param>
        /// <param name="maxWidth">Maximum width of the component.</param>
        /// <param name="scale">Scale multiplier for sizing.</param>
        /// <param name="isCentered">Whether to center the content.</param>
        /// <param name="isHoverable">Whether this component is hoverable.</param>
        public Text(
            string text,
            Vector2 anchor,
            float layerDepth = 0,
            Origin origin = Origin.TopLeft,
            IFilter enteringTransition = null,
            IFilter exitingTransition = null,
            float maxWidth = float.MaxValue,
            float scale = 1f,
            bool isCentered = false,
            bool isHoverable = false
        ) : base(
            anchor,
            layerDepth,
            origin,
            enteringTransition,
            exitingTransition
        ) {
            _text = text;
            _maxWidth = maxWidth;
            _scale = scale;
            _isCentered = isCentered;
            _isHoverable = isHoverable;

            _characters = new List<Character>();
            _resultingHeight = 0;

            InitializeCharacters();
        }

        /// <inheritdoc cref="IEntity.Draw"/>
        public virtual void Draw(
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
            if (!ShouldDraw())
            {
                return;
            }

            foreach (Character entity in _characters)
            {
                if (entity.ShouldDraw())
                {
                    entity.Draw(
                        batch,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null
                    );
                }
            }
        }

        /// <inheritdoc cref="IEntity.GetEntities"/>
        public override IList<IEntity> GetEntities()
        {
            return (IList<IEntity>)_characters;
        }

        /// <inheritdoc cref="IEntity.GetHeight"/>
        public override float GetHeight()
        {
            return _resultingHeight;
        }

        /// <inheritdoc cref="IEntity.GetId"/>
        public override string GetId()
        {
            return $"text-{_text}-{_id}";
        }

        /// <summary>
        /// Returns the max width of the  component.
        /// </summary>
        public float GetMaxWidth()
        {
            return _maxWidth;
        }

        /// <summary>
        /// Retrieves the text displayed.
        /// </summary>
        public string GetText()
        {
            return _text;
        }

        /// <inheritdoc cref="IEntity.GetWidth"/>
        public override float GetWidth()
        {
            return _maxWidth;
        }

        /// <summary>
        /// Whether the text is hoverable.
        /// </summary>
        public bool IsHoverable()
        {
            return _isHoverable;
        }

        /// <summary>
        /// Sets a new max width.
        /// </summary>
        /// <param name="maxWidth">New max width.</param>
        public void SetMaxWidth(float maxWidth)
        {
            if (maxWidth <= 0 || maxWidth == _maxWidth)
            {
                return;
            }

            _maxWidth = maxWidth;

            _characters = new List<Character>();
            _resultingHeight = 0;

            InitializeCharacters();
        }

        /// <summary>
        /// Set the displayed text to something else.
        /// </summary>
        /// <param name="text">New text to display.</param>
        public void SetText(string text)
        {
            _text = text;

            _characters.Clear();
            _resultingHeight = 0;

            InitializeCharacters();
        }

        /// <summary>
        /// Initializes the character entities from the text.
        /// </summary>
        protected void InitializeCharacters()
        {
            // Create a character object for every character at the origin.
            for (int i = 0; i < _text.Count(); i += 1)
            {
                char character = _text[i];

                if (character != ' ' && character != '\t' && character != '\n')
                {
                    _characters.Add(new Character(
                        character,
                        _scale,
                        _anchor,
                        _layerDepth,
                        _origin,
                        null,
                        null
                    ));
                }
            }

            // Track line widths.
            float currentLineWidth = 0;
            int nonDisplayables = 0;

            int lines = 0;
            int lastLineBreak = 0;

            // We're going to figure out where each character can be given the set width.
            for (int i = 0; i < _text.Count(); i += 1)
            {
                if (i - nonDisplayables >= _characters.Count())
                {
                    break;
                }

                char character = _text[i];
                Character entity = _characters[i - nonDisplayables];

                float additionalWidth = 0;

                // If it's a non-displayable, we need to mark it for indexing purposes.
                if (character == ' ' && character == '\t' && character == '\n')
                {
                    nonDisplayables++;

                    // Add the appropriate width.
                    if (character == ' ')
                    {
                        additionalWidth = GenericRenderConstants.Font.SpaceWidth * _scale;
                    }
                    else if (character == '\t')
                    {
                        additionalWidth = GenericRenderConstants.Font.SpaceWidth * 2 * _scale;
                    }
                }
                else
                {
                    // Else just add the character width.
                    additionalWidth = GenericRenderConstants.Font.SpaceBetweenCharacters * _scale + entity.GetWidth();
                }

                // If we go past our max width with this character.
                if (currentLineWidth + additionalWidth > _maxWidth || character == '\n'  || i + 1 ==  _text.Count())
                {
                    // We're basically declaring we're going to position lastLineBreak >= to < i

                    // Figure out the height of the line.
                    float heightOffset = lines * (GenericRenderConstants.Font.CharacterHeight + GenericRenderConstants.Font.LineSpacing) * _scale;

                    // Spaces at the end of lines aren't needed.
                    if (_text[i - 1] == ' ')
                    {
                        currentLineWidth -= GenericRenderConstants.Font.SpaceWidth * _scale;
                    }
                    if (_text[i - 1] == '\t')
                    {
                        currentLineWidth -= GenericRenderConstants.Font.SpaceWidth * 2 * _scale;
                    }

                    float offset = 0;

                    // If it's centered we need to offset it.
                    if (_isCentered)
                    {
                        offset = (_maxWidth - currentLineWidth) / 2;
                    }

                    // Track our X cursor.
                    float cursor = offset;
                    int innerNonDisplayables = 0;

                    // Starting at the last character not displayed and to before this character.
                    for (int j = lastLineBreak; j < i; j += 1)
                    {
                        if (character == ' ' || character == '\t' || character == '\n')
                        {
                            innerNonDisplayables++;

                            if (j != lastLineBreak)
                            {
                                // Add the appropriate width.
                                if (character == ' ')
                                {
                                    cursor += GenericRenderConstants.Font.SpaceWidth * _scale;
                                }
                                else if (character == '\t')
                                {
                                    cursor += GenericRenderConstants.Font.SpaceWidth * 2 * _scale;
                                }
                            }
                        } else
                        {
                            _characters[j - innerNonDisplayables].SetAnchor(new Vector2(
                                _anchor.X + cursor,
                                _anchor.Y + heightOffset +  GenericRenderConstants.Font.YOffset * _scale
                            ));

                            cursor += GenericRenderConstants.Font.SpaceBetweenCharacters * _scale;
                        }
                    }


                    // We need to construct the last line.
                    lastLineBreak = i;
                    lines += 1;
                    currentLineWidth = 0;
                }
                else
                {
                    // Else we just continue!
                    currentLineWidth += additionalWidth;
                }
            }
        }
    }
}
