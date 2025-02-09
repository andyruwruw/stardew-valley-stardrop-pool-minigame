namespace StardopPoolMinigame.Data
{
    /// <summary>
    /// Player editable configuration.
    /// </summary>
    class ModConfig
    {
        /// <summary>
        /// Dictates whether the player can play pool at anytime, regardless of NPCs being present.
        /// </summary>
        public bool PlayAnyTime { get; set; } = false;

        /// <summary>
        /// Whether to show particle animations.
        /// </summary>
        public bool ShowParticles { get; set; } = true;

        /// <summary>
        /// Whether to show transition animations.
        /// </summary>
        public bool ShowTransitions { get; set; } = false;
    }
}
