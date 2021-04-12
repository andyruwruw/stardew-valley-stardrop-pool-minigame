using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Structures;
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

        public static int PocketRadius = Ball.Radius + 5;

        private IList<IRange> _borders;

        public Table()
        {
            this.GenerateBorders();
        }

        public void Draw(SpriteBatch batch)
        {
            this.DrawTableTextures(batch);
            this.DrawBorders(batch);
        }

        public IList<IPocket> GetPockets()
        {
            IList<IPocket> pockets = new List<IPocket>();
            // Adding in clockwise order from NorthWest
            // NorthWest
            pockets.Add(new Pocket(
                0,
                Table.PocketRadius / -2,
                Table.PocketRadius / -2,
                Table.PocketRadius)
            );

            // North
            pockets.Add(new Pocket(
                1,
                Table.InnerWidth / 2,
                Table.PocketRadius / -2,
                Table.PocketRadius)
            );

            // NorthEast
            pockets.Add(new Pocket(
                2,
                Table.InnerWidth + (Table.PocketRadius / -2),
                Table.PocketRadius / -2,
                Table.PocketRadius)
            );

            // SouthEast
            pockets.Add(new Pocket(
                3,
                Table.InnerWidth + (Table.PocketRadius / -2),
                Table.InnerHeight + (Table.PocketRadius / -2),
                Table.PocketRadius)
            );

            // South
            pockets.Add(new Pocket(
                4,
                Table.InnerWidth / 2,
                Table.InnerHeight + (Table.PocketRadius / -2),
                Table.PocketRadius)
            );

            // SouthWest
            pockets.Add(new Pocket(
                5,
                Table.PocketRadius / -2,
                Table.InnerHeight + (Table.PocketRadius / -2),
                Table.PocketRadius)
            );

            return pockets;
        }

        public IList<IRange> GetBorders()
        {
            return this._borders;
        }

        private void DrawTableTextures(SpriteBatch batch)
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

                    Microsoft.Xna.Framework.Rectangle textureSource;

                    bool hasFront = true;
                    Microsoft.Xna.Framework.Rectangle frontSource;

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
                            hasFront = true;
                            textureSource = Textures.GetTableEdgeTexture(CardinalDirection.North);
                            frontSource = Textures.GetTableEdgeFrontTexture(CardinalDirection.North);
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
                            hasFront = true;
                            textureSource = Textures.GetTableEdgeTexture(CardinalDirection.South);
                            frontSource = Textures.GetTableEdgeFrontTexture(CardinalDirection.South);
                        }
                    }
                    else if (j == 0)
                    {
                        if (i % 2 == 1)
                        {
                            continue;
                        }

                        hasFront = true;
                        textureSource = Textures.GetTableEdgeTexture(CardinalDirection.West);
                        frontSource = Textures.GetTableEdgeFrontTexture(CardinalDirection.West);
                    }
                    else if (j == cols - 2)
                    {
                        if (i % 2 == 1)
                        {
                            continue;
                        }

                        hasFront = true;
                        textureSource = Textures.GetTableEdgeTexture(CardinalDirection.East);
                        frontSource = Textures.GetTableEdgeFrontTexture(CardinalDirection.East);
                    }
                    else
                    {
                        size = 16;
                        hasFront = false;
                        textureSource = Textures.Felt;
                        frontSource = Textures.Felt;
                    }

                    batch.Draw(Textures.TileSheet, new Microsoft.Xna.Framework.Rectangle((int)northWestRaw.X, (int)northWestRaw.Y, size * Table.Scale, size * Table.Scale), textureSource, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.0010f);

                    if (hasFront)
                    {
                        batch.Draw(Textures.TileSheet, new Microsoft.Xna.Framework.Rectangle((int)northWestRaw.X, (int)northWestRaw.Y, size * Table.Scale, size * Table.Scale), frontSource, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.0025f);
                    }
                }
            }
        }

        private void DrawBorders(SpriteBatch batch)
        {
            bool debug = true;

            if (debug)
            {
                foreach (IRange border in this.GetBorders())
                {
       
                    if (border is Structures.Rectangle)
                    {
                        ((Structures.Rectangle)border).Draw(batch);
                    } else if (border is Triangle)
                    {
                        ((Triangle)border).Draw(batch);
                    }
                }
            }
        }

        private void GenerateBorders()
        {
            this._borders = new List<IRange>();

            // NorthWest
            this._borders.Add(new Structures.Rectangle(
                (Table.InnerWidth / 4) + 5,
                Table.WallThickness / -2,
                (Table.InnerWidth / 2) - (Table.PocketWidth * (float)1.8),
                Table.WallThickness)
            );

            this._borders.Add(new Triangle(
                (Table.InnerWidth / 4) + 5 - ((Table.InnerWidth / 2) - (Table.PocketWidth * (float)1.8)) / 2,
                0,
                (Table.PocketWidth * -.8f),
                Table.WallThickness
            ));

            // NorthEast
            this._borders.Add(new Structures.Rectangle(
                (Table.InnerWidth / 4) * 3 - 5,
                Table.WallThickness / -2,
                (Table.InnerWidth / 2) - (Table.PocketWidth * (float)1.8),
                Table.WallThickness)
            );

            // SouthWest
            this._borders.Add(new Structures.Rectangle(
                (Table.InnerWidth / 4) + 5,
                Table.InnerHeight + (Table.WallThickness / 2),
                (Table.InnerWidth / 2) - (Table.PocketWidth * (float)1.8),
                Table.WallThickness)
            );

            // SouthEast
            this._borders.Add(new Structures.Rectangle(
                (Table.InnerWidth / 4) * 3 - 5,
                Table.InnerHeight + (Table.WallThickness / 2),
                (Table.InnerWidth / 2) - (Table.PocketWidth * (float)1.8),
                Table.WallThickness)
            );

            // West
            this._borders.Add(new Structures.Rectangle(
                Table.WallThickness / -2,
                (Table.InnerHeight / 2),
                Table.WallThickness,
                Table.InnerHeight - (Table.PocketWidth * 2))
            );

            // East
            this._borders.Add(new Structures.Rectangle(
                Table.InnerWidth + (Table.WallThickness / 2),
                (Table.InnerHeight / 2),
                Table.WallThickness,
                Table.InnerHeight - (Table.PocketWidth * 2))
            );
        }
    }
}
