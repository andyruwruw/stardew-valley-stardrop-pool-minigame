using StardropPoolMinigame.Powerups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Players
{
    interface IPlayer
    {
        bool IsComputer();

        bool IsMe();

        void SetBallType(BallType ballType);

        BallType GetBallType();

        string GetMusicId();

        long GetPlayerId();
    }
}
