using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Controller;
using StardropPoolMinigame.Enums;
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

        public Cue(
            Origin origin, 
            Vector2 anchor, 
            float layerDepth,
            IFilter enteringTransition,
            IFilter exitingTransition,
            CueType type = CueType.Basic
        ) : base(
            origin,
            anchor,
            layerDepth,
            enteringTransition,
            exitingTransition)
        {
            this._type = type;

            this._angle = Vector2.Zero;
            this._power = 0f;

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
            this._power = ((float)Math.Sqrt(Math.Pow(difference.X, 2) + Math.Pow(difference.Y, 2)) - GameConstants.Cue.MINIMUM_DISTANCE_FROM_BALL) / RenderConstants.TileScale();

            if (this._power < 0)
            {
                this._power = 0;
            }
            if (this._power > GameConstants.Cue.MAXIMUM_DISTANCE_FROM_BALL / RenderConstants.TileScale() - GameConstants.Cue.MINIMUM_DISTANCE_FROM_BALL / RenderConstants.TileScale())
            {
                this._power = GameConstants.Cue.MAXIMUM_DISTANCE_FROM_BALL / RenderConstants.TileScale() - GameConstants.Cue.MINIMUM_DISTANCE_FROM_BALL / RenderConstants.TileScale();
            }

            Vector2 relativeDistance = Vector2.Multiply(this._angle, this._power + (GameConstants.Cue.MINIMUM_DISTANCE_FROM_BALL / RenderConstants.TileScale()));

            this._anchor = Vector2.Add(cueBall.GetCenter(), relativeDistance);

            if (this._power > (GameConstants.Cue.MAXIMUM_DISTANCE_FROM_BALL / RenderConstants.TileScale() - GameConstants.Cue.MINIMUM_DISTANCE_FROM_BALL / RenderConstants.TileScale()) * GameConstants.Cue.PARTICLE_MINIMUM_POWER_TRIGGER)
            {
                this._particleEmitter.SetActive(true);
                this._particleEmitter.SetAnchor(this._anchor);

                int rate = (int)Math.Round(((GameConstants.Cue.MAXIMUM_DISTANCE_FROM_BALL / RenderConstants.TileScale() - GameConstants.Cue.MINIMUM_DISTANCE_FROM_BALL / RenderConstants.TileScale()) - this._power) * GameConstants.Cue.PARTICLE_RATE_PER_POWER);
                this._particleEmitter.SetRate(rate);
            } else
            {
                this._particleEmitter.SetActive(false);
            }
        }

        private void InitializeParticleEmitter()
        {
            this._particleEmitter = ParticleEmitterConstants.Cue.GetParticleEmitter(this._type);
        }
    }
}
