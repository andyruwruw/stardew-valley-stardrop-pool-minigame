using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Controller;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;
using System;

namespace StardropPoolMinigame.Entities
{
    class Cue : EntityStatic
    {
        private CueType _type;

        private Vector2 _angle;

        private float _power;

        private IFilter _wiggleAnimation;

        private ParticleEmitter _particleEmitter;

        private bool _striking;

        private Vector2 _cueBallPosition;

        public Cue(
            Origin origin, 
            Vector2 anchor, 
            float layerDepth,
            IFilter enteringTransition,
            CueType type = CueType.Basic
        ) : base(
            origin,
            anchor,
            layerDepth,
            enteringTransition,
            TransitionConstants.Game.Cue.Entering())
        {
            this._type = type;
            this._striking = false;

            this._angle = Vector2.Zero;
            this._power = 0f;
            this._cueBallPosition = Vector2.Zero;

            this._wiggleAnimation = new Wiggle($"{this.GetId()}-wiggle-animation", GameConstants.Cue.WIGGLE_FREQUENCY, 0);
            this._filters.Add(this._wiggleAnimation);

            this.InitializeParticleEmitter();
            this.SetDrawer(new CueDrawer(this));
        }

        public override string GetId()
        {
            return $"cue-{this._id}";
        }

        public void Update(TurnState turnState, Ball cueBall)
        {
            base.Update();
            this._particleEmitter.Update();

            if (turnState == TurnState.SelectingAngle)
            {
                this.UpdateAngle(cueBall);
            }

            if (turnState == TurnState.SelectingPower)
            {
                this.UpdatePower(cueBall);
                ((Wiggle)this._wiggleAnimation).SetAmplitude(this._power / (GameConstants.Cue.MAXIMUM_DISTANCE_FROM_BALL / RenderConstants.TileScale() - GameConstants.Cue.MINIMUM_DISTANCE_FROM_BALL / RenderConstants.TileScale()) * GameConstants.Cue.POWER_TO_WIGGLE_AMPLITUDE_SCALAR);
            } else
            {
                this._particleEmitter.SetActive(false);
                ((Wiggle)this._wiggleAnimation).SetAmplitude(0f);
            }

            if (turnState == TurnState.BallsInMotion)
            {
                this.UpdateBallsInMotion(cueBall);
            }
        }

        public override float GetTotalWidth()
        {
            return Textures.Cue.BASIC.Width;
        }

        public override float GetTotalHeight()
        {
            return Textures.Cue.BASIC.Height;
        }

        public Vector2 GetAngle()
        {
            return this._angle;
        }

        public CueType GetCueType()
        {
            return this._type;
        }

        public ParticleEmitter GetParticleEmitter()
        {
            return this._particleEmitter;
        }

        private void UpdateAngle(Ball cueBall)
        {
            this._angle = Vector2.Normalize(Vector2.Subtract(Mouse.Position, RenderConstants.ConvertMinigameWindowToRaw(cueBall.GetPosition())));
            Vector2 relativeDistance = Vector2.Multiply(this._angle, GameConstants.Cue.MINIMUM_DISTANCE_FROM_BALL / RenderConstants.TileScale());

            this._anchor = Vector2.Add(cueBall.GetCenter(), relativeDistance);
            this._particleEmitter.SetDirection(this._angle);
        }

        private void UpdatePower(Ball cueBall)
        {
            Vector2 difference = Vector2.Subtract(Mouse.Position, RenderConstants.ConvertMinigameWindowToRaw(cueBall.GetPosition()));
            this._power = (float)((Math.Sqrt(Math.Pow(difference.X, 2) + Math.Pow(difference.Y, 2)) - GameConstants.Cue.MINIMUM_DISTANCE_FROM_BALL) / (GameConstants.Cue.MAXIMUM_DISTANCE_FROM_BALL - GameConstants.Cue.MINIMUM_DISTANCE_FROM_BALL));

            if (this._power < 0.1f)
            {
                this._power = 0.1f;
            } else if (this._power > 1f)
            {
                this._power = 1f;
            }

            Vector2 relativeDistance = Vector2.Multiply(
                this._angle,
                this._power * ((GameConstants.Cue.MAXIMUM_DISTANCE_FROM_BALL - GameConstants.Cue.MINIMUM_DISTANCE_FROM_BALL) / RenderConstants.TileScale()) + (GameConstants.Cue.MINIMUM_DISTANCE_FROM_BALL / RenderConstants.TileScale()));

            this._anchor = Vector2.Add(cueBall.GetCenter(), relativeDistance);

            if (this._power > GameConstants.Cue.PARTICLE_MINIMUM_POWER_TRIGGER)
            {
                if (!this._particleEmitter.IsActive())
                {
                    Sound.PlaySound(SoundConstants.Cue.FULL_CHARGE);
                }
                this._particleEmitter.SetActive(true);
                this._particleEmitter.SetAnchor(this._anchor);
                this._particleEmitter.SetRate(GameConstants.Cue.PARTICLE_RATE_PER_POWER / ((this._power - GameConstants.Cue.PARTICLE_MINIMUM_POWER_TRIGGER) / (1 - GameConstants.Cue.PARTICLE_MINIMUM_POWER_TRIGGER)));
            } else
            {
                this._particleEmitter.SetActive(false);
            }
        }

        private void UpdateBallsInMotion(Ball cueBall)
        {
            if (!this._striking)
            {
                this._cueBallPosition = cueBall.GetCenter();
                this._striking = true;
                Timer.StartTimer($"{this.GetId()}-striking");
            }

            int timeRemaining = (int)(GameConstants.Cue.STRIKING_SPEED - Timer.CheckTimer($"{this.GetId()}-striking"));

            Vector2 relativeDistance = Vector2.Multiply(
                this._angle,
                this._power * ((GameConstants.Cue.MAXIMUM_DISTANCE_FROM_BALL - GameConstants.Cue.MINIMUM_DISTANCE_FROM_BALL) / RenderConstants.TileScale()) + (GameConstants.Cue.MINIMUM_DISTANCE_FROM_BALL / RenderConstants.TileScale()));
            
            this._anchor = Vector2.Add(
                this._cueBallPosition,
                relativeDistance * (timeRemaining / GameConstants.Cue.STRIKING_SPEED));

            if (timeRemaining <= 0)
            {
                Sound.PlaySound(SoundConstants.Ball.COLLIDING);

                cueBall.SetVelocity(Vector2.Multiply(this._angle, this._power * GameConstants.Cue.MOMENTUM_TRANSFER * -1));

                this.SetTransitionState(TransitionState.Exiting, true);
                Timer.EndTimer($"{this.GetId()}-striking");
            }
        }

        private void InitializeParticleEmitter()
        {
            this._particleEmitter = GetCueParticleEmitter(this._type, this._layerDepth);
        }

        public static ParticleEmitter GetCueParticleEmitter(CueType type, float layerDepth)
        {
            switch (type)
            {
                case CueType.Flames:
                    return new SparkEmitter(
                        Vector2.Zero,
                        5,
                        layerDepth - 0.0001f,
                        5);
                default:
                    return new SparkEmitter(
                        Vector2.Zero,
                        1,
                        layerDepth - 0.0001f,
                        1);
            }
        }
    }
}
