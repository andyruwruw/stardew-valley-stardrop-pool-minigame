using Microsoft.Xna.Framework;
using StardropPoolMinigame.Objects;
using StardropPoolMinigame.Players;
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
            QuadTree balls = new QuadTree(new Structures.Rectangle(Table.InnerWidth / 2, Table.InnerHeight / 2, Table.InnerWidth, Table.InnerHeight));
            int count = 0;

            // White
            balls.Insert(new Ball(count, new Vector2(Table.DiamondPadding * 2, Table.InnerHeight / 2)));
            count += 1;

            Queue<Tuple<bool, IBall>> regularBalls = new Queue<Tuple<bool, IBall>>();
            

            regularBalls.Enqueue(new Tuple<bool, IBall>(true, new Ball(count, new Vector2(Table.DiamondPadding * 6, Table.InnerHeight / 2))));
            count += 1;

            do
            {
                Tuple<bool, IBall> nextItem = regularBalls.Dequeue();
                bool isLeft = nextItem.Item1;
                IBall current = nextItem.Item2;

                if (balls.Count < 16)
                {
                    balls.Insert(current);

                    if (isLeft)
                    {
                        regularBalls.Enqueue(new Tuple<bool, IBall>(true, new Ball(this.GetNumberFromCount(count), Vector2.Add(current.GetPosition(), new Vector2((float)Math.Sqrt(Math.Pow(Ball.Radius * 2, 2) - Math.Pow(Ball.Radius, 2)) * (float)1.01, Ball.Radius) * (float)1.01))));
                        count += 1;
                    }

                    // Create right
                    regularBalls.Enqueue(new Tuple<bool, IBall>(false, new Ball(this.GetNumberFromCount(count), Vector2.Add(current.GetPosition(), new Vector2((float)Math.Sqrt(Math.Pow(Ball.Radius * 2, 2) - Math.Pow(Ball.Radius, 2)) * (float)1.01, Ball.Radius * (float)-1.01)))));
                    count += 1;
                }
            } while (regularBalls.Count > 0 && balls.Count < 16);

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

        private int GetNumberFromCount(int count)
        {
            if (count < 5)
            {
                return count;
            } else if (count == 5)
            {
                return 8;
            } else if (count > 5 && count < 9)
            {
                return count - 1;
            }
            return count;
        }
    }
}
