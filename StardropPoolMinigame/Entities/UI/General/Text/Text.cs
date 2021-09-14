using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    class Text : Entity
    {
        private string _text;

        private int _maxWidth;

        private float _resultingHeight;

        private IList<Character> _characters;

        private float _scale;

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
            float scale = 1f,
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
            this._scale = scale;
            this._isCentered = isCentered;
            this._isHoverable = isHoverable;

            this.SetDrawer(new TextDrawer(this));
            this.InicializeCharacters();
        }

        public override string GetId()
        {
            return $"text-{this._id}";
        }

        public override float GetTotalHeight()
        {
            return this._resultingHeight;
        }

        public override float GetTotalWidth()
        {
            return this._maxWidth;
        }

        public float GetScale()
        {
            return this._scale;
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

        public override void SetAnchor(Vector2 anchor)
        {
            this._anchor = anchor;
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

        public override void HoverCallback()
        {
        }

        private void InicializeCharacters()
        {
            string word = "";
            float wordLength = 0;

            string line = "";
            float lineLength = 0;

            int lineIndex = 0;

            this._characters = new List<Character>();
            this._resultingHeight = 0;

            int characterIndex = 0;

            foreach (char character in this._text)
            {
                IList<string> finishedLines = new List<string>();
                IList<float> finishedLineLengths = new List<float>();

                if (character == ' ' || character == '\n' || characterIndex == this._text.Length - 1)
                {
                    if (characterIndex == this._text.Length - 1)
                    {
                        Rectangle characterBounds = Textures.GetCharacterBoundsFromChar(character);

                        word = $"{word}{character}";
                        wordLength += RenderConstants.Font.SPACE_BETWEEN_CHARACTERS * this._scale + characterBounds.Width * this._scale;
                    }

                    if (lineLength + RenderConstants.Font.SPACE_WIDTH * this._scale + wordLength > this._maxWidth)
                    {
                        finishedLines.Add(line);
                        finishedLineLengths.Add(lineLength);

                        if (characterIndex == this._text.Length - 1)
                        {
                            finishedLines.Add(word);
                            finishedLineLengths.Add(wordLength);
                        } else
                        {
                            line = word;
                            lineLength = wordLength;
                        }
                    } else if (character == '\n' || characterIndex == this._text.Length - 1) {
                        if (line != "")
                        {
                            finishedLines.Add($"{line} {word}");
                            finishedLineLengths.Add(lineLength + RenderConstants.Font.SPACE_WIDTH * this._scale + wordLength);
                        } else
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
                    } else
                    {
                        line = $"{line} {word}";
                        lineLength += RenderConstants.Font.SPACE_WIDTH * this._scale + wordLength;
                    }

                    word = "";
                    wordLength = 0;
                } else
                {
                    Rectangle characterBounds = Textures.GetCharacterBoundsFromChar(character);

                    word = $"{word}{character}";
                    wordLength += characterBounds.Width * this._scale;
                    if (word != "")
                    {
                        wordLength += RenderConstants.Font.SPACE_BETWEEN_CHARACTERS * this._scale;
                    }
                }

                if (finishedLines.Count > 0)
                {
                    for (int i = 0; i < finishedLines.Count; i++)
                    {
                        float cursor = 0;
                        float leftMargin = this._isCentered ? (this._maxWidth - finishedLineLengths[i]) / 2 : 0;

                        foreach (char lineCharacter in finishedLines[i])
                        {
                            if (lineCharacter == ' ')
                            {
                                cursor += RenderConstants.Font.SPACE_WIDTH * this._scale;
                            } else
                            {
                                Rectangle characterBounds = Textures.GetCharacterBoundsFromChar(lineCharacter);

                                this._characters.Add(new Character(
                                    Origin.TopLeft,
                                    new Vector2(
                                        this.GetTopLeft().X + cursor + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS * this._scale + leftMargin,
                                        this.GetTopLeft().Y + lineIndex * (RenderConstants.Font.CHARACTER_HEIGHT * this._scale + RenderConstants.Font.LINE_SPACING * this._scale)),
                                    this._layerDepth,
                                    this._enteringTransition,
                                    this._exitingTransition,
                                    lineCharacter));

                                cursor += RenderConstants.Font.SPACE_BETWEEN_CHARACTERS * this._scale + characterBounds.Width * this._scale;
                            }
                        }

                        lineIndex += 1;
                        this._resultingHeight += RenderConstants.Font.CHARACTER_HEIGHT * this._scale + RenderConstants.Font.LINE_SPACING * this._scale;
                    }

                    finishedLines.Clear();
                    finishedLineLengths.Clear();
                }

                characterIndex += 1;
            }
        }
    }
}
