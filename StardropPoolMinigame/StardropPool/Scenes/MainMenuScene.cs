using Microsoft.Xna.Framework;
using MinigameFramework.Constants;
using MinigameFramework.Entities;
using MinigameFramework.Entities.UI;
using MinigameFramework.Entities.UI.Portraits;
using MinigameFramework.Enums;
using MinigameFramework.Helpers;
using MinigameFramework.Render;
using MinigameFramework.Scenes;
using MinigameFramework.Utilities;
using StardopPoolMinigame.Constants;
using StardopPoolMinigame.Entities.UI;
using StardopPoolMinigame.Entities.UI.Backgrounds;
using StardopPoolMinigame.Entities.UI.Buttons;
using StardopPoolMinigame.MinigameFramework.Render.Filters;

namespace StardopPoolMinigame.Scenes
{
    /// <summary>
    /// Just the main menu.
    /// </summary>
    class MainMenuScene : Scene
    {
        /// <summary>
        /// Instantiates a <see cref="MainMenuScene"/>.
        /// </summary>
        public MainMenuScene() : base()
        {
            Sounds.PlayMusic(SoundConstants.GameTheme);
        }

        /// <inheritdoc cref="IScene.GetKey"/>
        public override string GetKey()
        {
            return "main-menu-scene";
        }

        /// <inheritdoc cref="Scene.AddEntities"/>
        protected override IList<IEntity> InitializeEntities()
        {
            IList<IEntity> entities = new List<IEntity>();

            GetBannerEntities();
            GetButtonEntities();

            return entities;
        }

        /// <summary>
        /// Adds banner entities.
        /// </summary>
        protected IEntity GetBannerEntities()
        {
            Section section = new Section();

            // Background
            _entities.Add(
                EntityKeys.MainMenu.BarShelves,
                new BarShelves(
                    new Vector2(0, 0),
                    0.0010f,
                    Origin.TopLeft,
                    null,
                    null
                )
            );

            // Add main title.
            _entities.Add(
                EntityKeys.MainMenu.GameTitle,
                new GameTitle(
                    anchor: new Vector2(
                        GenericTextures.GetMinigameScreenCenter().X,
                        RenderConstants.MainMenuScene.GameTitle.TopMargin
                    ),
                    layerDepth: 0.0050f,
                    origin: Origin.TopCenter,
                    enteringTransition: FilterGenerator.CreateSlideTransition(
                        difference: new Vector2(0, -25),
                        duration: 60,
                        delay: 0
                    ),
                    exitingTransition: FilterGenerator.CreateSlideTransition(
                        difference: new Vector2(0, -25),
                        duration: 30,
                        delay: 0,
                        type: TransitionState.Exiting
                    )
                )
            );
            
            return section;
        }

