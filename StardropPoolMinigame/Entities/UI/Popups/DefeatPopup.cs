using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame.Entities
{
    internal class DefeatPopup : Popup
    {
        public DefeatPopup() : base(
            null,
            null,
            Translations.GetTranslation(StringConstants.Popups.Defeat))
        {
        }

        /// <inheritdoc cref="Entity.GetId"/>
        public override string GetId()
        {
            return $"popup-defeat-{this._id}";
        }
    }
}