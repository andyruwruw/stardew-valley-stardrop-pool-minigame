using StardropPoolMinigame.Render.Scenes;

namespace StardropPoolMinigame.Scenes
{
    class SettingsScene : Scene
    {
        public SettingsScene() : base()
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
            return new SettingsSceneRenderer(this);
        }

        public override string GetKey()
        {
            return "menu-scene";
        }
    }
}
