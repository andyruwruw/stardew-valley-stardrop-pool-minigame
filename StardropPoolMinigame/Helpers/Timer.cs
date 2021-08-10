using StardewValley;
using System.Collections.Generic;

namespace StardropPoolMinigame.Helpers
{
    class Timer
    {
        public static Dictionary<string, int> Timings = new Dictionary<string, int>();

        public static int StartTimer(string key)
        {
            if (Timings.ContainsKey(key))
            {
                return -1;
            }

            int now = Game1.ticks;

            Timings.Add(key, now);

            return 0;
        }

        public static int CheckTimer(string key)
        {
            if (!Timings.ContainsKey(key))
            {
                return -1;
            }

            return Game1.ticks - Timings[key];
        }

        public static int EndTimer(string key)
        {
            if (!Timings.ContainsKey(key))
            {
                return -1;
            }

            int elapsed = Game1.ticks - Timings[key];

            Timings.Remove(key);

            return elapsed;
        }
    }
}
