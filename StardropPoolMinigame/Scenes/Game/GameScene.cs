
using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Primitives;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Rules;
using StardropPoolMinigame.Scenes.States;
using StardropPoolMinigame.Structures;
using System;
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

        private IList<Ball> _cueBall;

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

            this._turn = new Turn(this._players, 0);

            this._fadeIn.SetTransitionState(TransitionState.Exiting, true);
        }

        public override string GetKey()
        {
            return "game-scene";
        }

        public override void Update()
        {
            this.UpdateQuadTree();
            this.UpdateCueBall();
            this.UpdateCue();
            base.Update();

            // IList<Ball> possiblyClickedBalls = this._balls.Query(new Primitives.Rectangle(new Vector2(Mouse.Position.X - GameConstants.Ball.RADIUS, Mouse.Position.Y - GameConstants.Ball.RADIUS), GameConstants.Ball.RADIUS * 2, GameConstants.Ball.RADIUS * 2));

            //foreach (Ball ball in possiblyClickedBalls)
            //{
            //    if (ball.IsHovered())
            //    {

            //        break;
            //    }
            //}
        }

        private void UpdateCueBall()
        {
            if (this._turn.GetTurnState() == TurnState.Idle)
            {
                if (this.GetCueBall().IsHovered())
                {
                    this.GetCueBall().SetIsHighlighted(true);
                } else
                {
                    this.GetCueBall().SetIsFlashing(true);
                }
            } else
            {
                this.GetCueBall().SetIsHighlighted(false);
                this.GetCueBall().SetIsFlashing(false);
            }
        }

        private void UpdateCue()
        {
            if (this._turn.GetTurnState() == TurnState.SelectingAngle
                || this._turn.GetTurnState() == TurnState.SelectingPower
                || this._turn.GetTurnState() == TurnState.BallsInMotion)
            {
                this._turn.GetCurrentPlayer().GetCue().Update(this._turn.GetTurnState(), this.GetCueBall());
            }
        }

        private void UpdateQuadTree()
        {
            if (this._turn.GetTurnState() == TurnState.BallsInMotion)
            {
                QuadTree quadTree = new QuadTree(
                    new Primitives.Rectangle(
                        Vector2.Zero,
                        RenderConstants.MinigameScreen.WIDTH,
                        RenderConstants.MinigameScreen.HEIGHT));

                IList<IEntity> balls = this._balls.Query();

                IDictionary<IEntity, IList<IEntity>> collisionsHandled = new Dictionary<IEntity, IList<IEntity>>();

                foreach (Ball ball in balls)
                {
                    IList<IEntity> neighbors = this._balls.Query(new Circle(ball.GetAnchor(), GameConstants.Ball.RADIUS * 2));
                    collisionsHandled.Add(ball, neighbors);

                    TableSegment tableSegment = this._table.GetTableSegmentFromPosition(ball.GetAnchor());

                    ball.Update(neighbors, tableSegment, collisionsHandled);
                    quadTree.Insert(ball);
                }

                this._balls = quadTree;
            }
        }

        public override void ReceiveLeftClick()
        {
            if (this._turn.GetTurnState() == TurnState.SelectingPocket && this._turn.IsMyTurn())
            {
                Sound.PlaySound(SoundConstants.Feedback.BOTTON_PRESS);
                if (this._turn.NeedsToPlaceCueBall())
                {
                    this._turn.SetTurnState(TurnState.PlacingBall);
                } else
                {
                    this._turn.SetTurnState(TurnState.Idle);
                }
            } else if (this._turn.GetTurnState() == TurnState.PlacingBall && this._turn.IsMyTurn())
            {
                Sound.PlaySound(SoundConstants.Feedback.BOTTON_PRESS);
                this._turn.SetTurnState(TurnState.Idle);
            } else if (this._turn.GetTurnState() == TurnState.Idle && this._turn.IsMyTurn())
            {
                if (this.GetCueBall().IsHovered())
                {
                    Sound.PlaySound(SoundConstants.Feedback.BOTTON_PRESS);
                    this._turn.SetTurnState(TurnState.SelectingAngle);
                }
            } else if (this._turn.GetTurnState() == TurnState.SelectingAngle && this._turn.IsMyTurn())
            {
                Sound.PlaySound(SoundConstants.Cue.LOCK_ANGLE);
                this._turn.SetTurnState(TurnState.SelectingPower);
            } else if (this._turn.GetTurnState() == TurnState.SelectingPower && this._turn.IsMyTurn())
            {
                Sound.PlaySound(SoundConstants.Cue.LOCK_POWER);
                this._turn.SetTurnState(TurnState.BallsInMotion);
            }
        }

        public override void ReceiveRightClick()
        {
            if (this._turn.GetTurnState() == TurnState.SelectingAngle && this._turn.IsMyTurn())
            {
                Sound.PlaySound(SoundConstants.Feedback.GAME_CANCEL);
                this._turn.SetTurnState(TurnState.Idle);
            } else if (this._turn.GetTurnState() == TurnState.SelectingPower && this._turn.IsMyTurn())
            {
                Sound.PlaySound(SoundConstants.Feedback.GAME_CANCEL);
                this._turn.SetTurnState(TurnState.SelectingAngle);
            }
        }

        public override IList<IEntity> GetEntities()
        {
            if (this._turn.GetTurnState() == TurnState.BallsInMotion
                || this._turn.GetTurnState() == TurnState.SelectingAngle
                || this._turn.GetTurnState() == TurnState.SelectingPower)
            {
                IList<IEntity> entities = new List<IEntity>();

                entities.Add(this._turn.GetCurrentPlayer().GetCue());
                entities.Add(this._balls);

                foreach (IEntity entity in this._entities)
                {
                    entities.Add(entity);
                }

                return entities;
            }
            return this._entities;
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

        private Ball GetCueBall()
        {
            if (this._rules.HasPlayerSpecificCueBalls())
            {
                return this._cueBall[this._turn.GetCurrentPlayerIndex()];
            }
            return this._cueBall[0];
        }

        /// <summary>
        /// Add entities that require constructor first
        /// </summary>
        private void AddDependentEntities()
        {
            // Game Entities
            this._entities.Add(this._table);

            Tuple<IList<Ball>, QuadTree> setup = this._rules.GenerateInitialBalls(
                this._table.GetTopLeft(),
                TableConstants.GetCueBallStart(this._table.GetTableType()),
                TableConstants.GetFootSpot(this._table.GetTableType()),
                TableConstants.GetRackOrientation(this._table.GetTableType()));

            this._cueBall = setup.Item1;
            this._balls = setup.Item2;

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
            this._cueBall = new List<Ball>();
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
