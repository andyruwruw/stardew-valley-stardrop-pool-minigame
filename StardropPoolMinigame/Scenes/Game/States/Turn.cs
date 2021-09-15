using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Players;
using System.Collections.Generic;

namespace StardropPoolMinigame.Scenes.States
{
    class Turn
    {
        /// <summary>
        /// <see cref="TurnResults"/> of <see cref="Turn"/>.
        /// </summary>
        private TurnResults _results;

        /// <summary>
        /// <see cref="IList"/> of <see cref="IPlayer"/>.
        /// </summary>
        private IList<IPlayer> _players;

        /// <summary>
        /// Index of <see cref="IPlayer"/> whose <see cref="Turn"/> it is.
        /// </summary>
        private int _playerIndex;

        /// <summary>
        /// Current <see cref="TurnState"/>.
        /// </summary>
        private TurnState _turnState;

        /// <summary>
        /// Whether the last <see cref="Turn"/> was a scratch and a new <see cref="Ball"/> needs to be placed.
        /// </summary>
        private bool _needsToPlaceCueBall;

        /// <summary>
        /// Instantiates a new <see cref="Turn"/>.
        /// </summary>
        /// <param name="players"><see cref="IList"/> of <see cref="IPlayer"/></param>
        /// <param name="playerIndex">Index of <see cref="IPlayer"/> whose <see cref="Turn"/> it is</param>
        /// <param name="wasScratch">Whether the last <see cref="Turn"/> was a scratch and a new <see cref="Ball"/> needs to be placed</param>
        /// <param name="selectPocket">Whether the next <see cref="Ball"/> requires a pocket to be specified</param>
        public Turn(
            IList<IPlayer> players, 
            int playerIndex = Math.Round(MiscellaneousHelper.Random()),
            bool wasScratch = false, 
            bool selectPocket = false)
        {
            this._players = players;
            this._playerIndex = playerIndex;
            this._needsToPlaceCueBall = wasScratch;

            this._turnState = TurnState.Idle;
            if (selectPocket)
            {
                this._turnState = TurnState.SelectingPocket;
            } else if (this._needsToPlaceCueBall)
            {
                this._turnState = TurnState.PlacingBall;
            }
        }

        public bool NeedsToPlaceCueBall()
        {
            return this._needsToPlaceCueBall;
        }

        public int GetCurrentPlayerIndex()
        {
            return this._playerIndex;
        }

        public IPlayer GetCurrentPlayer()
        {
            return this._players[this._playerIndex];
        }

        public bool IsMyTurn()
        {
            return (!this.GetCurrentPlayer().IsComputer()
                && this.GetCurrentPlayer().IsMe());
        }

        public void SetTurnState(TurnState state)
        {
            this._turnState = state;
        }

        public TurnState GetTurnState()
        {
            return this._turnState;
        }
    }
}
