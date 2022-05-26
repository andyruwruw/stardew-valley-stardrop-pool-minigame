using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame.Entities
{
    internal class ComboPopup : Popup
    {
        public ComboPopup() : base(null, null, Translations.GetTranslation(StringConstants.Popups.Combo))
        {
        }

        /// <inheritdoc cref="Entity.GetId"/>
        public override string GetId()
        {
            return $"popup-combo-{this._id}";
        }
    }
}