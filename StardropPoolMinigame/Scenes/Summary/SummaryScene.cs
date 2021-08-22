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

        public override void Update()
        {

        }

        public override void ReceiveLeftClick()
        {

        }

        public override void ReceiveRightClick()
        {

        }

        public override ISceneRenderer GetRenderer()
        {
            return new SummarySceneRenderer(this);
        }

        public override string GetKey()
        {
            return "summary-scene";
        }
    }
}
