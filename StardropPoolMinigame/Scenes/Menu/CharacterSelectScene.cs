using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Render;
using System.Collections.Generic;

namespace StardropPoolMinigame.Scenes
{
    class CharacterSelectScene : Scene
    {
        Portrait _samPortrait;
        Portrait _sebastianPortrait;
        Portrait _abigailPortrait;
        Portrait _gusPortrait;

        IList<Portrait> _portraits;

        Cursor _cursor;
        Text _selectedName;

        SubmitButton _challengeButton;

        OpponentType _opponentName;

        ComputerOpponent _opponent;

        public CharacterSelectScene() : base()
        {
            this._opponentName = OpponentType.Sam;
        }

        public override void Update()
        {
            this.UpdateEntities();
        }

        public override void ReceiveLeftClick()
        {
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
            else if (this._challengeButton.IsHovered())
            {
                this._challengeButton.ClickCallback();
                Sound.StopMusic();
                this.CharacterSelected();
            }
        }

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
                    } else if (this._opponentName == OpponentType.Sebastian)
                    {
                        emotion = PortraitEmotion.Smurk;
                    }

                    portrait.SetEmotion(emotion);
                    portrait.SetExitingTransition(TransitionConstants.CharacterSelectSceneActivePortraitExitingTransition());

                    this._opponent = ComputerOpponent.GetComputerOpponentFromName(this._opponentName);

