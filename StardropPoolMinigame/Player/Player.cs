using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Player
{
    class Player : IPlayer
    {
        private bool _isComputer;

        private BallType _ballType;

        public Player(bool isComputer)
        {
            this._isComputer = isComputer;
        }

        public bool IsComputer()
        {
            return this._isComputer;
        }

        public void SetBallType(BallType ballType)
        {
            this._ballType = ballType;
        }

        public BallType GetBallType()
        {
            return this._ballType;
        }
    }
}
