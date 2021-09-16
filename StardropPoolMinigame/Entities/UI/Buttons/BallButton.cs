﻿using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame.Entities
{
    internal class BallButton : Entity
    {
        private Ball _ball;

        private int _maxWidth;

        private Text _text;

        private string _textString;

        /// <summary>
        /// Creates button with rotating ball on hover.
        /// </summary>
        public BallButton(
            Origin origin,
            Vector2 anchor,
            float layerDepth,
            IFilter enteringTransition,
            IFilter exitingTransition,
            string text,
            int maxWidth = int.MaxValue,
            int ballNumber = 1
        ) : base(
            origin,
            anchor,
            layerDepth,
            enteringTransition,
            exitingTransition)
        {
            this._textString = text;
            this._maxWidth = maxWidth;

            this._text = new Text(
                Origin.TopLeft,
                new Vector2(this.GetTopLeft().X + (GameConstants.Ball.Radius * 2) + RenderConstants.Entities.BallButton.InnerPadding, anchor.Y),
                layerDepth,
                enteringTransition,
                exitingTransition,
                text,
                maxWidth,
                1f,
                false,
                true);

            this._ball = new Ball(
                new Vector2(this.GetTopLeft().X + GameConstants.Ball.Radius, this.GetTopLeft().Y + (this._text.GetTotalHeight() / 2)),
                layerDepth,
                enteringTransition,
                exitingTransition,
                ballNumber,
                new Vector2(0, -30));

            this.SetDrawer(new BallButtonDrawer(this));
        }

        public override void ClickCallback()
        {
            Sound.PlaySound(SoundConstants.Feedback.BottonPress);
        }

        public Ball GetBall()
        {
            return this._ball;
        }

        public override string GetId()
        {
            return $"ball-button-{this._id}";
        }

        public Text GetText()
        {
            return this._text;
        }

        public override float GetTotalHeight()
        {
            return this._text.GetTotalHeight();
        }

        public override float GetTotalWidth()
        {
            return (int)((GameConstants.Ball.Radius * 2) + RenderConstants.Entities.BallButton.InnerPadding + this._maxWidth);
        }

        public override void HoverCallback()
        {
            Sound.PlaySound(SoundConstants.Feedback.ButtonHover);
        }

        public override void SetTransitionState(TransitionState transitionState, bool start = false)
        {
            base.SetTransitionState(transitionState, start);
            this._ball.SetTransitionState(transitionState, true);
            this._text.SetTransitionState(transitionState, true);
        }

        public override void Update()
        {
            base.Update();

            if (this.IsHovered())
            {
                this._ball.GetOrientation().Roll(new Vector2(GameConstants.BallButton.HoverRotationalSpeed, 0));
            }
        }
    }
}