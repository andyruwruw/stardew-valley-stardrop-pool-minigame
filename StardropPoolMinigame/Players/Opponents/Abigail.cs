using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;

namespace StardropPoolMinigame.Players
{
    internal class Abigail : ComputerOpponent
    {
        public static string Name = "Abigail";

        public Abigail() : base(
            Name,
            NPCName.Abigail,
            Multiplayer.GetNewMultiplayerId(),
            SoundConstants.Theme.ABIGAIL,
            NPCConstants.Abigail.CONFIDENCE,
            NPCConstants.Abigail.COMPLEXITY,
            NPCConstants.Abigail.ANGLE_ACCURACY,
            NPCConstants.Abigail.POWER_ACCURACY)
        {
        }
    }
}