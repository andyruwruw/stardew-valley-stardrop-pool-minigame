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

        public override QuadTree GenerateInitialBalls(Vector2 footSpot, Direction rackOrientation)
        {
            QuadTree quadTree = new QuadTree(new Primitives.Rectangle(new Vector2(0, 0), RenderConstants.MinigameScreen.WIDTH, RenderConstants.MinigameScreen.HEIGHT));

            int ballsInRow = 1;
            int ballsFinishedInRow = 0;
            int row = 0;

            Logger.Info("Lets create some balls");

            for (int ballNumber = 1; ballNumber <= 15; ballNumber++)
            {
                Logger.Info($"{ballNumber}");
                if (rackOrientation == Direction.West || rackOrientation == Direction.East)
                {
                    float X = footSpot.X + (row * GameConstants.Ball.RADIUS / 11 * 10 * (rackOrientation == Direction.West ? -1 : 1));
                    float Y = footSpot.Y + (((ballsInRow * GameConstants.Ball.RADIUS * 2) + (ballsInRow - 1)) / 2 * (rackOrientation == Direction.West ? -1 : 1)) + (((ballsFinishedInRow * GameConstants.Ball.RADIUS * 2) + (ballsFinishedInRow - 1)) * (rackOrientation == Direction.West ? 1 : -1)) + GameConstants.Ball.RADIUS;
                    Logger.Info($"Yeet heres a ball {X} {Y}");

                    quadTree.Insert(new Ball(
                        new Vector2(
                            footSpot.X + (row * GameConstants.Ball.RADIUS / 11 * 10 * (rackOrientation == Direction.West ? -1 : 1)),
                            footSpot.Y + (((ballsInRow * GameConstants.Ball.RADIUS * 2) + (ballsInRow - 1)) / 2 * (rackOrientation == Direction.West ? -1 : 1)) + (((ballsFinishedInRow * GameConstants.Ball.RADIUS * 2) + (ballsFinishedInRow - 1)) * (rackOrientation == Direction.West ? 1 : -1)) + GameConstants.Ball.RADIUS),
                        LayerDepthConstants.Game.BALL,
                        null,
                        null,
                        ballNumber));
                }
                else
                {
                    quadTree.Insert(new Ball(
                        new Vector2(
                            footSpot.X + (((ballsInRow * GameConstants.Ball.RADIUS * 2) + (ballsInRow - 1)) / 2 * (rackOrientation == Direction.South ? -1 : 1)) + (((ballsFinishedInRow * GameConstants.Ball.RADIUS * 2) + (ballsFinishedInRow - 1)) * (rackOrientation == Direction.South ? 1 : -1)) + GameConstants.Ball.RADIUS,
                            footSpot.Y + (row * GameConstants.Ball.RADIUS / 11 * 10 * (rackOrientation == Direction.South ? 1 : -1))),
                        LayerDepthConstants.Game.BALL,
                        null,
                        null,
                        ballNumber));
                }

                ballsFinishedInRow += 1;

                if (ballsFinishedInRow >= ballsInRow)
                {
                    ballsInRow += 1;
                    ballsFinishedInRow = 0;
                    row += 1;
                }
            }

            return quadTree;
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
