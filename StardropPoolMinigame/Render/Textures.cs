using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Render
{
    public class Textures
    {
        public static int TileSize = 16;

        public static Texture2D TileSheet;

        public static void LoadTextures()
        {
            Textures.TileSheet = Game1.content.Load<Texture2D>("Minigames\\stardropPool");
        }

        public static Rectangle Logo = new Rectangle(0, Textures.TileSize * 12, Textures.TileSize * 3, Textures.TileSize * 2);

        public static Rectangle GetPocketTexture(CardinalDirection direction)
        {
            int tileSizeMultiplyer = 2;

            int row;
            int col;

            switch(direction)
            {
                case CardinalDirection.North:
                    row = 8;
                    col = 4;
                    break;
                case CardinalDirection.South:
                    row = 10;
                    col = 4;
                    break;
                case CardinalDirection.NorthWest:
                    row = 8;
                    col = 0;
                    break;
                case CardinalDirection.NorthEast:
                    row = 8;
                    col = 8;
                    break;
                case CardinalDirection.SouthWest:
                    row = 10;
                    col = 8;
                    break;
                default:
                    row = 10;
                    col = 0;
                    break;
            }

            return new Rectangle(Textures.TileSize * col, Textures.TileSize * row, Textures.TileSize * tileSizeMultiplyer, Textures.TileSize * tileSizeMultiplyer);
        }

        public static Rectangle GetPocketFrontTexture(CardinalDirection direction)
        {
            int tileSizeMultiplyer = 2;

            int row;
            int col;

            switch (direction)
            {
                case CardinalDirection.North:
                    row = 8;
                    col = 6;
                    break;
                case CardinalDirection.South:
                    row = 10;
                    col = 6;
                    break;
                case CardinalDirection.NorthWest:
                    row = 8;
                    col = 2;
                    break;
                case CardinalDirection.NorthEast:
                    row = 8;
                    col = 10;
                    break;
                case CardinalDirection.SouthWest:
                    row = 10;
                    col = 10;
                    break;
                default:
                    row = 10;
                    col = 2;
                    break;
            }

            return new Rectangle(Textures.TileSize * col, Textures.TileSize * row, Textures.TileSize * tileSizeMultiplyer, Textures.TileSize * tileSizeMultiplyer);
        }

        public static Rectangle GetTableEdgeTexture(CardinalDirection direction)
        {
            int tileSizeMultiplyer = 2;

            int row;
            int col;

            switch (direction)
            {
                case CardinalDirection.North:
                    row = 0;
                    col = 12;
                    break;
                case CardinalDirection.South:
                    row = 4;
                    col = 12;
                    break;
                case CardinalDirection.West:
                    row = 2;
                    col = 12;
                    break;
                default:
                    row = 6;
                    col = 12;
                    break;
            }

            return new Rectangle(Textures.TileSize * col, Textures.TileSize * row, Textures.TileSize * tileSizeMultiplyer, Textures.TileSize * tileSizeMultiplyer);
        }

        public static Rectangle GetTableEdgeFrontTexture(CardinalDirection direction)
        {
            int tileSizeMultiplyer = 2;

            int row;
            int col;

            switch (direction)
            {
                case CardinalDirection.North:
                    row = 0;
                    col = 14;
                    break;
                case CardinalDirection.South:
                    row = 4;
                    col = 14;
                    break;
                case CardinalDirection.West:
                    row = 2;
                    col = 14;
                    break;
                default:
                    row = 6;
                    col = 14;
                    break;
            }

            return new Rectangle(Textures.TileSize * col, Textures.TileSize * row, Textures.TileSize * tileSizeMultiplyer, Textures.TileSize * tileSizeMultiplyer);
        }

        public static Rectangle Felt = new Rectangle(Textures.TileSize * 10, 0, Textures.TileSize, Textures.TileSize);

        public static Rectangle GetBallBaseTexture(Color color)
        {
            if (color == Color.Yellow)
            {
                return new Rectangle(0, 0, Textures.TileSize, Textures.TileSize);
            } else if (color == Color.Blue)
            {
                return new Rectangle(Textures.TileSize, 0, Textures.TileSize, Textures.TileSize);
            } else if (color == Color.Red)
            {
                return new Rectangle(Textures.TileSize * 2, 0, Textures.TileSize, Textures.TileSize);
            } else if (color == Color.Purple)
            {
                return new Rectangle(Textures.TileSize * 3, 0, Textures.TileSize, Textures.TileSize);
            } else if (color == Color.Orange)
            {
                return new Rectangle(Textures.TileSize * 4, 0, Textures.TileSize, Textures.TileSize);
            } else if (color == Color.Green)
            {
                return new Rectangle(Textures.TileSize * 5, 0, Textures.TileSize, Textures.TileSize);
            } else if (color == Color.Maroon)
            {
                return new Rectangle(Textures.TileSize * 6, 0, Textures.TileSize, Textures.TileSize);
            } else if (color == Color.Black)
            {
                return new Rectangle(Textures.TileSize * 7, 0, Textures.TileSize, Textures.TileSize);
            } else
            {
                return new Rectangle(Textures.TileSize * 8, 0, Textures.TileSize, Textures.TileSize);
            }
        }

        public static Rectangle BallShadows = new Rectangle(Textures.TileSize * 9, 0, Textures.TileSize, Textures.TileSize);

        public static Rectangle GetBallCoreTexture(int x, int y)
        {
            int originX = 0;
            int originY = 4;

            // In position
            if (x >= 0 && x < 4 && y >= -3 && y < 4)
            {
                if (x == 0 && y == -3)
                {
                    return new Rectangle(Textures.TileSize * (x + originX), Textures.TileSize * (y * -1 + originY), Textures.TileSize, Textures.TileSize);
                }
                return new Rectangle(Textures.TileSize * (x + originX), Textures.TileSize * (y + originY), Textures.TileSize, Textures.TileSize);
            }

            // Left side offest
            if (x < 0 && y > -3 && y < 3)
            {
                return new Rectangle(Textures.TileSize * (x + originX + 6), Textures.TileSize * (y + originY), Textures.TileSize, Textures.TileSize);
            }

            // Diagonal
            if (x < 0 && Math.Abs(y) == 3)
            {
                return new Rectangle(Textures.TileSize * (x * -1 + originX), Textures.TileSize * (y * -1 + originY), Textures.TileSize, Textures.TileSize);
            }

            // Default
            return new Rectangle(Textures.TileSize * originX, Textures.TileSize * originY, Textures.TileSize, Textures.TileSize);
        }

        public static Rectangle GetBallStripeTexture(int x, int y)
        {
            int originX = 6;
            int originY = 4;

            if (y == 0)
            {
                return new Rectangle(Textures.TileSize * originX, Textures.TileSize * originY, Textures.TileSize, Textures.TileSize);
            }

            // In position
            if (x >= 0 && x < 4 && y >= -3 && y < 4)
            {
                if (x == 0 && y == -3)
                {
                    return new Rectangle(Textures.TileSize * (x + originX), Textures.TileSize * (y * -1 + originY), Textures.TileSize, Textures.TileSize);
                }
                return new Rectangle(Textures.TileSize * (x + originX), Textures.TileSize * (y + originY), Textures.TileSize, Textures.TileSize);
            }

            // Left side offest
            if (x < 0 && y > -3 && y < 3)
            {
                return new Rectangle(Textures.TileSize * (x + originX + 6), Textures.TileSize * (y + originY), Textures.TileSize, Textures.TileSize);
            }

            // Diagonal
            if (x < 0 && Math.Abs(y) == 3)
            {
                return new Rectangle(Textures.TileSize * (x * -1 + originX), Textures.TileSize * (y * -1 + originY), Textures.TileSize, Textures.TileSize);
            }

            // Default
            return new Rectangle(Textures.TileSize * originX, Textures.TileSize * originY, Textures.TileSize, Textures.TileSize);
        }

        public static Rectangle Cue = new Rectangle(Textures.TileSize * 3, Textures.TileSize * 12, Textures.TileSize * 8, Textures.TileSize);

        public static Rectangle CueShadow = new Rectangle(Textures.TileSize * 3, Textures.TileSize * 13, Textures.TileSize * 8, Textures.TileSize);
    }
}
