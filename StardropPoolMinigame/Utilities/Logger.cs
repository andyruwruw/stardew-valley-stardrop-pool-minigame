using StardewModdingAPI;
using System;
using Microsoft.Xna.Framework;

namespace StardropPoolMinigame
{
    /// <summary>
    /// Static method of printing to <see cref="IMonitor"/>
    /// </summary>
    internal class Logger
    {
        /// <summary>
        /// Static reference to <see cref="IMonitor"/>
        /// </summary>
        private static IMonitor Monitor;

        /// <summary>
        /// Prints to <see cref="LogLevel.Debug"/> of <see cref="IMonitor"/>
        /// </summary>
        /// <param name="message">Message to be printed</param>
        public static void Debug(String message)
        {
            Monitor.Log(message, LogLevel.Debug);
        }

        /// <summary>
        /// Prints to <see cref="LogLevel.Info"/> of <see cref="IMonitor"/>
        /// </summary>
        /// <param name="message">Message to be printed</param>
        public static void Info(String message)
        {
            Monitor.Log(message, LogLevel.Info);
        }

        /// <summary>
        /// Sets static reference to <see cref="IMonitor"/>
        /// </summary>
        /// <param name="monitor"><see cref="IMonitor"/> reference</param>
        public static void SetMonitor(IMonitor monitor)
        {
            Monitor = monitor;
        }

        /// <summary>
        /// Prints to <see cref="LogLevel.Trace"/> of <see cref="IMonitor"/>
        /// </summary>
        /// <param name="message">Message to be printed</param>
        public static void Trace(String message)
        {
            Monitor.Log(message, LogLevel.Trace);
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
    }
}