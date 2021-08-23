using StardropPoolMinigame.Enums;

namespace StardropPoolMinigame.Scenes.States
{
    class Turn
    {
        private TurnState _turnState;

        public Turn()
        {
            this._turnState = TurnState.Start;
        }

        public TurnState GetTurnState()
        {
            return this._turnState;
        }
    }
}
