using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Filters;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame.Entities
{
    internal class SubmitButton : Button
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

        /// <inheritdoc cref="Button.ClickCallback"/>
        public override void ClickCallback()
        {
            Sound.PlaySound(SoundConstants.Feedback.SubmitButtonPress);
            Sound.StopMusic();
        }

        /// <inheritdoc cref="Button.GetId"/>
        public override string GetId()
        {
            return $"submit-button-{this._id}";
        }
    }
}