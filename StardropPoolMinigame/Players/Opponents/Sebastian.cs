using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;

namespace StardropPoolMinigame.Players
{
    class Sebastian: ComputerOpponent
    {
        public static string Name = "Sebastian";

        public Sebastian() : base(
            Name,
            OpponentType.Sebastian,
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
