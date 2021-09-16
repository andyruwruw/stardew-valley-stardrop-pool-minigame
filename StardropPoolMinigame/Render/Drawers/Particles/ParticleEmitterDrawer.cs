using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;

namespace StardropPoolMinigame.Render.Drawers
{
	internal class ParticleEmitterDrawer : Drawer
	{
		public ParticleEmitterDrawer(ParticleEmitter emitter) : base(emitter)
		{
		}

		public override void Draw(SpriteBatch batch, Vector2? overrideDestination = null,
			Rectangle? overrideSource = null, Color? overrideColor = null, float? overrideRotation = null,
			Vector2? overrideOrigin = null, float? overrideScale = null, SpriteEffects? overrideEffects = null,
			float? overrideLayerDepth = null)
		{
			var particles = ((ParticleEmitter) _entity).GetEntities();

			foreach (var particle in particles)
				particle.GetDrawer().Draw(
					batch,
					overrideDestination,
					overrideSource,
					overrideColor,
					overrideRotation,
					overrideOrigin,
					overrideScale,
					overrideEffects,
					overrideLayerDepth);

			if (DevConstants.DebugVisuals) DrawDebugVisuals(batch);
		}

		protected override void DrawDebugVisuals(SpriteBatch batch)
		{
			DrawDebugPoint(batch, _entity.GetAnchor());
			DrawDebugCircle(batch, _entity.GetAnchor(), (int) Math.Round(((ParticleEmitter) _entity).GetRadius()),
				Color.Red);
		}

		protected override Rectangle GetRawSource()
		{
			return Textures.Particle.Spark.FRAME_1;
		}
	}
}