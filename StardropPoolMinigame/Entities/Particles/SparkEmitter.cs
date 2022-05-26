using System;
using Microsoft.Xna.Framework;
using StardropPoolMinigame.Behaviors.Physics;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Helpers;

namespace StardropPoolMinigame.Entities
{
	internal class SparkEmitter : ParticleEmitter
	{
		public SparkEmitter(
			Vector2 anchor,
			float radius,
			float layerDepth,
			float rate
		) : base(
			anchor,
			radius,
			layerDepth,
			rate,
			false,
			new FlockingPhysics(
				GameConstants.Particle.Spark.AlignmentStrength,
				GameConstants.Particle.Spark.SeparationStrength,
				GameConstants.Particle.Spark.CohesionStrength))
		{
		}

		public override Particle CreateParticle()
		{
			var startingAcceleration = new Vector2(
				MiscellaneousHelper.Random() * (GetMaximumInitialVelocity().X - GetMinimumInitialVelocity().X) +
				GetMinimumInitialVelocity().X,
				MiscellaneousHelper.Random() * (GetMaximumInitialVelocity().Y - GetMinimumInitialVelocity().Y) +
				GetMinimumInitialVelocity().Y);

			return new Spark(
				GetPositionInCreationWindow(),
				_layerDepth,
				TransitionConstants.Game.Sparks.Entering(),
				TransitionConstants.Game.Sparks.Exiting(),
				0f,
				null,
				startingAcceleration,
				GameConstants.Particle.Spark.PerceptionRadius);
		}

		public override string GetId()
		{
			return $"spark-emitter-{_id}";
		}

		protected override Vector2 GetMaximumInitialVelocity()
		{
			return VectorHelper.RadiansToVector(VectorHelper.VectorToRadians(_direction) - (float) (Math.PI / 3));
		}

		protected override Vector2 GetMinimumInitialVelocity()
		{
			return VectorHelper.RadiansToVector(VectorHelper.VectorToRadians(_direction) + (float) (Math.PI / 3));
		}
	}
}