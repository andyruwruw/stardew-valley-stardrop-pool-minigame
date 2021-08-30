using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;

namespace StardropPoolMinigame.Players
{
    class Abigail: ComputerOpponent
    {
        public static string Name = "Abigail";

        public Abigail() : base(
            Name,
            OpponentType.Abigail,
            Multiplayer.GetNewMultiplayerId(),
            SoundConstants.Theme.ABIGAIL,
            OpponentConstants.Abigail.CONFIDENCE,
            OpponentConstants.Abigail.COMPLEXITY,
            OpponentConstants.Abigail.ANGLE_ACCURACY,
            OpponentConstants.Abigail.POWER_ACCURACY)
        {
        }
    }
}
