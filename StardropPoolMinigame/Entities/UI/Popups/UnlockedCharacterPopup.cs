using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame.Entities.UI.Popups
{
    internal class UnlockedCharacterPopup : Popup
    {
        public UnlockedCharacterPopup() : base(
            null,
            null,
            Translations.GetTranslation(StringConstants.Popups.VICTORY))
        {
        }

        /// <inheritdoc cref="Entity.GetId"/>
        public override string GetId()
        {
            return $"popup-unlocked-character-{this._id}";
        }
    }
}