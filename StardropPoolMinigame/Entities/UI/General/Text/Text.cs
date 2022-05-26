using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
	internal class Text : Entity
	{
		private IList<Character> _characters;

		private readonly bool _isCentered;

		private readonly bool _isHoverable;

		private readonly int _maxWidth;

		private float _resultingHeight;

		private readonly float _scale;

		private string _text;

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
			_text = text;
			_maxWidth = maxWidth;
			_scale = scale;
			_isCentered = isCentered;
			_isHoverable = isHoverable;

			SetDrawer(new TextDrawer(this));
			InitializeCharacters();
		}

		public override void ClickCallback()
		{
		}

		public IList<Character> GetCharacters()
		{
			return _characters;
		}

		public override string GetId()
		{
			return $"text-{_id}";
		}

		public float GetScale()
		{
			return _scale;
		}

		public override float GetTotalHeight()
		{
			return _resultingHeight;
		}

		public override float GetTotalWidth()
		{
			return _maxWidth;
		}

		public override void HoverCallback()
		{
		}

		public bool IsHoverable()
		{
			return _isHoverable;
		}

		public override void SetAnchor(Vector2 anchor)
		{
			_anchor = anchor;
			InitializeCharacters();
		}

		public void SetText(string text)
		{
			_text = text;
			InitializeCharacters();
		}

		public override void SetTransitionState(TransitionState transitionState, bool start = false)
		{
			base.SetTransitionState(transitionState, start);

			foreach (var character in _characters) character.SetTransitionState(transitionState, true);
		}

		private void InitializeCharacters()
		{
			var word = "";
			float wordLength = 0;

			var line = "";
			float lineLength = 0;

			var lineIndex = 0;

			_characters = new List<Character>();
			_resultingHeight = 0;

			var characterIndex = 0;

			foreach (var character in _text)
			{
				IList<string> finishedLines = new List<string>();
				IList<float> finishedLineLengths = new List<float>();

				if (character == ' ' || character == '\n' || characterIndex == _text.Length - 1)
				{
					if (characterIndex == _text.Length - 1)
					{
						var characterBounds = Textures.GetCharacterBoundsFromChar(character);

						word = $"{word}{character}";
						wordLength += RenderConstants.Font.SpaceBetweenCharacters * _scale +
							characterBounds.Width * _scale;
					}

					if (lineLength + RenderConstants.Font.SpaceWidth * _scale + wordLength > _maxWidth)
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
							finishedLineLengths.Add(lineLength + RenderConstants.Font.SpaceWidth * _scale + wordLength);
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
						lineLength += RenderConstants.Font.SpaceWidth * _scale + wordLength;
					}

					word = "";
					wordLength = 0;
				}
				else
				{
					var characterBounds = Textures.GetCharacterBoundsFromChar(character);

					word = $"{word}{character}";
					wordLength += characterBounds.Width * _scale;
					if (word != "") wordLength += RenderConstants.Font.SpaceBetweenCharacters * _scale;
				}

				if (finishedLines.Count > 0)
				{
					for (var i = 0; i < finishedLines.Count; i++)
					{
						float cursor = 0;
						var leftMargin = _isCentered ? (_maxWidth - finishedLineLengths[i]) / 2 : 0;

						foreach (var lineCharacter in finishedLines[i])
							if (lineCharacter == ' ')
							{
								cursor += RenderConstants.Font.SpaceWidth * _scale;
							}
							else
							{
								var characterBounds = Textures.GetCharacterBoundsFromChar(lineCharacter);

								_characters.Add(new Character(
									Origin.TopLeft,
									new Vector2(
										GetTopLeft().X + cursor + RenderConstants.Font.SpaceBetweenCharacters * _scale +
										leftMargin,
										GetTopLeft().Y + lineIndex * (RenderConstants.Font.CharacterHeight * _scale +
											RenderConstants.Font.LineSpacing * _scale)),
									_layerDepth,
									_enteringTransition,
									_exitingTransition,
									lineCharacter));

								cursor += RenderConstants.Font.SpaceBetweenCharacters * _scale +
									characterBounds.Width * _scale;
							}

						lineIndex += 1;
						_resultingHeight += RenderConstants.Font.CharacterHeight * _scale +
							RenderConstants.Font.LineSpacing * _scale;
					}

					finishedLines.Clear();
					finishedLineLengths.Clear();
				}

				characterIndex += 1;
			}
		}
	}
}