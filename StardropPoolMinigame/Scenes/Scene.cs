using StardropPoolMinigame.Render.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Scenes
{
    class Scene: IScene
    {
        private IScene _newScene;

        private ISceneRenderer _renderer;

        public Scene()
        {
            this._newScene = null;
        }

        public void TransitionEnter()
        {

        }

        public void TransitionExit()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void ReceiveLeftClick()
        {

        }

        public virtual void ReceiveRightClick()
        {

        }

        public virtual ISceneRenderer GetRenderer()
        {
            return this._renderer;
        }

        public bool HasNewScene()
        {
            return this._newScene != null;
        }

        public IScene GetNewScene()
        {
            return this._newScene;
        }

        protected void SetRenderer(ISceneRenderer renderer)
        {
            this._renderer = renderer;
        }
    }
}