                    // Play their theme song for intensity
                    Sound.PlayMusic(this._opponent.GetMusicId());
                }

                portrait.SetTransitionState(TransitionState.Exiting, true);

                this._newScene = new DialogScene();
            }
        }

        public override void ReceiveRightClick()
        {
        }

        public override string GetKey()
        {
            return "charater-select-scene";
        }

        private void UpdatePortraits()
        {
            foreach (Portrait portrait in this._portraits)
            {
                portrait.SetSilhouette(this._opponentName != portrait.GetName());
            }

            float centerX = RenderConstants.MINIGAME_SCREEN_WIDTH / 2;
            float cursorTopMargin = Textures.BACKGROUND_BAR_SHELVES_BOUNDS.Height - Textures.PORTRAIT_SAM_DEFAULT_BOUNDS.Height - RenderConstants.CURSOR_BOTTOM_MARGIN;
            float portraitSeparation = Textures.PORTRAIT_SAM_DEFAULT_BOUNDS.Width;

            Vector2 cursorAnchor = new Vector2(centerX - (portraitSeparation * 1.5f), cursorTopMargin);
            Rectangle selectedOpponentNameBounds = Textures.BUTTON_TEXT_SAM_BOUNDS;

            switch (this._opponentName)
            {
                case OpponentType.Sebastian:
                    cursorAnchor = new Vector2(centerX - (portraitSeparation * 0.55f), cursorTopMargin);
                    selectedOpponentNameBounds = Textures.BUTTON_TEXT_SEBASTIAN_BOUNDS;
                    break;
                case OpponentType.Abigail:
                    cursorAnchor = new Vector2(centerX + (portraitSeparation * 0.4f), cursorTopMargin);
                    selectedOpponentNameBounds = Textures.BUTTON_TEXT_ABIGAIL_BOUNDS;
                    break;
                case OpponentType.Gus:
                    cursorAnchor = new Vector2(centerX + (portraitSeparation * 1.4f), cursorTopMargin);
                    selectedOpponentNameBounds = Textures.BUTTON_TEXT_GUS_BOUNDS;
                    break;
            }

            this._cursor.SetAnchor(cursorAnchor);
            this._cursor.SetTransitionState(TransitionState.Entering, true);
            this._selectedName.SetTextBounds(selectedOpponentNameBounds);
            this._selectedName.SetTransitionState(TransitionState.Entering, true);
        }

        protected override void AddEntities()
        {
            // Background
            this._entities.Add(new BarShelves(
                Origin.TopLeft,
                new Vector2(0, 0),
                0.0010f,
                null,
                null));

            this._entities.Add(new Solid(
                Origin.TopLeft,
                new Vector2(0, Textures.BACKGROUND_BAR_SHELVES_BOUNDS.Height),
                0.0031f,
                null,
                null,
                new Primitives.Rectangle(
                    new Vector2(0, Textures.BACKGROUND_BAR_SHELVES_BOUNDS.Height),
                    (int)RenderConstants.MINIGAME_SCREEN_WIDTH,
                    (int)RenderConstants.MINIGAME_SCREEN_HEIGHT - Textures.BACKGROUND_BAR_SHELVES_BOUNDS.Height),
                Color.Black));

            // Buttons
            this._portraits = new List<Portrait>();

            float centerX = RenderConstants.MINIGAME_SCREEN_WIDTH / 2;
            float portraitTopMargin = Textures.BACKGROUND_BAR_SHELVES_BOUNDS.Height - Textures.PORTRAIT_SAM_DEFAULT_BOUNDS.Height;
            float portraitSeparation = Textures.PORTRAIT_SAM_DEFAULT_BOUNDS.Width;

            this._samPortrait = new Portrait(
                Origin.TopLeft,
                new Vector2(centerX - (portraitSeparation * 2), portraitTopMargin),
                0.0030f,
                TransitionConstants.CharacterSelectScenePortraitFadeInTransition(),
                TransitionConstants.CharacterSelectScenePortraitExitingTransition(),
                OpponentType.Sam,
                false,
                isHoverable: true);
            this._entities.Add(this._samPortrait);
            this._portraits.Add(this._samPortrait);

            this._sebastianPortrait = new Portrait(
                Origin.TopLeft,
                new Vector2(centerX - portraitSeparation, portraitTopMargin),
                0.0030f,
                null,
                TransitionConstants.CharacterSelectScenePortraitExitingTransition(),
                OpponentType.Sebastian,
                true,
                isHoverable: true);
            this._entities.Add(this._sebastianPortrait);
            this._portraits.Add(this._sebastianPortrait);

            this._abigailPortrait = new Portrait(
                Origin.TopLeft,
                new Vector2(centerX, portraitTopMargin),
                0.0030f,
                null,
                TransitionConstants.CharacterSelectScenePortraitExitingTransition(),
                OpponentType.Abigail,
                true,
                isHoverable: true);
            this._entities.Add(this._abigailPortrait);
            this._portraits.Add(this._abigailPortrait);

            this._gusPortrait = new Portrait(
                Origin.TopLeft,
                new Vector2(centerX + portraitSeparation, portraitTopMargin),
                0.0030f,
                null,
                TransitionConstants.CharacterSelectScenePortraitExitingTransition(),
                OpponentType.Gus,
                true,
                isHoverable: true);
            this._entities.Add(this._gusPortrait);
            this._portraits.Add(this._gusPortrait);

            this._challengeButton = new SubmitButton(
                Origin.TopCenter,
                new Vector2(RenderConstants.MINIGAME_SCREEN_WIDTH / 2, RenderConstants.MINIGAME_SCREEN_HEIGHT - RenderConstants.CHARACTER_SELECT_NAME_TOP_MARGIN - Textures.BUTTON_TEXT_CHALLENGE_BOUNDS.Height),
                0.0050f,
                TransitionConstants.CharacterSelectSceneOpponentNameEnteringTransition(),
                null,
                Textures.BUTTON_TEXT_CHALLENGE_BOUNDS
            );
            this._entities.Add(this._challengeButton);

            // Feedback
            float cursorTopMargin = Textures.BACKGROUND_BAR_SHELVES_BOUNDS.Height - Textures.PORTRAIT_SAM_DEFAULT_BOUNDS.Height - RenderConstants.CURSOR_BOTTOM_MARGIN;

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
                new Vector2(RenderConstants.MINIGAME_SCREEN_WIDTH / 2, RenderConstants.MENU_SCENE_GAME_TITLE_TOP_MARGIN),
                0.0050f,
                TransitionConstants.CharacterSelectScenePageTitleEnteringTransition(),
                null,
                Textures.TITLE_CHARACTER_SELECT_MENU_BOUNDS));

            this._selectedName = new Text(
                Origin.TopCenter,
                new Vector2(RenderConstants.MINIGAME_SCREEN_WIDTH / 2, RenderConstants.MENU_SCENE_GAME_TITLE_TOP_MARGIN + RenderConstants.CHARACTER_SELECT_NAME_TOP_MARGIN),
                0.0050f,
                TransitionConstants.CharacterSelectSceneOpponentNameEnteringTransition(),
                null,
                Textures.BUTTON_TEXT_SAM_BOUNDS);
            this._entities.Add(this._selectedName);
        }
    }
}
