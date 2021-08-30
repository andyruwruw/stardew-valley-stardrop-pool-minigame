using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;

namespace StardropPoolMinigame.Players
{
    class Gus: ComputerOpponent
    {
        public static string Name = "Gus";

        public Gus() : base(
            Name,
            OpponentType.Gus,
            Multiplayer.GetNewMultiplayerId(),
            SoundConstants.Theme.GUS,
            OpponentConstants.Gus.CONFIDENCE,
            OpponentConstants.Gus.COMPLEXITY,
            OpponentConstants.Gus.ANGLE_ACCURACY,
            OpponentConstants.Gus.POWER_ACCURACY)
        {
        }
    }
}
