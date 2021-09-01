using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;

namespace StardropPoolMinigame.Render.Drawers
{
    class FloorTilesDrawer : Drawer
    {
        public FloorTilesDrawer(FloorTiles floorTiles) : base(floorTiles)
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
            int rows = (int)Math.Ceiling((double)(RenderConstants.MinigameScreen.HEIGHT / this.GetSource(overrideSource).Height));
            int cols = (int)Math.Ceiling((double)(RenderConstants.MinigameScreen.WIDTH / this.GetSource(overrideSource).Width));
            
            for (int i = 0; i <= rows; i++)
            {
                for (int j = 0; j <= cols; j++)
                {
                    Vector2 destination = new Vector2(
                        j * this.GetSource(overrideSource).Width * this.GetScale() + RenderConstants.AdjustedScreenWidthMargin(),
                        i * this.GetSource(overrideSource).Height * this.GetScale() + RenderConstants.AdjustedScreenHeightMargin());

                    this.DrawSingleFloorTile(
                        batch,
                        destination,
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

        protected override Rectangle GetRawSource()
        {
            return Textures.FLOOR_TILES;
        }

        private void DrawSingleFloorTile(
            SpriteBatch batch,
            Vector2 destination,
            Rectangle? overrideSource = null,
            Color? overrideColor = null,
            float? overrideRotation = null,
            Vector2? overrideOrigin = null,
            float? overrideScale = null,
            SpriteEffects? overrideEffects = null,
            float? overrideLayerDepth = null)
        {
            batch.Draw(
                this.GetTileset(),
                destination,
                this.GetSource(overrideSource),
                this.GetColor(overrideColor),
                this.GetRotation(overrideRotation),
                this.GetOrigin(overrideOrigin),
                this.GetScale(overrideScale),
                this.GetEffects(overrideEffects),
                this.GetLayerDepth(overrideLayerDepth));
        }
    }
}
