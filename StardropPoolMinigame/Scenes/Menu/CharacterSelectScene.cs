using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Rules;
using System.Collections.Generic;

namespace StardropPoolMinigame.Scenes
{
    class CharacterSelectScene : Scene
    {
        /// <summary>
        /// Clickable portrait of Sam
        /// </summary>
        Portrait _samPortrait;

        /// <summary>
        /// Clickable portrait of Sebastian
        /// </summary>
        Portrait _sebastianPortrait;

        /// <summary>
        /// Clickable portrait of Abigail
        /// </summary>
        Portrait _abigailPortrait;

        /// <summary>
        /// Clickable portrait of Gus
        /// </summary>
        Portrait _gusPortrait;

        /// <summary>
        /// Accessable list of clickable portraits
        /// </summary>
        IList<Portrait> _portraits;

        /// <summary>
        /// Arrow depicting selected opponent
        /// </summary>
        Cursor _cursor;

        /// <summary>
        /// Name of hovered or selected opponent
        /// </summary>
        Text _selectedName;

        /// <summary>
        /// Submit button to create game
        /// </summary>
        SubmitButton _challengeButton;

        /// <summary>
        /// Name of selected opponent
        /// </summary>
        OpponentType _opponentName;

        /// <summary>
        /// Class of selected opponent
        /// </summary>
        ComputerOpponent _opponent;

        public CharacterSelectScene() : base()
        {
            this._opponentName = OpponentType.Sam;
        }

        public override string GetKey()
        {
            return "charater-select-scene";
        }

        public override void Update()
        {
            this.UpdateEntities();
        }

        public override void ReceiveLeftClick()
        {
            // Check if buttons are clicked
            if (this._sebastianPortrait.IsHovered())
            {
                this._sebastianPortrait.ClickCallback();
                this._opponentName = OpponentType.Sebastian;
                this.UpdatePortraits();
            }
            else if (this._abigailPortrait.IsHovered())
            {
                this._abigailPortrait.ClickCallback();
                this._opponentName = OpponentType.Abigail;
                this.UpdatePortraits();
            }
            else if (this._samPortrait.IsHovered())
            {
                this._samPortrait.ClickCallback();
                this._opponentName = OpponentType.Sam;
                this.UpdatePortraits();
            }
            else if (this._gusPortrait.IsHovered())
            {
                this._gusPortrait.ClickCallback();
                this._opponentName = OpponentType.Gus;
                this.UpdatePortraits();
            }
            else if (
                this._challengeButton.IsHovered()
                && (this._opponentName != OpponentType.Abigail || Save.IsAbigailUnlocked())
                && (this._opponentName != OpponentType.Gus || Save.IsGusUnlocked()))
            {
                this._challengeButton.ClickCallback();
                Sound.StopMusic();
                this.CharacterSelected();
            }
        }

        public override void ReceiveRightClick()
        {
        }

