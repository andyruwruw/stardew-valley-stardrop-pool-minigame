namespace StardopPoolMinigame.Enums
{
    /// <summary>
    /// States the cue is in.
    /// </summary>
    public enum CueState
    {
        /// <summary>
        /// Cue is not viable.
        /// </summary>
        Invisible = 0,

        /// <summary>
        /// Selecting angle of cue stick.
        /// </summary>
        Angle = 1,

        /// <summary>
        /// Selecting power of cue stick.
        /// </summary>
        Power = 2,

        /// <summary>
        /// Cue is shooting.
        /// </summary>
        Shooting = 3,
    }
}
