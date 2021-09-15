using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;

namespace StardropPoolMinigame.Players
{
    internal class Sebastian : ComputerOpponent
    {
        public static string Name = "Sebastian";

        public Sebastian() : base(
            Name,
            NPCName.Sebastian,
            Multiplayer.GetNewMultiplayerId(),
            SoundConstants.Theme.SEBASTIAN,
            NPCConstants.Sebastian.CONFIDENCE,
            NPCConstants.Sebastian.COMPLEXITY,
            NPCConstants.Sebastian.ANGLE_ACCURACY,
            NPCConstants.Sebastian.POWER_ACCURACY)
        {
        }
    }
}