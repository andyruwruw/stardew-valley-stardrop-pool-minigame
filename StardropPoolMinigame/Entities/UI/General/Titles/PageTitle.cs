using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    internal class PageTitle : Entity
    {
        private Text _text;

        public PageTitle(
            Origin origin,
            Vector2 anchor,
            float layerDepth,
            IFilter enteringTransition,
            IFilter exitingTransition,
            string text,
            int maxWidth = int.MaxValue,
            float scale = 1.1f,
            bool isCentered = true
        ) : base(
            origin,
            anchor,
            layerDepth,
            enteringTransition,
            exitingTransition)
        {
            this._text = new Text(
                origin,
                anchor,
                layerDepth,
                enteringTransition,
                exitingTransition,
                text,
                maxWidth,
                scale,
                isCentered,
                false);

            this.SetDrawer(new PageTitleDrawer(this));
        }

        public override string GetId()
        {
            return $"page-title-{this._id}";
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
            return this._text.GetTotalWidth();
        }

        public override void SetTransitionState(TransitionState transitionState, bool start = false)
        {
            base.SetTransitionState(transitionState, start);
            this._text.SetTransitionState(transitionState, true);
        }
    }
}