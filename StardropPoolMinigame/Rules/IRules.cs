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
        ITable GenerateTable();

        QuadTree GenerateInitialBalls();

        IList<GameEvent> NoBallHit(IList<IBall> remaining);

        IList<GameEvent> FirstBallHit(IPlayer player, IBall ball);

        IList<GameEvent> BallPocketed(IPlayer player, IList<IBall> balls, IPocket pocket, IList<IBall> remaining, IPocket target = null);
    }
}
