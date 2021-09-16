using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame.Entities
{
    internal class VictoryPopup : Popup
    {
        public VictoryPopup() : base(
            null,
            null,
            Translations.GetTranslation(StringConstants.Popups.Victory))
        {
        }

        /// <inheritdoc cref="Entity.GetId"/>
        public override string GetId()
        {
            return $"popup-victory-{this._id}";
        }
    }
}