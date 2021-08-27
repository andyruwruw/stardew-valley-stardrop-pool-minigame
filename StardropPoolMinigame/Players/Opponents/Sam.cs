using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Helpers;

namespace StardropPoolMinigame.Players
{
    class Sam: ComputerOpponent
    {
        public static string Name = "Sam";

        public Sam() : base(
            Name,
            Multiplayer.GetNewMultiplayerId(),
            SoundConstants.SAM_THEME,
            OpponentConstants.SAM_CONFIDENCE,
            OpponentConstants.SAM_COMPLEXITY,
            OpponentConstants.SAM_ANGLE_ACCURACY,
            OpponentConstants.SAM_POWER_ACCURACY)
        {
        }
    }
}
