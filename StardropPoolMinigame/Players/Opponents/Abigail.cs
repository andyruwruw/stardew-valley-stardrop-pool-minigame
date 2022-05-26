using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Multiplayer;

namespace StardropPoolMinigame.Players
{
	internal class Abigail : ComputerOpponent
	{
		public static string Name = "Abigail";

		public Abigail() : base(
			Name,
			NPCName.Abigail,
			MultiplayerHelper.GetNewMultiplayerId(),
			SoundConstants.Theme.Abigail,
			NPCConstants.Abigail.Confidence,
			NPCConstants.Abigail.Complexity,
			NPCConstants.Abigail.AngleAccuracy,
			NPCConstants.Abigail.PowerAccuracy)
		{
		}
	}
}