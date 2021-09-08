using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Helpers;

namespace StardropPoolMinigame.Entities
{
    class VictoryPopup : Popup
    {
        public VictoryPopup() : base(null, null, Translations.GetTranslation(StringConstants.Popups.VICTORY))
        {

        }
    }
}
