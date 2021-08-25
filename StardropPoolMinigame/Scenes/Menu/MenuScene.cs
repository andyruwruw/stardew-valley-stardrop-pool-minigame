using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Render;

namespace StardropPoolMinigame.Scenes
{
    class MenuScene : Scene
    {
        private BallButton _playButton;

        private BallButton _multiplayerButton;

        private BallButton _galleryButton;

        private BallButton _settingsButton;

        public MenuScene() : base()
        {
            Sound.PlayMusic(SoundConstants.GAME_THEME);
            this.AddBackground();
            this.AddTitle();
            this.AddButtons();
        }

        public override void Update()
        {
            this.UpdateEntities();
        }

        public override void ReceiveLeftClick()
        {
            if (this._playButton.IsHovered())
            {
                this._playButton.ClickCallback();
                this._newScene = new CharacterSelectScene();
            } else if (this._multiplayerButton.IsHovered())
            {
                this._multiplayerButton.ClickCallback();
                this._newScene = new MultiplayerScene();
            } else if (this._galleryButton.IsHovered())
            {
                this._galleryButton.ClickCallback();
                this._newScene = new GalleryScene();
            } else if (this._settingsButton.IsHovered())
            {
                this._settingsButton.ClickCallback();
                this._newScene = new SettingsScene();
            }
        }

        public override void ReceiveRightClick()
        {
        }

        public override string GetKey()
        {
            return "menu-scene";
        }

        private void AddBackground()
        {
            this._entities.Add(new BarShelves(
                Origin.TopLeft,
                new Vector2(0, 0),
                0.0010f,
                null,
                null));

            float centerX = RenderConstants.MINIGAME_SCREEN_WIDTH / 2;
            float portraitTopMargin = Textures.BACKGROUND_BAR_SHELVES_BOUNDS.Height - Textures.PORTRAIT_SAM_DEFAULT_BOUNDS.Height;
            float portraitSeparation = Textures.PORTRAIT_SAM_DEFAULT_BOUNDS.Width;

            this._entities.Add(new Portrait(
                Origin.TopLeft,
                new Vector2(centerX - (portraitSeparation * 2), portraitTopMargin),
                0.0011f,
                TransitionConstants.MainMenuScenePortraitEnteringTransition(),
                null,
                OpponentType.Sam,
                true));

            this._entities.Add(new Portrait(
                Origin.TopLeft,
                new Vector2(centerX - portraitSeparation, portraitTopMargin),
                0.0011f,
                TransitionConstants.MainMenuScenePortraitEnteringTransition(),
                null,
                OpponentType.Sebastian,
                true));

            this._entities.Add(new Portrait(
                Origin.TopLeft,
                new Vector2(centerX, portraitTopMargin),
                0.0011f,
                TransitionConstants.MainMenuScenePortraitEnteringTransition(),
                null,
                OpponentType.Abigail,
                true));

            this._entities.Add(new Portrait(
                Origin.TopLeft,
                new Vector2(centerX + portraitSeparation, portraitTopMargin),
                0.0011f,
                TransitionConstants.MainMenuScenePortraitEnteringTransition(),
                null,
                OpponentType.Gus,
                true));
        }

        private void AddTitle()
        {
            this._entities.Add(new GameTitle(
                Origin.TopCenter, 
                new Vector2(RenderConstants.MINIGAME_SCREEN_WIDTH / 2, RenderConstants.MENU_SCENE_GAME_TITLE_TOP_MARGIN),
                0.0050f,
                TransitionConstants.MainMenuSceneGameTitleEnteringTransition(),
                null));
        }

        private void AddButtons()
        {
            float spaceHeight = RenderConstants.MINIGAME_SCREEN_HEIGHT - Textures.BACKGROUND_BAR_SHELVES_BOUNDS.Height;
            float buttonHeight = Textures.BUTTON_TEXT_PLAY_BOUNDS.Height;
            float margin = (spaceHeight - (buttonHeight * 4)) / 2;
            float baseY = margin + Textures.BACKGROUND_BAR_SHELVES_BOUNDS.Height;

            this._playButton = new BallButton(
                Origin.TopCenter,
                new Vector2((RenderConstants.MINIGAME_SCREEN_WIDTH / 2) + RenderConstants.BALL_BUTTON_LEFT_OFFSET, baseY),
                0.0040f,
                TransitionConstants.MainMenuSceneButtonEnteringTransition(0),
                null,
                Textures.BUTTON_TEXT_PLAY_BOUNDS,
                1);
            this._entities.Add(this._playButton);

            this._multiplayerButton = new BallButton(
                Origin.TopCenter,
                new Vector2((RenderConstants.MINIGAME_SCREEN_WIDTH / 2) + RenderConstants.BALL_BUTTON_LEFT_OFFSET, baseY + buttonHeight),
                0.0040f,
                TransitionConstants.MainMenuSceneButtonEnteringTransition(1),
                null,
                Textures.BUTTON_TEXT_MULTIPLAYER_BOUNDS,
                10);
            this._entities.Add(this._multiplayerButton);

            this._galleryButton = new BallButton(
                Origin.TopCenter,
                new Vector2((RenderConstants.MINIGAME_SCREEN_WIDTH / 2) + RenderConstants.BALL_BUTTON_LEFT_OFFSET, baseY + (buttonHeight * 2)),
                0.0040f,
                TransitionConstants.MainMenuSceneButtonEnteringTransition(2),
                null,
                Textures.BUTTON_TEXT_GALLERY_BOUNDS,
                3);
            this._entities.Add(this._galleryButton);

            this._settingsButton = new BallButton(
                Origin.TopCenter,
                new Vector2((RenderConstants.MINIGAME_SCREEN_WIDTH / 2) + RenderConstants.BALL_BUTTON_LEFT_OFFSET, baseY + (buttonHeight * 3)),
                0.0040f,
                TransitionConstants.MainMenuSceneButtonEnteringTransition(3),
                null,
                Textures.BUTTON_TEXT_SETTINGS_BOUNDS,
                12);
            this._entities.Add(this._settingsButton);
        }
    }
}
