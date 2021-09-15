namespace StardropPoolMinigame.Enums
{
    /// <summary>
    /// The states each turn is broken into
    /// </summary>
    public enum TurnState
    {
        Idle = 0,

        SelectingPocket = 1,

        PlacingBall = 2,

        SelectingAngle = 3,

        SelectingPower = 4,

        BallsInMotion = 5,

        Results = 6,

        PowerUpActivation = 7,
    }
}