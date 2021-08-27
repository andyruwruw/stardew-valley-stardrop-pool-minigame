using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Helpers;

namespace StardropPoolMinigame.Players
{
    class Abigail: ComputerOpponent
    {
        public static string Name = "Abigail";

        public Abigail() : base(
            Name,
            Multiplayer.GetNewMultiplayerId(),
            SoundConstants.ABIGAIL_THEME,
            OpponentConstants.ABIGAIL_CONFIDENCE,
            OpponentConstants.ABIGAIL_COMPLEXITY,
            OpponentConstants.ABIGAIL_ANGLE_ACCURACY,
            OpponentConstants.ABIGAIL_POWER_ACCURACY)
        {
        }
    }
}
