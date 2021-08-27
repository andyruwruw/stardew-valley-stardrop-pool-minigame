using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Rules;
using StardropPoolMinigame.Scenes.States;
using StardropPoolMinigame.Structures;
using System.Collections;
using System.Collections.Generic;

namespace StardropPoolMinigame.Scenes
{
    class GameScene : Scene
    {
        private IList<IPlayer> _players;

        private IRules _rules;

        private Table _table;

        private QuadTree _balls;

        private IList _ballList;

        private IList<Ball> _pocketedBalls;

        private Turn _turn;

        private IList<GameEvent> _events;

        private bool _isFinished;

        public GameScene(
            IPlayer player1,
            IPlayer player2,
            IRules rules = null) : base()
        {
            this.InicializePlayers(player1, player2);
            this._rules = rules;

            
            this._pocketedBalls = new List<Ball>();
            this._events = new List<GameEvent>();
            this._isFinished = false;

            this._turn = new Turn();
        }

        public override string GetKey()
        {
            return "game-scene";
        }

        public bool IsGameFinished()
        {
            return this._isFinished;
        }

        public Turn GetTurn()
        {
            return this._turn;
        }

        protected override void AddEntities()
        {
            // Background
            this._entities.Add(new FloorTiles(null, null));

            // Game Entities
            this._table = this._rules.GenerateTable();
            this._entities.Add(this._table);

            this._balls = this._rules.GenerateInitialBalls();
            foreach (Ball ball in this._balls.Query())
            {
                this._ballList.Add(ball);
                this._entities.Add(ball);
            }
        }

        private void InicializePlayers(IPlayer player1, IPlayer player2)
        {
            this._players = new List<IPlayer>();
            this._players.Add(player1);
            this._players.Add(player2);
        }

        private void InicializeLists()
        {
            this._ballList = new List<Ball>();
            this._pocketedBalls = new List<Ball>();
        }
    }
}