        /// <summary>
        /// Adds button entities.
        /// </summary>
        protected IList<IEntity> GetButtonEntities()
        {
            Section section = new Section();

            return section;
            
            IList<IEntity> entities = new List<IEntity>();

            IEntity playButton = new BallButton(
                key: EntityKeys.MainMenu.Play,
                text: Translations.GetTranslation(EntityKeys.MainMenu.Play),
                anchor: new Vector2(
                    GenericTextures.GetMinigameScreenCenter().X - RenderConstants.Entities.BallButton.LeftOffset,
                    RenderConstants.MainMenuScene.Buttons.TopMargin
                ),
                number: 1,
                layerDepth: 0.0040f,
                origin: Origin.TopLeft,
                enteringTransition: FilterGenerator.CreateSlideTransition(
                    difference: new Vector2(0, 8),
                    index: 0
                ),
                exitingTransition: FilterGenerator.CreateSlideTransition(
                    difference: new Vector2(0, 8),
                    delay: 0,
                    index: 0,
                    indexDelay: -4,
                    type: TransitionState.Exiting
                )
            );
            playButton.AddOnClickHandler(OnPlayButtonClicked);
            IEntity multiplayerButton = new BallButton(
                key: EntityKeys.MainMenu.Multiplayer,
                text: Translations.GetTranslation(EntityKeys.MainMenu.Multiplayer),
                anchor: new Vector2(
                    GenericTextures.GetMinigameScreenCenter().X - RenderConstants.Entities.BallButton.LeftOffset,
                    RenderConstants.MainMenuScene.Buttons.TopMargin + RenderConstants.MainMenuScene.Buttons.Height
                ),
                number: 10,
                layerDepth: 0.0040f,
                origin: Origin.TopLeft,
                enteringTransition: FilterGenerator.CreateSlideTransition(
                    difference: new Vector2(0, 8),
                    index: 1
                ),
                exitingTransition: FilterGenerator.CreateSlideTransition(
                    difference: new Vector2(0, 8),
                    delay: 0,
                    index: 1,
                    indexDelay: -4,
                    type: TransitionState.Exiting
                )
            );
            multiplayerButton.AddOnClickHandler(OnMultiplayerButtonClicked);
            IEntity galleryButton = new BallButton(
                key: EntityKeys.MainMenu.Gallery,
                text: Translations.GetTranslation(EntityKeys.MainMenu.Gallery),
                anchor: new Vector2(
                    GenericTextures.GetMinigameScreenCenter().X - RenderConstants.Entities.BallButton.LeftOffset,
                    RenderConstants.MainMenuScene.Buttons.TopMargin + RenderConstants.MainMenuScene.Buttons.Height * 2
                ),
                number: 3,
                layerDepth: 0.0040f,
                origin: Origin.TopLeft,
                enteringTransition: FilterGenerator.CreateSlideTransition(
                    difference: new Vector2(0, 8),
                    index: 2
                ),
                exitingTransition: FilterGenerator.CreateSlideTransition(
                    difference: new Vector2(0, 8),
                    delay: 0,
                    index: 2,
                    indexDelay: -4,
                    type: TransitionState.Exiting
                )
            );
            galleryButton.AddOnClickHandler(OnGalleryButtonClicked);
            IEntity settingsButton = new BallButton(
                key: EntityKeys.MainMenu.Settings,
                text: Translations.GetTranslation(EntityKeys.MainMenu.Settings),
                anchor: new Vector2(
                    GenericTextures.GetMinigameScreenCenter().X - RenderConstants.Entities.BallButton.LeftOffset,
                    RenderConstants.MainMenuScene.Buttons.TopMargin + RenderConstants.MainMenuScene.Buttons.Height * 3
                ),
                number: 12,
                layerDepth: 0.0040f,
                origin: Origin.TopLeft,
                enteringTransition: FilterGenerator.CreateSlideTransition(
                    difference: new Vector2(0, 8),
                    index: 3
                ),
                exitingTransition: FilterGenerator.CreateSlideTransition(
                    difference: new Vector2(0, 8),
                    delay: 0,
                    index: 3,
                    indexDelay: -4,
                    type: TransitionState.Exiting
                )
            );
            settingsButton.AddOnClickHandler(OnSettingsButtonClicked);

            Section section = new Section(
                new List<IEntity>() {
                    playButton,
                    multiplayerButton,
                    galleryButton,
                    settingsButton
                },
                new Vector2(
                    0,
                    RenderConstants.MainMenuScene.Buttons.TopMargin
                ),
                new Vector2(
                    GenericRenderConstants.MinigameScreen.Width,
                    RenderConstants.MainMenuScene.Buttons.Height * 4
                )
            );

            Microsoft.Xna.Framework.Rectangle buttonBoundingBox = RenderHelpers.FindBoundingBox(new List<IEntity>() {
                playButton,
                multiplayerButton,
                galleryButton,
                settingsButton
            });

            float margin = (GenericRenderConstants.MinigameScreen.Width - buttonBoundingBox.Width) / 2;

            playButton.SetAnchor(new Vector2(
                margin,
                playButton.GetTopLeft().Y
            ));
            multiplayerButton.SetAnchor(new Vector2(
                margin,
                multiplayerButton.GetTopLeft().Y
            ));
            galleryButton.SetAnchor(new Vector2(
                margin,
                galleryButton.GetTopLeft().Y
            ));
            settingsButton.SetAnchor(new Vector2(
                margin,
                settingsButton.GetTopLeft().Y
            ));

            // Draw the buttons.
            _entities.Add(
                EntityKeys.MainMenu.Play,
                playButton
            );
            _entities.Add(
                EntityKeys.MainMenu.Multiplayer,
                multiplayerButton
            );
            _entities.Add(
                EntityKeys.MainMenu.Gallery,
                galleryButton
            );
            _entities.Add(
                EntityKeys.MainMenu.Settings,
                settingsButton
            );

            return entities;
        }

