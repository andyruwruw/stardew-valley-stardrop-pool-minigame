using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Scenes;
using System.Collections.Generic;

namespace StardropPoolMinigame.Render
{
    class Renderer
    {
        public Renderer()
        {
        }

        public void Draw(SpriteBatch batch, IScene entering, IScene current, IScene exiting)
        {
            batch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp, null, null);

            this.DrawBackground(batch);
            this.DrawEntities(batch, entering, current, exiting);

            batch.End();
        }

        private void DrawBackground(SpriteBatch batch)
        {
            batch.Draw(
                Game1.staminaRect,
                new Rectangle(
                    (int)RenderConstants.AdjustedScreenWidthMargin(),
                    (int)RenderConstants.AdjustedScreenHeightMargin(),
                    (int)RenderConstants.AdjustedScreenWidth(),
                    (int)RenderConstants.AdjustedScreenHeight()),
                Game1.staminaRect.Bounds,
                Color.Black,
                0f,
                Vector2.Zero,
                SpriteEffects.None,
                0.0000f);
        }

        private void DrawEntities(SpriteBatch batch, IScene entering, IScene current, IScene exiting)
        {
            if (entering != null)
            {
                entering.GetRenderer().Draw(batch);
            }
            if (current != null)
            {
                current.GetRenderer().Draw(batch);
            }
            if (exiting != null)
            {
                exiting.GetRenderer().Draw(batch);
            }
        }
    }
}
