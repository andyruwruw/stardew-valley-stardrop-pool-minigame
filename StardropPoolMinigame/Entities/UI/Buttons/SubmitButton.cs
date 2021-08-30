using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    class SubmitButton : Button
    {
        /// <summary>
        /// Button with different click sound
        /// </summary>
        public SubmitButton(
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
            exitingTransition,
            text,
            maxWidth,
            isCentered)
        {
        }

        public override string GetId()
        {
            return $"submit-button-{this._id}";
        }

        public override void ClickCallback()
        {
            Sound.PlaySound(SoundConstants.Feedback.SUBMIT_BUTTON_PRESS);
            Sound.StopMusic();
        }
    }
}
