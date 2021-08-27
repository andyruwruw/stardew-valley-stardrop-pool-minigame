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
            Logger.Info(text);
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

        public override void SetTransitionState(TransitionState transitionState, bool start = false)
        {
            base.SetTransitionState(transitionState, start);

            foreach (Character character in this._characters)
            {
                character.SetTransitionState(transitionState, true);
            }
        }

        public void SetText(string text)
        {
            this._text = text;
            this.InicializeCharacters();
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

            int characterIndex = 0;

            foreach (char character in this._text)
            {
                IList<string> finishedLines = new List<string>();
                IList<int> finishedLineLengths = new List<int>();

                if (character == ' ' || character == '\n' || characterIndex == this._text.Length - 1)
                {
                    if (characterIndex == this._text.Length - 1)
                    {
                        Rectangle characterBounds = Textures.GetCharacterBoundsFromChar(character);

                        word = $"{word}{character}";
                        wordLength += RenderConstants.FONT_SPACE_BETWEEN_CHARACTERS + characterBounds.Width;
                    }

                    if (lineLength + RenderConstants.FONT_SPACE_WIDTH + wordLength > this._maxWidth)
                    {
                        finishedLines.Add(line);
                        finishedLineLengths.Add(lineLength);

                        if (characterIndex == this._text.Length - 1)
                        {
                            finishedLines.Add(word);
                            finishedLineLengths.Add(wordLength);
                        } else
                        {
                            line = $"{word}";
                            lineLength = wordLength;
                        }
                    } else if (character == '\n' || characterIndex == this._text.Length - 1) {
                        finishedLines.Add($"{line} {word}");
                        finishedLineLengths.Add(lineLength + RenderConstants.FONT_SPACE_WIDTH + wordLength);

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

                if (finishedLines.Count > 0)
                {
                    for (int i = 0; i < finishedLines.Count; i++)
                    {
                        int cursor = 0;
                        int leftMargin = this._isCentered ? (this._maxWidth - finishedLineLengths[i]) / 2 : 0;

                        foreach (char lineCharacter in finishedLines[i])
                        {
                            if (lineCharacter == ' ')
                            {
                                cursor += RenderConstants.FONT_SPACE_WIDTH;
                            } else
                            {
                                Rectangle characterBounds = Textures.GetCharacterBoundsFromChar(lineCharacter);

                                this._characters.Add(new Character(
                                    Origin.TopCenter,
                                    new Vector2(
                                        this.GetTopLeft().X + cursor + RenderConstants.FONT_SPACE_BETWEEN_CHARACTERS + leftMargin + (characterBounds.Width / 2),
                                        this.GetTopLeft().Y + lineIndex * (RenderConstants.FONT_CHARACTER_HEIGHT + RenderConstants.FONT_LINE_SPACING)),
                                    this._layerDepth,
                                    this._enteringTransition,
                                    this._exitingTransition,
                                    lineCharacter));

                                cursor += RenderConstants.FONT_SPACE_BETWEEN_CHARACTERS + characterBounds.Width;
                            }
                        }

                        lineIndex += 1;
                        this._resultingHeight += RenderConstants.FONT_CHARACTER_HEIGHT + RenderConstants.FONT_LINE_SPACING;
                    }

                    finishedLines.Clear();
                    finishedLineLengths.Clear();
                }

                characterIndex += 1;
            }
        }
    }
}
