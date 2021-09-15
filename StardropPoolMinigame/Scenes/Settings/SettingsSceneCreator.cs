namespace StardropPoolMinigame.Scenes.Settings
{
    /// <inheritdoc cref="ISceneCreator"/>
    internal class SettingsSceneCreator : ISceneCreator
    {
        /// <summary>
        /// Instantiates <see cref="SettingsSceneCreator"/>.
        /// </summary>
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