using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Entities;

namespace StardropPoolMinigame.Render.Drawers
{
    class ButtonDrawer : Drawer
    {
        public ButtonDrawer(Button button) : base(button)
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
            ((Button)this._entity).GetText().GetDrawer().Draw(
                batch,
                overrideDestination,
                overrideSource,
                this.GetRawColor(),
                overrideRotation,
                overrideOrigin,
                overrideScale,
                overrideEffects,
                overrideLayerDepth);
        }

        protected override Rectangle GetRawSource()
        {
            return Textures.Characters.LOWERCASE_A;
        }

        protected override Color GetRawColor()
        {
            if (((Button)this._entity).IsDisabled())
            {
                return Textures.Color.Solid.DISABLED;
            }
            if (((EntityHoverable)this._entity).IsHovered())
            {
                return Textures.Color.Solid.HOVER_ACCENT;
            }
            return Color.White;
        }
    }
}
