﻿using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame.Scenes.Dialog.Scripts
{
    internal class RevealAbigail : Script
    {
        public RevealAbigail() : base()
        {
        }

        protected override void AddRecitations()
        {
            this._recitations.Add(new Recitation(
                NPCName.Abigail,
                PortraitEmotion.StraightFace,
                Translations.GetTranslation(StringConstants.Quotes.Reveal.Abigail.Line1)));

            this._recitations.Add(new Recitation(
                NPCName.Abigail,
                PortraitEmotion.Laugh,
                Translations.GetTranslation(StringConstants.Quotes.Reveal.Abigail.Line2)));

            this._recitations.Add(new Recitation(
                NPCName.Abigail,
                PortraitEmotion.Glare,
                Translations.GetTranslation(StringConstants.Quotes.Reveal.Abigail.Line3)));
        }
    }
}