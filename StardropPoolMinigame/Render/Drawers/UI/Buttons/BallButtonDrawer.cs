using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Render.Filters;
using System.Collections.Generic;

namespace StardropPoolMinigame.Render.Drawers
{
    class BallButtonDrawer : Drawer
    {
        public BallButtonDrawer(BallButton button) : base(button)
        {
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(
                this.GetTileSheet(),
                this.GetTextDestination(),
                this.GetSource(),
                this.GetColor(),
                this.GetRotation(),
                this.GetOrigin(),
                this.GetScale(),
                this.GetEffects(),
                this.GetLayerDepth());

            Ball ball = ((BallButton)this._entity).GetBall();
            ball.GetDrawer().Draw(batch);
        }

        protected override Rectangle GetRawSource()
        {
            if (((EntityHoverable)this._entity).IsHovered())
            {
                return ((BallButton)this._entity).GetTextBounds();
            }
            return ((BallButton)this._entity).GetTextBounds();
        }

        protected override Color GetRawColor()
        {
            if (((EntityHoverable)this._entity).IsHovered())
            {
                return Textures.TEXT_HOVER_COLOR;
            }
            return Color.White;
        }

        private Vector2 GetTextDestination()
        {
            Vector2 topLeft = this._entity.GetTopLeft();
            Vector2 destination = new Vector2(
                (topLeft.X + (GameConstants.BALL_RADIUS * 2) + RenderConstants.BALL_BUTTON_INNER_PADDING) * RenderConstants.TileScale() + RenderConstants.AdjustedScreenWidthMargin(),
                topLeft.Y * RenderConstants.TileScale() + RenderConstants.AdjustedScreenHeightMargin());

            IList<IFilter> filters = this._entity.GetFilters();

            foreach (IFilter filter in filters)
            {
                destination = filter.ExecuteDestination(destination);
            }

            return destination;
        }
    }
}
