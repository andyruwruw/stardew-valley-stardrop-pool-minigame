using Microsoft.Xna.Framework;
using MinigameFramework.Constants;

namespace StardopPoolMinigame.Constants
{
    /// <summary>
    /// Locations of textures.
    /// </summary>
    class TextureConstants
    {
        public static Rectangle BarShelves = new Rectangle(
            0,
            0,
            GenericRenderConstants.TileSize * 25,
            GenericRenderConstants.TileSize * 8
        );

        public static Rectangle FloorTiles = new Rectangle(
            GenericRenderConstants.TileSize * 16,
            GenericRenderConstants.TileSize * 8,
            GenericRenderConstants.TileSize * 4,
            GenericRenderConstants.TileSize * 4
        );

        public static Rectangle GameTitle = new Rectangle(
            0,
            GenericRenderConstants.TileSize * 8,
            GenericRenderConstants.TileSize * 8,
            GenericRenderConstants.TileSize * 5
        );

        public static Rectangle PortraitRays = new Rectangle(
            0,
            GenericRenderConstants.TileSize * 8,
            GenericRenderConstants.TileSize * 17,
            GenericRenderConstants.TileSize * 4
        );

        /// <summary>
		/// Bounds for all <see cref="Entities.Ball"/> components
		/// </summary>
		public class Ball
        {
            public static Rectangle Highlight = new Rectangle(
                GenericRenderConstants.TileSize * 23,
                GenericRenderConstants.TileSize * 11,
                GenericRenderConstants.TileSize,
                GenericRenderConstants.TileSize
            );

            public static Rectangle Shadow = new Rectangle(
                GenericRenderConstants.TileSize * 24,
                GenericRenderConstants.TileSize * 10,
                GenericRenderConstants.TileSize,
                GenericRenderConstants.TileSize
            );

