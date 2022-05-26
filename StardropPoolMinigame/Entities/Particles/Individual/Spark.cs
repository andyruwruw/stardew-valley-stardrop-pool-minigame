using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
	internal class Spark : Particle
	{
		private readonly IFilter _sparkAnimation;

		public Spark(
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
			_sparkAnimation = new SparkAnimation(GetId());
			_filters.Add(_sparkAnimation);

			SetDrawer(new SparkDrawer(this));
		}

		public override string GetId()
		{
			return $"particle-spark-{_id}";
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