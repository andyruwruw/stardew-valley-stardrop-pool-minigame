using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
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

        public void Draw(
            SpriteBatch batch,
            IScene entering,
            IScene current,
            IScene exiting)
        {
            batch.Begin(
                SpriteSortMode.FrontToBack,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                null,
                null);

            this.DrawBackground(batch);
            this.DrawEntities(
                batch,
                entering,
                current,
                exiting);
            this.DrawForeground(batch);

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

        private void DrawForeground(SpriteBatch batch)
        {
            batch.Draw(
                Game1.staminaRect,
                new Rectangle(
                    0,
                    0,
                    (int)RenderConstants.AdjustedScreenWidthMargin(),
                    (int)RenderConstants.ViewportHeight()),
                Game1.staminaRect.Bounds,
                Textures.MINIGAME_MARGIN_BACKGROUND_COLOR,
                0f,
                Vector2.Zero,
                SpriteEffects.None,
                1.0000f);

            batch.Draw(
                Game1.staminaRect,
                new Rectangle(
                    (int)(RenderConstants.AdjustedScreenWidthMargin() + RenderConstants.AdjustedScreenWidth()),
                    0,
                    (int)RenderConstants.AdjustedScreenWidthMargin(),
                    (int)RenderConstants.ViewportHeight()),
                Game1.staminaRect.Bounds,
                Textures.MINIGAME_MARGIN_BACKGROUND_COLOR,
                0f,
                Vector2.Zero,
                SpriteEffects.None,
                1.0000f);

            batch.Draw(
                Game1.staminaRect,
                new Rectangle(
                    (int)RenderConstants.AdjustedScreenWidthMargin(),
                    0,
                    (int)RenderConstants.AdjustedScreenWidth(),
                    (int)RenderConstants.AdjustedScreenHeightMargin()),
                Game1.staminaRect.Bounds,
                Textures.MINIGAME_MARGIN_BACKGROUND_COLOR,
                0f,
                Vector2.Zero,
                SpriteEffects.None,
                1.0000f);

            batch.Draw(
                Game1.staminaRect,
                new Rectangle(
                    (int)(RenderConstants.AdjustedScreenWidthMargin() + RenderConstants.AdjustedScreenWidth()),
                    (int)(RenderConstants.AdjustedScreenHeightMargin() + RenderConstants.AdjustedScreenHeight()),
                    (int)RenderConstants.AdjustedScreenWidth(),
                    (int)RenderConstants.AdjustedScreenHeightMargin()),
                Game1.staminaRect.Bounds,
                Textures.MINIGAME_MARGIN_BACKGROUND_COLOR,
                0f,
                Vector2.Zero,
                SpriteEffects.None,
                1.0000f);
        }

        private void DrawEntities(
            SpriteBatch batch,
            IScene entering,
            IScene current,
            IScene exiting)
        {
            if (entering != null)
            {
                IList<IDrawer> drawers = GetDrawersFromEntities(GetEntitiesFromScene(entering));

                foreach (IDrawer drawer in drawers)
                {
                    drawer.Draw(batch);
                }
            }
            if (current != null)
            {
                IList<IDrawer> drawers = GetDrawersFromEntities(GetEntitiesFromScene(current));

                foreach (IDrawer drawer in drawers)
                {
                    drawer.Draw(batch);
                }
            }
            if (exiting != null)
            {
                IList<IDrawer> drawers = GetDrawersFromEntities(GetEntitiesFromScene(exiting));

                foreach (IDrawer drawer in drawers)
                {
                    drawer.Draw(batch);
                }
            }
        }

        private IList<IEntity> GetEntitiesFromScene(IScene scene)
        {
            return scene.GetEntities();
        }

        private IList<IDrawer> GetDrawersFromEntities(IList<IEntity> entities)
        {
            IList<IDrawer> drawers = new List<IDrawer>();

            foreach (IEntity entity in entities)
            {
                drawers.Add(entity.GetDrawer());
            }

            return drawers;
        }
    }
}
