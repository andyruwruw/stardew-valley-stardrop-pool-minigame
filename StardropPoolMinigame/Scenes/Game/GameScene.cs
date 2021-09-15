using Microsoft.Xna.Framework;
using StardropPoolMinigame.Behaviors.Physics;
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
using StardropPoolMinigame.Utilities;
using System;
using System.Collections.Generic;

namespace StardropPoolMinigame.Scenes
{
    internal class GameScene : Scene
    {
        /// <summary>
        /// References to cue <see cref="Ball"/>.
        /// </summary>
        private IList<Ball> _cueBalls;

        /// <summary>
        /// Whether the game is finished.
        /// </summary>
        private bool _isFinished;

        /// <summary>
        /// <see cref="IPhysics"/> system of rules applied to balls.
        /// </summary>
        private IPhysics _physics;

        /// <summary>
        /// <see cref="IList"/> of <see cref="IPlayer"/>.
        /// </summary>
        private IList<IPlayer> _players;

        /// <summary>
        /// <see cref="IRules"/> for current game.
        /// </summary>
        private IRules _rules;

        /// <summary>
        /// Current <see cref="Turn"/> state.
        /// </summary>
        private Turn _turn;

        /// <summary>
        /// Instantiates <see cref="GameScene"/>.
        /// </summary>
        /// <param name="player1">First <see cref="IPlayer"/></param>
        /// <param name="player2">Second <see cref="IPlayer"/></param>
        /// <param name="rules"><see cref="IRules"/> for game</param>
        /// <param name="table"><see cref="Table"/> for game</param>
        public GameScene(
            IPlayer player1,
            IPlayer player2,
            IRules rules = null,
            Table table = null,
            IPhysics physics = null) : base()
        {
            this.Inicialize(
                player1,
                player2,
                rules,
                table,
                physics);
            this.AddDependentEntities();

            this._turn = new Turn(this._players, 0);
            this._entities[StringConstants.Entities.Game.FADE_IN].SetTransitionState(TransitionState.Exiting, true);
        }

        /// <summary>
        /// Retrieves current cue <see cref="Ball"/>.
        /// </summary>
        /// <returns>Current cue <see cref="Ball"/></returns>
        public Ball GetCueBall()
        {
            if (this._rules.HasPlayerSpecificCueBalls())
            {
                return this._cueBalls[this._turn.GetCurrentPlayerIndex()];
            }
            return this._cueBalls[0];
        }

        /// <inheritdoc cref="Scene.GetEntities"/>
        public override IList<IEntity> GetEntities()
        {
            if (this._turn.GetTurnState() == TurnState.BallsInMotion
                || this._turn.GetTurnState() == TurnState.SelectingAngle
                || this._turn.GetTurnState() == TurnState.SelectingPower)
            {
                IList<IEntity> entities = new List<IEntity>();

                entities.Add(this._turn.GetCurrentPlayer().GetCue());

                foreach (IEntity entity in this._entities.Values)
                {
                    entities.Add(entity);
                }

                return entities;
            }
            return new List<IEntity>(this._entities.Values);
        }

        /// <inheritdoc cref="Scene.GetKey"/>
        public override string GetKey()
        {
            return "game-scene";
        }

        /// <summary>
        /// Retrieves <see cref="PocketedBalls"/> for <see cref="IPlayer"/> 1.
        /// </summary>
        /// <returns><see cref="PocketedBalls"/> for <see cref="IPlayer"/> 1</returns>
        public PocketedBalls GetPlayer1PocketedBalls()
        {
            return (PocketedBalls)this._entities[StringConstants.Entities.Game.POCKETED_BALLS_PLAYER1];
        }

        /// <summary>
        /// Retrieves <see cref="PocketedBalls"/> for <see cref="IPlayer"/> 2.
        /// </summary>
        /// <returns><see cref="PocketedBalls"/> for <see cref="IPlayer"/> 2</returns>
        public PocketedBalls GetPlayer2PocketedBalls()
        {
            return (PocketedBalls)this._entities[StringConstants.Entities.Game.POCKETED_BALLS_PLAYER2];
        }

