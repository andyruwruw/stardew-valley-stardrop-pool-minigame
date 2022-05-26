namespace StardropPoolMinigame.Scenes.CharacterSelect
{
    /// <inheritdoc cref="ISceneCreator"/>
    internal class CharacterSelectSceneCreator : ISceneCreator
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