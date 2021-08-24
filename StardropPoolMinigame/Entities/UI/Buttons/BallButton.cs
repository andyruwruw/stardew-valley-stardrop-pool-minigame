using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Drawers;

namespace StardropPoolMinigame.Entities
{
    class BallButton : EntityHoverable
    {
        private Ball _ball;

        private Rectangle _textBounds;

        /// <summary>
        /// Creates button with rotating ball on hover.
        /// </summary>
        /// <param name="anchor">Top left anchor</param>
        /// <param name="textBounds">Bounds for text texture</param>
        /// <param name="ballNumber">Ball to be displayed</param>
        public BallButton(Origin origin, Vector2 anchor, float layerDepth, Rectangle textBounds, int ballNumber) : base(origin, anchor, layerDepth)
        {
            this._textBounds = textBounds;
            this._ball = new Ball(
                new Vector2(this.GetTopLeft().X + GameConstants.BALL_RADIUS, this.GetTopLeft().Y + (textBounds.Height / 2)),
                layerDepth,
                ballNumber,
                new Vector2(0, -30));
        }

        public override void Update()
        {
            this.UpdateHoverable();

            if (this.IsHovered())
            {
                this._ball.GetOrientation().Roll(new Vector2(GameConstants.BALL_BUTTON_HOVER_ROTATIONAL_SPEED, 0));
            }
        }

        public Ball GetBall()
        {
            return this._ball;
        }

        public Rectangle GetTextBounds()
        {
            return this._textBounds;
        }

        public override IDrawer GetDrawer()
        {
            return new BallButtonDrawer(this);
        }

        public override string GetId()
        {
            return $"ball-button-{this._id}";
        }

        public override float GetTotalWidth()
        {
            return (int)((GameConstants.BALL_RADIUS * 2) + RenderConstants.BALL_BUTTON_INNER_PADDING + this._textBounds.Width);
        }

        public override float GetTotalHeight()
        {
            return this._textBounds.Height;
        }
    }
}
