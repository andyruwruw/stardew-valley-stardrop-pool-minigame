using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardropPoolMinigame.Constants;

namespace StardropPoolMinigame.Render
{
    class Textures
    {
        public static Texture2D TileSheet;

        public static Texture2D FontTileSheet;

        public static Texture2D PortraitAbigailTilesheet;

        public static Texture2D PortraitGusTilesheet;

        public static Texture2D PortraitSamTilesheet;

        public static Texture2D PortraitSebastianTilesheet;

        public static void LoadTextures()
        {
            Logger.Info("Loading Tilesheets");
            TileSheet = Game1.content.Load<Texture2D>("Minigames\\stardropPool");
            FontTileSheet = Game1.content.Load<Texture2D>("Minigames\\stardropPoolFont");
            PortraitAbigailTilesheet = Game1.content.Load<Texture2D>("Portraits\\Abigail");
            PortraitGusTilesheet = Game1.content.Load<Texture2D>("Portraits\\Gus");
            PortraitSamTilesheet = Game1.content.Load<Texture2D>("Portraits\\Sam");
            PortraitSebastianTilesheet = Game1.content.Load<Texture2D>("Portraits\\Sebastian");
        }

        public static Color TEXT_HOVER_COLOR = new Color(255, 217, 104);

        public static Color MINIGAME_MARGIN_BACKGROUND_COLOR = new Color(5, 3, 4);

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

