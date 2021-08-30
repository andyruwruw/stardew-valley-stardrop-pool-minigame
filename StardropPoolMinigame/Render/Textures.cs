using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardropPoolMinigame.Constants;

namespace StardropPoolMinigame.Render
{
    class Textures
    {
        public class Tileset
        {
            public static Texture2D Default;

            public static Texture2D Font;

            public static Texture2D PortraitAbigail;

            public static Texture2D PortraitGus;

            public static Texture2D PortraitSam;

            public static Texture2D PortraitSebastian;
        }

        public class Color
        {
            public class Solid
            {
                public static Microsoft.Xna.Framework.Color HOVER_ACCENT = new Microsoft.Xna.Framework.Color(255, 217, 104);

                public static Microsoft.Xna.Framework.Color DISABLED = new Microsoft.Xna.Framework.Color(50, 50, 50);

                public static Microsoft.Xna.Framework.Color BACKGROUND = Microsoft.Xna.Framework.Color.Black;

                public static Microsoft.Xna.Framework.Color MARGIN = new Microsoft.Xna.Framework.Color(5, 3, 4);

                
            }

            public class Shader
            {
                public static Microsoft.Xna.Framework.Color SHADOWED = new Microsoft.Xna.Framework.Color(50, 50, 50);
            }
        }

