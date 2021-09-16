using Microsoft.Xna.Framework;
using StardropPoolMinigame.Attributes;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Primitives;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame.Entities
{
	/// <summary>
	/// <see cref="Ball"/> in pool game.
	/// </summary>
	internal class Ball : EntityPhysics
	{
		private readonly float _massMultiplier;

		/// <summary>
		/// <see cref="Ball"/> number
		/// </summary>
		private readonly int _number;

		private readonly Orientation _orientation;

		private bool _isFlashing;

		private bool _isHighlighted;

		private bool _isPocketed;

		private float radius;

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
			exitingTransition,
			GameConstants.Ball.Mass)
		{
			_number = number;
			_orientation = new Orientation(GameConstants.Ball.Radius, orientation.X, orientation.Y);
			_massMultiplier = 1;

			_isHighlighted = isHighlighted;
			_isFlashing = isFlashing;
			_isPocketed = false;

			SetDrawer(new BallDrawer(this));
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
			exitingTransition,
			GameConstants.Ball.Mass)
		{
			_number = number;
			_orientation = new Orientation(GameConstants.Ball.Radius);
			_massMultiplier = 1;

			_isHighlighted = isHighlighted;
			_isFlashing = isFlashing;

			SetDrawer(new BallDrawer(this));
		}

		public BallColor GetBallColor()
		{
			if (_number == 0) return BallColor.White;

			switch (MiscellaneousHelper.Modulo(_number, 8))
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

		public BallType GetBallType()
		{
			if (_number == 0) return BallType.White;

			if (_number <= 8) return BallType.Solid;

			if (_number > 8) return BallType.Stripped;

			return BallType.Any;
		}

		/// <inheritdoc cref="EntityPhysics.GetId"/>
		public override string GetId()
		{
			return $"ball-{_id}";
		}

		public override float GetMass()
		{
			return GameConstants.Ball.Mass * _massMultiplier;
		}

		public int GetNumber()
		{
			return _number;
		}

		public Orientation GetOrientation()
		{
			return _orientation;
		}

		/// <inheritdoc cref="EntityPhysics.GetTotalHeight"/>
		public override float GetTotalHeight()
		{
			return GameConstants.Ball.Radius * 2;
		}

		/// <inheritdoc cref="EntityPhysics.GetTotalWidth"/>
		public override float GetTotalWidth()
		{
			return GameConstants.Ball.Radius * 2;
		}

		public bool IsFlashing()
		{
			return _isFlashing;
		}

		public bool IsHighlighted()
		{
			return _isHighlighted;
		}

		public bool IsPocketed()
		{
			return _isPocketed;
		}

		public void SetIsFlashing(bool state)
		{
			if (state) _isHighlighted = !state;
			_isFlashing = state;
		}

		public void SetIsHighlighted(bool state)
		{
			if (state) _isFlashing = !state;
			_isHighlighted = state;
		}

		public void SetPocketed(bool state)
		{
			_isPocketed = state;
		}

		/// <inheritdoc cref="EntityPhysics.Update"/>
		public override void Update()
		{
			base.Update();

			_orientation.Roll(Vector2.Negate(GetVelocity()));
		}

		/// <inheritdoc/>
		public override void CollisionCallback(object against)
		{
			if (against is Ball)
				Sound.PlaySound(SoundConstants.Ball.Colliding);
			else if (against is Line) Sound.PlaySound(SoundConstants.Ball.Bounce);
		}
	}
}