        public static Rectangle BALL_CORE_0_N30 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_0_N60 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_30_0 = new Rectangle(RenderConstants.TILE_SIZE * 26, RenderConstants.TILE_SIZE * 3, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_30_30 = new Rectangle(RenderConstants.TILE_SIZE * 26, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_30_N30 = new Rectangle(RenderConstants.TILE_SIZE * 26, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_45_60 = new Rectangle(RenderConstants.TILE_SIZE * 26, RenderConstants.TILE_SIZE * 1, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_45_N60 = new Rectangle(RenderConstants.TILE_SIZE * 26, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_60_0 = new Rectangle(RenderConstants.TILE_SIZE * 27, RenderConstants.TILE_SIZE * 3, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_60_30 = new Rectangle(RenderConstants.TILE_SIZE * 27, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_60_N30 = new Rectangle(RenderConstants.TILE_SIZE * 27, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_90_0 = new Rectangle(RenderConstants.TILE_SIZE * 28, RenderConstants.TILE_SIZE * 3, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_90_30 = new Rectangle(RenderConstants.TILE_SIZE * 28, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_90_60 = new Rectangle(RenderConstants.TILE_SIZE * 27, RenderConstants.TILE_SIZE * 1, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_90_N30 = new Rectangle(RenderConstants.TILE_SIZE * 28, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_90_N60 = new Rectangle(RenderConstants.TILE_SIZE * 27, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_120_0 = new Rectangle(RenderConstants.TILE_SIZE * 29, RenderConstants.TILE_SIZE * 3, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_120_30 = new Rectangle(RenderConstants.TILE_SIZE * 29, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_120_N30 = new Rectangle(RenderConstants.TILE_SIZE * 29, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_135_60 = new Rectangle(RenderConstants.TILE_SIZE * 28, RenderConstants.TILE_SIZE * 1, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_135_N60 = new Rectangle(RenderConstants.TILE_SIZE * 28, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_150_0 = new Rectangle(RenderConstants.TILE_SIZE * 30, RenderConstants.TILE_SIZE * 3, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_150_30 = new Rectangle(RenderConstants.TILE_SIZE * 30, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_CORE_150_N30 = new Rectangle(RenderConstants.TILE_SIZE * 30, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_STRIPES_0_0 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 9, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_STRIPES_0_30 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_STRIPES_0_60 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 7, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_STRIPES_0_90 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 6, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_STRIPES_0_N30 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 10, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_STRIPES_0_N60 = new Rectangle(RenderConstants.TILE_SIZE * 25, RenderConstants.TILE_SIZE * 11, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BALL_SHADOW = new Rectangle(RenderConstants.TILE_SIZE * 24, RenderConstants.TILE_SIZE * 14, RenderConstants.TILE_SIZE, RenderConstants.TILE_SIZE);

        public static Rectangle BUTTON_TEXT_ABIGAIL_BOUNDS = new Rectangle(0, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE);

        public static Rectangle BUTTON_TEXT_CHALLENGE_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 20, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE);

        public static Rectangle BUTTON_TEXT_GALLERY_BOUNDS = new Rectangle(0, RenderConstants.TILE_SIZE * 10, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE);

        public static Rectangle BUTTON_TEXT_GUS_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE);

        public static Rectangle BUTTON_TEXT_MULTIPLAYER_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE * 10, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE);

        public static Rectangle BUTTON_TEXT_PLAY_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 10, RenderConstants.TILE_SIZE * 10, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE);

        public static Rectangle BUTTON_TEXT_SAM_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 10, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE);

        public static Rectangle BUTTON_TEXT_SEBASTIAN_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 15, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE);

        public static Rectangle BUTTON_TEXT_SETTINGS_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 15, RenderConstants.TILE_SIZE * 10, RenderConstants.TILE_SIZE * 5, RenderConstants.TILE_SIZE);

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

        public static Rectangle PORTRAIT_SEBASTIAN_GLARE_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 4, RenderConstants.TILE_SIZE * 4);

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

        public static Rectangle TABLE_EDGE_EAST_FRONT_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 22, RenderConstants.TILE_SIZE * 23, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

        public static Rectangle TABLE_EDGE_NORTH_FRONT_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 22, RenderConstants.TILE_SIZE * 21, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

        public static Rectangle TABLE_EDGE_SOUTH_FRONT_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 20, RenderConstants.TILE_SIZE * 23, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

        public static Rectangle TABLE_EDGE_WEST_FRONT_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 20, RenderConstants.TILE_SIZE * 21, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

        public static Rectangle TABLE_POCKET_NORTH_FRONT_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 18, RenderConstants.TILE_SIZE * 21, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

        public static Rectangle TABLE_POCKET_NORTH_EAST_FRONT_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 16, RenderConstants.TILE_SIZE * 21, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

        public static Rectangle TABLE_POCKET_NORTH_WEST_FRONT_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 14, RenderConstants.TILE_SIZE * 21, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

        public static Rectangle TABLE_POCKET_SOUTH_FRONT_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 18, RenderConstants.TILE_SIZE * 23, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

        public static Rectangle TABLE_POCKET_SOUTH_EAST_FRONT_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 16, RenderConstants.TILE_SIZE * 23, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

        public static Rectangle TABLE_POCKET_SOUTH_WEST_FRONT_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 14, RenderConstants.TILE_SIZE * 23, RenderConstants.TILE_SIZE * 2, RenderConstants.TILE_SIZE * 2);

        public static Rectangle TITLE_GAME_BOUNDS = new Rectangle(0, RenderConstants.TILE_SIZE * 12, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 5);

        public static Rectangle TITLE_CHARACTER_SELECT_MENU_BOUNDS = new Rectangle(RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE * 12, RenderConstants.TILE_SIZE * 8, RenderConstants.TILE_SIZE);

        public static Rectangle LOWERCASE_A_BOUNDS = new Rectangle(0, 0, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle UPPERCASE_A_BOUNDS = new Rectangle(LOWERCASE_A_BOUNDS.X + LOWERCASE_A_BOUNDS.Width, 0, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle LOWERCASE_B_BOUNDS = new Rectangle(UPPERCASE_A_BOUNDS.X + UPPERCASE_A_BOUNDS.Width, 0, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle UPPERCASE_B_BOUNDS = new Rectangle(LOWERCASE_B_BOUNDS.X + LOWERCASE_B_BOUNDS.Width, 0, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle LOWERCASE_C_BOUNDS = new Rectangle(UPPERCASE_B_BOUNDS.X + UPPERCASE_B_BOUNDS.Width, 0, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle UPPERCASE_C_BOUNDS = new Rectangle(LOWERCASE_C_BOUNDS.X + LOWERCASE_C_BOUNDS.Width, 0, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle LOWERCASE_D_BOUNDS = new Rectangle(UPPERCASE_C_BOUNDS.X + UPPERCASE_C_BOUNDS.Width, 0, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle UPPERCASE_D_BOUNDS = new Rectangle(LOWERCASE_D_BOUNDS.X + LOWERCASE_D_BOUNDS.Width, 0, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle LOWERCASE_E_BOUNDS = new Rectangle(UPPERCASE_D_BOUNDS.X + UPPERCASE_D_BOUNDS.Width, 0, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle UPPERCASE_E_BOUNDS = new Rectangle(LOWERCASE_E_BOUNDS.X + LOWERCASE_E_BOUNDS.Width, 0, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle LOWERCASE_F_BOUNDS = new Rectangle(UPPERCASE_E_BOUNDS.X + UPPERCASE_E_BOUNDS.Width, 0, 5, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle UPPERCASE_F_BOUNDS = new Rectangle(LOWERCASE_F_BOUNDS.X + LOWERCASE_F_BOUNDS.Width, 0, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle LOWERCASE_G_BOUNDS = new Rectangle(UPPERCASE_F_BOUNDS.X + UPPERCASE_F_BOUNDS.Width, 0, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle UPPERCASE_G_BOUNDS = new Rectangle(LOWERCASE_G_BOUNDS.X + LOWERCASE_G_BOUNDS.Width, 0, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle LOWERCASE_H_BOUNDS = new Rectangle(UPPERCASE_G_BOUNDS.X + UPPERCASE_G_BOUNDS.Width, 0, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle UPPERCASE_H_BOUNDS = new Rectangle(LOWERCASE_H_BOUNDS.X + LOWERCASE_H_BOUNDS.Width, 0, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle LOWERCASE_I_BOUNDS = new Rectangle(UPPERCASE_H_BOUNDS.X + UPPERCASE_H_BOUNDS.Width, 0, 2, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle UPPERCASE_I_BOUNDS = new Rectangle(LOWERCASE_I_BOUNDS.X + LOWERCASE_I_BOUNDS.Width, 0, 6, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle LOWERCASE_J_BOUNDS = new Rectangle(UPPERCASE_I_BOUNDS.X + UPPERCASE_I_BOUNDS.Width, 0, 4, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle UPPERCASE_J_BOUNDS = new Rectangle(LOWERCASE_J_BOUNDS.X + LOWERCASE_J_BOUNDS.Width, 0, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle LOWERCASE_K_BOUNDS = new Rectangle(UPPERCASE_J_BOUNDS.X + UPPERCASE_J_BOUNDS.Width, 0, 6, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle UPPERCASE_K_BOUNDS = new Rectangle(LOWERCASE_K_BOUNDS.X + LOWERCASE_K_BOUNDS.Width, 0, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle LOWERCASE_L_BOUNDS = new Rectangle(0, RenderConstants.FONT_CHARACTER_HEIGHT, 2, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle UPPERCASE_L_BOUNDS = new Rectangle(LOWERCASE_L_BOUNDS.X + LOWERCASE_L_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle LOWERCASE_M_BOUNDS = new Rectangle(UPPERCASE_L_BOUNDS.X + UPPERCASE_L_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle UPPERCASE_M_BOUNDS = new Rectangle(LOWERCASE_M_BOUNDS.X + LOWERCASE_M_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle LOWERCASE_N_BOUNDS = new Rectangle(UPPERCASE_M_BOUNDS.X + UPPERCASE_M_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT, 6, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle UPPERCASE_N_BOUNDS = new Rectangle(LOWERCASE_N_BOUNDS.X + LOWERCASE_N_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle LOWERCASE_O_BOUNDS = new Rectangle(UPPERCASE_N_BOUNDS.X + UPPERCASE_N_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle UPPERCASE_O_BOUNDS = new Rectangle(LOWERCASE_O_BOUNDS.X + LOWERCASE_O_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle LOWERCASE_P_BOUNDS = new Rectangle(UPPERCASE_O_BOUNDS.X + UPPERCASE_O_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle UPPERCASE_P_BOUNDS = new Rectangle(LOWERCASE_P_BOUNDS.X + LOWERCASE_P_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle LOWERCASE_Q_BOUNDS = new Rectangle(UPPERCASE_P_BOUNDS.X + UPPERCASE_P_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle UPPERCASE_Q_BOUNDS = new Rectangle(LOWERCASE_Q_BOUNDS.X + LOWERCASE_Q_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle LOWERCASE_R_BOUNDS = new Rectangle(UPPERCASE_Q_BOUNDS.X + UPPERCASE_Q_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT, 5, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle UPPERCASE_R_BOUNDS = new Rectangle(LOWERCASE_R_BOUNDS.X + LOWERCASE_R_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle LOWERCASE_S_BOUNDS = new Rectangle(UPPERCASE_R_BOUNDS.X + UPPERCASE_R_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle UPPERCASE_S_BOUNDS = new Rectangle(LOWERCASE_S_BOUNDS.X + LOWERCASE_S_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle LOWERCASE_T_BOUNDS = new Rectangle(UPPERCASE_S_BOUNDS.X + UPPERCASE_S_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT, 5, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle UPPERCASE_T_BOUNDS = new Rectangle(LOWERCASE_T_BOUNDS.X + LOWERCASE_T_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT, 6, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle LOWERCASE_U_BOUNDS = new Rectangle(UPPERCASE_T_BOUNDS.X + UPPERCASE_T_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle UPPERCASE_U_BOUNDS = new Rectangle(LOWERCASE_U_BOUNDS.X + LOWERCASE_U_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle LOWERCASE_V_BOUNDS = new Rectangle(UPPERCASE_U_BOUNDS.X + UPPERCASE_U_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle UPPERCASE_V_BOUNDS = new Rectangle(LOWERCASE_V_BOUNDS.X + LOWERCASE_V_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle LOWERCASE_W_BOUNDS = new Rectangle(0, RenderConstants.FONT_CHARACTER_HEIGHT * 2, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle UPPERCASE_W_BOUNDS = new Rectangle(LOWERCASE_W_BOUNDS.X + LOWERCASE_W_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT * 2, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle LOWERCASE_X_BOUNDS = new Rectangle(UPPERCASE_W_BOUNDS.X + UPPERCASE_W_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT * 2, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle UPPERCASE_X_BOUNDS = new Rectangle(LOWERCASE_X_BOUNDS.X + LOWERCASE_X_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT * 2, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle LOWERCASE_Y_BOUNDS = new Rectangle(UPPERCASE_X_BOUNDS.X + UPPERCASE_X_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT * 2, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle UPPERCASE_Y_BOUNDS = new Rectangle(LOWERCASE_Y_BOUNDS.X + LOWERCASE_Y_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT * 2, 6, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle LOWERCASE_Z_BOUNDS = new Rectangle(UPPERCASE_Y_BOUNDS.X + UPPERCASE_Y_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT * 2, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle UPPERCASE_Z_BOUNDS = new Rectangle(LOWERCASE_Z_BOUNDS.X + LOWERCASE_Z_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT * 2, 7, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle PERIOD_BOUNDS = new Rectangle(UPPERCASE_Z_BOUNDS.X + UPPERCASE_Z_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT * 2, 2, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle COMMA_BOUNDS = new Rectangle(PERIOD_BOUNDS.X + PERIOD_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT * 2, 3, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle EXCLAMATION_POINT_BOUNDS = new Rectangle(COMMA_BOUNDS.X + COMMA_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT * 2, 2, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle QUESTION_MARK_BOUNDS = new Rectangle(EXCLAMATION_POINT_BOUNDS.X + EXCLAMATION_POINT_BOUNDS.Width, RenderConstants.FONT_CHARACTER_HEIGHT * 2, 6, RenderConstants.FONT_CHARACTER_HEIGHT);

        public static Rectangle GetBallCoreBounds(Vector2 orientation)
        {
            if (orientation.Y == 90)
            {
                return BALL_CORE_0_90;
            }
            if (orientation.Y == 60)
            {
                if (orientation.X == 0)
                {
                    return BALL_CORE_0_60;
                }
                if (orientation.X == 45)
                {
                    return BALL_CORE_45_60;
                }
                if (orientation.X == 90)
                {
                    return BALL_CORE_90_60;
                }
                if (orientation.X == 135)
                {
                    return BALL_CORE_135_60;
                }
            }
            if (orientation.Y == 30)
            {
                if (orientation.X == 0)
                {
                    return BALL_CORE_0_30;
                }
                if (orientation.X == 30)
                {
                    return BALL_CORE_30_30;
                }
                if (orientation.X == 60)
                {
                    return BALL_CORE_60_30;
                }
                if (orientation.X == 90)
                {
                    return BALL_CORE_90_30;
                }
                if (orientation.X == 120)
                {
                    return BALL_CORE_120_30;
                }
                if (orientation.X == 150)
                {
                    return BALL_CORE_150_30;
                }
            }
            if (orientation.Y == 0)
            {
                if (orientation.X == 0)
                {
                    return BALL_CORE_0_0;
                }
                if (orientation.X == 30)
                {
                    return BALL_CORE_30_0;
                }
                if (orientation.X == 60)
                {
                    return BALL_CORE_60_0;
                }
                if (orientation.X == 90)
                {
                    return BALL_CORE_90_0;
                }
                if (orientation.X == 120)
                {
                    return BALL_CORE_120_0;
                }
                if (orientation.X == 150)
                {
                    return BALL_CORE_150_0;
                }
            }
            if (orientation.Y == -30)
            {
                if (orientation.X == 0)
                {
                    return BALL_CORE_0_N30;
                }
                if (orientation.X == 30)
                {
                    return BALL_CORE_30_N30;
                }
                if (orientation.X == 60)
                {
                    return BALL_CORE_60_N30;
                }
                if (orientation.X == 90)
                {
                    return BALL_CORE_90_N30;
                }
                if (orientation.X == 120)
                {
                    return BALL_CORE_120_N30;
                }
                if (orientation.X == 150)
                {
                    return BALL_CORE_150_N30;
                }
            }
            if (orientation.Y == -60)
            {
                if (orientation.X == 0)
                {
                    return BALL_CORE_0_N60;
                }
                if (orientation.X == 45)
                {
                    return BALL_CORE_45_N60;
                }
                if (orientation.X == 90)
                {
                    return BALL_CORE_90_N60;
                }
                if (orientation.X == 135)
                {
                    return BALL_CORE_135_N60;
                }
            }
            return BALL_CORE_0_0;
        }

        public static Rectangle GetBallStripesBounds(Vector2 orientation)
        {
            if (orientation.Y == 90)
            {
                return BALL_STRIPES_0_90;
            }
            if (orientation.Y == 60)
            {
                return BALL_STRIPES_0_60;
            }
            if (orientation.Y == 30)
            {
                return BALL_STRIPES_0_30;
            }
            if (orientation.Y == 0)
            {
                return BALL_STRIPES_0_0;
            }
            if (orientation.Y == -30)
            {
                return BALL_STRIPES_0_N30;
            }
            if (orientation.Y == -60)
            {
                return BALL_STRIPES_0_N60;
            }
            return BALL_STRIPES_0_0;
        }

        public static Rectangle GetCharacterBoundsFromChar(char character)
        {
            switch (character)
            {
                case 'A':
                    return UPPERCASE_A_BOUNDS;
                case 'b':
                    return LOWERCASE_B_BOUNDS;
                case 'B':
                    return UPPERCASE_B_BOUNDS;
                case 'c':
                    return LOWERCASE_C_BOUNDS;
                case 'C':
                    return UPPERCASE_C_BOUNDS;
                case 'd':
                    return LOWERCASE_D_BOUNDS;
                case 'D':
                    return UPPERCASE_D_BOUNDS;
                case 'e':
                    return LOWERCASE_E_BOUNDS;
                case 'E':
                    return UPPERCASE_E_BOUNDS;
                case 'f':
                    return LOWERCASE_F_BOUNDS;
                case 'F':
                    return UPPERCASE_F_BOUNDS;
                case 'g':
                    return LOWERCASE_G_BOUNDS;
                case 'G':
                    return UPPERCASE_G_BOUNDS;
                case 'h':
                    return LOWERCASE_H_BOUNDS;
                case 'H':
                    return UPPERCASE_H_BOUNDS;
                case 'i':
                    return LOWERCASE_I_BOUNDS;
                case 'I':
                    return UPPERCASE_I_BOUNDS;
                case 'j':
                    return LOWERCASE_J_BOUNDS;
                case 'J':
                    return UPPERCASE_J_BOUNDS;
                case 'k':
                    return LOWERCASE_K_BOUNDS;
                case 'K':
                    return UPPERCASE_K_BOUNDS;
                case 'l':
                    return LOWERCASE_L_BOUNDS;
                case 'L':
                    return UPPERCASE_L_BOUNDS;
                case 'm':
                    return LOWERCASE_M_BOUNDS;
                case 'M':
                    return UPPERCASE_M_BOUNDS;
                case 'n':
                    return LOWERCASE_N_BOUNDS;
                case 'N':
                    return UPPERCASE_N_BOUNDS;
                case 'o':
                    return LOWERCASE_O_BOUNDS;
                case 'O':
                    return UPPERCASE_O_BOUNDS;
                case 'p':
                    return LOWERCASE_P_BOUNDS;
                case 'P':
                    return UPPERCASE_P_BOUNDS;
                case 'q':
                    return LOWERCASE_Q_BOUNDS;
                case 'Q':
                    return UPPERCASE_Q_BOUNDS;
                case 'r':
                    return LOWERCASE_R_BOUNDS;
                case 'R':
                    return UPPERCASE_R_BOUNDS;
                case 's':
                    return LOWERCASE_S_BOUNDS;
                case 'S':
                    return UPPERCASE_S_BOUNDS;
                case 't':
                    return LOWERCASE_T_BOUNDS;
                case 'T':
                    return UPPERCASE_T_BOUNDS;
                case 'u':
                    return LOWERCASE_U_BOUNDS;
                case 'U':
                    return UPPERCASE_U_BOUNDS;
                case 'v':
                    return LOWERCASE_V_BOUNDS;
                case 'V':
                    return UPPERCASE_V_BOUNDS;
                case 'w':
                    return LOWERCASE_W_BOUNDS;
                case 'W':
                    return UPPERCASE_W_BOUNDS;
                case 'x':
                    return LOWERCASE_X_BOUNDS;
                case 'X':
                    return UPPERCASE_X_BOUNDS;
                case 'y':
                    return LOWERCASE_Y_BOUNDS;
                case 'Y':
                    return UPPERCASE_Y_BOUNDS;
                case 'z':
                    return LOWERCASE_Z_BOUNDS;
                case 'Z':
                    return UPPERCASE_Z_BOUNDS;
                case '.':
                    return PERIOD_BOUNDS;
                case ',':
                    return COMMA_BOUNDS;
                case '!':
                    return EXCLAMATION_POINT_BOUNDS;
                case '?':
                    return QUESTION_MARK_BOUNDS;
                default:
                    return LOWERCASE_A_BOUNDS;
            }
        }
    }
}