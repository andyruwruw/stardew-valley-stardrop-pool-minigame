namespace StardropPoolMinigame.Scenes.Multiplayer
{
    /// <inheritdoc cref="ISceneCreator"/>
    class MultiplayerSceneCreator : ISceneCreator
    {
        /// <summary>
        /// Instantiates <see cref="MultiplayerSceneCreator"/>.
        /// </summary>
        public MultiplayerSceneCreator()
        {
        }

        /// <inheritdoc cref="ISceneCreator.GetScene"/>
        public IScene GetScene()
        {
            return new MultiplayerScene();
        }
    }
}
