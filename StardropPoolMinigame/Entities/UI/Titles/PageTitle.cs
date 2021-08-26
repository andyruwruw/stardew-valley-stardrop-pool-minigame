using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    class PageTitle : EntityStatic
    {
        Rectangle _textBounds;

        public PageTitle(
            Origin origin,
            Vector2 anchor,
            float layerDepth,
            IFilter enteringTransition,
            IFilter exitingTransition,
            Rectangle textBounds
        ) : base(
            origin,
            anchor,
            layerDepth,
            enteringTransition,
            exitingTransition)
        {
            this._textBounds = textBounds;
            this.SetDrawer(new PageTitleDrawer(this));
        }

        public override void Update()
        {
            this.UpdateTransitionState();
        }

        public override float GetTotalWidth()
        {
            return this._textBounds.Width;
        }

        public override float GetTotalHeight()
        {
            return this._textBounds.Height;
        }

        public Microsoft.Xna.Framework.Rectangle GetTextBounds()
        {
            return this._textBounds;
        }
    }
}
