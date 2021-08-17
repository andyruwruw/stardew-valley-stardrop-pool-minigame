namespace StardropPoolMinigame.Scenes.States
{
    interface IMenuPage
    {
        void Update();

        bool HasNewPage();

        MenuPage GetNewPage();

        void ReceiveLeftClick();

        void ReceiveRightClick();
    }
}
