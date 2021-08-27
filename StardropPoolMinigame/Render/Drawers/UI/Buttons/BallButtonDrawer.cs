using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Entities;

namespace StardropPoolMinigame.Render.Drawers
{
    class BallButtonDrawer : Drawer
    {
        public BallButtonDrawer(BallButton button) : base(button)
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
                overrideColor,
                overrideRotation,
                overrideOrigin,
                overrideScale,
                overrideEffects,
                overrideLayerDepth);
      
            Ball ball = ((BallButton)this._entity).GetBall();
            ball.GetDrawer().Draw(batch);
        }

        protected override Rectangle GetRawSource()
        {
            return Textures.LOWERCASE_A_BOUNDS;
        }

        protected override Color GetRawColor()
        {
            if (((EntityHoverable)this._entity).IsHovered())
            {
                return Textures.TEXT_HOVER_COLOR;
            }
            return Color.White;
        }
    }
}
