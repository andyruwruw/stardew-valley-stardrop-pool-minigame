﻿using Microsoft.Xna.Framework;
using StardropPoolMinigame.Primitives;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Attributes;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    class Ball : EntityHoverable
    {
        private int _number;

        private Circle _range;

        private Vector2 _velocity;

        private Vector2 _acceleration;

        private Orientation _orientation;

        private float _massMultiplier;

        private bool _isHighlighted;

        private bool _isFlashing;

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

        public override void Update()
        {
            this.UpdateVectors();

            base.Update();
        }

        public override float GetTotalWidth()
        {
            return GameConstants.Ball.RADIUS * 2;
        }

        public override float GetTotalHeight()
        {
            return GameConstants.Ball.RADIUS * 2;
        }

        public override string GetId()
        {
            return $"ball-{this._id}";
        }

        public void SetVelocity(Vector2 velocity)
        {
            this._velocity = velocity;
        }

        public void SetAcceleration(Vector2 velocity)
        {
            this._velocity = velocity;
        }

        public void SetPosition(Vector2 position)
        {
            this._range.SetCenter(position);
        }

        public Vector2 GetPosition()
        {
            return this._range.GetCenter();
        }

        public Vector2 GetVelocity()
        {
            return this._velocity;
        }

        public Vector2 GetAcceleration()
        {
            return this._acceleration;
        }

        public Orientation GetOrientation()
        {
            return this._orientation;
        }

        public float GetMass()
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

            switch (Operators.Modulo(this._number, 8))
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

        private void UpdateVectors()
        {
            Vector2 newPosition = Vector2.Add(this._range.GetCenter(), this._velocity);
            Vector2 newVelocity = Vector2.Add(this._velocity, this._acceleration);

            this._range.SetCenter(newPosition);
            this._orientation.Roll(this._velocity);
            this._velocity = newVelocity;
        }
    }
}
