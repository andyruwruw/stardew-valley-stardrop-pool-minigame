namespace StardropPoolMinigame.Scenes
{
    class DialogScene: Scene
    {
        private IScene _nextScene;

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

        private void InicializeScript()
        {
            if (this._nextScene is GameScene
                && ((GameScene)this._nextScene).GetPlayers()[1].IsComputer())
            {

            } else
            {
                this._newScene = this._nextScene;
            }

            
        }
    }
}
