namespace StardropPoolMinigame.Scenes.States
{
    class MenuPage: IMenuPage
    {
        private MenuPage _newPage;

        public MenuPage()
        {
            this._newPage = null;
        }

        public void Update()
        {

        }

        public bool HasNewPage()
        {
            return this._newPage != null;
        }

        public MenuPage GetNewPage()
        {
            return this._newPage;
        }

        public virtual void ReceiveLeftClick()
        {

        }

        public virtual void ReceiveRightClick()
        {

        }
    }
}
