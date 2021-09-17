using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Utilities;
using Rectangle = StardropPoolMinigame.Primitives.Rectangle;

namespace StardropPoolMinigame.Scenes
{
	internal class CharacterSelectScene : Scene
	{
		/// <summary>
		/// Class of selected opponent
		/// </summary>
		private ComputerOpponent _opponent;

		/// <summary>
		/// Name of selected opponent
		/// </summary>
		private NPCName _opponentName;

		/// <summary>
		/// Instantiates <see cref="CharacterSelectScene"/>.
		/// </summary>
		public CharacterSelectScene()
		{
			_opponentName = NPCName.Sam;
		}

		/// <inheritdoc cref="Scene.GetKey"/>
		public override string GetKey()
		{
			return "character-select-scene";
		}

		/// <inheritdoc cref="Scene.ReceiveLeftClick"/>
		public override void ReceiveLeftClick()
		{
			// Check if buttons are clicked
			foreach (var key in StringConstants.Entities.CharacterSelect.Portraits)
			{
				Logger.Info($"this is what {key}");

				if (_entities[key].IsHovered())
				{
					_entities[key].ClickCallback();
					_opponentName = ((Portrait) _entities[key]).GetName();
					UpdatePortraits();

					return;
				}
			}

			if (_entities[StringConstants.Entities.CharacterSelect.ChallengeButton].IsHovered()
				&& (_opponentName != NPCName.Abigail || Save.IsAbigailUnlocked())
				&& (_opponentName != NPCName.Gus || Save.IsGusUnlocked()))
			{
				_entities[StringConstants.Entities.CharacterSelect.ChallengeButton].ClickCallback();
				Sound.StopMusic();
				CharacterSelected();
			}
		}

		/// <inheritdoc cref="Scene.Update"/>
		public override void Update()
		{
			UpdateEntities();
		}

