using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Helpers;

namespace StardropPoolMinigame.Entities.UI.Popups
{
    class OpponentTurnPopup : Popup
    {
        public OpponentTurnPopup() : base(null, null, Translations.GetTranslation(StringConstants.Popups.OPPONENT_TURN))
        {

        }
    }
}
