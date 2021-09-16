using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame.Entities.UI.Popups
{
    internal class YourTurnPopup : Popup
    {
        public YourTurnPopup() : base(
            null,
            null,
            Translations.GetTranslation(StringConstants.Popups.YourTurn))
        {
        }

        /// <inheritdoc cref="Entity.GetId"/>
        public override string GetId()
        {
            return $"popup-your-turn-{this._id}";
        }
    }
}