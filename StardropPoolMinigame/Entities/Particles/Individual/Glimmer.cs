using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
	internal class Glimmer : Particle
	{
		public Glimmer(
			Vector2 anchor,
			float layerDepth,
			IFilter enteringTransition,
			IFilter exitingTransition,
			float mass,
			Vector2? startingVelocity = null,
			Vector2? startingAcceleration = null,
			float intangibleRadius = 0f
		) : base(
			Origin.CenterCenter,
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
			return $"particle-glimmer-{_id}";
		}

		public override float GetTotalHeight()
		{
			return Textures.Particle.Glimmer.FRAME_1.Height;
		}

		public override float GetTotalWidth()
		{
			return Textures.Particle.Glimmer.FRAME_1.Width;
		}
	}
}