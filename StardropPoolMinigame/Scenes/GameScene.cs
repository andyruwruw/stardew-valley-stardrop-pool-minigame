using Microsoft.Xna.Framework;
using StardewValley;
using StardropPoolMinigame.Objects;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Rules;
using StardropPoolMinigame.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Scenes
{
    class GameScene : Scene
    {
        private IRules _rules;

        private ITable _table;

        private QuadTree _balls;

        private bool _movement;

        private IList<IPlayer> _players;

        private int _turn;

        private TurnState _turnState;

        private IList<GameEvent> _events;

        private bool _finished;

        public GameScene(IPlayer player1, IPlayer player2, IRules rules = null) : base()
        {
            if (rules == null)
            {
                this._rules = new EightBall();
            } else
            {
                this._rules = rules;
            }

            this._table = this._rules.GenerateTable();
            this._balls = this._rules.GenerateInitialBalls();

            this._players = new List<IPlayer>();
            this._players.Add(player1);
            this._players.Add(player2);

            if (player2.IsComputer())
            {
                this._turn = 0;
            } else
            {
                Random rnd = new Random();
                this._turn = rnd.Next(0, 2);
            }

            this._turnState = TurnState.Start;
            this._events = new List<GameEvent>();
            this._movement = false;
        }

        public override void Start()
        {
            Game1.changeMusicTrack(this._players[1].GetMusicId(), track_interruptable: false, Game1.MusicContext.MiniGame);
        }

        public override void Update()
        {
            this.UpdateTurnState();
        }

        public void UpdateTurnState()
        {
            if (this._turnState == TurnState.Start)
            {
                if (this._events.Contains(GameEvent.Scratch))
                {
                    this._turnState = TurnState.PlacingBall;
                }
                else
                {
                    this._turnState = TurnState.SelectingAngle;
                    this._players[this._turn].GetCue().SetAnchor(this.GetCueBall().GetPosition());
                    this._players[this._turn].GetCue().SetCueState(CueState.Angle);
                }
            }
            else if (this._turnState == TurnState.PlacingBall)
            {

            }
            else if (this._turnState == TurnState.SelectingAngle)
            {
                
            }
            else if (this._turnState == TurnState.SelectingPower)
            {

            }
            else if (this._turnState == TurnState.MovingBalls)
            {
                if (this._players[this._turn].GetCue().GetCueState() == CueState.Invisible && !this._movement)
                {
                    this._movement = true;

                    Vector2 angle = this._players[this._turn].GetCue().GetAngle();
                    float power = this._players[this._turn].GetCue().GetPower();

                    this.GetCueBall().SetVelocity(new Vector2(angle.X * power * Feel.CueBallPowerToSpeed * -1, angle.Y * power * Feel.CueBallPowerToSpeed * -1));
                }
                if (this._movement)
                {
                    QuadTree newTree = new QuadTree(this._balls.GetBoundary());

                    foreach (IBall ball in this.GetBalls())
                    {
                        ball.Update(this.GetTable());
                        newTree.Insert(ball);
                    }

                    IDictionary<int, IList<int>> collisionsHandled = new Dictionary<int, IList<int>>();

                    foreach (IBall ball in this.GetBalls())
                    {
                        collisionsHandled.Add(ball.GetNumber(), new List<int>());

                        IList<IBall> collidesWith = this._balls.Query(new Circle(ball.GetPosition().X, ball.GetPosition().Y, Ball.Radius * 2));

                        ball.SetCurrentlyColliding(collidesWith);

                        foreach (IBall collidingBall in collidesWith)
                        {
                            if (collidingBall.GetNumber() == ball.GetNumber())
                            {
                                continue;
                            }

                            collisionsHandled[ball.GetNumber()].Add(collidingBall.GetNumber());

                            if (collisionsHandled.ContainsKey(collidingBall.GetNumber()) && collisionsHandled[collidingBall.GetNumber()].Contains(ball.GetNumber()))
                            {
                                continue;
                            }

                            Game1.playSound(Sounds.BallsColliding);

                            Vector2 angle = Vector2.Subtract(ball.GetPosition(), collidingBall.GetPosition());
                            angle.Normalize();

                            float myCollisionForce = Vector2.Dot(ball.GetVelocity(), angle);
                            float theirCollisionForce = Vector2.Dot(collidingBall.GetVelocity(), angle);

                            double optimizedMomentum = (2.0 * (myCollisionForce - theirCollisionForce)) / (Ball.Mass * ball.GetMassMultiplyer() + Ball.Mass * collidingBall.GetMassMultiplyer());

                            Vector2 ballBounce = Vector2.Subtract(ball.GetVelocity(), Vector2.Multiply(angle, new Vector2((float)optimizedMomentum * (Ball.Mass * collidingBall.GetMassMultiplyer() * Feel.BallBounceMomentumMultiplyer), (float)optimizedMomentum * (Ball.Mass * collidingBall.GetMassMultiplyer() * Feel.BallBounceMomentumMultiplyer))));
                            Vector2 collidingBallBounce = Vector2.Add(collidingBall.GetVelocity(), Vector2.Multiply(angle, new Vector2((float)optimizedMomentum * (Ball.Mass * ball.GetMassMultiplyer() * Feel.BallBounceMomentumMultiplyer), (float)optimizedMomentum * (Ball.Mass * ball.GetMassMultiplyer() * Feel.BallBounceMomentumMultiplyer)))); ;

                            ball.SetVelocity(ballBounce);
                            collidingBall.SetVelocity(collidingBallBounce);
                        }
                    }

                    this._balls = newTree;
                }
            }
        }

        public override void ReceiveLeftClick(int x, int y, bool playSound = true)
        {
            if (this.isMyTurn())
            {
                if (this._turnState == TurnState.SelectingAngle)
                {
                    this._players[this._turn].GetCue().LockAngle();
                    this._players[this._turn].GetCue().SetCueState(CueState.Power);
                    this._turnState = TurnState.SelectingPower;
                } else if (this._turnState == TurnState.SelectingPower)
                {
                    this._players[this._turn].GetCue().LockPower();
                    this._players[this._turn].GetCue().SetCueState(CueState.Shooting);
                    this._turnState = TurnState.MovingBalls;
                }
            }
        }

        public bool isMyTurn()
        {
            return this._turn == 0;
        }

        public IPlayer GetCurrentPlayer()
        {
            return this._players[this._turn];
        }

        public TurnState GetTurnState()
        {
            return this._turnState;
        }

        public ITable GetTable()
        {
            return this._table;
        }

        public IList<IBall> GetBalls()
        {
            return this._balls.Query();
        }

        public IBall GetCueBall()
        {
            return this._balls.GetCueBall();
        }
    }
}
