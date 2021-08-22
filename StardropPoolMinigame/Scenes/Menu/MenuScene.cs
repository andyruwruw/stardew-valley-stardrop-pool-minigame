using StardropPoolMinigame.Behaviors.Attributes;
using StardropPoolMinigame.Render.Scenes;
using StardropPoolMinigame.Scenes.States;
using System.Collections.Generic;

namespace StardropPoolMinigame.Scenes
{
    class MenuScene : Scene
    {
        private MenuPage _page;

        public MenuScene() : base()
        {
            this._page = new MainPage();
        }

        public override void Update()
        {
            this._page.Update();
        }

        public override void ReceiveLeftClick()
        {

        }

        public override void ReceiveRightClick()
        {

        }

        public MenuPage GetMenuPage()
        {
            return this._page;
        }

        public override ISceneRenderer GetRenderer()
        {
            return new MenuSceneRenderer(this);
        }

        public override string GetKey()
        {
            return "menu-scene";
        }
    }
}
