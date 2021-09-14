﻿using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame.Scenes.Dialog.Scripts
{
    class RevealAbigail : Script
    {
        public RevealAbigail() : base()
        {
        }

        protected override void AddRecitations()
        {
            this._recitations.Add(new Recitation(
                NPCName.Abigail,
                PortraitEmotion.StraightFace,
                Translations.GetTranslation(StringConstants.Quotes.Reveal.Abigail.LINE1)));

            this._recitations.Add(new Recitation(
                NPCName.Abigail,
                PortraitEmotion.Laugh,
                Translations.GetTranslation(StringConstants.Quotes.Reveal.Abigail.LINE2)));

            this._recitations.Add(new Recitation(
                NPCName.Abigail,
                PortraitEmotion.Glare,
                Translations.GetTranslation(StringConstants.Quotes.Reveal.Abigail.LINE3)));
        }
    }
}