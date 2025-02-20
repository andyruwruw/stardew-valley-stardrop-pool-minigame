namespace MinigameFramework.Enums
{
    /// <summary>
    /// Position compared to parent.
    /// </summary>
    public enum Position
    {
        /// <summary>
        /// Remains impacted by siblings.
        /// </summary>
        Relative = 0,

        /// <summary>
        /// Relative to parent, doesn't impact siblings.
        /// </summary>
        Absolute = 1,

        /// <summary>
        /// Relative to screen, doesn't impact siblings and doesn't follow parent.
        /// </summary>
        Fixed = 0
    }
}
