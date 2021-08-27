using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StardropPoolMinigame.Render.Drawers
{
    interface IDrawer
    {
        void Draw(
            SpriteBatch batch,
            Vector2? overrideDestination = null,
            Rectangle? overrideSource = null,
            Color? overrideColor = null,
            float? overrideRotation = null,
            Vector2? overrideOrigin = null,
            float? overrideScale = null,
            SpriteEffects? overrideEffects = null,
            float? overrideLayerDepth = null);

        bool ShouldDraw();
    }
}
