using StardropPoolMinigame.Powerups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame
{
    interface IPlayer
    {
        bool IsComputer();

        void SetBallType(BallType ballType);

        BallType GetBallType();
    }
}
