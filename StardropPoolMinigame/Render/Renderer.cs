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
                Color.LightGoldenrodYellow,
                0f,
                Vector2.Zero,
                SpriteEffects.None,
                0.0001f);
        }

        private void DrawEntities(SpriteBatch batch, IScene entering, IScene current, IScene exiting)
        {
            IList<IDrawer> enteringEntities = entering != null ? entering.GetRenderer().GetEntities() : new List<IDrawer>();
            IList<IDrawer> currentEntities = current != null ? current.GetRenderer().GetEntities() : new List<IDrawer>();
            IList<IDrawer> exitingEntities = exiting != null ? exiting.GetRenderer().GetEntities() : new List<IDrawer>();

            foreach (IDrawer drawer in enteringEntities)
            {
                drawer.Draw(batch);
            }

            foreach (IDrawer drawer in currentEntities)
            {
                drawer.Draw(batch);
            }

            foreach (IDrawer drawer in exitingEntities)
            {
                drawer.Draw(batch);
            }
        }
    }
}
