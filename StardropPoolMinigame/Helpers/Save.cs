using StardewModdingAPI;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Data.Save;
using StardropPoolMinigame.Enums;
using System.Collections.Generic;

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

                if (DevConstants.OVERRIDE_CHARACTER_UNLOCKS)
                {
                    UnlockAbigail();
                    UnlockGus();
                }
            }
        }

        public static void ResetData()
        {
            Data.WriteSaveData<SaveJson>("stardrop-pool-minigame", null);
        }

        public static int GetArcadeTokens()
        {
            return SaveData.ArcadeTokens;
        }

        public static void AddArcadeTokens(int tokens)
        {
            SaveData.ArcadeTokens += tokens;
        }

        public static void SubtractArcadeTokens(int tokens)
        {
            SaveData.ArcadeTokens -= tokens;
        }

        public static bool HasEnoughArcadeTokens(int tokens)
        {
            return SaveData.ArcadeTokens >= tokens;
        }

        public static int GetHighscore(OpponentType name)
        {
            switch (name)
            {
                case OpponentType.Sebastian:
                    return GetHighscoreAgainstSebastian();
                case OpponentType.Abigail:
                    return GetHighscoreAgainstAbigail();
                case OpponentType.Gus:
                    return GetHighscoreAgainstGus();
                default:
                    return GetHighscoreAgainstSam();
            }
        }

        public static int GetHighscoreAgainstSam()
        {
            return SaveData.HighscoreAgainstSam;
        }

        public static int GetHighscoreAgainstSebastian()
        {
            return SaveData.HighscoreAgainstSebastian;
        }

        public static int GetHighscoreAgainstAbigail()
        {
            return SaveData.HighscoreAgainstAbigail;
        }

        public static int GetHighscoreAgainstGus()
        {
            return SaveData.HighscoreAgainstGus;
        }

        public static void SetHighscore(OpponentType name, int score)
        {
            switch (name)
            {
                case OpponentType.Sebastian:
                    SetHighscoreAgainstSebastian(score);
                    break;
                case OpponentType.Abigail:
                    SetHighscoreAgainstAbigail(score);
                    break;
                case OpponentType.Gus:
                    SetHighscoreAgainstGus(score);
                    break;
                default:
                    SetHighscoreAgainstSam(score);
                    break;
            }
        }

        public static void SetHighscoreAgainstSam(int score)
        {
            SaveData.HighscoreAgainstSam = score;
        }

        public static void SetHighscoreAgainstSebastian(int score)
        {
            SaveData.HighscoreAgainstSebastian = score;
        }

        public static void SetHighscoreAgainstAbigail(int score)
        {
            SaveData.HighscoreAgainstAbigail = score;
        }

        public static void SetHighscoreAgainstGus(int score)
        {
            SaveData.HighscoreAgainstGus = score;
        }

        public static bool BeatsHighscore(OpponentType name, int score)
        {
            switch (name)
            {
                case OpponentType.Sebastian:
                    return BeatsHighscoreAgainstSebastian(score);
                case OpponentType.Abigail:
                    return BeatsHighscoreAgainstAbigail(score);
                case OpponentType.Gus:
                    return BeatsHighscoreAgainstGus(score);
                default:
                    return BeatsHighscoreAgainstSam(score);
            }
        }

        public static bool BeatsHighscoreAgainstSam(int score)
        {
            return SaveData.HighscoreAgainstSam > score;
        }

        public static bool BeatsHighscoreAgainstSebastian(int score)
        {
            return SaveData.HighscoreAgainstSam > score;
        }

        public static bool BeatsHighscoreAgainstAbigail(int score)
        {
            return SaveData.HighscoreAgainstAbigail > score;
        }

        public static bool BeatsHighscoreAgainstGus(int score)
        {
            return SaveData.HighscoreAgainstGus > score;
        }

        public static bool HasDefeated(OpponentType name)
        {
            switch (name)
            {
                case OpponentType.Sebastian:
                    return HasDefeatedSebastian();
                case OpponentType.Abigail:
                    return HasDefeatedAbigail();
                case OpponentType.Gus:
                    return HasDefeatedGus();
                default:
                    return HasDefeatedSam();
            }
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

        public static int GetWins(OpponentType name)
        {
            switch (name)
            {
                case OpponentType.Sebastian:
                    return GetWinsAgainstSebastian();
                case OpponentType.Abigail:
                    return GetWinsAgainstAbigail();
                case OpponentType.Gus:
                    return GetWinsAgainstGus();
                default:
                    return GetWinsAgainstSam();
            }
        }

        public static int GetWinsAgainstSam()
        {
            return SaveData.WinsAgainstSam;
        }

        public static int GetWinsAgainstSebastian()
        {
            return SaveData.WinsAgainstSebastian;
        }

        public static int GetWinsAgainstAbigail()
        {
            return SaveData.WinsAgainstAbigail;
        }

        public static int GetWinsAgainstGus()
        {
            return SaveData.WinsAgainstGus;
        }

        public static void AddWin(OpponentType name)
        {
            switch (name)
            {
                case OpponentType.Sebastian:
                    AddWinAgainstSebastian();
                    break;
                case OpponentType.Abigail:
                    AddWinAgainstAbigail();
                    break;
                case OpponentType.Gus:
                    AddWinAgainstGus();
                    break;
                default:
                    AddWinAgainstSam();
                    break;
            }
        }

        public static void AddWinAgainstSam()
        {
            SaveData.WinsAgainstSam += 1;
        }

        public static void AddWinAgainstSebastian()
        {
            SaveData.WinsAgainstSebastian += 1;
        }

        public static void AddWinAgainstAbigail()
        {
            SaveData.WinsAgainstAbigail += 1;
        }

        public static void AddWinAgainstGus()
        {
            SaveData.WinsAgainstGus += 1;
        }

        public static int GetLosses(OpponentType name)
        {
            switch (name)
            {
                case OpponentType.Sebastian:
                    return GetLossesAgainstSebastian();
                case OpponentType.Abigail:
                    return GetLossesAgainstAbigail();
                case OpponentType.Gus:
                    return GetLossesAgainstGus();
                default:
                    return GetLossesAgainstSam();
            }
        }

        public static int GetLossesAgainstSam()
        {
            return SaveData.LossesAgainstSam;
        }

        public static int GetLossesAgainstSebastian()
        {
            return SaveData.LossesAgainstSebastian;
        }

        public static int GetLossesAgainstAbigail()
        {
            return SaveData.LossesAgainstAbigail;
        }

        public static int GetLossesAgainstGus()
        {
            return SaveData.LossesAgainstGus;
        }

        public static void AddLoss(OpponentType name)
        {
            switch (name)
            {
                case OpponentType.Sebastian:
                    AddLossAgainstSebastian();
                    break;
                case OpponentType.Abigail:
                    AddLossAgainstAbigail();
                    break;
                case OpponentType.Gus:
                    AddLossAgainstGus();
                    break;
                default:
                    AddLossAgainstSam();
                    break;
            }
        }

        public static void AddLossAgainstSam()
        {
            SaveData.WinsAgainstSam += 1;
        }

        public static void AddLossAgainstSebastian()
        {
            SaveData.WinsAgainstSebastian += 1;
        }

        public static void AddLossAgainstAbigail()
        {
            SaveData.WinsAgainstAbigail += 1;
        }

        public static void AddLossAgainstGus()
        {
            SaveData.WinsAgainstGus += 1;
        }

        public static bool IsUnlocked(OpponentType name)
        {
            switch (name)
            {
                case OpponentType.Abigail:
                    return IsAbigailUnlocked();
                case OpponentType.Gus:
                    return IsGusUnlocked();
                default:
                    return true;
            }
        }

        public static bool IsAbigailUnlocked()
        {
            return SaveData.UnlockedAbigail;
        }

        public static bool IsGusUnlocked()
        {
            return SaveData.UnlockedGus;
        }

        public static string GetCurrentCue()
        {
            return SaveData.CurrentCue;
        }

        public static IList<string> GetUnlockedCues()
        {
            return new List<string>(SaveData.UnlockedCues.Split(','));
        }

        public static void UnlockCue(string key)
        {
            SaveData.UnlockedCues = $"{SaveData.UnlockedCues},{key}";
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

        public static bool IsChampion()
        {
            return HasDefeatedSam()
                && HasDefeatedSebastian()
                && HasDefeatedAbigail()
                && HasDefeatedGus();
        }

        public static void UnlockAbigail()
        {
            SaveData.UnlockedAbigail = true;
        }

        public static void UnlockGus()
        {
            SaveData.UnlockedGus = true;
        }
    }
}
