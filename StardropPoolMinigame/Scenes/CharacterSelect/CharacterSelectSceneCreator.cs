namespace StardropPoolMinigame.Scenes.CharacterSelect
{
    /// <inheritdoc cref="ISceneCreator"/>
    class CharacterSelectSceneCreator : ISceneCreator
    {
        /// <summary>
        /// Instantiates <see cref="CharacterSelectSceneCreator"/>.
        /// </summary>
        public CharacterSelectSceneCreator()
        {
        }

        /// <inheritdoc cref="ISceneCreator.GetScene"/>
        public IScene GetScene()
        {
            return new CharacterSelectScene();
        }
    }
}
