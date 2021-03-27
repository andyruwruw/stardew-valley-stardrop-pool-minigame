using StardewValley;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Scenes
{
    class TitleScene : Scene
    {
        public enum TitleState
        {
            Main,
            Waiting,
            OpponentSelect,
        }

        private TitleState _state;

        private IPlayer _opponent;

        public TitleScene() : base()
        {
            this._state = TitleState.Main;
        }

        public override void Start()
        {
            Game1.changeMusicTrack("movieTheater", track_interruptable: false, Game1.MusicContext.MiniGame);
        }

        public override void Update()
        {

        }

        public override void ReceiveLeftClick(int x, int y, bool playSound = true)
        {
            IPlayer me = new Player(Game1.player.Name, true, false, 0, "movieTheater");

            this._opponent = new Sebastian();

            this._newScene = new GameScene(me, _opponent, new EightBall());
            this._hasNewScene = true;
        }

        public TitleState GetState()
        {
            return this._state;
        }
    }
}
