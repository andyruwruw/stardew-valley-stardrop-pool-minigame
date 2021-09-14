using Microsoft.Xna.Framework;
using StardropPoolMinigame.Primitives;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Attributes;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;
using System.Collections.Generic;
using StardropPoolMinigame.Helpers;

namespace StardropPoolMinigame.Entities
{
    /// <summary>
    /// <see cref="Ball"/> in pool game.
    /// </summary>
    class Ball : EntityPhysics
    {
        /// <summary>
        /// <see cref="Ball"/> number
        /// </summary>
        private int _number;

        private float radius;

        private Orientation _orientation;

        private float _massMultiplier;

        private bool _isHighlighted;

        private bool _isFlashing;

        private bool _isPocketed;

        public Ball(
            Vector2 center,
            float layerDepth,
            IFilter enteringTransition,
            IFilter exitingTransition,
            int number,
            Vector2 orientation,
            bool isHighlighted = false,
            bool isFlashing = false
        ) : base(
            Origin.CenterCenter,
            center,
            layerDepth,
            enteringTransition,
            exitingTransition)
        {
            this._number = number;
            this._range = new Circle(center, GameConstants.Ball.RADIUS);
            this._isHighlighted = isHighlighted;
            this._isFlashing = isFlashing;
            this._isPocketed = false;

            this._velocity = new Vector2(0, 0);
            this._acceleration = new Vector2(0, 0);
            this._orientation = new Orientation(GameConstants.Ball.RADIUS, orientation.X, orientation.Y);
            this._massMultiplier = 1;

            this.SetDrawer(new BallDrawer(this));
        }

        public Ball(
            Vector2 center,
            float layerDepth,
            IFilter enteringTransition,
            IFilter exitingTransition,
            int number,
            bool isHighlighted = false,
            bool isFlashing = false
        ) : base(
            Origin.CenterCenter,
            center,
            layerDepth,
            enteringTransition,
            exitingTransition)
        {
            this._number = number;
            this._range = new Circle(center, GameConstants.Ball.RADIUS);
            this._isHighlighted = isHighlighted;
            this._isFlashing = isFlashing;

            this._velocity = new Vector2(0, 0);
            this._acceleration = new Vector2(0, 0);
            this._orientation = new Orientation(GameConstants.Ball.RADIUS);
            this._massMultiplier = 1;

            this.SetDrawer(new BallDrawer(this));
        }

        /// <inheritdoc cref="EntityPhysics.GetId"/>
        public override string GetId()
        {
            return $"ball-{this._id}";
        }

        /// <inheritdoc cref="EntityPhysics.Update"/>
        public override void Update()
        {
            this.UpdateVectors();
            base.Update();
        }

        public void Update(IList<IEntity> neighbors, TableSegment tableSegment, IDictionary<IEntity, IList<IEntity>> collisionsHandled)
        {
            this.UpdateInteractions(neighbors, tableSegment, collisionsHandled);
            this.UpdateVectors();
            base.Update();
        }

        /// <inheritdoc cref="EntityPhysics.GetTotalWidth"/>
        public override float GetTotalWidth()
        {
            return GameConstants.Ball.RADIUS * 2;
        }

        /// <inheritdoc cref="EntityPhysics.GetTotalHeight"/>
        public override float GetTotalHeight()
        {
            return GameConstants.Ball.RADIUS * 2;
        }

        
        public Orientation GetOrientation()
        {
            return this._orientation;
        }

        public override float GetMass()
        {
            return GameConstants.Ball.MASS * this._massMultiplier;
        }

        public int GetNumber()
        {
            return _number;
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
            if (this._number > 8)
            {
                return BallType.Stripped;
            }
            return BallType.Any;
        }

        public BallColor GetBallColor()
        {
            if (this._number == 0)
            {
                return BallColor.White;
            }

            switch (MiscellaneousHelper.Modulo(this._number, 8))
            {
                case 1:
                    return BallColor.Yellow;
                case 2:
                    return BallColor.Blue;
                case 3:
                    return BallColor.Red;
                case 4:
                    return BallColor.Purple;
                case 5:
                    return BallColor.Orange;
                case 6:
                    return BallColor.Green;
                case 7:
                    return BallColor.Maroon;
                default:
                    return BallColor.Black;
            }
        }

