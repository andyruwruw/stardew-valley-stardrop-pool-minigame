using Microsoft.Xna.Framework;
using StardewModdingAPI;

namespace MinigameFramework.Utilities
{
    /// <summary>
    /// Aids in printing console messages.
    /// </summary>
    static class Logger
    {
        /// <summary>
        /// Static reference to SMAPI monitor.
        /// </summary>
        private static IMonitor _monitor;

        /// <summary>
        /// Sets the static reference to the SMAPI monitor.
        /// </summary>
        public static void SetMonitor(IMonitor monitor)
        {
            _monitor = monitor;
        }

        /// <summary>
        /// Returns string of <see cref="Vector2"/> value.
        /// </summary>
        /// <param name="vector"><see cref="Vector2"/> to stringify</param>
        /// <returns>String of <see cref="Vector2"/> value</returns>
		public static string LogVector2(Vector2 vector)
        {
            return $"[X: {vector.X} Y: {vector.Y}]";
        }

        /// <summary>
        /// Prints a message to the console on the info layer.
        /// </summary>
        /// <param name="message">Message to send.</param>
        public static void Info(string message)
        {
            _monitor.Log(
                message,
                LogLevel.Info
            );
        }

        /// <summary>
        /// Prints a message to the console on the debug layer.
        /// </summary>
        /// <param name="message">Message to send.</param>
        public static void Debug(string message)
        {
            _monitor.Log(
                message,
                LogLevel.Debug
            );
        }

        /// <summary>
        /// Prints a message to the console on the trace layer.
        /// </summary>
        /// <param name="message">Message to send.</param>
        public static void Trace(string message)
        {
            _monitor.Log(
                message,
                LogLevel.Trace
            );
        }
    }
}
