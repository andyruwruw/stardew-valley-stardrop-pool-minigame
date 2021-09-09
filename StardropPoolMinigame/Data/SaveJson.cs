namespace StardropPoolMinigame.Data.Save
{
    /// <summary>
    /// Save data for <see cref="StardropPoolMinigame"/>
    /// </summary>
    class SaveJson
    {
        /// <summary>
        /// Arcade tokens earned
        /// </summary>
        public int ArcadeTokens { get; set; } = 0;

        /// <summary>
        /// Best score against Sam
        /// </summary>
        public int HighscoreAgainstSam { get; set; } = -1;

        /// <summary>
        /// Best score against Sebastian
        /// </summary>
        public int HighscoreAgainstSebastian { get; set; } = -1;

        /// <summary>
        /// Best score against Abigail
        /// </summary>
        public int HighscoreAgainstAbigail { get; set; } = -1;

        /// <summary>
        /// Best score against Gus
        /// </summary>
        public int HighscoreAgainstGus { get; set; } = -1;

        /// <summary>
        /// Current cue equipted
        /// </summary>
        public string CurrentCue { get; set; } = "basic";

        /// <summary>
        /// Comma separated IDs
        /// </summary>
        public string UnlockedCues { get; set; } = "basic";

        /// <summary>
        /// Number of wins against Sam
        /// </summary>
        public int WinsAgainstSam { get; set; } = 0;

        /// <summary>
        /// Number of losses against Sam
        /// </summary>
        public int LossesAgainstSam { get; set; } = 0;

        /// <summary>
        /// Number of wins against Sebastian
        /// </summary>
        public int WinsAgainstSebastian { get; set; } = 0;

        /// <summary>
        /// Number of losses against Sebastian
        /// </summary>
        public int LossesAgainstSebastian { get; set; } = 0;

        /// <summary>
        /// Number of wins against Abigail
        /// </summary>
        public int WinsAgainstAbigail { get; set; } = 0;

        /// <summary>
        /// Number of losses against Abigail
        /// </summary>
        public int LossesAgainstAbigail { get; set; } = 0;

        /// <summary>
        /// Number of wins against Gus
        /// </summary>
        public int WinsAgainstGus { get; set; } = 0;

        /// <summary>
        /// Number of losses against Gus
        /// </summary>
        public int LossesAgainstGus { get; set; } = 0;
    }
}
