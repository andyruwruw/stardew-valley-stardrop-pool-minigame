using StardewValley;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame.Scenes.Dialog.Scripts
{
    internal class IntroductionSam : Script
    {
        public IntroductionSam() : base()
        {
        }

        protected override void AddRecitations()
        {
            this._recitations.Add(new Recitation(
                NPCName.Sam,
                PortraitEmotion.Laugh,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Sam.Line1, new { name = Game1.player.displayName })));

            this._recitations.Add(new Recitation(
                NPCName.Sam,
                PortraitEmotion.Embarassed,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Sam.Line2)));

            this._recitations.Add(new Recitation(
                NPCName.Sam,
                PortraitEmotion.Default,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Sam.Line3)));

            this._recitations.Add(new Recitation(
                NPCName.Sam,
                PortraitEmotion.Laugh,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Sam.Line4)));

            this._recitations.Add(new Recitation(
                NPCName.Sam,
                PortraitEmotion.Default,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Sam.Line5)));

            this._recitations.Add(new Recitation(
                NPCName.Sam,
                PortraitEmotion.Default,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Sam.Line6)));

            this._recitations.Add(new Recitation(
                NPCName.Sam,
                PortraitEmotion.Embarassed,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Sam.Line7)));
        }
    }
}