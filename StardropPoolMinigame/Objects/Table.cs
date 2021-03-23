using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace StardropPoolMinigame.Objects
{
    class Table : ITable
    {
        public static int Width = 288 * 3;

        public static int Height = 192 * 3;

        public Table()
        {

        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(Game1.staminaRect, new Rectangle(0, 0, Table.Width, Table.Height), Game1.staminaRect.Bounds, Color.Gray, 0f, Vector2.Zero, SpriteEffects.None, 0.0001f);
        }
    }
}
