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
            OpponentConstants.Sebastian.CONFIDENCE,
            OpponentConstants.Sebastian.COMPLEXITY,
            OpponentConstants.Sebastian.ANGLE_ACCURACY,
            OpponentConstants.Sebastian.POWER_ACCURACY)
        {
        }
    }
}
