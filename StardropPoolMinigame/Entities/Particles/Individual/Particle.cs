using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
	internal class Particle : EntityPhysics
	{
		public Particle(
			Origin origin,
			Vector2 anchor,
			float layerDepth,
			IFilter enteringTransition,
			IFilter exitingTransition,
			float mass = 0f,
			Vector2? startingVelocity = null,
			Vector2? startingAcceleration = null,
			float intangibleRadius = 0f
		) : base(
			origin,
			anchor,
			layerDepth,
			enteringTransition,
			exitingTransition,
			mass,
			startingVelocity,
			startingAcceleration,
			intangibleRadius)
		{
		}

		public override string GetId()
		{
			return $"generic-particle-{_id}";
		}

		public override float GetTotalHeight()
		{
			return Textures.Particle.Spark.FRAME_1.Height;
		}

		public override float GetTotalWidth()
		{
			return Textures.Particle.Spark.FRAME_1.Width;
		}
	}
}