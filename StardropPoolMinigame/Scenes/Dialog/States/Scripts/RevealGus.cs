using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame.Scenes.Dialog.Scripts
{
    internal class RevealGus : Script
    {
        public RevealGus() : base()
        {
        }

        protected override void AddRecitations()
        {
            this._recitations.Add(new Recitation(
                NPCName.Gus,
                PortraitEmotion.Laugh,
                Translations.GetTranslation(StringConstants.Quotes.Reveal.Gus.LINE1)));

            this._recitations.Add(new Recitation(
                NPCName.Gus,
                PortraitEmotion.Smurk,
                Translations.GetTranslation(StringConstants.Quotes.Reveal.Gus.LINE2)));

            this._recitations.Add(new Recitation(
                NPCName.Gus,
                PortraitEmotion.Laugh,
                Translations.GetTranslation(StringConstants.Quotes.Reveal.Gus.LINE3)));

            this._recitations.Add(new Recitation(
                NPCName.Gus,
                PortraitEmotion.Glare,
                Translations.GetTranslation(StringConstants.Quotes.Reveal.Gus.LINE4),
                hasFire: true,
                isDarker: true));
        }
    }
}