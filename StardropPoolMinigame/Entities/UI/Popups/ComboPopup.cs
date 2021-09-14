﻿using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame.Entities
{
    class ComboPopup : Popup
    {
        public ComboPopup() : base(null, null, Translations.GetTranslation(StringConstants.Popups.COMBO))
        {

        }

        /// <inheritdoc cref="Entity.GetId"/>
        public override string GetId()
        {
            return $"popup-combo-{this._id}";
        }
    }
}