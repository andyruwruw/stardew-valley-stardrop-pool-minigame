using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardropPoolMinigame.Render;
using System;
using System.Collections.Generic;

namespace StardropPoolMinigame.Objects
{
    class Table : ITable
    {
        public static int Scale = 3;

        public static int Width = 288 * Table.Scale;

        public static int Height = 160 * Table.Scale;

        public static int WallThickness = 16 * Table.Scale;

        public static int PocketWidth = 16 * Table.Scale;

        public static int InnerWidth = Table.Width - WallThickness * 2;

        public static int InnerHeight = Table.Height - WallThickness * 2;

        public static int DiamondPadding = Table.InnerWidth / 8;

        public Table()
        {

        }

        public void Draw(SpriteBatch batch)
        {
            int rows = Table.Height / 16 / Table.Scale;
            int cols = Table.Width / 16 / Table.Scale;

            for (int i = 0; i < rows; i++)
            {
                if (i == 1 || i == rows - 1)
                {
                    continue;
                }

                int iPixel = i * 16 * Table.Scale;

                for (int j = 0; j < cols; j++)
                {
                    if (j == 1 || j == cols - 1)
                    {
                        continue;
                    }

                    Rectangle textureSource;

                    bool hasFront = true;
                    Rectangle frontSource;

                    int size = 32;

                    int jPixel = j * 16 * Table.Scale;

                    Vector2 northWest = new Vector2(jPixel, iPixel);
                    Vector2 northWestRaw = DrawMath.TableToRaw(northWest);

                    if (i == 0)
                    {
                        if (j % 2 == 1)
                        {
                            continue;
                        }

                        if (j == 0)
                        {
                            textureSource = Textures.GetPocketTexture(CardinalDirection.NorthWest);
                            frontSource = Textures.GetPocketFrontTexture(CardinalDirection.NorthWest);
                        }
                        else if (j == (int)Math.Round(cols / 2.0) - 1)
                        {
                            textureSource = Textures.GetPocketTexture(CardinalDirection.North);
                            frontSource = Textures.GetPocketFrontTexture(CardinalDirection.North);
                        }
                        else if (j == cols - 2)
                        {
                            textureSource = Textures.GetPocketTexture(CardinalDirection.NorthEast);
                            frontSource = Textures.GetPocketFrontTexture(CardinalDirection.NorthEast);
                        }
                        else
                        {
                            hasFront = false;
                            textureSource = Textures.GetTableEdgeTexture(CardinalDirection.North);
                            frontSource = Textures.GetPocketFrontTexture(CardinalDirection.North);
                        }
                    }
                    else if (i == rows - 2)
                    {
                        if (j % 2 == 1)
                        {
                            continue;
                        }

                        if (j == 0)
                        {
                            textureSource = Textures.GetPocketTexture(CardinalDirection.SouthWest);
                            frontSource = Textures.GetPocketFrontTexture(CardinalDirection.SouthWest);
                        }
                        else if (j == (int)Math.Round(cols / 2.0) - 1)
                        {
                            textureSource = Textures.GetPocketTexture(CardinalDirection.South);
                            frontSource = Textures.GetPocketFrontTexture(CardinalDirection.South);
                        }
                        else if (j == cols - 2)
                        {
                            textureSource = Textures.GetPocketTexture(CardinalDirection.SouthEast);
                            frontSource = Textures.GetPocketFrontTexture(CardinalDirection.SouthEast);
                        }
                        else
                        {
                            hasFront = false;
                            textureSource = Textures.GetTableEdgeTexture(CardinalDirection.South);
                            frontSource = Textures.GetTableEdgeTexture(CardinalDirection.South);
                        }
                    }
                    else if (j == 0)
                    {
                        if (i % 2 == 1)
                        {
                            continue;
                        }

                        hasFront = false;
                        textureSource = Textures.GetTableEdgeTexture(CardinalDirection.West);
                        frontSource = Textures.GetTableEdgeTexture(CardinalDirection.West);
                    }
                    else if (j == cols - 2)
                    {
                        if (i % 2 == 1)
                        {
                            continue;
                        }

                        hasFront = false;
                        textureSource = Textures.GetTableEdgeTexture(CardinalDirection.East);
                        frontSource = Textures.GetTableEdgeTexture(CardinalDirection.East);
                    }
                    else
                    {
                        size = 16;
                        hasFront = false;
                        textureSource = Textures.Felt;
                        frontSource = Textures.Felt;
                    }

                    batch.Draw(Textures.TileSheet, new Rectangle((int)northWestRaw.X, (int)northWestRaw.Y, size * Table.Scale, size * Table.Scale), textureSource, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.0010f);

                    if (hasFront)
                    {
                        batch.Draw(Textures.TileSheet, new Rectangle((int)northWestRaw.X, (int)northWestRaw.Y, size * Table.Scale, size * Table.Scale), frontSource, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.0025f);
                    }
                }
            }

            //foreach(Structures.Rectangle border in this.GetBorders())
            //{
            //    batch.Draw(Game1.staminaRect, new Rectangle((int)DrawMath.InnerTableToRaw(border.GetNorthWest()).X, (int)DrawMath.InnerTableToRaw(border.GetNorthWest()).Y, (int)border.GetWidth(), (int)border.GetHeight()), Game1.staminaRect.Bounds, Color.Purple, 0f, Vector2.Zero, SpriteEffects.None, 0.0101f) ;
            //}
        }

        public IList<Structures.Rectangle> GetBorders()
        {
            IList<Structures.Rectangle> borders = new List<Structures.Rectangle>();

            // NorthWest
            borders.Add(new Structures.Rectangle((Table.InnerWidth / 4) + 5, Table.WallThickness / -2, (Table.InnerWidth / 2) - (Table.PocketWidth * (float)1.8), Table.WallThickness));

            // NorthWestSmall
            borders.Add(new Structures.Rectangle((Textures.TileSize * 2) + 3 * DrawMath.PixelZoomAdjustement, Table.WallThickness / -9 * 5, 27 * DrawMath.PixelZoomAdjustement, 30 * DrawMath.PixelZoomAdjustement));

            // NorthEast
            borders.Add(new Structures.Rectangle((Table.InnerWidth / 4) * 3 - 5, Table.WallThickness / -2, (Table.InnerWidth / 2) - (Table.PocketWidth * (float)1.8), Table.WallThickness));

            // SouthWest
            borders.Add(new Structures.Rectangle((Table.InnerWidth / 4) + 5, Table.InnerHeight + (Table.WallThickness / 2), (Table.InnerWidth / 2) - (Table.PocketWidth * (float)1.8), Table.WallThickness));

            // SouthEast
            borders.Add(new Structures.Rectangle((Table.InnerWidth / 4) * 3 - 5, Table.InnerHeight + (Table.WallThickness / 2), (Table.InnerWidth / 2) - (Table.PocketWidth * (float)1.8), Table.WallThickness));

            // West
            borders.Add(new Structures.Rectangle(Table.WallThickness / -2, (Table.InnerHeight / 2), Table.WallThickness, Table.InnerHeight - (Table.PocketWidth * 2)));

            // East
            borders.Add(new Structures.Rectangle(Table.InnerWidth + (Table.WallThickness / 2), (Table.InnerHeight / 2), Table.WallThickness, Table.InnerHeight - (Table.PocketWidth * 2)));

            return borders;
        }
    }
}
