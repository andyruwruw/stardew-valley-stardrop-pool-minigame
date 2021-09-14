using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame.Scenes.Dialog.Scripts
{
    class IntroductionAbigail : Script
    {
        public IntroductionAbigail() : base()
        {
        }

        protected override void AddRecitations()
        {
            this._recitations.Add(new Recitation(
                NPCName.Abigail,
                PortraitEmotion.StraightFace,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Abigail.LINE1)));

            this._recitations.Add(new Recitation(
                NPCName.Abigail,
                PortraitEmotion.Laugh,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Abigail.LINE2)));

            this._recitations.Add(new Recitation(
                NPCName.Abigail,
                PortraitEmotion.Glare,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Abigail.LINE3)));
        }
    }
}
