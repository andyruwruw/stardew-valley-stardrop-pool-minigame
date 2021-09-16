using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;
using System.Collections.Generic;

namespace StardropPoolMinigame.Entities
{
    internal class PocketedBalls : Entity
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
            this.SetDrawer(new PocketedBallsDrawer(this));
        }

        public void Add(Ball ball)
        {
            float segmentWidth = (Textures.PocketedBalls.BORDER_BOX.Width - (RenderConstants.Entities.PocketedBalls.Padding * 2)) / 7;
            Vector2 location = Vector2.Add(
                this.GetTopLeft(),
                new Vector2(
                    this._balls.Count * segmentWidth + (segmentWidth / 2),
                    Textures.PocketedBalls.SUPPORTS.Height - (RenderConstants.Entities.PocketedBalls.SupportPadding * 2) + (Textures.PocketedBalls.BORDER_BOX.Height - RenderConstants.Entities.PocketedBalls.SupportPadding) / 2));

            ball.SetAnchor(location);
            ball.SetVelocity(Vector2.Zero);
            ball.SetAcceleration(Vector2.Zero);
            this._balls.Add(ball);
        }

        public void Clear()
        {
            this._balls.Clear();
        }

        public int Count()
        {
            return this._balls.Count;
        }

        public IList<Ball> GetBalls()
        {
            return this._balls;
        }

        public override string GetId()
        {
            return $"pocketed-balls-{this._id}";
        }

        public override float GetTotalHeight()
        {
            return Textures.PocketedBalls.BORDER_BOX.Height + Textures.PocketedBalls.SUPPORTS.Height;
        }

        public override float GetTotalWidth()
        {
            return Textures.PocketedBalls.BORDER_BOX.Width;
        }

        public int IndexOf(Ball ball)
        {
            return this._balls.IndexOf(ball);
        }

        public void Remove(Ball ball)
        {
            this._balls.Remove(ball);
        }

        public override void SetTransitionState(TransitionState transitionState, bool start = false)
        {
            base.SetTransitionState(transitionState, start);

            foreach (Ball ball in this._balls)
            {
                ball.SetTransitionState(transitionState, start);
            }
        }
    }
}