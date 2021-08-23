using StardropPoolMinigame.Render.Scenes;

namespace StardropPoolMinigame.Scenes
{
    class MultiplayerScene : Scene
    {
        public MultiplayerScene() : base()
        {
        }

        public override void Update()
        {
            this.UpdateEntities();
        }

        public override void ReceiveLeftClick()
        {
        }

        public override void ReceiveRightClick()
        {
        }

        public override ISceneRenderer GetRenderer()
        {
            return new MultiplayerSceneRenderer(this);
        }

        public override string GetKey()
        {
            return "menu-scene";
        }
    }
}
