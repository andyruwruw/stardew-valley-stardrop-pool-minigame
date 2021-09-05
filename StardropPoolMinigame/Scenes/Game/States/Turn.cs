using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Players;
using System.Collections.Generic;

namespace StardropPoolMinigame.Scenes.States
{
    class Turn
    {
        private IList<IPlayer> _players;

        private int _playerIndex;

        private TurnState _turnState;

        private bool _needsToPlaceCueBall;

        public Turn(IList<IPlayer> players, int playerIndex, bool wasScratch = false, bool selectPocket = false)
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
