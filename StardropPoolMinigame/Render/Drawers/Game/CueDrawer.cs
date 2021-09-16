using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Helpers;

namespace StardropPoolMinigame.Render.Drawers
{
    internal class CueDrawer : Drawer
    {
        public CueDrawer(Cue cue) : base(cue)
        {
        }

        public override void Draw(SpriteBatch batch, Vector2? overrideDestination = null, Rectangle? overrideSource = null, Color? overrideColor = null, float? overrideRotation = null, Vector2? overrideOrigin = null, float? overrideScale = null, SpriteEffects? overrideEffects = null, float? overrideLayerDepth = null)
        {
            base.Draw(batch, overrideDestination, overrideSource, overrideColor, overrideRotation, overrideOrigin, overrideScale, overrideEffects, overrideLayerDepth);

            ((Cue)this._entity).GetParticleEmitter().GetDrawer().Draw(batch, overrideDestination, overrideSource, overrideColor, overrideRotation, overrideOrigin, overrideScale, overrideEffects, overrideLayerDepth);
        }

        protected override void DrawDebugVisuals(SpriteBatch batch)
        {
            DrawDebugPoint(batch, this._entity.GetAnchor());
        }

        protected override Vector2 GetRawDestination()
        {
            return new Vector2(
                this._entity.GetAnchor().X * RenderConstants.TileScale() + RenderConstants.AdjustedScreen.Margin.Width(),
                this._entity.GetAnchor().Y * RenderConstants.TileScale() + RenderConstants.AdjustedScreen.Margin.Height());
        }

        protected override Vector2 GetRawOrigin()
        {
            return new Vector2(0, this._entity.GetTotalHeight() / 2);
        }

        protected override float GetRawRotation()
        {
            return VectorHelper.VectorToRadians(((Cue)this._entity).GetAngle());
        }

        protected override Rectangle GetRawSource()
        {
            return Textures.Cue.BASIC;
        }
    }
}