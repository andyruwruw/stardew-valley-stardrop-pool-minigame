using StardewModdingAPI;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Data.Save;
using StardropPoolMinigame.Enums;
using System.Collections.Generic;

namespace StardropPoolMinigame.Utilities
{
    /// <summary>
    /// Retrieves values generated from the mod save data.
    /// </summary>
    internal class Save
    {
        /// <summary>
        /// Static reference to <see cref="IDataHelper"/>
        /// </summary>
        private static IDataHelper Data;

        /// <summary>
        /// Static object generated from save data.
        /// </summary>
        private static SaveJson SaveData;

        public static void AddArcadeTokens(int tokens)
        {
            SaveData.ArcadeTokens += tokens;
        }

        public static void AddLoss(NPCName name)
        {
            switch (name)
            {
                case NPCName.Sebastian:
                    AddLossAgainstSebastian();
                    break;

                case NPCName.Abigail:
                    AddLossAgainstAbigail();
                    break;

                case NPCName.Gus:
                    AddLossAgainstGus();
                    break;

                default:
                    AddLossAgainstSam();
                    break;
            }
        }

        public static void AddLossAgainstAbigail()
        {
            SaveData.WinsAgainstAbigail += 1;
        }

        public static void AddLossAgainstGus()
        {
            SaveData.WinsAgainstGus += 1;
        }

        public static void AddLossAgainstSam()
        {
            SaveData.WinsAgainstSam += 1;
        }

        public static void AddLossAgainstSebastian()
        {
            SaveData.WinsAgainstSebastian += 1;
        }

        public static void AddWin(NPCName name)
        {
            switch (name)
            {
                case NPCName.Sebastian:
                    AddWinAgainstSebastian();
                    break;

                case NPCName.Abigail:
                    AddWinAgainstAbigail();
                    break;

                case NPCName.Gus:
                    AddWinAgainstGus();
                    break;

                default:
                    AddWinAgainstSam();
                    break;
            }
        }

        public static void AddWinAgainstAbigail()
        {
            SaveData.WinsAgainstAbigail += 1;
        }

        public static void AddWinAgainstGus()
        {
            SaveData.WinsAgainstGus += 1;
        }

        public static void AddWinAgainstSam()
        {
            SaveData.WinsAgainstSam += 1;
        }

        public static void AddWinAgainstSebastian()
        {
            SaveData.WinsAgainstSebastian += 1;
        }

        public static bool BeatsHighscore(NPCName name, int score)
        {
            switch (name)
            {
                case NPCName.Sebastian:
                    return BeatsHighscoreAgainstSebastian(score);

                case NPCName.Abigail:
                    return BeatsHighscoreAgainstAbigail(score);

                case NPCName.Gus:
                    return BeatsHighscoreAgainstGus(score);

                default:
                    return BeatsHighscoreAgainstSam(score);
            }
        }

        public static bool BeatsHighscoreAgainstAbigail(int score)
        {
            return SaveData.HighscoreAgainstAbigail > score;
        }

        public static bool BeatsHighscoreAgainstGus(int score)
        {
            return SaveData.HighscoreAgainstGus > score;
        }

        public static bool BeatsHighscoreAgainstSam(int score)
        {
            return SaveData.HighscoreAgainstSam > score;
        }

        public static bool BeatsHighscoreAgainstSebastian(int score)
        {
            return SaveData.HighscoreAgainstSam > score;
        }

        public static int GetArcadeTokens()
        {
            return SaveData.ArcadeTokens;
        }

        public static string GetCurrentCue()
        {
            return SaveData.CurrentCue;
        }

        public static int GetHighscore(NPCName name)
        {
            switch (name)
            {
                case NPCName.Sebastian:
                    return GetHighscoreAgainstSebastian();

                case NPCName.Abigail:
                    return GetHighscoreAgainstAbigail();

                case NPCName.Gus:
                    return GetHighscoreAgainstGus();

                default:
                    return GetHighscoreAgainstSam();
            }
        }

        public static int GetHighscoreAgainstAbigail()
        {
            return SaveData.HighscoreAgainstAbigail;
        }

        public static int GetHighscoreAgainstGus()
        {
            return SaveData.HighscoreAgainstGus;
        }

        public static int GetHighscoreAgainstSam()
        {
            return SaveData.HighscoreAgainstSam;
        }

        public static int GetHighscoreAgainstSebastian()
        {
            return SaveData.HighscoreAgainstSebastian;
        }

        public static int GetLosses(NPCName name)
        {
            switch (name)
            {
                case NPCName.Sebastian:
                    return GetLossesAgainstSebastian();

                case NPCName.Abigail:
                    return GetLossesAgainstAbigail();

                case NPCName.Gus:
                    return GetLossesAgainstGus();

                default:
                    return GetLossesAgainstSam();
            }
        }

        public static int GetLossesAgainstAbigail()
        {
            return SaveData.LossesAgainstAbigail;
        }

        public static int GetLossesAgainstGus()
        {
            return SaveData.LossesAgainstGus;
        }

        public static int GetLossesAgainstSam()
        {
            return SaveData.LossesAgainstSam;
        }

        public static int GetLossesAgainstSebastian()
        {
            return SaveData.LossesAgainstSebastian;
        }

