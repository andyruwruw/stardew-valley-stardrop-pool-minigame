using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using System.Collections.Generic;

namespace StardropPoolMinigame.Render.Drawers
{
    internal class TableDrawer : Drawer
    {
        public TableDrawer(Table table) : base(table)
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
            IList<IList<TableSegment>> grid = ((Table)this._entity).GetTableSegments();

            for (int i = 0; i < grid.Count; i++)
            {
                for (int j = 0; j < grid[i].Count; j++)
                {
                    if (grid[i][j] != null)
                    {
                        grid[i][j].GetDrawer().Draw(
                            batch,
                            overrideDestination,
                            overrideSource,
                            overrideColor,
                            overrideRotation,
                            overrideOrigin,
                            overrideScale,
                            overrideEffects,
                            overrideLayerDepth);
                    }
                }
            }
        }

        protected override void DrawDebugVisuals(SpriteBatch batch)
        {
            DrawDebugLine(batch, Vector2.Zero, new Vector2(RenderConstants.MinigameScreen.Width, RenderConstants.MinigameScreen.Height), Color.Coral, 1);
        }

        protected override Rectangle GetRawSource()
        {
            return Textures.Table.Edge.Front.NORTH;
        }
    }
}