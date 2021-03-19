using StardewModdingAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame
{
    public class Console
    {
        private static IMonitor _monitor;

        public static void SetMonitor(IMonitor monitor)
        {
            Console._monitor = monitor;
        }

        public static void Info(String message)
        {
            Console._monitor.Log(message, LogLevel.Info);
        }

        public static void Debug(String message)
        {
            Console._monitor.Log(message, LogLevel.Debug);
        }

        public static void Trace(String message)
        {
            Console._monitor.Log(message, LogLevel.Trace);
        }
    }
}
