using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Primitives;
using StardropPoolMinigame.Structures;

namespace StardropPoolMinigame.Rules
{
    class EightBall: IRules
    {
        public ITable GenerateTable()
        {
            return new Table();
        }

        public QuadTree GenerateInitialBalls()
        {
            QuadTree quadTree = new QuadTree(new Primitives.Rectangle(new Vector2(0, 0), 2, 2));

            return quadTree;
        }

        public IList<GameEvent> NoBallHit(IList<IBall> remaining)
        {
            IList<GameEvent> events = new List<GameEvent>();

            return events;
        }

        public IList<GameEvent> FirstBallHit(IPlayer player, IBall ball)
        {
            IList<GameEvent> events = new List<GameEvent>();

            return events;
        }

        public IList<GameEvent> BallPocketed(IPlayer player, IList<IBall> balls, IPocket pocket, IList<IBall> remaining, IPocket target = null)
        {
            IList<GameEvent> events = new List<GameEvent>();

            return events;
        }
    }
}
