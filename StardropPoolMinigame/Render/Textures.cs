using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardropPoolMinigame.Constants;

namespace StardropPoolMinigame.Render
{
    class Textures
    {
        public static Texture2D TileSheet;

        public static Texture2D AbigailPortraitTilesheet;

        public static Texture2D GusPortraitTilesheet;

        public static Texture2D SamPortraitTilesheet;

        public static Texture2D SebastianPortraitTilesheet;

        public static void LoadTextures()
        {
            Textures.TileSheet = Game1.content.Load<Texture2D>("Minigames\\stardropPool");
            Textures.AbigailPortraitTilesheet = Game1.content.Load<Texture2D>("Portraits\\Abigail");
            Textures.GusPortraitTilesheet = Game1.content.Load<Texture2D>("Portraits\\Gus");
            Textures.SamPortraitTilesheet = Game1.content.Load<Texture2D>("Portraits\\Sam");
            Textures.SebastianPortraitTilesheet = Game1.content.Load<Texture2D>("Portraits\\Sebastian");
        }

        public static Rectangle BACKGROUND_BAR_SHELVES_BOUNDS = new Rectangle(0, 0, RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 8);

        public static Rectangle BACKGROUND_FLOOR_TILES_HIGH_RESOLUTION_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 16, RenderConstants.TILE_SIZE * 13, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle BALL_COLOR_WHITE = new Rectangle(RenderConstants.TILE_SIZE * 20, RenderConstants.TILE_SIZE * 13, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_COLOR_YELLOW = new Rectangle(RenderConstants.TILE_SIZE * 21, RenderConstants.TILE_SIZE * 13, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_COLOR_BLUE = new Rectangle(RenderConstants.TILE_SIZE * 22, RenderConstants.TILE_SIZE * 13, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_COLOR_RED = new Rectangle(RenderConstants.TILE_SIZE * 23, RenderConstants.TILE_SIZE * 13, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_COLOR_PURPLE = new Rectangle(RenderConstants.TILE_SIZE * 24, RenderConstants.TILE_SIZE * 13, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_COLOR_ORANGE = new Rectangle(RenderConstants.TILE_SIZE * 20, RenderConstants.TILE_SIZE * 14, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_COLOR_GREEN = new Rectangle(RenderConstants.TILE_SIZE * 21, RenderConstants.TILE_SIZE * 14, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_COLOR_MAROON = new Rectangle(RenderConstants.TILE_SIZE * 22, RenderConstants.TILE_SIZE * 14, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_COLOR_BLACK = new Rectangle(RenderConstants.TILE_SIZE * 23, RenderConstants.TILE_SIZE * 14, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_0_0 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 3, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_0_30 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_0_60 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 1, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_0_90 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 0, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_0_n30 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_0_n60 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_30_0 = new Rectangle(RenderConstants.TILE_SIZE * 26, RenderConstants.TILE_SIZE * 3, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_30_30 = new Rectangle(RenderConstants.TILE_SIZE * 26, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_30_n30 = new Rectangle(RenderConstants.TILE_SIZE * 26, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_45_60 = new Rectangle(RenderConstants.TILE_SIZE * 26, RenderConstants.TILE_SIZE * 1, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_45_n60 = new Rectangle(RenderConstants.TILE_SIZE * 26, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_60_0 = new Rectangle(RenderConstants.TILE_SIZE * 27, RenderConstants.TILE_SIZE * 3, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_60_30 = new Rectangle(RenderConstants.TILE_SIZE * 27, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_60_n30 = new Rectangle(RenderConstants.TILE_SIZE * 27, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_90_0 = new Rectangle(RenderConstants.TILE_SIZE * 28, RenderConstants.TILE_SIZE * 3, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_90_30 = new Rectangle(RenderConstants.TILE_SIZE * 28, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_90_60 = new Rectangle(RenderConstants.TILE_SIZE * 27, RenderConstants.TILE_SIZE * 1, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_90_n30 = new Rectangle(RenderConstants.TILE_SIZE * 28, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_90_n60 = new Rectangle(RenderConstants.TILE_SIZE * 27, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_120_0 = new Rectangle(RenderConstants.TILE_SIZE * 29, RenderConstants.TILE_SIZE * 3, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_120_30 = new Rectangle(RenderConstants.TILE_SIZE * 29, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_120_n30 = new Rectangle(RenderConstants.TILE_SIZE * 29, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_135_60 = new Rectangle(RenderConstants.TILE_SIZE * 28, RenderConstants.TILE_SIZE * 1, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_135_n60 = new Rectangle(RenderConstants.TILE_SIZE * 28, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_150_0 = new Rectangle(RenderConstants.TILE_SIZE * 30, RenderConstants.TILE_SIZE * 3, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_150_30 = new Rectangle(RenderConstants.TILE_SIZE * 30, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_150_n30 = new Rectangle(RenderConstants.TILE_SIZE * 30, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_STRIPES_0_0 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 9, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_STRIPES_0_30 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_STRIPES_0_60 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 7, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_STRIPES_0_90 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 6, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_STRIPES_0_n30 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 10, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_STRIPES_0_n60 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 11, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_SHADOW = new Rectangle(RenderConstants.TILE_SIZE * 24, RenderConstants.TILE_SIZE * 14, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BUTTON_TEXT_ABIGAIL_BOUNDS = new Rectangle(0, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE);

        public static Rectangle BUTTON_TEXT_ABIGAIL_HOVER_BOUNDS = new Rectangle(0, RenderConstants.TILE_SIZE * 9, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE);

        public static Rectangle BUTTON_TEXT_CHALLENGE_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 20, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE);

        public static Rectangle BUTTON_TEXT_CHALLENGE_HOVER_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 20, RenderConstants.TILE_SIZE * 9, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE);

        public static Rectangle BUTTON_TEXT_GALLERY_BOUNDS = new Rectangle(0, RenderConstants.TILE_SIZE * 10, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE);

        public static Rectangle BUTTON_TEXT_GALLERY_HOVER_BOUNDS = new Rectangle(0, RenderConstants.TILE_SIZE * 11, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE);

        public static Rectangle BUTTON_TEXT_GUS_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE);

        public static Rectangle BUTTON_TEXT_GUS_HOVER_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE * 9, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE);

        public static Rectangle BUTTON_TEXT_MULTIPLAYER_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE * 10, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE);

        public static Rectangle BUTTON_TEXT_MULTIPLAYER_HOVER_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE * 11, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE);

        public static Rectangle BUTTON_TEXT_PLAY_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 10, RenderConstants.TILE_SIZE * 10, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE);

        public static Rectangle BUTTON_TEXT_PLAY_HOVER_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 10, RenderConstants.TILE_SIZE * 11, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE);

        public static Rectangle BUTTON_TEXT_SAM_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 10, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE);

        public static Rectangle BUTTON_TEXT_SAM_HOVER_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 10, RenderConstants.TILE_SIZE * 9, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE);

        public static Rectangle BUTTON_TEXT_SEBASTIAN_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 15, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE);

        public static Rectangle BUTTON_TEXT_SEBASTIAN_HOVER_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 15, RenderConstants.TILE_SIZE * 9, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE);

        public static Rectangle BUTTON_TEXT_SETTINGS_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 15, RenderConstants.TILE_SIZE * 10, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE);

        public static Rectangle BUTTON_TEXT_SETTINGS_HOVER_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 15, RenderConstants.TILE_SIZE * 11, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE);

        public static Rectangle BUTTON_TEXT_UNKNOWN_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 20, RenderConstants.TILE_SIZE * 10, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE);

        public static Rectangle CUE_BASIC_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 13, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE);

        public static Rectangle CUE_ABIGAIL_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 16, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE);

        public static Rectangle CUE_GUS_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 16, RenderConstants.TILE_SIZE * 12, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE);

        public static Rectangle CUE_SAM_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 14, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE);

        public static Rectangle CUE_SEBASTIAN_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 15, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE);

        public static Rectangle CURSOR_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 23, RenderConstants.TILE_SIZE * 11, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle CURSOR_TRANSITION_1_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 20, RenderConstants.TILE_SIZE * 11, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle CURSOR_TRANSITION_2_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 21, RenderConstants.TILE_SIZE * 11, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle CURSOR_TRANSITION_3_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 22, RenderConstants.TILE_SIZE * 11, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle EFFECTS_PORTRAIT_FIRE_1_BOUNDS = new Rectangle(0, RenderConstants.TILE_SIZE * 17, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle EFFECTS_PORTRAIT_FIRE_2_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 17, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle EFFECTS_PORTRAIT_FIRE_3_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 17, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle EFFECTS_PORTRAIT_FIRE_4_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 12, RenderConstants.TILE_SIZE * 17, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle EFFECTS_PORTRAIT_FIRE_5_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 16, RenderConstants.TILE_SIZE * 17, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle EFFECTS_PORTRAIT_FIRE_6_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 20, RenderConstants.TILE_SIZE * 17, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle EFFECTS_PORTRAIT_FIRE_7_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 24, RenderConstants.TILE_SIZE * 17, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle EFFECTS_PORTRAIT_FIRE_8_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 28, RenderConstants.TILE_SIZE * 17, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle EFFECTS_SHINE_BOUNDS = new Rectangle(0, RenderConstants.TILE_SIZE * 21, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle POCKETED_BALLS_BORDER_BOX_SUPPORTS_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 24, RenderConstants.TILE_SIZE * 11, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle PORTRAIT_ABIGAIL_DEFAULT_BOUNDS = new Rectangle(0, 0, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle PORTRAIT_ABIGAIL_LAUGH_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 4, 0, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle PORTRAIT_ABIGAIL_SAD_BOUNDS = new Rectangle(0, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle PORTRAIT_ABIGAIL_CONFUSED_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle PORTRAIT_ABIGAIL_BLUSH_BOUNDS = new Rectangle(0, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle PORTRAIT_ABIGAIL_GLARE_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle PORTRAIT_ABIGAIL_SUPRISED_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 12, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle PORTRAIT_GUS_DEFAULT_BOUNDS = new Rectangle(0, 0, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle PORTRAIT_GUS_LAUGH_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 4, 0, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle PORTRAIT_GUS_BLUSH_BOUNDS = new Rectangle(0, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle PORTRAIT_GUS_GLARE_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle PORTRAIT_SAM_DEFAULT_BOUNDS = new Rectangle(0, 0, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle PORTRAIT_SAM_LAUGH_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 4, 0, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle PORTRAIT_SAM_SAD_BOUNDS = new Rectangle(0, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle PORTRAIT_SAM_FRUSTRATED_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle PORTRAIT_SAM_OOPS_BOUNDS = new Rectangle(0, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle PORTRAIT_SAM_GLARE_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle PORTRAIT_SAM_STRAIGHT_FACE_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 12, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle PORTRAIT_SAM_SHOCK_BOUNDS = new Rectangle(0, RenderConstants.TILE_SIZE * 16, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle PORTRAIT_SAM_EMBARASSED_BOUNDS = new Rectangle(0, RenderConstants.TILE_SIZE * 20, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle PORTRAIT_SEBASTIAN_DEFAULT_BOUNDS = new Rectangle(0, 0, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle PORTRAIT_SEBASTIAN_GLAD_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 4, 0, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle PORTRAIT_SEBASTIAN_SAD_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle PORTRAIT_SEBASTIAN_BLUSH_BOUNDS = new Rectangle(0, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle PORTRAIT_SEBASTIAN_ANGRY_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle PORTRAIT_SEBASTIAN_SMURK_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 12, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

        public static Rectangle TABLE_FELT_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 20, RenderConstants.TILE_SIZE * 15, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle TABLE_EDGE_EAST_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 12, RenderConstants.TILE_SIZE * 23, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

        public static Rectangle TABLE_EDGE_NORTH_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 12, RenderConstants.TILE_SIZE * 21, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

        public static Rectangle TABLE_EDGE_SOUTH_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 10, RenderConstants.TILE_SIZE * 23, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

        public static Rectangle TABLE_EDGE_WEST_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 10, RenderConstants.TILE_SIZE * 21, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

        public static Rectangle TABLE_POCKET_NORTH_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 21, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

        public static Rectangle TABLE_POCKET_NORTH_EAST_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 6, RenderConstants.TILE_SIZE * 21, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

        public static Rectangle TABLE_POCKET_NORTH_WEST_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 21, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

        public static Rectangle TABLE_POCKET_SOUTH_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 23, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

        public static Rectangle TABLE_POCKET_SOUTH_EAST_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 6, RenderConstants.TILE_SIZE * 23, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

        public static Rectangle TABLE_POCKET_SOUTH_WEST_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 23, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

        public static Rectangle TITLE_GAME_BOUNDS = new Rectangle(0, RenderConstants.TILE_SIZE * 12, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 5);

        public static Rectangle TITLE_CHARACTER_SELECT_MENU_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 12, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE);
    }
}