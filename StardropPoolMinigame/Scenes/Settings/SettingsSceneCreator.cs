namespace StardropPoolMinigame.Scenes.Settings
{
    /// <inheritdoc cref="ISceneCreator"/>
    class SettingsSceneCreator : ISceneCreator
    {
        public SettingsSceneCreator()
        {
        }

        /// <inheritdoc cref="ISceneCreator.GetScene"/>
        public IScene GetScene()
        {
            return new SettingsScene();
        }
    }
}
