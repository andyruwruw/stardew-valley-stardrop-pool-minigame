using StardewValley;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame.Scenes.Dialog.Scripts
{
    internal class IntroductionSebastian : Script
    {
        public IntroductionSebastian() : base()
        {
        }

        protected override void AddRecitations()
        {
            this._recitations.Add(new Recitation(
                NPCName.Sebastian,
                PortraitEmotion.Default,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Sebastian.LINE1, new { name = Game1.player.displayName })));

            this._recitations.Add(new Recitation(
                NPCName.Sebastian,
                PortraitEmotion.Smurk,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Sebastian.LINE2)));

            this._recitations.Add(new Recitation(
                NPCName.Sebastian,
                PortraitEmotion.Glad,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Sebastian.LINE3)));

            this._recitations.Add(new Recitation(
                NPCName.Sebastian,
                PortraitEmotion.Smurk,
                Translations.GetTranslation(StringConstants.Quotes.Introduction.Sebastian.LINE4)));
        }
    }
}