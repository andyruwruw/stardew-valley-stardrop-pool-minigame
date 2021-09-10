namespace StardropPoolMinigame.Scenes.CharacterSelect
{
    /// <inheritdoc cref="ISceneCreator"/>
    class CharacterSelectSceneCreator : ISceneCreator
    {
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
