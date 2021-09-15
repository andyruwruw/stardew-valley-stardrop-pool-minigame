using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame.Entities
{
    internal class BallPocketedPopup : Popup
    {
        public BallPocketedPopup() : base(
            null,
            null,
            Translations.GetTranslation(StringConstants.Popups.COMBO))
        {
        }

        /// <inheritdoc cref="Entity.GetId"/>
        public override string GetId()
        {
            return $"popup-ball-pocketed-{this._id}";
        }
    }
}