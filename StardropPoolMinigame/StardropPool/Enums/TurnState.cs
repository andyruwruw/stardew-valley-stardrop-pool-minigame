namespace StardopPoolMinigame.Enums
{
    /// <summary>
    /// Stages of a player's turn.
    /// </summary>
    public enum TurnState
    {
        /// <summary>
        /// Players turn has begun.
        /// </summary>
        Start = 0,

        /// <summary>
        /// Player is placing the ball (post-scratch).
        /// </summary>
        PlacingBall = 1,

        /// <summary>
        /// Player is selecting their cue angle.
        /// </summary>
        SelectingAngle = 2,
        
        /// <summary>
        /// Player is selecting their power.
        /// </summary>
        SelectingPower = 3,

        /// <summary>
        /// The balls are in motion.
        /// </summary>
        MovingBalls = 4,

        /// <summary>
        /// Post turn results.
        /// </summary>
        Results = 5,

        /// <summary>
        /// Player is selecting a power-up.
        /// </summary>
        PowerUpSelect = 6,
    }
}
