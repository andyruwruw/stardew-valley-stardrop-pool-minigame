namespace StardropPoolMinigame.Scenes
{
    /// <summary>
    /// Depicts score and summary of finished <see cref="GameScene"/>
    /// </summary>
    internal class SummaryScene : Scene
    {
        /// <summary>
        /// Previous <see cref="GameScene"/> being summarized.
        /// </summary>
        private IScene _gameScene;

        /// <summary>
        /// Instantiates <see cref="SummaryScene"/>.
        /// </summary>
        /// <param name="gameScene">Previous <see cref="GameScene"/> being summarized</param>
        public SummaryScene(GameScene gameScene) : base()
        {
            this._gameScene = gameScene;
        }

        /// <inheritdoc cref="IScene.GetKey"/>
        public override string GetKey()
        {
            return "summary-scene";
        }

        /// <inheritdoc cref="Scene.AddEntities"/>
        protected override void AddEntities()
        {
        }
    }
}