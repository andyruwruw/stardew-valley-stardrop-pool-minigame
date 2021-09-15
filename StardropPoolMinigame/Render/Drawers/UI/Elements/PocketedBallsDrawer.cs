using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;

namespace StardropPoolMinigame.Render.Drawers
{
    internal class PocketedBallsDrawer : Drawer
    {
        public PocketedBallsDrawer(PocketedBalls pocketedBalls) : base(pocketedBalls)
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
            base.Draw(
                batch,
                Vector2.Add(this.GetRawDestination(), new Vector2(0, Textures.PocketedBalls.SUPPORTS.Height)),
                overrideSource,
                overrideColor,
                overrideRotation,
                overrideOrigin,
                overrideScale,
                overrideEffects,
                overrideLayerDepth);

            batch.Draw(
                this.GetTileset(),
                this.GetDestination(Vector2.Add(
                    this.GetRawDestination(),
                    new Vector2(
                        RenderConstants.Entities.PocketedBalls.SUPPORT_PADDING * RenderConstants.TileScale(),
                        RenderConstants.Entities.PocketedBalls.SUPPORT_UPPER_MARGIN * RenderConstants.TileScale()))),
                Textures.PocketedBalls.SUPPORTS,
                this.GetColor(),
                this.GetRotation(),
                this.GetOrigin(),
                this.GetScale(),
                this.GetEffects(),
                this.GetLayerDepth());

            batch.Draw(
                this.GetTileset(),
                this.GetDestination(Vector2.Add(
                    this.GetRawDestination(),
                    new Vector2(
                        ((Textures.PocketedBalls.BORDER_BOX.Width) - Textures.PocketedBalls.SUPPORTS.Width + (RenderConstants.Entities.PocketedBalls.SUPPORT_PADDING * -1)) * RenderConstants.TileScale(),
                        RenderConstants.Entities.PocketedBalls.SUPPORT_UPPER_MARGIN * RenderConstants.TileScale()))),
                Textures.PocketedBalls.SUPPORTS,
                this.GetColor(),
                this.GetRotation(),
                this.GetOrigin(),
                this.GetScale(),
                this.GetEffects(),
                this.GetLayerDepth());

            foreach (Ball ball in ((PocketedBalls)this._entity).GetBalls())
            {
                ball.GetDrawer().Draw(batch);
            }
        }

        protected override Rectangle GetRawSource()
        {
            return Textures.PocketedBalls.BORDER_BOX;
        }
    }
}