using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Players;
using System;
using System.Collections.Generic;
using StardropPoolMinigame.Entities;

namespace StardropPoolMinigame.Scenes.States
{
	class Turn
	{
		/// <summary>
		/// <see cref="IList"/> of <see cref="IPlayer"/>.
		/// </summary>
		private readonly IList<IPlayer> _players;

		/// <summary>
		/// Index of <see cref="IPlayer"/> whose <see cref="Turn"/> it is.
		/// </summary>
		private readonly int _playerIndex;

		/// <summary>
        /// Whether the last <see cref="Turn"/> was a scratch.
        /// </summary>
		private readonly bool _wasScratch;

		/// <summary>
		/// Whether this <see cref="Turn"/> resulted in a scratch.
		/// </summary>
		private bool _isScratch;

        /// <summary>
        /// Whether this <see cref="Turn"/> determined each <see cref="IPlayer"/> <see cref="BallType"/>.
        /// </summary>
		private bool _newBallTypes;

        /// <summary>
        /// Whether current player needs to select a pocket.
        /// </summary>
		private readonly bool _needsToSelectPocket;

		/// <summary>
        /// Current <see cref="TurnState"/>.
        /// </summary>
        private TurnState _turnState;

        /// <summary>
        /// Whether this <see cref="Turn"/> resulted in a victory.
        /// </summary>
		private bool _victory;

		/// <summary>
		/// Whether this <see cref="Turn"/> resulted in a defeat.
		/// </summary>
		private bool _defeat;

        /// <summary>
        /// Number of points scored during this <see cref="Turn"/>.
        /// </summary>
		private int _pointsScored;

        /// <summary>
        /// Number of points given during this <see cref="Turn"/>.
        /// </summary>
		private int _pointsGiven;

        /// <summary>
        /// Pocket targeted by <see cref="IPlayer"/>.
        /// </summary>
		private TableSegment _targetPocket;

		/// <summary>
        /// Instantiates a new <see cref="Turn"/>.
        /// </summary>
        /// <param name="players"><see cref="IList"/> of <see cref="IPlayer"/></param>
        /// <param name="playerIndex">Index of <see cref="IPlayer"/> whose <see cref="Turn"/> it is</param>
        /// <param name="wasScratch">Whether the last <see cref="Turn"/> was a scratch and a new <see cref="Ball"/> needs to be placed</param>
        /// <param name="selectPocket">Whether the next <see cref="Ball"/> requires a pocket to be specified</param>
        public Turn(
			IList<IPlayer> players,
            int? playerIndex = null,
            bool wasScratch = false,
			bool needsToSelectPocket = false)
		{
			_players = players;
            _playerIndex = playerIndex == null ? (int)Math.Round(MiscellaneousHelper.Random()) : (int)playerIndex;
			_wasScratch = wasScratch;
			_needsToSelectPocket = needsToSelectPocket;

			_victory = false;
			_defeat = false;
			_pointsScored = 0;
			_pointsGiven = 0;

			_turnState = TurnState.Idle;
            if (_needsToSelectPocket)
            {
                _turnState = TurnState.SelectingPocket;
            }
            else if (_wasScratch)
            {
                _turnState = TurnState.PlacingBall;
            }
        }

		/// <summary>
        /// Retrieves current <see cref="IPlayer"/>.
        /// </summary>
        /// <returns>Current <see cref="IPlayer"/></returns>
        public IPlayer GetCurrentPlayer()
        {
            return _players[_playerIndex];
        }

        /// <summary>
        /// Retrieves current <see cref="IPlayer">IPlayer's</see> opponent.
        /// </summary>
		/// <returns>Current <see cref="IPlayer">IPlayer's</see> opponent</returns>
        public IPlayer GetCurrentPlayersOpponent()
		{
			return _players[_playerIndex + 1 % 2];
		}

        /// <summary>
        /// Retrieves current <see cref="IPlayer"/> index.
        /// </summary>
        /// <returns>Current <see cref="IPlayer"/> index</returns>
        public int GetCurrentPlayerIndex()
        {
            return _playerIndex;
        }

