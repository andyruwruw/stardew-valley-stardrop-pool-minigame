using StardewModdingAPI;
using StardropPoolMinigame.Data.Save;

namespace StardropPoolMinigame.Helpers
{
    class Save
    {
        private static IDataHelper Data;

        private static SaveJson SaveData;

        public static void SetData(IDataHelper data)
        {
            Data = data;
            ReadSaveData();
        }

        public static void WriteSaveData()
        {
            Data.WriteSaveData<SaveJson>("stardrop-pool-minigame", SaveData);
        }

        public static void ReadSaveData()
        {
            if (SaveData == null)
            {
                SaveData = Data.ReadSaveData<SaveJson>("stardrop-pool-minigame");

                if (SaveData == null)
                {
                    SaveData = new SaveJson();
                }
            }
        }

        public static void ResetData()
        {
            Data.WriteSaveData<SaveJson>("stardrop-pool-minigame", null);
        }

        public static int GetBestGame()
        {
            return SaveData.BestGame;
        }

        public static string GetCurrentCue()
        {
            return SaveData.CurrentCue;
        }

        public static bool HasDefeatedSam()
        {
            return SaveData.WinsAgainstSam > 0;
        }

        public static bool HasDefeatedSebastian()
        {
            return SaveData.WinsAgainstSebastian > 0;
        }

        public static bool HasDefeatedAbigail()
        {
            return SaveData.WinsAgainstAbigail > 0;
        }

        public static bool HasDefeatedGus()
        {
            return SaveData.WinsAgainstGus > 0;
        }

        public static int GetWinsAgainstSam()
        {
            return SaveData.WinsAgainstSam;
        }

        public static int GetLossesAgainstSam()
        {
            return SaveData.LossesAgainstSam;
        }

        public static int GetWinsAgainstSebastian()
        {
            return SaveData.WinsAgainstSebastian;
        }

        public static int GetLossesAgainstSebastian()
        {
            return SaveData.LossesAgainstSebastian;
        }

        public static int GetWinsAgainstAbigail()
        {
            return SaveData.WinsAgainstAbigail;
        }

        public static int GetLossesAgainstAbigail()
        {
            return SaveData.LossesAgainstAbigail;
        }

        public static int GetWinsAgainstGus()
        {
            return SaveData.WinsAgainstGus;
        }

        public static int GetLossesAgainstGus()
        {
            return SaveData.LossesAgainstGus;
        }
    }
}
