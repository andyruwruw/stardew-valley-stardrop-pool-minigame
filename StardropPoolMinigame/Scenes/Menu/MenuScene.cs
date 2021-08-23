using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Scenes;

namespace StardropPoolMinigame.Scenes
{
    class MenuScene : Scene
    {
        public MenuScene() : base()
        {
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
        }

        public override void ReceiveRightClick()
        {
        }

        public override ISceneRenderer GetRenderer()
        {
            return new MenuSceneRenderer(this);
        }

        public override string GetKey()
        {
            return "menu-scene";
        }

        private void AddBackground()
        {
            this._entities.Add(new BarShelves(Origin.TopLeft, new Vector2(0, 0)));
        }

        private void AddTitle()
        {
            this._entities.Add(new GameTitle(Origin.TopCenter, new Vector2(0, RenderConstants.MENU_SCENE_GAME_TITLE_TOP_MARGIN)));
        }

        private void AddButtons()
        {
            float spaceHeight = RenderConstants.MINIGAME_SCREEN_HEIGHT - Textures.BACKGROUND_BAR_SHELVES_BOUNDS.Height;
            float buttonHeight = Textures.BUTTON_TEXT_PLAY_BOUNDS.Height;
            float margin = (spaceHeight - (buttonHeight * 4)) / 2;
            float baseY = margin + Textures.BACKGROUND_BAR_SHELVES_BOUNDS.Height;

            this._entities.Add(new BallButton(Origin.TopCenter, new Vector2(RenderConstants.MINIGAME_SCREEN_WIDTH / 2, baseY), Textures.BUTTON_TEXT_PLAY_BOUNDS, 1));
            this._entities.Add(new BallButton(Origin.TopCenter, new Vector2(RenderConstants.MINIGAME_SCREEN_WIDTH / 2, baseY + buttonHeight), Textures.BUTTON_TEXT_MULTIPLAYER_BOUNDS, 1));
            this._entities.Add(new BallButton(Origin.TopCenter, new Vector2(RenderConstants.MINIGAME_SCREEN_WIDTH / 2, baseY + (buttonHeight * 2)), Textures.BUTTON_TEXT_GALLERY_BOUNDS, 1));
            this._entities.Add(new BallButton(Origin.TopCenter, new Vector2(RenderConstants.MINIGAME_SCREEN_WIDTH / 2, baseY + (buttonHeight * 3)), Textures.BUTTON_TEXT_SETTINGS_BOUNDS, 1));
        }
    }
}
