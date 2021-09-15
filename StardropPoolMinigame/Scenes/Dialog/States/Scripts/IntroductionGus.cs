using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame.Scenes.Dialog.Scripts
{
    internal class IntroductionGus : Script
    {
        public IntroductionGus() : base()
        {
        }

        protected override void AddRecitations()
        {
            this._recitations.Add(new Recitation(
                NPCName.Abigail,
                PortraitEmotion.Laugh,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Gus.LINE1)));

            this._recitations.Add(new Recitation(
                NPCName.Abigail,
                PortraitEmotion.Smurk,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Gus.LINE2)));

            this._recitations.Add(new Recitation(
                NPCName.Abigail,
                PortraitEmotion.Laugh,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Gus.LINE3)));

            this._recitations.Add(new Recitation(
                NPCName.Abigail,
                PortraitEmotion.Glare,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Gus.LINE4),
                hasFire: true,
                isDarker: true));
        }
    }
}