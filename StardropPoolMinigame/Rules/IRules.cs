using StardropPoolMinigame.Players;
using StardropPoolMinigame.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Rules
{
    interface IRules
    {
        QuadTree GenerateInitialBalls();

        ITable GenerateTable();

        IList<GameEvent> BallPocketed(IPlayer player, IList<IBall> balls, IPocket pocket, IList<IBall> remaining, IPocket target = null);

        IList<GameEvent> NoBallHit(IList<IBall> remaining);
    }
}
