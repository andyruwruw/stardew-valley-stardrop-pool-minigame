using StardewValley;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;

namespace StardropPoolMinigame.Scenes.Dialog.Scripts
{
    class IntroductionSebastian : Script
    {
        public IntroductionSebastian() : base()
        {
        }

        protected override void AddRecitations()
        {
            this._recitations.Add(new Recitation(
                PortraitEmotion.Glad,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Sebastian.LINE1, new { name = Game1.player.displayName })));

            this._recitations.Add(new Recitation(
                PortraitEmotion.Smurk,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Sebastian.LINE2)));

            this._recitations.Add(new Recitation(
                PortraitEmotion.Glare,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Sebastian.LINE3)));
        }

        public override OpponentType GetCharacter()
        {
            return OpponentType.Sebastian;
        }
    }
}