        /// <summary>
        /// Retrieves <see cref="IList"/> of <see cref="IPlayer"/>.
        /// </summary>
        /// <returns><see cref="IList"/> of <see cref="IPlayer"/></returns>
        public IList<IPlayer> GetPlayers()
        {
            return this._players;
        }

        /// <summary>
        /// Retrieves <see cref="PocketedBalls"/> for <see cref="IPlayer"/> by index.
        /// </summary>
        /// <returns><see cref="PocketedBalls"/> for <see cref="IPlayer"/> by index</returns>
        public PocketedBalls GetPocketedBalls(int player)
        {
            switch (player)
            {
                case 1:
                    return this.GetPlayer2PocketedBalls();

                default:
                    return this.GetPlayer1PocketedBalls();
            }
        }

        /// <summary>
        /// Retrieves <see cref="Portrait"/> for <see cref="ComputerOpponent"/>.
        /// </summary>
        /// <returns><see cref="Portrait"/> for <see cref="ComputerOpponent"/></returns>
        public Portrait GetPortrait()
        {
            return (Portrait)this._entities[StringConstants.Entities.Game.PORTRAIT];
        }

        /// <summary>
        /// Retrieves reference to <see cref="QuadTree{T}"/> of <see cref="Ball"/>.
        /// </summary>
        /// <returns>Reference to <see cref="QuadTree{T}"/> of <see cref="Ball"/></returns>
        public QuadTree<EntityPhysics> GetQuadTree()
        {
            return (QuadTree<EntityPhysics>)this._entities[StringConstants.Entities.Game.QUAD_TREE];
        }

        /// <summary>
        /// Retrieves reference to <see cref="Table"/>.
        /// </summary>
        /// <returns>Teference to <see cref="Table"/></returns>
        public Table GetTable()
        {
            return (Table)this._entities[StringConstants.Entities.Game.TABLE];
        }

        /// <summary>
        /// Retrieves current <see cref="Turn"/>.
        /// </summary>
        /// <returns>Current <see cref="Turn"/></returns>
        public Turn GetTurn()
        {
            return this._turn;
        }

        /// <summary>
        /// Whether the game is finished.
        /// </summary>
        /// <returns>Whether the game is finished</returns>
        public bool IsGameFinished()
        {
            return this._isFinished;
        }

        /// <inheritdoc cref="Scene.ReceiveLeftClick"/>
        public override void ReceiveLeftClick()
        {
            if (this._turn.GetTurnState() == TurnState.SelectingPocket && this._turn.IsMyTurn())
            {
                Sound.PlaySound(SoundConstants.Feedback.BOTTON_PRESS);
                if (this._turn.NeedsToPlaceCueBall())
                {
                    this._turn.SetTurnState(TurnState.PlacingBall);
                }
                else
                {
                    this._turn.SetTurnState(TurnState.Idle);
                }
            }
            else if (this._turn.GetTurnState() == TurnState.PlacingBall && this._turn.IsMyTurn())
            {
                Sound.PlaySound(SoundConstants.Feedback.BOTTON_PRESS);
                this._turn.SetTurnState(TurnState.Idle);
            }
            else if (this._turn.GetTurnState() == TurnState.Idle && this._turn.IsMyTurn())
            {
                if (this.GetCueBall().IsHovered())
                {
                    Sound.PlaySound(SoundConstants.Feedback.BOTTON_PRESS);
                    this._turn.SetTurnState(TurnState.SelectingAngle);
                }
            }
            else if (this._turn.GetTurnState() == TurnState.SelectingAngle && this._turn.IsMyTurn())
            {
                Sound.PlaySound(SoundConstants.Cue.LOCK_ANGLE);
                this._turn.SetTurnState(TurnState.SelectingPower);
            }
            else if (this._turn.GetTurnState() == TurnState.SelectingPower && this._turn.IsMyTurn())
            {
                Sound.PlaySound(SoundConstants.Cue.LOCK_POWER);
                this._turn.SetTurnState(TurnState.BallsInMotion);
            }
        }

