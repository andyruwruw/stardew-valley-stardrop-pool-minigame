using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Scenes
{
    class DialogueScene : IScene
    {
        private bool _hasNewScene;

        private IScene _newScene;

        public DialogueScene()
        {

        }

        public void Start()
        {
            Game1.changeMusicTrack("poppy");
        }

        public void ReceiveLeftClick(int x, int y, bool playSound = true)
        {
        }

        public bool HasNewScene()
        {
            return this._hasNewScene;
        }

        public IScene GetNewScene()
        {
            this._hasNewScene = false;
            return this._newScene;
        }
    }
}
