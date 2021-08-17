using StardropPoolMinigame.Render.Scenes;
using StardropPoolMinigame.Scenes.States;

namespace StardropPoolMinigame.Scenes
{
    class MenuScene : Scene
    {
        private MenuPage _page;

        public MenuScene() : base()
        {
            this.SetRenderer(new MenuSceneRenderer());
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
    }
}