        public bool IsHighlighted()
        {
            return this._isHighlighted;
        }

        public void SetIsHighlighted(bool state)
        {
            if (state)
            {
                this._isFlashing = !state;
            }
            this._isHighlighted = state;
        }

        public bool IsFlashing()
        {
            return this._isFlashing;
        }

        public void SetIsFlashing(bool state)
        {
            if (state)
            {
                this._isHighlighted = !state;
            }
            this._isFlashing = state;
        }

        public bool IsPocketed()
        {
            return this._isPocketed;
        }

        public void SetPocketed(bool state)
        {
            this._isPocketed = state;
        }

        private void UpdateInteractions(IList<IEntity> neighbors, TableSegment tableSegment, IDictionary<IEntity, IList<IEntity>> collisionsHandled)
        {
            // Bounce off balls
            foreach (Ball ball in neighbors)
            {
                if (ball.GetId() != this.GetId()
                    && (!collisionsHandled.ContainsKey(ball) || !collisionsHandled[ball].Contains(this)
                    && (Operators.GetMagnitude(ball.GetVelocity()) > GameConstants.Ball.MINIMUM_BOUNCE_VELOCITY && Operators.GetMagnitude(this._velocity) > GameConstants.Ball.MINIMUM_BOUNCE_VELOCITY)))
                {
                    Sound.PlaySound(SoundConstants.Ball.COLLIDING);
                    RealPhysics.Bounce(this, ball);
                } else if (ball.GetId() != this.GetId()
                    && (!collisionsHandled.ContainsKey(ball) || !collisionsHandled[ball].Contains(this))) {
                    RealPhysics.Bounce(this, ball, true);
                }
            }

            // Bounce off walls
            IList<Line> bounceableSurfaces = tableSegment.GetBounceableSurfaces();

            foreach (Line bounceableSurface in bounceableSurfaces)
            {
                if (bounceableSurface.Intersects(new Circle(this._anchor, GameConstants.Ball.RADIUS)))
                {
                    Sound.PlaySound(SoundConstants.Ball.BOUNCE);
                    RealPhysics.Bounce(this, bounceableSurface);
                    break;
                }
            }

            // Fall in pockets
            IList<Circle> pockets = tableSegment.GetPockets();

            foreach (Circle pocket in pockets)
            {
                if (pocket.Contains(this._anchor))
                {
                    this._isPocketed = true;
                }
            }
        }

        private void UpdateVectors()
        {
            this._anchor = Vector2.Add(this._anchor, this._velocity);
            this._orientation.Roll(Vector2.Negate(this._velocity));

            this._velocity = Vector2.Add(this._velocity, this._acceleration);
            this._acceleration = Vector2.Zero;

            if (Operators.GetMagnitude(this._velocity) < GameConstants.Ball.MINIMUM_VELOCITY && Operators.GetMagnitude(this._velocity) > 0)
            {
                this._velocity = Vector2.Zero;
            } else
            {
                Vector2 friction = Vector2.Multiply(this._velocity, GameConstants.Ball.FRICTION_ACCELERATION);

                // Friction ramps up the slower the ball gets
                if (Operators.GetMagnitude(this._velocity) <= GameConstants.Ball.HALT_BEGIN_VELOCITY && Operators.GetMagnitude(this._velocity) > 0)
                {
                    Vector2 direction = Vector2.Normalize(this._velocity);
                    float percentShortStop = (GameConstants.Ball.HALT_BEGIN_VELOCITY - Operators.GetMagnitude(this._velocity)) / GameConstants.Ball.HALT_BEGIN_VELOCITY;
                    friction = Vector2.Add(friction, Vector2.Multiply(direction, GameConstants.Ball.HALT_ACCELERATION * percentShortStop));
                }

                Vector2 minimum = Vector2.Min(Vector2.Zero, Vector2.Multiply(this._velocity, -1));
                Vector2 maximum = Vector2.Max(Vector2.Zero, Vector2.Multiply(this._velocity, -1));

                Vector2.Clamp(friction, minimum, maximum);

                this._acceleration = Vector2.Add(this._acceleration, friction);
            }

            this._range.SetCenter(this._anchor);
        }
    }
}
