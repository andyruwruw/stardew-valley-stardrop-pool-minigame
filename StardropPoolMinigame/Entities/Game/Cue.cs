using System;
using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Controller;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame.Entities
{
	internal class Cue : Entity
	{
		private Vector2 _angle;

		private Vector2 _cueBallPosition;

		private ParticleEmitter _particleEmitter;

		private float _power;

		private bool _striking;

		private readonly CueType _type;

		private readonly IFilter _wiggleAnimation;

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
			_type = type;
			_striking = false;

			_angle = Vector2.Zero;
			_power = 0f;
			_cueBallPosition = Vector2.Zero;

			_wiggleAnimation = new Wiggle($"{GetId()}-wiggle-animation", GameConstants.Cue.WiggleFrequency, 0);
			_filters.Add(_wiggleAnimation);

			InitializeParticleEmitter();
			SetDrawer(new CueDrawer(this));
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

		public Vector2 GetAngle()
		{
			return _angle;
		}

		public CueType GetCueType()
		{
			return _type;
		}

		public override string GetId()
		{
			return $"cue-{_id}";
		}

		public ParticleEmitter GetParticleEmitter()
		{
			return _particleEmitter;
		}

		public override float GetTotalHeight()
		{
			return Textures.Cue.BASIC.Height;
		}

		public override float GetTotalWidth()
		{
			return Textures.Cue.BASIC.Width;
		}

		public void Update(TurnState turnState, Ball cueBall)
		{
			base.Update();
			_particleEmitter.Update();

			if (turnState == TurnState.SelectingAngle) UpdateAngle(cueBall);

			if (turnState == TurnState.SelectingPower)
			{
				UpdatePower(cueBall);
				((Wiggle) _wiggleAnimation).SetAmplitude(_power /
					(GameConstants.Cue.MaximumDistanceFromCueBall / RenderConstants.TileScale() -
						GameConstants.Cue.MinimumDistanceFromCueBall / RenderConstants.TileScale()) *
					GameConstants.Cue.PowerToWiggleAmplitudeScalar);
			}
			else
			{
				_particleEmitter.SetActive(false);
				((Wiggle) _wiggleAnimation).SetAmplitude(0f);
			}

			if (turnState == TurnState.BallsInMotion) UpdateBallsInMotion(cueBall);
		}

		private void InitializeParticleEmitter()
		{
			_particleEmitter = GetCueParticleEmitter(_type, _layerDepth);
		}

		private void UpdateAngle(Ball cueBall)
		{
			_angle = Vector2.Normalize(Vector2.Subtract(Mouse.Position,
				RenderConstants.ConvertAdjustedScreenToRaw(cueBall.GetPosition())));
			var relativeDistance = Vector2.Multiply(_angle,
				GameConstants.Cue.MinimumDistanceFromCueBall / RenderConstants.TileScale());

			_anchor = Vector2.Add(cueBall.GetCenter(), relativeDistance);
			_particleEmitter.SetDirection(_angle);
		}

		private void UpdateBallsInMotion(Ball cueBall)
		{
			if (!_striking)
			{
				_cueBallPosition = cueBall.GetCenter();
				_striking = true;
				Timer.StartTimer($"{GetId()}-striking");
			}

			var timeRemaining = (int) (GameConstants.Cue.StrikingSpeed - Timer.CheckTimer($"{GetId()}-striking"));

			var relativeDistance = Vector2.Multiply(
				_angle,
				_power *
				((GameConstants.Cue.MaximumDistanceFromCueBall - GameConstants.Cue.MinimumDistanceFromCueBall) /
					RenderConstants.TileScale()) +
				GameConstants.Cue.MinimumDistanceFromCueBall / RenderConstants.TileScale());

			_anchor = Vector2.Add(
				_cueBallPosition,
				relativeDistance * (timeRemaining / GameConstants.Cue.StrikingSpeed));

			if (timeRemaining <= 0)
			{
				Sound.PlaySound(SoundConstants.Ball.Colliding);

				cueBall.SetVelocity(Vector2.Multiply(_angle, _power * GameConstants.Cue.MomentumTransfer * -1));

				SetTransitionState(TransitionState.Exiting, true);
				Timer.EndTimer($"{GetId()}-striking");
			}
		}

		private void UpdatePower(Ball cueBall)
		{
			var difference = Vector2.Subtract(Mouse.Position,
				RenderConstants.ConvertAdjustedScreenToRaw(cueBall.GetPosition()));
			_power =
				(float) ((Math.Sqrt(Math.Pow(difference.X, 2) + Math.Pow(difference.Y, 2)) -
					GameConstants.Cue.MinimumDistanceFromCueBall) / (GameConstants.Cue.MaximumDistanceFromCueBall -
					GameConstants.Cue.MinimumDistanceFromCueBall));

			if (_power < 0.1f)
				_power = 0.1f;
			else if (_power > 1f) _power = 1f;

			var relativeDistance = Vector2.Multiply(
				_angle,
				_power *
				((GameConstants.Cue.MaximumDistanceFromCueBall - GameConstants.Cue.MinimumDistanceFromCueBall) /
					RenderConstants.TileScale()) +
				GameConstants.Cue.MinimumDistanceFromCueBall / RenderConstants.TileScale());

			_anchor = Vector2.Add(cueBall.GetCenter(), relativeDistance);

			if (_power > GameConstants.Cue.ParticleMinimumPowerTrigger)
			{
				if (!_particleEmitter.IsActive()) Sound.PlaySound(SoundConstants.Cue.FullCharge);
				_particleEmitter.SetActive(true);
				_particleEmitter.SetAnchor(_anchor);
				_particleEmitter.SetRate(GameConstants.Cue.ParticleRatePerPower /
					((_power - GameConstants.Cue.ParticleMinimumPowerTrigger) /
						(1 - GameConstants.Cue.ParticleMinimumPowerTrigger)));
			}
			else
			{
				_particleEmitter.SetActive(false);
			}
		}
	}
}