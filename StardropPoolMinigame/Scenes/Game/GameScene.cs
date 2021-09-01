
using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Primitives;
using StardropPoolMinigame.Rules;
using StardropPoolMinigame.Scenes.States;
using StardropPoolMinigame.Structures;
using System.Collections;
using System.Collections.Generic;

namespace StardropPoolMinigame.Scenes
{
    class GameScene : Scene
    {
        private Solid _fadeIn;

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
            IRules rules = null, 
            Table table = null) : base()
        {
            this.InicializeLists();
            this.InicializePlayers(player1, player2);
            this._rules = rules == null ? RuleSet.GetDefaultRules() : rules;
            this._table = table == null ? Table.GetDefaultTable() : table;

            this.AddDependentEntities();

            this._pocketedBalls = new List<Ball>();
            this._events = new List<GameEvent>();
            this._isFinished = false;

            this._turn = new Turn();
            this._fadeIn.SetTransitionState(TransitionState.Exiting, true);
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

        public IList<IPlayer> GetPlayers()
        {
            return this._players;
        }

        protected override void AddEntities()
        {
            // Background
            this._entities.Add(new FloorTiles(null, null));

            this._fadeIn = new Solid(
                new Primitives.Rectangle(new Vector2(0, 0), RenderConstants.MinigameScreen.WIDTH, RenderConstants.MinigameScreen.HEIGHT),
                LayerDepthConstants.Game.FADE_IN,
                null,
                TransitionConstants.Game.FadeIn.Exiting(),
                Color.Black);
            this._entities.Add(this._fadeIn);
        }

        private void AddDependentEntities()
        {
            // Game Entities
            this._entities.Add(this._table);

            this._balls = this._rules.GenerateInitialBalls(
                TableConstants.GetFootSpot(this._table.GetTableType()),
                TableConstants.GetRackOrientation(this._table.GetTableType()));

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