        /// <summary>
        /// Updates entities based on state 
        /// </summary>
        private void UpdatePortraits()
        {
            // Darken out unselected portraits
            foreach (Portrait portrait in this._portraits)
            {
                if (portrait.GetName() == OpponentType.Abigail)
                {
                    portrait.SetDarker(this._opponentName != portrait.GetName() && Save.IsAbigailUnlocked());
                    portrait.SetSilhouette(!Save.IsAbigailUnlocked());
                } else if (portrait.GetName() == OpponentType.Gus)
                {
                    portrait.SetDarker(this._opponentName != portrait.GetName() && Save.IsGusUnlocked());
                    portrait.SetSilhouette(!Save.IsGusUnlocked());
                } else
                {
                    portrait.SetDarker(this._opponentName != portrait.GetName());
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
                case OpponentType.Sebastian:
                    cursorAnchor = new Vector2(centerX - (portraitSeparation * 0.55f), cursorTopMargin);
                    selectedOpponentName = Sebastian.Name;
                    this._challengeButton.SetDisabled(false);
                    break;
                case OpponentType.Abigail:
                    cursorAnchor = new Vector2(centerX + (portraitSeparation * 0.4f), cursorTopMargin);
                    if (Save.IsAbigailUnlocked())
                    {
                        selectedOpponentName = Abigail.Name;
                        this._challengeButton.SetDisabled(false);
                    } else
                    {
                        selectedOpponentName = "????";
                        this._challengeButton.SetDisabled(true);
                    }
                    break;
                case OpponentType.Gus:
                    cursorAnchor = new Vector2(centerX + (portraitSeparation * 1.4f), cursorTopMargin);
                    if (Save.IsGusUnlocked())
                    {
                        selectedOpponentName = Gus.Name;
                        this._challengeButton.SetDisabled(false);
                    }
                    else
                    {
                        selectedOpponentName = "????";
                        this._challengeButton.SetDisabled(true);
                    }
                    break;
                default:
                    this._challengeButton.SetDisabled(false);
                    break;
            }

            this._cursor.SetAnchor(cursorAnchor);
            this._cursor.SetTransitionState(TransitionState.Entering, true);
            this._selectedName.SetText(selectedOpponentName);
            this._selectedName.SetTransitionState(TransitionState.Entering, true);
        }

        /// <summary>
        /// Initiate exiting transition and create GameScene / DialogScene
        /// </summary>
        private void CharacterSelected()
        {
            this._challengeButton.SetTransitionState(TransitionState.Dead);

            foreach (Portrait portrait in this._portraits)
            {
                if (this._opponentName == portrait.GetName())
                {
                    PortraitEmotion emotion = PortraitEmotion.Laugh;

                    if (this._opponentName == OpponentType.Abigail)
                    {
                        emotion = PortraitEmotion.Glare;
                    }
                    else if (this._opponentName == OpponentType.Sebastian)
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

        protected override void AddEntities()
        {
            // Background
            this._entities.Add(new BarShelves(
                Origin.TopLeft,
                new Vector2(0, 0),
                0.0010f,
                null,
                TransitionConstants.CharacterSelect.Exiting()));

            this._entities.Add(new Solid(
                new Primitives.Rectangle(
                    new Vector2(0, Textures.BAR_SHELVES.Height),
                    (int)RenderConstants.MinigameScreen.WIDTH,
                    (int)RenderConstants.MinigameScreen.HEIGHT - Textures.BAR_SHELVES.Height),
                0.0031f,
                null,
                TransitionConstants.CharacterSelect.Exiting(),
                Color.Black));

            // Buttons
            this._portraits = new List<Portrait>();

            float centerX = RenderConstants.MinigameScreen.WIDTH / 2;
            float portraitTopMargin = Textures.BAR_SHELVES.Height - Textures.Portrait.Sam.DEFAULT.Height;
            float portraitSeparation = Textures.Portrait.Sam.DEFAULT.Width;

            this._samPortrait = new Portrait(
                Origin.TopLeft,
                new Vector2(centerX - (portraitSeparation * 2), portraitTopMargin),
                0.0030f,
                TransitionConstants.CharacterSelect.Portrait.Entering(),
                TransitionConstants.CharacterSelect.Portrait.Exiting(),
                OpponentType.Sam,
                isHoverable: true);
            this._entities.Add(this._samPortrait);
            this._portraits.Add(this._samPortrait);

            this._sebastianPortrait = new Portrait(
                Origin.TopLeft,
                new Vector2(centerX - portraitSeparation, portraitTopMargin),
                0.0030f,
                TransitionConstants.CharacterSelect.Portrait.Entering(),
                TransitionConstants.CharacterSelect.Portrait.Exiting(),
                OpponentType.Sebastian,
                isHoverable: true,
                isDarker: true);
            this._entities.Add(this._sebastianPortrait);
            this._portraits.Add(this._sebastianPortrait);

            this._abigailPortrait = new Portrait(
                Origin.TopLeft,
                new Vector2(centerX, portraitTopMargin),
                0.0030f,
                TransitionConstants.CharacterSelect.Portrait.Entering(),
                TransitionConstants.CharacterSelect.Portrait.Exiting(),
                OpponentType.Abigail,
                isHoverable: true,
                isDarker: Save.IsAbigailUnlocked(),
                isSilhouette: !Save.IsAbigailUnlocked());
            this._entities.Add(this._abigailPortrait);
            this._portraits.Add(this._abigailPortrait);

            this._gusPortrait = new Portrait(
                Origin.TopLeft,
                new Vector2(centerX + portraitSeparation, portraitTopMargin),
                0.0030f,
                TransitionConstants.CharacterSelect.Portrait.Entering(),
                TransitionConstants.CharacterSelect.Portrait.Exiting(),
                OpponentType.Gus,
                isHoverable: true,
                isDarker: Save.IsGusUnlocked(),
                isSilhouette: !Save.IsGusUnlocked());
            this._entities.Add(this._gusPortrait);
            this._portraits.Add(this._gusPortrait);

            this._challengeButton = new SubmitButton(
                Origin.TopCenter,
                new Vector2(RenderConstants.MinigameScreen.WIDTH / 2, RenderConstants.MinigameScreen.HEIGHT - RenderConstants.Scenes.CharacterSelect.SelectedName.TOP_MARGIN - RenderConstants.Font.CHARACTER_HEIGHT),
                0.0050f,
                TransitionConstants.CharacterSelect.OpponentName.Entering(),
                null,
                Translations.GetTranslation(StringConstants.Buttons.CharacterSelect.CHALLENGE),
                80);
            this._entities.Add(this._challengeButton);

            // Feedback
            float cursorTopMargin = Textures.BAR_SHELVES.Height - Textures.Portrait.Sam.DEFAULT.Height - RenderConstants.Scenes.CharacterSelect.Cursor.BOTTOM_MARGIN;

            this._cursor = new Cursor(
                Origin.TopCenter,
                new Vector2(centerX - (portraitSeparation * 1.5f), cursorTopMargin),
                0.0040f,
                30,
                true);
            this._entities.Add(this._cursor);

            // Titles
            this._entities.Add(new PageTitle(
                Origin.TopCenter,
                new Vector2(RenderConstants.MinigameScreen.WIDTH / 2, RenderConstants.Scenes.MainMenu.GameTitle.TOP_MARGIN),
                0.0050f,
                TransitionConstants.CharacterSelect.PageTitle.Entering(),
                TransitionConstants.CharacterSelect.Exiting(),
                Translations.GetTranslation(StringConstants.Titles.CHARACTER_SELECT),
                200));

            this._selectedName = new Text(
                Origin.TopCenter,
                new Vector2(RenderConstants.MinigameScreen.WIDTH / 2, RenderConstants.Scenes.MainMenu.GameTitle.TOP_MARGIN + RenderConstants.Scenes.CharacterSelect.SelectedName.TOP_MARGIN),
                0.0050f,
                TransitionConstants.CharacterSelect.OpponentName.Entering(),
                TransitionConstants.CharacterSelect.Exiting(),
                Sam.Name,
                80,
                1f,
                true);
            this._entities.Add(this._selectedName);
        }
    }
}
