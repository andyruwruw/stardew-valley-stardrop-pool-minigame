namespace StardropPoolMinigame.Detect.Hover
{
    /// <summary>
    /// Detects if player is currently hovering certain tile IDs
    /// </summary>
    internal interface ITileHoverDetector
    {
        /// <summary>
        /// Returns whether the player is hovering over designated tile IDs
        /// </summary>
        /// <returns>Whether player is hovering tile IDs</returns>
        bool IsHovering();
    }
}