using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Utilities;

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
        public CharacterSelectScene() : base()
        {
            this._opponentName = NPCName.Sam;
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
            foreach (string key in StringConstants.Entities.CharacterSelect.Portraits)
            {
                if (this._entities[key].IsHovered())
                {
                    this._entities[key].ClickCallback();
                    this._opponentName = ((Portrait)this._entities[key]).GetName();
                    this.UpdatePortraits();
                    return;
                }
            }

            if (this._entities[StringConstants.Entities.CharacterSelect.ChallengeButton].IsHovered()
                && (this._opponentName != NPCName.Abigail || Save.IsAbigailUnlocked())
                && (this._opponentName != NPCName.Gus || Save.IsGusUnlocked()))
            {
                this._entities[StringConstants.Entities.CharacterSelect.ChallengeButton].ClickCallback();
                Sound.StopMusic();
                this.CharacterSelected();
            }
        }

        /// <inheritdoc cref="Scene.Update"/>
        public override void Update()
        {
            this.UpdateEntities();
        }

        /// <inheritdoc cref="Scene.AddEntities"/>
        protected override void AddEntities()
        {
            // Background
            this._entities.Add(
                StringConstants.Entities.CharacterSelect.BarShelves,
                new BarShelves(
                    Origin.TopLeft,
                    new Vector2(0, 0),
                    0.0010f,
                    null,
                    TransitionConstants.CharacterSelect.Exiting()));

            this._entities.Add(
                StringConstants.Entities.CharacterSelect.BottomBackground,
                new Solid(
                    new Primitives.Rectangle(
                        new Vector2(0, Textures.BAR_SHELVES.Height),
                        (int)RenderConstants.MinigameScreen.Width,
                        (int)RenderConstants.MinigameScreen.Height - Textures.BAR_SHELVES.Height),
                    0.0031f,
                    null,
                    TransitionConstants.CharacterSelect.Exiting(),
                    Color.Black));

            // Buttons
            float centerX = RenderConstants.MinigameScreen.Width / 2;
            float portraitTopMargin = Textures.BAR_SHELVES.Height - Textures.Portrait.Sam.DEFAULT.Height;
            float portraitSeparation = Textures.Portrait.Sam.DEFAULT.Width;

            this._entities.Add(
                StringConstants.Entities.CharacterSelect.SamPortrait,
                new Portrait(
                    Origin.TopLeft,
                    new Vector2(centerX - (portraitSeparation * 2), portraitTopMargin),
                    0.0030f,
                    TransitionConstants.CharacterSelect.Portrait.Entering(),
                    TransitionConstants.CharacterSelect.Portrait.Exiting(),
                    NPCName.Sam,
                    isHoverable: true));

            this._entities.Add(
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

            this._entities.Add(
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

            this._entities.Add(
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

            this._entities.Add(
                StringConstants.Entities.CharacterSelect.ChallengeButton,
                new SubmitButton(
                    Origin.TopCenter,
                    new Vector2(RenderConstants.MinigameScreen.Width / 2, RenderConstants.MinigameScreen.Height - RenderConstants.Scenes.CharacterSelect.SelectedName.TopMargin - RenderConstants.Font.CharacterHeight),
                    0.0050f,
                    TransitionConstants.CharacterSelect.OpponentName.Entering(),
                    null,
                    Translations.GetTranslation(StringConstants.Buttons.CharacterSelect.Challenge),
                    80));

            // Feedback
            float cursorTopMargin = Textures.BAR_SHELVES.Height - Textures.Portrait.Sam.DEFAULT.Height - RenderConstants.Scenes.CharacterSelect.Cursor.BottomMargin;

            this._entities.Add(
                StringConstants.Entities.CharacterSelect.Cursor,
                new Cursor(
                    Origin.TopCenter,
                    new Vector2(centerX - (portraitSeparation * 1.5f), cursorTopMargin),
                    0.0040f,
                    30,
                    true));

            // Titles
            this._entities.Add(
                StringConstants.Entities.CharacterSelect.PageTitle,
                new PageTitle(
                    Origin.TopCenter,
                    new Vector2(RenderConstants.MinigameScreen.Width / 2, RenderConstants.Scenes.MainMenu.GameTitle.TopMargin),
                    0.0050f,
                    TransitionConstants.CharacterSelect.PageTitle.Entering(),
                    TransitionConstants.CharacterSelect.Exiting(),
                    Translations.GetTranslation(StringConstants.Titles.CharacterSelect),
                    200));

            this._entities.Add(
                StringConstants.Entities.CharacterSelect.SelectedName,
                new Text(
                    Origin.TopCenter,
                    new Vector2(RenderConstants.MinigameScreen.Width / 2, RenderConstants.Scenes.MainMenu.GameTitle.TopMargin + RenderConstants.Scenes.CharacterSelect.SelectedName.TopMargin),
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
            this.GetChallengeButton().SetTransitionState(TransitionState.Dead);

            foreach (string key in StringConstants.Entities.CharacterSelect.Portraits)
            {
                if (this._opponentName == ((Portrait)this._entities[key]).GetName())
                {
                    PortraitEmotion emotion = PortraitEmotion.Laugh;

                    if (this._opponentName == NPCName.Abigail)
                    {
                        emotion = PortraitEmotion.Glare;
                    }
                    else if (this._opponentName == NPCName.Sebastian)
                    {
                        emotion = PortraitEmotion.Smurk;
                    }

                    ((Portrait)this._entities[key]).SetEmotion(emotion);
                    this._entities[key].SetExitingTransition(TransitionConstants.CharacterSelect.Portrait.ActiveExiting());

                    this._opponent = ComputerOpponent.GetComputerOpponentFromName(this._opponentName);

                    // Play their theme song for intensity
                    Sound.PlayMusic(this._opponent.GetMusicId());
                }

                this._entities[key].SetTransitionState(TransitionState.Exiting, true);
            }

            this.GetCursor().SetExitingTransition(TransitionConstants.CharacterSelect.Portrait.ActiveExiting());
            this.GetCursor().SetTransitionState(TransitionState.Exiting, true);

            ISceneCreator gameSceneCreator = new GameSceneCreator(Player.GetMainPlayer(), this._opponent);
            this._newScene = new DialogScene(gameSceneCreator);
        }

        /// <summary>
        /// Retrieves <see cref="SubmitButton"/> that finalizes selection.
        /// </summary>
        /// <returns><see cref="SubmitButton"/> that finalizes selection</returns>
        private SubmitButton GetChallengeButton()
        {
            return (SubmitButton)this._entities[StringConstants.Entities.CharacterSelect.ChallengeButton];
        }

        /// <summary>
        /// Retrieves <see cref="Cursor"/> that hovers over selected <see cref="Portrait"/>.
        /// </summary>
        /// <returns><see cref="Cursor"/> that hovers over selected <see cref="Portrait"/></returns>
        private Cursor GetCursor()
        {
            return (Cursor)this._entities[StringConstants.Entities.CharacterSelect.Cursor];
        }

        /// <summary>
        /// Updates entities based on state
        /// </summary>
        private void UpdatePortraits()
        {
            // Darken out unselected portraits
            foreach (string key in StringConstants.Entities.CharacterSelect.Portraits)
            {
                if (((Portrait)this._entities[key]).GetName() == NPCName.Abigail)
                {
                    ((Portrait)this._entities[key]).SetDarker(this._opponentName != ((Portrait)this._entities[key]).GetName() && Save.IsAbigailUnlocked());
                    ((Portrait)this._entities[key]).SetSilhouette(!Save.IsAbigailUnlocked());
                }
                else if (((Portrait)this._entities[key]).GetName() == NPCName.Gus)
                {
                    ((Portrait)this._entities[key]).SetDarker(this._opponentName != ((Portrait)this._entities[key]).GetName() && Save.IsGusUnlocked());
                    ((Portrait)this._entities[key]).SetSilhouette(!Save.IsGusUnlocked());
                }
                else
                {
                    ((Portrait)this._entities[key]).SetDarker(this._opponentName != ((Portrait)this._entities[key]).GetName());
                }
            }

            // Reposition cursor and set name to selected opponent
            float centerX = RenderConstants.MinigameScreen.Width / 2;
            float cursorTopMargin = Textures.BAR_SHELVES.Height - Textures.Portrait.Sam.DEFAULT.Height - RenderConstants.Scenes.CharacterSelect.Cursor.BottomMargin;
            float portraitSeparation = Textures.Portrait.Sam.DEFAULT.Width;

            Vector2 cursorAnchor = new Vector2(centerX - (portraitSeparation * 1.5f), cursorTopMargin);
            string selectedOpponentName = Sam.Name;

            switch (this._opponentName)
            {
                case NPCName.Sebastian:
                    cursorAnchor = new Vector2(centerX - (portraitSeparation * 0.55f), cursorTopMargin);
                    selectedOpponentName = Sebastian.Name;
                    ((SubmitButton)this._entities[StringConstants.Entities.CharacterSelect.ChallengeButton]).SetDisabled(false);
                    break;

                case NPCName.Abigail:
                    cursorAnchor = new Vector2(centerX + (portraitSeparation * 0.4f), cursorTopMargin);
                    if (Save.IsAbigailUnlocked())
                    {
                        selectedOpponentName = Abigail.Name;
                        ((SubmitButton)this._entities[StringConstants.Entities.CharacterSelect.ChallengeButton]).SetDisabled(false);
                    }
                    else
                    {
                        selectedOpponentName = "????";
                        ((SubmitButton)this._entities[StringConstants.Entities.CharacterSelect.ChallengeButton]).SetDisabled(true);
                    }
                    break;

                case NPCName.Gus:
                    cursorAnchor = new Vector2(centerX + (portraitSeparation * 1.4f), cursorTopMargin);
                    if (Save.IsGusUnlocked())
                    {
                        selectedOpponentName = Gus.Name;
                        ((SubmitButton)this._entities[StringConstants.Entities.CharacterSelect.ChallengeButton]).SetDisabled(false);
                    }
                    else
                    {
                        selectedOpponentName = "????";
                        ((SubmitButton)this._entities[StringConstants.Entities.CharacterSelect.ChallengeButton]).SetDisabled(true);
                    }
                    break;

                default:
                    ((SubmitButton)this._entities[StringConstants.Entities.CharacterSelect.ChallengeButton]).SetDisabled(false);
                    break;
            }

            this._entities[StringConstants.Entities.CharacterSelect.Cursor].SetAnchor(cursorAnchor);
            this._entities[StringConstants.Entities.CharacterSelect.Cursor].SetTransitionState(TransitionState.Entering, true);
            ((Text)this._entities[StringConstants.Entities.CharacterSelect.Cursor]).SetText(selectedOpponentName);
            ((Text)this._entities[StringConstants.Entities.CharacterSelect.Cursor]).SetTransitionState(TransitionState.Entering, true);
        }
    }
}