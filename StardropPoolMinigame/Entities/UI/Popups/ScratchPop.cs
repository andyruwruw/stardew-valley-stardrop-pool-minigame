using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame.Entities
{
    class ScratchPop : Popup
    {
        public ScratchPop() : base(
            null,
            null,
            Translations.GetTranslation(StringConstants.Popups.SCRATCH))
        {

        }

        /// <inheritdoc cref="Entity.GetId"/>
        public override string GetId()
        {
            return $"popup-scratch-{this._id}";
        }
    }
}
