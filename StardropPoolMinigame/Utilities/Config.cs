using StardropPoolMinigame.Data;

namespace StardropPoolMinigame.Utilities
{
    /// <summary>
    /// Retrieves values generated from the <see href="https://stardewvalleywiki.com/Modding:Modder_Guide/APIs/Config">config.json</see>.
    /// </summary>
    class Config
    {
        /// <summary>
        /// Static object generated from <see href="https://stardewvalleywiki.com/Modding:Modder_Guide/APIs/Config">config.json</see>.
        /// </summary>
        private static ModConfig _config;

        /// <summary>
        /// Sets static object generated from <see href="https://stardewvalleywiki.com/Modding:Modder_Guide/APIs/Config">config.json</see>.
        /// </summary>
        /// <param name="config">Object generated from <see href="https://stardewvalleywiki.com/Modding:Modder_Guide/APIs/Config">config.json</see></param>
        public static void SetConfig(ModConfig config)
        {
            _config = config;
        }

        /// <summary>
        /// Whether <see cref="Entities.ParticleEmitter">ParticleEmitters</see> are enabled.
        /// </summary>
        /// <returns>Whether <see cref="Entities.ParticleEmitter">ParticleEmitters</see> are enabled</returns>
        public static bool ShowParticles()
        {
            return _config.ShowParticles;
        }

        /// <summary>
        /// Whether <see cref="Scenes.IScene"/> <see cref="Render.Filters.Transition">Transitions</see> are not skipped.
        /// </summary>
        /// <returns>Whether to not skip <see cref="Render.Filters.Transition">Transitions</see></returns>
        public static bool ShowTransitions()
        {
            return _config.ShowTransitions;
        }

        /// <summary>
        /// Whether time and day restrictions apply to when you can play NPC.
        /// </summary>
        /// <returns>Whether time and day restrictions apply</returns>
        public static bool PlayAnyTime()
        {
            return _config.PlayAnyTime;
        }
    }
}
