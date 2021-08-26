using StardropPoolMinigame.Render.Scenes;

namespace StardropPoolMinigame.Scenes
{
    class SummaryScene: Scene
    {
        private IScene _gameScene;

        public SummaryScene(GameScene gameScene) : base()
        {
            this._gameScene = gameScene;
        }

        public override string GetKey()
        {
            return "summary-scene";
        }

        protected override void AddEntities()
        {
        }
    }
}
