using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardropPoolMinigame.Entities;

namespace StardropPoolMinigame.Render.Drawers
{
    class SolidDrawer : Drawer
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
                this.GetTileSheet(),
                ((Solid)this._entity).GetXnaDestination(),
                this.GetSource(overrideSource),
                this.GetColor(overrideColor),
                this.GetRotation(overrideRotation),
                this.GetOrigin(overrideOrigin),
                this.GetEffects(overrideEffects),
                this.GetLayerDepth(overrideLayerDepth));
        }

        protected override Texture2D GetTileSheet()
        {
            return Game1.staminaRect;
        }

        protected override Rectangle GetRawSource()
        {
            return Game1.staminaRect.Bounds;
        }

        protected override Color GetRawColor()
        {
            return ((Solid)this._entity).GetColor();
        }
    }
}
