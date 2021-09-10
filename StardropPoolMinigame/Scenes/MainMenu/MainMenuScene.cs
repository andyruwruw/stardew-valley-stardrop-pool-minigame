using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Render;

namespace StardropPoolMinigame.Scenes
{
    class MainMenuScene : Scene
    {
        private BallButton _playButton;

        private BallButton _multiplayerButton;

        private BallButton _galleryButton;

        private BallButton _settingsButton;

        public MainMenuScene() : base()
        {
            Sound.PlayMusic(SoundConstants.Theme.GAME);
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

        protected override void AddEntities()
        {
            // Background
            this._entities.Add(new BarShelves(
                Origin.TopLeft,
                new Vector2(0, 0),
                0.0010f,
                null,
                null));

            float centerX = RenderConstants.MinigameScreen.WIDTH / 2;
            float portraitTopMargin = Textures.BAR_SHELVES.Height - Textures.Portrait.Sam.DEFAULT.Height;
            float portraitSeparation = Textures.Portrait.Sam.DEFAULT.Width;

            this._entities.Add(new Portrait(
                Origin.TopLeft,
                new Vector2(centerX - (portraitSeparation * 2), portraitTopMargin),
                0.0011f,
                TransitionConstants.MainMenu.Portrait.Entering(),
                TransitionConstants.MainMenu.Portrait.Exiting(),
                OpponentType.Sam,
                isSilhouette: true));

            this._entities.Add(new Portrait(
                Origin.TopLeft,
                new Vector2(centerX - portraitSeparation, portraitTopMargin),
                0.0011f,
                TransitionConstants.MainMenu.Portrait.Entering(),
                TransitionConstants.MainMenu.Portrait.Exiting(),
                OpponentType.Sebastian,
                isSilhouette: true));

            this._entities.Add(new Portrait(
                Origin.TopLeft,
                new Vector2(centerX, portraitTopMargin),
                0.0011f,
                TransitionConstants.MainMenu.Portrait.Entering(),
                TransitionConstants.MainMenu.Portrait.Exiting(),
                OpponentType.Abigail,
                isSilhouette: true));

            this._entities.Add(new Portrait(
                Origin.TopLeft,
                new Vector2(centerX + portraitSeparation, portraitTopMargin),
                0.0011f,
                TransitionConstants.MainMenu.Portrait.Entering(),
                TransitionConstants.MainMenu.Portrait.Exiting(),
                OpponentType.Gus,
                isSilhouette: true));

            // Buttons
            float spaceHeight = RenderConstants.MinigameScreen.HEIGHT - Textures.BAR_SHELVES.Height;
            float buttonHeight = RenderConstants.Font.CHARACTER_HEIGHT;
            float margin = (spaceHeight - (buttonHeight * 4) - RenderConstants.Scenes.MainMenu.BallButton.BUTTON_MARGIN * 3) / 2;
            float baseY = margin + Textures.BAR_SHELVES.Height;

            this._playButton = new BallButton(
                Origin.TopCenter,
                new Vector2((RenderConstants.MinigameScreen.WIDTH / 2) + RenderConstants.Entities.BallButton.LEFT_OFFSET, baseY),
                0.0040f,
                TransitionConstants.MainMenu.Button.Entering(0),
                TransitionConstants.MainMenu.Button.Exiting(0),
                Translations.GetTranslation(StringConstants.Buttons.MainMenu.PLAY),
                80,
                1);
            this._entities.Add(this._playButton);

            this._multiplayerButton = new BallButton(
                Origin.TopCenter,
                new Vector2((RenderConstants.MinigameScreen.WIDTH / 2) + RenderConstants.Entities.BallButton.LEFT_OFFSET, baseY + buttonHeight + RenderConstants.Scenes.MainMenu.BallButton.BUTTON_MARGIN),
                0.0040f,
                TransitionConstants.MainMenu.Button.Entering(1),
                TransitionConstants.MainMenu.Button.Exiting(1),
                Translations.GetTranslation(StringConstants.Buttons.MainMenu.MULTIPLAYER),
                80,
                10);
            this._entities.Add(this._multiplayerButton);

            this._galleryButton = new BallButton(
                Origin.TopCenter,
                new Vector2((RenderConstants.MinigameScreen.WIDTH / 2) + RenderConstants.Entities.BallButton.LEFT_OFFSET, baseY + (buttonHeight * 2) + (RenderConstants.Scenes.MainMenu.BallButton.BUTTON_MARGIN * 2)),
                0.0040f,
                TransitionConstants.MainMenu.Button.Entering(2),
                TransitionConstants.MainMenu.Button.Exiting(2),
                Translations.GetTranslation(StringConstants.Buttons.MainMenu.GALLERY),
                80,
                3);
            this._entities.Add(this._galleryButton);

            this._settingsButton = new BallButton(
                Origin.TopCenter,
                new Vector2((RenderConstants.MinigameScreen.WIDTH / 2) + RenderConstants.Entities.BallButton.LEFT_OFFSET, baseY + (buttonHeight * 3) + (RenderConstants.Scenes.MainMenu.BallButton.BUTTON_MARGIN * 3)),
                0.0040f,
                TransitionConstants.MainMenu.Button.Entering(3),
                TransitionConstants.MainMenu.Button.Exiting(3),
                Translations.GetTranslation(StringConstants.Buttons.MainMenu.SETTINGS),
                80,
                12);
            this._entities.Add(this._settingsButton);

            // Title
            this._entities.Add(new GameTitle(
                Origin.TopCenter,
                new Vector2(RenderConstants.MinigameScreen.WIDTH / 2, RenderConstants.Scenes.MainMenu.GameTitle.TOP_MARGIN),
                0.0050f,
                TransitionConstants.MainMenu.GameTitle.Entering(),
                TransitionConstants.MainMenu.GameTitle.Exiting()));
        }
    }
}
