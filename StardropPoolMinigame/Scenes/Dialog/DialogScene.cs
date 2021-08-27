namespace StardropPoolMinigame.Scenes
{
    class DialogScene: Scene
    {
        IScene _nextScene;

        public DialogScene(IScene nextScene): base()
        {
            this._nextScene = nextScene;
        }

        public override string GetKey()
        {
            return "dialog-scene";
        }

        protected override void AddEntities()
        {
        }
    }
}
