using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;

namespace StardropPoolMinigame.Players
{
    class Sam: ComputerOpponent
    {
        public static string Name = "Sam";

        public Sam() : base(
            Name,
            OpponentType.Sam,
            Multiplayer.GetNewMultiplayerId(),
            SoundConstants.Theme.SEBASTIAN,
            OpponentConstants.Sam.CONFIDENCE,
            OpponentConstants.Sam.COMPLEXITY,
            OpponentConstants.Sam.ANGLE_ACCURACY,
            OpponentConstants.Sam.POWER_ACCURACY)
        {
        }
    }
}
