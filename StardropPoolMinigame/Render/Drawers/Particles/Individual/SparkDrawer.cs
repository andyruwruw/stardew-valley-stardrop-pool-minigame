using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;

namespace StardropPoolMinigame.Render.Drawers
{
	internal class SparkDrawer : Drawer
	{
		public SparkDrawer(Spark spark) : base(spark)
		{
		}

		public override bool ShouldDraw()
		{
			return _entity.GetTransitionState() != TransitionState.Dead;
		}

		protected override void DrawDebugVisuals(SpriteBatch batch)
		{
			DrawDebugPoint(batch, _entity.GetAnchor());
			DrawDebugCircle(batch, _entity.GetAnchor(),
				(int) Math.Round(((EntityPhysics) _entity).GetIntangibleRadius()), Color.Purple);
		}

		protected override Color GetRawColor()
		{
			return new Color(200, 200, 200, 200);
		}

		protected override Vector2 GetRawDestination()
		{
			var topLeft = Vector2.Add(_entity.GetTopLeft(),
				new Vector2(GetRawSource().Width / 2, GetRawSource().Height / 2));

			return new Vector2(
				topLeft.X * RenderConstants.TileScale() + RenderConstants.AdjustedScreen.Margin.Width(),
				topLeft.Y * RenderConstants.TileScale() + RenderConstants.AdjustedScreen.Margin.Height());
		}

		protected override Vector2 GetRawOrigin()
		{
			return new Vector2(GetRawSource().Width / 2, GetRawSource().Height / 2);
		}

		protected override float GetRawRotation()
		{
			return (float) (VectorHelper.VectorToRadians(((EntityPhysics) _entity).GetVelocity()) + Math.PI / 3f);
		}

		protected override Rectangle GetRawSource()
		{
			return Textures.Particle.Spark.FRAME_1;
		}
	}
}