        public class Ball
        {
            public class Base
            {
                public static Rectangle WHITE = new Rectangle(RenderConstants.TILE_SIZE * 20, RenderConstants.TILE_SIZE * 13, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle YELLOW = new Rectangle(RenderConstants.TILE_SIZE * 21, RenderConstants.TILE_SIZE * 13, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle BLUE = new Rectangle(RenderConstants.TILE_SIZE * 22, RenderConstants.TILE_SIZE * 13, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle RED = new Rectangle(RenderConstants.TILE_SIZE * 23, RenderConstants.TILE_SIZE * 13, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle PURPLE = new Rectangle(RenderConstants.TILE_SIZE * 24, RenderConstants.TILE_SIZE * 13, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle ORANGE = new Rectangle(RenderConstants.TILE_SIZE * 20, RenderConstants.TILE_SIZE * 14, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle GREEN = new Rectangle(RenderConstants.TILE_SIZE * 21, RenderConstants.TILE_SIZE * 14, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle MAROON = new Rectangle(RenderConstants.TILE_SIZE * 22, RenderConstants.TILE_SIZE * 14, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle BLACK = new Rectangle(RenderConstants.TILE_SIZE * 23, RenderConstants.TILE_SIZE * 14, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);
            }

            public class Core
            {
                public static Rectangle CORE_0_0 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 3, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle CORE_0_30 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle CORE_0_60 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 1, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle CORE_0_90 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 0, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle CORE_0_N30 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle CORE_0_N60 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle CORE_30_0 = new Rectangle(RenderConstants.TILE_SIZE * 26, RenderConstants.TILE_SIZE * 3, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle CORE_30_30 = new Rectangle(RenderConstants.TILE_SIZE * 26, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle CORE_30_N30 = new Rectangle(RenderConstants.TILE_SIZE * 26, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle CORE_45_60 = new Rectangle(RenderConstants.TILE_SIZE * 26, RenderConstants.TILE_SIZE * 1, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle CORE_45_N60 = new Rectangle(RenderConstants.TILE_SIZE * 26, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle CORE_60_0 = new Rectangle(RenderConstants.TILE_SIZE * 27, RenderConstants.TILE_SIZE * 3, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle CORE_60_30 = new Rectangle(RenderConstants.TILE_SIZE * 27, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle CORE_60_N30 = new Rectangle(RenderConstants.TILE_SIZE * 27, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle CORE_90_0 = new Rectangle(RenderConstants.TILE_SIZE * 28, RenderConstants.TILE_SIZE * 3, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle CORE_90_30 = new Rectangle(RenderConstants.TILE_SIZE * 28, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle CORE_90_60 = new Rectangle(RenderConstants.TILE_SIZE * 27, RenderConstants.TILE_SIZE * 1, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle CORE_90_N30 = new Rectangle(RenderConstants.TILE_SIZE * 28, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle CORE_90_N60 = new Rectangle(RenderConstants.TILE_SIZE * 27, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle CORE_120_0 = new Rectangle(RenderConstants.TILE_SIZE * 29, RenderConstants.TILE_SIZE * 3, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle CORE_120_30 = new Rectangle(RenderConstants.TILE_SIZE * 29, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle CORE_120_N30 = new Rectangle(RenderConstants.TILE_SIZE * 29, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle CORE_135_60 = new Rectangle(RenderConstants.TILE_SIZE * 28, RenderConstants.TILE_SIZE * 1, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle CORE_135_N60 = new Rectangle(RenderConstants.TILE_SIZE * 28, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle CORE_150_0 = new Rectangle(RenderConstants.TILE_SIZE * 30, RenderConstants.TILE_SIZE * 3, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle CORE_150_30 = new Rectangle(RenderConstants.TILE_SIZE * 30, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle CORE_150_N30 = new Rectangle(RenderConstants.TILE_SIZE * 30, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);
            }

            public class Stripes
            {
                public static Rectangle STRIPES_0_0 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 9, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle STRIPES_0_30 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle STRIPES_0_60 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 7, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle STRIPES_0_90 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 6, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle STRIPES_0_N30 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 10, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

                public static Rectangle STRIPES_0_N60 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 11, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);
            }

            public static Rectangle SHADOW = new Rectangle(RenderConstants.TILE_SIZE * 24, RenderConstants.TILE_SIZE * 14, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);
        }

        public class Cue
        {
            public static Rectangle BASIC = new Rectangle(RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 13, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE);

            public static Rectangle ABIGAIL = new Rectangle(RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 16, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE);

            public static Rectangle GUS = new Rectangle(RenderConstants.TILE_SIZE * 16, RenderConstants.TILE_SIZE * 12, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE);

            public static Rectangle SAM = new Rectangle(RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 14, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE);

            public static Rectangle SEBASTIAN = new Rectangle(RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 15, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE);
        }

        public class Cursor
        {
            public static Rectangle DEFAULT = new Rectangle(RenderConstants.TILE_SIZE * 23, RenderConstants.TILE_SIZE * 11, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

            public static Rectangle FRAME_1 = new Rectangle(RenderConstants.TILE_SIZE * 20, RenderConstants.TILE_SIZE * 11, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

            public static Rectangle FRAME_2 = new Rectangle(RenderConstants.TILE_SIZE * 21, RenderConstants.TILE_SIZE * 11, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

            public static Rectangle FRAME_3 = new Rectangle(RenderConstants.TILE_SIZE * 22, RenderConstants.TILE_SIZE * 11, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);
        }

        public class PortraitFire
        {
            public static Rectangle FRAME_1 = new Rectangle(0, RenderConstants.TILE_SIZE * 17, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

            public static Rectangle FRAME_2 = new Rectangle(RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 17, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

            public static Rectangle FRAME_3 = new Rectangle(RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 17, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

            public static Rectangle FRAME_4 = new Rectangle(RenderConstants.TILE_SIZE * 12, RenderConstants.TILE_SIZE * 17, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

            public static Rectangle FRAME_5 = new Rectangle(RenderConstants.TILE_SIZE * 16, RenderConstants.TILE_SIZE * 17, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

            public static Rectangle FRAME_6 = new Rectangle(RenderConstants.TILE_SIZE * 20, RenderConstants.TILE_SIZE * 17, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

            public static Rectangle FRAME_7 = new Rectangle(RenderConstants.TILE_SIZE * 24, RenderConstants.TILE_SIZE * 17, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

            public static Rectangle FRAME_8 = new Rectangle(RenderConstants.TILE_SIZE * 28, RenderConstants.TILE_SIZE * 17, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);
        }

        public class Portrait
        {
            public class Sam
            {
                public static Rectangle DEFAULT = new Rectangle(0, 0, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

                public static Rectangle LAUGH = new Rectangle(RenderConstants.TILE_SIZE * 4, 0, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

                public static Rectangle SAD = new Rectangle(0, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

                public static Rectangle FRUSTRATED = new Rectangle(RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

                public static Rectangle OOPS = new Rectangle(0, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

                public static Rectangle GLARE = new Rectangle(RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

                public static Rectangle STRAIGHT_FACE = new Rectangle(RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 12, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

                public static Rectangle SHOCK = new Rectangle(0, RenderConstants.TILE_SIZE * 16, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

                public static Rectangle EMBARASSED = new Rectangle(0, RenderConstants.TILE_SIZE * 20, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);
            }

            public class Sebastian
            {
                public static Rectangle DEFAULT = new Rectangle(0, 0, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

                public static Rectangle GLAD = new Rectangle(RenderConstants.TILE_SIZE * 4, 0, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

                public static Rectangle SAD = new Rectangle(RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

                public static Rectangle BLUSH = new Rectangle(0, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

                public static Rectangle GLARE = new Rectangle(RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

                public static Rectangle SMURK = new Rectangle(RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 12, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);
            }

            public class Abigail
            {
                public static Rectangle DEFAULT = new Rectangle(0, 0, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

                public static Rectangle LAUGH = new Rectangle(RenderConstants.TILE_SIZE * 4, 0, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

                public static Rectangle SAD = new Rectangle(0, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

                public static Rectangle CONFUSED = new Rectangle(RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

                public static Rectangle BLUSH = new Rectangle(0, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

                public static Rectangle GLARE = new Rectangle(RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

                public static Rectangle SUPRISED = new Rectangle(RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 12, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);
            }

            public class Gus
            {
                public static Rectangle DEFAULT = new Rectangle(0, 0, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

                public static Rectangle LAUGH = new Rectangle(RenderConstants.TILE_SIZE * 4, 0, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

                public static Rectangle BLUSH = new Rectangle(0, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

                public static Rectangle GLARE = new Rectangle(RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);
            }
        }

        public class Table
        {
            public class Edge
            {
                public class Front
                {
                    public static Rectangle EAST = new Rectangle(RenderConstants.TILE_SIZE * 22, RenderConstants.TILE_SIZE * 23, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

                    public static Rectangle NORTH = new Rectangle(RenderConstants.TILE_SIZE * 22, RenderConstants.TILE_SIZE * 21, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

                    public static Rectangle SOUTH = new Rectangle(RenderConstants.TILE_SIZE * 20, RenderConstants.TILE_SIZE * 23, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

                    public static Rectangle WEST = new Rectangle(RenderConstants.TILE_SIZE * 20, RenderConstants.TILE_SIZE * 21, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);
                }

                public class Back
                {
                    public static Rectangle EAST = new Rectangle(RenderConstants.TILE_SIZE * 12, RenderConstants.TILE_SIZE * 23, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

                    public static Rectangle NORTH = new Rectangle(RenderConstants.TILE_SIZE * 12, RenderConstants.TILE_SIZE * 21, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

                    public static Rectangle SOUTH = new Rectangle(RenderConstants.TILE_SIZE * 10, RenderConstants.TILE_SIZE * 23, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

                    public static Rectangle WEST = new Rectangle(RenderConstants.TILE_SIZE * 10, RenderConstants.TILE_SIZE * 21, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);
                }
            }

            public class Pocket
            {
                public class Front
                {
                    public static Rectangle NORTH = new Rectangle(RenderConstants.TILE_SIZE * 18, RenderConstants.TILE_SIZE * 21, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

                    public static Rectangle NORTH_EAST = new Rectangle(RenderConstants.TILE_SIZE * 16, RenderConstants.TILE_SIZE * 21, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

                    public static Rectangle NORTH_WEST = new Rectangle(RenderConstants.TILE_SIZE * 14, RenderConstants.TILE_SIZE * 21, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

                    public static Rectangle SOUTH = new Rectangle(RenderConstants.TILE_SIZE * 18, RenderConstants.TILE_SIZE * 23, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

                    public static Rectangle SOUTH_EAST = new Rectangle(RenderConstants.TILE_SIZE * 16, RenderConstants.TILE_SIZE * 23, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

                    public static Rectangle SOUTH_WEST = new Rectangle(RenderConstants.TILE_SIZE * 14, RenderConstants.TILE_SIZE * 23, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);
                }

                public class Back
                {
                    public static Rectangle NORTH = new Rectangle(RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 21, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

                    public static Rectangle NORTH_EAST = new Rectangle(RenderConstants.TILE_SIZE * 6, RenderConstants.TILE_SIZE * 21, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

                    public static Rectangle NORTH_WEST = new Rectangle(RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 21, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

                    public static Rectangle SOUTH = new Rectangle(RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 23, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

                    public static Rectangle SOUTH_EAST = new Rectangle(RenderConstants.TILE_SIZE * 6, RenderConstants.TILE_SIZE * 23, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

                    public static Rectangle SOUTH_WEST = new Rectangle(RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 23, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);
                }
                

                
            }

            public static Rectangle FELT = new Rectangle(RenderConstants.TILE_SIZE * 20, RenderConstants.TILE_SIZE * 15, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);
        }

        public static Rectangle BAR_SHELVES = new Rectangle(0, 0, RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 8);

        public static Rectangle FLOOR_TILES = new Rectangle(RenderConstants.TILE_SIZE * 16, RenderConstants.TILE_SIZE * 13, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle PORTRAIT_RAYS = new Rectangle(0, RenderConstants.TILE_SIZE * 21, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle POCKETED_BALLS_BORDER_BOX_SUPPORTS = new Rectangle(RenderConstants.TILE_SIZE * 24, RenderConstants.TILE_SIZE * 11, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle GAME_TITLE = new Rectangle(0, RenderConstants.TILE_SIZE * 12, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 5);

        public class Characters
        {
            public static Rectangle LOWERCASE_A = new Rectangle(
                0,
                0,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_A = new Rectangle(
                Characters.LOWERCASE_A.X + Characters.LOWERCASE_A.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                0,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_B = new Rectangle(
                Characters.UPPERCASE_A.X + Characters.UPPERCASE_A.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                0,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_B = new Rectangle(
                Characters.LOWERCASE_B.X + Characters.LOWERCASE_B.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                0,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_C = new Rectangle(
                Characters.UPPERCASE_B.X + Characters.UPPERCASE_B.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                0,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

             public static Rectangle UPPERCASE_C = new Rectangle(
                Characters.LOWERCASE_C.X + Characters.LOWERCASE_C.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                0,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_D = new Rectangle(
                Characters.UPPERCASE_C.X + Characters.UPPERCASE_C.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                0,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_D = new Rectangle(
                Characters.LOWERCASE_D.X + Characters.LOWERCASE_D.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                0,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_E = new Rectangle(
                Characters.UPPERCASE_D.X + Characters.UPPERCASE_D.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                0,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_E = new Rectangle(
                Characters.LOWERCASE_E.X + Characters.LOWERCASE_E.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                0,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_F = new Rectangle(
                Characters.UPPERCASE_E.X + Characters.UPPERCASE_E.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                0,
                5,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_F = new Rectangle(
                Characters.LOWERCASE_F.X + Characters.LOWERCASE_F.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                0,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_G = new Rectangle(
                Characters.UPPERCASE_F.X + Characters.UPPERCASE_F.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                0,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_G = new Rectangle(
                Characters.LOWERCASE_G.X + Characters.LOWERCASE_G.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                0,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_H = new Rectangle(
                Characters.UPPERCASE_G.X + Characters.UPPERCASE_G.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                0,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_H = new Rectangle(
               Characters.LOWERCASE_H.X + Characters.LOWERCASE_H.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
               0,
               7,
               RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_I = new Rectangle(
                Characters.UPPERCASE_H.X + Characters.UPPERCASE_H.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                0,
                2,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_I = new Rectangle(
                Characters.LOWERCASE_I.X + Characters.LOWERCASE_I.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                0,
                6,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_J = new Rectangle(
                Characters.UPPERCASE_I.X + Characters.UPPERCASE_I.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                0,
                4,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_J = new Rectangle(
               0,
               RenderConstants.Font.CHARACTER_HEIGHT,
               7,
               RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_K = new Rectangle(
                Characters.UPPERCASE_J.X + Characters.UPPERCASE_J.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT,
                6,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_K = new Rectangle(
                Characters.LOWERCASE_K.X + Characters.LOWERCASE_K.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_L = new Rectangle(
                Characters.UPPERCASE_K.X + Characters.UPPERCASE_K.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT,
                2,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_L = new Rectangle(
                Characters.LOWERCASE_L.X + Characters.LOWERCASE_L.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_M = new Rectangle(
                Characters.UPPERCASE_L.X + Characters.UPPERCASE_L.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_M = new Rectangle(
                Characters.LOWERCASE_M.X + Characters.LOWERCASE_M.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_N = new Rectangle(
                Characters.UPPERCASE_M.X + Characters.UPPERCASE_M.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT,
                6,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_N = new Rectangle(
                Characters.LOWERCASE_N.X + Characters.LOWERCASE_N.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_O = new Rectangle(
                Characters.UPPERCASE_N.X + Characters.UPPERCASE_N.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_O = new Rectangle(
                Characters.LOWERCASE_O.X + Characters.LOWERCASE_O.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_P = new Rectangle(
                Characters.UPPERCASE_O.X + Characters.UPPERCASE_O.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_P = new Rectangle(
                Characters.LOWERCASE_P.X + Characters.LOWERCASE_P.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_Q = new Rectangle(
                Characters.UPPERCASE_P.X + Characters.UPPERCASE_P.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_Q = new Rectangle(
                Characters.LOWERCASE_Q.X + Characters.LOWERCASE_Q.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_R = new Rectangle(
                Characters.UPPERCASE_Q.X + Characters.UPPERCASE_Q.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT,
                5,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_R = new Rectangle(
                Characters.LOWERCASE_R.X + Characters.LOWERCASE_R.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_S = new Rectangle(
                Characters.UPPERCASE_R.X + Characters.UPPERCASE_R.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_S = new Rectangle(
                Characters.LOWERCASE_S.X + Characters.LOWERCASE_S.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_T = new Rectangle(
                0,
                RenderConstants.Font.CHARACTER_HEIGHT * 2,
                5,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_T = new Rectangle(
                Characters.LOWERCASE_T.X + Characters.LOWERCASE_T.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 2,
                6,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_U = new Rectangle(
                Characters.UPPERCASE_T.X + Characters.UPPERCASE_T.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 2,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_U = new Rectangle(
                Characters.LOWERCASE_U.X + Characters.LOWERCASE_U.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 2,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_V = new Rectangle(
                Characters.UPPERCASE_U.X + Characters.UPPERCASE_U.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 2,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_V = new Rectangle(
                Characters.LOWERCASE_V.X + Characters.LOWERCASE_V.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 2,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_W = new Rectangle(
                Characters.UPPERCASE_V.X + Characters.UPPERCASE_V.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 2,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_W = new Rectangle(
                Characters.LOWERCASE_W.X + Characters.LOWERCASE_W.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 2,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_X = new Rectangle(
                Characters.UPPERCASE_W.X + Characters.UPPERCASE_W.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 2,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_X = new Rectangle(
                Characters.LOWERCASE_X.X + Characters.LOWERCASE_X.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 2,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_Y = new Rectangle(
                Characters.UPPERCASE_X.X + Characters.UPPERCASE_X.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 2,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_Y = new Rectangle(
                Characters.LOWERCASE_Y.X + Characters.LOWERCASE_Y.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 2,
                6,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_Z = new Rectangle(
                Characters.UPPERCASE_Y.X + Characters.UPPERCASE_Y.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 2,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_Z = new Rectangle(
                Characters.LOWERCASE_Z.X + Characters.LOWERCASE_Z.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 2,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle PERIOD = new Rectangle(
                    Characters.UPPERCASE_Z.X + Characters.UPPERCASE_Z.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                    RenderConstants.Font.CHARACTER_HEIGHT * 2,
                    2,
                    RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle COMMA = new Rectangle(
                PERIOD.X + PERIOD.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 2,
                3,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle EXCLAMATION_POINT = new Rectangle(
                COMMA.X + COMMA.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 2,
                2,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle QUESTION_MARK = new Rectangle(
                EXCLAMATION_POINT.X + EXCLAMATION_POINT.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 2,
                6,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle APOSTROPHE = new Rectangle(
                QUESTION_MARK.X + QUESTION_MARK.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 2,
                2,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle COLON = new Rectangle(
                APOSTROPHE.X + APOSTROPHE.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 2,
                2,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_A_GRAVE = new Rectangle(
                        COLON.X + COLON.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                        RenderConstants.Font.CHARACTER_HEIGHT * 2,
                        7,
                        RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_A_GRAVE = new Rectangle(
                        0,
                        RenderConstants.Font.CHARACTER_HEIGHT * 3,
                        7,
                        RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_A_ACUTE = new Rectangle(
                Characters.UPPERCASE_A_GRAVE.X + Characters.UPPERCASE_A_GRAVE.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 3,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_A_ACUTE = new Rectangle(
                LOWERCASE_A_ACUTE.X + LOWERCASE_A_ACUTE.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 3,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_A_CIRCUMFLEX = new Rectangle(
                Characters.UPPERCASE_A_ACUTE.X + Characters.UPPERCASE_A_ACUTE.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 3,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_A_CIRCUMFLEX = new Rectangle(
                LOWERCASE_A_CIRCUMFLEX.X + LOWERCASE_A_CIRCUMFLEX.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 3,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_A_DIAERISIS = new Rectangle(
                Characters.UPPERCASE_A_CIRCUMFLEX.X + Characters.UPPERCASE_A_CIRCUMFLEX.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 3,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_A_DIAERISIS = new Rectangle(
                LOWERCASE_A_DIAERISIS.X + LOWERCASE_A_DIAERISIS.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 3,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_AE_LIGATURE = new Rectangle(
                Characters.UPPERCASE_A_DIAERISIS.X + Characters.UPPERCASE_A_DIAERISIS.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 3,
                12,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_AE_LIGATURE = new Rectangle(
                LOWERCASE_AE_LIGATURE.X + LOWERCASE_AE_LIGATURE.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 3,
                11,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_C_CEDILLA = new Rectangle(
                Characters.UPPERCASE_AE_LIGATURE.X + Characters.UPPERCASE_AE_LIGATURE.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 3,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_C_CEDILLA = new Rectangle(
                LOWERCASE_C_CEDILLA.X + LOWERCASE_C_CEDILLA.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 3,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_E_ACUTE = new Rectangle(
                Characters.UPPERCASE_C_CEDILLA.X + Characters.UPPERCASE_C_CEDILLA.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 3,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_E_ACUTE = new Rectangle(
                LOWERCASE_E_ACUTE.X + LOWERCASE_E_ACUTE.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 3,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_E_GRAVE = new Rectangle(
                Characters.UPPERCASE_E_ACUTE.X + Characters.UPPERCASE_E_ACUTE.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 3,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_E_GRAVE = new Rectangle(
                LOWERCASE_E_GRAVE.X + LOWERCASE_E_GRAVE.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 3,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_E_CIRCUMFLEX = new Rectangle(
                Characters.UPPERCASE_E_GRAVE.X + Characters.UPPERCASE_E_GRAVE.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 3,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_E_CIRCUMFLEX = new Rectangle(
                LOWERCASE_E_CIRCUMFLEX.X + LOWERCASE_E_CIRCUMFLEX.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 3,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_E_DIAERISIS = new Rectangle(
                0,
                RenderConstants.Font.CHARACTER_HEIGHT * 4,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_E_DIAERISIS = new Rectangle(
                LOWERCASE_E_DIAERISIS.X + LOWERCASE_E_DIAERISIS.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 4,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_I_GRAVE = new Rectangle(
                Characters.UPPERCASE_E_DIAERISIS.X + Characters.UPPERCASE_E_DIAERISIS.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 4,
                2,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_I_GRAVE = new Rectangle(
                LOWERCASE_I_GRAVE.X + LOWERCASE_I_GRAVE.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 4,
                6,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_I_ACUTE = new Rectangle(
                Characters.UPPERCASE_I_GRAVE.X + Characters.UPPERCASE_I_GRAVE.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 4,
                2,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_I_ACUTE = new Rectangle(
                LOWERCASE_I_ACUTE.X + LOWERCASE_I_ACUTE.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 4,
                6,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_I_CIRCUMFLEX = new Rectangle(
                Characters.UPPERCASE_I_ACUTE.X + Characters.UPPERCASE_I_ACUTE.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 4,
                3,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_I_CIRCUMFLEX = new Rectangle(
                LOWERCASE_I_CIRCUMFLEX.X + LOWERCASE_I_CIRCUMFLEX.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 4,
                6,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_I_DIAERISIS = new Rectangle(
                Characters.UPPERCASE_I_CIRCUMFLEX.X + Characters.UPPERCASE_I_CIRCUMFLEX.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 4,
                4,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_I_DIAERISIS = new Rectangle(
                LOWERCASE_I_DIAERISIS.X + LOWERCASE_I_DIAERISIS.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 4,
                6,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_O_ACUTE = new Rectangle(
                Characters.UPPERCASE_I_DIAERISIS.X + Characters.UPPERCASE_I_DIAERISIS.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 4,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_O_ACUTE = new Rectangle(
                LOWERCASE_O_ACUTE.X + LOWERCASE_O_ACUTE.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 4,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_O_GRAVE = new Rectangle(
                Characters.UPPERCASE_O_ACUTE.X + Characters.UPPERCASE_O_ACUTE.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 4,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_O_GRAVE = new Rectangle(
                LOWERCASE_O_GRAVE.X + LOWERCASE_O_GRAVE.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 4,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_O_CIRCUMFLEX = new Rectangle(
                Characters.UPPERCASE_O_GRAVE.X + Characters.UPPERCASE_O_GRAVE.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 4,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_O_CIRCUMFLEX = new Rectangle(
                LOWERCASE_O_CIRCUMFLEX.X + LOWERCASE_O_CIRCUMFLEX.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 4,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_O_DIAERISIS = new Rectangle(
                Characters.UPPERCASE_O_CIRCUMFLEX.X + Characters.UPPERCASE_O_CIRCUMFLEX.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 4,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_O_DIAERISIS = new Rectangle(
                LOWERCASE_O_DIAERISIS.X + LOWERCASE_O_DIAERISIS.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 4,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_OE_LIGATURE = new Rectangle(
                Characters.UPPERCASE_O_DIAERISIS.X + Characters.UPPERCASE_O_DIAERISIS.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 4,
                12,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_OE_LIGATURE = new Rectangle(
                0,
                RenderConstants.Font.CHARACTER_HEIGHT * 5,
                12,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_U_ACUTE = new Rectangle(
                Characters.UPPERCASE_OE_LIGATURE.X + Characters.UPPERCASE_OE_LIGATURE.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 5,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_U_ACUTE = new Rectangle(
                LOWERCASE_U_ACUTE.X + LOWERCASE_U_ACUTE.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 5,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_U_GRAVE = new Rectangle(
                Characters.UPPERCASE_U_ACUTE.X + Characters.UPPERCASE_U_ACUTE.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 5,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_U_GRAVE = new Rectangle(
                LOWERCASE_U_GRAVE.X + LOWERCASE_U_GRAVE.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 5,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_U_CIRCUMFLEX = new Rectangle(
                Characters.UPPERCASE_U_GRAVE.X + Characters.UPPERCASE_U_GRAVE.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 5,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_U_CIRCUMFLEX = new Rectangle(
                LOWERCASE_U_CIRCUMFLEX.X + LOWERCASE_U_CIRCUMFLEX.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 5,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_U_DIAERISIS = new Rectangle(
                Characters.UPPERCASE_U_CIRCUMFLEX.X + Characters.UPPERCASE_U_CIRCUMFLEX.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 5,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_U_DIAERISIS = new Rectangle(
                LOWERCASE_U_DIAERISIS.X + LOWERCASE_U_DIAERISIS.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 5,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_Y_DIAERISIS = new Rectangle(
               Characters.UPPERCASE_U_DIAERISIS.X + Characters.UPPERCASE_U_DIAERISIS.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
               RenderConstants.Font.CHARACTER_HEIGHT * 5,
               7,
               RenderConstants.Font.CHARACTER_HEIGHT);
            
            public static Rectangle UPPERCASE_Y_DIAERISIS = new Rectangle(
                LOWERCASE_Y_DIAERISIS.X + LOWERCASE_Y_DIAERISIS.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 5,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle ESZETT = new Rectangle(
                    Characters.UPPERCASE_Y_DIAERISIS.X + Characters.UPPERCASE_Y_DIAERISIS.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                    RenderConstants.Font.CHARACTER_HEIGHT * 5,
                    7,
                    RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle LOWERCASE_N_TILDE = new Rectangle(
               ESZETT.X + ESZETT.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
               RenderConstants.Font.CHARACTER_HEIGHT * 5,
               7,
               RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle UPPERCASE_N_TILDE = new Rectangle(
                LOWERCASE_N_TILDE.X + LOWERCASE_N_TILDE.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
                RenderConstants.Font.CHARACTER_HEIGHT * 5,
                7,
                RenderConstants.Font.CHARACTER_HEIGHT);

            public static Rectangle INVERTED_QUESTION_MARK = new Rectangle(
               Characters.UPPERCASE_N_TILDE.X + Characters.UPPERCASE_N_TILDE.Width + RenderConstants.Font.SPACE_BETWEEN_CHARACTERS_ON_TILESET,
               RenderConstants.Font.CHARACTER_HEIGHT * 5,
               6,
               RenderConstants.Font.CHARACTER_HEIGHT);
        }

        public static void LoadTextures()
        {
            Logger.Info("Loading Tilesets");
            Tileset.Default = Game1.content.Load<Texture2D>("Minigames\\stardropPool");
            Tileset.Font = Game1.content.Load<Texture2D>("Minigames\\stardropPoolFont");
            Tileset.PortraitAbigail = Game1.content.Load<Texture2D>("Portraits\\Abigail");
            Tileset.PortraitGus = Game1.content.Load<Texture2D>("Portraits\\Gus");
            Tileset.PortraitSam = Game1.content.Load<Texture2D>("Portraits\\Sam");
            Tileset.PortraitSebastian = Game1.content.Load<Texture2D>("Portraits\\Sebastian");
        }

        public static Rectangle GetBallCoreBounds(Vector2 orientation)
        {
            if (orientation.Y == 90)
            {
                return Ball.Core.CORE_0_90;
            }
            if (orientation.Y == 60)
            {
                if (orientation.X == 0)
                {
                    return Ball.Core.CORE_0_60;
                }
                if (orientation.X == 45)
                {
                    return Ball.Core.CORE_45_60;
                }
                if (orientation.X == 90)
                {
                    return Ball.Core.CORE_90_60;
                }
                if (orientation.X == 135)
                {
                    return Ball.Core.CORE_135_60;
                }
            }
            if (orientation.Y == 30)
            {
                if (orientation.X == 0)
                {
                    return Ball.Core.CORE_0_30;
                }
                if (orientation.X == 30)
                {
                    return Ball.Core.CORE_30_30;
                }
                if (orientation.X == 60)
                {
                    return Ball.Core.CORE_60_30;
                }
                if (orientation.X == 90)
                {
                    return Ball.Core.CORE_90_30;
                }
                if (orientation.X == 120)
                {
                    return Ball.Core.CORE_120_30;
                }
                if (orientation.X == 150)
                {
                    return Ball.Core.CORE_150_30;
                }
            }
            if (orientation.Y == 0)
            {
                if (orientation.X == 0)
                {
                    return Ball.Core.CORE_0_0;
                }
                if (orientation.X == 30)
                {
                    return Ball.Core.CORE_30_0;
                }
                if (orientation.X == 60)
                {
                    return Ball.Core.CORE_60_0;
                }
                if (orientation.X == 90)
                {
                    return Ball.Core.CORE_90_0;
                }
                if (orientation.X == 120)
                {
                    return Ball.Core.CORE_120_0;
                }
                if (orientation.X == 150)
                {
                    return Ball.Core.CORE_150_0;
                }
            }
            if (orientation.Y == -30)
            {
                if (orientation.X == 0)
                {
                    return Ball.Core.CORE_0_N30;
                }
                if (orientation.X == 30)
                {
                    return Ball.Core.CORE_30_N30;
                }
                if (orientation.X == 60)
                {
                    return Ball.Core.CORE_60_N30;
                }
                if (orientation.X == 90)
                {
                    return Ball.Core.CORE_90_N30;
                }
                if (orientation.X == 120)
                {
                    return Ball.Core.CORE_120_N30;
                }
                if (orientation.X == 150)
                {
                    return Ball.Core.CORE_150_N30;
                }
            }
            if (orientation.Y == -60)
            {
                if (orientation.X == 0)
                {
                    return Ball.Core.CORE_0_N60;
                }
                if (orientation.X == 45)
                {
                    return Ball.Core.CORE_45_N60;
                }
                if (orientation.X == 90)
                {
                    return Ball.Core.CORE_90_N60;
                }
                if (orientation.X == 135)
                {
                    return Ball.Core.CORE_135_N60;
                }
            }
            return Ball.Core.CORE_0_0;
        }

        public static Rectangle GetBallStripesBounds(Vector2 orientation)
        {
            if (orientation.Y == 90)
            {
                return Ball.Stripes.STRIPES_0_90;
            }
            if (orientation.Y == 60)
            {
                return Ball.Stripes.STRIPES_0_60;
            }
            if (orientation.Y == 30)
            {
                return Ball.Stripes.STRIPES_0_30;
            }
            if (orientation.Y == 0)
            {
                return Ball.Stripes.STRIPES_0_0;
            }
            if (orientation.Y == -30)
            {
                return Ball.Stripes.STRIPES_0_N30;
            }
            if (orientation.Y == -60)
            {
                return Ball.Stripes.STRIPES_0_N60;
            }
            return Ball.Stripes.STRIPES_0_0;
        }

        public static Rectangle GetCharacterBoundsFromChar(char character)
        {
            switch (character)
            {
                case 'A':
                    return Characters.UPPERCASE_A;
                case 'b':
                    return Characters.LOWERCASE_B;
                case 'B':
                    return Characters.UPPERCASE_B;
                case 'c':
                    return Characters.LOWERCASE_C;
                case 'C':
                    return Characters.UPPERCASE_C;
                case 'd':
                    return Characters.LOWERCASE_D;
                case 'D':
                    return Characters.UPPERCASE_D;
                case 'e':
                    return Characters.LOWERCASE_E;
                case 'E':
                    return Characters.UPPERCASE_E;
                case 'f':
                    return Characters.LOWERCASE_F;
                case 'F':
                    return Characters.UPPERCASE_F;
                case 'g':
                    return Characters.LOWERCASE_G;
                case 'G':
                    return Characters.UPPERCASE_G;
                case 'h':
                    return Characters.LOWERCASE_H;
                case 'H':
                    return Characters.UPPERCASE_H;
                case 'i':
                    return Characters.LOWERCASE_I;
                case 'I':
                    return Characters.UPPERCASE_I;
                case 'j':
                    return Characters.LOWERCASE_J;
                case 'J':
                    return Characters.UPPERCASE_J;
                case 'k':
                    return Characters.LOWERCASE_K;
                case 'K':
                    return Characters.UPPERCASE_K;
                case 'l':
                    return Characters.LOWERCASE_L;
                case 'L':
                    return Characters.UPPERCASE_L;
                case 'm':
                    return Characters.LOWERCASE_M;
                case 'M':
                    return Characters.UPPERCASE_M;
                case 'n':
                    return Characters.LOWERCASE_N;
                case 'N':
                    return Characters.UPPERCASE_N;
                case 'o':
                    return Characters.LOWERCASE_O;
                case 'O':
                    return Characters.UPPERCASE_O;
                case 'p':
                    return Characters.LOWERCASE_P;
                case 'P':
                    return Characters.UPPERCASE_P;
                case 'q':
                    return Characters.LOWERCASE_Q;
                case 'Q':
                    return Characters.UPPERCASE_Q;
                case 'r':
                    return Characters.LOWERCASE_R;
                case 'R':
                    return Characters.UPPERCASE_R;
                case 's':
                    return Characters.LOWERCASE_S;
                case 'S':
                    return Characters.UPPERCASE_S;
                case 't':
                    return Characters.LOWERCASE_T;
                case 'T':
                    return Characters.UPPERCASE_T;
                case 'u':
                    return Characters.LOWERCASE_U;
                case 'U':
                    return Characters.UPPERCASE_U;
                case 'v':
                    return Characters.LOWERCASE_V;
                case 'V':
                    return Characters.UPPERCASE_V;
                case 'w':
                    return Characters.LOWERCASE_W;
                case 'W':
                    return Characters.UPPERCASE_W;
                case 'x':
                    return Characters.LOWERCASE_X;
                case 'X':
                    return Characters.UPPERCASE_X;
                case 'y':
                    return Characters.LOWERCASE_Y;
                case 'Y':
                    return Characters.UPPERCASE_Y;
                case 'z':
                    return Characters.LOWERCASE_Z;
                case 'Z':
                    return Characters.UPPERCASE_Z;
                case '.':
                    return Characters.PERIOD;
                case ',':
                    return Characters.COMMA;
                case '!':
                    return Characters.EXCLAMATION_POINT;
                case '?':
                    return Characters.QUESTION_MARK;
                case '\'':
                    return Characters.APOSTROPHE;
                case ':':
                    return Characters.COLON;
                case 'à':
                    return Characters.LOWERCASE_A_GRAVE;
                case 'À':
                    return Characters.UPPERCASE_A_GRAVE;
                case 'á':
                    return Characters.LOWERCASE_A_ACUTE;
                case 'Á':
                    return Characters.UPPERCASE_A_ACUTE;
                case 'â':
                    return Characters.LOWERCASE_A_CIRCUMFLEX;
                case 'Â':
                    return Characters.UPPERCASE_A_CIRCUMFLEX;
                case 'ä':
                    return Characters.LOWERCASE_A_DIAERISIS;
                case 'Ä':
                    return Characters.UPPERCASE_A_DIAERISIS;
                case 'æ':
                    return Characters.LOWERCASE_AE_LIGATURE;
                case 'Æ':
                    return Characters.UPPERCASE_AE_LIGATURE;
                case 'ç':
                    return Characters.LOWERCASE_C_CEDILLA;
                case 'Ç':
                    return Characters.UPPERCASE_C_CEDILLA;
                case 'é':
                    return Characters.LOWERCASE_E_ACUTE;
                case 'É':
                    return Characters.UPPERCASE_E_ACUTE;
                case 'è':
                    return Characters.LOWERCASE_E_GRAVE;
                case 'È':
                    return Characters.UPPERCASE_E_GRAVE;
                case 'ê':
                    return Characters.LOWERCASE_E_CIRCUMFLEX;
                case 'Ê':
                    return Characters.UPPERCASE_E_CIRCUMFLEX;
                case 'ë':
                    return Characters.LOWERCASE_E_DIAERISIS;
                case 'Ë':
                    return Characters.UPPERCASE_E_DIAERISIS;
                case 'ì':
                    return Characters.LOWERCASE_I_GRAVE;
                case 'Ì':
                    return Characters.UPPERCASE_I_GRAVE;
                case 'í':
                    return Characters.LOWERCASE_I_ACUTE;
                case 'Í':
                    return Characters.UPPERCASE_I_ACUTE;
                case 'î':
                    return Characters.LOWERCASE_I_CIRCUMFLEX;
                case 'Î':
                    return Characters.UPPERCASE_I_CIRCUMFLEX;
                case 'ï':
                    return Characters.LOWERCASE_I_DIAERISIS;
                case 'Ï':
                    return Characters.UPPERCASE_I_DIAERISIS;
                case 'ó':
                    return Characters.LOWERCASE_O_ACUTE;
                case 'Ó':
                    return Characters.UPPERCASE_O_ACUTE;
                case 'ò':
                    return Characters.LOWERCASE_O_GRAVE;
                case 'Ò':
                    return Characters.UPPERCASE_O_GRAVE;
                case 'ô':
                    return Characters.LOWERCASE_O_CIRCUMFLEX;
                case 'Ô':
                    return Characters.UPPERCASE_O_CIRCUMFLEX;
                case 'ö':
                    return Characters.LOWERCASE_O_DIAERISIS;
                case 'Ö':
                    return Characters.UPPERCASE_O_DIAERISIS;
                case 'œ':
                    return Characters.LOWERCASE_OE_LIGATURE;
                case 'Œ':
                    return Characters.UPPERCASE_OE_LIGATURE;
                case 'ú':
                    return Characters.LOWERCASE_U_ACUTE;
                case 'Ú':
                    return Characters.UPPERCASE_U_ACUTE;
                case 'ù':
                    return Characters.LOWERCASE_U_GRAVE;
                case 'Ù':
                    return Characters.UPPERCASE_U_GRAVE;
                case 'û':
                    return Characters.LOWERCASE_U_CIRCUMFLEX;
                case 'Û':
                    return Characters.UPPERCASE_U_CIRCUMFLEX;
                case 'ü':
                    return Characters.LOWERCASE_U_DIAERISIS;
                case 'Ü':
                    return Characters.UPPERCASE_U_DIAERISIS;
                case 'ÿ':
                    return Characters.LOWERCASE_Y_DIAERISIS;
                case 'Ÿ':
                    return Characters.UPPERCASE_Y_DIAERISIS;
                case 'ß':
                    return Characters.ESZETT;
                case 'ñ':
                    return Characters.LOWERCASE_N_TILDE;
                case 'Ñ':
                    return Characters.UPPERCASE_N_TILDE;
                case '¿':
                    return Characters.INVERTED_QUESTION_MARK;
                default:
                    return Characters.LOWERCASE_A;
            }
        }
    }
}