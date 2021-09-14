using Microsoft.Xna.Framework;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Structures;
using System;
using System.Collections.Generic;

namespace StardropPoolMinigame.Rules
{
    /// <summary>
    /// Specifies what game events are brought about by different events
    /// </summary>
    interface IRules
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableTopLeft"></param>
        /// <param name="cueBallStart"></param>
        /// <param name="footSpot"></param>
        /// <param name="rackOrientation"></param>
        /// <returns></returns>
        Tuple<IList<Ball>, QuadTree<EntityPhysics>> GenerateInitialBalls(
            Vector2 tableTopLeft,
            Vector2 cueBallStart,
            Vector2 footSpot,
            Direction rackOrientation);

        IList<GameEvent> NoBallHit(IList<Ball> remaining);

        IList<GameEvent> FirstBallHit(IPlayer player, Ball ball);

        IList<GameEvent> BallPocketed(
            IPlayer player,
            Ball ball,
            TableSegment pocket,
            IList<Ball> remaining,
            TableSegment target = null);

        bool HasPlayerSpecificCueBalls();
    }
}
