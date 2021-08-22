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
        protected IScene _newScene;

        public Scene()
        {
            this._newScene = null;
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
            return null;
        }

        public bool HasNewScene()
        {
            return this._newScene != null;
        }

        public IScene GetNewScene()
        {
            return this._newScene;
        }

        public virtual string GetKey()
        {
            return "unnamed-scene";
        }
    }
}
