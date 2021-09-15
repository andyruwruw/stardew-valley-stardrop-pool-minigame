using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardropPoolMinigame.Entities;

namespace StardropPoolMinigame.Render.Drawers
{
    internal class SolidDrawer : Drawer
    {
        public SolidDrawer(Solid solid) : base(solid)
        {
        }

        public override void Draw(
            SpriteBatch batch,
            Vector2? overrideDestination = null,
            Rectangle? overrideSource = null,
            Color? overrideColor = null,
            float? overrideRotation = null,
            Vector2? overrideOrigin = null,
            float? overrideScale = null,
            SpriteEffects? overrideEffects = null,
            float? overrideLayerDepth = null)
        {
            batch.Draw(
                this.GetTileset(),
                ((Solid)this._entity).IsRawCoords() ? ((Solid)this._entity).GetXnaDestination() : ((Solid)this._entity).GetRawXnaDestination(),
                this.GetSource(overrideSource),
                this.GetColor(overrideColor),
                this.GetRotation(overrideRotation),
                this.GetOrigin(overrideOrigin),
                this.GetEffects(overrideEffects),
                this.GetLayerDepth(overrideLayerDepth));
        }

        protected override Color GetRawColor()
        {
            return ((Solid)this._entity).GetColor();
        }

        protected override Rectangle GetRawSource()
        {
            return Game1.staminaRect.Bounds;
        }

        protected override Texture2D GetTileset()
        {
            return Game1.staminaRect;
        }
    }
}