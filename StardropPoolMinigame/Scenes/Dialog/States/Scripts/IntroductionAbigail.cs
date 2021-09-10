using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;

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
                PortraitEmotion.StraightFace,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Abigail.LINE1)));

            this._recitations.Add(new Recitation(
                PortraitEmotion.Laugh,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Abigail.LINE2)));

            this._recitations.Add(new Recitation(
                PortraitEmotion.Glare,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Abigail.LINE3)));
        }

        public override OpponentType GetCharacter()
        {
            return OpponentType.Abigail;
        }
    }
}
