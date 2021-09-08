using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Helpers;

namespace StardropPoolMinigame.Entities
{
    class DefeatPopup : Popup
    {
        public DefeatPopup() : base(null, null, Translations.GetTranslation(StringConstants.Popups.DEFEAT))
        {

        }
    }
}
