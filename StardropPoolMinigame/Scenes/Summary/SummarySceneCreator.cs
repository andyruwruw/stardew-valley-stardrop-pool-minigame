namespace StardropPoolMinigame.Scenes
{
    /// <inheritdoc cref="ISceneCreator"/>
    class SummarySceneCreator : ISceneCreator
    {
        /// <summary>
        /// Stored parameter for <see cref="DialogScene"/> creation
        /// </summary>
        private GameScene _gameScene;

        public SummarySceneCreator(GameScene gameScene)
        {
            this._gameScene = gameScene;
        }

        /// <inheritdoc cref="ISceneCreator.GetScene"/>
        public IScene GetScene()
        {
            return new SummaryScene(this._gameScene);
        }
    }
}
