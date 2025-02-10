namespace MinigameFramework.Helpers
{
    /// <summary>
    /// Just some math helper functions.
    /// </summary>
    static class MiscellaneousHelpers
    {
        /// <summary>
        /// Converts degrees to radians.
        /// </summary>
        /// <param name="degrees">Degree value to convert</param>
        /// <returns>Value as radians</returns>
        public static float DegreesToRadians(float degrees)
        {
            return (float)(degrees * Math.PI / 180);
        }

        /// <summary>
        /// Converts radians to degrees.
        /// </summary>
        /// <param name="radians">Radian value to convert</param>
        /// <returns>Value as degrees</returns>
        public static float RadiansToDegrees(float radians)
        {
            return (float)(radians / Math.PI * 180);
        }

        /// <summary>
        /// Custom implementation of modulo to account for negative values.
        /// </summary>
        /// <param name="a">First value</param>
        /// <param name="b">Second value</param>
        /// <returns><c>a % b</c> result</returns>
        public static float Modulo(
            float a,
            float b
        ) {
            return (float)(a - b * Math.Floor(a / b));
        }

        /// <summary>
        /// Random float between <c>0</c> and <c>1</c>.
        /// </summary>
        /// <returns>Random float</returns>
        public static float Random()
        {
            return (float)(new System.Random()).NextDouble();
        }
    }
}
