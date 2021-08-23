using StardewModdingAPI;
using System;

namespace StardropPoolMinigame
{
    class Logger
    {
        private static IMonitor Monitor;

        public static void SetMonitor(IMonitor monitor)
        {
            Monitor = monitor;
        }

        public static void Info(String message)
        {
            Monitor.Log(message, LogLevel.Info);
        }

        public static void Debug(String message)
        {
            Monitor.Log(message, LogLevel.Debug);
        }

        public static void Trace(String message)
        {
            Monitor.Log(message, LogLevel.Trace);
        }
    }
}
