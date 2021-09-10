namespace StardropPoolMinigame.Scenes.Gallery
{
    /// <inheritdoc cref="ISceneCreator"/>
    class GallerySceneCreator : ISceneCreator
    {
        public GallerySceneCreator()
        {
        }

        /// <inheritdoc cref="ISceneCreator.GetScene"/>
        public IScene GetScene()
        {
            return new GalleryScene();
        }
    }
}
