using StardropPoolMinigame.Render.Scenes;

namespace StardropPoolMinigame.Scenes
{
    /// <summary>
    /// Depicts score and summary of finished <see cref="GameScene"/>
    /// </summary>
    class SummaryScene: Scene
    {
        /// <summary>
        /// Previous <see cref="GameScene"/> being summarized
        /// </summary>
        private IScene _gameScene;

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
