using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame.Scenes
{
    internal class MainMenuScene : Scene
    {
        /// <summary>
        /// Instantiates <see cref="MainMenuScene"/>.
        /// </summary>
        public MainMenuScene() : base()
        {
            Sound.PlayMusic(SoundConstants.Theme.GAME);
        }

        public override string GetKey()
        {
            return "main-menu-scene";
        }

        public override void ReceiveLeftClick()
        {
            foreach (string key in StringConstants.Entities.MainMenu.BUTTONS)
            {
                if (this._entities[key].IsHovered())
                {
                    this._entities[key].ClickCallback();

                    if (key == StringConstants.Entities.MainMenu.MULTIPLAYER_BUTTON)
                    {
                        this._newScene = new MultiplayerScene();
                    }
                    else if (key == StringConstants.Entities.MainMenu.GALLERY_BUTTON)
                    {
                        this._newScene = new GalleryScene();
                    }
                    else if (key == StringConstants.Entities.MainMenu.SETTINGS_BUTTON)
                    {
                        this._newScene = new SettingsScene();
                    }
                    else
                    {
                        this._newScene = new CharacterSelectScene();
                    }
                }
            }
        }

        public override void ReceiveRightClick()
        {
        }

        public override void Update()
        {
            this.UpdateEntities();
        }

        protected override void AddEntities()
        {
            // Background
            this._entities.Add(
                StringConstants.Entities.MainMenu.BAR_SHELVES,
                new BarShelves(
                    Origin.TopLeft,
                    new Vector2(0, 0),
                    0.0010f,
                    null,
                    null));

            float centerX = RenderConstants.MinigameScreen.WIDTH / 2;
            float portraitTopMargin = Textures.BAR_SHELVES.Height - Textures.Portrait.Sam.DEFAULT.Height;
            float portraitSeparation = Textures.Portrait.Sam.DEFAULT.Width;

            this._entities.Add(
                StringConstants.Entities.MainMenu.SAM_PORTRAIT,
                new Portrait(
                    Origin.TopLeft,
                    new Vector2(centerX - (portraitSeparation * 2), portraitTopMargin),
                    0.0011f,
                    TransitionConstants.MainMenu.Portrait.Entering(),
                    TransitionConstants.MainMenu.Portrait.Exiting(),
                    NPCName.Sam,
                    isSilhouette: true));

            this._entities.Add(
                StringConstants.Entities.MainMenu.SEBASTIAN_PORTRAIT,
                new Portrait(
                    Origin.TopLeft,
                    new Vector2(centerX - portraitSeparation, portraitTopMargin),
                    0.0011f,
                    TransitionConstants.MainMenu.Portrait.Entering(),
                    TransitionConstants.MainMenu.Portrait.Exiting(),
                    NPCName.Sebastian,
                    isSilhouette: true));

            this._entities.Add(
                StringConstants.Entities.MainMenu.ABIGAIL_PORTRAIT,
                new Portrait(
                    Origin.TopLeft,
                    new Vector2(centerX, portraitTopMargin),
                    0.0011f,
                    TransitionConstants.MainMenu.Portrait.Entering(),
                    TransitionConstants.MainMenu.Portrait.Exiting(),
                    NPCName.Abigail,
                    isSilhouette: true));

            this._entities.Add(
                StringConstants.Entities.MainMenu.GUS_PORTRAIT,
                new Portrait(
                    Origin.TopLeft,
                    new Vector2(centerX + portraitSeparation, portraitTopMargin),
                    0.0011f,
                    TransitionConstants.MainMenu.Portrait.Entering(),
                    TransitionConstants.MainMenu.Portrait.Exiting(),
                    NPCName.Gus,
                    isSilhouette: true));

            // Buttons
            float spaceHeight = RenderConstants.MinigameScreen.HEIGHT - Textures.BAR_SHELVES.Height;
            float buttonHeight = RenderConstants.Font.CHARACTER_HEIGHT;
            float margin = (spaceHeight - (buttonHeight * 4) - RenderConstants.Scenes.MainMenu.BallButton.BUTTON_MARGIN * 3) / 2;
            float baseY = margin + Textures.BAR_SHELVES.Height;

            this._entities.Add(
                StringConstants.Entities.MainMenu.PLAY_BUTTON,
                new BallButton(
                    Origin.TopCenter,
                    new Vector2((RenderConstants.MinigameScreen.WIDTH / 2) + RenderConstants.Entities.BallButton.LEFT_OFFSET, baseY),
                    0.0040f,
                    TransitionConstants.MainMenu.Button.Entering(0),
                    TransitionConstants.MainMenu.Button.Exiting(0),
                    Translations.GetTranslation(StringConstants.Buttons.MainMenu.PLAY),
                    80,
                    1));

            this._entities.Add(
                StringConstants.Entities.MainMenu.MULTIPLAYER_BUTTON,
                new BallButton(
                    Origin.TopCenter,
                    new Vector2((RenderConstants.MinigameScreen.WIDTH / 2) + RenderConstants.Entities.BallButton.LEFT_OFFSET, baseY + buttonHeight + RenderConstants.Scenes.MainMenu.BallButton.BUTTON_MARGIN),
                    0.0040f,
                    TransitionConstants.MainMenu.Button.Entering(1),
                    TransitionConstants.MainMenu.Button.Exiting(1),
                    Translations.GetTranslation(StringConstants.Buttons.MainMenu.MULTIPLAYER),
                    80,
                    10));

            this._entities.Add(
                StringConstants.Entities.MainMenu.GALLERY_BUTTON,
                new BallButton(
                    Origin.TopCenter,
                    new Vector2((RenderConstants.MinigameScreen.WIDTH / 2) + RenderConstants.Entities.BallButton.LEFT_OFFSET, baseY + (buttonHeight * 2) + (RenderConstants.Scenes.MainMenu.BallButton.BUTTON_MARGIN * 2)),
                    0.0040f,
                    TransitionConstants.MainMenu.Button.Entering(2),
                    TransitionConstants.MainMenu.Button.Exiting(2),
                    Translations.GetTranslation(StringConstants.Buttons.MainMenu.GALLERY),
                    80,
                    3));

            this._entities.Add(
                StringConstants.Entities.MainMenu.SETTINGS_BUTTON,
                new BallButton(
                    Origin.TopCenter,
                    new Vector2((RenderConstants.MinigameScreen.WIDTH / 2) + RenderConstants.Entities.BallButton.LEFT_OFFSET, baseY + (buttonHeight * 3) + (RenderConstants.Scenes.MainMenu.BallButton.BUTTON_MARGIN * 3)),
                    0.0040f,
                    TransitionConstants.MainMenu.Button.Entering(3),
                    TransitionConstants.MainMenu.Button.Exiting(3),
                    Translations.GetTranslation(StringConstants.Buttons.MainMenu.SETTINGS),
                    80,
                    12));

            // Title
            this._entities.Add(
                StringConstants.Entities.MainMenu.GAME_TITLE,
                new GameTitle(
                    Origin.TopCenter,
                    new Vector2(RenderConstants.MinigameScreen.WIDTH / 2, RenderConstants.Scenes.MainMenu.GameTitle.TOP_MARGIN),
                    0.0050f,
                    TransitionConstants.MainMenu.GameTitle.Entering(),
                    TransitionConstants.MainMenu.GameTitle.Exiting()));
        }
    }
}