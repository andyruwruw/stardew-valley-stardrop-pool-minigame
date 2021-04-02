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
        /// <summary>
        /// <see cref="IRules">Rule Set</see> for current game.
        /// </summary>
        private IRules _rules;

        /// <summary>
        /// List of <see cref="IPlayer">Players</see> in current game.
        /// </summary>
        private IList<IPlayer> _players;

        /// <summary>
        /// Whether the game is completed.
        /// </summary>
        private bool _finished;

        /// <summary>
        /// <see cref="ITable"/> instance for current game.
        /// </summary>
        private ITable _table;

        /// <summary>
        /// <see cref="QuadTree"/> of all <see cref="IBall">Balls</see> on the <see cref="ITable"/>.
        /// </summary>
        private QuadTree _balls;

        /// <summary>
        /// <see cref="IBall">Balls</see> pocketed.
        /// </summary>
        private IList<IBall> _pocketedBalls;

        /// <summary>
        /// Whether or not balls are still in movement.
        /// </summary>
        private bool _movement;

        /// <summary>
        /// Index of current <see cref="IPlayer"/> in <see cref="_players"/>
        /// </summary>
        private int _turn;

        /// <summary>
        /// Stage of the current player's turn.
        /// </summary>
        private TurnState _turnState;

        /// <summary>
        /// List of <see cref="GameEvents"/> from current turn.
        /// </summary>
        private IList<GameEvent> _events;

        /// <summary>
        /// Instantiates a new Game.
        /// </summary>
        /// 
        /// <param name="player1">First <see cref="IPlayer"/>, always the current player.</param>
        /// <param name="player2">Second <see cref="IPlayer"/>, sometimes multiplayer or NPC.</param>
        /// <param name="rules"><see cref="IRules">Rule Set</see> to use for this game.</param>
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

            this._pocketedBalls = new List<IBall>();
        }

        public override void Start()
        {
            Game1.changeMusicTrack(this._players[1].GetMusicId(), track_interruptable: false, Game1.MusicContext.MiniGame);
        }

        public override void Update()
        {
            this.UpdateTurnState();
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
                    Console.Info("Locked Power");
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

        private void UpdateTurnState()
        {
            if (this._turnState == TurnState.Start)
            {
                this.UpdateTurnStateStart();
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
                this.UpdateTurnStateMovingBalls();
            }
        }

        private void UpdateTurnStateStart()
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

        private void UpdateTurnStateMovingBalls()
        {
            // Player shoots cue ball
            if (this._players[this._turn].GetCue().GetCueState() == CueState.Invisible && !this._movement)
            {
                this._movement = true;

                Vector2 angle = this._players[this._turn].GetCue().GetAngle();
                float power = this._players[this._turn].GetCue().GetPower();

                this.GetCueBall().SetVelocity(new Vector2(angle.X * power * Feel.CueBallPowerToSpeed * -1, angle.Y * power * Feel.CueBallPowerToSpeed * -1));
            }
            // Balls are in movement
            else if (this._movement)
            {
                // Generate new Quad Tree
                QuadTree newTree = new QuadTree(this._balls.GetBoundary());

                // Update and insert
                foreach (IBall ball in this.GetBalls())
                {
                    ball.Update(this.GetTable());
                    newTree.Insert(ball);
                }

                // Track collisions
                IDictionary<int, IList<int>> collisionsHandled = new Dictionary<int, IList<int>>();

                // Loop through, find all collisions
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

                        // Find vector between balls
                        Vector2 angle = Vector2.Subtract(ball.GetPosition(), collidingBall.GetPosition());
                        angle.Normalize();

                        // Do some bad physics
                        float myCollisionForce = Vector2.Dot(ball.GetVelocity(), angle);
                        float theirCollisionForce = Vector2.Dot(collidingBall.GetVelocity(), angle);

                        double optimizedMomentum = (2.0 * (myCollisionForce - theirCollisionForce)) / (Ball.Mass * ball.GetMassMultiplyer() + Ball.Mass * collidingBall.GetMassMultiplyer());

                        Vector2 ballBounce = Vector2.Subtract(ball.GetVelocity(), Vector2.Multiply(angle, new Vector2((float)optimizedMomentum * (Ball.Mass * collidingBall.GetMassMultiplyer() * Feel.BallBounceMomentumMultiplyer), (float)optimizedMomentum * (Ball.Mass * collidingBall.GetMassMultiplyer() * Feel.BallBounceMomentumMultiplyer))));
                        Vector2 collidingBallBounce = Vector2.Add(collidingBall.GetVelocity(), Vector2.Multiply(angle, new Vector2((float)optimizedMomentum * (Ball.Mass * ball.GetMassMultiplyer() * Feel.BallBounceMomentumMultiplyer), (float)optimizedMomentum * (Ball.Mass * ball.GetMassMultiplyer() * Feel.BallBounceMomentumMultiplyer)))); ;

                        ball.SetVelocity(ballBounce);
                        collidingBall.SetVelocity(collidingBallBounce);
                    }
                }

                foreach (IPocket pocket in this._table.GetPockets())
                {
                    IList<IBall> balls = this._balls.Query(pocket.GetBoundary());

                    if (balls.Count != 0)
                    {
                        foreach (IBall ball in balls)
                        {
                            ball.Pocket();
                            this._pocketedBalls.Add(ball);
                            newTree.Remove(ball);

                            this._events = (this._events.Concat(this._rules.BallPocketed(this.GetCurrentPlayer(), new List<IBall>() { ball }, pocket, balls.ToList().FindAll(b => b != ball)))).ToList<GameEvent>();
                        }
                    }
                }

                foreach (GameEvent thing in this._events) {
                    Console.Info($"Event: {thing.ToString()}");
                }

                this._balls = newTree;
            } else if (this._players[this._turn].GetCue().GetCueState() == CueState.Invisible)
            {
                this._turnState = TurnState.Results;
            }
        }
    }
}
