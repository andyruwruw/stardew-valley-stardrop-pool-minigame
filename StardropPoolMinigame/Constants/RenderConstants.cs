using Microsoft.Xna.Framework;
using StardewValley;

namespace StardropPoolMinigame.Constants
{
    class RenderConstants
    {
        /// <summary>
        /// The height of the mingame window
        /// </summary>
        public static int MINIGAME_SCREEN_HEIGHT = 224;

        /// <summary>
        /// The width of the mingame window
        /// </summary>
        public static int MINIGAME_SCREEN_WIDTH = 400;

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
            return MINIGAME_SCREEN_HEIGHT * TileScale();
        }

        /// <summary>
        /// The width of the mingame window adjusted with zoom settings
        /// </summary>
        public static float AdjustedScreenWidth()
        {
            return MINIGAME_SCREEN_WIDTH * TileScale();
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
            return new Vector2(point.X + AdjustedScreenWidthMargin(), point.Y + AdjustedScreenHeightMargin());
        }

        public static Vector2 ConvertRawToMinigameWindow(Vector2 point)
        {
            return new Vector2(point.X - AdjustedScreenWidthMargin(), point.Y - AdjustedScreenHeightMargin());
        }

        public static float BALL_MARGIN_LEFT = 3f;

        public static float BALL_MARGIN_TOP = 3f;

        public static float BALL_BUTTON_INNER_PADDING = 8f;

        public static float BALL_BUTTON_LEFT_OFFSET = 4f;

        public static float MENU_SCENE_GAME_TITLE_TOP_MARGIN = 6f;

        public static float CURSOR_BOTTOM_MARGIN = 18f;

        public static float CHARACTER_SELECT_NAME_TOP_MARGIN = 18f;
    }
}