		/// <inheritdoc cref="Scene.AddEntities"/>
		protected override void AddEntities()
		{
			// Background
			_entities.Add(
				StringConstants.Entities.CharacterSelect.BarShelves,
				new BarShelves(
					Origin.TopLeft,
					new Vector2(0, 0),
					0.0010f,
					null,
					TransitionConstants.CharacterSelect.Exiting()));

			_entities.Add(
				StringConstants.Entities.CharacterSelect.BottomBackground,
				new Solid(
					new Rectangle(
						new Vector2(0, Textures.BAR_SHELVES.Height),
						RenderConstants.MinigameScreen.Width,
						RenderConstants.MinigameScreen.Height - Textures.BAR_SHELVES.Height),
					0.0031f,
					null,
					TransitionConstants.CharacterSelect.Exiting(),
					Color.Black));

			// Buttons
			float centerX = RenderConstants.MinigameScreen.Width / 2;
			float portraitTopMargin = Textures.BAR_SHELVES.Height - Textures.Portrait.Sam.DEFAULT.Height;
			float portraitSeparation = Textures.Portrait.Sam.DEFAULT.Width;

			_entities.Add(
				StringConstants.Entities.CharacterSelect.SamPortrait,
				new Portrait(
					Origin.TopLeft,
					new Vector2(centerX - portraitSeparation * 2, portraitTopMargin),
					0.0030f,
					TransitionConstants.CharacterSelect.Portrait.Entering(),
					TransitionConstants.CharacterSelect.Portrait.Exiting(),
					NPCName.Sam,
					isHoverable: true));

			_entities.Add(
				StringConstants.Entities.CharacterSelect.SebastianPortrait,
				new Portrait(
					Origin.TopLeft,
					new Vector2(centerX - portraitSeparation, portraitTopMargin),
					0.0030f,
					TransitionConstants.CharacterSelect.Portrait.Entering(),
					TransitionConstants.CharacterSelect.Portrait.Exiting(),
					NPCName.Sebastian,
					isHoverable: true,
					isDarker: true));

			_entities.Add(
				StringConstants.Entities.CharacterSelect.AbigailPortrait,
				new Portrait(
					Origin.TopLeft,
					new Vector2(centerX, portraitTopMargin),
					0.0030f,
					TransitionConstants.CharacterSelect.Portrait.Entering(),
					TransitionConstants.CharacterSelect.Portrait.Exiting(),
					NPCName.Abigail,
					isHoverable: true,
					isDarker: Save.IsAbigailUnlocked(),
					isSilhouette: !Save.IsAbigailUnlocked()));

			_entities.Add(
				StringConstants.Entities.CharacterSelect.GusPortrait,
				new Portrait(
					Origin.TopLeft,
					new Vector2(centerX + portraitSeparation, portraitTopMargin),
					0.0030f,
					TransitionConstants.CharacterSelect.Portrait.Entering(),
					TransitionConstants.CharacterSelect.Portrait.Exiting(),
					NPCName.Gus,
					isHoverable: true,
					isDarker: Save.IsGusUnlocked(),
					isSilhouette: !Save.IsGusUnlocked()));

			_entities.Add(
				StringConstants.Entities.CharacterSelect.ChallengeButton,
				new SubmitButton(
					Origin.TopCenter,
					new Vector2(RenderConstants.MinigameScreen.Width / 2,
						RenderConstants.MinigameScreen.Height -
						RenderConstants.Scenes.CharacterSelect.SelectedName.TopMargin -
						RenderConstants.Font.CharacterHeight),
					0.0050f,
					TransitionConstants.CharacterSelect.OpponentName.Entering(),
					null,
					Translations.GetTranslation(StringConstants.Buttons.CharacterSelect.Challenge),
					80));

			// Feedback
			var cursorTopMargin = Textures.BAR_SHELVES.Height - Textures.Portrait.Sam.DEFAULT.Height -
				RenderConstants.Scenes.CharacterSelect.Cursor.BottomMargin;

			_entities.Add(
				StringConstants.Entities.CharacterSelect.Cursor,
				new Cursor(
					Origin.TopCenter,
					new Vector2(centerX - portraitSeparation * 1.5f, cursorTopMargin),
					0.0040f,
					30,
					true));

			// Titles
			_entities.Add(
				StringConstants.Entities.CharacterSelect.PageTitle,
				new PageTitle(
					Origin.TopCenter,
					new Vector2(RenderConstants.MinigameScreen.Width / 2,
						RenderConstants.Scenes.MainMenu.GameTitle.TopMargin),
					0.0050f,
					TransitionConstants.CharacterSelect.PageTitle.Entering(),
					TransitionConstants.CharacterSelect.Exiting(),
					Translations.GetTranslation(StringConstants.Titles.CharacterSelect),
					200));

			_entities.Add(
				StringConstants.Entities.CharacterSelect.SelectedName,
				new Text(
					Origin.TopCenter,
					new Vector2(RenderConstants.MinigameScreen.Width / 2,
						RenderConstants.Scenes.MainMenu.GameTitle.TopMargin +
						RenderConstants.Scenes.CharacterSelect.SelectedName.TopMargin),
					0.0050f,
					TransitionConstants.CharacterSelect.OpponentName.Entering(),
					TransitionConstants.CharacterSelect.Exiting(),
					Sam.Name,
					80,
					1f,
					true));
		}

		/// <summary>
		/// Initiate exiting transition and create <see cref="GameScene"/> / <see cref="DialogScene"/>
		/// </summary>
		private void CharacterSelected()
		{
			GetChallengeButton().SetTransitionState(TransitionState.Dead);

			foreach (var key in StringConstants.Entities.CharacterSelect.Portraits)
			{
				if (_opponentName == ((Portrait) _entities[key]).GetName())
				{
					var emotion = PortraitEmotion.Laugh;

					if (_opponentName == NPCName.Abigail)
						emotion = PortraitEmotion.Glare;
					else if (_opponentName == NPCName.Sebastian) emotion = PortraitEmotion.Smurk;

					((Portrait) _entities[key]).SetEmotion(emotion);
					_entities[key].SetExitingTransition(TransitionConstants.CharacterSelect.Portrait.ActiveExiting());

					_opponent = ComputerOpponent.GetComputerOpponentFromName(_opponentName);

					// Play their theme song for intensity
					Sound.PlayMusic(_opponent.GetMusicId());
				}

				_entities[key].SetTransitionState(TransitionState.Exiting, true);
			}

			GetCursor().SetExitingTransition(TransitionConstants.CharacterSelect.Portrait.ActiveExiting());
			GetCursor().SetTransitionState(TransitionState.Exiting, true);

			ISceneCreator gameSceneCreator = new GameSceneCreator(Player.GetMainPlayer(), _opponent);
			_newScene = new DialogScene(gameSceneCreator);
		}

