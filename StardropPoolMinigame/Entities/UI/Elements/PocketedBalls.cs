using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Filters;
using System.Collections.Generic;

namespace StardropPoolMinigame.Entities.UI.Background
{
    class PocketedBalls : EntityStatic
    {
        private IList<Ball> _balls;

        public PocketedBalls(
            Origin origin,
            Vector2 anchor,
            float layerDepth,
            IFilter enteringTransition,
            IFilter exitingTransition
        ) : base(
            origin,
            anchor,
            layerDepth,
            enteringTransition,
            exitingTransition)
        {
            this._balls = new List<Ball>();
        }

        public override float GetTotalHeight()
        {
            return Textures.POCKETED_BALLS_BORDER_BOX_SUPPORTS_BOUNDS.Height;
        }

        public override float GetTotalWidth()
        {
            return Textures.POCKETED_BALLS_BORDER_BOX_SUPPORTS_BOUNDS.Width;
        }

        public override void SetTransitionState(TransitionState transitionState, bool start = false)
        {
            base.SetTransitionState(transitionState, start);

            foreach (Ball ball in this._balls)
            {
                ball.SetTransitionState(transitionState, start);
            }
        }

        public void AddBall(Ball ball)
        {
            this._balls.Add(ball);
        }
    }
}
