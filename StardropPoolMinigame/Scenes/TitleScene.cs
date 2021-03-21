using StardewValley;
using StardropPoolMinigame.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Scenes
{
    class TitleScene : IScene
    {
        public enum TitleState
        {
            Main,
            Waiting,
            OpponentSelect,
        }

        private TitleState _state;

        private bool _hasNewScene;

        private IScene _newScene;

        public TitleScene()
        {
            this._state = TitleState.Main;
            this._newScene = null;
        }

        public void Start()
        {
            Console.Info("Starting");
            Game1.changeMusicTrack("poppy", track_interruptable: false, Game1.MusicContext.MiniGame);
        }

        public void ReceiveLeftClick(int x, int y, bool playSound = true)
        {
            this._newScene = new GameScene(new EightBall());
            this._hasNewScene = true;
        }

        public TitleState GetState()
        {
            return this._state;
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
