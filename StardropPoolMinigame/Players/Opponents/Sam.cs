using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Helpers;

namespace StardropPoolMinigame.Players
{
    class Sam: ComputerOpponent
    {
        public Sam() : base("Sam", Multiplayer.GetNewMultiplayerId(), SoundConstants.SAM_THEME, OpponentConstants.SAM_CONFIDENCE, OpponentConstants.SAM_COMPLEXITY, OpponentConstants.SAM_ANGLE_ACCURACY, OpponentConstants.SAM_POWER_ACCURACY)
        {
        }
    }
}
