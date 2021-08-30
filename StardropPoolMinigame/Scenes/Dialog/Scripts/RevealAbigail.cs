using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;

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
                PortraitEmotion.StraightFace,
                Translations.GetTranslation(StringConstants.Quotes.Reveal.Abigail.LINE1)));

            this._recitations.Add(new Recitation(
                PortraitEmotion.Laugh,
                Translations.GetTranslation(StringConstants.Quotes.Reveal.Abigail.LINE2)));

            this._recitations.Add(new Recitation(
                PortraitEmotion.Glare,
                Translations.GetTranslation(StringConstants.Quotes.Reveal.Abigail.LINE3)));
        }

        public override OpponentType GetCharacter()
        {
            return OpponentType.Abigail;
        }
    }
}