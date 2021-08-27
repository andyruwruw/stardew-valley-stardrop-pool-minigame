using System.Collections.Generic;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Structures;

namespace StardropPoolMinigame.Rules
{
    abstract class RuleSet : IRules
    {
        public abstract Table GenerateTable();

        public abstract QuadTree GenerateInitialBalls();

        public abstract IList<GameEvent> NoBallHit(IList<Ball> remaining);

        public abstract IList<GameEvent> FirstBallHit(IPlayer player, Ball ball);

        public abstract IList<GameEvent> BallPocketed(IPlayer player, IList<Ball> balls, Pocket pocket, IList<Ball> remaining, Pocket target = null);

        public static IRules GetDefaultRules()
        {
            return new EightBall();
        }
    }
}
