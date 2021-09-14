using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame.Entities
{
    class DefeatPopup : Popup
    {
        public DefeatPopup() : base(
            null,
            null,
            Translations.GetTranslation(StringConstants.Popups.DEFEAT))
        {

        }

        /// <inheritdoc cref="Entity.GetId"/>
        public override string GetId()
        {
            return $"popup-defeat-{this._id}";
        }
    }
}
