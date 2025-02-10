using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MinigameFramework.Constants;
using MinigameFramework.Enums;
using MinigameFramework.Render;
using MinigameFramework.Render.Filters;
using MinigameFramework.Utilities;
using StardopPoolMinigame.Constants;
using StardopPoolMinigame.Render;

namespace MinigameFramework.Entities.UI.Text
{
    /// <summary>
    /// Displays text as an entity.
    /// </summary>
    class Text : Entity
    {
        /// <summary>
        /// Height of the component.
        /// </summary>
        protected float _height = -1;

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
        /// The width of the component.
        /// </summary>
        protected float _width = -1;

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
            IFilter? enteringTransition = null,
            IFilter? exitingTransition = null,
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
            _resultingHeight = 0;

            InitializeCharacters();
        }

        /// <inheritdoc cref="IEntity.GetHeight"/>
        public override float GetHeight()
        {
            if (_height != -1)
            {
                return _height;
            }

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
            if (_width != -1)
            {
                return _width;
            }

            float minimum = float.MaxValue;
            float maximum = float.MinValue;

            foreach (Character entity in GetChildren())
            {
                if (entity.GetTopLeft().X < minimum)
                {
                    minimum = entity.GetTopLeft().X;
                }
                if (entity.GetTopLeft().X + entity.GetWidth() > maximum)
                {
                    maximum = entity.GetTopLeft().X + entity.GetWidth();
                }
            }

            _width = maximum - minimum;

            return maximum - minimum;
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

            _children = new List<IEntity>();
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

            _children.Clear();
            _resultingHeight = 0;

            InitializeCharacters();
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

        /// <summary>
        /// Initializes the character entities from the text.
        /// </summary>
        protected void InitializeCharacters()
        {
            float top = float.MaxValue;
            float bottom = float.MinValue;
            float left = float.MaxValue;
            float right = float.MinValue;

            string word = "";
            float wordLength = 0;

            string line = "";
            float lineLength = 0;

            int lineIndex = 0;
            _resultingHeight = 0;

            int characterIndex = 0;

            foreach (char character in _text)
            {
                IList<string> finishedLines = new List<string>();
                IList<float> finishedLineLengths = new List<float>();

                if (character == ' ' || character == '\n' || characterIndex == _text.Length - 1)
                {
                    if (characterIndex == _text.Length - 1)
                    {
                        Rectangle characterBounds = GenericTextures.GetCharacterBoundsFromChar(character);

                        word = $"{word}{character}";
                        wordLength += GenericRenderConstants.Font.SpaceBetweenCharacters * _scale + characterBounds.Width * _scale;
                    }

                    if (lineLength + GenericRenderConstants.Font.SpaceWidth * _scale + wordLength > _maxWidth)
                    {
                        finishedLines.Add(line);
                        finishedLineLengths.Add(lineLength);

                        if (characterIndex == _text.Length - 1)
                        {
                            finishedLines.Add(word);
                            finishedLineLengths.Add(wordLength);
                        }
                        else
                        {
                            line = word;
                            lineLength = wordLength;
                        }
                    }
                    else if (character == '\n' || characterIndex == _text.Length - 1)
                    {
                        if (line != "")
                        {
                            finishedLines.Add($"{line} {word}");
                            finishedLineLengths.Add(lineLength + GenericRenderConstants.Font.SpaceWidth * _scale + wordLength);
                        }
                        else
                        {
                            finishedLines.Add(word);
                            finishedLineLengths.Add(wordLength);
                        }

                        if (character == '\n')
                        {
                            finishedLines.Add(" ");
                            finishedLineLengths.Add(0);
                        }

                        line = "";
                        lineLength = 0;
                    }
                    else
                    {
                        line = $"{line} {word}";
                        lineLength += GenericRenderConstants.Font.SpaceWidth * _scale + wordLength;
                    }

                    word = "";
                    wordLength = 0;
                }
                else
                {
                    Rectangle characterBounds = GenericTextures.GetCharacterBoundsFromChar(character);

                    word = $"{word}{character}";
                    wordLength += characterBounds.Width * _scale;

                    if (word != "")
                    {
                        wordLength += GenericRenderConstants.Font.SpaceBetweenCharacters * _scale;
                    }
                }

                if (finishedLines.Count > 0)
                {
                    for (int i = 0; i < finishedLines.Count; i++)
                    {
                        float cursor = 0;
                        float leftMargin = _isCentered ? (_maxWidth - finishedLineLengths[i]) / 2 : 0;

                        foreach (char lineCharacter in finishedLines[i])
                            if (lineCharacter == ' ')
                            {
                                cursor += GenericRenderConstants.Font.SpaceWidth * _scale;
                            }
                            else
                            {
                                Rectangle characterBounds = GenericTextures.GetCharacterBoundsFromChar(lineCharacter);

                                float x = GetTopLeft().X + cursor + GenericRenderConstants.Font.SpaceBetweenCharacters * _scale + leftMargin;
                                float y = GetTopLeft().Y + lineIndex * (GenericRenderConstants.Font.CharacterHeight * _scale + GenericRenderConstants.Font.LineSpacing * _scale);

                                _children.Add(new Character(
                                    lineCharacter,
                                    _scale,
                                    new Vector2(
                                        x,
                                        y
                                    ),
                                    _layerDepth,
                                    Origin.TopLeft,
                                    _enteringTransition,
                                    _exitingTransition
                                ));

                                if (x < left)
                                {
                                    left = x;
                                }
                                if (x + characterBounds.Width > right)
                                {
                                    right = x + characterBounds.Width;
                                }
                                if (y < top)
                                {
                                    top = y;
                                }
                                if (y + characterBounds.Height > bottom)
                                {
                                    bottom = y + characterBounds.Height;
                                }

                                cursor += GenericRenderConstants.Font.SpaceBetweenCharacters * _scale + characterBounds.Width * _scale;
                            }

                        lineIndex += 1;
                        _resultingHeight += GenericRenderConstants.Font.CharacterHeight * _scale + GenericRenderConstants.Font.LineSpacing * _scale;
                    }

                    finishedLines.Clear();
                    finishedLineLengths.Clear();
                }

                characterIndex += 1;
            }

            _height = bottom - top;
            _width = right - left;
        }
    }
}
