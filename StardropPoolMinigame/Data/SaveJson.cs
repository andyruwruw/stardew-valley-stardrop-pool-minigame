namespace StardropPoolMinigame.Data.Save
{
    class SaveJson
    {
        public int BestGame { get; set; } = -1;

        public string CurrentCue { get; set; } = "basic";

        public bool DefeatedSam { get; set; } = false;

        public bool DefeatedSebastian { get; set; } = false;

        public bool DefeatedAbigail { get; set; } = false;

        public bool DefeatedGus { get; set; } = false;

        public int WinsAgainstSam { get; set; } = 0;

        public int LossesAgainstSam { get; set; } = 0;

        public int WinsAgainstSebastian { get; set; } = 0;

        public int LossesAgainstSebastian { get; set; } = 0;

        public int WinsAgainstAbigail { get; set; } = 0;

        public int LossesAgainstAbigail { get; set; } = 0;

        public int WinsAgainstGus { get; set; } = 0;

        public int LossesAgainstGus { get; set; } = 0;
    }
}
