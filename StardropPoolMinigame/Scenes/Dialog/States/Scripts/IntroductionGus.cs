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
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Gus.Line1)));

            this._recitations.Add(new Recitation(
                NPCName.Abigail,
                PortraitEmotion.Smurk,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Gus.Line2)));

            this._recitations.Add(new Recitation(
                NPCName.Abigail,
                PortraitEmotion.Laugh,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Gus.Line3)));

            this._recitations.Add(new Recitation(
                NPCName.Abigail,
                PortraitEmotion.Glare,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Gus.Line4),
                hasFire: true,
                isDarker: true));
        }
    }
}