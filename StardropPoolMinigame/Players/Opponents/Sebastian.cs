using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Multiplayer;

namespace StardropPoolMinigame.Players
{
	internal class Sebastian : ComputerOpponent
	{
		public static string Name = "Sebastian";

		public Sebastian() : base(
			Name,
			NPCName.Sebastian,
			MultiplayerHelper.GetNewMultiplayerId(),
			SoundConstants.Theme.Sebastian,
			NPCConstants.Sebastian.Confidence,
			NPCConstants.Sebastian.Complexity,
			NPCConstants.Sebastian.AngleAccuracy,
			NPCConstants.Sebastian.PowerAccuracy)
		{
		}
	}
}