        /// <summary>
        /// Retrieves current <see cref="TurnState"/>.
        /// </summary>
        /// <returns>Current <see cref="TurnState"/></returns>
        public TurnState GetTurnState()
        {
            return _turnState;
        }

        /// <summary>
        /// Sets current <see cref="TurnState"/>.
        /// </summary>
        /// <param name="state">Current <see cref="TurnState"/></param>
		public void SetTurnState(TurnState state)
		{
			_turnState = state;
		}

        /// <summary>
        /// Checks whether current <see cref="TurnState"/> is <see cref="TurnState.SelectingPocket"/>.
		/// </summary>
        /// <returns>Whether current <see cref="TurnState"/> is <see cref="TurnState.SelectingPocket"/></returns>
        public bool IsSelectingPocket()
		{
			return _turnState == TurnState.SelectingPocket;
		}

        /// <summary>
        /// Checks whether current <see cref="TurnState"/> is <see cref="TurnState.PlacingBall"/>.
        /// </summary>
        /// <returns>Whether current <see cref="TurnState"/> is <see cref="TurnState.PlacingBall"/></returns>
        public bool IsPlacingBall()
		{
			return _turnState == TurnState.PlacingBall;
		}

        /// <summary>
        /// Checks whether current <see cref="TurnState"/> is <see cref="TurnState.Idle"/>.
        /// </summary>
        /// <returns>Whether current <see cref="TurnState"/> is <see cref="TurnState.Idle"/></returns>
        public bool IsIdle()
		{
			return _turnState == TurnState.Idle;
		}

        /// <summary>
        /// Checks whether current <see cref="TurnState"/> is <see cref="TurnState.SelectingAngle"/>.
        /// </summary>
        /// <returns>Whether current <see cref="TurnState"/> is <see cref="TurnState.SelectingAngle"/></returns>
        public bool IsSelectingAngle()
		{
			return _turnState == TurnState.SelectingAngle;
		}

        /// <summary>
        /// Checks whether current <see cref="TurnState"/> is <see cref="TurnState.SelectingPower"/>.
        /// </summary>
        /// <returns>Whether current <see cref="TurnState"/> is <see cref="TurnState.SelectingPower"/></returns>
        public bool IsSelectingPower()
		{
			return _turnState == TurnState.SelectingPower;
		}

        /// <summary>
        /// Checks whether it is main <see cref="Player">Player's</see> <see cref="Turn"/>.
        /// </summary>
        /// <returns>Whether it is main <see cref="Player">Player's</see> <see cref="Turn"/>.</returns>
        public bool IsMyTurn()
        {
            return (!GetCurrentPlayer().IsComputer()
                && GetCurrentPlayer().IsMe());
        }

		/// <summary>
		/// Checks whether <see cref="Player"/> is making an attempt on their last <see cref="Ball"/>.
		/// </summary>
		/// <returns>Whether <see cref="Player"/> is making an attempt on their last <see cref="Ball"/></returns>
		public bool NeedsToSelectPocket()
		{
			return _needsToSelectPocket;
		}

        /// <summary>
        /// Checks whether cue <see cref="Ball"/> needs to be placed due to a scratch on the previous <see cref="Turn"/>.
        /// </summary>
        /// <returns>Whether cue <see cref="Ball"/> needs to be placed</returns>
        public bool NeedsToPlaceCueBall()
        {
            return _wasScratch;
        }

        /// <summary>
        /// Sets targeted pocket.
        /// </summary>
        /// <param name="pocket">Targeted pocket</param>
		public void SetTarget(TableSegment pocket)
		{
			_targetPocket = pocket;
		}

        /// <summary>
        /// Retrieves targeted pocket.
        /// </summary>
        /// <returns>Targeted pocket</returns>
		public TableSegment GetTarget()
		{
			return _targetPocket;
		}

