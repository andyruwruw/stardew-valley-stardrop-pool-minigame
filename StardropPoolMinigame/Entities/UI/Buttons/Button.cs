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
        private Text _text;

        public Button(
            Origin origin,
            Vector2 anchor,
            float layerDepth,
            IFilter enteringTransition,
            IFilter exitingTransition,
            string text,
            int maxWidth = int.MaxValue,
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
                isCentered,
                true);

            this.SetDrawer(new ButtonDrawer(this));
        }

        public override string GetId()
        {
            return $"basic-button-{this._id}";
        }

        public override float GetTotalWidth()
        {
            return this._text.GetTotalWidth();
        }

        public override float GetTotalHeight()
        {
            return this._text.GetTotalHeight();
        }

        public override void ClickCallback()
        {
            Sound.PlaySound(SoundConstants.BOTTON_PRESS);
        }

        protected override void HoveredCallback()
        {
            Sound.PlaySound(SoundConstants.BUTTON_HOVER);
        }

        public Text GetText()
        {
            return this._text;
        }
    }
}