        /// <inheritdoc cref="Scene.ReceiveRightClick"/>
        public override void ReceiveRightClick()
        {
            if (this._turn.GetTurnState() == TurnState.SelectingAngle && this._turn.IsMyTurn())
            {
                Sound.PlaySound(SoundConstants.Feedback.GAME_CANCEL);
                this._turn.SetTurnState(TurnState.Idle);
            }
            else if (this._turn.GetTurnState() == TurnState.SelectingPower && this._turn.IsMyTurn())
            {
                Sound.PlaySound(SoundConstants.Feedback.GAME_CANCEL);
                this._turn.SetTurnState(TurnState.SelectingAngle);
            }
        }

        /// <summary>
        /// Sets reference to <see cref="QuadTree{T}"/> of <see cref="Ball"/>.
        /// </summary>
        /// <param name="quadTree">Reference to <see cref="QuadTree{T}"/> of <see cref="Ball"/></returns>
        public void SetQuadTree(QuadTree<EntityPhysics> quadTree)
        {
            this._entities.Remove(StringConstants.Entities.Game.QUAD_TREE);
            this._entities.Add(StringConstants.Entities.Game.QUAD_TREE, quadTree);
        }

        /// <inheritdoc cref="Scene.Update"/>
        public override void Update()
        {
            this.UpdateQuadTree();
            this.UpdateCueBall();
            this.UpdateCue();
            base.Update();
        }

        /// <inheritdoc cref="Scene.AddDependentEntities"/>
        protected override void AddDependentEntities()
        {
            // Game Entities
            Tuple<IList<Ball>, QuadTree<EntityPhysics>> setup = this._rules.GenerateInitialBalls(
                this.GetTable().GetTopLeft(),
                TableConstants.GetCueBallStart(this.GetTable().GetTableType()),
                TableConstants.GetFootSpot(this.GetTable().GetTableType()),
                TableConstants.GetRackOrientation(this.GetTable().GetTableType()));

            this._cueBalls = setup.Item1;
            this._entities.Add(
                StringConstants.Entities.Game.QUAD_TREE,
                setup.Item2);

            if (this._players[1].IsComputer())
            {
                this._entities.Add(
                    StringConstants.Entities.Game.PORTRAIT,
                    new Portrait(
                        Origin.TopLeft,
                        new Vector2(RenderConstants.MinigameScreen.WIDTH - Textures.Portrait.Sam.DEFAULT.Width, RenderConstants.MinigameScreen.HEIGHT - Textures.Portrait.Sam.DEFAULT.Height),
                        RenderConstants.Scenes.Game.LayerDepth.PORTRAIT,
                        TransitionConstants.Game.Portrait.Entering(),
                        null,
                        ((ComputerOpponent)this._players[1]).GetNPCName(),
                        PortraitEmotion.Default));
            }
        }

        /// <inheritdoc cref="Scene.AddEntities"/>
        protected override void AddEntities()
        {
            // Background
            this._entities.Add(
                StringConstants.Entities.Game.FLOOR_TILES,
                new FloorTiles(null, null));

            this._entities.Add(
                StringConstants.Entities.Game.FADE_IN,
                new Solid(
                    new Primitives.Rectangle(new Vector2(0, 0), RenderConstants.MinigameScreen.WIDTH, RenderConstants.MinigameScreen.HEIGHT),
                    RenderConstants.Scenes.Game.LayerDepth.FADE_IN,
                    null,
                    TransitionConstants.Game.FadeIn.Exiting(),
                    Color.Black));

            this._entities.Add(
                StringConstants.Entities.Game.POCKETED_BALLS_PLAYER1,
                new PocketedBalls(
                    Origin.TopLeft,
                    new Vector2((RenderConstants.MinigameScreen.WIDTH / 2) - ((TableConstants.Classic.LAYOUT[0].Count * Textures.Table.Edge.Back.NORTH.Width) / 2), 0),
                    RenderConstants.Scenes.Game.LayerDepth.POCKETED_BALLS,
                    TransitionConstants.Game.PocketedBalls.Entering(),
                    null));

            this._entities.Add(
                StringConstants.Entities.Game.POCKETED_BALLS_PLAYER2,
                new PocketedBalls(
                    Origin.TopRight,
                    new Vector2((RenderConstants.MinigameScreen.WIDTH / 2) + ((TableConstants.Classic.LAYOUT[0].Count * Textures.Table.Edge.Back.NORTH.Width) / 2), 0),
                    RenderConstants.Scenes.Game.LayerDepth.POCKETED_BALLS,
                    TransitionConstants.Game.PocketedBalls.Entering(),
                    null));
        }

