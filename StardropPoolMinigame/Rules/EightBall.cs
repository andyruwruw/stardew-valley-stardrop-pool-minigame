using Microsoft.Xna.Framework;
using StardropPoolMinigame.Objects;
using StardropPoolMinigame.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Rules
{
    class EightBall : IRules
    {
        public EightBall()
        {

        }

        public QuadTree GenerateInitialBalls()
        {
            int wallThickness = 18 * 2;

            int width = Table.Width - wallThickness;
            int height = Table.Height - wallThickness;

            int diamond = width / 8;

            QuadTree balls = new QuadTree(new Structures.Rectangle(0, 0, width, height));

            // White
            balls.Insert(new Ball(0, new Vector2(diamond * 2, height / 2)));

            int ballsCreated = 2;
            Queue<Tuple<bool, IBall>> regularBalls = new Queue<Tuple<bool, IBall>>();

            regularBalls.Enqueue(new Tuple<bool, IBall>(true, new Ball(1, new Vector2(diamond * 6, height / 2))));

            do
            {
                Tuple<bool, IBall> nextItem = regularBalls.Dequeue();
                bool isLeft = nextItem.Item1;
                IBall current = nextItem.Item2;

                if (ballsCreated < 15)
                {
                    balls.Insert(current);

                    // Create right
                    regularBalls.Enqueue(new Tuple<bool, IBall>(false, new Ball(ballsCreated, Vector2.Add(current.GetPosition(), new Vector2((float)Math.Sqrt(Math.Pow(Ball.Radius * 2, 2) - Math.Pow(Ball.Radius, 2)), Ball.Radius)))));
                    ballsCreated += 1;

                    if (isLeft)
                    {
                        regularBalls.Enqueue(new Tuple<bool, IBall>(true, new Ball(ballsCreated, Vector2.Add(current.GetPosition(), new Vector2((float)Math.Sqrt(Math.Pow(Ball.Radius * 2, 2) - Math.Pow(Ball.Radius, 2)), Ball.Radius * -1)))));
                        ballsCreated += 1;
                    }
                }
            } while (regularBalls.Count > 0 && ballsCreated < 15);

            return balls;
        }

        public ITable GenerateTable()
        {
            return new Table();
        }

        public IList<GameEvent> BallPocketed(IPlayer player, IList<IBall> balls, IPocket pocket, IList<IBall> remaining, IPocket target = null)
        {
            IList<GameEvent> events = new List<GameEvent>();

            for (int i = 0; i < balls.Count; i++)
            {
                if (balls[i].GetNumber() == 0)
                {
                    events.Add(GameEvent.Scratch);
                } else if (player.GetBallType() == BallType.Any)
                {
                    player.SetBallType(balls[i].GetBallType());
                }

                if (balls[i].GetNumber() != 0 && balls[i].GetNumber() != 8)
                {
                    if (balls[i].GetBallType() == player.GetBallType())
                    {
                        events.Add(GameEvent.ScoredPoint);
                    }
                    else
                    {
                        events.Add(GameEvent.GavePoint);
                    }
                }

                if (balls[i].GetNumber() == 8)
                {
                    if (player.GetBallType() == BallType.Any)
                    {
                        events.Add(GameEvent.Lose);
                    } else
                    {
                        bool lost = false;
                        bool won = false;

                        foreach (IBall ball in remaining)
                        {
                            if (ball.GetBallType() == player.GetBallType())
                            {
                                lost = true;
                                events.Add(GameEvent.Lose);
                                break;
                            }
                        }

                        if (!lost)
                        {
                            for (int j = i + 1; j < balls.Count; j++)
                            {
                                if (balls[j].GetBallType() == player.GetBallType() ||
                                    balls[j].GetBallType() == BallType.White)
                                {
                                    lost = true;
                                    events.Add(GameEvent.Lose);
                                    break;
                                }
                            }
                        }

                        if (!lost)
                        {
                            if (pocket.GetId() == target.GetId())
                            {
                                events.Add(GameEvent.Win);
                            } else
                            {
                                events.Add(GameEvent.Lose);
                            }
                        }
                    }
                }
            }

            return events;
        }

        public IList<GameEvent> NoBallHit(IList<IBall> remaining)
        {
            IList<GameEvent> events = new List<GameEvent>();
            events.Add(GameEvent.Scratch);
            return events;
        }
    }
}
