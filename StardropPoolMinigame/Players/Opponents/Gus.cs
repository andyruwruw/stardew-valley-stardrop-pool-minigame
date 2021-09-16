using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Multiplayer;

namespace StardropPoolMinigame.Players
{
	internal class Gus : ComputerOpponent
	{
		public static string Name = "Gus";

		public Gus() : base(
			Name,
			NPCName.Gus,
			MultiplayerHelper.GetNewMultiplayerId(),
			SoundConstants.Theme.Gus,
			NPCConstants.Gus.Confidence,
			NPCConstants.Gus.Complexity,
			NPCConstants.Gus.AngleAccuracy,
			NPCConstants.Gus.PowerAccuracy)
		{
		}
	}
}