namespace StardropPoolMinigame.Constants
{
    /// <summary>
    /// What's up coder, good to have you here.
    /// </summary>
    class DevConstants
    {
        /// <summary>
        /// Displays physics and drawing debugging visuals
        /// </summary>
        public static bool DEBUG_VISUALS = false;

        /// <summary>
        /// Useful for finding sprites outside the minigame window
        /// </summary>
        public static bool DISABLE_MARGIN_SOLIDS = false;

        /// <summary>
        /// All right clicks will be registered as pool table clicks
        /// </summary>
        public static bool OVERRIDE_IS_POOL_TABLE = true;

        /// <summary>
        /// Unlock all characters
        /// </summary>
        public static bool OVERRIDE_CHARACTER_UNLOCKS = false;

        /// <summary>
        /// Unlock all collectables
        /// </summary>
        public static bool OVERRIDE_COLLECTABLE_UNLOCKS = false;

        /// <summary>
        /// On game start, skip menus and go right into dialog
        /// </summary>
        public static bool AUTO_START_DIALOG = false;

        /// <summary>
        /// On game start, skip menus and go right into a game
        /// </summary>
        public static bool AUTO_START_AI_GAME = true;

        /// <summary>
        /// On game start, skip menus and go right into game summary
        /// </summary>
        public static bool AUTO_START_SUMMARY = false;

        /// <summary>
        /// Allows multiplayer without another player. You play both turns.
        /// </summary>
        public static bool PRETEND_MULTIPLAYER = false;

        /// <summary>
        /// Load fake save data
        /// </summary>
        public static bool FAKE_SAVE_DATA = false;
    }
}