        public static IList<string> GetUnlockedCues()
        {
            return new List<string>(SaveData.UnlockedCues.Split(','));
        }

        public static int GetWins(NPCName name)
        {
            switch (name)
            {
                case NPCName.Sebastian:
                    return GetWinsAgainstSebastian();

                case NPCName.Abigail:
                    return GetWinsAgainstAbigail();

                case NPCName.Gus:
                    return GetWinsAgainstGus();

                default:
                    return GetWinsAgainstSam();
            }
        }

        public static int GetWinsAgainstAbigail()
        {
            return SaveData.WinsAgainstAbigail;
        }

        public static int GetWinsAgainstGus()
        {
            return SaveData.WinsAgainstGus;
        }

        public static int GetWinsAgainstSam()
        {
            return SaveData.WinsAgainstSam;
        }

        public static int GetWinsAgainstSebastian()
        {
            return SaveData.WinsAgainstSebastian;
        }

        public static bool HasDefeated(NPCName name)
        {
            switch (name)
            {
                case NPCName.Sebastian:
                    return HasDefeatedSebastian();

                case NPCName.Abigail:
                    return HasDefeatedAbigail();

                case NPCName.Gus:
                    return HasDefeatedGus();

                default:
                    return HasDefeatedSam();
            }
        }

        public static bool HasDefeatedAbigail()
        {
            return SaveData.WinsAgainstAbigail > 0;
        }

        public static bool HasDefeatedGus()
        {
            return SaveData.WinsAgainstGus > 0;
        }

        public static bool HasDefeatedSam()
        {
            return SaveData.WinsAgainstSam > 0;
        }

        public static bool HasDefeatedSebastian()
        {
            return SaveData.WinsAgainstSebastian > 0;
        }

        public static bool HasEnoughArcadeTokens(int tokens)
        {
            return SaveData.ArcadeTokens >= tokens;
        }

        public static bool IsAbigailUnlocked()
        {
            return SaveData.WinsAgainstSebastian > 0;
        }

        public static bool IsChampion()
        {
            return HasDefeatedSam()
                && HasDefeatedSebastian()
                && HasDefeatedAbigail()
                && HasDefeatedGus();
        }

        public static bool IsGusUnlocked()
        {
            return SaveData.WinsAgainstAbigail > 0;
        }

        public static bool IsUnlocked(NPCName name)
        {
            switch (name)
            {
                case NPCName.Abigail:
                    return IsAbigailUnlocked();

                case NPCName.Gus:
                    return IsGusUnlocked();

                default:
                    return true;
            }
        }

        /// <summary>
        /// Reads save data and generates <see cref="SaveJson"/>.
        /// </summary>
        public static void ReadSaveData()
        {
            if (SaveData == null)
            {
                SaveData = Data.ReadSaveData<SaveJson>("stardrop-pool-minigame");

                if (SaveData == null)
                {
                    SaveData = new SaveJson();
                }

                if (DevConstants.OVERRIDE_CHARACTER_UNLOCKS)
                {
                    SaveData.WinsAgainstSebastian = 1;
                    SaveData.WinsAgainstAbigail = 1;
                }
            }
        }

        /// <summary>
        /// Deletes save data.
        /// </summary>
        public static void ResetData()
        {
            Data.WriteSaveData<SaveJson>("stardrop-pool-minigame", null);
        }

        /// <summary>
        /// Sets static object generated from save data.
        /// </summary>
        /// <param name="config">Reference to <see cref="IDataHelper"/></param>
        public static void SetData(IDataHelper data)
        {
            Data = data;
            ReadSaveData();
        }

        public static void SetHighscore(NPCName name, int score)
        {
            switch (name)
            {
                case NPCName.Sebastian:
                    SetHighscoreAgainstSebastian(score);
                    break;

                case NPCName.Abigail:
                    SetHighscoreAgainstAbigail(score);
                    break;

                case NPCName.Gus:
                    SetHighscoreAgainstGus(score);
                    break;

                default:
                    SetHighscoreAgainstSam(score);
                    break;
            }
        }

        public static void SetHighscoreAgainstAbigail(int score)
        {
            SaveData.HighscoreAgainstAbigail = score;
        }

        public static void SetHighscoreAgainstGus(int score)
        {
            SaveData.HighscoreAgainstGus = score;
        }

        public static void SetHighscoreAgainstSam(int score)
        {
            SaveData.HighscoreAgainstSam = score;
        }

        public static void SetHighscoreAgainstSebastian(int score)
        {
            SaveData.HighscoreAgainstSebastian = score;
        }

        public static bool ShouldUnlockAbigail()
        {
            return HasDefeatedSam() && HasDefeatedSebastian();
        }

        public static bool ShouldUnlockGus()
        {
            return HasDefeatedSam()
                && HasDefeatedSebastian()
                && HasDefeatedAbigail();
        }

        public static void SubtractArcadeTokens(int tokens)
        {
            SaveData.ArcadeTokens -= tokens;
        }

        public static void UnlockCue(string key)
        {
            SaveData.UnlockedCues = $"{SaveData.UnlockedCues},{key}";
        }

        /// <summary>
        /// Reads save data from <see cref="SaveJson"/>.
        /// </summary>
        public static void WriteSaveData()
        {
            Data.WriteSaveData<SaveJson>("stardrop-pool-minigame", SaveData);
        }
    }
}