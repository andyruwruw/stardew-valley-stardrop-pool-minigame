using StardewValley;
using System.Collections.Generic;

namespace StardropPoolMinigame.Utilities
{
    /// <summary>
    /// <para>Times events based on keys.</para>
    /// <para>Utilizes game ticks.</para>
    /// </summary>
    class Timer
    {
        /// <summary>
        /// Dictionary of keys and their start times. 
        /// </summary>
        private static Dictionary<string, int> _timings = new Dictionary<string, int>();

        /// <summary>
        /// Starts a timer with a given key.
        /// </summary>
        /// <param name="key">Timer key</param>
        /// <returns><c>0</c> on success, <c>-1</c> on overlapping keys</returns>
        public static int StartTimer(string key)
        {
            if (_timings.ContainsKey(key))
            {
                return -1;
            }

            int now = Game1.ticks;

            _timings.Add(key, now);

            return 0;
        }

        /// <summary>
        /// Returns the number of ticks since a timer was started by key
        /// </summary>
        /// <param name="key">Timer key</param>
        /// <returns>Number of ticks since timer started, <c>-1</c> on failure to find key</returns>
        public static int CheckTimer(string key)
        {
            if (!_timings.ContainsKey(key))
            {
                return -1;
            }

            return Game1.ticks - _timings[key];
        }

        /// <summary>
        /// <para>Ends a timer by key.</para>
        /// <para>This will remove the timer and it will no longer be accessable</para>
        /// </summary>
        /// <param name="key">Timer key</param>
        /// <returns>Number of ticks since timer started, <c>-1</c> on failure to find key</returns>
        public static int EndTimer(string key)
        {
            if (!_timings.ContainsKey(key))
            {
                return -1;
            }

            int elapsed = Game1.ticks - _timings[key];

            _timings.Remove(key);

            return elapsed;
        }
    }
}
