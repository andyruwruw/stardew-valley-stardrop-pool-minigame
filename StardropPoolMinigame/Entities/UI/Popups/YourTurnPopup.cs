using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame.Entities.UI.Popups
{
    class YourTurnPopup : Popup
    {
        public YourTurnPopup() : base(
            null,
            null,
            Translations.GetTranslation(StringConstants.Popups.YOUR_TURN))
        {

        }

        /// <inheritdoc cref="Entity.GetId"/>
        public override string GetId()
        {
            return $"popup-your-turn-{this._id}";
        }
    }
}
