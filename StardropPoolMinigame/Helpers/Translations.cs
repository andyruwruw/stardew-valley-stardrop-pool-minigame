using System;
using StardewModdingAPI;

namespace StardropPoolMinigame.Helpers
{
    /// <summary>
    /// Retrieves translated strings from <see href="https://stardewvalleywiki.com/Modding:Translations">i18n folder</see>.
    /// </summary>
    class Translations
    {
        /// <inheritdoc cref="ITranslationHelper"/>
        public static ITranslationHelper Helper;

        /// <summary>
        /// Sets static reference to <see cref="ITranslationHelper"/>.
        /// </summary>
        /// <param name="helper"><inheritdoc cref="ITranslationHelper"/></param>
        public static void SetHelper(ITranslationHelper helper)
        {
            Helper = helper;
        }

        /// <summary>
        /// Retrieves translated string from <see href="https://stardewvalleywiki.com/Modding:Translations">i18n folder</see> by ID.
        /// </summary>
        /// <param name="key">Translated string ID</param>
        /// <returns>Translated string from <see href="https://stardewvalleywiki.com/Modding:Translations">i18n folder</see>.</returns>
        public static string GetTranslation(string key)
        {
            return Helper.Get(key);
        }

        /// <summary>
        /// Retrieves translated string from <see href="https://stardewvalleywiki.com/Modding:Translations">i18n folder</see> by ID utilizing dynamic tokens.
        /// </summary>
        /// <param name="key">Translated string ID</param>
        /// <param name="tokens">Dynamic tokens</param>
        /// <returns>Translated string from <see href="https://stardewvalleywiki.com/Modding:Translations">i18n folder</see> with dynamic tokens inserted.</returns>
        public static string GetTranslation(string key, Object tokens)
        {
            return Helper.Get(key, tokens);
        }
    }
}
