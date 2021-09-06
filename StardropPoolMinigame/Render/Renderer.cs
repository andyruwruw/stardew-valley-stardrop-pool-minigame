using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Scenes;
using System.Collections.Generic;

namespace StardropPoolMinigame.Render
{
    /// <summary>
    /// Renders entries onto the screen
    /// </summary>
    class Renderer
    {
        IList<IEntity> _entities;

        public Renderer()
        {
            this.InicializeStaticEntities();
        }

        /// <summary>
        /// Draws all entities for scenes
        /// </summary>
        /// <param name="batch">XNA Framework SpriteBatch</param>
        /// <param name="entering">Scene in entry transition</param>
        /// <param name="current">Current scene</param>
        /// <param name="exiting">Scene in exit transition</param>
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

            this.DrawStaticEntities(batch);

            if (entering != null)
            {
                this.DrawEntities(batch, entering.GetEntities());
            }
            if (current != null)
            {
                this.DrawEntities(batch, current.GetEntities());
            }
            if (exiting != null)
            {
                this.DrawEntities(batch, exiting.GetEntities());
            }

            batch.End();
        }

        /// <summary>
        /// Draws entries that are always present
        /// </summary>
        /// <param name="batch">XNA Framework SpriteBatch</param>
        private void DrawStaticEntities(SpriteBatch batch)
        {
            this.DrawEntities(batch, this._entities);
        }

        /// <summary>
        /// Draws the provided set of entries
        /// </summary>
        /// <param name="batch">XNA Framework SpriteBatch</param>
        /// <param name="entities">Entities to be drawn</param>
        private void DrawEntities(SpriteBatch batch, IList<IEntity> entities)
        {

            IList<IDrawer> drawers = GetDrawersFromEntities(entities);

            foreach (IDrawer drawer in drawers)
            {
                if (drawer.ShouldDraw())
                {
                    drawer.Draw(batch);
                }
            }
        }

        /// <summary>
        /// Retrieves list of drawers for a set of entries
        /// </summary>
        /// <param name="entities">Entities to be drawn</param>
        /// <returns>List of drawers</returns>
        private IList<IDrawer> GetDrawersFromEntities(IList<IEntity> entities)
        {
            IList<IDrawer> drawers = new List<IDrawer>();

            foreach (IEntity entity in entities)
            {
                drawers.Add(entity.GetDrawer());
            }

            return drawers;
        }

        /// <summary>
        /// Creates static entries
        /// </summary>
        private void InicializeStaticEntities()
        {
            this._entities = new List<IEntity>();

            // Background
            this._entities.Add(new Solid(
                new Primitives.Rectangle(
                    new Vector2(RenderConstants.AdjustedScreenWidthMargin(), RenderConstants.AdjustedScreenHeightMargin()),
                    (int)RenderConstants.AdjustedScreenWidth(),
                    (int)RenderConstants.AdjustedScreenHeight()),
                0.0000f,
                null,
                null,
                Color.Black,
                isRawCoords: true));

            // Foreground
            if (!DevConstants.DISABLE_MARGIN_SOLIDS)
            {
                this._entities.Add(new Solid(
                new Primitives.Rectangle(
                    new Vector2(0, 0),
                    (int)RenderConstants.AdjustedScreenWidthMargin(),
                    (int)RenderConstants.ViewportHeight()),
                0.9000f,
                null,
                null,
                Textures.Color.Solid.MARGIN,
                isRawCoords: true));

                this._entities.Add(new Solid(
                    new Primitives.Rectangle(
                        new Vector2(RenderConstants.AdjustedScreenWidthMargin() + RenderConstants.AdjustedScreenWidth(), 0),
                        (int)RenderConstants.AdjustedScreenWidthMargin(),
                        (int)RenderConstants.ViewportHeight()),
                    0.9000f,
                    null,
                    null,
                    Textures.Color.Solid.MARGIN,
                    isRawCoords: true));

                this._entities.Add(new Solid(
                    new Primitives.Rectangle(
                        new Vector2(RenderConstants.AdjustedScreenWidthMargin(), 0),
                        (int)RenderConstants.AdjustedScreenWidth(),
                        (int)RenderConstants.AdjustedScreenHeightMargin()),
                    0.9000f,
                    null,
                    null,
                    Textures.Color.Solid.MARGIN,
                    isRawCoords: true));

                this._entities.Add(new Solid(
                    new Primitives.Rectangle(
                        new Vector2(RenderConstants.AdjustedScreenWidthMargin(), RenderConstants.AdjustedScreenHeight() + RenderConstants.AdjustedScreenHeightMargin()),
                        (int)RenderConstants.AdjustedScreenWidth(),
                        (int)RenderConstants.AdjustedScreenHeightMargin()),
                    0.9000f,
                    null,
                    null,
                    Textures.Color.Solid.MARGIN,
                    isRawCoords: true));
            }
        }
    }
}
