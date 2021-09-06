using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Helpers;
using System;

namespace StardropPoolMinigame.Render.Drawers
{
    class SparkDrawer : Drawer
    {
        public SparkDrawer(Spark spark) : base(spark)
        {
        }

        protected override void DrawDebugVisuals(SpriteBatch batch)
        {
            DrawDebugPoint(batch, this._entity.GetAnchor());
        }

        protected override Rectangle GetRawSource()
        {
            return Textures.Particle.Spark.FRAME_1;
        }

        protected override Vector2 GetRawDestination()
        {
            Vector2 topLeft = Vector2.Add(this._entity.GetTopLeft(), new Vector2(this.GetRawSource().Width / 2, this.GetRawSource().Height / 2));
            return new Vector2(
                topLeft.X * RenderConstants.TileScale() + RenderConstants.AdjustedScreenWidthMargin(),
                topLeft.Y * RenderConstants.TileScale() + RenderConstants.AdjustedScreenHeightMargin());
        }

        protected override float GetRawRotation()
        {
            return (float)(Operators.VectorToRadians(((EntityBoid)this._entity).GetVelocity()) + Math.PI * 1.5f);
        }

        protected override Vector2 GetRawOrigin()
        {
            return new Vector2(this.GetRawSource().Width / 2, this.GetRawSource().Height / 2);
        }
    }
}
