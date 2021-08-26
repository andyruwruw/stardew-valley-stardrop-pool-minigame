using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    class Text : EntityHoverable
    {
        Rectangle _textBounds;

        private bool _isHoverable;

        public Text(
            Origin origin,
            Vector2 anchor,
            float layerDepth,
            IFilter enteringTransition,
            IFilter exitingTransition,
            Rectangle textBounds,
            bool isHoverable = false
        ) : base(
            origin,
            anchor,
            layerDepth,
            enteringTransition,
            exitingTransition)
        {
            this._textBounds = textBounds;
            this._isHoverable = isHoverable;

            this.SetDrawer(new TextDrawer(this));
        }

        public override void Update()
        {
            this.UpdateHoverable();
            this.UpdateTransitionState();
        }

        public override float GetTotalHeight()
        {
            return this._textBounds.Height;
        }

        public override float GetTotalWidth()
        {
            return this._textBounds.Width;
        }

        public override void ClickCallback()
        {
        }

        protected override void HoveredCallback()
        {
        }

        public Rectangle GetTextBounds()
        {
            return this._textBounds;
        }

        public void SetTextBounds(Rectangle textBounds)
        {
            this._textBounds = textBounds;
        }
    }
}
