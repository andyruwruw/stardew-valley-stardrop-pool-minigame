using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Scenes
{
    abstract class Scene : IScene
    {
        protected bool _hasNewScene;

        protected IScene _newScene;

        public Scene()
        {
            this._newScene = null;
        }

        public IScene GetNewScene()
        {
            return this._newScene;
        }

        public bool HasNewScene()
        {
            return this._hasNewScene;
        }

        public abstract void ReceiveLeftClick(int x, int y, bool playSound = true);

        public abstract void Start();
    }
}
