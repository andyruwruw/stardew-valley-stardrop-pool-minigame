using System;
using StardewModdingAPI;

namespace StardropPoolMinigame.Helpers
{
    class Translations
    {
        public static ITranslationHelper Helper;

        public static void SetHelper(ITranslationHelper helper)
        {
            Helper = helper;
        }

        public static string GetTranslation(string key)
        {
            return Helper.Get(key);
        }

        public static string GetTranslation(string key, Object tokens)
        {
            return Helper.Get(key, tokens);
        }
    }
}