        /// <summary>
        /// Handles <see cref="Ball"/> being pocketed.
        /// </summary>
        /// <param name="ball"><see cref="Ball"/> pockted</param>
        /// <param name="balls"><see cref="Ball"/> remaining</param>
        /// <param name="tableSegment"><see cref="TableSegment"/> ball was pockted in</param>
        private void BallPocketed(Ball ball, IList<IEntity> balls, TableSegment tableSegment)
        {
            IList<Ball> remaining = new List<Ball>();

            foreach (Ball filterBall in balls)
            {
                if (filterBall.GetId() != ball.GetId() && !filterBall.IsPocketed())
                {
                    remaining.Add(filterBall);
                }
            }
            Sound.PlaySound(SoundConstants.Ball.POCKETED);
            IList<GameEvent> newEvents = this._rules.BallPocketed(this._turn.GetCurrentPlayer(), ball, tableSegment, remaining);

            foreach (GameEvent newEvent in newEvents)
            {
                this._events.Add(newEvent);
            }

            this.GetPocketedBalls(this._turn.GetCurrentPlayerIndex()).Add(ball);
        }

        /// <summary>
        /// Sets default values
        /// </summary>
        /// <param name="rules">Provided <see cref="RuleSet"/> or null for default</param>
        /// <param name="table">Provided <see cref="Table"/> or null for default</param>
        private void Inicialize(
            IPlayer player1,
            IPlayer player2,
            IRules rules,
            Table table,
            IPhysics physics)
        {
            this._rules = rules == null ? RuleSet.GetDefaultRules() : rules;

            this._entities.Add(
                StringConstants.Entities.Game.TABLE,
                table == null ? Table.GetDefaultTable() : table);

            this._physics = physics == null ? Physics.GetDefaultPhysics() : physics;

            this._cueBalls = new List<Ball>();

            this._players = new List<IPlayer>();
            this._players.Add(player1);
            this._players.Add(player2);

            this._events = new List<GameEvent>();
            this._isFinished = false;
        }

        /// <summary>
        /// Updates <see cref="Cue"/> based on <see cref="TurnState"/>.
        /// </summary>
        private void UpdateCue()
        {
            if (this._turn.GetTurnState() == TurnState.SelectingAngle
                || this._turn.GetTurnState() == TurnState.SelectingPower
                || this._turn.GetTurnState() == TurnState.BallsInMotion)
            {
                this._turn.GetCurrentPlayer().GetCue().Update(this._turn.GetTurnState(), this.GetCueBall());
            }
        }

        /// <summary>
        /// Updates cue <see cref="Ball"/> based on <see cref="TurnState"/> and hovering.
        /// </summary>
        private void UpdateCueBall()
        {
            if (this._turn.GetTurnState() == TurnState.Idle)
            {
                if (this.GetCueBall().IsHovered())
                {
                    this.GetCueBall().SetIsHighlighted(true);
                }
                else
                {
                    this.GetCueBall().SetIsFlashing(true);
                }
            }
            else
            {
                this.GetCueBall().SetIsHighlighted(false);
                this.GetCueBall().SetIsFlashing(false);
            }
        }

        /// <summary>
        /// Updates all <see cref="Ball"/> in <see cref="QuadTree{T}"/>.
        /// </summary>
        private void UpdateQuadTree()
        {
            if (this._turn.GetTurnState() == TurnState.BallsInMotion)
            {
                Tuple<IGraph<EntityPhysics>, bool> tangibleInteractionResults = this._physics.TangibleInteractions(this.GetQuadTree(), this.GetTable());

                this.SetQuadTree((QuadTree<EntityPhysics>)tangibleInteractionResults.Item1);
                if (tangibleInteractionResults.Item2 && this._turn.GetCurrentPlayer().GetCue().GetTransitionState() == TransitionState.Dead)
                {
                    this._turn.SetTurnState(TurnState.Results);
                }
            }
        }
    }
}