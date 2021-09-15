using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;
using System;

namespace StardropPoolMinigame.Render.Drawers
{
    internal class SparkDrawer : Drawer
    {
        public SparkDrawer(Spark spark) : base(spark)
        {
        }

        public override bool ShouldDraw()
        {
            return this._entity.GetTransitionState() != TransitionState.Dead;
        }

        protected override void DrawDebugVisuals(SpriteBatch batch)
        {
            DrawDebugPoint(batch, this._entity.GetAnchor());
            DrawDebugCircle(batch, this._entity.GetAnchor(), (int)Math.Round(((Spark)this._entity).GetPerception().GetRadius()), Color.Purple);
        }

        protected override Color GetRawColor()
        {
            return new Color(200, 200, 200, 200);
        }

        protected override Vector2 GetRawDestination()
        {
            Vector2 topLeft = Vector2.Add(this._entity.GetTopLeft(), new Vector2(this.GetRawSource().Width / 2, this.GetRawSource().Height / 2));
            return new Vector2(
                topLeft.X * RenderConstants.TileScale() + RenderConstants.AdjustedScreenWidthMargin(),
                topLeft.Y * RenderConstants.TileScale() + RenderConstants.AdjustedScreenHeightMargin());
        }

        protected override Vector2 GetRawOrigin()
        {
            return new Vector2(this.GetRawSource().Width / 2, this.GetRawSource().Height / 2);
        }

        protected override float GetRawRotation()
        {
            return (float)(Operators.VectorToRadians(((EntityBoid)this._entity).GetVelocity()) + Math.PI / 3f);
        }

        protected override Rectangle GetRawSource()
        {
            return Textures.Particle.Spark.FRAME_1;
        }
    }
}