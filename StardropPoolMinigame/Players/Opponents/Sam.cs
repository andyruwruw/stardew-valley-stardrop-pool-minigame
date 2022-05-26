using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Multiplayer;

namespace StardropPoolMinigame.Players
{
	internal class Sam : ComputerOpponent
	{
		public static string Name = "Sam";

		public Sam() : base(
			Name,
			NPCName.Sam,
			MultiplayerHelper.GetNewMultiplayerId(),
			SoundConstants.Theme.Sam,
			NPCConstants.Sam.Confidence,
			NPCConstants.Sam.Complexity,
			NPCConstants.Sam.AngleAccuracy,
			NPCConstants.Sam.PowerAccuracy)
		{
		}
	}
}