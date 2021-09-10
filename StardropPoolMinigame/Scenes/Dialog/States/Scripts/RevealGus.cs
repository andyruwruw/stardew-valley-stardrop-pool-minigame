using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;
using System;
namespace StardropPoolMinigame.Scenes.Dialog.Scripts
{
    class RevealGus : Script
    {
        public RevealGus() : base()
        {
        }

        protected override void AddRecitations()
        {
            this._recitations.Add(new Recitation(
                PortraitEmotion.Laugh,
                Translations.GetTranslation(StringConstants.Quotes.Reveal.Gus.LINE1)));

            this._recitations.Add(new Recitation(
                PortraitEmotion.Smurk,
                Translations.GetTranslation(StringConstants.Quotes.Reveal.Gus.LINE2)));

            this._recitations.Add(new Recitation(
                PortraitEmotion.Laugh,
                Translations.GetTranslation(StringConstants.Quotes.Reveal.Gus.LINE3)));

            this._recitations.Add(new Recitation(
                PortraitEmotion.Glare,
                Translations.GetTranslation(StringConstants.Quotes.Reveal.Gus.LINE4),
                hasFire: true,
                isDarker: true));
        }

        public override OpponentType GetCharacter()
        {
            return OpponentType.Gus;
        }
    }
}