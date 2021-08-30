namespace StardropPoolMinigame.Data.Save
{
    class SaveJson
    {
        public int ArcadeTokens { get; set; } = 0;

        public int HighscoreAgainstSam { get; set; } = -1;

        public int HighscoreAgainstSebastian { get; set; } = -1;

        public int HighscoreAgainstAbigail { get; set; } = -1;

        public int HighscoreAgainstGus { get; set; } = -1;

        public string CurrentCue { get; set; } = "basic";

        public string UnlockedCues { get; set; } = "basic";

        public int WinsAgainstSam { get; set; } = 0;

        public int LossesAgainstSam { get; set; } = 0;

        public int WinsAgainstSebastian { get; set; } = 0;

        public int LossesAgainstSebastian { get; set; } = 0;

        public int WinsAgainstAbigail { get; set; } = 0;

        public int LossesAgainstAbigail { get; set; } = 0;

        public int WinsAgainstGus { get; set; } = 0;

        public int LossesAgainstGus { get; set; } = 0;

        public bool UnlockedAbigail { get; set; } = false;

        public bool UnlockedGus { get; set; } = false;
    }
}
