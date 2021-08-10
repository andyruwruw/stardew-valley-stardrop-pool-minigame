using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace StardropPoolMinigame.Render
{
    class Textures
    {
        public static Texture2D TileSheet;

        public static void LoadTextures()
        {
            Textures.TileSheet = Game1.content.Load<Texture2D>("Minigames\\stardropPool");
        }
    }
}