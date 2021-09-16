namespace StardropPoolMinigame.Constants
{
	/// <summary>
	/// <para>What's up coder, good to have you here</para>
	/// <para>Here are some tools to help you test</para>
	/// </summary>
	internal class DevConstants
	{
		/// <summary>
		/// On game start, skip menus and go right into a game.
		/// </summary>
		public static bool AutoStartAIGame = true;

		/// <summary>
		/// On game start, skip menus and go right into dialog.
		/// </summary>
		public static bool AutoStartDialog = false;

		/// <summary>
		/// On game start, skip menus and go right into game summary.
		/// </summary>
		public static bool AutoStartSummary = false;

		/// <summary>
		/// Displays physics and drawing debugging visuals.
		/// </summary>
		public static bool DebugVisuals = true;

		/// <summary>
		/// Useful for finding sprites outside the minigame window.
		/// </summary>
		public static bool DisableMarginSolids = false;

		/// <summary>
		/// Load fake save data.
		/// </summary>
		public static bool FakeSaveData = false;

		/// <summary>
		/// Unlock all characters.
		/// </summary>
		public static bool OverrideCharacterUnlocks = false;

		/// <summary>
		/// Unlock all collectables.
		/// </summary>
		public static bool OverrideCollectableUnlocks = false;

		/// <summary>
		/// All right clicks will be registered as pool table clicks.
		/// </summary>
		public static bool OverrideIsPoolTable = true;

		/// <summary>
		/// Allows multiplayer without another player. You play both turns.
		/// </summary>
		public static bool PretendMultiplayer = false;
	}
}