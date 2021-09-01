using Microsoft.Xna.Framework;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Structures;
using System.Collections.Generic;

namespace StardropPoolMinigame.Rules
{
    interface IRules
    {
        QuadTree GenerateInitialBalls(Vector2 footSpot, Direction rackOrientation);

        IList<GameEvent> NoBallHit(IList<Ball> remaining);

        IList<GameEvent> FirstBallHit(IPlayer player, Ball ball);

        IList<GameEvent> BallPocketed(
            IPlayer player,
            IList<Ball> balls,
            TableSegment pocket,
            IList<Ball> remaining,
            TableSegment target = null);
    }
}
