﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardropPoolMinigame.Behaviors.Physics;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Rules;
using StardropPoolMinigame.Scenes.States;
using StardropPoolMinigame.Structures;
using StardropPoolMinigame.Utilities;
using Rectangle = StardropPoolMinigame.Primitives.Rectangle;

namespace StardropPoolMinigame.Scenes
{
	internal class GameScene : Scene
	{
		/// <summary>
		/// <see cref="IRules"/> for current game.
		/// </summary>
		private IRules _rules;

		/// <summary>
		/// <see cref="IPhysics"/> system of rules applied to balls.
		/// </summary>
		private IPhysics _physics;

		/// <summary>
		/// <see cref="IList"/> of <see cref="IPlayer"/>.
		/// </summary>
		private IList<IPlayer> _players;

		/// <summary>
		/// Whether the game is finished.
		/// </summary>
		private bool _isFinished;

		/// <summary>
		/// Current <see cref="Turn"/> state.
		/// </summary>
		private Turn _turn;

		/// <summary>
		/// References to cue <see cref="Ball"/>.
		/// </summary>
		private IList<Ball> _cueBalls;

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
			IPhysics physics = null)
		{
			Initialize(
				player1,
				player2,
				rules,
				table,
				physics);
			AddDependentEntities();

			_turn = new Turn(_players);
			_entities[StringConstants.Entities.Game.FadeIn].SetTransitionState(TransitionState.Exiting, true);
		}

		/// <inheritdoc cref="Scene.GetKey"/>
		public override string GetKey()
		{
			return "game-scene";
		}

		/// <inheritdoc cref="Scene.GetEntities"/>
		public override IList<IEntity> GetEntities()
		{
			IList<IEntity> entities = new List<IEntity>();

			foreach (var entity in _entities.Values) entities.Add(entity);

			foreach (Ball ball in GetQuadTree().Query()) entities.Add(ball);

			if (_turn.GetTurnState() == TurnState.BallsInMotion
				|| _turn.GetTurnState() == TurnState.SelectingAngle
				|| _turn.GetTurnState() == TurnState.SelectingPower)
				entities.Add(_turn.GetCurrentPlayer().GetCue());

			return entities;
		}

		/// <summary>
		/// Retrieves <see cref="IList"/> of <see cref="IPlayer"/>.
		/// </summary>
		/// <returns><see cref="IList"/> of <see cref="IPlayer"/></returns>
		public IList<IPlayer> GetPlayers()
		{
			return _players;
		}

		/// <summary>
		/// Retrieves current <see cref="Turn"/>.
		/// </summary>
		/// <returns>Current <see cref="Turn"/></returns>
		public Turn GetTurn()
		{
			return _turn;
		}

		/// <summary>
		/// Retrieves reference to <see cref="Table"/>.
		/// </summary>
		/// <returns>Reference to <see cref="Table"/></returns>
		public Table GetTable()
		{
			return (Table)_entities[StringConstants.Entities.Game.Table];
		}

		/// <summary>
		/// Retrieves reference to <see cref="QuadTree{T}"/> of <see cref="Ball"/>.
		/// </summary>
		/// <returns>Reference to <see cref="QuadTree{T}"/> of <see cref="Ball"/></returns>
		public QuadTree<EntityPhysics> GetQuadTree()
		{
			return (QuadTree<EntityPhysics>)_entities[StringConstants.Entities.Game.QuadTree];
		}

		/// <summary>
		/// Whether the game is finished.
		/// </summary>
		/// <returns>Whether the game is finished</returns>
		public bool IsGameFinished()
		{
			return _isFinished;
		}