		/// <summary>
		/// Retrieves <see cref="SubmitButton"/> that finalizes selection.
		/// </summary>
		/// <returns><see cref="SubmitButton"/> that finalizes selection</returns>
		private SubmitButton GetChallengeButton()
		{
			return (SubmitButton) _entities[StringConstants.Entities.CharacterSelect.ChallengeButton];
		}

		/// <summary>
		/// Retrieves <see cref="Cursor"/> that hovers over selected <see cref="Portrait"/>.
		/// </summary>
		/// <returns><see cref="Cursor"/> that hovers over selected <see cref="Portrait"/></returns>
		private Cursor GetCursor()
		{
			return (Cursor) _entities[StringConstants.Entities.CharacterSelect.Cursor];
		}

		/// <summary>
		/// Retrieves <see cref="Text"/> of selected <see cref="Portrait"/> name.
		/// </summary>
		/// <returns><see cref="Text"/> of selected <see cref="Portrait"/> name</returns>
		private Text GetSelectedText()
		{
			return (Text) _entities[StringConstants.Entities.CharacterSelect.SelectedName];
		}

		/// <summary>
		/// Updates entities based on state
		/// </summary>
		private void UpdatePortraits()
		{
			// Darken out unselected portraits
			foreach (var key in StringConstants.Entities.CharacterSelect.Portraits)
			{
				var portrait = (Portrait) _entities[key];

				if (portrait.GetName() == NPCName.Abigail)
				{
					portrait.SetDarker(_opponentName != portrait.GetName() && Save.IsAbigailUnlocked());
					portrait.SetSilhouette(!Save.IsAbigailUnlocked());
				}
				else if (portrait.GetName() == NPCName.Gus)
				{
					portrait.SetDarker(_opponentName != portrait.GetName() && Save.IsGusUnlocked());
					portrait.SetSilhouette(!Save.IsGusUnlocked());
				}
				else
				{
					portrait.SetDarker(_opponentName != portrait.GetName());
				}
			}

			// Reposition cursor and set name to selected opponent
			float centerX = RenderConstants.MinigameScreen.Width / 2;
			var cursorTopMargin = Textures.BAR_SHELVES.Height - Textures.Portrait.Sam.DEFAULT.Height -
				RenderConstants.Scenes.CharacterSelect.Cursor.BottomMargin;
			float portraitSeparation = Textures.Portrait.Sam.DEFAULT.Width;

			var cursorAnchor = new Vector2(centerX - portraitSeparation * 1.5f, cursorTopMargin);
			var selectedOpponentName = Sam.Name;

			switch (_opponentName)
			{
				case NPCName.Sebastian:
					cursorAnchor = new Vector2(centerX - portraitSeparation * 0.55f, cursorTopMargin);
					selectedOpponentName = Sebastian.Name;
					GetChallengeButton().SetDisabled(false);

					break;

				case NPCName.Abigail:
					cursorAnchor = new Vector2(centerX + portraitSeparation * 0.4f, cursorTopMargin);

					if (Save.IsAbigailUnlocked())
					{
						selectedOpponentName = Abigail.Name;
						GetChallengeButton().SetDisabled(false);
					}
					else
					{
						selectedOpponentName = "????";
						GetChallengeButton().SetDisabled(true);
					}

					break;

				case NPCName.Gus:
					cursorAnchor = new Vector2(centerX + portraitSeparation * 1.4f, cursorTopMargin);

					if (Save.IsGusUnlocked())
					{
						selectedOpponentName = Gus.Name;
						GetChallengeButton().SetDisabled(false);
					}
					else
					{
						selectedOpponentName = "????";
						GetChallengeButton().SetDisabled(true);
					}

					break;

				default:
					GetChallengeButton().SetDisabled(false);

					break;
			}

			GetCursor().SetAnchor(cursorAnchor);
			GetCursor().SetTransitionState(TransitionState.Entering, true);
			GetSelectedText().SetText(selectedOpponentName);
			GetSelectedText().SetTransitionState(TransitionState.Entering, true);
		}
	}
}