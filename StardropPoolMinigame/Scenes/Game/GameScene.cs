using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Rules;
using StardropPoolMinigame.Structures;
using System.Collections.Generic;

namespace StardropPoolMinigame.Scenes
{
    class GameScene: IScene
    {
        private IRules _rules;

        private IList<IPlayer> _players;

        private ITable _table;

        private QuadTree _balls;

        private IList<IBall> _pocketedBalls;

        private TurnState _turnState;

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
            this._pocketedBalls = new List<IBall>();

            this._turnState = TurnState.Start;
            this._events = new List<GameEvent>();

            this._isFinished = false;
        }

        public void Update()
        {

        }

        public void ReceiveLeftClick()
        {

        }

        public void ReceiveRightClick()
        {

        }

        public bool HasNewScene()
        {
            return true;
        }

        public IScene GetNewScene()
        {
            return new MenuScene();
        }

        public bool IsGameFinished()
        {
            return this._isFinished;
        }

        public TurnState GetTurnState()
        {
            return this._turnState;
        }

        private void PlayMusic()
        {

        }
    }
}
