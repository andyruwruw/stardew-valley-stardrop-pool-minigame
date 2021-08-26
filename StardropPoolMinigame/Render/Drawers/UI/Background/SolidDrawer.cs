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

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(
                this.GetTileSheet(),
                ((Solid)this._entity).GetXnaDestination(),
                this.GetSource(),
                this.GetColor(),
                this.GetRotation(),
                this.GetOrigin(),
                this.GetEffects(),
                this.GetLayerDepth());
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
