using Microsoft.Xna.Framework;

namespace StardropPoolMinigame.Controller
{
    class Mouse
    {
        /// <summary>
        /// Position of the cursor
        /// </summary>
        public static Vector2 Position;

        /// <summary>
        /// Sets the position of the cursor every tick
        /// </summary>
        /// <param name="x">X coord of cursor relative to viewport</param>
        /// <param name="y">Y coord of cursor relative to viewport</param>
        public static void SetPosition(int x = 0, int y = 0)
        {
            Position = new Vector2(x, y);
        }
    }
}
