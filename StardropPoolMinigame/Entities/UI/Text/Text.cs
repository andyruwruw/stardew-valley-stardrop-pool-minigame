using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    class Text : EntityHoverable
    {
        private string _text;

        private int _maxWidth;

        private int _resultingHeight;

        private IList<Character> _characters;

        private bool _isCentered;

        private bool _isHoverable;

        public Text(
            Origin origin,
            Vector2 anchor,
            float layerDepth,
            IFilter enteringTransition,
            IFilter exitingTransition,
            string text,
            int maxWidth,
            bool isCentered = false,
            bool isHoverable = false
        ) : base(
            origin,
            anchor,
            layerDepth,
            enteringTransition,
            exitingTransition)
        {
            this._text = text;
            this._maxWidth = maxWidth;
            this._isCentered = isCentered;
            this._isHoverable = isHoverable;

            this.SetDrawer(new TextDrawer(this));
            this.InicializeCharacters();
        }

        public override float GetTotalHeight()
        {
            return this._resultingHeight;
        }

        public override float GetTotalWidth()
        {
            return this._maxWidth;
        }

        public override void ClickCallback()
        {
        }

        public IList<Character> GetCharacters()
        {
            return this._characters;
        }

        public bool IsHoverable()
        {
            return this._isHoverable;
        }

        protected override void HoveredCallback()
        {
        }

        private void InicializeCharacters()
        {
            string word = "";
            int wordLength = 0;

            string line = "";
            int lineLength = 0;

            int lineIndex = 0;

            this._characters = new List<Character>();
            this._resultingHeight = 0;

            foreach (char character in this._text)
            {
                string finishedLine = null;
                int finishedLineLength = 0;

                if (character == ' ' || character == '\n')
                {
                    if (lineLength + RenderConstants.FONT_SPACE_WIDTH + wordLength > this._maxWidth)
                    {
                        finishedLine = line;
                        finishedLineLength = lineLength;

                        line = $"{word}";
                        lineLength = wordLength;
                    } else if (character == '\n') {
                        finishedLine = $"{line} {word}";
                        finishedLineLength = lineLength + RenderConstants.FONT_SPACE_WIDTH + wordLength;

                        line = "";
                        lineLength = 0;
                    } else
                    {
                        line = $"{line} {word}";
                        lineLength += RenderConstants.FONT_SPACE_WIDTH + wordLength;
                    }

                    word = "";
                    wordLength = 0;
                } else
                {
                    Rectangle characterBounds = Textures.GetCharacterBoundsFromChar(character);

                    word = $"{word}{character}";
                    wordLength += RenderConstants.FONT_SPACE_BETWEEN_CHARACTERS + characterBounds.Width;
                }

                if (finishedLine != null)
                {
                    int cursor = 0;
                    int leftMargin = this._isCentered ? (this._maxWidth - finishedLineLength) / 2 : 0;

                    foreach (char lineCharacter in finishedLine)
                    {
                        if (lineCharacter == ' ')
                        {
                            cursor += RenderConstants.FONT_SPACE_WIDTH;
                        } else
                        {
                            this._characters.Add(new Character(
                                Origin.TopLeft,
                                new Vector2(
                                    cursor + RenderConstants.FONT_SPACE_BETWEEN_CHARACTERS + leftMargin,
                                    lineIndex * (RenderConstants.FONT_CHARACTER_HEIGHT + RenderConstants.FONT_LINE_SPACING)),
                                this._layerDepth,
                                this._enteringTransition,
                                this._exitingTransition,
                                lineCharacter));
                        }

                        Rectangle characterBounds = Textures.GetCharacterBoundsFromChar(lineCharacter);
                        cursor += RenderConstants.FONT_SPACE_BETWEEN_CHARACTERS + characterBounds.Width;
                    }

                    finishedLine = "";
                    finishedLineLength = 0;
                    lineIndex += 1;

                    this._resultingHeight += RenderConstants.FONT_CHARACTER_HEIGHT + RenderConstants.FONT_LINE_SPACING;
                }
            }
        }
    }
}
