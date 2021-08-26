using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    class SubmitButton : Button
    {
        public SubmitButton(
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
            exitingTransition,
            textBounds)
        {
        }

        public override string GetId()
        {
            return $"submit-button-{this._id}";
        }

        public override void ClickCallback()
        {
            Sound.PlaySound(SoundConstants.SUBMIT_BUTTON_PRESS);
            Sound.StopMusic();
        }
    }
}
