namespace StardropPoolMinigame.Scenes.MainMenu
{
    /// <inheritdoc cref="ISceneCreator"/>
    class MainMenuSceneCreator : ISceneCreator
    {
        public MainMenuSceneCreator()
        {
        }

        /// <inheritdoc cref="ISceneCreator.GetScene"/>
        public IScene GetScene()
        {
            return new MainMenuScene();
        }
    }
}
