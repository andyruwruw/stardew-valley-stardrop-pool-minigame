using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;

namespace StardropPoolMinigame.Players
{
    internal class Gus : ComputerOpponent
    {
        public static string Name = "Gus";

        public Gus() : base(
            Name,
            NPCName.Gus,
            Multiplayer.GetNewMultiplayerId(),
            SoundConstants.Theme.GUS,
            NPCConstants.Gus.CONFIDENCE,
            NPCConstants.Gus.COMPLEXITY,
            NPCConstants.Gus.ANGLE_ACCURACY,
            NPCConstants.Gus.POWER_ACCURACY)
        {
        }
    }
}