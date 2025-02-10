namespace MinigameFramework.Enums
{
    /// <summary>
    /// States of transitions
    /// </summary>
    public enum TransitionState
    {
        /// <summary>
        /// Starting a transition.
        /// </summary>
        Entering = 0,

        /// <summary>
        /// In a transition.
        /// </summary>
        Present = 1,

        /// <summary>
        /// Leaving transition.
        /// </summary>
        Exiting = 2,

        /// <summary>
        /// Not visable.
        /// </summary>
        Dead = 3,
    }
}
