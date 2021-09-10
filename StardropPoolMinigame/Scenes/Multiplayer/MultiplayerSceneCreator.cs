namespace StardropPoolMinigame.Scenes.Multiplayer
{
    /// <inheritdoc cref="ISceneCreator"/>
    class MultiplayerSceneCreator : ISceneCreator
    {
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
