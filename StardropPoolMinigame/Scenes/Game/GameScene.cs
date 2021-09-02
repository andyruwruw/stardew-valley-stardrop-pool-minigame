
using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Render;
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

        private PocketedBalls _player1PocketedBalls;

        private PocketedBalls _player2PocketedBalls;

        private Portrait _opponentPortrait;

        private Turn _turn;

        private IList<GameEvent> _events;

        private bool _isFinished;

        public GameScene(
            IPlayer player1,
            IPlayer player2,
            IRules rules = null, 
            Table table = null) : base()
        {
            this.Inicialize(rules, table, player1, player2);

            this.AddDependentEntities();

            this._fadeIn.SetTransitionState(TransitionState.Exiting, true);

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

        public IList<IPlayer> GetPlayers()
        {
            return this._players;
        }

        public override IList<IEntity> GetEntities()
        {
            return this._entities;
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

            this._player1PocketedBalls = new PocketedBalls(
                Origin.TopLeft,
                new Vector2((RenderConstants.MinigameScreen.WIDTH / 2) - ((TableConstants.Classic.LAYOUT[0].Count * Textures.Table.Edge.Back.NORTH.Width) / 2), 0),
                LayerDepthConstants.Game.POCKETED_BALLS,
                TransitionConstants.Game.PocketedBalls.Entering(),
                null);
            this._entities.Add(this._player1PocketedBalls);

            this._player2PocketedBalls = new PocketedBalls(
                Origin.TopRight,
                new Vector2((RenderConstants.MinigameScreen.WIDTH / 2) + ((TableConstants.Classic.LAYOUT[0].Count * Textures.Table.Edge.Back.NORTH.Width) / 2), 0),
                LayerDepthConstants.Game.POCKETED_BALLS,
                TransitionConstants.Game.PocketedBalls.Entering(),
                null);
            this._entities.Add(this._player2PocketedBalls);
        }

        private void AddDependentEntities()
        {
            // Game Entities
            this._entities.Add(this._table);

            this._balls = this._rules.GenerateInitialBalls(
                this._table.GetTopLeft(),
                TableConstants.GetCueBallStart(this._table.GetTableType()),
                TableConstants.GetFootSpot(this._table.GetTableType()),
                TableConstants.GetRackOrientation(this._table.GetTableType()));

            foreach (Ball ball in this._balls.Query())
            {
                this._ballList.Add(ball);
                this._entities.Add(ball);
            }

            if (this._players[1].IsComputer())
            {
                this._opponentPortrait = new Portrait(
                    Origin.TopLeft,
                    new Vector2(RenderConstants.MinigameScreen.WIDTH - Textures.Portrait.Sam.DEFAULT.Width, RenderConstants.MinigameScreen.HEIGHT - Textures.Portrait.Sam.DEFAULT.Height),
                    LayerDepthConstants.Game.PORTRAIT,
                    TransitionConstants.Game.Portrait.Entering(),
                    null,
                    ((ComputerOpponent)this._players[1]).GetOpponentType(),
                    PortraitEmotion.Default);
                this._entities.Add(this._opponentPortrait);
            }
        }

        /// <summary>
        /// Sets default values
        /// </summary>
        /// <param name="rules">Provided <see cref="RuleSet"/> or null for default</param>
        /// <param name="table">Provided <see cref="Table"/> or null for default</param>
        private void Inicialize(IRules rules, Table table, IPlayer player1, IPlayer player2)
        {
            this._ballList = new List<Ball>();
            this._opponentPortrait = null;

            this._rules = rules == null ? RuleSet.GetDefaultRules() : rules;
            this._table = table == null ? Table.GetDefaultTable() : table;

            this._players = new List<IPlayer>();
            this._players.Add(player1);
            this._players.Add(player2);

            this._events = new List<GameEvent>();
            this._isFinished = false;
        }
    }
}
