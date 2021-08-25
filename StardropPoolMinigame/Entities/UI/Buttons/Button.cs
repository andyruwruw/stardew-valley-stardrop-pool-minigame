using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    class Button : EntityHoverable
    {
        private Microsoft.Xna.Framework.Rectangle _textBounds;

        public Button(
            Origin origin,
            Vector2 anchor,
            float layerDepth,
            IFilter enteringTransition,
            IFilter exitingTransition,
            Microsoft.Xna.Framework.Rectangle textBounds
        ) : base(
            origin,
            anchor,
            layerDepth,
            enteringTransition,
            exitingTransition)
        {
            this._textBounds = textBounds;

            this.SetDrawer(new ButtonDrawer(this));
        }

        public override void Update()
        {
            this.UpdateHoverable();
            this.UpdateTransitionState();
        }

        public override IDrawer GetDrawer()
        {
            return this._drawer;
        }

        public override string GetId()
        {
            return $"basic-button-{this._id}";
        }

        public override float GetTotalWidth()
        {
            return this._textBounds.Width;
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

        public Microsoft.Xna.Framework.Rectangle GetTextBounds()
        {
            return this._textBounds;
        }
    }
}
