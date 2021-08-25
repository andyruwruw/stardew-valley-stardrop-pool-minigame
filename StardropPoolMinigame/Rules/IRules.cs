using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Structures;
using System.Collections.Generic;

namespace StardropPoolMinigame.Rules
{
    interface IRules
    {
        Table GenerateTable();

        QuadTree GenerateInitialBalls();

        IList<GameEvent> NoBallHit(IList<Ball> remaining);

        IList<GameEvent> FirstBallHit(IPlayer player, Ball ball);

        IList<GameEvent> BallPocketed(
            IPlayer player,
            IList<Ball> balls,
            Pocket pocket,
            IList<Ball> remaining,
            Pocket target = null);
    }
}
