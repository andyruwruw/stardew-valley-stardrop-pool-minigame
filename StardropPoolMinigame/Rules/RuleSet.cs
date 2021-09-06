using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Structures;

namespace StardropPoolMinigame.Rules
{
    abstract class RuleSet : IRules
    {
        public abstract Tuple<IList<Ball>, QuadTree> GenerateInitialBalls(Vector2 tableTopLeft, Vector2 cueBallStart, Vector2 footSpot, Direction rackOrientation);

        public abstract IList<GameEvent> NoBallHit(IList<Ball> remaining);

        public abstract IList<GameEvent> FirstBallHit(IPlayer player, Ball ball);

        public abstract IList<GameEvent> BallPocketed(IPlayer player, IList<Ball> balls, TableSegment pocket, IList<Ball> remaining, TableSegment target = null);

        public virtual bool HasPlayerSpecificCueBalls()
        {
            return false;
        }

        public static IRules GetDefaultRules()
        {
            return new EightBall();
        }
    }
}
