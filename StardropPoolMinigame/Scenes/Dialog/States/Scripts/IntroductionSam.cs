using StardewValley;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;

namespace StardropPoolMinigame.Scenes.Dialog.Scripts
{
    class IntroductionSam : Script
    {
        public IntroductionSam() : base()
        {
        }

        protected override void AddRecitations()
        {
            this._recitations.Add(new Recitation(
                PortraitEmotion.Laugh,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Sam.LINE1, new { name = Game1.player.displayName })));

            this._recitations.Add(new Recitation(
                PortraitEmotion.Embarassed,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Sam.LINE2)));

            this._recitations.Add(new Recitation(
                PortraitEmotion.Default,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Sam.LINE3)));

            this._recitations.Add(new Recitation(
                PortraitEmotion.Laugh,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Sam.LINE4)));

            this._recitations.Add(new Recitation(
                PortraitEmotion.Default,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Sam.LINE5)));

            this._recitations.Add(new Recitation(
                PortraitEmotion.Default,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Sam.LINE6)));

            this._recitations.Add(new Recitation(
                PortraitEmotion.Embarassed,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Sam.LINE7)));
        }

        public override OpponentType GetCharacter()
        {
            return OpponentType.Sam;
        }
    }
}
