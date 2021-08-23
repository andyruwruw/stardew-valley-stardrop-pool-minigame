using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Render.Scenes;
using StardropPoolMinigame.Rules;
using StardropPoolMinigame.Scenes.States;
using StardropPoolMinigame.Structures;
using System.Collections.Generic;

namespace StardropPoolMinigame.Scenes
{
    class GameScene : Scene
    {
        private IRules _rules;

        private IList<IPlayer> _players;

        private Table _table;

        private QuadTree _balls;

        private IList<Ball> _pocketedBalls;

        private Turn _turn;

        private IList<GameEvent> _events;

        private bool _isFinished;

        public GameScene(IPlayer player1, IPlayer player2, IRules rules = null) : base()
        {
            this._players = new List<IPlayer>();
            this._players.Add(player1);
            this._players.Add(player2);

            this._rules = rules == null ? new EightBall() : rules;
            this._table = this._rules.GenerateTable();
            this._balls = this._rules.GenerateInitialBalls();
            this._pocketedBalls = new List<Ball>();
            this._events = new List<GameEvent>();
            this._isFinished = false;

            this._turn = new Turn();
        }

        public override void Update()
        {

        }

        public override void ReceiveLeftClick()
        {

        }

        public override void ReceiveRightClick()
        {

        }
        public bool IsGameFinished()
        {
            return this._isFinished;
        }

        public Turn GetTurn()
        {
            return this._turn;
        }

        public override ISceneRenderer GetRenderer()
        {
            return new GameSceneRenderer(this);
        }

        private void PlayMusic()
        {

        }
    }
}
