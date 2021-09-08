using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Helpers;

namespace StardropPoolMinigame.Entities.UI.Popups
{
    class UnlockedCharacterPopup : Popup
    {
        public UnlockedCharacterPopup() : base(null, null, Translations.GetTranslation(StringConstants.Popups.VICTORY))
        {

        }
    }
}
