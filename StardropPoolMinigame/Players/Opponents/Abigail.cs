using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Helpers;

namespace StardropPoolMinigame.Players
{
    class Abigail: ComputerOpponent
    {
        public Abigail() : base("Abigail", Multiplayer.GetNewMultiplayerId(), SoundConstants.ABIGAIL_THEME, OpponentConstants.ABIGAIL_CONFIDENCE, OpponentConstants.ABIGAIL_COMPLEXITY, OpponentConstants.ABIGAIL_ANGLE_ACCURACY, OpponentConstants.ABIGAIL_POWER_ACCURACY)
        {
        }
    }
}
