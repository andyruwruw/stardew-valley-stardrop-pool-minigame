﻿using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame.Scenes
{
    class CharacterSelectScene : Scene
    {
        /// <summary>
        /// Name of selected opponent
        /// </summary>
        NPCName _opponentName;

        /// <summary>
        /// Class of selected opponent
        /// </summary>
        ComputerOpponent _opponent;

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
            return "charater-select-scene";
        }

        /// <inheritdoc cref="Scene.Update"/>
        public override void Update()
        {
            this.UpdateEntities();
        }

        /// <inheritdoc cref="Scene.ReceiveLeftClick"/>
        public override void ReceiveLeftClick()
        {
            // Check if buttons are clicked
            foreach (string key in StringConstants.Entities.CharacterSelect.PORTRAITS)
            {
                if (this._entities[key].IsHovered())
                {
                    this._entities[key].ClickCallback();
                    this._opponentName = ((Portrait)this._entities[key]).GetName();
                    this.UpdatePortraits();
                    return;
                }
            }

            if (this._entities[StringConstants.Entities.CharacterSelect.CHALLENGE_BUTTON].IsHovered()
                && (this._opponentName != NPCName.Abigail || Save.IsAbigailUnlocked())
                && (this._opponentName != NPCName.Gus || Save.IsGusUnlocked()))
            {
                this._entities[StringConstants.Entities.CharacterSelect.CHALLENGE_BUTTON].ClickCallback();
                Sound.StopMusic();
                this.CharacterSelected();
            }
        }

        /// <inheritdoc cref="Scene.AddEntities"/>
        protected override void AddEntities()
        {
            // Background
            this._entities.Add(
                StringConstants.Entities.CharacterSelect.BAR_SHELVES,
                new BarShelves(
                    Origin.TopLeft,
                    new Vector2(0, 0),
                    0.0010f,
                    null,
                    TransitionConstants.CharacterSelect.Exiting()));

            this._entities.Add(
                StringConstants.Entities.CharacterSelect.BOTTOM_BACKGROUND,
                new Solid(
                    new Primitives.Rectangle(
                        new Vector2(0, Textures.BAR_SHELVES.Height),
                        (int)RenderConstants.MinigameScreen.WIDTH,
                        (int)RenderConstants.MinigameScreen.HEIGHT - Textures.BAR_SHELVES.Height),
                    0.0031f,
                    null,
                    TransitionConstants.CharacterSelect.Exiting(),
                    Color.Black));

            // Buttons
            float centerX = RenderConstants.MinigameScreen.WIDTH / 2;
            float portraitTopMargin = Textures.BAR_SHELVES.Height - Textures.Portrait.Sam.DEFAULT.Height;
            float portraitSeparation = Textures.Portrait.Sam.DEFAULT.Width;

            this._entities.Add(
                StringConstants.Entities.CharacterSelect.SAM_PORTRAIT,
                new Portrait(
                    Origin.TopLeft,
                    new Vector2(centerX - (portraitSeparation * 2), portraitTopMargin),
                    0.0030f,
                    TransitionConstants.CharacterSelect.Portrait.Entering(),
                    TransitionConstants.CharacterSelect.Portrait.Exiting(),
                    NPCName.Sam,
                    isHoverable: true));

            this._entities.Add(
                StringConstants.Entities.CharacterSelect.SEBASTIAN_PORTRAIT,
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
                StringConstants.Entities.CharacterSelect.ABIGAIL_PORTRAIT,
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
                StringConstants.Entities.CharacterSelect.GUS_PORTRAIT,
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
                StringConstants.Entities.CharacterSelect.CHALLENGE_BUTTON,
                new SubmitButton(
                    Origin.TopCenter,
                    new Vector2(RenderConstants.MinigameScreen.WIDTH / 2, RenderConstants.MinigameScreen.HEIGHT - RenderConstants.Scenes.CharacterSelect.SelectedName.TOP_MARGIN - RenderConstants.Font.CHARACTER_HEIGHT),
                    0.0050f,
                    TransitionConstants.CharacterSelect.OpponentName.Entering(),
                    null,
                    Translations.GetTranslation(StringConstants.Buttons.CharacterSelect.CHALLENGE),
                    80));

            // Feedback
            float cursorTopMargin = Textures.BAR_SHELVES.Height - Textures.Portrait.Sam.DEFAULT.Height - RenderConstants.Scenes.CharacterSelect.Cursor.BOTTOM_MARGIN;

            this._entities.Add(
                StringConstants.Entities.CharacterSelect.CURSOR,
                new Cursor(
                    Origin.TopCenter,
                    new Vector2(centerX - (portraitSeparation * 1.5f), cursorTopMargin),
                    0.0040f,
                    30,
                    true));

            // Titles
            this._entities.Add(
                StringConstants.Entities.CharacterSelect.PAGE_TITLE,
                new PageTitle(
                    Origin.TopCenter,
                    new Vector2(RenderConstants.MinigameScreen.WIDTH / 2, RenderConstants.Scenes.MainMenu.GameTitle.TOP_MARGIN),
                    0.0050f,
                    TransitionConstants.CharacterSelect.PageTitle.Entering(),
                    TransitionConstants.CharacterSelect.Exiting(),
                    Translations.GetTranslation(StringConstants.Titles.CHARACTER_SELECT),
                    200));

            this._entities.Add(
                StringConstants.Entities.CharacterSelect.SELECTED_NAME,
                new Text(
                    Origin.TopCenter,
                    new Vector2(RenderConstants.MinigameScreen.WIDTH / 2, RenderConstants.Scenes.MainMenu.GameTitle.TOP_MARGIN + RenderConstants.Scenes.CharacterSelect.SelectedName.TOP_MARGIN),
                    0.0050f,
                    TransitionConstants.CharacterSelect.OpponentName.Entering(),
                    TransitionConstants.CharacterSelect.Exiting(),
                    Sam.Name,
                    80,
                    1f,
                    true));
        }

        /// <summary>
        /// Updates entities based on state 
        /// </summary>
        private void UpdatePortraits()
        {
            // Darken out unselected portraits
            foreach (string key in StringConstants.Entities.CharacterSelect.PORTRAITS)
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
            float centerX = RenderConstants.MinigameScreen.WIDTH / 2;
            float cursorTopMargin = Textures.BAR_SHELVES.Height - Textures.Portrait.Sam.DEFAULT.Height - RenderConstants.Scenes.CharacterSelect.Cursor.BOTTOM_MARGIN;
            float portraitSeparation = Textures.Portrait.Sam.DEFAULT.Width;

            Vector2 cursorAnchor = new Vector2(centerX - (portraitSeparation * 1.5f), cursorTopMargin);
            string selectedOpponentName = Sam.Name;

            switch (this._opponentName)
            {
                case NPCName.Sebastian:
                    cursorAnchor = new Vector2(centerX - (portraitSeparation * 0.55f), cursorTopMargin);
                    selectedOpponentName = Sebastian.Name;
                    ((SubmitButton)this._entities[StringConstants.Entities.CharacterSelect.CHALLENGE_BUTTON]).SetDisabled(false);
                    break;
                case NPCName.Abigail:
                    cursorAnchor = new Vector2(centerX + (portraitSeparation * 0.4f), cursorTopMargin);
                    if (Save.IsAbigailUnlocked())
                    {
                        selectedOpponentName = Abigail.Name;
                        ((SubmitButton)this._entities[StringConstants.Entities.CharacterSelect.CHALLENGE_BUTTON]).SetDisabled(false);
                    } else
                    {
                        selectedOpponentName = "????";
                        ((SubmitButton)this._entities[StringConstants.Entities.CharacterSelect.CHALLENGE_BUTTON]).SetDisabled(true);
                    }
                    break;
                case NPCName.Gus:
                    cursorAnchor = new Vector2(centerX + (portraitSeparation * 1.4f), cursorTopMargin);
                    if (Save.IsGusUnlocked())
                    {
                        selectedOpponentName = Gus.Name;
                        ((SubmitButton)this._entities[StringConstants.Entities.CharacterSelect.CHALLENGE_BUTTON]).SetDisabled(false);
                    }
                    else
                    {
                        selectedOpponentName = "????";
                        ((SubmitButton)this._entities[StringConstants.Entities.CharacterSelect.CHALLENGE_BUTTON]).SetDisabled(true);
                    }
                    break;
                default:
                    ((SubmitButton)this._entities[StringConstants.Entities.CharacterSelect.CHALLENGE_BUTTON]).SetDisabled(false);
                    break;
            }

            this._entities[StringConstants.Entities.CharacterSelect.CURSOR].SetAnchor(cursorAnchor);
            this._entities[StringConstants.Entities.CharacterSelect.CURSOR].SetTransitionState(TransitionState.Entering, true);
            ((Text)this._entities[StringConstants.Entities.CharacterSelect.CURSOR]).SetText(selectedOpponentName);
            ((Text)this._entities[StringConstants.Entities.CharacterSelect.CURSOR]).SetTransitionState(TransitionState.Entering, true);
        }

        /// <summary>
        /// Initiate exiting transition and create <see cref="GameScene"/> / <see cref="DialogScene"/>
        /// </summary>
        private void CharacterSelected()
        {
            this._challengeButton.SetTransitionState(TransitionState.Dead);

            foreach (Portrait portrait in this._portraits)
            {
                if (this._opponentName == portrait.GetName())
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

                    portrait.SetEmotion(emotion);
                    portrait.SetExitingTransition(TransitionConstants.CharacterSelect.Portrait.ActiveExiting());

                    this._opponent = ComputerOpponent.GetComputerOpponentFromName(this._opponentName);

                    // Play their theme song for intensity
                    Sound.PlayMusic(this._opponent.GetMusicId());
                }

                portrait.SetTransitionState(TransitionState.Exiting, true);
            }

            this._cursor.SetExitingTransition(TransitionConstants.CharacterSelect.Portrait.ActiveExiting());
            this._cursor.SetTransitionState(TransitionState.Exiting, true);

            ISceneCreator gameSceneCreator = new GameSceneCreator(Player.GetMainPlayer(), this._opponent);
            this._newScene = new DialogScene(gameSceneCreator);
        }
    }
}