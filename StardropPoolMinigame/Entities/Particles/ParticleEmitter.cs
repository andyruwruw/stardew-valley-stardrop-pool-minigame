using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardropPoolMinigame.Behaviors.Physics;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Structures;
using StardropPoolMinigame.Utilities;
using Rectangle = StardropPoolMinigame.Primitives.Rectangle;

namespace StardropPoolMinigame.Entities
{
	/// <summary>
	/// Emits <see cref="Particle"/> at a given rate and manages updating them.
	/// </summary>
	internal abstract class ParticleEmitter : Entity
	{
		/// <summary>
		/// Whether the <see cref="ParticleEmitter"/> is active.
		/// </summary>
		protected bool _active;

		/// <summary>
		/// The direction as a <see cref="Vector2"/> the <see cref="Particle"/> are emitted.
		/// </summary>
		protected Vector2 _direction;

		/// <summary>
		/// <see cref="IPhysics"/> system of rules applied to <see cref="Particle"/>.
		/// </summary>
		protected IPhysics _physics;

		/// <summary>
		/// <see cref="QuadTree{T}"/> managing <see cref="Particle"/>.
		/// </summary>
		protected QuadTree<EntityPhysics> _quadTree;

		/// <summary>
		/// Radius <see cref="Particle"/> can be born in.
		/// </summary>
		protected float _radius;

		/// <summary>
		/// Rate at which <see cref="Particle"/> are emitted.
		/// </summary>
		protected float _rate;

		/// <summary>
		/// Rate multiplier to enable different emitters to have different set rates.
		/// </summary>
		protected float _rateBase;

		/// <summary>
		/// Instantiates a <see cref="ParticleEmitter"/>.
		/// </summary>
		/// <param name="anchor"></param>
		/// <param name="radius"></param>
		/// <param name="layerDepth"></param>
		/// <param name="rate"></param>
		/// <param name="active"></param>
		public ParticleEmitter(
			Vector2 anchor,
			float radius,
			float layerDepth,
			float rate,
			bool active = false,
			IPhysics physics = null
		) : base(
			Origin.TopLeft,
			anchor,
			layerDepth,
			null,
			null)
		{
			_quadTree = new QuadTree<EntityPhysics>(
				new Rectangle(
					new Vector2(0, 0),
					RenderConstants.MinigameScreen.Width,
					RenderConstants.MinigameScreen.Height));
			_radius = radius;
			_rateBase = rate;
			_rate = rate;
			_direction = Vector2.Zero;
			_active = active;
			_physics = physics == null ? new FlockingPhysics(0.01f, 0.01f, 0.01f) : physics;

			SetDrawer(new ParticleEmitterDrawer(this));
			Timer.StartTimer($"{GetId()}-creation-cycle");
		}

		public void AddParticle()
		{
			var particle = CreateParticle();

			_quadTree.Insert(particle.GetAnchor(), particle);
		}

		public abstract Particle CreateParticle();

		public IList<EntityPhysics> GetEntities()
		{
			return _quadTree.Query();
		}

		public override string GetId()
		{
			return $"particle-emitter-{_id}";
		}

		public float GetRadius()
		{
			return _radius;
		}

		public float GetRate()
		{
			return _rate;
		}

		public override float GetTotalHeight()
		{
			return 0f;
		}

		public override float GetTotalWidth()
		{
			return 0f;
		}

		public bool IsActive()
		{
			return _active;
		}

		public void SetActive(bool state)
		{
			_active = state;
		}

		public void SetDirection(Vector2 direction)
		{
			_direction = VectorHelper.RadiansToVector(VectorHelper.VectorToRadians(direction) + (float) (Math.PI / 3));
		}

		public void SetRadius(float radius)
		{
			_radius = radius;
		}

		public void SetRate(float rate)
		{
			_rate = rate * _rateBase;
		}

		public override void Update()
		{
			base.Update();

			var particles = _quadTree.Query();

			if (_physics.HasIntangibleInteractions())
			{
				var results = _physics.IntangibleInteractions(_quadTree, null);
				_quadTree = (QuadTree<EntityPhysics>) results.Item1;
			}

			if (_physics.HasTangibleInteractions())
			{
				var results = _physics.TangibleInteractions(_quadTree, null);
				_quadTree = (QuadTree<EntityPhysics>) results.Item1;
			}

			if (_active && Timer.CheckTimer($"{GetId()}-creation-cycle") > _rate)
			{
				Timer.EndTimer($"{GetId()}-creation-cycle");
				Timer.StartTimer($"{GetId()}-creation-cycle");

				AddParticle();
			}
		}

		protected virtual Vector2 GetMaximumInitialVelocity()
		{
			return _direction;
		}

		protected virtual Vector2 GetMinimumInitialVelocity()
		{
			return _direction;
		}

		protected Vector2 GetPositionInCreationWindow()
		{
			return Vector2.Add(_anchor,
				new Vector2(MiscellaneousHelper.Random() * _radius, MiscellaneousHelper.Random() * _radius));
		}
	}
}