﻿using Microsoft.Xna.Framework;
using StardewValley;

namespace StardropPoolMinigame.Constants
{
    class RenderConstants
    {
        /// <summary>
        /// Dimentions of the minigame window
        /// </summary>
        public class MinigameScreen
        {
            /// <summary>
            /// The height of the minigame window
            /// </summary>
            public static int HEIGHT = 224;

            /// <summary>
            /// The width of the minigame window
            /// </summary>
            public static int WIDTH = 400;
        }
        

        /// <summary>
        /// Tile size on tile sheet
        /// </summary>
        public static int TILE_SIZE = 16;

        /// <summary>
        /// SDV zoom settings
        /// </summary>
        public static float PixelZoomAdjustement()
        {
            return 1f / Game1.options.zoomLevel;
        }

        public static float TileScale()
        {
            return 4 * PixelZoomAdjustement();
        }

        /// <summary>
        /// The height of the mingame window adjusted with zoom settings
        /// </summary>
        public static float AdjustedScreenHeight()
        {
            return MinigameScreen.HEIGHT * TileScale();
        }

        /// <summary>
        /// The width of the mingame window adjusted with zoom settings
        /// </summary>
        public static float AdjustedScreenWidth()
        {
            return MinigameScreen.WIDTH * TileScale();
        }

        /// <summary>
        /// The height of the player's SDV window
        /// </summary>
        public static int ViewportHeight()
        {
            return Game1.game1.localMultiplayerWindow.Height;
        }

        /// <summary>
        /// The width of the player's SDV window
        /// </summary>
        public static int ViewportWidth()
        {
            return Game1.game1.localMultiplayerWindow.Width;
        }

        public static float AdjustedScreenHeightDifference()
        {
            return ViewportHeight() - AdjustedScreenHeight();
        }

        public static float AdjustedScreenWidthDifference()
        {
            return ViewportWidth() - AdjustedScreenWidth();
        }

        public static float AdjustedScreenHeightMargin()
        {
            return AdjustedScreenHeightDifference() / 2;
        }

        public static float AdjustedScreenWidthMargin()
        {
            return AdjustedScreenWidthDifference() / 2;
        }

        public static Vector2 GetCenterOfScreen()
        {
            return new Vector2((ViewportWidth() / 2), (ViewportHeight() / 2));
        }

        public static Vector2 GetMinigameScreenNorthWest()
        {
            return new Vector2(AdjustedScreenWidthMargin(), AdjustedScreenHeightMargin());
        }

        public static Vector2 GetMinigameScreenNorthEast()
        {
            return new Vector2(ViewportWidth() - AdjustedScreenWidthMargin(), AdjustedScreenHeightMargin());
        }

        public static Vector2 GetMinigameScreenSouthWest()
        {
            return new Vector2(AdjustedScreenWidthMargin(), ViewportHeight() - AdjustedScreenHeightMargin());
        }

        public static Vector2 GetMinigameScreenSouthEast()
        {
            return new Vector2(ViewportWidth() - AdjustedScreenWidthMargin(), ViewportHeight() - AdjustedScreenHeightMargin());
        }

        public static Vector2 PixelArtScaleToRaw(Vector2 point)
        {
            return new Vector2(point.X * TileScale() + AdjustedScreenWidthMargin(), point.Y * TileScale() + AdjustedScreenHeightMargin());
        }

        public static Vector2 ConvertMinigameWindowToRaw(Vector2 point)
        {
            return Vector2.Add(Vector2.Multiply(point, RenderConstants.TileScale()), RenderConstants.GetMinigameScreenNorthWest());
        }

        public static Vector2 ConvertRawToMinigameWindow(Vector2 point)
        {
            return new Vector2(point.X - AdjustedScreenWidthMargin(), point.Y - AdjustedScreenHeightMargin());
        }

        public class Font
        {
            public static int CHARACTER_HEIGHT = 13;

            public static int SPACE_BETWEEN_CHARACTERS = 1;

            public static int SPACE_BETWEEN_CHARACTERS_ON_TILESET = 1;

            public static int SPACE_WIDTH = 4;

            public static int LINE_SPACING = 3;

            public static int Y_OFFSET = 1;
        }

        public class Entities
        {
            public class Ball
            {
                public static float MARGIN_LEFT = 3f;

                public static float MARGIN_TOP = 2f;
            }

            public class BallButton
            {
                public static float INNER_PADDING = 8f;

                public static float LEFT_OFFSET = 4f;
            }

            public class PortraitFire
            {
                public static int FRAMES = 8;

                public static int FRAME_DURATION = 4;
            }

            public class TableSegment
            {
                public static int MARGIN = 3;

                public static int BORDER = 10;

                public static int LIP = 5;

                public static int PASSABLE_LIP = 2;

                public static int UNPASSABLE_LIP = 3;

                public static int SPACE_TO_BOUNCEABLE_SURFACE = MARGIN + BORDER + UNPASSABLE_LIP;

                public static int VERTICAL_POCKET_STRAIGHT_EDGE_HEIGHT = 2;

                public static int POCKET_ANGLED_EDGE_HEIGHT = 3;

                public static int FLAT_POCKET_BARE_EDGE_LENGTH = 3;

                public static int ANGLED_POCKET_BARE_EDGE_LENGTH = 6;

                public static int FLAT_POCKET_BORDER_OFFSET = -2;

                public static int ANGLED_POCKET_BORDER_OFFSET = 3;

                public static int POCKET_RADIUS = 7;
            }

            public class PocketedBalls
            {
                public static float SUPPORT_UPPER_MARGIN = -3f;

                public static int SUPPORT_PADDING = 5;

                public static int PADDING = 4;
            }

            public class Particle
            {
                public class Spark
                {
                    public static int FRAMES = 3;

                    public static int FRAME_DURATION = 4;

                    public static float MARGIN_LEFT = 3f;

                    public static float MARGIN_TOP = 3f;
                }
            }
        }

        public class Scenes
        {
            public class MainMenu
            {
                public class GameTitle
                {
                    public static float TOP_MARGIN = 6f;
                }

                public class BallButton
                {
                    public static float BUTTON_MARGIN = 4f;
                }
            }

            public class CharacterSelect
            {
                public class Cursor
                {
                    public static float BOTTOM_MARGIN = 18f;
                }

                public class SelectedName
                {
                    public static float TOP_MARGIN = 18f;
                }
            }

            public class Dialog
            {
                public class Text
                {
                    public static int TOP_MARGIN = 15;

                    public static int MAX_WIDTH = 150;
                }
            }
        }
    }
}
