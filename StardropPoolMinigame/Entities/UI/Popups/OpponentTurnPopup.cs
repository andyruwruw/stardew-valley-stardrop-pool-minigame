using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame.Entities.UI.Popups
{
    internal class OpponentTurnPopup : Popup
    {
        public OpponentTurnPopup() : base(
            null,
            null,
            Translations.GetTranslation(StringConstants.Popups.OPPONENT_TURN))
        {
        }

        /// <inheritdoc cref="Entity.GetId"/>
        public override string GetId()
        {
            return $"popup-opponent-turn-{this._id}";
        }
    }
}