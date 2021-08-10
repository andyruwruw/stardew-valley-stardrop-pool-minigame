﻿using Microsoft.Xna.Framework;
using StardropPoolMinigame.Primitives;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Attributes;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;

namespace StardropPoolMinigame.Entities
{
    class Ball: IBall
    {
        private int _number;

        private Circle _range;

        private Vector2 _velocity;

        private Vector2 _acceleration;

        private Orientation _orientation;

        private float _massMultiplier;

        public Ball(int number, Vector2 center)
        {
            this._number = number;
            this._range = new Circle(center, GameConstants.BALL_RADIUS);
            this._velocity = new Vector2(0, 0);
            this._acceleration = new Vector2(0, 0);
            this._orientation = new Orientation();
            this._massMultiplier = 1;
        }

        public void Update()
        {
            UpdateVectors();
        }

        public void UpdateVectors()
        {
            Vector2 newPosition = Vector2.Add(this._range.GetCenter(), this._velocity);
            Vector2 newVelocity = Vector2.Add(this._velocity, this._acceleration);

            this._range.SetCenter(newPosition);
            this._velocity = newVelocity;
        }

        public void SetVelocity(Vector2 velocity)
        {
            this._velocity = velocity;
        }

        public void SetAcceleration(Vector2 velocity)
        {
            this._velocity = velocity;
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
            return GameConstants.BALL_MASS * this._massMultiplier;
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

            switch (Operators.Modulo((this._number - 1), 8))
            {
                case 0:
                    return BallColor.Yellow;
                case 1:
                    return BallColor.Blue;
                case 2:
                    return BallColor.Red;
                case 3:
                    return BallColor.Purple;
                case 4:
                    return BallColor.Orange;
                case 5:
                    return BallColor.Green;
                case 6:
                    return BallColor.Maroon;
                default:
                    return BallColor.Black;
            }
        }
    }
}
