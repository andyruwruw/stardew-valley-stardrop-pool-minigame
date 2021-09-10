namespace StardropPoolMinigame.Scenes.Dialog
{
    /// <inheritdoc cref="ISceneCreator"/>
    class DialogSceneCreator : ISceneCreator
    {
        /// <summary>
        /// Stored parameter for <see cref="DialogScene"/> creation
        /// </summary>
        private ISceneCreator _sceneCreator;

        public DialogSceneCreator(ISceneCreator sceneCreator)
        {
            this._sceneCreator = sceneCreator;
        }

        /// <inheritdoc cref="ISceneCreator.GetScene"/>
        public IScene GetScene()
        {
            return new DialogScene(this._sceneCreator);
        }
    }
}
