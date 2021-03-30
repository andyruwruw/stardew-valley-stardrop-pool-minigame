using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Structures;
using System;
using System.Collections.Generic;

namespace StardropPoolMinigame.Objects
{
    class Ball : IBall
    {
        public static int Radius = 15;

        public static float Mass = 1;

        private Vector2 _position;

        private Vector2 _velocity;
        private Vector2 _acceleration;

        private int _number;

        private int _massMultiplyer;

        private IList<IBall> _currentlyColliding;

        private IList<Structures.Rectangle> _currentlyBouncing;

        private double _xOrientation;
        private double _yOrientation;

        public Ball(int number, Vector2 position)
        {
            this._number = number;
            this._position = position;
            this._velocity = new Vector2(0, 0);
            this._acceleration = new Vector2(0, 0);
            this._massMultiplyer = 1;
            this._xOrientation = 0;
            this._yOrientation = 0;
            this._currentlyBouncing = new List<Structures.Rectangle>();
            this._currentlyColliding = new List<IBall>();
        }

        public void Update(ITable table)
        {
            this.UpdateCollisionWithTableBoundaries(table);

            this.UpdateOrientation();

            this._position = Vector2.Add(this._position, this._velocity);

            this._velocity = Vector2.Add(this._velocity, this._acceleration);

            this.PreventOverlapWithBalls();

            //this.PreventEscape();

            this.UpdateAcceleration();
        }

        public void Draw(SpriteBatch batch)
        {
            int scale = (int)Math.Round(Ball.Radius * 3 * DrawMath.PixelZoomAdjustement);
            Vector2 rawPosition = DrawMath.InnerTableToRaw(this._position);

            Microsoft.Xna.Framework.Rectangle destination = new Microsoft.Xna.Framework.Rectangle((int)(rawPosition.X - Ball.Radius * 1.615), (int)(rawPosition.Y - Ball.Radius * 1.465), scale, scale);

            // Base Color
            batch.Draw(Textures.TileSheet, destination, Textures.GetBallBaseTexture(this.GetColor()), Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.0020f);

            // Core
            if (this._number != 0)
            {
                batch.Draw(Textures.TileSheet, destination, Textures.GetBallCoreTexture((int)Math.Round(this._xOrientation / Feel.OrientationChange), (int)Math.Round(this._yOrientation / Feel.OrientationChange)), Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.0021f);
            }

            if (this.GetBallType() == BallType.Stripped)
            {
                batch.Draw(Textures.TileSheet, destination, Textures.GetBallStripeTexture((int)Math.Round(this._xOrientation / Feel.OrientationChange), (int)Math.Round(this._yOrientation / Feel.OrientationChange)), Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.0021f);
            }

            // Shadow
            batch.Draw(Textures.TileSheet, destination, Textures.BallShadows, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.0022f);
        }

        public void SetAcceleration(Vector2 acceleration)
        {
            this._acceleration = acceleration;
        }

        public void SetCurrentlyColliding(IList<IBall> balls)
        {
            this._currentlyColliding = balls;
        }

        public void SetCurrentlyBouncing(IList<Structures.Rectangle> walls) {
            this._currentlyBouncing = walls;
        }

        public void SetVelocity(Vector2 velocity)
        {
            this._velocity = velocity;
        }

        public Vector2 GetPosition()
        {
            return this._position;
        }

        public Vector2 GetVelocity()
        {
            return this._velocity;
        }

        public Vector2 GetAcceleration()
        {
            return this._acceleration;
        }

        public float GetMassMultiplyer()
        {
            return this._massMultiplyer;
        }

        public int GetNumber()
        {
            return this._number;
        }

        public Color GetColor()
        {
            if (this._number == 0)
            {
                return Color.White;
            }

            switch (VectorMath.Modulo((this._number - 1), 8))
            {
                case 0:
                    return Color.Yellow;
                case 1:
                    return Color.Blue;
                case 2:
                    return Color.Red;
                case 3:
                    return Color.Purple;
                case 4:
                    return Color.Orange;
                case 5:
                    return Color.Green;
                case 6:
                    return Color.Maroon;
                default:
                    return Color.Black;
            }
        }

        public BallType GetBallType()
        {
            if (this._number == 0)
            {
                return BallType.White;
            }

            if (this._number <= 8)
            {
                return BallType.Solid;
            }
            return BallType.Stripped;
        }

        public void SetPosition(Vector2 position)
        {
            this._position = position;
        }

        public void Pocket()
        {
            Game1.playSound(Sounds.BallPocketed);
        }

        private void UpdateAcceleration()
        {
            this._acceleration = new Vector2(0, 0);

            float movement = Math.Abs(this._velocity.X) + Math.Abs(this._velocity.Y);
            
            // Reduce movement to 0 if below threshhold
            if (movement < Feel.MinimumSpeed && movement > 0)
            {
                this._velocity = new Vector2(0, 0);
            } else
            {
                // Apply friction
                Vector2 friction = Vector2.Multiply(this._velocity, new Vector2(Feel.FrictionPerDistance, Feel.FrictionPerDistance));

                // Apply ramping friction
                if (movement <= Feel.ShortStopStart && movement > 0)
                {
                    Vector2 normalizedVelocity = new Vector2(this._velocity.X, this._velocity.Y);
                    normalizedVelocity.Normalize();

                    float percent = (Feel.ShortStopStart - movement) / Feel.ShortStopStart;

                    friction = Vector2.Add(friction, Vector2.Multiply(normalizedVelocity, new Vector2(Feel.ShortStopFriction * percent, Feel.ShortStopFriction * percent)));
                }

                Vector2 minimum = Vector2.Min(new Vector2(0, 0), new Vector2(this._velocity.X * -1, this._velocity.Y * -1));
                Vector2 maximum = Vector2.Max(new Vector2(0, 0), new Vector2(this._velocity.X * -1, this._velocity.Y * -1));

                // Ensure friction does not exceed velocity
                Vector2.Clamp(friction, minimum, maximum);

                this._acceleration = Vector2.Add(this._acceleration, friction);
            }
        }