		/// <summary>
		/// Retrieves current cue <see cref="Ball"/>.
		/// </summary>
		/// <returns>Current cue <see cref="Ball"/></returns>
		public Ball GetCueBall()
		{
			if (_rules.HasPlayerSpecificCueBalls())
			{
				return _cueBalls[_turn.GetCurrentPlayerIndex()];
			}
			return _cueBalls[0];
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
					return GetPlayer2PocketedBalls();

				default:
					return GetPlayer1PocketedBalls();
			}
		}

		/// <summary>
		/// Retrieves <see cref="PocketedBalls"/> for <see cref="IPlayer"/> 1.
		/// </summary>
		/// <returns><see cref="PocketedBalls"/> for <see cref="IPlayer"/> 1</returns>
		public PocketedBalls GetPlayer1PocketedBalls()
		{
			return (PocketedBalls)_entities[StringConstants.Entities.Game.PocketedBallsPlayer1];
		}

		/// <summary>
		/// Retrieves <see cref="PocketedBalls"/> for <see cref="IPlayer"/> 2.
		/// </summary>
		/// <returns><see cref="PocketedBalls"/> for <see cref="IPlayer"/> 2</returns>
		public PocketedBalls GetPlayer2PocketedBalls()
		{
			return (PocketedBalls)_entities[StringConstants.Entities.Game.PocketedBallsPlayer2];
		}

		/// <summary>
		/// Retrieves <see cref="Portrait"/> for <see cref="ComputerOpponent"/>.
		/// </summary>
		/// <returns><see cref="Portrait"/> for <see cref="ComputerOpponent"/></returns>
		public Portrait GetPortrait()
		{
			return (Portrait) _entities[StringConstants.Entities.Game.Portrait];
		}

		/// <inheritdoc cref="Scene.ReceiveLeftClick"/>
		public override void ReceiveLeftClick()
		{
			Logger.Info("Right click recieved");
			if (_turn.IsSelectingPocket() && _turn.IsMyTurn())
			{
				Logger.Info("Selecting Pocket");
				Sound.PlaySound(SoundConstants.Feedback.BottonPress);

				if (_turn.NeedsToPlaceCueBall())
				{
					_turn.SetTurnState(TurnState.PlacingBall);
				}
				else
				{
					_turn.SetTurnState(TurnState.Idle);
				}
					
			}
			else if (_turn.IsPlacingBall() && _turn.IsMyTurn())
			{
				Logger.Info("Placing Ball");
				Sound.PlaySound(SoundConstants.Feedback.BottonPress);
				_turn.SetTurnState(TurnState.Idle);
			}
			else if (_turn.IsIdle() && _turn.IsMyTurn())
			{
				Logger.Info("Idle");
				if (GetCueBall().IsHovered())
				{
					Logger.Info("Cue Ball is Hovered");
					Sound.PlaySound(SoundConstants.Feedback.BottonPress);
					_turn.SetTurnState(TurnState.SelectingAngle);
				}
			}
			else if (_turn.IsSelectingAngle() && _turn.IsMyTurn())
			{
				Logger.Info("Angle Selected");
				Sound.PlaySound(SoundConstants.Cue.LockAngle);
				_turn.SetTurnState(TurnState.SelectingPower);
			}
			else if (_turn.IsSelectingPower() && _turn.IsMyTurn())
			{
				Logger.Info("Selecting Power");
				Sound.PlaySound(SoundConstants.Cue.LockPower);
				_turn.SetTurnState(TurnState.BallsInMotion);
			}
		}

		/// <inheritdoc cref="Scene.ReceiveRightClick"/>
		public override void ReceiveRightClick()
		{
			if (_turn.IsSelectingAngle() && _turn.IsMyTurn())
			{
				Sound.PlaySound(SoundConstants.Feedback.GameCancel);
				_turn.SetTurnState(TurnState.Idle);
			}
			else if (_turn.IsSelectingPower() && _turn.IsMyTurn())
			{
				Sound.PlaySound(SoundConstants.Feedback.GameCancel);
				_turn.SetTurnState(TurnState.SelectingAngle);
			}
		}

		/// <summary>
		/// Sets reference to <see cref="QuadTree{T}"/> of <see cref="Ball"/>.
		/// </summary>
		/// <param name="quadTree">Reference to <see cref="QuadTree{T}"/> of <see cref="Ball"/></returns>
		public void SetQuadTree(QuadTree<EntityPhysics> quadTree)
		{
			_entities.Remove(StringConstants.Entities.Game.QuadTree);
			_entities.Add(StringConstants.Entities.Game.QuadTree, quadTree);
		}

		/// <inheritdoc cref="Scene.Update"/>
		public override void Update()
		{
			UpdateQuadTree();
			UpdateCueBall();
			UpdateCue();
			base.Update();
		}

		/// <inheritdoc cref="Scene.AddDependentEntities"/>
		protected override void AddDependentEntities()
		{
			// Game Entities
			var setup = _rules.GenerateInitialBalls(
				GetTable().GetTopLeft(),
				TableConstants.GetCueBallStart(GetTable().GetTableType()),
				TableConstants.GetFootSpot(GetTable().GetTableType()),
				TableConstants.GetRackOrientation(GetTable().GetTableType()));

			_cueBalls = setup.Item1;
			_entities.Add(
				StringConstants.Entities.Game.QuadTree,
				setup.Item2);

			if (_players[1].IsComputer())
			{
				_entities.Add(
					StringConstants.Entities.Game.Portrait,
					new Portrait(
						Origin.TopLeft,
						new Vector2(RenderConstants.MinigameScreen.Width - Textures.Portrait.Sam.DEFAULT.Width,
							RenderConstants.MinigameScreen.Height - Textures.Portrait.Sam.DEFAULT.Height),
						RenderConstants.Scenes.Game.LayerDepth.Portrait,
						TransitionConstants.Game.Portrait.Entering(),
						null,
						((ComputerOpponent)_players[1]).GetNPCName()));
			}
		}

		/// <inheritdoc cref="Scene.AddEntities"/>
		protected override void AddEntities()
		{
			// Background
			_entities.Add(
				StringConstants.Entities.Game.FloorTiles,
				new FloorTiles(null, null));

			_entities.Add(
				StringConstants.Entities.Game.FadeIn,
				new Solid(
					new Rectangle(new Vector2(0, 0), RenderConstants.MinigameScreen.Width,
						RenderConstants.MinigameScreen.Height),
					RenderConstants.Scenes.Game.LayerDepth.FadeIn,
					null,
					TransitionConstants.Game.FadeIn.Exiting(),
					Color.Black));

			_entities.Add(
				StringConstants.Entities.Game.PocketedBallsPlayer1,
				new PocketedBalls(
					Origin.TopLeft,
					new Vector2(
						RenderConstants.MinigameScreen.Width / 2 - TableConstants.Classic.Layout[0].Count *
						Textures.Table.Edge.Back.NORTH.Width / 2, 0),
					RenderConstants.Scenes.Game.LayerDepth.PocketedBalls,
					TransitionConstants.Game.PocketedBalls.Entering(),
					null));

			_entities.Add(
				StringConstants.Entities.Game.PocketedBallsPlayer2,
				new PocketedBalls(
					Origin.TopRight,
					new Vector2(
						RenderConstants.MinigameScreen.Width / 2 + TableConstants.Classic.Layout[0].Count *
						Textures.Table.Edge.Back.NORTH.Width / 2, 0),
					RenderConstants.Scenes.Game.LayerDepth.PocketedBalls,
					TransitionConstants.Game.PocketedBalls.Entering(),
					null));
		}

		/// <summary>
		/// Sets default values
		/// </summary>
		/// <param name="rules">Provided <see cref="RuleSet"/> or null for default</param>
		/// <param name="table">Provided <see cref="Table"/> or null for default</param>
		private void Initialize(
			IPlayer player1,
			IPlayer player2,
			IRules rules,
			Table table,
			IPhysics physics)
		{
			_rules = rules == null ? RuleSet.GetDefaultRules() : rules;

			_entities.Add(
				StringConstants.Entities.Game.Table,
				table == null ? Table.GetDefaultTable() : table);

			_physics = physics == null ? Physics.GetDefaultPhysics() : physics;

			_cueBalls = new List<Ball>();

			_players = new List<IPlayer>();
			_players.Add(player1);
			_players.Add(player2);

			_isFinished = false;
		}

		/// <summary>
		/// Updates <see cref="Cue"/> based on <see cref="TurnState"/>.
		/// </summary>
		private void UpdateCue()
		{
			if (_turn.GetTurnState() == TurnState.SelectingAngle
				|| _turn.GetTurnState() == TurnState.SelectingPower
				|| _turn.GetTurnState() == TurnState.BallsInMotion)
			{
				_turn.GetCurrentPlayer().GetCue().Update(_turn.GetTurnState(), GetCueBall());
			}
		}

		/// <summary>
		/// Updates cue <see cref="Ball"/> based on <see cref="TurnState"/> and hovering.
		/// </summary>
		private void UpdateCueBall()
		{
			if (_turn.GetTurnState() == TurnState.Idle)
			{
				if (GetCueBall().IsHovered())
				{
					GetCueBall().SetIsHighlighted(true);
				}
				else
				{
					GetCueBall().SetIsFlashing(true);
				}
			}
			else
			{
				GetCueBall().SetIsHighlighted(false);
				GetCueBall().SetIsFlashing(false);
			}
		}

		/// <summary>
		/// Updates all <see cref="Ball">Balls</see> in <see cref="QuadTree{T}"/>.
		/// </summary>
		private void UpdateQuadTree()
		{
			if (_turn.GetTurnState() == TurnState.BallsInMotion)
			{
				var newGraph = new QuadTree<EntityPhysics>(
				new Rectangle(
					Vector2.Zero,
					RenderConstants.MinigameScreen.Width,
					RenderConstants.MinigameScreen.Height));

				IList<EntityPhysics> balls = GetQuadTree().Query();
				IDictionary<string, IList<string>> collisionsHandled = new Dictionary<string, IList<string>>();

				bool finishedMoving = true;

				foreach (Ball ball in balls)
				{
					if (finishedMoving && VectorHelper.GetMagnitude(ball.GetVelocity()) != 0)
					{
						finishedMoving = false;
					}

					var tableSegment = GetTable().GetTableSegmentFromPosition(ball.GetAnchor());

					var physicsResults = _physics.TangibleInteractions(ball, GetQuadTree(), tableSegment, collisionsHandled[ball.GetId()]);

					if (CheckIfPocketed(ball, tableSegment))
					{
						BallPocketed(ball, balls, tableSegment);
					}
					else
					{
						newGraph.Insert(ball.GetAnchor(), ball);
					}
				}

				SetQuadTree(newGraph);

				if (finishedMoving && _turn.GetCurrentPlayer().GetCue().GetTransitionState() == TransitionState.Dead)
				{
					NewTurn();
				}
			}
		}

		private void NewTurn()
		{
			Logger.Info("New Turn");
			_turn = _turn.GetNextTurn();
			_turn.GetCurrentPlayer().StartTurn();
		}

		/// <summary>
		/// Checks whether a <see cref="Ball"/> has been pocketed.
		/// </summary>
		/// <param name="ball"><see cref="Ball"/> in question</param>
		/// <param name="tableSegment"><see cref="TableSegment"/> <see cref="Ball"/> is currently in</param>
		/// <returns>Whether a <see cref="Ball"/> has been pocketed</returns>
		private bool CheckIfPocketed(Ball ball, TableSegment tableSegment)
		{
			var pocketBounds = tableSegment.GetPockets();

			foreach (var pocketBound in pocketBounds)
			{
				if (pocketBound.Contains(ball.GetAnchor()))
				{
					ball.SetPocketed(true);
				}
			}
			return false;
		}

		/// <summary>
		/// Handles <see cref="Ball"/> being pocketed.
		/// </summary>
		/// <param name="ball"><see cref="Ball"/> pocketed</param>
		/// <param name="balls"><see cref="Ball"/> remaining</param>
		/// <param name="tableSegment"><see cref="TableSegment"/> ball was pocketed in</param>
		private void BallPocketed(
			Ball ball,
			IList<EntityPhysics> balls,
			TableSegment tableSegment)
		{
			IList<EntityPhysics> remaining = new List<EntityPhysics>();

			foreach (Ball filteredBall in balls)
			{
				if (filteredBall.GetId() != ball.GetId() && !filteredBall.IsPocketed())
				{
					remaining.Add(filteredBall);
				}
			}

			Sound.PlaySound(SoundConstants.Ball.Pocketed);
			_rules.BallPocketed(_turn, ball, tableSegment, remaining);

			GetPocketedBalls(_turn.GetCurrentPlayerIndex()).Add(ball);
		}
	}
}