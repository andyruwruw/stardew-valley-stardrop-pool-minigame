namespace StardropPoolMinigame.Scenes
{
    /// <summary>
    /// Proxy for <see cref="IScene"/>, delaying its creation
    /// </summary>
    interface ISceneCreator
    {
        /// <summary>
        /// Instantiates and returns the <see cref="IScene"/>
        /// </summary>
        /// <returns>New <see cref="IScene"/></returns>
        IScene GetScene();
    }
}
