using StardewValley;
using StardropPoolMinigame.Objects;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Rules;
using StardropPoolMinigame.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Scenes
{
    class GameScene : Scene
    {
        private IRules _rules;

        private ITable _table;

        private QuadTree _balls;

        private IList<IPlayer> _players;

        private int _turn;

        private TurnState _turnState;

        public GameScene(IPlayer player1, IPlayer player2, IRules rules = null) : base()
        {
            if (rules == null)
            {
                this._rules = new EightBall();
            } else
            {
                this._rules = rules;
            }

            this._table = this._rules.GenerateTable();
            this._balls = this._rules.GenerateInitialBalls();

            this._players = new List<IPlayer>();
            this._players.Add(player1);
            this._players.Add(player2);

            if (player2.IsComputer())
            {
                this._turn = 0;
            } else
            {
                Random rnd = new Random();
                this._turn = rnd.Next(0, 2);
            }

            this._turnState = TurnState.Start;
        }

        public override void Start()
        {
            Game1.changeMusicTrack(this._players[1].GetMusicId(), track_interruptable: false, Game1.MusicContext.MiniGame);
        }

        public override void ReceiveLeftClick(int x, int y, bool playSound = true)
        {
        }

        public IList<IBall> GetBalls()
        {
            return this._balls.Query();
        }

        public ITable GetTable()
        {
            return this._table;
        }
    }
}