        /// <summary>
        /// Adds portrait entities.
        /// </summary>
        protected void AddPortraitEntities()
        {
            // Draw the silhouettes
            _entities.Add(
                EntityKeys.MainMenu.SamPortrait,
                new Portrait(
                    name: DisplayableNPC.Sam,
                    anchor: new Vector2(
                        GenericTextures.GetMinigameScreenCenter().X - (RenderConstants.MainMenuScene.Portraits.Gap * 2),
                        RenderConstants.MainMenuScene.Portraits.TopMargin
                    ),
                    layerDepth: 0.0011f,
                    enteringTransition: FilterGenerator.CreateSlideTransition(
                        difference: new Vector2(0, 4),
                        duration: 25,
                        delay: 20
                    ),
                    exitingTransition: FilterGenerator.CreateSlideTransition(
                        difference: new Vector2(
                            0,
                            GenericTextureConstants.Portrait.Size / 2
                        ),
                        delay: 0,
                        randomDelay: true,
                        type: TransitionState.Exiting
                    ),
                    isSilhouette: true
                )
            );
            _entities.Add(
                EntityKeys.MainMenu.SebastianPortrait,
                new Portrait(
                    name: DisplayableNPC.Sebastian,
                    anchor: new Vector2(
                        GenericTextures.GetMinigameScreenCenter().X - RenderConstants.MainMenuScene.Portraits.Gap,
                        RenderConstants.MainMenuScene.Portraits.TopMargin
                    ),
                    layerDepth: 0.0011f,
                    enteringTransition: FilterGenerator.CreateSlideTransition(
                        difference: new Vector2(0, 4),
                        duration: 25,
                        delay: 20
                    ),
                    exitingTransition: FilterGenerator.CreateSlideTransition(
                        difference: new Vector2(
                            0,
                            GenericTextureConstants.Portrait.Size / 2
                        ),
                        delay: 0,
                        randomDelay: true,
                        type: TransitionState.Exiting
                    ),
                    isSilhouette: true
                )
            );
            _entities.Add(
                EntityKeys.MainMenu.AbigailPortrait,
                new Portrait(
                    name: DisplayableNPC.Abigail,
                    anchor: new Vector2(
                        GenericTextures.GetMinigameScreenCenter().X,
                        RenderConstants.MainMenuScene.Portraits.TopMargin
                    ),
                    layerDepth: 0.0011f,
                    enteringTransition: FilterGenerator.CreateSlideTransition(
                        difference: new Vector2(0, 4),
                        duration: 25,
                        delay: 20
                    ),
                    exitingTransition: FilterGenerator.CreateSlideTransition(
                        difference: new Vector2(
                            0,
                            GenericTextureConstants.Portrait.Size / 2
                        ),
                        delay: 0,
                        randomDelay: true,
                        type: TransitionState.Exiting
                    ),
                    isSilhouette: true
                )
            );
            _entities.Add(
                EntityKeys.MainMenu.GusPortrait,
                new Portrait(
                    name: DisplayableNPC.Gus,
                    anchor: new Vector2(
                        GenericTextures.GetMinigameScreenCenter().X + RenderConstants.MainMenuScene.Portraits.Gap,
                        RenderConstants.MainMenuScene.Portraits.TopMargin
                    ),
                    layerDepth: 0.0011f,
                    enteringTransition: FilterGenerator.CreateSlideTransition(
                        difference: new Vector2(0, 4),
                        duration: 25,
                        delay: 20
                    ),
                    exitingTransition: FilterGenerator.CreateSlideTransition(
                        difference: new Vector2(
                            0,
                            GenericTextureConstants.Portrait.Size / 2
                        ),
                        delay: 0,
                        randomDelay: true,
                        type: TransitionState.Exiting
                    ),
                    isSilhouette: true
                )
            );
        }
    
        protected void OnPlayButtonClicked(
            object? obj,
            string key
        )
        {
            Logger.Debug("Play button was clicked!");
            _newScene = new GameSetupScene();
        }

        protected void OnMultiplayerButtonClicked(
            object? obj,
            string key
        )
        {
            // Game1.currentMinigame = new StardropPoolMinigame();
        }

        protected void OnGalleryButtonClicked(
            object? obj,
            string key
        )
        {
            // Game1.currentMinigame = new StardropPoolMinigame();
        }

        protected void OnSettingsButtonClicked(
            object? obj,
            string key
        )
        {
            // Game1.currentMinigame = new StardropPoolMinigame();
        }
    }
}
