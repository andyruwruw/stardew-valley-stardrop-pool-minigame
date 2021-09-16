using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
	internal class PurpleWisp : Particle
	{
		public PurpleWisp(
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
			return $"particle-purple-whisp-{_id}";
		}

		public override float GetTotalHeight()
		{
			return Textures.Particle.PurpleWhisp.FRAME_1.Height;
		}

		public override float GetTotalWidth()
		{
			return Textures.Particle.PurpleWhisp.FRAME_1.Width;
		}
	}
}