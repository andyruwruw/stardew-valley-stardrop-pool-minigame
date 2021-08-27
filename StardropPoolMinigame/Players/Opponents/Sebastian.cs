using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Helpers;

namespace StardropPoolMinigame.Players
{
    class Sebastian: ComputerOpponent
    {
        public static string Name = "Sebastian";

        public Sebastian() : base(
            Name,
            Multiplayer.GetNewMultiplayerId(),
            SoundConstants.SEBASTIAN_THEME,
            OpponentConstants.SEBASTIAN_CONFIDENCE,
            OpponentConstants.SEBASTIAN_COMPLEXITY,
            OpponentConstants.SEBASTIAN_ANGLE_ACCURACY,
            OpponentConstants.SEBASTIAN_POWER_ACCURACY)
        {
        }
    }
}
