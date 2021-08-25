using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;

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
        public BallButton(
            Origin origin,
            Vector2 anchor,
            float layerDepth,
            IFilter enteringTransition,
            IFilter exitingTransition,
            Rectangle textBounds,
            int ballNumber
        ) : base(
            origin,
            anchor,
            layerDepth,
            enteringTransition,
            exitingTransition)
        {
            this._textBounds = textBounds;
            this._ball = new Ball(
                new Vector2(this.GetTopLeft().X + GameConstants.BALL_RADIUS, this.GetTopLeft().Y + (textBounds.Height / 2)),
                layerDepth,
                enteringTransition,
                exitingTransition,
                ballNumber,
                new Vector2(0, -30));

            this.SetDrawer(new BallButtonDrawer(this));
        }

        public override void Update()
        {
            this.UpdateHoverable();
            this.UpdateTransitionState();

            if (this.IsHovered())
            {
                this._ball.GetOrientation().Roll(new Vector2(GameConstants.BALL_BUTTON_HOVER_ROTATIONAL_SPEED, 0));
            }
        }

        public override IDrawer GetDrawer()
        {
            return this._drawer;
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

        public override void ClickCallback()
        {
            Sound.PlaySound(SoundConstants.BOTTON_PRESS);
        }

        protected override void HoveredCallback()
        {
            Sound.PlaySound(SoundConstants.BUTTON_HOVER);
        }

        public Ball GetBall()
        {
            return this._ball;
        }

        public Rectangle GetTextBounds()
        {
            return this._textBounds;
        }
    }
}
