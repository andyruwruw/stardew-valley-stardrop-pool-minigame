namespace StardropPoolMinigame.Scenes.MainMenu
{
    /// <inheritdoc cref="ISceneCreator"/>
    class MainMenuSceneCreator : ISceneCreator
    {
        /// <summary>
        /// Instantiates <see cref="MainMenuSceneCreator"/>.
        /// </summary>
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
