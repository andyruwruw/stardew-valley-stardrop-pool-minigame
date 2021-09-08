using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Helpers;

namespace StardropPoolMinigame.Entities.UI.Popups
{
    class YourTurnPopup : Popup
    {
        public YourTurnPopup() : base(null, null, Translations.GetTranslation(StringConstants.Popups.YOUR_TURN))
        {

        }
    }
}
