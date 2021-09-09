using Microsoft.Xna.Framework;

namespace StardropPoolMinigame.Controller
{
    /// <summary>
    /// Tracks the position of the player's cursor
    /// </summary>
    class Mouse
    {
        /// <summary>
        /// <see cref="Vector2"/> of position of the cursor
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
