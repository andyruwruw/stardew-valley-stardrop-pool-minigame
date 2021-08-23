using StardropPoolMinigame.Render.Scenes;

namespace StardropPoolMinigame.Scenes
{
    class CharacterSelectScene : Scene
    {
        public CharacterSelectScene() : base()
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
            return new CharacterSelectSceneRenderer(this);
        }

        public override string GetKey()
        {
            return "charater-select-scene";
        }
    }
}