            public class Base
            {
                public static Rectangle Black = new Rectangle(
                    GenericRenderConstants.TileSize * 23,
                    GenericRenderConstants.TileSize * 10,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle Blue = new Rectangle(
                    GenericRenderConstants.TileSize * 22,
                    GenericRenderConstants.TileSize * 9,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle Green = new Rectangle(
                    GenericRenderConstants.TileSize * 21,
                    GenericRenderConstants.TileSize * 10,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle Maroon = new Rectangle(
                    GenericRenderConstants.TileSize * 22,
                    GenericRenderConstants.TileSize * 10,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle Orange = new Rectangle(
                    GenericRenderConstants.TileSize * 20,
                    GenericRenderConstants.TileSize * 10,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle Purple = new Rectangle(
                    GenericRenderConstants.TileSize * 24,
                    GenericRenderConstants.TileSize * 9,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle Red = new Rectangle(
                    GenericRenderConstants.TileSize * 23,
                    GenericRenderConstants.TileSize * 9,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle White = new Rectangle(
                    GenericRenderConstants.TileSize * 20,
                    GenericRenderConstants.TileSize * 9,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle Yellow = new Rectangle(
                    GenericRenderConstants.TileSize * 21,
                    GenericRenderConstants.TileSize * 9,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );
            }

            public class Core
            {
                public static Rectangle CORE_0_0 = new Rectangle(
                    GenericRenderConstants.TileSize * 25,
                    GenericRenderConstants.TileSize * 3,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle CORE_0_30 = new Rectangle(
                    GenericRenderConstants.TileSize * 25,
                    GenericRenderConstants.TileSize * 2,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle CORE_0_60 = new Rectangle(
                    GenericRenderConstants.TileSize * 25,
                    GenericRenderConstants.TileSize * 1,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle CORE_0_90 = new Rectangle(
                    GenericRenderConstants.TileSize * 25,
                    GenericRenderConstants.TileSize * 0,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle CORE_0_N30 = new Rectangle(
                    GenericRenderConstants.TileSize * 25,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle CORE_0_N60 = new Rectangle(
                    GenericRenderConstants.TileSize * 25,
                    GenericRenderConstants.TileSize * 5,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle CORE_120_0 = new Rectangle(
                    GenericRenderConstants.TileSize * 29,
                    GenericRenderConstants.TileSize * 3,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle CORE_120_30 = new Rectangle(
                    GenericRenderConstants.TileSize * 29,
                    GenericRenderConstants.TileSize * 2,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle CORE_120_N30 = new Rectangle(
                    GenericRenderConstants.TileSize * 29,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle CORE_135_60 = new Rectangle(
                    GenericRenderConstants.TileSize * 28,
                    GenericRenderConstants.TileSize * 1,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle CORE_135_N60 = new Rectangle(
                    GenericRenderConstants.TileSize * 28,
                    GenericRenderConstants.TileSize * 5,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle CORE_150_0 = new Rectangle(
                    GenericRenderConstants.TileSize * 30,
                    GenericRenderConstants.TileSize * 3,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle CORE_150_30 = new Rectangle(
                    GenericRenderConstants.TileSize * 30,
                    GenericRenderConstants.TileSize * 2,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle CORE_150_N30 = new Rectangle(
                    GenericRenderConstants.TileSize * 30,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle CORE_30_0 = new Rectangle(
                    GenericRenderConstants.TileSize * 26,
                    GenericRenderConstants.TileSize * 3,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle CORE_30_30 = new Rectangle(
                    GenericRenderConstants.TileSize * 26,
                    GenericRenderConstants.TileSize * 2,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle CORE_30_N30 = new Rectangle(
                    GenericRenderConstants.TileSize * 26,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle CORE_45_60 = new Rectangle(
                    GenericRenderConstants.TileSize * 26,
                    GenericRenderConstants.TileSize * 1,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle CORE_45_N60 = new Rectangle(
                    GenericRenderConstants.TileSize * 26,
                    GenericRenderConstants.TileSize * 5,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle CORE_60_0 = new Rectangle(
                    GenericRenderConstants.TileSize * 27,
                    GenericRenderConstants.TileSize * 3,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle CORE_60_30 = new Rectangle(
                    GenericRenderConstants.TileSize * 27,
                    GenericRenderConstants.TileSize * 2,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle CORE_60_N30 = new Rectangle(
                    GenericRenderConstants.TileSize * 27,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle CORE_90_0 = new Rectangle(
                    GenericRenderConstants.TileSize * 28,
                    GenericRenderConstants.TileSize * 3,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle CORE_90_30 = new Rectangle(
                    GenericRenderConstants.TileSize * 28,
                    GenericRenderConstants.TileSize * 2,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle CORE_90_60 = new Rectangle(
                    GenericRenderConstants.TileSize * 27,
                    GenericRenderConstants.TileSize * 1,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle CORE_90_N30 = new Rectangle(
                    GenericRenderConstants.TileSize * 28,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle CORE_90_N60 = new Rectangle(
                    GenericRenderConstants.TileSize * 27,
                    GenericRenderConstants.TileSize * 5,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );
            }

            public class Stripes
            {
                public static Rectangle STRIPES_0_0 = new Rectangle(
                    GenericRenderConstants.TileSize * 25,
                    GenericRenderConstants.TileSize * 9,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle STRIPES_0_30 = new Rectangle(
                    GenericRenderConstants.TileSize * 25,
                    GenericRenderConstants.TileSize * 8,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle STRIPES_0_60 = new Rectangle(
                    GenericRenderConstants.TileSize * 25,
                    GenericRenderConstants.TileSize * 7,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle STRIPES_0_90 = new Rectangle(
                    GenericRenderConstants.TileSize * 25,
                    GenericRenderConstants.TileSize * 6,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle STRIPES_0_N30 = new Rectangle(
                    GenericRenderConstants.TileSize * 25,
                    GenericRenderConstants.TileSize * 10,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );

                public static Rectangle STRIPES_0_N60 = new Rectangle(
                    GenericRenderConstants.TileSize * 25,
                    GenericRenderConstants.TileSize * 11,
                    GenericRenderConstants.TileSize,
                    GenericRenderConstants.TileSize
                );
            }
        }

        /// <summary>
        /// Bounds for <see cref="Entities.Cue"/>
        /// </summary>
        public class Cue
        {
            public static Rectangle Abigail = new Rectangle(GenericRenderConstants.TileSize * 8, GenericRenderConstants.TileSize * 11,
                GenericRenderConstants.TileSize * 8, GenericRenderConstants.TileSize);

            public static Rectangle Basic = new Rectangle(GenericRenderConstants.TileSize * 8, GenericRenderConstants.TileSize * 8,
                GenericRenderConstants.TileSize * 8, GenericRenderConstants.TileSize);

            public static Rectangle Gus = new Rectangle(GenericRenderConstants.TileSize * 8, GenericRenderConstants.TileSize * 12,
                GenericRenderConstants.TileSize * 8, GenericRenderConstants.TileSize);

            public static Rectangle Sam = new Rectangle(GenericRenderConstants.TileSize * 8, GenericRenderConstants.TileSize * 9,
                GenericRenderConstants.TileSize * 8, GenericRenderConstants.TileSize);

            public static Rectangle Sebastian = new Rectangle(GenericRenderConstants.TileSize * 8,
                GenericRenderConstants.TileSize * 10, GenericRenderConstants.TileSize * 8, GenericRenderConstants.TileSize);
        }

        /// <summary>
        /// Bounds for <see cref="Entities.Cursor"/>
        /// </summary>
        public class Cursor
        {
            public static Rectangle Default = new Rectangle(GenericRenderConstants.TileSize * 23, GenericRenderConstants.TileSize * 8,
                GenericRenderConstants.TileSize, GenericRenderConstants.TileSize);

            public static Rectangle Frame1 = new Rectangle(GenericRenderConstants.TileSize * 20, GenericRenderConstants.TileSize * 8,
                GenericRenderConstants.TileSize, GenericRenderConstants.TileSize);

            public static Rectangle Frame2 = new Rectangle(GenericRenderConstants.TileSize * 21, GenericRenderConstants.TileSize * 8,
                GenericRenderConstants.TileSize, GenericRenderConstants.TileSize);

            public static Rectangle Frame3 = new Rectangle(GenericRenderConstants.TileSize * 22, GenericRenderConstants.TileSize * 8,
                GenericRenderConstants.TileSize, GenericRenderConstants.TileSize);
        }

        public class Particle
        {
            public class Glimmer
            {
                public static Rectangle Frame1 = new Rectangle(GenericRenderConstants.TileSize * 20,
                    GenericRenderConstants.TileSize * 11, GenericRenderConstants.TileSize, GenericRenderConstants.TileSize);

                public static Rectangle Frame2 = new Rectangle(GenericRenderConstants.TileSize * 21,
                    GenericRenderConstants.TileSize * 11, GenericRenderConstants.TileSize, GenericRenderConstants.TileSize);
            }

            public class PurpleWhisp
            {
                public static Rectangle Frame1 = new Rectangle(GenericRenderConstants.TileSize * 22,
                    GenericRenderConstants.TileSize * 12, GenericRenderConstants.TileSize, GenericRenderConstants.TileSize);

                public static Rectangle Frame2 = new Rectangle(GenericRenderConstants.TileSize * 23,
                    GenericRenderConstants.TileSize * 12, GenericRenderConstants.TileSize, GenericRenderConstants.TileSize);

                public static Rectangle Frame3 = new Rectangle(GenericRenderConstants.TileSize * 24,
                    GenericRenderConstants.TileSize * 12, GenericRenderConstants.TileSize, GenericRenderConstants.TileSize);
            }

            public class Spark
            {
                public static Rectangle Frame1 = new Rectangle(GenericRenderConstants.TileSize * 19,
                    GenericRenderConstants.TileSize * 12, GenericRenderConstants.TileSize, GenericRenderConstants.TileSize);

                public static Rectangle Frame2 = new Rectangle(GenericRenderConstants.TileSize * 20,
                    GenericRenderConstants.TileSize * 12, GenericRenderConstants.TileSize, GenericRenderConstants.TileSize);

                public static Rectangle Frame3 = new Rectangle(GenericRenderConstants.TileSize * 21,
                    GenericRenderConstants.TileSize * 12, GenericRenderConstants.TileSize, GenericRenderConstants.TileSize);
            }

            public class Sparkle
            {
                public static Rectangle Frame1 = new Rectangle(GenericRenderConstants.TileSize * 16,
                    GenericRenderConstants.TileSize * 12, GenericRenderConstants.TileSize, GenericRenderConstants.TileSize);

                public static Rectangle Frame2 = new Rectangle(GenericRenderConstants.TileSize * 17,
                    GenericRenderConstants.TileSize * 12, GenericRenderConstants.TileSize, GenericRenderConstants.TileSize);

                public static Rectangle Frame3 = new Rectangle(GenericRenderConstants.TileSize * 18,
                    GenericRenderConstants.TileSize * 12, GenericRenderConstants.TileSize, GenericRenderConstants.TileSize);
            }
        }

        public class PocketedBalls
        {
            public static Rectangle BorderBox = new Rectangle(GenericRenderConstants.TileSize * 12,
                GenericRenderConstants.TileSize * 21, GenericRenderConstants.TileSize * 7, GenericRenderConstants.TileSize * 2);

            public static Rectangle Supports = new Rectangle(GenericRenderConstants.TileSize * 24,
                GenericRenderConstants.TileSize * 8, GenericRenderConstants.TileSize, GenericRenderConstants.TileSize);
        }

        /// <summary>
        /// Bounds for <see cref="Entities.PortraitFire"/>
        /// </summary>
        public class PortraitFire
        {
            public static Rectangle Frame1 = new Rectangle(GenericRenderConstants.TileSize * 12,
                GenericRenderConstants.TileSize * 17, GenericRenderConstants.TileSize * 4, GenericRenderConstants.TileSize * 4);

            public static Rectangle Frame2 = new Rectangle(GenericRenderConstants.TileSize * 16,
                GenericRenderConstants.TileSize * 17, GenericRenderConstants.TileSize * 4, GenericRenderConstants.TileSize * 4);

            public static Rectangle Frame3 = new Rectangle(GenericRenderConstants.TileSize * 20,
                GenericRenderConstants.TileSize * 17, GenericRenderConstants.TileSize * 4, GenericRenderConstants.TileSize * 4);

            public static Rectangle Frame4 = new Rectangle(GenericRenderConstants.TileSize * 24,
                GenericRenderConstants.TileSize * 17, GenericRenderConstants.TileSize * 4, GenericRenderConstants.TileSize * 4);

            public static Rectangle Frame5 = new Rectangle(GenericRenderConstants.TileSize * 28,
                GenericRenderConstants.TileSize * 17, GenericRenderConstants.TileSize * 4, GenericRenderConstants.TileSize * 4);

            public static Rectangle Frame6 = new Rectangle(0, GenericRenderConstants.TileSize * 21,
                GenericRenderConstants.TileSize * 4, GenericRenderConstants.TileSize * 4);

            public static Rectangle Frame7 = new Rectangle(GenericRenderConstants.TileSize * 4, GenericRenderConstants.TileSize * 21,
                GenericRenderConstants.TileSize * 4, GenericRenderConstants.TileSize * 4);

            public static Rectangle Frame8 = new Rectangle(GenericRenderConstants.TileSize * 8, GenericRenderConstants.TileSize * 21,
                GenericRenderConstants.TileSize * 4, GenericRenderConstants.TileSize * 4);
        }

        /// <summary>
        /// Bounds for all <see cref="Entities.TableSegment"/> pieces
        /// </summary>
        public class Table
        {
            public static Rectangle Felt = new Rectangle(GenericRenderConstants.TileSize * 22, GenericRenderConstants.TileSize * 11,
                GenericRenderConstants.TileSize, GenericRenderConstants.TileSize);

            public class Corner
            {
                public class Back
                {
                    public static Rectangle NorthEast = new Rectangle(0, GenericRenderConstants.TileSize * 19,
                        GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle NorthWest = new Rectangle(GenericRenderConstants.TileSize * 4,
                        GenericRenderConstants.TileSize * 19, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle SouthEast = new Rectangle(0, GenericRenderConstants.TileSize * 17,
                        GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle SouthWest = new Rectangle(GenericRenderConstants.TileSize * 4,
                        GenericRenderConstants.TileSize * 17, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);
                }

                public class Front
                {
                    public static Rectangle NorthEast = new Rectangle(GenericRenderConstants.TileSize * 2,
                        GenericRenderConstants.TileSize * 19, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle NorthWest = new Rectangle(GenericRenderConstants.TileSize * 6,
                        GenericRenderConstants.TileSize * 19, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle SouthEast = new Rectangle(GenericRenderConstants.TileSize * 2,
                        GenericRenderConstants.TileSize * 17, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle SouthWest = new Rectangle(GenericRenderConstants.TileSize * 6,
                        GenericRenderConstants.TileSize * 17, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);
                }
            }

            public class Edge
            {
                public class Back
                {
                    public static Rectangle East = new Rectangle(GenericRenderConstants.TileSize * 4,
                        GenericRenderConstants.TileSize * 13, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle North = new Rectangle(0, GenericRenderConstants.TileSize * 13,
                        GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle NorthEast = new Rectangle(GenericRenderConstants.TileSize * 28,
                        GenericRenderConstants.TileSize * 13, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle NorthWest = new Rectangle(GenericRenderConstants.TileSize * 24,
                        GenericRenderConstants.TileSize * 13, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle South = new Rectangle(0, GenericRenderConstants.TileSize * 15,
                        GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle SouthEast = new Rectangle(GenericRenderConstants.TileSize * 28,
                        GenericRenderConstants.TileSize * 15, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle SouthWest = new Rectangle(GenericRenderConstants.TileSize * 24,
                        GenericRenderConstants.TileSize * 15, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle West = new Rectangle(GenericRenderConstants.TileSize * 4,
                        GenericRenderConstants.TileSize * 15, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);
                }

                public class Front
                {
                    public static Rectangle East = new Rectangle(GenericRenderConstants.TileSize * 6,
                        GenericRenderConstants.TileSize * 13, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle North = new Rectangle(GenericRenderConstants.TileSize * 2,
                        GenericRenderConstants.TileSize * 13, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle NorthEast = new Rectangle(GenericRenderConstants.TileSize * 30,
                        GenericRenderConstants.TileSize * 13, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle NorthWest = new Rectangle(GenericRenderConstants.TileSize * 26,
                        GenericRenderConstants.TileSize * 13, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle South = new Rectangle(GenericRenderConstants.TileSize * 2,
                        GenericRenderConstants.TileSize * 15, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle SouthEast = new Rectangle(GenericRenderConstants.TileSize * 30,
                        GenericRenderConstants.TileSize * 15, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle SouthWest = new Rectangle(GenericRenderConstants.TileSize * 26,
                        GenericRenderConstants.TileSize * 15, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle West = new Rectangle(GenericRenderConstants.TileSize * 6,
                        GenericRenderConstants.TileSize * 15, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);
                }
            }

            public class Pocket
            {
                public class Back
                {
                    public static Rectangle East = new Rectangle(GenericRenderConstants.TileSize * 20,
                        GenericRenderConstants.TileSize * 13, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle North = new Rectangle(GenericRenderConstants.TileSize * 16,
                        GenericRenderConstants.TileSize * 13, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle NorthEast = new Rectangle(GenericRenderConstants.TileSize * 12,
                        GenericRenderConstants.TileSize * 13, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle NorthWest = new Rectangle(GenericRenderConstants.TileSize * 8,
                        GenericRenderConstants.TileSize * 13, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle South = new Rectangle(GenericRenderConstants.TileSize * 16,
                        GenericRenderConstants.TileSize * 15, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle SouthEast = new Rectangle(GenericRenderConstants.TileSize * 12,
                        GenericRenderConstants.TileSize * 15, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle SouthWest = new Rectangle(GenericRenderConstants.TileSize * 8,
                        GenericRenderConstants.TileSize * 15, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle West = new Rectangle(GenericRenderConstants.TileSize * 20,
                        GenericRenderConstants.TileSize * 15, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);
                }

                public class Front
                {
                    public static Rectangle East = new Rectangle(GenericRenderConstants.TileSize * 22,
                        GenericRenderConstants.TileSize * 13, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle North = new Rectangle(GenericRenderConstants.TileSize * 18,
                        GenericRenderConstants.TileSize * 13, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle NorthEast = new Rectangle(GenericRenderConstants.TileSize * 14,
                        GenericRenderConstants.TileSize * 13, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle NorthWest = new Rectangle(GenericRenderConstants.TileSize * 10,
                        GenericRenderConstants.TileSize * 13, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle South = new Rectangle(GenericRenderConstants.TileSize * 18,
                        GenericRenderConstants.TileSize * 15, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle SouthEast = new Rectangle(GenericRenderConstants.TileSize * 14,
                        GenericRenderConstants.TileSize * 15, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle SouthWest = new Rectangle(GenericRenderConstants.TileSize * 10,
                        GenericRenderConstants.TileSize * 15, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);

                    public static Rectangle West = new Rectangle(GenericRenderConstants.TileSize * 22,
                        GenericRenderConstants.TileSize * 15, GenericRenderConstants.TileSize * 2, GenericRenderConstants.TileSize * 2);
                }
            }
        }
    }
}
