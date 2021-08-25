using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Helpers;

namespace StardropPoolMinigame.Players
{
    class Gus: ComputerOpponent
    {
        public Gus() : base(
            "Gus",
            Multiplayer.GetNewMultiplayerId(),
            SoundConstants.GUS_THEME,
            OpponentConstants.GUS_CONFIDENCE,
            OpponentConstants.GUS_COMPLEXITY,
            OpponentConstants.GUS_ANGLE_ACCURACY,
            OpponentConstants.GUS_POWER_ACCURACY)
        {
        }
    }
}
