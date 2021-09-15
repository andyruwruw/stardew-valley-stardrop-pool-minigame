using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;

namespace StardropPoolMinigame.Players
{
    internal class Sam : ComputerOpponent
    {
        public static string Name = "Sam";

        public Sam() : base(
            Name,
            NPCName.Sam,
            Multiplayer.GetNewMultiplayerId(),
            SoundConstants.Theme.SAM,
            NPCConstants.Sam.CONFIDENCE,
            NPCConstants.Sam.COMPLEXITY,
            NPCConstants.Sam.ANGLE_ACCURACY,
            NPCConstants.Sam.POWER_ACCURACY)
        {
        }
    }
}