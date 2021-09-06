using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Structures;

namespace StardropPoolMinigame.Rules
{
    class EightBall : RuleSet
    {
        public EightBall() : base()
        {

        }

        public override Tuple<IList<Ball>, QuadTree> GenerateInitialBalls(
            Vector2 tableTopLeft,
            Vector2 cueBallStart,
            Vector2 footSpot,
            Direction rackOrientation)
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

            int ballsInRow = 1;
            int ballsFinishedInRow = 0;
            int row = 0;

            for (int ballNumber = 1; ballNumber <= 15; ballNumber++)
            {
                int adjustedBallNumber = ballNumber;
                if (ballNumber == 5)
                {
                    adjustedBallNumber = 8;
                }
                else if (ballNumber > 5 && ballNumber <= 8)
                {
                    adjustedBallNumber = ballNumber - 1;
                } else
                {
                }

                Vector2 startingPosition = Vector2.Add(tableTopLeft, footSpot);

                float totalRowWidth = ((ballsInRow * GameConstants.Ball.RADIUS * 2) + (ballsInRow - 1));
                float halfRowWidth = totalRowWidth / 2;

                float finishedRowWidth = (ballsFinishedInRow * GameConstants.Ball.RADIUS * 2) + ballsFinishedInRow;

                float rowOffset = (row * GameConstants.Ball.RADIUS * 2) / 11 * 10 * (rackOrientation == Direction.West || rackOrientation == Direction.North ? -1 : 1);
                float colOffset = (halfRowWidth * (rackOrientation == Direction.West || rackOrientation == Direction.North ? 1 : -1)) + (finishedRowWidth * (rackOrientation == Direction.West || rackOrientation == Direction.North ? -1 : 1)) + GameConstants.Ball.RADIUS;

                if (rackOrientation == Direction.West || rackOrientation == Direction.East)
                {
                    quadTree.Insert(new Ball(
                        Vector2.Add(startingPosition, new Vector2(rowOffset, colOffset)),
                        LayerDepthConstants.Game.BALL,
                        null,
                        null,
                        adjustedBallNumber));
                }
                else
                {
                    quadTree.Insert(new Ball(
                        Vector2.Add(startingPosition, new Vector2(colOffset, rowOffset)),
                        LayerDepthConstants.Game.BALL,
                        null,
                        null,
                        adjustedBallNumber));
                }

                ballsFinishedInRow += 1;

                if (ballsFinishedInRow >= ballsInRow)
                {
                    ballsInRow += 1;
                    ballsFinishedInRow = 0;
                    row += 1;
                }
            }

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