        /// <summary>
        /// Sets whether this <see cref="Turn"/> resulted in a victory.
        /// </summary>
        /// <param name="state">Whether this <see cref="Turn"/> resulted in a victory</param>
		public void SetVictory(bool state = true)
		{
			_victory = state;
		}

        /// <summary>
        /// Checks whether this <see cref="Turn"/> resulted in a victory.
        /// </summary>
        /// <returns>Whether this <see cref="Turn"/> resulted in a victory</returns>
		public bool IsVictory()
		{
			return _victory;
		}

		/// <summary>
		/// Sets whether this <see cref="Turn"/> resulted in a defeat.
		/// </summary>
		/// <param name="state">Whether this <see cref="Turn"/> resulted in a defeat </param>
		public void SetDefeat(bool state = true)
		{
			_defeat = state;
		}

        /// <summary>
        /// Checks whether this <see cref="Turn"/> resulted in a defeat.
        /// </summary>
        /// <returns>Whether this <see cref="Turn"/> resulted in a defeat</returns>
        public bool IsDefeat()
		{
			return _defeat;
		}

        /// <summary>
        /// Sets whether this <see cref="Turn"/> resulted in a scratch.
        /// </summary>
        /// <param name="state">Whether this <see cref="Turn"/> resulted in a scratch</param>
		public void SetIsScratch(bool state = true)
		{
			_isScratch = state;
		}

        /// <summary>
        /// Checks whether this <see cref="Turn"/> resulted in a scratch.
        /// </summary>
        /// <returns>Whether this <see cref="Turn"/> resulted in a scratch</returns>
        public bool IsScratch()
		{
			return _isScratch;
		}

        /// <summary>
        /// Sets whether this <see cref="Turn"/> resulted in setting each <see cref="IPlayer">IPlayer's</see> <see cref="BallType"/>.
        /// </summary>
        /// <param name="state">Whether this <see cref="Turn"/> resulted in setting each <see cref="IPlayer">IPlayer's</see> <see cref="BallType"/></param>
		public void SetIsNewBallTypes(bool state = true)
		{
			_newBallTypes = state;
		}

        /// <summary>
        /// Checks whether this <see cref="Turn"/> resulted in setting each <see cref="IPlayer">IPlayer's</see> <see cref="BallType"/>.
        /// </summary>
        /// <returns>Whether this <see cref="Turn"/> resulted in setting each <see cref="IPlayer">IPlayer's</see> <see cref="BallType"/></returns>
		public bool IsNewBallTypes()
		{
			return _newBallTypes;
		}

        /// <summary>
        /// Adds points scored this <see cref="Turn"/>.
        /// </summary>
        /// <param name="num">Number of points to add to points scored</param>
		public void AddPointScored(int num = 1)
		{
			_pointsScored += num;
		}

        /// <summary>
        /// Retrieves points scored this <see cref="Turn"/>.
        /// </summary>
        /// <returns>Number of points scored this <see cref="Turn"/></returns>
		public int GetPointsScored()
		{
			return _pointsScored;
		}

		/// <summary>
		/// Adds points given this <see cref="Turn"/>.
		/// </summary>
		/// <param name="num">Number of points to add to points given</param>
		public void AddPointGiven(int num = 1)
		{
			_pointsGiven += num;
		}

        /// <summary>
        /// Retrieves points given this <see cref="Turn"/>.
        /// </summary>
        /// <returns>Number of points given this <see cref="Turn"/></returns>
        public int GetPointsGiven()
		{
			return _pointsGiven;
		}

		/// <summary>
        /// Generates next <see cref="Turn"/>.
        /// </summary>
        /// <returns>Next <see cref="Turn"/></returns>
        public Turn GetNextTurn(bool needsToSelectPocket = false)
		{
			int playerIndex = _playerIndex;

			if (_isScratch || _pointsScored == 0)
			{
				playerIndex = _playerIndex == 0 ? 1 : 0;
			}

			return new Turn(
				_players,
				playerIndex,
				_isScratch,
				needsToSelectPocket);
		}
	}
}