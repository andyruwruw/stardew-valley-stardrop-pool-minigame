using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Structures;

namespace StardropPoolMinigame.Rules
{
    internal abstract class RuleSet : IRules
    {
        public static IRules GetDefaultRules()
        {
            return new EightBall();
        }

        public abstract IList<GameEvent> BallPocketed(IPlayer player, Ball ball, TableSegment pocket, IList<Ball> remaining, TableSegment target = null);

        public abstract IList<GameEvent> FirstBallHit(IPlayer player, Ball ball);

        public abstract Tuple<IList<Ball>, QuadTree<EntityPhysics>> GenerateInitialBalls(Vector2 tableTopLeft, Vector2 cueBallStart, Vector2 footSpot, Direction rackOrientation);

        public virtual bool HasPlayerSpecificCueBalls()
        {
            return false;
        }

        public abstract IList<GameEvent> NoBallHit(IList<Ball> remaining);
    }
}