        private void UpdateCollisionWithTableBoundaries(ITable table)
        {
            Circle ridgidBody = new Circle(this._position.X, this._position.Y, Ball.Radius);

            IList<IRange> borders = table.GetBorders();

            foreach (IRange border in borders)
            {
                if (border is Structures.Rectangle)
                {
                    if (border.Intersects(ridgidBody))
                    {
                        Game1.playSound(Sounds.BallBounce);

                        // Alter Velocity
                        if ((this._position.Y < ((Structures.Rectangle)border).GetNorth() ||
                            this._position.Y > ((Structures.Rectangle)border).GetSouth()) &&
                            this._position.X < ((Structures.Rectangle)border).GetEast() &&
                            this._position.X > ((Structures.Rectangle)border).GetWest())
                        {
                            this._velocity = new Vector2(this._velocity.X, this._velocity.Y * -1);
                        }

                        if ((this._position.X < ((Structures.Rectangle)border).GetWest() ||
                            this._position.X > ((Structures.Rectangle)border).GetEast()) &&
                            this._position.Y < ((Structures.Rectangle)border).GetSouth() &&
                            this._position.Y > ((Structures.Rectangle)border).GetNorth())
                        {
                            this._velocity = new Vector2(this._velocity.X * -1, this._velocity.Y);
                        }
                    }
                }
            }
        }

        private void UpdateOrientation()
        {
            // Do not update if not moving
            if (this._velocity.X == 0 && this._velocity.Y == 0)
            {
                return;
            }

            // New orientation
            this._xOrientation = this._xOrientation + this._velocity.X;
            this._yOrientation = this._yOrientation + this._velocity.Y;

            bool xSwapped = false;
            bool ySwapped = false;

            // Modulo new orientation
            if (Math.Abs(this._xOrientation) > 3 * Feel.OrientationChange)
            {
                this._xOrientation = VectorMath.Modulo(((int)Math.Round(this._xOrientation) + 3 * Feel.OrientationChange), 6 * Feel.OrientationChange) - 3 * Feel.OrientationChange;
                xSwapped = true;
            } 
            if (Math.Abs(this._yOrientation) > 3 * Feel.OrientationChange)
            {
                this._yOrientation = VectorMath.Modulo(((int)Math.Round(this._yOrientation) + 3 * Feel.OrientationChange), 6 * Feel.OrientationChange) - 3 * Feel.OrientationChange;
                ySwapped = true;
            }

            // Switch to complementary side.
            if (xSwapped && !ySwapped)
            {
                this._yOrientation = this._yOrientation * -1;
            }

            if (ySwapped && !xSwapped)
            {
                this._xOrientation = this._xOrientation * -1;
            }
        }

        private void PreventOverlapWithBalls()
        {
            foreach (IBall ball in this._currentlyColliding)
            {
                if (ball.GetNumber() == this._number)
                {
                    continue;
                }

                // If they are overlapping
                if ((Math.Sqrt((Math.Pow(this._position.X - ball.GetPosition().X, 2) + Math.Pow(this._position.Y - ball.GetPosition().Y, 2)))) < Ball.Radius * 2)
                {
                    // Find angle between balls
                    double diff = Ball.Radius * 2 - (Math.Sqrt((Math.Pow(this._position.X - ball.GetPosition().X, 2) + Math.Pow(this._position.Y - ball.GetPosition().Y, 2))));
                    Vector2 angle = Vector2.Subtract(ball.GetPosition(), this._position);
                    angle.Normalize();

                    // Move them out of the way
                    this._position = Vector2.Subtract(this._position, Vector2.Multiply(angle, new Vector2((float)diff + 1, (float)diff + 1)));
                    // ball.SetPosition(Vector2.Subtract(ball.GetPosition(), Vector2.Multiply(angle, new Vector2(((float)diff + 1) * -1, ((float)diff + 1) * -1))));
                }
            }
        }

        private void PreventEscape()
        {
            if (this._position.X < Ball.Radius)
            {
                this._position.X = Ball.Radius;
            }
            if (this._position.X > Table.InnerWidth - Ball.Radius)
            {
                this._position.X = Table.InnerWidth - Ball.Radius;
            }
            if (this._position.Y < Ball.Radius)
            {
                this._position.Y = Ball.Radius;
            }
            if (this._position.Y > Table.InnerHeight - Ball.Radius)
            {
                this._position.Y = Table.InnerHeight - Ball.Radius;
            }
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Ball);
        }

        public bool Equals(Ball p)
        {
            if (System.Object.ReferenceEquals(p, null))
            {
                return false;
            }
            if (System.Object.ReferenceEquals(this, p))
            {
                return true;
            }
            if (this.GetType() != p.GetType())
            {
                return false;
            }
            return (this._number == p.GetNumber());
        }

        public override int GetHashCode()
        {
            return this._number * 0x00010000;
        }

        public static bool operator ==(Ball lhs, Ball rhs)
        {
            if (System.Object.ReferenceEquals(lhs, null))
            {
                if (System.Object.ReferenceEquals(rhs, null))
                {
                    return true;
                }
                return false;
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Ball lhs, Ball rhs)
        {
            return !(lhs == rhs);
        }
    }
}
