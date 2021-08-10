using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;

namespace StardropPoolMinigame.Scenes
{
    class MenuScene : IScene
    {
        private MenuPage _page;

        public MenuScene()
        {
            this._page = MenuPage.Main;
        }

        public void Update()
        {
            Logger.Info("MENU UPDATE");
        }

        public void ReceiveLeftClick()
        {

        }

        public void ReceiveRightClick()
        {

        }

        public bool HasNewScene()
        {
            return false;
        }

        public IScene GetNewScene()
        {
            return new DialogScene();
        }

        public MenuPage GetMenuPage()
        {
            return this._page;
        }
    }
}
