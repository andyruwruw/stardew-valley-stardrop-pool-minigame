using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Structures;
using System;
using System.Collections.Generic;

namespace StardropPoolMinigame.Rules
{
    class NineBall : RuleSet
    {
        public NineBall() : base()
        {
        }

        public override Tuple<IList<Ball>, QuadTree> GenerateInitialBalls(Vector2 tableTopLeft, Vector2 cueBallStart, Vector2 footSpot, Direction rackOrientation)
        {
            QuadTree quadTree = new QuadTree(
                new Primitives.Rectangle(
                    new Vector2(0, 0),
                    RenderConstants.MinigameScreen.WIDTH,
                    RenderConstants.MinigameScreen.HEIGHT));

            Ball cueBall = new Ball(
                Vector2.Add(tableTopLeft, cueBallStart),
                LayerDepthConstants.Game.BALL,
                null,
                null,
                0);
            quadTree.Insert(cueBall);

            return new Tuple<IList<Ball>, QuadTree>(new List<Ball> { cueBall }, quadTree);
        }

        public override IList<GameEvent> NoBallHit(IList<Ball> remaining)
        {
            IList<GameEvent> events = new List<GameEvent>();

            return events;
        }

        public override IList<GameEvent> FirstBallHit(IPlayer player, Ball ball)
        {
            IList<GameEvent> events = new List<GameEvent>();

            return events;
        }

        public override IList<GameEvent> BallPocketed(
            IPlayer player,
            IList<Ball> balls,
            TableSegment pocket,
            IList<Ball> remaining,
            TableSegment target = null)
        {
            IList<GameEvent> events = new List<GameEvent>();

            return events;
        }
    }
}
