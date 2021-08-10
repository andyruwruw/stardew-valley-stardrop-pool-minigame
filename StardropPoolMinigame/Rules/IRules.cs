using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Structures;
using System.Collections.Generic;

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
