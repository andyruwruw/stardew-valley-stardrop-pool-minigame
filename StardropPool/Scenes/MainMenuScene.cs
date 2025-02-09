using Microsoft.Xna.Framework;
using MinigameFramework.Constants;
using MinigameFramework.Entities.UI.Portraits;
using MinigameFramework.Enums;
using MinigameFramework.Render;
using MinigameFramework.Scenes;
using MinigameFramework.Utilities;
using StardopPoolMinigame.Constants;
using StardopPoolMinigame.Entities.UI;
using StardopPoolMinigame.Entities.UI.Backgrounds;
using StardopPoolMinigame.Entities.UI.Buttons;
using StardopPoolMinigame.MinigameFramework.Render.Filters;
using StardopPoolMinigame.StardropPool.Constants;

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
        protected override void AddEntities()
        {
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
                        difference: new Vector2(0, 0),
                        duration: 25,
                        delay: 20
                    ),
                    exitingTransition: FilterGenerator.CreateSlideTransition(
                        difference: new Vector2(
                            0,
                            GenericTextureConstants.Portrait.Sam.Default.Height / 2
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
                        difference: new Vector2(0, 0),
                        duration: 25,
                        delay: 20
                    ),
                    exitingTransition: FilterGenerator.CreateSlideTransition(
                        difference: new Vector2(
                            0,
                            GenericTextureConstants.Portrait.Sam.Default.Height / 2
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
                        difference: new Vector2(0, 0),
                        duration: 25,
                        delay: 20
                    ),
                    exitingTransition: FilterGenerator.CreateSlideTransition(
                        difference: new Vector2(
                            0,
                            GenericTextureConstants.Portrait.Sam.Default.Height / 2
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
                        difference: new Vector2(0, 0),
                        duration: 25,
                        delay: 20
                    ),
                    exitingTransition: FilterGenerator.CreateSlideTransition(
                        difference: new Vector2(
                            0,
                            GenericTextureConstants.Portrait.Sam.Default.Height / 2
                        ),
                        delay: 0,
                        randomDelay: true,
                        type: TransitionState.Exiting
                    ),
                    isSilhouette: true
                )
            );

            // Draw the buttons.
            _entities.Add(
                EntityKeys.MainMenu.Play,
                new BallButton(
                    text: Translations.GetTranslation(EntityKeys.MainMenu.Play),
                    anchor: new Vector2(
                        GenericTextures.GetMinigameScreenCenter().X + RenderConstants.Entities.BallButton.LeftOffset,
                        RenderConstants.MainMenuScene.Buttons.TopMargin
                    ),
                    number: 1,
                    layerDepth: 0.0040f,
                    origin: Origin.TopCenter,
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
                    ),
                    maxWidth: 80
                )
            );
            _entities.Add(
                EntityKeys.MainMenu.Multiplayer,
                new BallButton(
                    text: Translations.GetTranslation(EntityKeys.MainMenu.Multiplayer),
                    anchor: new Vector2(
                        GenericTextures.GetMinigameScreenCenter().X + RenderConstants.Entities.BallButton.LeftOffset,
                        RenderConstants.MainMenuScene.Buttons.TopMargin + RenderConstants.MainMenuScene.Buttons.Height
                    ),
                    number: 10,
                    layerDepth: 0.0040f,
                    origin: Origin.TopCenter,
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
                    ),
                    maxWidth: 80
                )
            );
            _entities.Add(
                EntityKeys.MainMenu.Gallery,
                new BallButton(
                    text: Translations.GetTranslation(EntityKeys.MainMenu.Gallery),
                    anchor: new Vector2(
                        GenericTextures.GetMinigameScreenCenter().X + RenderConstants.Entities.BallButton.LeftOffset,
                        RenderConstants.MainMenuScene.Buttons.TopMargin + RenderConstants.MainMenuScene.Buttons.Height * 2
                    ),
                    number: 3,
                    layerDepth: 0.0040f,
                    origin: Origin.TopCenter,
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
                    ),
                    maxWidth: 80
                )
            );
            _entities.Add(
                EntityKeys.MainMenu.Settings,
                new BallButton(
                    text: Translations.GetTranslation(EntityKeys.MainMenu.Settings),
                    anchor: new Vector2(
                        GenericTextures.GetMinigameScreenCenter().X + RenderConstants.Entities.BallButton.LeftOffset,
                        RenderConstants.MainMenuScene.Buttons.TopMargin + RenderConstants.MainMenuScene.Buttons.Height * 3
                    ),
                    number: 12,
                    layerDepth: 0.0040f,
                    origin: Origin.TopCenter,
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
                    ),
                    maxWidth: 80
                )
            );

            // Add main title.
            this._entities.Add(
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
        }
    }
}
